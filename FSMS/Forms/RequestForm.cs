using FSMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSMS.Forms
{
    public partial class RequestForm : Form
    {
        private  RequestDAL requestDAL = new RequestDAL();

        private int requestID = 0;

        private bool isEdit = false;
        public RequestForm()
        {
            InitializeComponent();

            LoadComboBoxes();
            LoadVolunteers();

            lblTitle.Text = "Assign Donation";

            lblSubTitle.Text = "Assign a food donation to a volunteer";
        }

        public RequestForm(int id)
        {
            InitializeComponent();

            requestID = id;

            isEdit = true;

            LoadComboBoxes();

            LoadRequestData();

            LoadVolunteers();


            lblTitle.Text = "Edit Assignment";

            lblSubTitle.Text = "Update assignment information";
            btnSave.Text = "Update";

        }
        private void LoadComboBoxes()
        {
            DataTable dt;

            if (isEdit)
                dt = requestDAL.GetAvailableDonations(requestID);
            else
                dt = requestDAL.GetAvailableDonations();

            cmbDonation.DataSource = dt;

            cmbDonation.DisplayMember = "DonationInfo";

            cmbDonation.ValueMember = "DonationID";

            cmbStatus.Items.Clear();

            cmbStatus.Items.Add("Pending");
            cmbStatus.Items.Add("Approved");
            cmbStatus.Items.Add("Completed");
        }
        private void LoadVolunteers()
        {
            if (cmbDonation.SelectedValue == null)
                return;

            if (!int.TryParse(cmbDonation.SelectedValue.ToString(), out int donationID))
                return;

            cmbVolunteer.DataSource =
                requestDAL.GetAvailableVolunteers(donationID);

            cmbVolunteer.DisplayMember = "FullName";

            cmbVolunteer.ValueMember = "VolunteerID";
        }
        private void cmbDonation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDonation.SelectedValue == null)
                return;

            LoadDonationDetails();

            LoadVolunteers();
        }
        private void LoadDonationDetails()
        {
            if (cmbDonation.SelectedValue == null)
                return;

            if (!int.TryParse(cmbDonation.SelectedValue.ToString(), out int donationID))
                return;

            DataTable dt =
                requestDAL.GetDonationDetails(donationID);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtRestaurant.Text =
                row["RestaurantName"].ToString();

            txtFoodType.Text =
                row["FoodType"].ToString();

            txtQuantity.Text =
                row["Quantity"].ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs())
                return;
            try
            {
   

                int donationID = Convert.ToInt32(cmbDonation.SelectedValue);

                int volunteerID = Convert.ToInt32(cmbVolunteer.SelectedValue);

                string status = cmbStatus.Text;

                DateTime assignedDate = dtAssignedDate.Value;



                if (isEdit)
                {
                    requestDAL.UpdateRequest(
                        requestID,
                        donationID,
                        volunteerID,
                        status,
                        assignedDate
                    );


                    MessageBox.Show(
                        "Request updated successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    requestDAL.InsertRequest(
                        donationID,
                        volunteerID,
                        status,
                        assignedDate
                    );


                    MessageBox.Show(
                        "Request added successfully",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }


                this.DialogResult = DialogResult.OK;

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadRequestData()
        {
            DataTable dt = requestDAL.GetRequestByID(requestID);


            if (dt.Rows.Count > 0)
            {
                cmbDonation.SelectedValue =
                    Convert.ToInt32(dt.Rows[0]["DonationID"]);


                cmbVolunteer.SelectedValue =
                    Convert.ToInt32(dt.Rows[0]["VolunteerID"]);


                cmbStatus.Text =
                    dt.Rows[0]["Status"].ToString();


                dtAssignedDate.Value =
                    Convert.ToDateTime(dt.Rows[0]["AssignedDate"]);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            errorProvider1.Clear();


           
            if (cmbDonation.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cmbDonation,
                    "Please select a Donation."
                );

                isValid = false;
            }

            //if (string.IsNullOrWhiteSpace(txtFoodType.Text))
            //{
            //    errorProviderRequest.SetError(
            //        txtFoodType,
            //        "Food type is required."
            //    );

            //    isValid = false;
            //}

            //if (txtQuantity.Value <= 0)
            //{
            //    errorProvider1.SetError(
            //        numQuantity,
            //        "Quantity must be greater than zero."
            //    );

            //    isValid = false;
            //}


            // Status
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                errorProvider1.SetError(
                    cmbStatus,
                    "Please select Request status."
                );

                isValid = false;
            }


         

            return isValid;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
