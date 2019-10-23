using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ozeki.Media;

namespace Slide
{
    public partial class LiveView : Form
    {
        private DrawingImageProvider _bitmapSourceProvider1;
        private DrawingImageProvider _bitmapSourceProvider2;
        private DrawingImageProvider _bitmapSourceProvider3;
        private MediaConnector _connector1;
        private MediaConnector _connector2;
        private MediaConnector _connector3;
        private MJPEGConnection _mjpegConnection1;
        private MJPEGConnection _mjpegConnection2;
        private MJPEGConnection _mjpegConnection3;
        private SnapshotHandler _snapShot1;
        private SnapshotHandler _snapShot2;
        private SnapshotHandler _snapShot3;
        private MPEG4Recorder _mpeg4Recorder1;
        private MPEG4Recorder _mpeg4Recorder2;
        private MPEG4Recorder _mpeg4Recorder3;
        private IVideoSender _videoSender;

        public LiveView()
        {
            InitializeComponent();
            _bitmapSourceProvider1 = new DrawingImageProvider();
            _bitmapSourceProvider2 = new DrawingImageProvider();
            _bitmapSourceProvider3 = new DrawingImageProvider();
            _connector1 = new MediaConnector();
            _connector2 = new MediaConnector();
            _connector3 = new MediaConnector();
            _snapShot1 = new SnapshotHandler();
            _snapShot2 = new SnapshotHandler();
            _snapShot3 = new SnapshotHandler();
            videoViewerWF1.SetImageProvider(_bitmapSourceProvider1);
            videoViewerWF2.SetImageProvider(_bitmapSourceProvider2);
            videoViewerWF3.SetImageProvider(_bitmapSourceProvider3);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (GlobalClass.VariableName == "A")
            {
                this.Close();
                Dashboard d1 = new Dashboard();
                d1.Show();
                this.Hide();
            }
            else if (GlobalClass.VariableName == "U")
            {
                this.Close();
                Dashboard d1 = new Dashboard();
                d1.bunifuFlatButton2.Enabled = false;
                d1.bunifuFlatButton3.Enabled = false;
                d1.bunifuFlatButton4.Enabled = false;
                d1.Show();
                this.Hide();
            }

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

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection1 == null || _mpeg4Recorder1 == null) return;

                _mpeg4Recorder1.Multiplex();

                _connector1.Disconnect(_mjpegConnection1.AudioChannel, _mpeg4Recorder1.AudioRecorder);
                _connector1.Disconnect(_mjpegConnection1.VideoChannel, _mpeg4Recorder1.VideoRecorder);
                MessageBox.Show("Stop video recording");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection1 != null)
                    _mjpegConnection1.Disconnect();
                var config1 = new OzMJPEGClient_Config(bunifuMaterialTextbox4.Text, bunifuMaterialTextbox1.Text, bunifuMaterialTextbox2.Text);
                _mjpegConnection1 = new MJPEGConnection(config1);
                _mjpegConnection1.Connect();
                _connector1.Connect(_mjpegConnection1.VideoChannel, _bitmapSourceProvider1);
                _connector1.Connect(_mjpegConnection1.VideoChannel, _snapShot1);
                _videoSender = _mjpegConnection1.VideoChannel;
                videoViewerWF1.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void btnDisconnect1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection1 == null) return;
                _mjpegConnection1.Disconnect();
                _connector1.Disconnect(_mjpegConnection1.VideoChannel, _bitmapSourceProvider1);
                _connector1.Disconnect(_mjpegConnection1.VideoChannel, _snapShot1);
                videoViewerWF1.Stop();
                bunifuMaterialTextbox4.Text = "";
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
                videoViewerWF1.ClearScreen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error");
            }
        }

        private void btnConnect2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection2 != null)
                    _mjpegConnection2.Disconnect();

                var config2 = new OzMJPEGClient_Config(bunifuMaterialTextbox5.Text, bunifuMaterialTextbox7.Text, bunifuMaterialTextbox8.Text);
                _mjpegConnection2 = new MJPEGConnection(config2);
                _mjpegConnection2.Connect();
                _connector2.Connect(_mjpegConnection2.VideoChannel, _bitmapSourceProvider2);
                _connector2.Connect(_mjpegConnection2.VideoChannel, _snapShot2);
                videoViewerWF2.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void btnDisconnect2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection2 == null) return;
                _mjpegConnection2.Disconnect();
                _connector2.Disconnect(_mjpegConnection2.VideoChannel, _bitmapSourceProvider2);
                _connector2.Disconnect(_mjpegConnection2.VideoChannel, _snapShot2);
                videoViewerWF2.Stop();
                bunifuMaterialTextbox5.Text = "";
                bunifuMaterialTextbox7.Text = "";
                bunifuMaterialTextbox8.Text = "";
                bunifuMaterialTextbox6.Text = "";
                videoViewerWF2.ClearScreen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void btnConnect3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection3 != null)
                    _mjpegConnection3.Disconnect();

                var config3 = new OzMJPEGClient_Config(bunifuMaterialTextbox9.Text, bunifuMaterialTextbox11.Text, bunifuMaterialTextbox12.Text);
                _mjpegConnection3 = new MJPEGConnection(config3);
                _mjpegConnection3.Connect();
                _connector3.Connect(_mjpegConnection3.VideoChannel, _bitmapSourceProvider3);
                _connector3.Connect(_mjpegConnection3.VideoChannel, _snapShot3);
                videoViewerWF3.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void btnDisconnect3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection3 == null) return;
                _mjpegConnection3.Disconnect();
                _connector3.Disconnect(_mjpegConnection3.VideoChannel, _bitmapSourceProvider3);
                _connector3.Disconnect(_mjpegConnection3.VideoChannel, _snapShot3);
                videoViewerWF3.Stop();
                bunifuMaterialTextbox9.Text = "";
                bunifuMaterialTextbox11.Text = "";
                bunifuMaterialTextbox12.Text = "";
                bunifuMaterialTextbox10.Text = "";
                videoViewerWF3.ClearScreen();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void btnSnapshot1_Click(object sender, EventArgs e)
        {
            var path = bunifuMaterialTextbox3.Text;
            if (!String.IsNullOrEmpty(path))
                CreateSnapShot1(path);
        }

        private void btnSaveto1_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
                bunifuMaterialTextbox3.Text = folderBrowserDialog1.SelectedPath;
        }

        private void CreateSnapShot1(string path)
        {
            try
            {
                var date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
                           DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;

                string currentpath;
                if (String.IsNullOrEmpty(path))
                    currentpath = date + ".jpg";
                else
                    currentpath = path + "\\" + date + ".jpg";

                var image = _snapShot1.TakeSnapshot().ToImage();
                image.Save(currentpath, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Camera is not connected");
            }

        }

        private void btnSnapshot2_Click(object sender, EventArgs e)
        {
            var path = bunifuMaterialTextbox6.Text;
            if (!String.IsNullOrEmpty(path))
                CreateSnapShot2(path);
        }

        private void btnSaveto2_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog2.ShowDialog();
            if (result == DialogResult.OK)
                bunifuMaterialTextbox6.Text = folderBrowserDialog2.SelectedPath;
        }

        private void CreateSnapShot2(string path)
        {
            try
            {
                var date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
                           DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;

                string currentpath;
                if (String.IsNullOrEmpty(path))
                    currentpath = date + ".jpg";
                else
                    currentpath = path + "\\" + date + ".jpg";

                var image = _snapShot2.TakeSnapshot().ToImage();
                image.Save(currentpath, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Camera is not connected");
            }

        }

        private void btnSnapshot3_Click(object sender, EventArgs e)
        {
            var path = bunifuMaterialTextbox10.Text;
            if (!String.IsNullOrEmpty(path))
                CreateSnapShot3(path);
        }

        private void btnSavto3_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog3.ShowDialog();
            if (result == DialogResult.OK)
                bunifuMaterialTextbox10.Text = folderBrowserDialog3.SelectedPath;
        }

        private void CreateSnapShot3(string path)
        {
            try
            {
                var date = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" +
                           DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;

                string currentpath;
                if (String.IsNullOrEmpty(path))
                    currentpath = date + ".jpg";
                else
                    currentpath = path + "\\" + date + ".jpg";

                var image = _snapShot3.TakeSnapshot().ToImage();
                image.Save(currentpath, System.Drawing.Imaging.ImageFormat.Jpeg);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Camera is not connected");
            }

        }

        private void btnStartrec1_Click(object sender, EventArgs e)
        {
            try
            {
                var Path = "C:\\Users\\Public\\Documents";
                var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                           DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                string currentpath1;

                if (String.IsNullOrEmpty(Path))
                    currentpath1 = date + ".mp4";
                else
                    currentpath1 = Path + "\\" + date + ".mp4";

                _mpeg4Recorder1 = new MPEG4Recorder(currentpath1);
                _mpeg4Recorder1.MultiplexFinished += Mpeg4Recorder_MultiplexFinished1;

                _connector1.Connect(_mjpegConnection1.AudioChannel, _mpeg4Recorder1.AudioRecorder);
                _connector1.Connect(_mjpegConnection1.VideoChannel, _mpeg4Recorder1.VideoRecorder);
                if (_mpeg4Recorder1 != null)
                {
                    MessageBox.Show("Video saved to : " + Path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Camera is not connected");
            }
        }

        void Mpeg4Recorder_MultiplexFinished1(object sender, VoIPEventArgs<bool> e)
        {
            _connector1.Disconnect(_mjpegConnection1.AudioChannel, _mpeg4Recorder1.AudioRecorder);
            _connector1.Disconnect(_mjpegConnection1.VideoChannel, _mpeg4Recorder1.VideoRecorder);
            _mpeg4Recorder1.MultiplexFinished -= Mpeg4Recorder_MultiplexFinished1;
            _mpeg4Recorder1.Dispose();
        }

        private void btnDisconnectrec1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_videoSender == null) return;
                _connector1.Disconnect(_videoSender, _mpeg4Recorder1.VideoRecorder);
                _mpeg4Recorder1.Multiplex();
                MessageBox.Show("Stoping video recording");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void btnStartrec2_Click(object sender, EventArgs e)
        {
            try
            {
                var Path = "C:\\Users\\Public\\Documents";
                var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                           DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                string currentpath2;

                if (String.IsNullOrEmpty(Path))
                    currentpath2 = date + ".mp4";
                else
                    currentpath2 = Path + "\\" + date + ".mp4";

                _mpeg4Recorder2 = new MPEG4Recorder(currentpath2);
                _mpeg4Recorder2.MultiplexFinished += Mpeg4Recorder_MultiplexFinished2;

                _connector2.Connect(_mjpegConnection2.AudioChannel, _mpeg4Recorder2.AudioRecorder);
                _connector2.Connect(_mjpegConnection2.VideoChannel, _mpeg4Recorder2.VideoRecorder);
                if (_mpeg4Recorder2 != null)
                {
                    MessageBox.Show("Video saved to : " + Path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Camera is not connected");
            }
        }

        void Mpeg4Recorder_MultiplexFinished2(object sender, VoIPEventArgs<bool> e)
        {
            _connector2.Disconnect(_mjpegConnection2.AudioChannel, _mpeg4Recorder2.AudioRecorder);
            _connector2.Disconnect(_mjpegConnection2.VideoChannel, _mpeg4Recorder2.VideoRecorder);
            _mpeg4Recorder2.MultiplexFinished -= Mpeg4Recorder_MultiplexFinished2;
            _mpeg4Recorder2.Dispose();
        }

        private void btnDisconnectrec2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection2 == null || _mpeg4Recorder2 == null) return;

                _mpeg4Recorder2.Multiplex();

                _connector2.Disconnect(_mjpegConnection2.AudioChannel, _mpeg4Recorder2.AudioRecorder);
                _connector2.Disconnect(_mjpegConnection2.VideoChannel, _mpeg4Recorder2.VideoRecorder);
                MessageBox.Show("Stop video recording");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void btnStartrec3_Click(object sender, EventArgs e)
        {
            try
            {
                var Path = "C:\\Users\\Public\\Documents";
                var date = DateTime.Now.Year + "y-" + DateTime.Now.Month + "m-" + DateTime.Now.Day + "d-" +
                           DateTime.Now.Hour + "h-" + DateTime.Now.Minute + "m-" + DateTime.Now.Second + "s";
                string currentpath3;

                if (String.IsNullOrEmpty(Path))
                    currentpath3 = date + ".mp4";
                else
                    currentpath3 = Path + "\\" + date + ".mp4";

                _mpeg4Recorder3 = new MPEG4Recorder(currentpath3);
                _mpeg4Recorder3.MultiplexFinished += Mpeg4Recorder_MultiplexFinished3;

                _connector3.Connect(_mjpegConnection3.AudioChannel, _mpeg4Recorder3.AudioRecorder);
                _connector3.Connect(_mjpegConnection3.VideoChannel, _mpeg4Recorder3.VideoRecorder);
                if (_mpeg4Recorder3 != null)
                {
                    MessageBox.Show("Video saved to : " + Path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Camera is not connected");
            }
        }

        void Mpeg4Recorder_MultiplexFinished3(object sender, VoIPEventArgs<bool> e)
        {
            _connector3.Disconnect(_mjpegConnection3.AudioChannel, _mpeg4Recorder3.AudioRecorder);
            _connector3.Disconnect(_mjpegConnection3.VideoChannel, _mpeg4Recorder3.VideoRecorder);
            _mpeg4Recorder3.MultiplexFinished -= Mpeg4Recorder_MultiplexFinished3;
            _mpeg4Recorder3.Dispose();
        }

        private void btnDisconnectrec3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mjpegConnection3 == null || _mpeg4Recorder3 == null) return;

                _mpeg4Recorder3.Multiplex();

                _connector3.Disconnect(_mjpegConnection3.AudioChannel, _mpeg4Recorder3.AudioRecorder);
                _connector3.Disconnect(_mjpegConnection3.VideoChannel, _mpeg4Recorder3.VideoRecorder);
                MessageBox.Show("Stop video recording");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Please enter IP, Username and Password !");
            }
        }

        private void bunifuMaterialTextbox2_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2.isPassword = true;
        }

        private void bunifuMaterialTextbox8_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox8.isPassword = true;
        }

        private void bunifuMaterialTextbox12_Enter(object sender, EventArgs e)
        {
            bunifuMaterialTextbox12.isPassword = true;
        }

        private void LiveView_Load(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator3_Load(object sender, EventArgs e)
        {

        }
    }
}

