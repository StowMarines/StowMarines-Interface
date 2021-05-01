using System;
using System.Net;
using System.Windows.Forms;

namespace StowMarines_Interface
{
    public partial class CalendarForm : Form
    {

        NetworkCredential credentials = new NetworkCredential("StowMarinesInterfaceUser", "");

        public CalendarForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = monthCalendar1.SelectionRange.Start.ToString();
            date = date.ToString().Substring(0, date.LastIndexOf(" ")).Replace("/", "");
            getEvents(date);
        }

        private void getEvents(string date)
        {
            try
            {
                WebClient dateRequest = new WebClient();
                string url1 = "ftp://188.165.239.165/calendar/" + date + ".txt";
                dateRequest.Credentials = credentials;
                string eventsString = System.Text.Encoding.UTF8.GetString(dateRequest.DownloadData(url1));
                dateRequest.Dispose();

                if (eventsString != "")
                    MessageBox.Show($"Events for {date}: {eventsString}");
                else
                    MessageBox.Show("No events scheduled");
               
            }
            catch
            {
                MessageBox.Show("No such file");
                MessageBox.Show($"{date}");
            }
        }
    }
}
