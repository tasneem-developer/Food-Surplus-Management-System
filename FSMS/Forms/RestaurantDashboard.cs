using FontAwesome.Sharp;
using FSMS.DataAccess;
using FSMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FSMS.Forms
{

    public partial class RestaurantDashboard : Form
    {
        private int restaurantID;
        private RestaurantDashboardDAL dashboardDAL;
        private IconButton currentButton;
        private RestaurantDonationDAL donationDAL;
        private int hoverRowDonation = -1;
        private string hoverIconDonation = "";
        private RestaurantRequestDAL requestDAL =
    new RestaurantRequestDAL();

        // Constructor: initializes the restaurant dashboard and prepares its main components.
        public RestaurantDashboard(int restaurantID)
        {
            InitializeComponent();
            ShowPanel(pnlDashboardHome);
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyyy");
            this.restaurantID = restaurantID;
            dashboardDAL = new RestaurantDashboardDAL();
            donationDAL = new RestaurantDonationDAL();
            ActivateButton(bntDashboard);



            bntDashboard.Click += MenuButton_Click;
            bntDonations.Click += MenuButton_Click;
            bntRequests.Click += MenuButton_Click;
        }

        // Shows the selected dashboard panel and brings it to the front.
        private void ShowPanel(System.Windows.Forms.Panel panel)
        {

            panel.Visible = true;
            panel.BringToFront();
        }

        // Loads the restaurant's donation statistics and displays them on the dashboard.
        private void LoadDonationStatistics()
        {
            DataTable dt = dashboardDAL.GetDonationStatistics(restaurantID);

            if (dt.Rows.Count > 0)
            {
                lblTotalDonations.Text =
                    dt.Rows[0]["TotalDonations"].ToString();

                lblAvailableDonations.Text =
                    dt.Rows[0]["AvailableDonations"].ToString();

                lblCompletedDonations.Text =
                    dt.Rows[0]["CompletedDonations"].ToString();

                lblExpiredDonations.Text =
                    dt.Rows[0]["ExpiredDonations"].ToString();
            }
        }

        // Form Load event: loads all dashboard data when the restaurant dashboard starts.
        private void RestaurantDashboard_Load(object sender, EventArgs e)
        {


            LoadDonationStatistics();
            LoadDonationActivity();
            LoadDonationStatus();
            LoadRecentDonations();
            LoadRestaurantInfo();
            LoadRequestSummary();

            LoadRestaurantStatus();
        }

        // Loads the restaurant information and displays the restaurant name in the dashboard.
        private void LoadRestaurantInfo()
        {
            DataTable dt = dashboardDAL.GetRestaurantInfo(restaurantID);

            if (dt.Rows.Count > 0)
            {
                string restaurantName =
                    dt.Rows[0]["RestaurantName"].ToString();

                lblWelcome.Text =
                    "Welcome back, " + restaurantName + " Restaurant ";
                lblRestaurantName.Text = restaurantName + " Restaurant";
            }
        }

        // Changes the menu button appearance when the mouse enters the button.
        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            IconButton btn = sender as IconButton;

            btn.BackColor = Color.FromArgb(0, 150, 136);

            btn.IconColor = Color.White;

            btn.ForeColor = Color.White;
        }

        // Restores the menu button appearance when the mouse leaves it, unless it is active.
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

        // Activates the selected menu button and applies the active button styling.
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

        // Resets the appearance of the previously active menu button.
        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = Color.Transparent;
                currentButton.IconColor = Color.FromArgb(0, 150, 136);
                currentButton.ForeColor = Color.White;
            }
        }

        // Handles menu button clicks and activates the clicked button.
        private void MenuButton_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
        }


        // Loads the daily donation activity and displays it in the line chart.
        private void LoadDonationActivity()
        {
            DataTable dt = dashboardDAL.GetDonationActivity(restaurantID);

            chartDonationActivity.Series.Clear();
            chartDonationActivity.ChartAreas.Clear();

            ChartArea chartArea = new ChartArea();
            chartDonationActivity.ChartAreas.Add(chartArea);

            Series series = new Series("Donations");

            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 7;
            series.IsValueShownAsLabel = true;
            series.Color = Color.FromArgb(0, 150, 136);

            foreach (DataRow row in dt.Rows)
            {
                DateTime date = Convert.ToDateTime(row["DonationDay"]);
                int count = Convert.ToInt32(row["DonationCount"]);

                series.Points.AddXY(date.ToString("ddd"), count);
            }

            chartDonationActivity.Series.Add(series);

            chartArea.AxisX.Title = "Day";
            chartArea.AxisY.Title = "Donations";

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor =
                System.Drawing.Color.LightGray;

            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Interval = 1;
            chartArea.AxisY.LabelStyle.Format = "0";
        }





        // Loads donation statuses and displays their percentages in the doughnut chart.
        private void LoadDonationStatus()
        {
            DataTable dt = dashboardDAL.GetDonationStatus(restaurantID);

            chartDonationStatus.Series.Clear();
            chartDonationStatus.ChartAreas.Clear();
            chartDonationStatus.Legends.Clear();

            ChartArea chartArea = new ChartArea();
            chartDonationStatus.ChartAreas.Add(chartArea);

            Series series = new Series("Donation Status");

            series.ChartType = SeriesChartType.Doughnut;
            series["DoughnutRadius"] = "65";

            int total = 0;

            // حساب إجمالي التبرعات
            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToInt32(row["DonationCount"]);
            }

            foreach (DataRow row in dt.Rows)
            {
                string status = row["Status"].ToString();
                int count = Convert.ToInt32(row["DonationCount"]);

                int pointIndex = series.Points.AddXY(status, count);

                DataPoint point = series.Points[pointIndex];

                // النسبة المئوية
                double percentage = total > 0
                    ? (count * 100.0) / total
                    : 0;

                point.Label = percentage.ToString("0") + "%";
                point.LegendText = status;

                // ألوان الحالات
                if (status == "Available")
                {
                    point.Color =
                        System.Drawing.ColorTranslator.FromHtml("#2E7D32");
                }
                else if (status == "Completed")
                {
                    point.Color =
                        System.Drawing.ColorTranslator.FromHtml("blue");
                }
                else if (status == "Expired")
                {
                    point.Color =
                        System.Drawing.ColorTranslator.FromHtml("#E53935");
                }
                else if (status == "Cancelled")
                {
                    point.Color =
                        System.Drawing.ColorTranslator.FromHtml("gray");
                }
            }

            chartDonationStatus.Series.Add(series);

            Legend legend = new Legend();
            legend.Docking = Docking.Bottom;
            legend.Alignment = System.Drawing.StringAlignment.Center;

            chartDonationStatus.Legends.Add(legend);

            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
        }

        // Loads the restaurant's recent donations into the donations DataGridView.
        private void LoadRecentDonations()
        {
            DataTable dt = dashboardDAL.GetRecentDonations(restaurantID);

            dgvRecentDonations.DataSource = dt;
        }

        // Loads request statistics for the restaurant and displays them on the dashboard.
        private void LoadRequestSummary()
        {
            DataTable dt =
                dashboardDAL.GetRequestSummary(restaurantID);

            if (dt.Rows.Count > 0)
            {
                lblTotalRequests.Text =
                    dt.Rows[0]["TotalRequests"].ToString();

                lblPendingRequests.Text =
                    dt.Rows[0]["PendingRequests"].ToString();

                lblApprovedRequests.Text =
                    dt.Rows[0]["ApprovedRequests"].ToString();

                lblCompletedRequests.Text =
                    dt.Rows[0]["CompletedRequests"].ToString();

                lblRejectedRequests.Text =
                  dt.Rows[0]["RejectedRequests"].ToString();
            }
        }

        // Loads the restaurant's donations according to the search text and selected status.
        private void LoadMyDonations(string search = "", string status = "All")
        {
            RestaurantDonationDAL donationDAL = new RestaurantDonationDAL();

            donationDAL.UpdateExpiredDonations();

            DataTable dt = donationDAL.GetDonations(
                restaurantID,
                search,
                status
            );

            dgvMyDonations.DataSource = dt;

            lblDonationFound.Text = $"{dt.Rows.Count} Donations Found";

            lblNoDonation.Visible = dt.Rows.Count == 0;
        }

        // Reloads donations when the user changes the donation search text.
        private void txtSearchDonation_TextChanged(object sender, EventArgs e)
        {
            LoadMyDonations(txtSearchDonation.Text.Trim(), cmbDonationStatus.Text);
        }

        // Reloads donations when the selected donation status changes.
        private void cmbDonationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMyDonations(txtSearchDonation.Text.Trim(), cmbDonationStatus.Text);
        }

        // Displays the dashboard home panel and refreshes its main data.
        private void bntDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPanel(pnlDashboardHome);
            LoadDonationStatistics();
            LoadDonationActivity();
            LoadDonationStatus();
            LoadRecentDonations();
            LoadRestaurantInfo();
            LoadRequestSummary();

        }

        // Displays the donations panel and loads the restaurant's donation data.
        private void bntDonations_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPanel(pnlDonations);
            LoadMyDonations(txtSearchDonation.Text.Trim(), cmbDonationStatus.Text);
            LoadMyDonationStatistics();


        }

        // Loads statistics specifically for the restaurant's donations panel.
        private void LoadMyDonationStatistics()
        {
            DataTable dt = dashboardDAL.GetDonationStatistics(restaurantID);

            if (dt.Rows.Count > 0)
            {
                lblTotalMyDonations.Text =
                    dt.Rows[0]["TotalDonations"].ToString();

                lblAvailableMyDonations.Text =
                    dt.Rows[0]["AvailableDonations"].ToString();

                lblCompletedMyDonations.Text =
                    dt.Rows[0]["CompletedDonations"].ToString();

                lblExpiredMyDonations.Text =
                    dt.Rows[0]["ExpiredDonations"].ToString();
            }
        }

        // Resets the donation search and status filters, then reloads the donations list.
        private void btnRefreshDonation_Click(object sender, EventArgs e)
        {
            txtSearchDonation.Clear();
            cmbDonationStatus.SelectedIndex = 0;
            LoadMyDonations();
        }

        // Confirms logout, hides the dashboard, and opens the login form.
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

        // Custom paints donation status badges and action icons inside the donations table.
        private void dgvDonations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            // Status Badge
            if (dgvMyDonations.Columns[e.ColumnIndex].Name == "Status")
            {
                DrawStatusBadge(e);
            }


            // Action Icons
            if (dgvMyDonations.Columns[e.ColumnIndex].Name == "ActionDonation")
            {
                DataGridViewHelper.DrawActionIcons(
                    e,
                    hoverRowDonation,
                    hoverIconDonation
                );
            }
        }


        // Draws a colored badge representing the current donation status.
        private void DrawStatusBadge(DataGridViewCellPaintingEventArgs e)
        {
            e.PaintBackground(e.CellBounds, true);

            string status =
                dgvMyDonations.Rows[e.RowIndex]
                .Cells["Status"].Value.ToString();


            Color color = Color.Gray;


            switch (status)
            {
                case "Available":
                    color = Color.FromArgb(76, 175, 80);
                    break;

                case "Completed":
                    color = Color.FromArgb(63, 81, 181);
                    break;

                case "Expired":
                    color = Color.FromArgb(244, 67, 54);
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

        // Detects which donation action icon the mouse is hovering over.
        private void dgvDonations_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;


            if (dgvMyDonations.Columns[e.ColumnIndex].Name != "ActionDonation")
                return;


            int x = dgvMyDonations.PointToClient(System.Windows.Forms.Cursor.Position).X;


            Rectangle cell =
                dgvMyDonations.GetCellDisplayRectangle(
                    e.ColumnIndex,
                    e.RowIndex,
                    false
                );


            if (x < cell.Left + 45)
                hoverIconDonation = "Edit";
            else
                hoverIconDonation = "Delete";


            hoverRowDonation = e.RowIndex;


            dgvMyDonations.Cursor = Cursors.Hand;


            dgvMyDonations.InvalidateCell(
                e.ColumnIndex,
                e.RowIndex
            );
        }

        // Handles clicks on the donation action icons and opens edit or delete functionality.
        private void dgvDonations_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            if (e.RowIndex >= dgvMyDonations.Rows.Count)
                return;

            if (dgvMyDonations.Columns[e.ColumnIndex].Name != "ActionDonation")
                return;

            DataGridViewRow row = dgvMyDonations.Rows[e.RowIndex];

            if (row.IsNewRow)
                return;

            if (row.Cells["DonationID"].Value == null)
                return;

            int donationID =
     Convert.ToInt32(
         row.Cells["DonationID"].Value);

            int x = dgvMyDonations.PointToClient(System.Windows.Forms.Cursor.Position).X;
            Rectangle cell = dgvMyDonations.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);

            if (x < cell.Left + 45)
            {
                EditDonation(donationID);
            }
            else
            {
                DeleteDonation(donationID);
            }
        }

        // Opens the donation form in edit mode and refreshes the donation data after saving.
        private void EditDonation(int id)
        {
            RestaurantDonationForm frm =
                new RestaurantDonationForm(restaurantID, id);

            frm.FormTitle = "Edit Donation";
            frm.FormSubTitle = "Update donation information";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMyDonations(
                    txtSearchDonation.Text,
                    cmbDonationStatus.Text
                );

                LoadMyDonationStatistics();
            }
        }

        // Confirms deletion of a donation, deletes it, and refreshes the donation list.
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
                RestaurantDonationDAL donationDAL =
                    new RestaurantDonationDAL();

                donationDAL.DeleteDonation(id);

                LoadMyDonations(
                    txtSearchDonation.Text,
                    cmbDonationStatus.Text
                );

                LoadMyDonationStatistics();
            }
        }

        // Opens the donation form in create mode and refreshes the list after adding a donation.
        private void btnAddDonation_Click(object sender, EventArgs e)
        {
            RestaurantDonationForm frm =
       new RestaurantDonationForm(restaurantID);

            frm.FormTitle = "Create Donation";
            frm.FormSubTitle = "Add a new food donation";

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadMyDonations(
                    txtSearchDonation.Text,
                    cmbDonationStatus.Text
                );

                LoadMyDonationStatistics();
            }
        }

        // Opens the donations panel from the dashboard and loads the latest donation data.
        private void viewAllDonation_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPanel(pnlDonations);
            LoadMyDonationStatistics();
            LoadMyDonations(txtSearchDonation.Text.Trim(), cmbDonationStatus.Text);


        }

        // Loads the current restaurant status and updates the status switch and label.
        private void LoadRestaurantStatus()
        {
            string status =
                dashboardDAL.GetRestaurantStatus(restaurantID);

            if (status == "Active")
            {
                switchRestaurantStatus.Checked = true;
                lblRestaurantStatus.Text = "Active";
            }
            else
            {
                switchRestaurantStatus.Checked = false;
                lblRestaurantStatus.Text = "Inactive";
            }
        }

        // Updates the restaurant status in the database when the status switch changes.
        private void switchRestaurantStatus_CheckedChanged(
        object sender, EventArgs e)
        {
            string newStatus;

            if (switchRestaurantStatus.Checked)
            {
                newStatus = "Active";
                lblRestaurantStatus.Text = "Active";
            }
            else
            {
                newStatus = "Inactive";
                lblRestaurantStatus.Text = "Inactive";
            }

            dashboardDAL.UpdateRestaurantStatus(
                restaurantID,
                newStatus
            );
        }


        // Loads restaurant requests according to the search text and selected status.
        private void LoadRestaurantRequests(
    string search = "",
    string status = "All")
        {
            DataTable dt =
                requestDAL.GetRequests(
                    restaurantID,
                    search,
                    status);

            dgvRestaurantRequests.DataSource = dt;

            lblTotalRecords.Text =
                $"{dt.Rows.Count} Requests Found";

            lblNoReqest.Visible =
                dt.Rows.Count == 0;


        }

        // Loads request statistics for the restaurant and displays them in the request cards.
        private void LoadMyRequestStatistics()
        {
            DataTable dt =
                requestDAL.GetRequestStatistics(
                    restaurantID);

            if (dt.Rows.Count > 0)
            {
                lblTotalMyRequests.Text =
                    dt.Rows[0]["TotalRequests"].ToString();

                lblPendingMyRequests.Text =
                    dt.Rows[0]["PendingRequests"].ToString();

                lblApprovedMyRequests.Text =
                    dt.Rows[0]["ApprovedRequests"].ToString();

                lblCompletedMyRequests.Text =
                    dt.Rows[0]["CompletedRequests"].ToString();
            }
        }

        // Displays the requests panel and loads the restaurant's request data and statistics.
        private void bntRequests_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            ShowPanel(pnlRequests);

            LoadRestaurantRequests(
        txtSearchRequest.Text,
        cmbRequestStatus.Text);

            LoadMyRequestStatistics();
        }

        // Reloads restaurant requests when the request search text changes.
        private void txtSearchRequest_TextChanged(object sender, EventArgs e)
        {
            LoadRestaurantRequests(
     txtSearchRequest.Text,
     cmbRequestStatus.Text);
        }

        // Reloads restaurant requests when the selected request status changes.
        private void cmbRequestStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRestaurantRequests(
       txtSearchRequest.Text,
       cmbRequestStatus.Text);
        }

        // Resets the request filters and reloads the request list and statistics.
        private void btnRefreshRequests_Click(object sender, EventArgs e)
        {
            txtSearchRequest.Clear();
            cmbRequestStatus.SelectedIndex = 0;
            LoadRestaurantRequests(
      txtSearchRequest.Text,
      cmbRequestStatus.Text);

            LoadMyRequestStatistics();
        }







    }
}