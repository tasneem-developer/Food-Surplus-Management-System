using FSMS.DataAccess;
using FSMS.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FSMS.Forms
{
    public partial class DonationForm : Form
    {
        private int donationID = 0;

        private bool isEdit = false;
        private DonationDAL donationDAL = new DonationDAL();
        public DonationForm()
        {
            InitializeComponent();

            isEdit = false;
        }

        public DonationForm(int id)
        {
            InitializeComponent();

            donationID = id;

            isEdit = true;
        }
        public string FormTitle
        {
            get
            {
                return lblTitle.Text;
            }
            set
            {
                lblTitle.Text = value;
            }
        }

        public string FormSubTitle
        {
            get
            {
                return lblSubTitle.Text;
            }
            set
            {
                lblSubTitle.Text = value;
            }
        }
        private void LoadDonation()
        {
            DataTable dt = DonationDAL.GetDonationById(donationID);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            cmbRestaurant.SelectedValue = row["RestaurantID"];

            txtFoodType.Text = row["FoodType"].ToString();

            numQuantity.Value = Convert.ToDecimal(row["Quantity"]);

            dtDonationDate.Value =
                Convert.ToDateTime(row["DonationDate"]);

            dtExpiryTime.Value =
                Convert.ToDateTime(row["ExpiryTime"]);

            cmbStatus.Text =
                row["Status"].ToString();
        }
        private void LoadRestaurants()
        {
            cmbRestaurant.DataSource = DonationDAL.GetRestaurantsForCombo();

            cmbRestaurant.DisplayMember = "RestaurantName";

            cmbRestaurant.ValueMember = "RestaurantID";
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs())
                return;

            if (isEdit)
            {
                UpdateDonation();

            }
            else
            {
                AddDonation();

            }
        }



        private bool ValidateInputs()
        {
            bool isValid = true;

            errorProvider1.Clear();


            // Restaurant
            if (cmbRestaurant.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cmbRestaurant,
                    "Please select a restaurant."
                );

                isValid = false;
            }


            // Food Type
            if (string.IsNullOrWhiteSpace(txtFoodType.Text))
            {
                errorProvider1.SetError(
                    txtFoodType,
                    "Food type is required."
                );

                isValid = false;
            }
            else if (txtFoodType.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(txtFoodType, "food name must contain text only.");
                isValid = false;
            }


            // Quantity
            if (numQuantity.Value <= 0)
            {
                errorProvider1.SetError(
                    numQuantity,
                    "Quantity must be greater than zero."
                );

                isValid = false;
            }


            // Status
            if (string.IsNullOrWhiteSpace(cmbStatus.Text))
            {
                errorProvider1.SetError(
                    cmbStatus,
                    "Please select donation status."
                );

                isValid = false;
            }


            // Expiry check
            if (dtExpiryTime.Value < dtDonationDate.Value)
            {
                errorProvider1.SetError(
                    dtExpiryTime,
                    "Expiry time cannot be before donation date."
                );

                isValid = false;
            }


            return isValid;
        }


        private void AddDonation()
        {
            donationDAL.AddDonation(
                Convert.ToInt32(cmbRestaurant.SelectedValue),
                txtFoodType.Text.Trim(),
                Convert.ToInt32(numQuantity.Value),
                dtDonationDate.Value,
                dtExpiryTime.Value,
                cmbStatus.Text);

            MessageBox.Show(
                "Donation added successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;

            Close();
        }

        private void UpdateDonation()
        {
           
            donationDAL.UpdateDonation(
                donationID,
                Convert.ToInt32(cmbRestaurant.SelectedValue),
                txtFoodType.Text.Trim(),
                Convert.ToInt32(numQuantity.Value),
                dtDonationDate.Value,
                dtExpiryTime.Value,
                cmbStatus.Text);

            MessageBox.Show(
                "Donation updated successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;

            Close();
        }

        private void DonationForm_Load(object sender, EventArgs e)
        {
            isEdit = donationID > 0;

            LoadRestaurants();

            if (isEdit)
            {
                LoadDonation();
                btnSave.Text = "Update";
            }
            else
            {
                btnSave.Text = "Save";

                cmbRestaurant.SelectedIndex = -1;
                txtFoodType.Clear();
                numQuantity.Value = numQuantity.Minimum;
                cmbStatus.SelectedIndex = 0;
                dtDonationDate.Value = DateTime.Now;
                dtExpiryTime.Value = DateTime.Now;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}