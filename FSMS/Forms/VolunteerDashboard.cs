using FontAwesome.Sharp;
using FSMS.DAL;
using FSMS.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace FSMS.Forms
{
    public partial class VolunteerDashboard : Form
    {
        private int volunteerID;

        private VolunteerDashboardDAL dashboardDAL;
        private VolunteerDonationDAL donationDAL;
        private VolunteerRequestDAL VolunteerRequestDAL;
        private IconButton currentButton;


        // Constructor:
        // تهيئة واجهة لوحة تحكم المتطوع، حفظ Volunteer ID،
        // إنشاء كائنات DAL وربط أزرار القائمة بالأحداث.
        // Returns: لا تُرجع قيمة؛ لأنها Constructor.
        public VolunteerDashboard(int volunteerID)
        {
            InitializeComponent();
            this.volunteerID = volunteerID;
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");

            dashboardDAL = new VolunteerDashboardDAL();
            donationDAL = new VolunteerDonationDAL();
            VolunteerRequestDAL = new VolunteerRequestDAL();
            this.volunteerID = volunteerID;
            ShowPanel(pnlDashboardHome);
            bntDashboard.Click += MenuButton_Click;
            btnAvailableDonations.Click += MenuButton_Click;
            btnMyRequests.Click += MenuButton_Click;
            dgvMyRequests.AutoGenerateColumns = false;

        }



        // عرض الـ Panel المطلوب وإظهاره في مقدمة الواجهة.
        // Returns: لا تُرجع قيمة (void).
        private void ShowPanel(System.Windows.Forms.Panel panel)
        {

            panel.Visible = true;
            panel.BringToFront();
        }


        // جلب إحصائيات المتطوع من قاعدة البيانات وعرضها في بطاقات Dashboard.
        // تشمل التبرعات المتاحة والطلبات المعلقة والمقبولة والمكتملة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadVolunteerStatistics()
        {
            DataTable dt =
                dashboardDAL.GetVolunteerStatistics(volunteerID);

            if (dt.Rows.Count > 0)
            {
                lblAvailableDonations.Text =
                    dt.Rows[0]["AvailableDonations"].ToString();

                lblPendingRequests.Text =
                    dt.Rows[0]["PendingRequests"].ToString();

                lblApprovedRequests.Text =
                    dt.Rows[0]["ApprovedRequests"].ToString();

                lblCompletedRequests.Text =
                    dt.Rows[0]["CompletedRequests"].ToString();
            }
        }

        // جلب بيانات المتطوع وعرض اسمه في رسالة الترحيب وبيانات الواجهة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadVolunteerInfo()
        {
            DataTable dt =
                dashboardDAL.GetVolunteerInfo(volunteerID);

            if (dt.Rows.Count > 0)
            {
                string name =
                    dt.Rows[0]["FullName"].ToString();

                lblWelcome.Text =
                    "Welcome Back, " + name + "!";
                lblVolunteerName.Text = name;
            }
        }

        // تحميل البيانات الأساسية عند فتح لوحة تحكم المتطوع.
        // يتم تحميل المعلومات والإحصائيات والطلبات والإشعارات وحالة المتطوع.
        // Returns: لا تُرجع قيمة (void).
        private void VolunteerDashboard_Load(object sender, EventArgs e)
        {
            LoadVolunteerInfo();

            LoadVolunteerStatistics();
            LoadMyRequestStatus();

            LoadNotifications();

            LoadRecentRequests();
            LoadVolunteerStatus();

        }


        // تغيير شكل زر القائمة عند مرور مؤشر الماوس عليه.
        // Returns: لا تُرجع قيمة (void).
        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;

            btn.BackColor = Color.FromArgb(0, 150, 136);

            btn.IconColor = Color.White;

            btn.ForeColor = Color.White;
        }

        // إعادة شكل زر القائمة إلى حالته الطبيعية عند خروج مؤشر الماوس.
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

        // إعادة الزر النشط إلى مظهره الطبيعي وإلغاء حالته النشطة.
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

        // معالجة الضغط على أزرار القائمة وتفعيل الزر الذي تم الضغط عليه.
        // Returns: لا تُرجع قيمة (void).
        private void MenuButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }



        // جلب حالات طلبات المتطوع وإنشاء Doughnut Chart يوضح نسبة كل حالة.
        // يعرض الحالات Pending و Approved و Completed كنسب مئوية.
        // Returns: لا تُرجع قيمة (void).
        private void LoadMyRequestStatus()
        {
            DataTable dt =
                dashboardDAL.GetMyRequestStatus(volunteerID);

            chartMyRequestStatus.Series.Clear();
            chartMyRequestStatus.ChartAreas.Clear();
            chartMyRequestStatus.Legends.Clear();

            ChartArea chartArea = new ChartArea();

            chartMyRequestStatus.ChartAreas.Add(chartArea);

            Series series =
                new Series("Request Status");

            series.ChartType =
                SeriesChartType.Doughnut;

            series["DoughnutRadius"] = "65";

            int total = 0;

            foreach (DataRow row in dt.Rows)
            {
                total +=
                    Convert.ToInt32(row["RequestCount"]);
            }

            foreach (DataRow row in dt.Rows)
            {
                string status =
                    row["Status"].ToString();

                int count =
                    Convert.ToInt32(row["RequestCount"]);

                int pointIndex =
                    series.Points.AddXY(status, count);

                DataPoint point =
                    series.Points[pointIndex];

                double percentage =
                    total > 0
                    ? (count * 100.0) / total
                    : 0;

                point.Label =
                    percentage.ToString("0") + "%";

                point.LegendText = status;

                if (status == "Pending")
                {
                    point.Color =
                        Color.FromArgb(255, 193, 7);
                }
                else if (status == "Approved")
                {
                    point.Color =
                        Color.FromArgb(0, 150, 136);
                }
                else if (status == "Completed")
                {
                    point.Color =
                        Color.DodgerBlue;
                }
            }

            chartMyRequestStatus.Series.Add(series);

            Legend legend = new Legend();

            legend.Docking = Docking.Bottom;

            legend.Alignment =
                StringAlignment.Center;

            chartMyRequestStatus.Legends.Add(legend);

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
        }


        // جلب الطلبات المقبولة للمتطوع وعرضها كإشعارات داخل Dashboard.
        // Returns: لا تُرجع قيمة (void).
        private void LoadNotifications()
        {
            DataTable dt =
                dashboardDAL.GetApprovedRequests(volunteerID);

            pnlNotificationList.Controls.Clear();

            if (dt.Rows.Count == 0)
            {
                lblNoNotifications.Visible = true;
                return;
            }

            lblNoNotifications.Visible = false;

            foreach (DataRow row in dt.Rows)
            {
                Panel notification =
                    CreateNotificationCard(row);

                pnlNotificationList.Controls.Add(
                    notification);
            }
        }


        // إنشاء بطاقة إشعار تحتوي على الأيقونة والعنوان والرسالة والتاريخ.
        // Returns: تُرجع Panel يحتوي على بيانات الإشعار.
        private Panel CreateNotificationCard(DataRow row)
        {
            Panel pnl = new Panel();

            pnl.Width =
                pnlNotificationList.ClientSize.Width - 10;

            pnl.Height = 85;

            pnl.Margin =
                new Padding(5, 5, 5, 5);

            pnl.BackColor =
                Color.WhiteSmoke;

            // Icon
            IconPictureBox icon =
                new IconPictureBox();

            icon.IconChar = IconChar.Bell;

            icon.IconColor =
                Color.FromArgb(0, 150, 136);

            icon.IconSize = 24;

            icon.Location =
                new Point(12, 15);

            icon.Size =
                new Size(30, 30);

            pnl.Controls.Add(icon);


            // Title
            Label lblTitle =
                new Label();

            lblTitle.Text =
                "Request Approved";

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    10,
                    FontStyle.Bold);

            lblTitle.AutoSize = true;

            lblTitle.Location =
                new Point(50, 8);

            pnl.Controls.Add(lblTitle);


            // Message
            Label lblMessage =
                new Label();

            lblMessage.Text =
                "Your request for " +
                row["FoodType"].ToString() +
                " has been approved.";

            lblMessage.Font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Regular);

            lblMessage.AutoSize = false;

            lblMessage.Width =
                pnl.Width - 65;

            lblMessage.Height = 30;

            lblMessage.Location =
                new Point(50, 32);

            pnl.Controls.Add(lblMessage);


            // Date
            Label lblDate =
                new Label();

            DateTime date =
                Convert.ToDateTime(
                    row["AssignedDate"]);

            lblDate.Text =
                date.ToString("dd/MM/yyyy");

            lblDate.Font =
                new Font(
                    "Segoe UI",
                    8,
                    FontStyle.Regular);

            lblDate.ForeColor =
                Color.Gray;

            lblDate.AutoSize = true;

            lblDate.Location =
                new Point(50, 62);

            pnl.Controls.Add(lblDate);


            return pnl;
        }

        // تسجيل خروج المتطوع وإظهار نافذة تسجيل الدخول مرة أخرى.
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


        // جلب أحدث طلبات المتطوع وعرضها في جدول الطلبات الأخيرة.
        // يتم أيضاً تعديل عناوين الأعمدة وإخفاء Request ID.
        // Returns: لا تُرجع قيمة (void).
        private void LoadRecentRequests()
        {
            DataTable dt =
                dashboardDAL.GetRecentRequests(volunteerID);

            dgvRecentRequests.DataSource = dt;

            if (dgvRecentRequests.Columns.Contains("RequestID"))
            {
                dgvRecentRequests.Columns["RequestID"]
                    .Visible = false;
            }

            dgvRecentRequests.Columns["FoodType"]
                .HeaderText = "Food Type";

            dgvRecentRequests.Columns["Quantity"]
                .HeaderText = "Quantity";

            dgvRecentRequests.Columns["RestaurantName"]
                .HeaderText = "Restaurant";

            dgvRecentRequests.Columns["RequestDate"]
                .HeaderText = "Request Date";

            dgvRecentRequests.Columns["Status"]
                .HeaderText = "Status";
        }

        // الانتقال إلى الصفحة الرئيسية للـDashboard وإعادة تحميل بياناتها.
        // Returns: لا تُرجع قيمة (void).
        private void bntDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPanel(pnlDashboardHome);
            LoadVolunteerInfo();

            LoadVolunteerStatistics();
            LoadMyRequestStatus();

            LoadNotifications();

            LoadRecentRequests();

        }

        // الانتقال إلى صفحة التبرعات المتاحة وتحميل التبرعات وإحصائياتها.
        // Returns: لا تُرجع قيمة (void).
        private void btnAvailableDonations_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPanel(pnlDonations);
            LoadAvailableDonations();
            LoadMyDonationStatistics();
        }

        // جلب التبرعات المتاحة للمتطوع باستخدام البحث الحالي.
        // يتم ربط النتائج بالجدول وتحديث عدد النتائج وعناوين الأعمدة.
        // Returns: لا تُرجع قيمة (void).
        private void LoadAvailableDonations()
        {
            DataTable dt =
                donationDAL.GetAvailableDonations(
                    volunteerID,
                    txtSearchDonation.Text.Trim());

            dgvAvailableDonations.DataSource = dt;

            lblDonationFound.Text =
                $"{dt.Rows.Count} Donations Found";

            lblNoDonation.Visible =
                dt.Rows.Count == 0;


            // Hide DonationID
            if (dgvAvailableDonations.Columns.Contains("DonationID"))
            {
                dgvAvailableDonations.Columns["DonationID"]
                    .Visible = false;
            }


            // Headers

            if (dgvAvailableDonations.Columns.Contains("FoodType"))
            {
                dgvAvailableDonations.Columns["FoodType"]
                    .HeaderText = "Food Type";
            }


            if (dgvAvailableDonations.Columns.Contains("Quantity"))
            {
                dgvAvailableDonations.Columns["Quantity"]
                    .HeaderText = "Quantity";
            }


            if (dgvAvailableDonations.Columns.Contains("RestaurantName"))
            {
                dgvAvailableDonations.Columns["RestaurantName"]
                    .HeaderText = "Restaurant";
            }


            if (dgvAvailableDonations.Columns.Contains("Address"))
            {
                dgvAvailableDonations.Columns["Address"]
                    .HeaderText = "Location";
            }


            if (dgvAvailableDonations.Columns.Contains("DonationDate"))
            {
                dgvAvailableDonations.Columns["DonationDate"]
                    .HeaderText = "Donation Date";
            }


            if (dgvAvailableDonations.Columns.Contains("ExpiryTime"))
            {
                dgvAvailableDonations.Columns["ExpiryTime"]
                    .HeaderText = "Expiry Time";
            }
        }

        // إرسال طلب للحصول على تبرع محدد بعد تأكيد المتطوع.
        // يتم تحديث التبرعات والإحصائيات بعد نجاح الطلب.
        // Returns: لا تُرجع قيمة (void).
        private void RequestDonation(int donationID)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to request this donation?",
                    "Request Donation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;


            bool success =
                donationDAL.CreateRequest(
                    volunteerID,
                    donationID);


            if (success)
            {
                MessageBox.Show(
                    "Donation request submitted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadAvailableDonations();
                LoadMyDonationStatistics();
            }
            else
            {
                MessageBox.Show(
                    "You already have an active request for this donation.",
                    "Request Exists",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // معالجة الضغط على زر Request داخل جدول التبرعات المتاحة.
        // يتم استخراج Donation ID ثم إرسال طلب التبرع.
        // Returns: لا تُرجع قيمة (void).
        private void dgvAvailableDonations_CellClick(
       object sender,
       DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;


            if (dgvAvailableDonations.Columns[e.ColumnIndex].Name
                != "Action")
                return;


            DataGridViewRow row =
                dgvAvailableDonations.Rows[e.RowIndex];


            if (row.IsNewRow)
                return;


            if (row.Cells["DonationID"].Value == null)
                return;


            int donationID =
                Convert.ToInt32(
                    row.Cells["DonationID"].Value);


            RequestDonation(donationID);
            LoadVolunteerStatistics();
        }




        // رسم زر Request داخل عمود Action في جدول التبرعات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvAvailableDonations_CellPainting(
      object sender,
      DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;


            if (dgvAvailableDonations.Columns[e.ColumnIndex].Name
                != "Action")
                return;


            e.PaintBackground(
                e.CellBounds,
                true);


            Rectangle buttonRect =
                new Rectangle(
                    e.CellBounds.Left + 8,
                    e.CellBounds.Top + 6,
                    e.CellBounds.Width - 16,
                    e.CellBounds.Height - 12);


            using (Brush brush =
                new SolidBrush(
                    Color.FromArgb(0, 150, 136)))
            {
                e.Graphics.FillRectangle(
                    brush,
                    buttonRect);
            }


            using (Font font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    "Request",
                    font,
                    buttonRect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter);
            }


            e.Handled = true;
        }

        // تغيير شكل مؤشر الماوس إلى Hand عند المرور فوق زر Action.
        // Returns: لا تُرجع قيمة (void).
        private void dgvAvailableDonations_CellMouseMove(
     object sender,
     DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;


            if (dgvAvailableDonations.Columns[e.ColumnIndex].Name
                == "Action")
            {
                dgvAvailableDonations.Cursor =
                    Cursors.Hand;
            }
            else
            {
                dgvAvailableDonations.Cursor =
                    Cursors.Default;
            }
        }

        // إعادة تحميل التبرعات عند تغيير نص البحث.
        // Returns: لا تُرجع قيمة (void).
        private void txtSearchDonation_TextChanged(object sender, EventArgs e)
        {
            LoadAvailableDonations();
        }

        // مسح البحث وإعادة تحميل قائمة التبرعات المتاحة.
        // Returns: لا تُرجع قيمة (void).
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchDonation.Clear();

            LoadAvailableDonations();
        }

        // جلب إحصائيات التبرعات الخاصة بالمتطوع وعرضها في بطاقات الإحصائيات.
        // Returns: لا تُرجع قيمة (void).
        private void LoadMyDonationStatistics()
        {
            DataTable dt =
                donationDAL.GetMyDonationStatistics(
                    volunteerID);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            lblTotalAvailable.Text =
                row["TotalAvailable"].ToString();

            lblFoodItems.Text =
                row["FoodItems"].ToString();

            lblMyRequests.Text =
                row["MyRequests"].ToString();

            lblApprovedRequest.Text =
                row["ApprovedRequests"].ToString();
        }


        // جلب جميع طلبات المتطوع حسب البحث والحالة المحددة وعرضها في الجدول.
        // يتم أيضاً ضبط عناوين الأعمدة وإخفاء Request ID.
        // Returns: لا تُرجع قيمة (void).
        private void LoadMyRequests()
        {
            string search =
                txtSearchRequest.Text.Trim();

            string status =
                cmbRequestStatus.SelectedItem?
                .ToString() ?? "All";

            DataTable dt =
                VolunteerRequestDAL.GetMyRequests(
                    volunteerID,
                    search,
                    status);


            dgvMyRequests.DataSource = dt;

            lblTotalRecords.Text =
             $"{dt.Rows.Count} Donations Found";

            lblNoReqest.Visible =
                dt.Rows.Count == 0;

            // =========================================================
            // HIDE REQUEST ID
            // =========================================================

            if (dgvMyRequests.Columns.Contains("RequestID"))
            {
                dgvMyRequests.Columns["RequestID"]
                    .Visible = false;
            }

            // =========================================================
            // HEADERS
            // =========================================================

            if (dgvMyRequests.Columns.Contains("FoodTypeRequest"))
            {
                dgvMyRequests.Columns["FoodTypeRequest"]
                    .HeaderText = "Food Type";
            }

            if (dgvMyRequests.Columns.Contains("QuantityRequest"))
            {
                dgvMyRequests.Columns["QuantityRequest"]
                    .HeaderText = "Quantity";
            }

            if (dgvMyRequests.Columns.Contains("RestaurantNameR"))
            {
                dgvMyRequests.Columns["RestaurantNameR"]
                    .HeaderText = "Restaurant";
            }

            if (dgvMyRequests.Columns.Contains("AddressR"))
            {
                dgvMyRequests.Columns["AddressR"]
                    .HeaderText = "Location";
            }

            if (dgvMyRequests.Columns.Contains("DonationDateR"))
            {
                dgvMyRequests.Columns["DonationDateR"]
                    .HeaderText = "Donation Date";
            }

            if (dgvMyRequests.Columns.Contains("ExpiryTimeR"))
            {
                dgvMyRequests.Columns["ExpiryTimeR"]
                    .HeaderText = "Expiry Time";
            }

            if (dgvMyRequests.Columns.Contains("StatusRequest"))
            {
                dgvMyRequests.Columns["StatusRequest"]
                    .HeaderText = "Status";
            }

            if (dgvMyRequests.Columns.Contains("AssignedDate"))
            {
                dgvMyRequests.Columns["AssignedDate"]
                    .HeaderText = "Request Date";
            }

            if (dgvMyRequests.Columns.Contains("ActionR"))
            {
                dgvMyRequests.Columns["ActionR"]
                    .HeaderText = "Action";
            }

            dgvMyRequests.Refresh();
        }

        // الانتقال إلى صفحة طلبات المتطوع وتحميل الطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void btnMyRequests_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);

            ShowPanel(pnlMyRequests);
            LoadMyRequests();
        }

        // إعادة تحميل الطلبات عند تغيير نص البحث.
        // Returns: لا تُرجع قيمة (void).
        private void txtSearchRequest_TextChanged(object sender, EventArgs e)
        {
            LoadMyRequests();
        }

        // إعادة تحميل الطلبات عند تغيير حالة الطلب من ComboBox.
        // Returns: لا تُرجع قيمة (void).
        private void cmbRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMyRequests();
        }

        // مسح البحث وإعادة الحالة إلى All ثم إعادة تحميل الطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void btnRefreshRequests_Click(object sender, EventArgs e)
        {
            txtSearchRequest.Clear();

            cmbRequestStatus.SelectedIndex = 0;

            LoadMyRequests();
        }


        // رسم زر Action داخل جدول طلبات المتطوع حسب حالة الطلب.
        // Pending يظهر Cancel، وApproved يظهر Complete،
        // بينما الحالات المكتملة أو الملغاة تظهر بحالتها.
        // Returns: لا تُرجع قيمة (void).
        private void dgvMyRequests_CellPainting(
        object sender,
        DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            if (dgvMyRequests.Columns[e.ColumnIndex].Name
                != "ActionR")
                return;

            e.PaintBackground(
                e.CellBounds,
                true);

            string status =
                dgvMyRequests.Rows[e.RowIndex]
                .Cells["StatusRequest"]
                .Value?
                .ToString()
                .Trim() ?? "";

            string buttonText = "";
            Color buttonColor = Color.Gray;

            // =========================================================
            // PENDING
            // =========================================================

            if (status.Equals(
                "Pending",
                StringComparison.OrdinalIgnoreCase))
            {
                buttonText = "Cancel";

                buttonColor =
                    Color.FromArgb(255, 152, 0);
            }

            // =========================================================
            // APPROVED
            // =========================================================

            else if (status.Equals(
                "Approved",
                StringComparison.OrdinalIgnoreCase))
            {
                buttonText = "Complete";

                buttonColor =
                    Color.FromArgb(63, 81, 181);
            }

            // =========================================================
            // COMPLETED
            // =========================================================

            else if (status.Equals(
                "Completed",
                StringComparison.OrdinalIgnoreCase))
            {
                buttonText = "Completed";

                buttonColor =
                    Color.FromArgb(76, 175, 80);
            }

            // =========================================================
            // CANCELLED
            // =========================================================

            else if (status.Equals(
                "Cancelled",
                StringComparison.OrdinalIgnoreCase))
            {
                buttonText = "Cancelled";

                buttonColor =
                    Color.Gray;
            }

            else if (status.Equals(
               "Rejected",
               StringComparison.OrdinalIgnoreCase))
            {
                buttonText = "Rejected";

                buttonColor =
                    Color.Red;
            }
            Rectangle buttonRect =
                new Rectangle(
                    e.CellBounds.Left + 8,
                    e.CellBounds.Top + 6,
                    e.CellBounds.Width - 16,
                    e.CellBounds.Height - 12);

            using (Brush brush =
                new SolidBrush(buttonColor))
            {
                e.Graphics.FillRectangle(
                    brush,
                    buttonRect);
            }

            using (Font font =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold))
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    buttonText,
                    font,
                    buttonRect,
                    Color.White,
                    TextFormatFlags.HorizontalCenter |
                    TextFormatFlags.VerticalCenter);
            }

            e.Handled = true;
        }

        // إلغاء طلب متطوع موجود في حالة Pending بعد تأكيد المستخدم.
        // Returns: لا تُرجع قيمة (void).
        private void CancelMyRequest(int requestID)
        {
            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to cancel this request?",
                    "Cancel Request",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            bool success =
                VolunteerRequestDAL.CancelRequest(
                    requestID);

            if (success)
            {
                MessageBox.Show(
                    "Your request has been cancelled successfully.",
                    "Request Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMyRequests();

                LoadMyDonationStatistics();

                dgvMyRequests.Invalidate();
                dgvMyRequests.Refresh();
            }
            else
            {
                MessageBox.Show(
                    "Only pending requests can be cancelled.",
                    "Cancel Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // معالجة الضغط على زر Action في جدول الطلبات.
        // يحدد الإجراء المطلوب حسب حالة الطلب: Cancel أو Complete.
        // Returns: لا تُرجع قيمة (void).
        private void dgvMyRequests_CellClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex < 0)
                return;

            if (dgvMyRequests.Columns[e.ColumnIndex].Name
                != "ActionR")
                return;

            DataGridViewRow row =
                dgvMyRequests.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            // =========================================================
            // GET REQUEST ID
            // =========================================================

            if (row.Cells["RequestID"].Value == null ||
                row.Cells["RequestID"].Value == DBNull.Value)
                return;

            int requestID =
                Convert.ToInt32(
                    row.Cells["RequestID"].Value);

            // =========================================================
            // GET STATUS
            // =========================================================

            string status =
                row.Cells["StatusRequest"].Value?
                .ToString()
                .Trim() ?? "";

            // =========================================================
            // PENDING → CANCEL
            // =========================================================

            if (status.Equals(
                "Pending",
                StringComparison.OrdinalIgnoreCase))
            {
                CancelMyRequest(requestID);
            }

            // =========================================================
            // APPROVED → COMPLETE
            // =========================================================

            else if (status.Equals(
                "Approved",
                StringComparison.OrdinalIgnoreCase))
            {
                CompleteMyRequest(requestID);
            }

            // =========================================================
            // COMPLETED
            // =========================================================

            else if (status.Equals(
                "Completed",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "This request has already been completed.",
                    "Request Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            // =========================================================
            // CANCELLED
            // =========================================================

            else if (status.Equals(
                "Cancelled",
                StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "This request has already been cancelled.",
                    "Request Cancelled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            else if (status.Equals(
               "Rejected",
               StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(
                    "This request has already been Rejected.",
                    "Request Rejected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        // إكمال طلب تمت الموافقة عليه بعد تأكيد استلام التبرع.
        // Returns: لا تُرجع قيمة (void).
        private void CompleteMyRequest(int requestID)
        {
            DialogResult result =
                MessageBox.Show(
                    "Have you received the food donation?\n\n" +
                    "If yes, the request will be marked as completed.",
                    "Complete Request",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            bool success =
                VolunteerRequestDAL.CompleteRequest(
                    requestID);

            if (success)
            {
                MessageBox.Show(
                    "The request has been completed successfully.",
                    "Request Completed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadMyRequests();

                LoadMyDonationStatistics();

                dgvMyRequests.Invalidate();
                dgvMyRequests.Refresh();
            }
            else
            {
                MessageBox.Show(
                    "Only approved requests can be completed.",
                    "Complete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // تغيير مؤشر الماوس إلى Hand عند المرور فوق زر Action في الطلبات.
        // Returns: لا تُرجع قيمة (void).
        private void dgvMyRequests_CellMouseMove(
       object sender,
       DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 ||
                e.ColumnIndex < 0)
                return;

            if (dgvMyRequests.Columns[e.ColumnIndex].Name
                == "ActionR")
            {
                dgvMyRequests.Cursor =
                    Cursors.Hand;
            }
            else
            {
                dgvMyRequests.Cursor =
                    Cursors.Default;
            }
        }

        // الانتقال إلى صفحة طلبات المتطوع عند الضغط على View All Donations.
        // Returns: لا تُرجع قيمة (void).
        private void viewAllDonation_Click(object sender, EventArgs e)
        {
            ActivateButton(btnMyRequests);

            ShowPanel(pnlMyRequests);
            LoadMyRequests();
        }

        // جلب حالة حساب المتطوع من قاعدة البيانات وعرضها في Switch وLabel.
        // Returns: لا تُرجع قيمة (void).
        private void LoadVolunteerStatus()
        {
            string status =
                dashboardDAL.GetVolunteerStatus(volunteerID);

            if (status == "Active")
            {
                switchVolunteerStatus.Checked = true;

                lblVolunteerStatus.Text =
                    "Active";
            }
            else
            {
                switchVolunteerStatus.Checked = false;

                lblVolunteerStatus.Text =
                    "Inactive";
            }
        }

        // تحديث حالة المتطوع في قاعدة البيانات عند تغيير Switch.
        // الحالات الممكنة هي Active و Inactive.
        // Returns: لا تُرجع قيمة (void).
        private void switchVolunteerStatus_CheckedChanged(object sender, EventArgs e)
        {
            string newStatus;

            if (switchVolunteerStatus.Checked)
            {
                newStatus = "Active";

                lblVolunteerStatus.Text =
                    "Active";
            }
            else
            {
                newStatus = "Inactive";

                lblVolunteerStatus.Text =
                    "Inactive";
            }

            dashboardDAL.UpdateVolunteerStatus(
                volunteerID,
                newStatus);
        }
    }
}