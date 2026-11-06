using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMS.DataAccess
{
    internal class DashboardDAL
    {
        public int GetTotalRestaurants()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query =
                    "SELECT COUNT(*) FROM Restaurants";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                con.Open();

                return (int)cmd.ExecuteScalar();
            }
        }


        public int GetTotalVolunteers()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query =
                    "SELECT COUNT(*) FROM Volunteers";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                con.Open();

                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetTotalDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query =
                    "SELECT COUNT(*) FROM FoodDonations";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                con.Open();

                return (int)cmd.ExecuteScalar();
            }
        }

        public int GetCompletedRequests()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query =
                @"SELECT COUNT(*) 
          FROM Requests
          WHERE Status='Completed'";


                SqlCommand cmd =
                    new SqlCommand(query, con);

                con.Open();

                return (int)cmd.ExecuteScalar();
            }
        }


        public DataTable GetDonationStatus()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT 
            Status,
            COUNT(*) AS Total
        FROM FoodDonations
        GROUP BY Status";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetMonthlyDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT
            DATENAME(MONTH, DonationDate) AS MonthName,
            COUNT(*) AS Total
        FROM FoodDonations

        GROUP BY
            DATENAME(MONTH, DonationDate),
            MONTH(DonationDate)

        ORDER BY
            MONTH(DonationDate)";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetRequestStatus()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT
            Status,
            COUNT(*) AS Total
        FROM Requests

        GROUP BY Status";


                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);


                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetRecentDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT TOP 5

R.RestaurantName,

D.FoodType,

D.Quantity,

D.Status,

D.DonationDate
FROM FoodDonations D

INNER JOIN Restaurants R
ON D.RestaurantID = R.RestaurantID

ORDER BY D.CreatedDate DESC";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }




        public DataTable GetRecentRequests()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT TOP 5

V.FullName AS VolunteerName,

R2.RestaurantName,

D.FoodType,

Req.Status,
Req.AssignedDate
FROM Requests Req

INNER JOIN Volunteers V
ON Req.VolunteerID=V.VolunteerID

INNER JOIN FoodDonations D
ON Req.DonationID=D.DonationID

INNER JOIN Restaurants R2
ON D.RestaurantID=R2.RestaurantID

ORDER BY Req.CreatedDate DESC";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }


        public DataTable GetNotifications()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

-- Expired Donations
SELECT
    'Expired Donation' AS Title,
    R.RestaurantName + ' donation has expired.' AS Message,
    D.ExpiryTime AS NotificationDate,
    'Expired' AS Type
FROM FoodDonations D
INNER JOIN Restaurants R
    ON D.RestaurantID = R.RestaurantID
WHERE D.Status = 'Expired'


UNION ALL


-- Donations Expiring Tomorrow
SELECT
    'Expiring Tomorrow' AS Title,
    R.RestaurantName + ' donation expires tomorrow.' AS Message,
    D.ExpiryTime AS NotificationDate,
    'Tomorrow' AS Type
FROM FoodDonations D
INNER JOIN Restaurants R
    ON D.RestaurantID = R.RestaurantID
WHERE CAST(D.ExpiryTime AS DATE) =
      DATEADD(DAY, 1, CAST(GETDATE() AS DATE))
AND D.Status = 'Available'


UNION ALL


-- New Assignments
SELECT
    'New Assignment' AS Title,
    V.FullName + ' assigned to a donation.' AS Message,
    Req.AssignedDate AS NotificationDate,
    'Assignment' AS Type
FROM
(
    SELECT TOP 5
        RequestID,
        VolunteerID,
        AssignedDate
    FROM Requests
    WHERE AssignedDate IS NOT NULL
    ORDER BY RequestID DESC
) Req
INNER JOIN Volunteers V
    ON Req.VolunteerID = V.VolunteerID


UNION ALL


-- New Restaurants
SELECT
    'New Restaurant' AS Title,
    R.RestaurantName + ' has joined the system.' AS Message,
    R.CreatedDate AS NotificationDate,
    'Restaurant' AS Type
FROM
(
    SELECT TOP 3
        RestaurantID,
        RestaurantName,
        CreatedDate
    FROM Restaurants
    ORDER BY RestaurantID DESC
) R


UNION ALL


-- New Volunteers
SELECT
    'New Volunteer' AS Title,
    V.FullName + ' registered as volunteer.' AS Message,
    V.CreatedDate AS NotificationDate,
    'Volunteer' AS Type
FROM
(
    SELECT TOP 3
        VolunteerID,
        FullName,
        CreatedDate
    FROM Volunteers
    ORDER BY VolunteerID DESC
) V


ORDER BY NotificationDate DESC;
";

                SqlDataAdapter da = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
    }
}
