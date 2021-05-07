using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace StowMarines_Interface
{
    public partial class FinanceForm : Form
    {
        NetworkCredential credentials = new NetworkCredential("StowMarinesInterfaceUser", "");

        public FinanceForm()
        {
            InitializeComponent();
        }

        private void FinanceForm_Load(object sender, EventArgs e)
        {
            teamBox.Items.Add(" ");
            teamBox.Items.Add("StowMarines");
            teamBox.Items.Add("Apollo");
            teamBox.Items.Add("Ares");
            teamBox.Items.Add("Aura");
            teamBox.Items.Add("Athena");
            teamBox.Items.Add("Artemis");
            teamBox.Items.Add("Kratos");
            teamBox.Items.Add("Helios");

            changeBox.Items.Add(" ");
            changeBox.Items.Add("Add");
            changeBox.Items.Add("Subtract");

            teamFinanceGrid.Rows.Add("StowMarines", GetTeamBalance("StowMarines"));
            teamFinanceGrid.Rows.Add("Apollo", GetTeamBalance("Apollo"));
            teamFinanceGrid.Rows.Add("Ares", GetTeamBalance("Ares"));
            teamFinanceGrid.Rows.Add("Aura", GetTeamBalance("Aura"));
            teamFinanceGrid.Rows.Add("Athena", GetTeamBalance("Athena"));
            teamFinanceGrid.Rows.Add("Artemis", GetTeamBalance("Artemis"));
            teamFinanceGrid.Rows.Add("Kratos", GetTeamBalance("Kratos"));
            teamFinanceGrid.Rows.Add("Helios", GetTeamBalance("Helios"));
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 form = new Form2();
            form.Closed += (s, args) => this.Close();
            form.Show();
        }

        private long GetTeamBalance(string teamName)
        {
            WebClient balRqst = new WebClient();
            string url1 = "ftp://188.165.239.165/finance/" + teamName + ".txt";
            balRqst.Credentials = credentials;
            string bal = Encoding.UTF8.GetString(balRqst.DownloadData(url1));
            return Int64.Parse(bal);
        }

        private void submitChangeButton_Click(object sender, EventArgs e)
        {
            string team = teamBox.Text;
            long amount = Int64.Parse(amountUpDown.Text);
            if (changeBox.Text == "Subtract")
                amount *= -1;
            
            long currentAmount = GetTeamBalance(team);
            long totAmount = currentAmount += amount;

            string tempFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StowMarines_Interface\\temp");

            Directory.CreateDirectory(tempFolder);
            File.WriteAllText(tempFolder + "\\" + team + ".txt", totAmount.ToString());

            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://188.165.239.165/finance/" + team + ".txt");
                request.Credentials = credentials;
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    MessageBox.Show(response.StatusDescription);
                }

                WebClient myWebClient = new WebClient();
                myWebClient.UploadFile("ftp://188.165.239.165/finance/" + team + ".txt", tempFolder + "\\" + team + ".txt");
            }
            catch
            {
                MessageBox.Show("error");
            }


        }

        private void upFile(string team)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://188.165.239.165/finance/" + team + ".txt");
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = credentials;

            // Copy the contents of the file to the request stream.
            byte[] fileContents;
            using (StreamReader sourceStream = new StreamReader("testfile.txt"))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }
    }
}
