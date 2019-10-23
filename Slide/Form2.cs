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
using System.Configuration;

namespace Slide
{
    public partial class Log_In : Form
    {
        public string utype;
        private string connectionString = ConfigurationManager.ConnectionStrings["DiplomaConnectionString"].ConnectionString;/*"Data Source=localhost;Initial Catalog=Diploma;Integrated Security=True";*/

        public string uType
        {
            get { return utype; }
            set { utype = value; }
        }

        public Log_In()
        {
            InitializeComponent();
        }

        private void Log_In_Load(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox1.ForeColor = Color.Black;
        }

        private void bunifuMaterialTextbox2_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.ForeColor = Color.Black;
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Dashboard d1 = new Dashboard();
            this.Hide();
            d1.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
                leftpanel.Visible = false;
                rightpanel.Visible = true;
                Transition1.ShowSync(rightpanel);
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox5.Text = "";
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            rightpanel.Visible = false;
            leftpanel.Visible = true;
            Transition1.ShowSync(leftpanel);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Users where Username = '" + bunifuMaterialTextbox4.Text + "' AND Password = '" + bunifuMaterialTextbox3.Text + "'";
            try
            {
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    GlobalClass.VariableName = dt.Rows[0][3].ToString();
                    if(GlobalClass.VariableName == "A")
                    {
                        Dashboard f2 = new Dashboard();
                        f2.ShowDialog();
                        this.Hide();
                        GlobalClass.VariableName = "A";
                    }
                    else if (GlobalClass.VariableName == "U")
                    {
                        Dashboard f2 = new Dashboard();
                        f2.bunifuFlatButton2.Enabled = false;
                        f2.bunifuFlatButton3.Enabled = false;
                        f2.bunifuFlatButton4.Enabled = false;
                        f2.ShowDialog();
                        this.Hide();
                        GlobalClass.VariableName = "U";
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Credentials");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabimi :", ex.Message);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (bunifuMaterialTextbox1.Text == ""  && bunifuMaterialTextbox5.Text == "")
            {
                MessageBox.Show("Please enter datas");
            }
            else
            {
                string query1 = "Select AdminPass from Users where UserID = '1'";
                try
                {
                    SqlConnection conn = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand(query1, conn);
                    conn.Open();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    string pass = dt.Rows[0][0].ToString();
                    if (bunifuMaterialTextbox2.Text == pass)
                    {
                        string query = "INSERT INTO Users(Username,Password,AdminPass,UserType) VALUES('" + bunifuMaterialTextbox1.Text + "','" + bunifuMaterialTextbox5.Text + "','" + bunifuMaterialTextbox2.Text + "','U')";
                        try
                        {
                            SqlConnection conn1 = new SqlConnection(connectionString);
                            SqlCommand cmd1 = new SqlCommand(query, conn);
                            SqlDataReader Myreader;
                            conn1.Open();
                            Myreader = cmd1.ExecuteReader();
                            conn.Close();
                            MessageBox.Show("User added succesfully");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gabimi :", ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password incorrect");
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void bunifuMaterialTextbox3_OnValueChanged(object sender, EventArgs e)
        {
        }

        private void bunifuMaterialTextbox3_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox3.isPassword = true;
        }

        private void bunifuMaterialTextbox2_OnValueChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
        }
    }
}
