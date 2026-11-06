using System.Data.SqlClient;

public class Database
{
    public static SqlConnection GetConnection()
    {
        string connectionString =
        @"Data Source=DESKTOP-NLA7PPI;Initial Catalog=FSMS_DB;Integrated Security=True";

        return new SqlConnection(connectionString);
    }


}