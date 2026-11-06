using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using FSMS.DataAccess;
namespace FSMS.Forms

{
    public partial class AddRestaurantForm : Form
    {

        private bool ValidateInputs()
        {
            bool isValid = true;

            errorProvider1.Clear();

            // Restaurant Name
            if (string.IsNullOrWhiteSpace(txtRestaurantName.Text))
            {
                errorProvider1.SetError(txtRestaurantName, "Restaurant name is required.");
                isValid = false;
            }
            else if (txtRestaurantName.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(txtRestaurantName, "Restaurant name must contain text only.");
                isValid = false;
            }

            // Phone
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider1.SetError(txtPhone, "Phone number is required.");
                isValid = false;
            }
            else if (txtPhone.Text.Length != 9)
            {
                errorProvider1.SetError(txtPhone, "Phone number must be 9 digits.");
                isValid = false;
            }
            else if (!txtPhone.Text.All(char.IsDigit))
            {
                errorProvider1.SetError(txtPhone, "Phone must contain numbers only.");
                isValid = false;
            }
          

            // Contact Person
            if (string.IsNullOrWhiteSpace(txtContactPerson.Text))
            {
                errorProvider1.SetError(txtContactPerson, "Contact person is required.");
                isValid = false;
            }
            else if (txtContactPerson.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(txtContactPerson, "Contact person name must contain text only.");
                isValid = false;
            }

            // Address
            if (string.IsNullOrWhiteSpace(cmdAddress.Text))
            {
                errorProvider1.SetError(cmdAddress, "Address is required.");
                isValid = false;
            }

            // Username
            if (string.IsNullOrWhiteSpace(tUsername.Text))
            {
                errorProvider1.SetError(tUsername, "Username is required.");
                isValid = false;
            }

            // Password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errorProvider1.SetError(txtPassword, "Password is required.");
                isValid = false;
            }
            else if (txtPassword.Text.Length < 6)
            {
                errorProvider1.SetError(txtPassword, "Password must be at least 6 characters.");
                isValid = false;
            }

            return isValid;
        }
        public AddRestaurantForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;


            try
            {
                RestaurantDAL dal = new RestaurantDAL();


                dal.AddRestaurant(
                    tUsername.Text.Trim(),
                    txtPassword.Text.Trim(),
                    txtRestaurantName.Text.Trim(),
                    txtPhone.Text.Trim(),
                    txtContactPerson.Text.Trim(),
                    cmdAddress.Text,
                    cmbStatus.Text,
                    txtNotes.Text.Trim()
                );


                MessageBox.Show(
                    "Restaurant added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                DialogResult = DialogResult.OK;
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
