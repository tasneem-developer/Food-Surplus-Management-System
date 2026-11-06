using FSMS.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FSMS
{
    public partial class LoginForm : Form
    {
        // تهيئة نموذج تسجيل الدخول وإخفاء كلمة المرور بشكل افتراضي.
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        // تكبير نافذة تسجيل الدخول عند فتح النموذج.
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        // التحقق من بيانات تسجيل الدخول وتحديد لوحة التحكم المناسبة حسب دور المستخدم.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // التأكد من أن اسم المستخدم وكلمة المرور غير فارغين.
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                lblError.Text = "Invalid username or password.";
                lblError.Visible = true;
            }

            using (SqlConnection con = Database.GetConnection())
            {
                // جلب بيانات المستخدم والدور ومعرّف المطعم أو المتطوع المرتبط بالحساب.
                string query = @"
SELECT 
    U.UserID,
    U.Role,
    R.RestaurantID,
    V.VolunteerID
FROM Users U

LEFT JOIN Restaurants R
    ON U.UserID = R.UserID

LEFT JOIN Volunteers V
    ON U.UserID = V.UserID

WHERE U.Username = @username
AND U.Password = @password";

                SqlCommand cmd = new SqlCommand(query, con);

                // تمرير بيانات تسجيل الدخول إلى الاستعلام باستخدام Parameters.
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                // فتح الاتصال بقاعدة البيانات.
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    // التأكد من وجود مستخدم مطابق لبيانات تسجيل الدخول.
                    if (reader.Read())
                    {
                        int userID = Convert.ToInt32(reader["UserID"]);
                        string role = reader["Role"].ToString();

                        lblError.Visible = false;

                        // فتح لوحة تحكم المدير.
                        if (role == "Admin")
                        {
                            DashBoard dashboard = new DashBoard();

                            dashboard.Show();

                            this.Hide();
                        }

                        // فتح لوحة تحكم المطعم مع تمرير RestaurantID.
                        else if (role == "Restaurant")
                        {
                            if (reader["RestaurantID"] != DBNull.Value)
                            {
                                int restaurantID =
                                    Convert.ToInt32(reader["RestaurantID"]);

                                RestaurantDashboard dashboard =
                                    new RestaurantDashboard(restaurantID);

                                dashboard.Show();

                                this.Hide();
                            }
                            else
                            {
                                // الحساب موجود، لكن غير مرتبط بأي مطعم.
                                lblError.Text =
                                    "This account is not linked to a restaurant.";

                                lblError.Visible = true;
                            }
                        }

                        // فتح لوحة تحكم المتطوع مع تمرير VolunteerID.
                        else if (role == "Volunteer")
                        {
                            if (reader["VolunteerID"] != DBNull.Value)
                            {
                                int volunteerID =
                                    Convert.ToInt32(reader["VolunteerID"]);

                                VolunteerDashboard dashboard =
                                    new VolunteerDashboard(volunteerID);

                                dashboard.Show();

                                this.Hide();
                            }
                            else
                            {
                                // الحساب موجود، لكن غير مرتبط بأي متطوع.
                                lblError.Text =
                                    "This account is not linked to a volunteer.";

                                lblError.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        // لا يوجد مستخدم مطابق لاسم المستخدم وكلمة المرور.
                        lblError.Text = "Invalid username or password.";
                        lblError.Visible = true;
                        return;
                    }
                }
            }
        }

        // تبديل حالة إظهار وإخفاء كلمة المرور حسب اختيار المستخدم.
        private void showPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
