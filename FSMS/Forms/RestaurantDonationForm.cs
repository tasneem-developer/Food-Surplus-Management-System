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

namespace FSMS.Forms
{
    public partial class RestaurantDonationForm : Form
    {
        private int restaurantID;
        private int donationID = 0;

        private bool isEdit = false;

        private RestaurantDonationDAL donationDAL =
            new RestaurantDonationDAL();
        public RestaurantDonationForm(int restaurantID)
        {
            InitializeComponent();

            this.restaurantID = restaurantID;

            isEdit = false;
        }
        public RestaurantDonationForm(int restaurantID, int donationID)
        {
            InitializeComponent();

            this.restaurantID = restaurantID;
            this.donationID = donationID;

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
            DataTable dt =
                donationDAL.GetDonationById(donationID);

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            txtFoodType.Text =
                row["FoodType"].ToString();

            numQuantity.Value =
                Convert.ToDecimal(row["Quantity"]);

            dtDonationDate.Value =
                Convert.ToDateTime(row["DonationDate"]);

            dtExpiryTime.Value =
                Convert.ToDateTime(row["ExpiryTime"]);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (!ValidateInputs())
            //    return;

            if (isEdit)
            {
                UpdateDonation();
            }
            else
            {
                AddDonation();
            }
        }


        private void AddDonation()
        {
            donationDAL.AddDonation(
                restaurantID,
                txtFoodType.Text.Trim(),
                Convert.ToInt32(numQuantity.Value),
                dtDonationDate.Value,
                dtExpiryTime.Value
            );

            MessageBox.Show(
                "Donation added successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }




        private void UpdateDonation()
        {
            donationDAL.UpdateDonation(
                donationID,
                restaurantID,
                txtFoodType.Text.Trim(),
                Convert.ToInt32(numQuantity.Value),
                dtDonationDate.Value,
                dtExpiryTime.Value            );

            MessageBox.Show(
                "Donation updated successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;
            Close();
        }

        private void RestaurantDonationForm_Load(object sender, EventArgs e)
        {
            if (isEdit)
            {
                LoadDonation();

                btnSave.Text = "Update";
            }
            else
            {
                btnSave.Text = "Save";

                txtFoodType.Clear();

                numQuantity.Value = numQuantity.Minimum;


                dtDonationDate.Value = DateTime.Now;

                dtExpiryTime.Value = DateTime.Now;
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            errorProvider1.Clear();


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

        private void btnSave_Click_1(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
