using System;
using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    public class RestaurantDAL
    {
        public DataTable GetRestaurants(string search = "", string status = "All")
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
                SELECT
                    RestaurantID,
                    RestaurantName,
                    Phone,
                    Address,
                    Status
                FROM Restaurants
                WHERE
                    (RestaurantName LIKE @search
                    OR Phone LIKE @search
                    OR Address LIKE @search)";


                if (status != "All")
                {
                    query += " AND Status = @status";
                }


                SqlDataAdapter da = new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters.AddWithValue(
                    "@search",
                    "%" + search + "%"
                );


                if (status != "All")
                {
                    da.SelectCommand.Parameters.AddWithValue(
                        "@status",
                        status
                    );
                }


                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public void DeleteRestaurant(int id)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                string query =
                    "DELETE FROM Restaurants WHERE RestaurantID = @id";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public int GetTotalRestaurants()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Restaurants",
                    con
                );

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetActiveRestaurants()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Restaurants WHERE Status='Active'",
                    con
                );

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetActiveRestaurantsThisWeek()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*)
          FROM Restaurants
          WHERE Status='Active'
          AND CreatedDate >= DATEADD(DAY,-7,GETDATE())",
                con);


                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetInactiveRestaurants()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Restaurants WHERE Status='Inactive'",
                    con
                );

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetNewRestaurants()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*)
          FROM Restaurants
          WHERE CreatedDate >= DATEADD(DAY,-7,GETDATE())",
                con);


                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public SqlDataReader GetRestaurantById(int id)
        {
            SqlConnection con = Database.GetConnection();

            con.Open();

            string query =
            @"SELECT *
      FROM Restaurants
      WHERE RestaurantID=@id";


            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@id", id);


            return cmd.ExecuteReader();
        }
        public void UpdateRestaurant(
    int id,
    string name,
    string phone,
    string contact,
    string address,
    string status,
    string notes)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                string query =
                @"UPDATE Restaurants
          SET RestaurantName=@name,
              Phone=@phone,
              ContactPerson=@contact,
              Address=@address,
              Status=@status,
              Notes=@notes
          WHERE RestaurantID=@id";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@contact", contact);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@notes", notes);
                cmd.Parameters.AddWithValue("@id", id);


                cmd.ExecuteNonQuery();
            }
        }




        public void AddRestaurant(
    string username,
    string password,
    string restaurantName,
    string phone,
    string contactPerson,
    string address,
    string status,
    string notes)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Add User
                    string userQuery = @"
            INSERT INTO Users
            (Username, Password, Role, createdDate)
            VALUES
            (@Username, @Password, 'Restaurant', GETDATE());

            SELECT SCOPE_IDENTITY();";


                    SqlCommand userCmd =
                        new SqlCommand(userQuery, con, transaction);


                    userCmd.Parameters.AddWithValue("@Username", username);
                    userCmd.Parameters.AddWithValue("@Password", password);


                    int userID =
                        Convert.ToInt32(userCmd.ExecuteScalar());



                    // Add Restaurant
                    string restaurantQuery = @"
            INSERT INTO Restaurants
            (UserID, RestaurantName, Phone, ContactPerson, Address, Status, Notes, createdDate)
            VALUES
            (@UserID, @RestaurantName, @Phone, @ContactPerson,
             @Address, @Status, @Notes, GETDATE())";


                    SqlCommand restaurantCmd =
                        new SqlCommand(restaurantQuery, con, transaction);


                    restaurantCmd.Parameters.AddWithValue("@UserID", userID);
                    restaurantCmd.Parameters.AddWithValue("@RestaurantName", restaurantName);
                    restaurantCmd.Parameters.AddWithValue("@Phone", phone);
                    restaurantCmd.Parameters.AddWithValue("@ContactPerson", contactPerson);
                    restaurantCmd.Parameters.AddWithValue("@Address", address);
                    restaurantCmd.Parameters.AddWithValue("@Status", status);
                    restaurantCmd.Parameters.AddWithValue("@Notes", notes);


                    restaurantCmd.ExecuteNonQuery();


                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }




    }

}