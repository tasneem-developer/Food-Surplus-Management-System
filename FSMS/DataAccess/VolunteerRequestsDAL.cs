using System;
using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    internal class VolunteerRequestDAL
    {
        // =========================================================
        // 1. GET MY REQUESTS
        // =========================================================

        public DataTable GetMyRequests(
      int volunteerID,
      string search = "",
      string status = "All")
        {
            using (SqlConnection con =
                Database.GetConnection())
            {
                string query = @"
SELECT
    Req.RequestID,
    D.FoodType,
    D.Quantity,
    R.RestaurantName,
    R.Address,
    D.DonationDate,
    D.ExpiryTime,
    Req.Status,
    Req.AssignedDate

FROM Requests Req

INNER JOIN FoodDonations D
    ON Req.DonationID = D.DonationID

INNER JOIN Restaurants R
    ON D.RestaurantID = R.RestaurantID

WHERE
    Req.VolunteerID = @VolunteerID

    AND
    (
        D.FoodType LIKE '%' + @Search + '%'
        OR R.RestaurantName LIKE '%' + @Search + '%'
        OR R.Address LIKE '%' + @Search + '%'
        OR Req.Status LIKE '%' + @Search + '%'
    )

    AND
    (
        @Status = 'All'
        OR Req.Status = @Status
    )

ORDER BY
    Req.AssignedDate DESC,
    Req.RequestID DESC;
";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    cmd.Parameters.AddWithValue(
                        "@Search",
                        search ?? "");

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        status ?? "All");

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt =
                            new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }


        // =========================================================
        // 2. CANCEL PENDING REQUEST
        // =========================================================

        public bool CancelRequest(int requestID)
        {
            using (SqlConnection con =
                Database.GetConnection())
            {
                string query = @"
UPDATE Requests
SET
    Status = 'Cancelled'
WHERE
    RequestID = @RequestID
    AND Status = 'Pending';

SELECT @@ROWCOUNT;
";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@RequestID",
                        requestID);

                    con.Open();

                    int affectedRows =
                        Convert.ToInt32(
                            cmd.ExecuteScalar());

                    return affectedRows > 0;
                }
            }
        }


        // =========================================================
        // 3. COMPLETE APPROVED REQUEST
        // =========================================================

        public bool CompleteRequest(int requestID)
        {
            using (SqlConnection con =
                Database.GetConnection())
            {
                string query = @"
UPDATE Requests
SET
    Status = 'Completed'
WHERE
    RequestID = @RequestID
    AND Status = 'Approved';

SELECT @@ROWCOUNT;
";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@RequestID",
                        requestID);

                    con.Open();

                    int affectedRows =
                        Convert.ToInt32(
                            cmd.ExecuteScalar());

                    return affectedRows > 0;
                }
            }
        }
    }
}