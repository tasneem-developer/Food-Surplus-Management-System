using System;
using System.Data;
using System.Data.SqlClient;
namespace FSMS.DAL
{
    public class RequestDAL
    {

        public DataTable GetRequests(string search = "", string status = "All")
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
SELECT
R.RequestID,
R.DonationID,
R.VolunteerID,

V.FullName AS VolunteerName,

Res.RestaurantName,

D.FoodType,

D.Quantity,

R.AssignedDate,

R.Status

FROM Requests R

INNER JOIN Volunteers V
ON R.VolunteerID = V.VolunteerID

INNER JOIN FoodDonations D
ON R.DonationID = D.DonationID

INNER JOIN Restaurants Res
ON D.RestaurantID = Res.RestaurantID

WHERE
(
V.FullName LIKE @Search
OR
Res.RestaurantName LIKE @Search
OR
D.FoodType LIKE @Search
)
";

                if (status != "All")
                {
                    query += " AND R.Status = @Status ";
                }

                query += " ORDER BY R.RequestID DESC";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@Search", "%" + search + "%");

                if (status != "All")
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }


            public DataTable GetRequestStatistics()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

COUNT(*) AS TotalAssignments,

SUM(CASE WHEN Status='Pending' THEN 1 ELSE 0 END) AS Pending,

SUM(CASE WHEN Status='Approved' THEN 1 ELSE 0 END) AS Approved,

SUM(CASE WHEN Status='Completed' THEN 1 ELSE 0 END) AS Completed

FROM Requests";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }


        public void DeleteRequest(int id)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query =
                    "DELETE FROM Requests WHERE RequestID=@ID";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public DataTable GetVolunteers()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT
        VolunteerID,
        FullName
        FROM Volunteers
        ";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }


        public DataTable GetDonationDetails(int donationID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

R.RestaurantName,

D.FoodType,

D.Quantity

FROM FoodDonations D

INNER JOIN Restaurants R
ON D.RestaurantID = R.RestaurantID

WHERE D.DonationID=@DonationID";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DonationID", donationID);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
        public void InsertRequest(
    int donationID,
    int volunteerID,
    string status,
    DateTime assignedDate)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        INSERT INTO Requests
        (
            DonationID,
            VolunteerID,
            Status,
            AssignedDate
        )

        VALUES
        (
            @DonationID,
            @VolunteerID,
            @Status,
            @AssignedDate
        )";


                SqlCommand cmd = new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@DonationID", donationID);

                cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);

                cmd.Parameters.AddWithValue("@Status", status);

                cmd.Parameters.AddWithValue("@AssignedDate", assignedDate);


                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateRequest(
    int requestID,
    int donationID,
    int volunteerID,
    string status,
    DateTime assignedDate)
        {

            using (SqlConnection con = Database.GetConnection())
            {

                string query = @"

        UPDATE Requests

        SET

        DonationID = @DonationID,

        VolunteerID = @VolunteerID,

        Status = @Status,

        AssignedDate = @AssignedDate


        WHERE RequestID = @RequestID

        ";


                SqlCommand cmd =
                    new SqlCommand(query, con);


                cmd.Parameters.AddWithValue("@RequestID", requestID);

                cmd.Parameters.AddWithValue("@DonationID", donationID);

                cmd.Parameters.AddWithValue("@VolunteerID", volunteerID);

                cmd.Parameters.AddWithValue("@Status", status);

                cmd.Parameters.AddWithValue("@AssignedDate", assignedDate);


                con.Open();

                cmd.ExecuteNonQuery();

            }

        }
        public DataTable GetRequestByID(int id)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
        SELECT
            RequestID,
            DonationID,
            VolunteerID,
            Status,
            AssignedDate

        FROM Requests

        WHERE RequestID = @ID
        ";


                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@ID", id);


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);


                return dt;
            }
        }

        public DataTable GetRequestDetails(int requestID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

V.FullName AS VolunteerName,

R.RestaurantName,

D.FoodType,

D.Quantity,

Req.Status,

Req.AssignedDate

FROM Requests Req

INNER JOIN Volunteers V
ON Req.VolunteerID = V.VolunteerID

INNER JOIN FoodDonations D
ON Req.DonationID = D.DonationID

INNER JOIN Restaurants R
ON D.RestaurantID = R.RestaurantID

WHERE Req.RequestID = @RequestID

";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@RequestID", requestID);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }
        public DataTable GetAvailableDonations()
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

D.DonationID,

R.RestaurantName + ' - ' +
D.FoodType + ' (' +
CAST(D.Quantity AS NVARCHAR) + ')' AS DonationInfo

FROM FoodDonations D

INNER JOIN Restaurants R
ON D.RestaurantID = R.RestaurantID

WHERE D.Status = 'Available'

AND D.DonationID NOT IN
(
    SELECT DonationID
    FROM Requests
)

ORDER BY D.DonationID DESC";

                SqlDataAdapter da =
                    new SqlDataAdapter(query, con);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }


        public DataTable GetAvailableDonations(int requestID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT

D.DonationID,

R.RestaurantName + ' - ' +
D.FoodType + ' (' +
CAST(D.Quantity AS NVARCHAR) + ')' AS DonationInfo

FROM FoodDonations D

INNER JOIN Restaurants R
ON D.RestaurantID = R.RestaurantID

WHERE

(
D.Status='Available'

AND D.DonationID NOT IN
(
SELECT DonationID FROM Requests
)

)

OR

D.DonationID=
(
SELECT DonationID
FROM Requests
WHERE RequestID=@RequestID
)

ORDER BY DonationInfo";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                cmd.Parameters.AddWithValue(
                    "@RequestID",
                    requestID);

                SqlDataAdapter da =
                    new SqlDataAdapter(cmd);

                DataTable dt =
                    new DataTable();

                da.Fill(dt);

                return dt;
            }
        }

        public DataTable GetAvailableVolunteers(int donationID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"

SELECT
    V.VolunteerID,
    V.FullName,
    V.Area

FROM Volunteers V

INNER JOIN FoodDonations D
ON 1=1

INNER JOIN Restaurants R
ON D.RestaurantID = R.RestaurantID

WHERE
    D.DonationID = @DonationID

AND
    V.Status = 'Active'

AND
    R.Address LIKE '%' + V.Area + '%'

ORDER BY V.FullName
";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@DonationID", donationID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                return dt;
            }
        }


        public bool ApproveRequest(int requestID)
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
DECLARE @DonationID INT;

BEGIN TRANSACTION;

BEGIN TRY

    -- معرفة التبرع الخاص بالطلب
    SELECT @DonationID = DonationID
    FROM Requests
    WHERE RequestID = @RequestID
      AND Status = 'Pending';

    -- إذا الطلب غير موجود أو ليس Pending
    IF @DonationID IS NULL
    BEGIN
        ROLLBACK TRANSACTION;
        SELECT 0;
        RETURN;
    END;


    -- اعتماد الطلب الذي اختاره الأدمن
    UPDATE Requests
    SET Status = 'Approved'
    WHERE RequestID = @RequestID
      AND Status = 'Pending';


    -- رفض باقي الطلبات لنفس التبرع
    UPDATE Requests
    SET Status = 'Rejected'
    WHERE DonationID = @DonationID
      AND RequestID <> @RequestID
      AND Status = 'Pending';


    -- تغيير حالة التبرع مباشرة بعد الاعتماد
    UPDATE FoodDonations
    SET Status = 'Completed'
    WHERE DonationID = @DonationID
      AND Status = 'Available';


    COMMIT TRANSACTION;

    SELECT 1;

END TRY

BEGIN CATCH

    ROLLBACK TRANSACTION;
    SELECT 0;

END CATCH;
";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@RequestID",
                        requestID);

                    con.Open();

                    return Convert.ToInt32(
                        cmd.ExecuteScalar()) == 1;
                }
            }
        }
    }
    }









