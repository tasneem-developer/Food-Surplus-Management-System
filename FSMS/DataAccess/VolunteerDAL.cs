using System;
using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    public class VolunteerDAL
    {
        public DataTable GetVolunteers(string search = "", string status = "All")
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

        WHERE
        (FullName LIKE @search
        OR Phone LIKE @search
        OR Area LIKE @search)
        ";


                if (status != "All")
                {
                    query += " AND Status=@status";
                }


                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);


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

        public int GetTotalVolunteers()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Volunteers",
                    con);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetActiveVolunteers()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Volunteers WHERE Status='Active'",
                    con);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        public int GetInactiveVolunteers()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Volunteers WHERE Status='Inactive'",
                    con);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int GetNewVolunteers()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*)
          FROM Volunteers
          WHERE CreatedDate >= DATEADD(DAY,-7,GETDATE())",
                con);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }


        public int GetActiveVolunteersThisWeek()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*)
          FROM Volunteers
          WHERE Status='Active'
          AND CreatedDate >= DATEADD(DAY,-7,GETDATE())",
                con);

                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public void AddVolunteer(
    string username,
    string password,
    string fullName,
    string phone,
    string area,
    string status)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    string userQuery = @"
            INSERT INTO Users
            (Username, Password, Role, CreatedDate)
            VALUES
            (@Username,@Password,'Volunteer',GETDATE());

            SELECT SCOPE_IDENTITY();";

                    SqlCommand userCmd =
                        new SqlCommand(userQuery, con, transaction);

                    userCmd.Parameters.AddWithValue("@Username", username);
                    userCmd.Parameters.AddWithValue("@Password", password);

                    int userID =
                        Convert.ToInt32(userCmd.ExecuteScalar());

                    string volunteerQuery = @"
            INSERT INTO Volunteers
            (UserID, FullName, Phone, Area, Status, CreatedDate)
            VALUES
            (@UserID,@FullName,@Phone,@Area,@Status,GETDATE())";

                    SqlCommand volunteerCmd =
                        new SqlCommand(volunteerQuery, con, transaction);

                    volunteerCmd.Parameters.AddWithValue("@UserID", userID);
                    volunteerCmd.Parameters.AddWithValue("@FullName", fullName);
                    volunteerCmd.Parameters.AddWithValue("@Phone", phone);
                    volunteerCmd.Parameters.AddWithValue("@Area", area);
                    volunteerCmd.Parameters.AddWithValue("@Status", status);

                    volunteerCmd.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public DataTable GetVolunteerById(int id)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"SELECT *
                         FROM Volunteers
                         WHERE VolunteerID=@id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                da.SelectCommand.Parameters.AddWithValue("@id", id);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public void UpdateVolunteer(
    int id,
    string fullName,
    string phone,
    string area,
    string status)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                string query = @"
        UPDATE Volunteers
        SET
            FullName=@FullName,
            Phone=@Phone,
            Area=@Area,
            Status=@Status
        WHERE VolunteerID=@ID";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Phone", phone);
                cmd.Parameters.AddWithValue("@Area", area);
                cmd.Parameters.AddWithValue("@Status", status);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteVolunteer(int id)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                con.Open();

                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // الحصول على UserID المرتبط بالمتطوع
                    SqlCommand getUser = new SqlCommand(
                        "SELECT UserID FROM Volunteers WHERE VolunteerID=@id",
                        con,
                        transaction);

                    getUser.Parameters.AddWithValue("@id", id);

                    object result = getUser.ExecuteScalar();

                    if (result == null)
                        throw new Exception("Volunteer not found.");

                    int userID = Convert.ToInt32(result);

                    // حذف المتطوع
                    SqlCommand deleteVolunteer = new SqlCommand(
                        "DELETE FROM Volunteers WHERE VolunteerID=@id",
                        con,
                        transaction);

                    deleteVolunteer.Parameters.AddWithValue("@id", id);

                    deleteVolunteer.ExecuteNonQuery();

                    // حذف المستخدم
                    SqlCommand deleteUser = new SqlCommand(
                        "DELETE FROM Users WHERE UserID=@userID",
                        con,
                        transaction);

                    deleteUser.Parameters.AddWithValue("@userID", userID);

                    deleteUser.ExecuteNonQuery();

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