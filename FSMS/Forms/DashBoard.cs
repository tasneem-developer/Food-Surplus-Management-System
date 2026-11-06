using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using FontAwesome.Sharp;
using FSMS.DAL;
using FSMS.DataAccess;
using FSMS.Helpers;
using FSMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace FSMS.Forms

{
    public partial class DashBoard : Form
    {
        private IconButton currentButton;
        private DashboardDAL dashboardDAL = new DashboardDAL();
        private int hoverRow = -1;
        private string hoverIcon = "";

        private int hoverRowVolunteer = -1;
        private string hoverIconVolunteer = "";

        private int hoverRowDonation = -1;
        private string hoverIconDonation = "";

        private int hoverRowRequest = -1;
        private string hoverIconRequest = "";

        private ReportDAL reportDAL = new ReportDAL();


        // Constructor: تهيئة مكونات لوحة التحكم وربط أزرار القائمة بالأحداث.
        // Returns: لا تُرجع قيمة.
        public DashBoard()
        {

            InitializeComponent();
            ShowPanel(pnlDashboardHome);
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");


            dgvRestaurants.AutoGenerateColumns = false;


            dgvVolunteers.AutoGenerateColumns = false;


            dgvDonations.AutoGenerateColumns = false;


            dgvRequests.AutoGenerateColumns = false;



            bntDashboard.Click += MenuButton_Click;
            btnRestaurants.Click += MenuButton_Click;
            bntVolunteers.Click += MenuButton_Click;
            bntDonations.Click += MenuButton_Click;
            bntRequests.Click += MenuButton_Click;
            bntReports.Click += MenuButton_Click;



        }
        ///////////////////////////////////dashbord/////////////////////////////////////////////


        // تحميل الإحصائيات الرئيسية الخاصة ببطاقات لوحة التحكم.
        // Returns: لا تُرجع قيمة (void).
        private void LoadDashboardCards()
        {

            lblRestaurantCount.Text =
                dashboardDAL.GetTotalRestaurants().ToString();


            lblDashboardVolunteers.Text =
                dashboardDAL.GetTotalVolunteers().ToString();


            lblDashboardDonations.Text =
                dashboardDAL.GetTotalDonations().ToString();


            lblCompletedRequest.Text =
                dashboardDAL.GetCompletedRequests().ToString();
        }

        // إظهار الـ Panel المحدد ووضعه في مقدمة واجهة لوحة التحكم.
        // Returns: لا تُرجع قيمة (void).
        private void ShowPanel(System.Windows.Forms.Panel panel)
        {

            panel.Visible = true;
            panel.BringToFront();
        }

        // تحميل جميع الرسوم البيانية الموجودة في الصفحة الرئيسية.
        // Returns: لا تُرجع قيمة (void).
        private void LoadDashboardCharts()
        {

            LoadDonationStatusChart();

            LoadMonthlyDonationChart();

            LoadRequestStatusChart();

        }

        // تحميل إحصائيات حالات التبرعات داخل الرسم البياني.
        // Returns: لا تُرجع قيمة (void).
        private void LoadDonationStatusChart()
        {
            DataTable dt =
                dashboardDAL.GetDonationStatus();

            Series series =
                chartDonationStatusDash.Series[0];

            series.Points.Clear();

            int totalDonations = dt.AsEnumerable()
                .Sum(row => Convert.ToInt32(row["Total"]));


            foreach (DataRow row in dt.Rows)
            {
                string status = row["Status"].ToString();

                int total = Convert.ToInt32(row["Total"]);

                int index = series.Points.AddXY(status, total);

                int percentage =
                    totalDonations > 0
                    ? (int)Math.Round((total * 100.0) / totalDonations)
                    : 0;

                DataPoint point =
                    series.Points[index];

                point.Label =
                    percentage + "%";


                switch (status)
                {
                    case "Available":
                        series.Points[index].Color =
                            Color.FromArgb(76, 175, 80);
                        break;

                    case "Completed":
                        series.Points[index].Color =
                            Color.FromArgb(33, 150, 243);
                        break;

                    case "Expired":
                        series.Points[index].Color =
                            Color.FromArgb(244, 67, 54);
                        break;

                    case "Cancelled":
                        series.Points[index].Color =
                            Color.Gray;
                        break;
                }
            }

            series.IsValueShownAsLabel = true;
        }

        // تحميل بيانات التبرعات الشهرية وعرضها في الرسم البياني.
        // Returns: لا تُرجع قيمة (void).
        private void LoadMonthlyDonationChart()
        {
            DataTable dt =
                dashboardDAL.GetMonthlyDonations();


            // نأخذ الـ Series الموجودة من الـ Designer
            Series series =
                chartMonthlyDonations.Series[0];


            // نمسح البيانات فقط
            series.Points.Clear();


            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(
                    row["MonthName"].ToString(),
                    Convert.ToInt32(row["Total"])
                );
            }
        }

        // تحميل حالات الطلبات وحساب نسبة كل حالة داخل الرسم البياني.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRequestStatusChart()
        {
            DataTable dt =
                dashboardDAL.GetRequestStatus();

            Series series =
                chartRequestStatus.Series[0];

            series.Points.Clear();

            // حساب مجموع جميع الطلبات
            int grandTotal = 0;

            foreach (DataRow row in dt.Rows)
            {
                grandTotal +=
                    Convert.ToInt32(row["Total"]);
            }

            // إضافة الحالات وحساب النسبة
            foreach (DataRow row in dt.Rows)
            {
                string status =
                    row["Status"].ToString();

                int total =
                    Convert.ToInt32(row["Total"]);

                int index =
                    series.Points.AddXY(status, total);

                DataPoint point =
                    series.Points[index];

                // النسبة من إجمالي الطلبات
                double percentage =
                    grandTotal > 0
                    ? (total * 100.0) / grandTotal
                    : 0;

                point.Label =
                    percentage.ToString("0") + "%";

                point.LegendText =
                    status;

                switch (status)
                {
                    case "Pending":
                        point.Color =
                            Color.FromArgb(255, 193, 7);
                        break;

                    case "Approved":
                        point.Color =
                            Color.FromArgb(76, 175, 80);
                        break;

                    case "Completed":
                        point.Color =
                            Color.FromArgb(33, 150, 243);
                        break;

                    case "Rejected":
                        point.Color =
                            Color.Gray;
                        break;

                    case "Cancelled":
                        point.Color =
                            Color.MediumPurple;
                        break;
                }
            }
        }

        // تحميل أحدث التبرعات في جدول التبرعات الأخيرة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRecentDonations()
        {
            dgvRecentDonations.AutoGenerateColumns = false;

            dgvRecentDonations.DataSource =
                dashboardDAL.GetRecentDonations();
        }

        // تحميل أحدث الطلبات في جدول الطلبات الأخيرة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRecentRequests()
        {
            dgvRecentRequests.AutoGenerateColumns = false;

            dgvRecentRequests.DataSource =
                dashboardDAL.GetRecentRequests();
        }


        // تحميل التنبيهات من قاعدة البيانات وعرضها داخل لوحة التنبيهات.
        // Returns: لا تُرجع قيمة (void).
        private void LoadNotifications()
        {
            flpNotifications.Controls.Clear();

            DataTable dt =
                dashboardDAL.GetNotifications();

            foreach (DataRow row in dt.Rows)
            {
                AddNotification(

                    row["Title"].ToString(),

                    row["Message"].ToString(),

                    Convert.ToDateTime(
                        row["NotificationDate"]),

                    row["Type"].ToString()
                );
            }
        }

        // إنشاء عنصر Notification وعرض عنوانه ورسالة التنبيه وتاريخه حسب نوعه.
        // Returns: لا تُرجع قيمة (void).
        private void AddNotification(
    string title,
    string message,
    DateTime date,
    string type)
        {
            Panel pnl = new Panel();

            pnl.Width = 300;

            pnl.Height = 70;

            pnl.Margin = new Padding(0, 0, 0, 10);

            pnl.BackColor = Color.WhiteSmoke;



            Panel line = new Panel();

            line.Width = 6;

            line.Height = 70;

            line.Dock = DockStyle.Left;



            switch (type)
            {
                case "Expired":
                    line.BackColor =
                        Color.FromArgb(244, 67, 54);
                    break;

                case "Tomorrow":
                    line.BackColor =
                        Color.FromArgb(255, 152, 0);
                    break;

                case "Assignment":
                    line.BackColor =
                        Color.FromArgb(33, 150, 243);
                    break;

                case "Restaurant":
                    line.BackColor =
                        Color.FromArgb(0, 150, 136);
                    break;

                case "Volunteer":
                    line.BackColor =
                        Color.FromArgb(156, 39, 176);
                    break;
            }



            Label lblTitle = new Label();

            lblTitle.Text = title;

            lblTitle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            lblTitle.Location =
                new Point(15, 8);

            lblTitle.AutoSize = true;



            Label lblMessage = new Label();

            lblMessage.Text = message;

            lblMessage.Font =
                new Font("Segoe UI", 9);

            lblMessage.ForeColor = Color.Gray;

            lblMessage.Location =
                new Point(15, 30);

            lblMessage.AutoSize = true;



            Label lblDate = new Label();

            lblDate.Text =
                date.ToString("dd MMM yyyy  hh:mm tt");

            lblDate.Font =
                new Font("Segoe UI", 8);

            lblDate.ForeColor =
                Color.DarkGray;

            lblDate.Location =
                new Point(15, 50);

            lblDate.AutoSize = true;



            pnl.Controls.Add(line);

            pnl.Controls.Add(lblTitle);

            pnl.Controls.Add(lblMessage);

            pnl.Controls.Add(lblDate);

            flpNotifications.Controls.Add(pnl);
        }

        // تغيير لون زر Dashboard عند دخول مؤشر الماوس.
        // Returns: لا تُرجع قيمة (void).
        private void bntDashboard_MouseEnter(object sender, EventArgs e)
        {
            bntDashboard.BackColor = Color.FromArgb(0, 150, 136);
        }

        // إعادة لون زر Dashboard إلى اللون الافتراضي عند خروج مؤشر الماوس.
        // Returns: لا تُرجع قيمة (void).
        private void bntDashboard_MouseLeave(object sender, EventArgs e)
        {
            bntDashboard.BackColor = Color.Transparent;

        }

        // عرض الصفحة الرئيسية وتحميل البطاقات والرسوم والبيانات الأخيرة والتنبيهات.
        // Returns: لا تُرجع قيمة (void).
        private void bntDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ShowPanel(pnlDashboardHome);


            LoadDashboardCards();
            LoadDashboardCharts();
            LoadRecentDonations();
            LoadRecentRequests();
            LoadNotifications();
        }

        ///////////////////////////////////restaurant/////////////////////////////////////////////

        // تحميل قائمة المطاعم مع إمكانية البحث والتصفية حسب الحالة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRestaurants(string search = "", string status = "All")
        {
            RestaurantDAL dal = new RestaurantDAL();

            DataTable dt = dal.GetRestaurants(search, status);

            dgvRestaurants.DataSource = dt;

            lblResultsFound.Text = $"{dt.Rows.Count} Restaurants Found";


            lblNoData.Visible = dt.Rows.Count == 0;


            foreach (DataGridViewColumn col in dgvRestaurants.Columns)
            {
                col.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
            }

            dgvRestaurants.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }


        // رسم أيقونات التعديل والحذف داخل عمود Action الخاص بالمطاعم.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRestaurants_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (dgvRestaurants.Columns[e.ColumnIndex].Name == "Action")
            {
                DataGridViewHelper.DrawActionIcons(
                    e,
                    hoverRow,
                    hoverIcon
                );
            }
        }


        // تحديد الأيقونة التي يتم تمرير مؤشر الماوس عليها في جدول المطاعم.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRestaurants_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRestaurants.Columns[e.ColumnIndex].Name != "Action")
                return;

            int x = dgvRestaurants.PointToClient(System.Windows.Forms.Cursor.Position).X;
            Rectangle cell = dgvRestaurants.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (x < cell.Left + 45)
                hoverIcon = "Edit";
            else
                hoverIcon = "Delete";

            hoverRow = e.RowIndex;

            dgvRestaurants.Cursor = Cursors.Hand;
            dgvRestaurants.InvalidateCell(e.ColumnIndex, e.RowIndex);
        }


        // معالجة الضغط على أيقونات التعديل أو الحذف الخاصة بالمطاعم.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRestaurants_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= dgvRestaurants.Rows.Count)
                return;

            if (dgvRestaurants.Columns[e.ColumnIndex].Name != "Action")
                return;

            DataGridViewRow row = dgvRestaurants.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            if (row.Cells["RestaurantID"].Value == null)
                return;

            int restaurantID = Convert.ToInt32(row.Cells["RestaurantID"].Value);

            int x = dgvRestaurants.PointToClient(System.Windows.Forms.Cursor.Position).X;
            Rectangle cell = dgvRestaurants.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (x < cell.Left + 45)
            {
                EditRestaurant(restaurantID);
            }
            else
            {
                DeleteRestaurant(restaurantID);
            }
        }

        // فتح نموذج تعديل المطعم ثم إعادة تحميل البيانات عند نجاح التعديل.
        // Returns: لا تُرجع قيمة (void).
        private void EditRestaurant(int id)
        {
            EditRestaurantForm frm = new EditRestaurantForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadRestaurants(txtSearchRestaurant.Text.Trim(), cmbStatus.Text);
                LoadRestaurantCards();

            }
        }


        // حذف مطعم بعد تأكيد المستخدم ثم تحديث الجدول والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void DeleteRestaurant(int id)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this restaurant?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );


            if (result == DialogResult.Yes)
            {
                RestaurantDAL dal = new RestaurantDAL();

                dal.DeleteRestaurant(id);


                LoadRestaurants(
                    txtSearchRestaurant.Text.Trim(),
                    cmbStatus.Text
                );

                LoadRestaurantCards();
            }
        }

        // فتح قسم إدارة المطاعم وتحميل بيانات المطاعم والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void btnRestaurants_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ShowPanel(pnlRestaurants);



            LoadRestaurants(txtSearchRestaurant.Text.Trim(), cmbStatus.Text);
            LoadRestaurantCards();
        }





        // إعادة تحميل المطاعم عند تغيير حالة التصفية.
        // Returns: لا تُرجع قيمة (void).
        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRestaurants(txtSearchRestaurant.Text.Trim(), cmbStatus.Text);
        }


        // فتح نموذج إضافة مطعم جديد ثم تحديث القائمة بعد نجاح الإضافة.
        // Returns: لا تُرجع قيمة (void).
        private void btnAddRestaurant_Click(object sender, EventArgs e)
        {
            AddRestaurantForm frm = new AddRestaurantForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadRestaurants(txtSearchRestaurant.Text.Trim(), cmbStatus.Text);
                LoadRestaurantCards();
            }


        }



        // إعادة تحميل المطاعم تلقائياً عند تغيير نص البحث.
        // Returns: لا تُرجع قيمة (void).
        private void txtSearchRestaurant_TextChanged(object sender, EventArgs e)
        {

            LoadRestaurants(txtSearchRestaurant.Text.Trim(), cmbStatus.Text);
        }

        // تحميل إحصائيات المطاعم وعرضها في البطاقات الخاصة بالقسم.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRestaurantCards()
        {
            RestaurantDAL dal = new RestaurantDAL();


            int total = dal.GetTotalRestaurants();

            lblTotalRestaurants.Text = total.ToString();

            lblTotalRestaurantsInf.Text =
                $"Updated {DateTime.Now:dd MMM}";


            int active = dal.GetActiveRestaurants();

            lblActiveRestaurants.Text =
                active.ToString();


            int activeWeek = dal.GetActiveRestaurantsThisWeek();

            lblActiveRestaurantInfo.Text =
                $"+{activeWeek} this week";


            int inactive = dal.GetInactiveRestaurants();

            lblInactiveRestaurants.Text =
                inactive.ToString();


            lblInactiveRestaurantsInfo.Text =
                inactive == 0
                ? "No inactive restaurants"
                : $"{inactive} inactive";


            int newRestaurants = dal.GetNewRestaurants();

            lblNewRestaurant.Text =
                newRestaurants.ToString();


            lblNewRextaurantInfo.Text =
                newRestaurants == 0
                ? "No new restaurants"
                : $"{newRestaurants} added this week";
        }



        // إعادة تعيين البحث والتصفية ثم إعادة تحميل بيانات المطاعم.
        // Returns: لا تُرجع قيمة (void).
        private void btnRefresh_Click(object sender, EventArgs e)
        {

            txtSearchRestaurant.Clear();

            cmbStatus.SelectedIndex = 0;

            LoadRestaurants();

            LoadRestaurantCards();

        }


        ///////////////////////////////////volunter/////////////////////////////////////////////


        // تحميل قائمة المتطوعين مع إمكانية البحث والتصفية حسب الحالة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadVolunteers(string search = "", string status = "All")
        {
            VolunteerDAL dal = new VolunteerDAL();

            DataTable dt = dal.GetVolunteers(search, status);

            dgvVolunteers.DataSource = dt;

            lblVolunteerResults.Text =
                $"Showing {dt.Rows.Count} Volunteers";
            lblNoFoundV.Visible = dt.Rows.Count == 0;

        }

        // رسم أيقونات الإجراءات داخل جدول المتطوعين.
        // Returns: لا تُرجع قيمة (void).
        private void dgvVolunteers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (dgvVolunteers.Columns[e.ColumnIndex].Name == "colVolunteerAction")
            {
                DataGridViewHelper.DrawActionIcons(
                   e,
                 hoverRowVolunteer,
                 hoverIconVolunteer);
            }
        }




        // تحديد الأيقونة التي يتم تمرير مؤشر الماوس عليها في جدول المتطوعين.
        // Returns: لا تُرجع قيمة (void).
        private void dgvVolunteers_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvVolunteers.Columns[e.ColumnIndex].Name != "colVolunteerAction")
                return;

            int x = dgvVolunteers.PointToClient(System.Windows.Forms.Cursor.Position).X;
            Rectangle cell = dgvVolunteers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (x < cell.Left + 45)
                hoverIconVolunteer = "Edit";
            else
                hoverIconVolunteer = "Delete";

            hoverRow = e.RowIndex;

            dgvVolunteers.Cursor = Cursors.Hand;
            dgvVolunteers.InvalidateCell(e.ColumnIndex, e.RowIndex);
        }




        // معالجة الضغط على أيقونات التعديل أو الحذف الخاصة بالمتطوعين.
        // Returns: لا تُرجع قيمة (void).
        private void dgvVolunteers_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= dgvVolunteers.Rows.Count)
                return;

            if (dgvVolunteers.Columns[e.ColumnIndex].Name != "colVolunteerAction")
                return;

            DataGridViewRow row = dgvVolunteers.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            if (row.Cells["VolunteerID"].Value == null)
                return;

            int volunteerID =
     Convert.ToInt32(
         row.Cells["VolunteerID"].Value);

            int x = dgvVolunteers.PointToClient(System.Windows.Forms.Cursor.Position).X;
            Rectangle cell = dgvVolunteers.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (x < cell.Left + 45)
            {
                EditVolunteer(volunteerID);
            }
            else
            {
                DeleteVolunteer(volunteerID);
            }
        }



        // فتح نموذج تعديل المتطوع ثم إعادة تحميل بيانات المتطوعين.
        // Returns: لا تُرجع قيمة (void).
        private void EditVolunteer(int id)
        {
            EditVolunteerForm frm =
                new EditVolunteerForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadVolunteers(
                    txtSearchVolunteer.Text.Trim(),
                    cmbVolunteerStatus.Text);

                LoadVolunteerCards();
            }
        }

        // فتح قسم المتطوعين وتحميل بيانات المتطوعين والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void bntVolunteers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ShowPanel(pnlVolunteers);



            LoadVolunteers(
                   txtSearchVolunteer.Text.Trim(),
                   cmbVolunteerStatus.Text);

            LoadVolunteerCards();
        }

        // إعادة تحميل المتطوعين عند تغيير نص البحث.
        // Returns: لا تُرجع قيمة (void).
        private void txtSearchVolunteer_TextChanged(object sender, EventArgs e)
        {
            LoadVolunteers(
      txtSearchVolunteer.Text.Trim(),
      cmbVolunteerStatus.Text
  );
        }

        // إعادة تحميل المتطوعين عند تغيير حالة التصفية.
        // Returns: لا تُرجع قيمة (void).
        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadVolunteers(
      txtSearchVolunteer.Text.Trim(),
      cmbVolunteerStatus.Text
  );
        }

        // تحميل إحصائيات المتطوعين وعرضها في البطاقات الخاصة بالقسم.
        // Returns: لا تُرجع قيمة (void).
        private void LoadVolunteerCards()
        {
            VolunteerDAL dal = new VolunteerDAL();

            int total = dal.GetTotalVolunteers();

            lblTotalVolunteers.Text = total.ToString();
            lblTotalVolunteersInfo.Text = $"Updated {DateTime.Now:dd MMM}";


            int active = dal.GetActiveVolunteers();

            lblActiveVolunteers.Text = active.ToString();

            int activeWeek = dal.GetActiveVolunteersThisWeek();

            lblActiveVolunteersInfo.Text = $"+{activeWeek} this week";


            int inactive = dal.GetInactiveVolunteers();

            lblInactiveVolunteers.Text = inactive.ToString();

            lblInactiveVolunteersInfo.Text =
                inactive == 0
                ? "No inactive volunteers"
                : $"{inactive} inactive";


            int newVolunteers = dal.GetNewVolunteers();

            lblNewVolunteers.Text = newVolunteers.ToString();

            lblNewVolunteersInfo.Text =
                newVolunteers == 0
                ? "No new volunteers"
                : $"{newVolunteers} added this week";
        }

        // فتح نموذج إضافة متطوع جديد ثم تحديث البيانات بعد نجاح الإضافة.
        // Returns: لا تُرجع قيمة (void).
        private void btnAddVolunteer_Click(object sender, EventArgs e)
        {
            AddVolunteerForm frm = new AddVolunteerForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadVolunteers(
                    txtSearchVolunteer.Text.Trim(),
                    cmbVolunteerStatus.Text);

                LoadVolunteerCards();
            }
        }

        // حذف متطوع بعد تأكيد العملية ثم تحديث القائمة والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void DeleteVolunteer(int id)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this volunteer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                VolunteerDAL dal = new VolunteerDAL();

                dal.DeleteVolunteer(id);

                LoadVolunteers(
                    txtSearchVolunteer.Text.Trim(),
                    cmbVolunteerStatus.Text);

                LoadVolunteerCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // إعادة تعيين البحث والتصفية وإعادة تحميل بيانات المتطوعين.
        // Returns: لا تُرجع قيمة (void).
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            txtSearchVolunteer.Clear();

            cmbVolunteerStatus.SelectedIndex = 0;

            LoadVolunteers();

            LoadVolunteerCards();
        }

        ///////////////////////////////////Donations/////////////////////////////////////////////

        // تحديث التبرعات المنتهية ثم تحميل التبرعات حسب البحث والحالة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadDonations(string search = "", string status = "All")
        {
            DonationDAL donationDAL = new DonationDAL();
            donationDAL.UpdateExpiredDonations();

            DataTable dt = donationDAL.GetDonations(search, status);

            dgvDonations.DataSource = dt;

            lblDonationFound.Text = $"{dt.Rows.Count} Donations Found";

            lblNoDonation.Visible = dt.Rows.Count == 0;

            LoadDonationChart();
        }




        // رسم Badge لحالة التبرع ورسم أيقونات الإجراءات داخل جدول التبرعات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvDonations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            // Status Badge
            if (dgvDonations.Columns[e.ColumnIndex].Name == "Status")
            {
                DrawStatusBadge(e);
            }


            // Action Icons
            if (dgvDonations.Columns[e.ColumnIndex].Name == "ActionDonation")
            {
                DataGridViewHelper.DrawActionIcons(
                    e,
                    hoverRowDonation,
                    hoverIconDonation
                );
            }
        }


        // رسم مستطيل ملون يعرض حالة التبرع داخل خلية الجدول.
        // Returns: لا تُرجع قيمة (void).
        private void DrawStatusBadge(DataGridViewCellPaintingEventArgs e)
        {
            e.PaintBackground(e.CellBounds, true);

            string status =
                dgvDonations.Rows[e.RowIndex]
                .Cells["Status"].Value.ToString();


            Color color = Color.Gray;


            switch (status)
            {
                case "Available":
                    color = Color.FromArgb(95,76, 175, 80);
                    break;

                case "Completed":
                    color = Color.FromArgb(95,63, 81, 181);
                    break;

                case "Expired":
                    color = Color.FromArgb(95,244, 67, 54);
                    break;

                case "Cancelled":
                    color = Color.Gray;
                    break;
            }


            Rectangle rect = new Rectangle(
                e.CellBounds.Left + 12,
                e.CellBounds.Top + 10,
                e.CellBounds.Width - 24,
                25
            );


            using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
            using (Brush brush = new SolidBrush(color))
            {
                e.Graphics.FillRectangle(
                    brush,
                    rect
                );

                TextRenderer.DrawText(
                    e.Graphics,
                    status,
                    font,
                    rect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter
                );
            }


            e.Handled = true;
        }

        // تحديد أيقونة التعديل أو الحذف عند تحريك الماوس داخل جدول التبرعات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvDonations_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (dgvDonations.Columns[e.ColumnIndex].Name != "ActionDonation")
                return;


            int x = dgvDonations.PointToClient(System.Windows.Forms.Cursor.Position).X;


            Rectangle cell =
                dgvDonations.GetCellDisplayRectangle(
                    e.ColumnIndex,
                    e.RowIndex,
                    false
                );


            if (x < cell.Left + 45)
                hoverIconDonation = "Edit";
            else
                hoverIconDonation = "Delete";


            hoverRowDonation = e.RowIndex;


            dgvDonations.Cursor = Cursors.Hand;


            dgvDonations.InvalidateCell(
                e.ColumnIndex,
                e.RowIndex
            );
        }

        // معالجة الضغط على أيقونات التعديل أو الحذف الخاصة بالتبرعات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvDonations_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= dgvDonations.Rows.Count)
                return;

            if (dgvDonations.Columns[e.ColumnIndex].Name != "ActionDonation")
                return;

            DataGridViewRow row = dgvDonations.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            if (row.Cells["DonationID"].Value == null)
                return;

            int donationID =
     Convert.ToInt32(
         row.Cells["DonationID"].Value);

            int x = dgvDonations.PointToClient(System.Windows.Forms.Cursor.Position).X;
            Rectangle cell = dgvDonations.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (x < cell.Left + 45)
            {
                EditDonation(donationID);
            }
            else
            {
                DeleteDonation(donationID);
            }
        }


        // فتح نموذج تعديل التبرع ثم تحديث الجدول والبطاقات والرسم البياني.
        // Returns: لا تُرجع قيمة (void).
        private void EditDonation(int id)
        {
            DonationForm frm = new DonationForm(id);

            frm.FormTitle = "Edit Donation";
            frm.FormSubTitle = "Update donation information";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDonations(
          txtSearchDonation.Text,
          cmbDonationStatus.Text
      ); LoadDonationCards();
                LoadDonationChart();
            }
        }

        // حذف التبرع بعد تأكيد المستخدم ثم تحديث بيانات التبرعات.
        // Returns: لا تُرجع قيمة (void).
        private void DeleteDonation(int id)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this donation?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );


            if (result == DialogResult.Yes)
            {
                DonationDAL.DeleteDonation(id);
                LoadDonations(
          txtSearchDonation.Text,
          cmbDonationStatus.Text
      ); LoadDonationCards();

            }
        }

        // فتح قسم إدارة التبرعات وتحميل البيانات والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void bntDonations_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ShowPanel(pnlDonations);


            LoadDonations(
      txtSearchDonation.Text,
      cmbDonationStatus.Text
  ); LoadDonationCards();

        }

        // فتح نموذج إضافة تبرع جديد ثم تحديث البيانات بعد نجاح الإضافة.
        // Returns: لا تُرجع قيمة (void).
        private void btnAddDonation_Click(object sender, EventArgs e)
        {
            DonationForm frm = new DonationForm();

            frm.FormTitle = "Add Donation";
            frm.FormSubTitle = "Create a new food donation";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadDonations(
          txtSearchDonation.Text,
          cmbDonationStatus.Text
      ); LoadDonationCards();
                LoadDonationChart();
            }
        }

        // تحميل إحصائيات حالات التبرعات في الرسم البياني الخاص بقسم التبرعات.
        // Returns: لا تُرجع قيمة (void).
        private void LoadDonationChart()
        {
            DataTable dt = DonationDAL.GetDonationStatusCount();


            // نأخذ الـ Series الموجودة من الـ Designer
            Series series =
                chartDonationStatus.Series[0];


            // نمسح البيانات فقط
            series.Points.Clear();


            // حساب إجمالي التبرعات
            int totalDonations = dt.AsEnumerable()
                .Sum(row => Convert.ToInt32(row["Total"]));


            foreach (DataRow row in dt.Rows)
            {
                string status = row["Status"].ToString();

                int total = Convert.ToInt32(row["Total"]);


                int index =
                    series.Points.AddXY(status, total);


                // حساب النسبة المئوية كرقم صحيح
                int percentage = totalDonations == 0
                    ? 0
                    : (int)Math.Round((double)total / totalDonations * 100);


                // إظهار النسبة داخل الدائرة
                series.Points[index].Label =
                    percentage + "%";


                switch (status)
                {
                    case "Available":
                        series.Points[index].Color =
                            Color.FromArgb(76, 175, 80);
                        break;


                    case "Completed":
                        series.Points[index].Color =
                            Color.FromArgb(63, 81, 181);
                        break;


                    case "Expired":
                        series.Points[index].Color =
                            Color.FromArgb(244, 67, 54);
                        break;


                    case "Cancelled":
                        series.Points[index].Color =
                            Color.Gray;
                        break;
                }
            }

            // إظهار الـ Label داخل الدائرة
            series.IsValueShownAsLabel = true;
        }


        // تحميل الأعداد الإجمالية للتبرعات والتبرعات المتاحة والمكتملة والمنتهية.
        // Returns: لا تُرجع قيمة (void).
        private void LoadDonationCards()
        {
            lblTotalDonations.Text =
                DonationDAL.GetTotalDonations().ToString();


            lblAvailableDonations.Text =
                DonationDAL.GetAvailableDonations().ToString();


            lblCompletedDonations.Text =
                DonationDAL.GetCompletedDonations().ToString();


            lblExpiredDonations.Text =
                DonationDAL.GetExpiredDonations().ToString();
        }

        // إعادة تحميل التبرعات عند تغيير نص البحث.
        // Returns: لا تُرجع قيمة (void).
        private void txtSearchDonation_TextChanged(object sender, EventArgs e)
        {
            LoadDonations(
       txtSearchDonation.Text,
       cmbDonationStatus.Text
   );
        }

        // إعادة تحميل التبرعات عند تغيير حالة التصفية.
        // Returns: لا تُرجع قيمة (void).
        private void cmbDonationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDonations(
      txtSearchDonation.Text,
      cmbDonationStatus.Text
  );
        }

        // إعادة تعيين البحث والتصفية وإعادة تحميل التبرعات والرسم البياني.
        // Returns: لا تُرجع قيمة (void).
        private void btnRefreshDonation_Click(object sender, EventArgs e)
        {
            txtSearchDonation.Clear();
            cmbDonationStatus.SelectedIndex = 0;
            LoadDonations();
            LoadDonationChart();

        }


        ///////////////////////////////////Requests/////////////////////////////////////////////

        // تحميل طلبات التبرعات حسب البحث والحالة وعرض تفاصيل أول طلب عند توفره.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRequests(string search = "", string status = "All")
        {
            RequestDAL requestDAL = new RequestDAL();

            dgvRequests.AutoGenerateColumns = false;

            dgvRequests.DataSource =
                requestDAL.GetRequests(search, status);

            lblTotalRecords.Text =
                $"Showing {dgvRequests.Rows.Count} Records";
            lblNoReqest.Visible = dgvRequests.Rows.Count == 0;

            if (dgvRequests.Rows.Count > 0)
            {
                int id = Convert.ToInt32(
                    dgvRequests.Rows[0]
                    .Cells["RequestID"].Value);

                LoadRequestDetails(id);
            }
        }


        // تحميل إحصائيات الطلبات وعرض إجمالي الطلبات حسب الحالات المختلفة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRequestStatistics()
        {
            RequestDAL requestDAL = new RequestDAL();

            DataTable dt =
                requestDAL.GetRequestStatistics();

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            lblTotalAssignments.Text =
                row["TotalAssignments"].ToString();

            lblPendingRequests.Text =
                row["Pending"].ToString();

            lblApprovedRequests.Text =
                row["Approved"].ToString();

            lblCompletedRequests.Text =
                row["Completed"].ToString();
        }

        // فتح قسم إدارة الطلبات وتحميل قائمة الطلبات وإحصائياتها.
        // Returns: لا تُرجع قيمة (void).
        private void bntRequests_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            LoadRequests();

            LoadRequestStatistics();

            ShowPanel(pnlRequests);



        }

        // إعادة تحميل الطلبات عند تغيير نص البحث.
        // Returns: لا تُرجع قيمة (void).
        private void txtSearchRequest_TextChanged(object sender, EventArgs e)
        {
            LoadRequests(
      txtSearchRequest.Text,
      cmbStatusRequest.Text
  );
        }

        // إعادة تحميل الطلبات عند تغيير حالة التصفية.
        // Returns: لا تُرجع قيمة (void).
        private void cmbStatusRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequests(
txtSearchRequest.Text,
cmbStatusRequest.Text
);
        }

        // رسم أيقونات الإجراءات داخل جدول الطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRequests_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (dgvRequests.Columns[e.ColumnIndex].Name == "ActionRequest")
            {
                DataGridViewHelper.DrawActionIcons(
                    e,
                    hoverRowRequest,
                    hoverIconRequest
                );
            }
        }

        // تحديد أيقونة التعديل أو الحذف عند تحريك الماوس داخل جدول الطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRequests_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvRequests.Columns[e.ColumnIndex].Name != "ActionRequest")
                return;

            int x = dgvRequests.PointToClient(System.Windows.Forms.Cursor.Position).X;

            Rectangle cell =
                dgvRequests.GetCellDisplayRectangle(
                    e.ColumnIndex,
                    e.RowIndex,
                    false);

            if (x < cell.Left + 45)
                hoverIconRequest = "Edit";
            else
                hoverIconRequest = "Delete";

            hoverRowRequest = e.RowIndex;

            dgvRequests.Cursor = Cursors.Hand;

            dgvRequests.InvalidateCell(
                e.ColumnIndex,
                e.RowIndex);
        }

        // إلغاء حالة Hover عند مغادرة صف الإجراءات في جدول الطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRequests_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            hoverRowRequest = -1;
            hoverIconRequest = "";

            dgvRequests.Cursor = Cursors.Default;

            dgvRequests.Invalidate();
        }

        // معالجة الضغط على أيقونات التعديل أو الحذف الخاصة بالطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= dgvRequests.Rows.Count)
                return;

            if (dgvRequests.Columns[e.ColumnIndex].Name != "ActionRequest")
                return;

            DataGridViewRow row = dgvRequests.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            if (row.Cells["RequestID"].Value == null)
                return;

            int requestID =
     Convert.ToInt32(
         row.Cells["RequestID"].Value);

            int x = dgvRequests.PointToClient(System.Windows.Forms.Cursor.Position).X;
            Rectangle cell = dgvRequests.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (x < cell.Left + 45)
            {
                EditRequest(requestID);
            }
            else
            {
                DeleteRequest(requestID);
            }
        }

        // فتح نموذج تعديل الطلب ثم تحديث قائمة الطلبات والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void EditRequest(int id)
        {
            RequestForm frm = new RequestForm(id);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadRequests(
                    txtSearchRequest.Text,
                    cmbStatusRequest.Text);

                LoadRequestStatistics();
            }

        }

        // حذف الطلب بعد تأكيد المستخدم ثم تحديث البيانات والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void DeleteRequest(int id)
        {
            RequestDAL requestDAL = new RequestDAL();

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this request?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                requestDAL.DeleteRequest(id);

                LoadRequests(
                    txtSearchRequest.Text,
                    cmbStatusRequest.Text);

                LoadRequestStatistics();
            }
        }

        // فتح نموذج إضافة طلب جديد ثم تحديث القائمة والإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void btnAddRequst_Click(object sender, EventArgs e)
        {
            RequestForm frm = new RequestForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadRequests(
                    txtSearchRequest.Text,
                    cmbStatusRequest.Text);

                LoadRequestStatistics();
            }
        }

        // تحميل تفاصيل الطلب المحدد وعرض بيانات المتطوع والمطعم وحالة الطلب.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRequestDetails(int requestID)
        {
            RequestDAL requestDAL = new RequestDAL();

            DataTable dt =
                requestDAL.GetRequestDetails(requestID);

            if (dt.Rows.Count == 0)
            {
                btnApprove.Visible = false;
                return;
            }

            DataRow row = dt.Rows[0];

            lblVolunteerName.Text =
                row["VolunteerName"].ToString();

            lblRestaurant.Text =
                row["RestaurantName"].ToString();

            lblFoodType.Text =
                row["FoodType"].ToString();

            lblQuantity.Text =
                row["Quantity"].ToString();

            lblStatus.Text =
                row["Status"].ToString();

            lblAssignedDate.Text =
                Convert.ToDateTime(
                    row["AssignedDate"])
                .ToString("dd/MM/yyyy");

            // =====================================
            // APPROVE BUTTON
            // =====================================

            string status =
                row["Status"].ToString();

            if (status == "Pending")
            {
                btnApprove.Visible = true;
            }
            else
            {
                btnApprove.Visible = false;
            }
        }

        // تحديث تفاصيل الطلب عند تغيير الصف المحدد في جدول الطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null)
            {
                btnApprove.Visible = false;
                return;
            }

            if (dgvRequests.CurrentRow.Cells["RequestID"].Value == null)
            {
                btnApprove.Visible = false;
                return;
            }

            int requestID =
                Convert.ToInt32(
                    dgvRequests.CurrentRow
                    .Cells["RequestID"]
                    .Value);

            LoadRequestDetails(requestID);
        }

        // تنفيذ عملية الموافقة على الطلب بعد تأكيد المستخدم وتحديث البيانات.
        // Returns: لا تُرجع قيمة (void).
        private void ApproveRequest(int requestID)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to approve this request?\n\n" +
                "All other pending requests for the same donation will be rejected.",
                "Approve Request",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            RequestDAL requestDAL = new RequestDAL();

            bool success =
                requestDAL.ApproveRequest(requestID);

            if (success)
            {
                MessageBox.Show(
                    "Request approved successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadRequests(
                    txtSearchRequest.Text,
                    cmbStatusRequest.Text);

                LoadRequestStatistics();

                btnApprove.Visible = false;
            }
            else
            {
                MessageBox.Show(
                    "This request is no longer pending.",
                    "Approve Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                btnApprove.Visible = false;
            }
        }

        // الحصول على رقم الطلب المحدد ثم استدعاء عملية الموافقة عليه.
        // Returns: لا تُرجع قيمة (void).
        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null)
                return;

            if (dgvRequests.CurrentRow.Cells["RequestID"].Value == null)
                return;

            int requestID =
                Convert.ToInt32(
                    dgvRequests.CurrentRow
                    .Cells["RequestID"]
                    .Value);

            ApproveRequest(requestID);
        }















       

        ///////////////////////////////////Report/////////////////////////////////////////////

        // إنشاء التقرير المطلوب حسب نوع التقرير والفترة الزمنية المحددة.
        // Returns: لا تُرجع قيمة (void).
        private void btnGenerate_Click(object sender, EventArgs e)
        {

            switch (cmbReportType.Text)
            {
                case "Summary":

                    dgvReports.DataSource =
                        reportDAL.GetSummaryReport(
                            dtFrom.Value,
                            dtTo.Value
                        );
                    lblNoReportFound.Visible = dgvReports.Rows.Count == 0;
                    lblNoReport.Visible = false;

                    break;

                case "Donations":
                    dgvReports.DataSource =
                        reportDAL.GetDonationReport(
                            dtFrom.Value,
                            dtTo.Value);
                    lblNoReportFound.Visible = dgvReports.Rows.Count == 0;
                    lblNoReport.Visible = false;

                    break;

                case "Volunteers ":
                    dgvReports.DataSource =
                        reportDAL.GetVolunteerReport(
                             dtFrom.Value,
                            dtTo.Value);
                    lblNoReportFound.Visible = dgvReports.Rows.Count == 0;

                    lblNoReport.Visible = false;

                    break;
                case "Requests":
                    dgvReports.DataSource =
                        reportDAL.GetRequestReport(
                            dtFrom.Value,
                            dtTo.Value);
                    lblNoReportFound.Visible = dgvReports.Rows.Count == 0;
                    lblNoReport.Visible = false;

                    break;

                case "Restaurants":
                    dgvReports.DataSource =
                        reportDAL.GetRestaurantReport(
                             dtFrom.Value,
                            dtTo.Value);
                    lblNoReportFound.Visible = dgvReports.Rows.Count == 0;
                    lblNoReport.Visible = false;

                    break;
            }

            TotalReport.Text = $"Showing {dgvReports.Rows.Count} Record";

        }

        // فتح قسم التقارير وإظهار لوحة التقارير.
        // Returns: لا تُرجع قيمة (void).
        private void bntReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ShowPanel(pnlReports);

        }

        // تصدير البيانات الموجودة في جدول التقارير إلى ملف Excel.
        // Returns: لا تُرجع قيمة (void).
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There is no data to export.",
                    "Export Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter =
                "Excel Files (*.xlsx)|*.xlsx";

            saveFileDialog.Title =
                "Save Report as Excel";

            saveFileDialog.FileName =
                "FSMS_Report.xlsx";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    DataTable dt = new DataTable();

                    foreach (DataGridViewColumn column in dgvReports.Columns)
                    {
                        if (column.Visible)
                        {
                            dt.Columns.Add(column.HeaderText);
                        }
                    }

                    foreach (DataGridViewRow row in dgvReports.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        DataRow dataRow = dt.NewRow();

                        int index = 0;

                        foreach (DataGridViewColumn column in dgvReports.Columns)
                        {
                            if (column.Visible)
                            {
                                dataRow[index] =
                                    row.Cells[column.Index].Value ?? "";

                                index++;
                            }
                        }

                        dt.Rows.Add(dataRow);
                    }

                    workbook.Worksheets.Add(dt, "Report");

                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show(
                    "Report exported successfully.",
                    "Export Excel",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Export Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }



        ///////////////////////////////////Button Action/////////////////////////////////////////////

        // تطبيق تنسيق Hover على أزرار القائمة عند دخول مؤشر الماوس.
        // Returns: لا تُرجع قيمة (void).
        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;

            btn.BackColor = Color.FromArgb(0, 150, 136);

            btn.IconColor = Color.White;

            btn.ForeColor = Color.White;
        }

        // إعادة تنسيق زر القائمة إلى حالته الطبيعية عند خروج مؤشر الماوس.
        // Returns: لا تُرجع قيمة (void).
        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;

            if (btn != currentButton)
            {
                btn.BackColor = Color.Transparent;
                btn.IconColor = Color.FromArgb(0, 150, 136);
                btn.ForeColor = Color.White;
            }
        }

        // تفعيل زر القائمة المحدد وإلغاء تفعيل الزر السابق.
        // Returns: لا تُرجع قيمة (void).
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                DisableButton();

                currentButton = (IconButton)btnSender;

                currentButton.BackColor = Color.FromArgb(0, 150, 136);
                currentButton.IconColor = Color.White;
                currentButton.ForeColor = Color.White;
            }
        }

        // إعادة الزر النشط إلى التنسيق الافتراضي.
        // Returns: لا تُرجع قيمة (void).
        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.IconColor = Color.FromArgb(0, 150, 136);
                currentButton.ForeColor = Color.White;
            }
        }

        // معالجة الضغط العام على أزرار القائمة وتفعيل الزر المضغوط.
        // Returns: لا تُرجع قيمة (void).
        private void MenuButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }













        ///////////////////////////////////Logout/////////////////////////////////////////////

        // تنفيذ تسجيل الخروج بعد تأكيد المستخدم والعودة إلى شاشة تسجيل الدخول.
        // Returns: لا تُرجع قيمة (void).
        private void bntLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();

                LoginForm loginForm = new LoginForm();

                loginForm.ShowDialog();

                this.Close();
            }
        }

        // تهيئة بيانات لوحة التحكم عند تحميل الفورم لأول مرة.
        // Returns: لا تُرجع قيمة (void).
        private void DashBoard_Load(object sender, EventArgs e)
        {
            ActivateButton(bntDashboard);

            LoadDashboardCards();
            LoadDashboardCharts();
            LoadRecentDonations();
            LoadRecentRequests();
            LoadNotifications();
        }


    }
}