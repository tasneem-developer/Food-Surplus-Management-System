using System;
using System.Data;
using System.Data.SqlClient;

namespace FSMS.DataAccess
{
    internal class VolunteerDonationDAL
    {
        // =========================================================
        // 1. GET AVAILABLE DONATIONS
        // =========================================================
        public DataTable GetAvailableDonations(
            int volunteerID,
            string search = "")
        {
            using (SqlConnection con = Database.GetConnection())
            {
                string query = @"
SELECT
    D.DonationID,
    D.FoodType,
    D.Quantity,
    R.RestaurantName,
    R.Address,
    D.DonationDate,
    D.ExpiryTime

FROM FoodDonations D

INNER JOIN Restaurants R
    ON D.RestaurantID = R.RestaurantID

INNER JOIN Volunteers V
    ON V.VolunteerID = @VolunteerID

WHERE
    D.Status = 'Available'

AND
    D.ExpiryTime > GETDATE()

AND
    V.Status = 'Active'

AND
    R.Address LIKE '%' + V.Area + '%'

AND
(
    D.FoodType LIKE '%' + @Search + '%'
    OR R.RestaurantName LIKE '%' + @Search + '%'
    OR R.Address LIKE '%' + @Search + '%'
)

ORDER BY
    D.ExpiryTime ASC;
";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    cmd.Parameters.AddWithValue(
                        "@Search",
                        search ?? "");

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt =
                            new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }


        // =========================================================
        // 2. CREATE NEW REQUEST
        // =========================================================
        public bool CreateRequest(
            int volunteerID,
            int donationID)
        {
            using (SqlConnection con =
                Database.GetConnection())
            {
                string query = @"
DECLARE @LastStatus NVARCHAR(50);

SELECT TOP 1
    @LastStatus = Status
FROM Requests
WHERE
    VolunteerID = @VolunteerID
    AND DonationID = @DonationID
ORDER BY
    AssignedDate DESC,
    RequestID DESC;


IF @LastStatus IN ('Pending', 'Approved')
BEGIN
    SELECT 0;
    RETURN;
END;


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
    'Pending',
    GETDATE()
);


SELECT 1;
";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    cmd.Parameters.AddWithValue(
                        "@DonationID",
                        donationID);

                    con.Open();

                    int result =
                        Convert.ToInt32(
                            cmd.ExecuteScalar());

                    return result == 1;
                }
            }
        }


        // =========================================================
        // 3. VOLUNTEER DONATION STATISTICS
        // =========================================================
        public DataTable GetMyDonationStatistics(
            int volunteerID)
        {
            using (SqlConnection con =
                Database.GetConnection())
            {
                string query = @"
SELECT

    -- Total Available
    (
        SELECT COUNT(*)
        FROM FoodDonations D

        INNER JOIN Restaurants R
            ON D.RestaurantID = R.RestaurantID

        INNER JOIN Volunteers V
            ON V.VolunteerID = @VolunteerID

        WHERE
            D.Status = 'Available'
            AND D.ExpiryTime > GETDATE()
            AND V.Status = 'Active'
            AND R.Address LIKE '%' + V.Area + '%'

    ) AS TotalAvailable,


    -- Food Items
    (
        SELECT ISNULL(SUM(D.Quantity), 0)
        FROM FoodDonations D

        INNER JOIN Restaurants R
            ON D.RestaurantID = R.RestaurantID

        INNER JOIN Volunteers V
            ON V.VolunteerID = @VolunteerID

        WHERE
            D.Status = 'Available'
            AND D.ExpiryTime > GETDATE()
            AND V.Status = 'Active'
            AND R.Address LIKE '%' + V.Area + '%'

    ) AS FoodItems,


    -- My Requests
    (
        SELECT COUNT(*)
        FROM Requests Req

        WHERE
            Req.VolunteerID = @VolunteerID

    ) AS MyRequests,


    -- Approved Requests
    (
        SELECT COUNT(*)
        FROM Requests Req

        WHERE
            Req.VolunteerID = @VolunteerID
            AND Req.Status = 'Approved'

    ) AS ApprovedRequests;
";

                using (SqlCommand cmd =
                    new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@VolunteerID",
                        volunteerID);

                    using (SqlDataAdapter da =
                        new SqlDataAdapter(cmd))
                    {
                        DataTable dt =
                            new DataTable();

                        da.Fill(dt);

                        return dt;
                    }
                }
            }
        }
    }
}