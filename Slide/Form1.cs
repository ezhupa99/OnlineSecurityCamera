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

namespace Slide
{
    public partial class Dashboard : Form
    {

        public Dashboard()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void butonMenu_Click(object sender, EventArgs e)
        {

            if (sidemenu.Width == 50)
            {
                sidemenu.Visible = false;
                sidemenu.Width = 217;
                panelTransition.ShowSync(sidemenu);
                logotransition1.ShowSync(Logo);
            }
            else
            {
                Logo.Visible = false;
                sidemenu.Visible = false;
                sidemenu.Width = 50;
                panelTransition1.ShowSync(sidemenu);
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            LiveView f3 = new LiveView();
            this.Hide();
            f3.Show();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Recordings r1 = new Recordings();
            this.Hide();
            r1.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_In f1 = new Log_In();
            f1.Show();
        }

        private void metroToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Snapshots s1 = new Snapshots();
            this.Hide();
            s1.Show();
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton6_Click_1(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = "Sistemi i Survejit te Kamerave";
            bunifuFlatButton1.Text = "   Pamje Direkt";
            bunifuFlatButton3.Text = "  Rregjistrime";
            bunifuFlatButton2.Text = "  Foto";
            label2.Text = "Sistemi i Survejit te Kamerave";
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            bunifuCustomLabel1.Text = "Surveillance Camera System";
            bunifuFlatButton1.Text = "   Live View";
            bunifuFlatButton3.Text = "  Recordings";
            bunifuFlatButton2.Text = "  Snapshot";
            label2.Text = "Surveillance Camera System";
        }

        private void bunifuFlatButton4_Click_1(object sender, EventArgs e)
        {
            UserManager u2 = new UserManager();
            this.Hide();
            u2.Show();
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            try
            {
                Log_In userLogOut = new Log_In();
                this.Hide();
                userLogOut.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gabimi : ", ex.Message);
            }
        }
    }
}
