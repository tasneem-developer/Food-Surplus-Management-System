using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    internal class RestaurantRequestDAL
    {
        public DataTable GetRequests(
            int restaurantID,
            string search = "",
            string status = "All")
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
                    SELECT
                        R.RequestID,
                        V.FullName AS VolunteerName,
                        D.FoodType,
                        D.Quantity,
                        R.AssignedDate AS RequestDate,
                        R.Status
                    FROM Requests R
                    INNER JOIN Volunteers V
                        ON R.VolunteerID = V.VolunteerID
                    INNER JOIN FoodDonations D
                        ON R.DonationID = D.DonationID
                    WHERE D.RestaurantID = @RestaurantID
                    AND
                    (
                        V.FullName LIKE @Search
                        OR D.FoodType LIKE @Search
                    )
                    AND
                    (
                        @Status = 'All'
                        OR R.Status = @Status
                    )
                    ORDER BY R.CreatedDate DESC";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@RestaurantID",
                        restaurantID);

                    cmd.Parameters.AddWithValue(
                        "@Search",
                        "%" + search + "%");

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        status);

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

        public DataTable GetRequestStatistics(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                COUNT(*) AS TotalRequests,

                SUM(CASE
                    WHEN R.Status = 'Pending'
                    THEN 1 ELSE 0
                END) AS PendingRequests,

                SUM(CASE
                    WHEN R.Status = 'Approved'
                    THEN 1 ELSE 0
                END) AS ApprovedRequests,

                SUM(CASE
                    WHEN R.Status = 'Completed'
                    THEN 1 ELSE 0
                END) AS CompletedRequests

            FROM Requests R

            INNER JOIN FoodDonations D
                ON R.DonationID = D.DonationID

            WHERE D.RestaurantID = @RestaurantID";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@RestaurantID",
                        restaurantID);

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
    }
}