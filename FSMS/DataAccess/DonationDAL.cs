using System;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    public class DonationDAL
    {

        public static void DeleteDonation(int id)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                string query =
                @"DELETE FROM FoodDonations
                  WHERE DonationID=@id";


                SqlCommand cmd =
                    new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@id", id);


                cmd.ExecuteNonQuery();
            }
        }


        //public DataTable GetDonations()
        //{
        //    DataTable dt = new DataTable();

        //    using (SqlConnection con = Database.GetConnection())
        //    {
        //        string query = @"
        //SELECT
        //    fd.DonationID,
        //    r.RestaurantName,
        //    fd.FoodType,
        //    fd.Quantity,
        //    fd.DonationDate,
        //    fd.ExpiryTime,
        //    fd.Status
        //FROM FoodDonations fd
        //INNER JOIN Restaurants r
        //    ON fd.RestaurantID = r.RestaurantID
        //ORDER BY fd.DonationDate DESC";

        //        SqlDataAdapter da = new SqlDataAdapter(query, con);
        //        da.Fill(dt);
        //    }

        //    return dt;
        //}

        public DataTable GetDonations(string search = "", string status = "All")
        {
            using (SqlConnection con = Database.GetConnection())
            {

                string query = @"
    SELECT 
        d.DonationID,
        r.RestaurantName,
        d.FoodType,
        d.Quantity,
        d.DonationDate,
        d.ExpiryTime,
        d.Status

    FROM FoodDonations d

    INNER JOIN Restaurants r
    ON d.RestaurantID = r.RestaurantID


    WHERE
    (
        r.RestaurantName LIKE @search
        OR
        d.FoodType LIKE @search
        OR
        d.ExpiryTime LIKE @search
    )

    AND

    (
        @status = 'All'
        OR
        d.Status = @status
    )

    ";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue(
                    "@search",
                    "%" + search + "%"
                );


                cmd.Parameters.AddWithValue(
                    "@status",
                    status
                );


                SqlDataAdapter da = new SqlDataAdapter(cmd);


                DataTable dt = new DataTable();


                da.Fill(dt);


                return dt;
            }
        }

        public static DataTable GetDonationById(int donationID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT
            RestaurantID,
            FoodType,
            Quantity,
            DonationDate,
            ExpiryTime,
            Status
        FROM FoodDonations
        WHERE DonationID = @DonationID";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters.AddWithValue("@DonationID", donationID);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }


        public static DataTable GetRestaurants()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query =
                @"SELECT RestaurantID,RestaurantName
          FROM Restaurants
          ORDER BY RestaurantName";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        //public static void UpdateDonation(
        //  int donationID,
        //  int restaurantID,
        //  string foodType,
        //  int quantity,
        //  DateTime donationDate,
        //  DateTime expiryTime,
        //  string status)
        //{
        //    using (SqlConnection con = Database.GetConnection())
        //    {
        //        con.Open();

        //        string query = @"
        //UPDATE FoodDonations
        //SET RestaurantID = @RestaurantID,
        //    FoodType = @FoodType,
        //    Quantity = @Quantity,
        //    DonationDate = @DonationDate,
        //    ExpiryTime = @ExpiryTime,
        //    Status = @Status
        //WHERE DonationID = @DonationID";

        //        SqlCommand cmd = new SqlCommand(query, con);

        //        cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
        //        cmd.Parameters.AddWithValue("@FoodType", foodType);
        //        cmd.Parameters.AddWithValue("@Quantity", quantity);
        //        cmd.Parameters.AddWithValue("@DonationDate", donationDate);
        //        cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
        //        cmd.Parameters.AddWithValue("@Status", status);
        //        cmd.Parameters.AddWithValue("@DonationID", donationID);

        //        cmd.ExecuteNonQuery();
        //    }
        //}
        public static DataTable GetRestaurantsForCombo()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"SELECT RestaurantID, RestaurantName
                         FROM Restaurants
                         WHERE Status='Active'
                         ORDER BY RestaurantName";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public void AddDonation(
    int restaurantID,
    string foodType,
    int quantity,
    DateTime donationDate,
    DateTime expiryTime,
    string status)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                string query = @"
        INSERT INTO FoodDonations
        (
            RestaurantID,
            FoodType,
            Quantity,
            DonationDate,
            ExpiryTime,
            Status,
            CreatedDate
        )
        VALUES
        (
            @RestaurantID,
            @FoodType,
            @Quantity,
            @DonationDate,
            @ExpiryTime,
            @Status,
            GETDATE()
        )";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
                cmd.Parameters.AddWithValue("@FoodType", foodType);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@DonationDate", donationDate);
                cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                cmd.Parameters.AddWithValue("@Status", status);

                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateDonation(
    int donationID,
    int restaurantID,
    string foodType,
    int quantity,
    DateTime donationDate,
    DateTime expiryTime,
    string status)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                string query = @"
        UPDATE FoodDonations
        SET
            RestaurantID = @RestaurantID,
            FoodType = @FoodType,
            Quantity = @Quantity,
            DonationDate = @DonationDate,
            ExpiryTime = @ExpiryTime,
            Status = @Status
        WHERE DonationID = @DonationID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DonationID", donationID);
                cmd.Parameters.AddWithValue("@RestaurantID", restaurantID);
                cmd.Parameters.AddWithValue("@FoodType", foodType);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@DonationDate", donationDate);
                cmd.Parameters.AddWithValue("@ExpiryTime", expiryTime);
                cmd.Parameters.AddWithValue("@Status", status);

                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable GetDonationStatusCount()
        {
            using (SqlConnection con = Database.GetConnection())
            {

                string query = @"
        SELECT 
            Status,
            COUNT(*) AS Total
        FROM FoodDonations
        GROUP BY Status
    ";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public static int GetTotalDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT COUNT(*) 
        FROM FoodDonations
    ";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                return count;
            }
        }


        public static int GetAvailableDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT COUNT(*) 
        FROM FoodDonations
        WHERE Status = 'Available'
    ";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                return count;
            }
        }

        public static int GetCompletedDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT COUNT(*) 
        FROM FoodDonations
        WHERE Status = 'Completed'
    ";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                return count;
            }
        }

        public static int GetExpiredDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT COUNT(*) 
        FROM FoodDonations
        WHERE Status = 'Expired'
                 ";

                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                con.Close();

                return count;
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

    }


}