using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    internal class RestaurantDashboardDAL
    {
        public DataTable GetRestaurantInfo(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                RestaurantID,
                RestaurantName,
                Phone,
                Address
            FROM Restaurants
            WHERE RestaurantID = @RestaurantID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@RestaurantID",
                    restaurantID
                );

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetDonationStatistics(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                COUNT(*) AS TotalDonations,

                SUM(CASE 
                    WHEN Status = 'Available' THEN 1 
                    ELSE 0 
                END) AS AvailableDonations,

                SUM(CASE 
                    WHEN Status = 'Completed' THEN 1 
                    ELSE 0 
                END) AS CompletedDonations,

                SUM(CASE 
                    WHEN Status = 'Expired' THEN 1 
                    ELSE 0 
                END) AS ExpiredDonations

            FROM FoodDonations
            WHERE RestaurantID = @RestaurantID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public DataTable GetDonationActivity(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                CAST(DonationDate AS DATE) AS DonationDay,
                COUNT(*) AS DonationCount
            FROM FoodDonations
            WHERE RestaurantID = @RestaurantID
              AND DonationDate >= DATEADD(DAY, -6, CAST(GETDATE() AS DATE))
              AND DonationDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
            GROUP BY CAST(DonationDate AS DATE)
            ORDER BY DonationDay";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }


        public DataTable GetDonationStatus(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                Status,
                COUNT(*) AS DonationCount
            FROM FoodDonations
            WHERE RestaurantID = @RestaurantID
              AND Status IN ('Available', 'Completed', 'Expired','Cancelled')
            GROUP BY Status
            ORDER BY Status";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }



        public DataTable GetRecentDonations(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT TOP 5
                FoodType,
                Quantity,
                DonationDate,
                ExpiryTime,
                Status
            FROM FoodDonations
            WHERE RestaurantID = @RestaurantID
            ORDER BY DonationDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }


        public DataTable GetRequestSummary(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                COUNT(*) AS TotalRequests,

                SUM(CASE 
                    WHEN Req.Status = 'Pending' THEN 1 
                    ELSE 0 
                END) AS PendingRequests,

                SUM(CASE 
                    WHEN Req.Status = 'Approved' THEN 1 
                    ELSE 0 
                END) AS ApprovedRequests,

                SUM(CASE 
                    WHEN Req.Status = 'Completed' THEN 1 
                    ELSE 0 
                END) AS CompletedRequests,
  SUM(CASE 
                    WHEN Req.Status = 'Rejected' THEN 1 
                    ELSE 0 
                END) AS RejectedRequests


            FROM Requests Req
            INNER JOIN FoodDonations D
                ON Req.DonationID = D.DonationID

            WHERE D.RestaurantID = @RestaurantID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }
        public string GetRestaurantStatus(int restaurantID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT Status
            FROM Restaurants
            WHERE RestaurantID = @RestaurantID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

                    con.Open();

                    object result = cmd.ExecuteScalar();

                    return result != null
                        ? result.ToString()
                        : "Inactive";
                }
            }
        }


        public void UpdateRestaurantStatus(int restaurantID, string status)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            UPDATE Restaurants
            SET Status = @Status
            WHERE RestaurantID = @RestaurantID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
