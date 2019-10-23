using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Slide
{
    public partial class UserManage : Form
    {
        public UserManage()
        {
            InitializeComponent();
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["DiplomaConnectionString"].ConnectionString;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserManage_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
            UserManager u11 = new UserManager();
            u11.Show();
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO Users(Username,Password,UserType) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader Myreader;
                conn.Open();
                Myreader = cmd.ExecuteReader();
                MessageBox.Show("Data Inserted");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabimi :", ex.Message);
            }
        }

        private void textBox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                string query = "Update Users SET Username = '" + textBox2.Text + "', Password = '" + textBox3.Text + "', UserType = '" + textBox4.Text + "' where UserID = '" + textBox1.Text + "'";
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : ", ex.Message);
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string query = "Delete from Users where UserID = '" + textBox1.Text + "'";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("User Deleted");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabimi :", ex.Message);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.isPassword = true;
        }
    }
}
