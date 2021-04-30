using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerSide_StowMarines_Interface
{
    public partial class Form1 : Form
    {
        //C:\Users\razma\Desktop\SS_SMI_Test\
        //C:\Users\Administrator\Desktop\StowMarines Interface\
        string path = @"C:\Users\Administrator\Desktop\StowMarines Interface\";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Task.Run(() => GetModNames());
        }

        private async void GetModNames()
        {
            List<string> mods = new List<string>();

            foreach (string s in Directory.GetDirectories(path + "mods"))
            {
                mods.Add(s.Remove(0, (path + "mods").Length + 1));
            }

            File.WriteAllLines(path + "modNames.txt", mods);
            await Task.Run(() => GetModSizes(mods));
        }

        private async void GetModSizes(List<string> mods)
        {
            List<string> sizes = new List<string>();

            foreach (string mod in mods)
            {
                var dirInfo = new DirectoryInfo(path + "mods\\" + mod);
                long size = 0;
                foreach (FileInfo file in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    size += file.Length;
                }
                sizes.Add(size.ToString());
            }

            await Task.Run(() => File.WriteAllLines(path + "modSizes.txt", sizes));
        }
    }
}
