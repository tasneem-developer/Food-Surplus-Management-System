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
using FSMS.DataAccess;
namespace FSMS.Forms
{
    public partial class EditRestaurantForm : Form
    {
        private int restaurantID;
        public EditRestaurantForm()
        {
            InitializeComponent();
        }
        public EditRestaurantForm(int id)
        {
            InitializeComponent();

            restaurantID = id;

        }
        private void LoadRestaurantData()
        {
            RestaurantDAL dal = new RestaurantDAL();

            SqlDataReader dr = dal.GetRestaurantById(restaurantID);


            if (dr.Read())
            {
                txtRestaurantName.Text = dr["RestaurantName"].ToString();
                txtPhone.Text = dr["Phone"].ToString();
                txtContactPerson.Text = dr["ContactPerson"].ToString();
                cmdAddress.Text = dr["Address"].ToString();
                txtNotes.Text = dr["Notes"].ToString();

                cmbStatus.Text = dr["Status"].ToString();
            }

            dr.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void Desc_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            RestaurantDAL dal = new RestaurantDAL();


            dal.UpdateRestaurant(
                restaurantID,
                txtRestaurantName.Text.Trim(),
                txtPhone.Text.Trim(),
                txtContactPerson.Text.Trim(),
                cmdAddress.Text,
                cmbStatus.Text,
                txtNotes.Text.Trim()
            );


            DialogResult = DialogResult.OK;

            Close();
        }

        private void EditRestaurantForm_Load(object sender, EventArgs e)
        {
            LoadRestaurantData();
        }
    }
}
