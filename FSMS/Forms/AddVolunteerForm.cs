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
    public partial class AddVolunteerForm : Form
    {
        public AddVolunteerForm()
        {
            InitializeComponent();
            txtPassword.UseSystemPasswordChar = true;

            cmbStatus.SelectedIndex = 0;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }
        private bool ValidateInputs()
        {
            bool isValid = true;

            errorProvider1.Clear();

            // full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Full name is required.");
                isValid = false;
            }
            else if (txtFullName.Text.Any(char.IsDigit))
            {
                errorProvider1.SetError(txtFullName, "Full name must contain text only.");
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

   

            // Area
            if (string.IsNullOrWhiteSpace(cmdArea.Text))
            {
                errorProvider1.SetError(cmdArea, "Address is required.");
                isValid = false;
            }

            // Username
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                errorProvider1.SetError(txtUsername, "Username is required.");
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                VolunteerDAL dal = new VolunteerDAL();

                dal.AddVolunteer(
                    txtUsername.Text.Trim(),
                    txtPassword.Text.Trim(),
                    txtFullName.Text.Trim(),
                    txtPhone.Text.Trim(),
                    cmdArea.Text,
                    cmbStatus.Text);

                MessageBox.Show(
                    "Volunteer added successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
       !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
