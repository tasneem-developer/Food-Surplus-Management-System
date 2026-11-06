using System;
using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    internal class RestaurantDonationDAL
    {
        public DataTable GetDonations(
       int restaurantID,
       string searchText,
       string status)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                DonationID,
                FoodType,
                Quantity,
                DonationDate,
                ExpiryTime,
                Status
            FROM FoodDonations
            WHERE RestaurantID = @RestaurantID

              AND (
                    @SearchText = ''
                    OR FoodType LIKE @Search
                    OR Status LIKE @Search
                  )

              AND (
                    @Status = 'All'
                    OR Status = @Status
                  )

            ORDER BY CreatedDate DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@RestaurantID",
                        restaurantID
                    );

                    cmd.Parameters.AddWithValue(
                        "@SearchText",
                        searchText
                    );

                    cmd.Parameters.AddWithValue(
                        "@Search",
                        "%" + searchText + "%"
                    );

                    cmd.Parameters.AddWithValue(
                        "@Status",
                        status
                    );

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
        public void UpdateExpiredDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
UPDATE FoodDonations
SET Status = 'Expired'
WHERE
    ExpiryTime <= GETDATE()
    AND Status = 'Available'";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public DataTable GetDonationById(int donationID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            SELECT
                DonationID,
                RestaurantID,
                FoodType,
                Quantity,
                DonationDate,
                ExpiryTime,
                Status
            FROM FoodDonations
            WHERE DonationID = @DonationID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DonationID", donationID);

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }

        public void DeleteDonation(int donationID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            DELETE FROM FoodDonations
            WHERE DonationID = @DonationID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DonationID", donationID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddDonation(
    int restaurantID,
    string foodType,
    int quantity,
    DateTime donationDate,
    DateTime expiryTime)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            INSERT INTO FoodDonations
            (
                RestaurantID,
                FoodType,
                Quantity,
                DonationDate,
                ExpiryTime,
                Status
            )
            VALUES
            (
                @RestaurantID,
                @FoodType,
                @Quantity,
                @DonationDate,
                @ExpiryTime,
                'Available'
            )";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
                    cmd.Parameters.AddWithValue("@FoodType", foodType);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@DonationDate", donationDate);
                    cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }




        public void UpdateDonation(
    int donationID,
    int restaurantID,
    string foodType,
    int quantity,
    DateTime donationDate,
    DateTime expiryTime
   )
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
            UPDATE FoodDonations
            SET
                RestaurantID = @RestaurantID,
                FoodType = @FoodType,
                Quantity = @Quantity,
                DonationDate = @DonationDate,
                ExpiryTime = @ExpiryTime,
                Status = 'Available'
            WHERE DonationID = @DonationID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@DonationID", donationID);
                    cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
                    cmd.Parameters.AddWithValue("@FoodType", foodType);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    cmd.Parameters.AddWithValue("@DonationDate", donationDate);
                    cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }


    }
    }
