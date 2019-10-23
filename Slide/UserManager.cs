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
    public partial class UserManager : Form
    {

        public UserManager()
        {
            InitializeComponent();
        }

        private string connectionString = ConfigurationManager.ConnectionStrings["DiplomaConnectionString"].ConnectionString;

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

            Dashboard d1 = new Dashboard();
            d1.Show();
            this.Close();
        }

        private void UserManager_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Users";
            try
            {

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                BindingSource bdsour = new BindingSource();
                bdsour.DataSource = dt;
                bunifuCustomDataGrid1.DataSource = bdsour;
                da.Update(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabimi :", ex.Message);
            }
        }

        private void bunifuCustomDataGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserManage u1 = new UserManage();
            u1.textBox1.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
            u1.textBox2.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
            u1.textBox3.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
            u1.textBox4.Text = this.bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
            u1.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Users";
            try
            {

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                BindingSource bdsour = new BindingSource();
                bdsour.DataSource = dt;
                bunifuCustomDataGrid1.DataSource = bdsour;
                da.Update(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabimi :", ex.Message);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Users";
            try
            {

                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                BindingSource bdsour = new BindingSource();
                bdsour.DataSource = dt;
                bunifuCustomDataGrid1.DataSource = bdsour;
                da.Update(dt);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabimi :", ex.Message);
            }
        }
    }
}
