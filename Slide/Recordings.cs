using Ozeki.Common;
using Ozeki.Media;
using System;
using System.Linq;
using System.Windows.Forms;


namespace Slide
{
    public partial class Recordings : Form
    {
        private Speaker speaker;
        private AVPlayer _player;
        private MediaConnector _connector;
        private DrawingImageProvider _provider;

        public Recordings()
        {
            InitializeComponent();

            this.FormClosing += MainForm_FormClosing;

            _connector = new MediaConnector();

            _provider = new DrawingImageProvider();

            videoViewerWF1.Start();

            var SpeakerList = Speaker.GetDevices();
            var DeviceInfo = WaveOutFactory.GetDefaultDeviceInfo(AudioApi.WASAPI);
            speaker = Speaker.GetDefaultDevice(new AudioFormat(44100, 2, 16));
            speaker.ConverterType = AudioConverterType.DMO;
        }

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                videoViewerWF1.Stop();

                if (_player != null)
                    _player.Stop();

                speaker.Stop();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Gabimi : ", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard d1 = new Dashboard();
            d1.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                _connector.Disconnect(_player.VideoChannel, _provider);
                _connector.Disconnect(_player.AudioChannel, speaker);

                _player.Stop();
                speaker.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.InitialDirectory = @"C:\Videos\TEST\AVI";
                DialogResult result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    var tmp = openFileDialog1.FileName.Split('.');
                    string ext = tmp[tmp.Length - 1];
                    ext = ext.ToLower();
                    string[] supported = { "mp4", "avi", "3gp", "mpeg4" };

                    if (!supported.Contains(ext))
                    {
                        throw new MediaException(20018, "Unsupported file format.");
                    }

                    string filePath = openFileDialog1.FileName;

                    textbox1.Text = openFileDialog1.SafeFileName;

                    if (_player != null)
                    {
                        _connector.Disconnect(_player.VideoChannel, _provider);
                        _connector.Disconnect(_player.AudioChannel, speaker);

                        _player.Stop();
                        speaker.Stop();
                    }

                    _player = new AVPlayer(filePath, speaker.ReceiveFormats, speaker.ConverterType);
                    _connector.Connect(_player.VideoChannel, _provider);
                    _connector.Connect(_player.AudioChannel, speaker);
                    videoViewerWF1.SetImageProvider(_provider);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                _player.Pause();
                speaker.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try {
                _player.Start();
                speaker.Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
