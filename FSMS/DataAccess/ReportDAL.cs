using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMS.DataAccess
{
    internal class ReportDAL
    {

        public DataTable GetDonationReport(DateTime from, DateTime to)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

R.RestaurantName,

D.FoodType,

D.Quantity,

D.Status,

D.DonationDate,

D.ExpiryTime

FROM FoodDonations D

INNER JOIN Restaurants R
ON D.RestaurantID = R.RestaurantID

WHERE

CAST(D.DonationDate AS DATE)
BETWEEN @From AND @To

ORDER BY D.DonationDate DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@From", from.Date);

                cmd.Parameters.AddWithValue("@To", to.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetRequestReport(DateTime from, DateTime to)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

Res.RestaurantName,

V.FullName AS Volunteer,

D.FoodType,

D.Quantity,

Req.Status,

Req.AssignedDate

FROM Requests Req

INNER JOIN FoodDonations D
ON Req.DonationID=D.DonationID

INNER JOIN Restaurants Res
ON D.RestaurantID=Res.RestaurantID

INNER JOIN Volunteers V
ON Req.VolunteerID=V.VolunteerID

WHERE

CAST(Req.AssignedDate AS DATE)
BETWEEN @From AND @To

ORDER BY Req.AssignedDate DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@From", from.Date);

                cmd.Parameters.AddWithValue("@To", to.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetRestaurantReport(DateTime from, DateTime to)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

RestaurantName,

Phone,

Address,

Status,

CreatedDate

FROM Restaurants
WHERE

CAST(CreatedDate AS DATE)
BETWEEN @From AND @To

ORDER BY RestaurantName";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@From", from.Date);

                cmd.Parameters.AddWithValue("@To", to.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
        public DataTable GetVolunteerReport(DateTime from, DateTime to)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

FullName,

Phone,

Area,

Status,

CreatedDate

FROM Volunteers

WHERE

CAST(CreatedDate AS DATE)
BETWEEN @From AND @To

ORDER BY FullName";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@From", from.Date);

                cmd.Parameters.AddWithValue("@To", to.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
        public DataTable GetSummaryReport(DateTime from, DateTime to)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

(
    SELECT COUNT(*)
    FROM Restaurants
    WHERE CAST(CreatedDate AS DATE)
    BETWEEN @From AND @To
) AS TotalRestaurants,


(
    SELECT COUNT(*)
    FROM Volunteers
    WHERE CAST(CreatedDate AS DATE)
    BETWEEN @From AND @To
) AS TotalVolunteers,


(
    SELECT COUNT(*)
    FROM FoodDonations
    WHERE CAST(DonationDate AS DATE)
    BETWEEN @From AND @To
) AS TotalDonations,


(
    SELECT COUNT(*)
    FROM Requests
    WHERE CAST(AssignedDate AS DATE)
    BETWEEN @From AND @To
) AS TotalRequests,


(
    SELECT COUNT(*)
    FROM FoodDonations
    WHERE Status = 'Available'
    AND CAST(DonationDate AS DATE)
    BETWEEN @From AND @To
) AS AvailableDonations,


(
    SELECT COUNT(*)
    FROM FoodDonations
    WHERE Status = 'Expired'
    AND CAST(DonationDate AS DATE)
    BETWEEN @From AND @To
) AS ExpiredDonations,


(
    SELECT COUNT(*)
    FROM Requests
    WHERE Status = 'Pending'
    AND CAST(AssignedDate AS DATE)
    BETWEEN @From AND @To
) AS PendingRequests,


(
    SELECT COUNT(*)
    FROM Requests
    WHERE Status = 'Completed'
    AND CAST(AssignedDate AS DATE)
    BETWEEN @From AND @To
) AS CompletedRequests
";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@From", from.Date);
                cmd.Parameters.AddWithValue("@To", to.Date);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
    }
}
