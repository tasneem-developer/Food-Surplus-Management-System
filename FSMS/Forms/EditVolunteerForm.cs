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
    public partial class EditVolunteerForm : Form
    {
        private int volunteerID;
        public EditVolunteerForm(int id)
        {
            InitializeComponent();
            volunteerID = id;
        }

        private void LoadVolunteer()
        {
            VolunteerDAL dal = new VolunteerDAL();

            DataTable dt = dal.GetVolunteerById(volunteerID);

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];

                txtFullName.Text = dr["FullName"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                cmdArea.Text = dr["Area"].ToString();
                cmbStatus.Text = dr["Status"].ToString();
            }
        }

        private void EditVolunteerForm_Load(object sender, EventArgs e)
        {
            LoadVolunteer();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                VolunteerDAL dal = new VolunteerDAL();

                dal.UpdateVolunteer(
                    volunteerID,
                    txtFullName.Text.Trim(),
                    txtPhone.Text.Trim(),
                    cmdArea.Text,
                    cmbStatus.Text
                );

                MessageBox.Show(
                    "Volunteer updated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateInputs()
        {
            bool isValid = true;

            errorProvider1.Clear();

            // full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                errorProvider1.SetError(txtFullName, "Restaurant name is required.");
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


            return isValid;
        }
    }
}
