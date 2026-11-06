using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    internal class VolunteerDashboardDAL
    {
        // جلب بيانات المتطوع
        public DataTable GetVolunteerInfo(int volunteerID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
                    SELECT
                        VolunteerID,
                        FullName,
                        Phone,
                        Area,
                        Status
                    FROM Volunteers
                    WHERE VolunteerID = @VolunteerID";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }


        // إحصائيات Dashboard
        public DataTable GetVolunteerStatistics(int volunteerID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
                    SELECT

                    -- التبرعات المتاحة في منطقة المتطوع
                    (
                        SELECT COUNT(*)
                        FROM FoodDonations D
                        INNER JOIN Restaurants R
                            ON D.RestaurantID = R.RestaurantID

                        INNER JOIN Volunteers V
                            ON V.VolunteerID = @VolunteerID

                        WHERE
                            V.Status = 'Active'
                            AND D.Status = 'Available'
                            AND D.ExpiryTime > GETDATE()
                            AND R.Address LIKE '%' + V.Area + '%'
                    ) AS AvailableDonations,


                    -- جميع طلبات المتطوع
                    COUNT(RQ.RequestID) AS TotalRequests,


                    -- Pending
                    SUM(
                        CASE
                            WHEN RQ.Status = 'Pending'
                            THEN 1
                            ELSE 0
                        END
                    ) AS PendingRequests,


                    -- Approved
                    SUM(
                        CASE
                            WHEN RQ.Status = 'Approved'
                            THEN 1
                            ELSE 0
                        END
                    ) AS ApprovedRequests,


                    -- Completed
                    SUM(
                        CASE
                            WHEN RQ.Status = 'Completed'
                            THEN 1
                            ELSE 0
                        END
                    ) AS CompletedRequests

                    FROM Volunteers V

                    LEFT JOIN Requests RQ
                        ON V.VolunteerID = RQ.VolunteerID

                    WHERE
                        V.VolunteerID = @VolunteerID";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public DataTable GetMyRequestStatus(int volunteerID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                Status,
                COUNT(*) AS RequestCount
            FROM Requests
            WHERE VolunteerID = @VolunteerID
              AND Status IN ('Pending', 'Approved', 'Completed')
            GROUP BY Status
            ORDER BY Status";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public DataTable GetApprovedRequests(int volunteerID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT TOP 5
                R.RequestID,
                D.FoodType,
                R.Status,
                R.AssignedDate
            FROM Requests R

            INNER JOIN FoodDonations D
                ON R.DonationID = D.DonationID

            WHERE
                R.VolunteerID = @VolunteerID

            AND
                R.Status = 'Approved'

            ORDER BY
                R.AssignedDate DESC";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }


            }
        }


        public DataTable GetRecentRequests(int volunteerID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT TOP 5
                R.RequestID,
                D.FoodType,
                D.Quantity,
                Res.RestaurantName,
                R.CreatedDate AS RequestDate,
                R.Status

            FROM Requests R

            INNER JOIN FoodDonations D
                ON R.DonationID = D.DonationID

            INNER JOIN Restaurants Res
                ON D.RestaurantID = Res.RestaurantID

            WHERE R.VolunteerID = @VolunteerID

            ORDER BY R.CreatedDate DESC";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }


        public string GetVolunteerStatus(int volunteerID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT Status
        FROM Volunteers
        WHERE VolunteerID = @VolunteerID";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    con.Open();

                    object result =
                        cmd.ExecuteScalar();

                    return result != null
                        ? result.ToString()
                        : "Inactive";
                }
            }
        }


        public void UpdateVolunteerStatus(
            int volunteerID,
            string status)
        {
            using (SqlConnection con =
                Database.GetConnection())
            {
                string query = @"
        UPDATE Volunteers
        SET Status = @Status
        WHERE VolunteerID = @VolunteerID";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Status",
                        status);

                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}