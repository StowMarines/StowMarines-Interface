using System;
using System.Text;
using System.Net;
using System.Windows.Forms;

namespace StowMarines_Interface
{
    public partial class Form2 : Form
    {
        string usr;
        string psw;
        NetworkCredential credentials = new NetworkCredential("StowMarinesInterfaceUser", "");

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            TransparentBG(titleLabel);
        }

        private void testButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            usr = usrNamBox.Text;
            psw = pswBox.Text;

            string usrFileLoc = "ftp://188.165.239.165/userProfiles/" + usr + ".txt";

            var request = (FtpWebRequest)WebRequest.Create(usrFileLoc);
            request.Credentials = credentials;
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                request.Abort();
                response.Close();

                WebClient loginRqst = new WebClient();
                loginRqst.Credentials = credentials;
                string[] data = Encoding.UTF8.GetString(loginRqst.DownloadData(usrFileLoc)).Split('\n');
                if (data[0] == psw)
                {
                    loginBox.Visible = false;
                    financeButton.Visible = true;
                }    
                else
                    MessageBox.Show("Incorrect password");
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    MessageBox.Show("This account does not exist.\n\nIf you think this is incorrect, please let us know in #general-support on Discord.", "Does not exist");
                }
            }
        }

        void TransparentBG(Control C)
        {
            C.Visible = false;

            C.Refresh();
            Application.DoEvents();

            System.Drawing.Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;
            int Right = screenRectangle.Left - this.Left;

            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));
            System.Drawing.Bitmap bmpImage = new System.Drawing.Bitmap(bmp);
            bmp = bmpImage.Clone(new System.Drawing.Rectangle(C.Location.X + Right, C.Location.Y + titleHeight, C.Width, C.Height), bmpImage.PixelFormat);
            C.BackgroundImage = bmp;

            C.Visible = true;
        }

        private void financeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            FinanceForm form = new FinanceForm();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }
    }
}
