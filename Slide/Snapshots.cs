using Ozeki.Common;
using Ozeki.Media;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Slide
{
    public partial class Snapshots : Form
    {

        public Snapshots()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

                OpenFileDialog fileDialog1 = new OpenFileDialog();
                fileDialog1.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";
                if (fileDialog1.ShowDialog() == DialogResult.OK && fileDialog1.FileName.Length > 0)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = Image.FromFile(fileDialog1.FileName);
                }
            string filePath = fileDialog1.FileName;
            textBox1.Text = fileDialog1.SafeFileName;        }

        private void Snapshots_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox1.Text = "";
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard d1 = new Dashboard();
            d1.Show();
            this.Hide();

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

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog1 = new OpenFileDialog();
            fileDialog1.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp|png (*.png)|*.png";
            if (fileDialog1.ShowDialog() == DialogResult.OK && fileDialog1.FileName.Length > 0)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(fileDialog1.FileName);
            }
            string filePath = fileDialog1.FileName;
            textBox1.Text = fileDialog1.SafeFileName;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox1.Text = "";
        }
    }
}
