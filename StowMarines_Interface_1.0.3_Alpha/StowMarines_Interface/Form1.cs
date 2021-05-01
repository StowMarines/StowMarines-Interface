using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace StowMarines_Interface
{
    public partial class Form1 : Form
    {
        string armaDir;
        string modDir;
        string installDir;
        string serverModPath = "ftp://188.165.239.165/mods/";
        NetworkCredential credentials = new NetworkCredential("StowMarinesInterfaceUser", "");
        string dataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "StowMarines_Interface");
        int timesRan = 0;
        List<string> modsToUpdate = new List<string>();
        bool missionMakerMode = false;
        bool optionalMods = true;

        // UI //

        public Form1()
        {
            InitializeComponent();
        }

        delegate void SetTextCallback(Button b);

        private async void Form1_Load(object sender, EventArgs e)
        {
            // UI Changes
            TransparentBG(titleLabel);
            TransparentBG(downloadSpeedLabel);
            TransparentBG(scanningFileLabel);
            TransparentBG(modNoLabel);
            TransparentBG(modInfoLabel);
            TransparentBG(a3DirLabel);
            TransparentBG(customModDirLabel);

            progressBar1.Visible = false;
            modInfoLabel.Visible = false;
            modNoLabel.Visible = false;
            progressBar2.Visible = false;
            scanningFileLabel.Visible = false;
            downloadSpeedLabel.Visible = false;

            progressBar1.Minimum = 0;
            progressBar2.Minimum = 0;

            // Get data

            if (!Directory.Exists(dataFolder))
            {
                await Task.Run(() => CreateUserData(true));
            }
            else if (!File.Exists(dataFolder + "//" + "userData.txt"))
            {
                await Task.Run(() => CreateUserData(false));
            }
            else
            {
                GetUserData();
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            if (armaDir == null)
            {
                MessageBox.Show("Please set your Arma 3 Directory", "Arma Directory is not set!");
                _ = Invoke(new Action(() =>
                {
                    SetArmaDir();
                }));
            }
            else if (!File.Exists(armaDir + "\\" + "arma3battleye.exe"))
            {
                MessageBox.Show("Incorrect Arma 3 Directory, please set the correct Arma 3 Directory", "Arma Directory is incorrect!");
                _ = Invoke(new Action(() =>
                {
                    SetArmaDir();
                }));
            }
            else
            {
                LaunchArma();
            }
        }

        private async void checkForUpdatesButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() => CheckDirs());
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void armaDirButton_Click(object sender, EventArgs e)
        {
            SetArmaDir();
        }

        private void modDirButton_Click(object sender, EventArgs e)
        {
            SetModDir(true);
        }

        private void clearModDirButton_Click(object sender, EventArgs e)
        {
            SetModDir(false);
        }

        private  void noSplashBox_CheckedChanged(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
            if (noSplashBox.Checked)
            {
                arrLine[2] = "true";
            }
            else
            {
                arrLine[2] = "false";
            }
            File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
        }

        private  void noPauseBox_CheckedChanged(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
            if (noPauseBox.Checked)
            {    
                arrLine[3] = "true";
            }
            else
            {
                arrLine[3] = "false";
            }
            File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
        }

        private void hugePagesBox_CheckedChanged(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
            if (hugePagesBox.Checked)
            { 
                arrLine[4] = "true";
            }
            else
            {
                arrLine[4] = "false";
            }
            File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
        }

        private void profileBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
            arrLine[5] = profileBox.Text;
            File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (launchParContainer.Visible == true)
                launchParContainer.Visible = false;
            else
                launchParContainer.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendarForm form = new CalendarForm();
            form.Show();
        }

        private void stopButton_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void optionalModsBox_CheckedChanged(object sender, EventArgs e) 
        {
            string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
            if (optionalModsBox.Checked)
            {
                arrLine[6] = "true";
                optionalMods = true;
            }
            else
            {
                arrLine[6] = "false";
                optionalMods = false;
            }
            File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
        }

        private void mmmBox_CheckedChanged(object sender, EventArgs e)
        {
            string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
            if (mmmBox.Checked)
            {
                arrLine[7] = "true";
                missionMakerMode = true;
            }
            else
            {
                arrLine[7] = "false";
                missionMakerMode = false;
            }
            File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
        }


        // CHECK FOR UPDATE //

        public async Task CheckForUpdates()
        {
            try
            {
                _ = Invoke(new Action(() =>
                {
                    checkForUpdatesButton.Enabled = false;
                    startGameButton.Enabled = false;
                    if (timesRan >= 1)
                        stopButton.Visible = true;
                }));

                //Get mod names
                WebClient modsRequest = new WebClient();
                string url1 = "ftp://188.165.239.165/" + "modNames.txt";
                modsRequest.Credentials = credentials;
                string modString = System.Text.Encoding.UTF8.GetString(modsRequest.DownloadData(url1));
                string[] mods = modString.Split('\n');

                //Get mod sizes
                WebClient sizeRequest = new WebClient();
                string url2 = "ftp://188.165.239.165/" + "modSizes.txt";
                sizeRequest.Credentials = credentials;
                string sizeString = System.Text.Encoding.UTF8.GetString(modsRequest.DownloadData(url2));
                string[] sizes = sizeString.Split('\n');

                modsRequest.Dispose();
                sizeRequest.Dispose();

                if (modDir != "null")
                    installDir = modDir;
                else
                    installDir = armaDir;

                _ = Invoke(new Action(() =>
                {
                    progressBar1.Value = 1;
                    progressBar1.Maximum = mods.Count() - 1;
                    progressBar2.Value = 1;
                    modInfoLabel.Visible = true;
                    progressBar1.Visible = true;
                    modNoLabel.Visible = true;
                    progressBar2.Visible = true;
                    scanningFileLabel.Visible = true;
                }));

                int modNum = 0;
                float totUpSize = 0;

                foreach (string mod in mods)
                {
                    string path = $@"{installDir}\{mod}";
                    if (mod != " ")
                    {
                        _ = Invoke(new Action(() =>
                        {
                            progressBar1.Increment(1);
                            modInfoLabel.Text = $"Scanning {mod}";
                            modNoLabel.Text = $"Scanned {modNum + 1}/{mods.Count()} mods";
                        }));  

                        bool success = long.TryParse(sizes[modNum], out long serverSize);
                        if (success)
                        {
                            if (Directory.Exists(path))
                            {
                                //Client has the mod
                                var dirInfo = new DirectoryInfo(path);
                                long size = 0;
                                var cFiles = dirInfo.GetFiles("*", SearchOption.AllDirectories);
                                _ = Invoke(new Action(() =>
                                {
                                    progressBar2.Maximum = dirInfo.GetFiles("*", SearchOption.AllDirectories).Count();
                                }));

                                //Client mod size
                                foreach (FileInfo file in cFiles)
                                {
                                    size += file.Length;
                                    _ = Invoke(new Action(() =>
                                    {
                                        progressBar2.Increment(1);
                                        scanningFileLabel.Text = file.ToString();
                                    }));
                                }

                                if (serverSize > size)
                                {
                                    //Data needs to be added
                                    totUpSize += serverSize - size;
                                    modsToUpdate.Add(mod);
                                }
                                else if (serverSize < size)
                                {
                                    //Data needs to be removed
                                    totUpSize += serverSize - size;
                                    modsToUpdate.Add(mod);
                                }
                            }
                            else
                            {
                                //The client doesn't have the mod, add it to the update list
                                modsToUpdate.Add(mod);
                                if (serverSize.ToString() != "")
                                    totUpSize += serverSize;
                            }
                            modNum += 1;
                        }
                    }
                }
                _ = Invoke(new Action(() =>
                {
                    progressBar1.Value = 1;
                    progressBar2.Value = 1;
                    modInfoLabel.Visible = false;
                    progressBar1.Visible = false;
                    modNoLabel.Visible = false;
                    progressBar2.Visible = false;
                    scanningFileLabel.Visible = false;
                }));
                if (modsToUpdate.Count() >= 1)
                {
                    modsToUpdate = modsToUpdate.Select(t => t.Trim()).ToList();
                    string sizeType = "Error";

                    if (totUpSize >= -1023 && totUpSize <= 1023)
                    {
                        sizeType = "Bytes";
                    }
                    else if (totUpSize >= -1048575 && totUpSize <= 1048575)
                    {
                        totUpSize /= 1024;
                        sizeType = "KB";
                    }
                    else if (totUpSize >= -1073741823 && totUpSize <= 1073741823)
                    {
                        totUpSize /= 1048576;
                        sizeType = "MB";
                    }
                    else if (totUpSize >= -9.3132257e-10)
                    {
                        totUpSize /= 1073741824;
                        sizeType = "GB";
                    }
                    await Task.Run(() => ModsNeedUpdating(modsToUpdate, Math.Round(totUpSize, 2).ToString() + sizeType));
                }
                else if (timesRan > 1)
                {
                    MessageBox.Show("Mods are up to date!", "Up to date");
                    _ = Invoke(new Action(() =>
                    {
                        checkForUpdatesButton.Enabled = true;
                        startGameButton.Enabled = true;
                        stopButton.Visible = false;
                    }));
                }
                else
                {
                    _ = Invoke(new Action(() =>
                    {
                        checkForUpdatesButton.Enabled = true;
                        startGameButton.Enabled = true;
                        stopButton.Visible = false;
                    }));
                }
            }
            catch (WebException d)
            {
                MessageBox.Show($"Something went wrong whilst checking for updates {d.Message}");
                _ = Invoke(new Action(() =>
                {
                    progressBar1.Value = 1;
                    progressBar2.Value = 1;
                    modInfoLabel.Visible = false;
                    progressBar1.Visible = false;
                    modNoLabel.Visible = false;
                    progressBar2.Visible = false;
                    scanningFileLabel.Visible = false;
                }));
            }
            timesRan += 1;
        }


        // DOWNLOAD //

        private async void ModsNeedUpdating(List<string> modsToUpdate, string totUpSize)
        {
            if (timesRan < 2)
                System.Threading.Thread.Sleep(1000);
            DialogResult result = MessageBox.Show($"Your mods need updating, would you like to update them now?\n\nSize of update: {totUpSize}", "Mods need updating!", 
                MessageBoxButtons.YesNo, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            if (result == DialogResult.Yes)
            {
                _ = Invoke(new Action(() =>
                {
                    progressBar1.Value = 0;
                    progressBar1.Maximum = modsToUpdate.Count();
                    progressBar2.Value = 0;
                    modInfoLabel.Visible = true;
                    progressBar1.Visible = true;
                    modNoLabel.Visible = true;
                    progressBar2.Visible = true;
                    scanningFileLabel.Visible = true;
                    checkForUpdatesButton.Enabled = false;
                    startGameButton.Enabled = false;
                    stopButton.Visible = true;
                }));
                int modNum = 0;
                int totModNo = modsToUpdate.Count();

                foreach (string mod in modsToUpdate)
                {
                    _ = Invoke(new Action(() =>
                    {
                        progressBar1.Increment(1);
                        modInfoLabel.Text = $"Downloading {mod}";
                        modNoLabel.Text = $"Downloaded {modNum + 1}/{modsToUpdate.Count()}";
                    }));

                    await Task.Run(() => UpdateMod(mod));
                    modNum += 1;

                    if (modNum == totModNo)
                    {
                        MessageBox.Show("Finished Downloading", "Finished downloading");
                        _ = Invoke(new Action(() =>
                        {
                            progressBar1.Value = 0;
                            progressBar2.Value = 0;
                            modInfoLabel.Visible = false;
                            progressBar1.Visible = false;
                            modNoLabel.Visible = false;
                            progressBar2.Visible = false;
                            scanningFileLabel.Visible = false;
                            checkForUpdatesButton.Enabled = true;
                            startGameButton.Enabled = true;
                            stopButton.Visible = false;
                        }));
                    }
                }
            }
            else
            {
                _ = Invoke(new Action(() =>
                {
                    checkForUpdatesButton.Enabled = true;
                    startGameButton.Enabled = true;
                    stopButton.Visible = false;
                }));
            }
        }

        private async Task UpdateMod(string modName)
        {
            List<string> files = await Task.Run(() => DirFiles(serverModPath + modName));

            List<string> sFiles = new List<string>();
            foreach (string f in files)
            {
                if (!f.Contains('.'))
                {
                    List<string> l = await Task.Run(() => DirFiles(serverModPath + f));
                    foreach (string s in l)
                    {
                        sFiles.Add(modName + "\\" + s.Replace('/', '\\'));
                    }
                }
                else
                    sFiles.Add(f.Replace('/', '\\'));
            }

            if (Directory.Exists($@"{installDir}\{modName}"))
            {
                string[] clientFiles = Directory.GetFiles($@"{installDir}\{modName}", "*.*", SearchOption.AllDirectories);

                if (File.Exists($@"{installDir}\{modName}\LICENSE"))
                    File.Delete($@"{installDir}\{modName}\LICENSE");

                if (File.Exists($@"{installDir}\{modName}\43042cb645e567cf555faac5f9a6278e"))
                    File.Delete($@"{installDir}\{modName}\43042cb645e567cf555faac5f9a6278e");

                foreach (string fi in clientFiles)
                {
                    if (fi.Contains('.'))
                    {
                        int pos = Array.IndexOf(sFiles.ToArray(), fi.Substring(fi.LastIndexOf('@')));
                        if (pos == -1 && File.Exists(fi))
                        {
                            File.Delete(fi);
                        }
                    }
                    else //DOESN'T WORK
                    {
                        int pos = Array.IndexOf(sFiles.ToArray(), fi.Substring(fi.LastIndexOf('@')));
                        if (pos == -1 && Directory.Exists(fi))
                        {
                            Directory.Delete(fi);
                        }
                    }       
                }
            }

            int totFileNo = files.Count;
            int fileNo = 0;

            _ = Invoke(new Action(() =>
            {
                progressBar2.Maximum = totFileNo;
            }));

            Parallel.ForEach(files, file =>
           {
               fileNo += 1;

               _ = Invoke(new Action(() =>
               {
                   scanningFileLabel.Text = $"{file}";
               }));

               totFileNo -= 1;
               string path = $@"{installDir}\{modName}";

               if (!Directory.Exists(path))
               {
                   DirectoryInfo di = Directory.CreateDirectory(path);
               }
               if (file.Contains("."))
               {
                   string clientPath = $@"{path}\{file.Substring(file.LastIndexOf("/") + 1)}";
                   if (File.Exists(clientPath))
                   {
                       long serverFileSize = ServerFileSize($@"{serverModPath}{modName}/{file.Substring(file.LastIndexOf("/") + 1)}");
                       long clientFileSize = new FileInfo(clientPath).Length;
                       if (serverFileSize != clientFileSize)
                           DownloadFile(file, clientPath);
                   }
                   else
                       DownloadFile(file, clientPath);
               }
               else
               {
                   string subDir = file;
                   List<string> subFiles = DirFiles($@"{serverModPath}/{subDir}");

                   Parallel.ForEach(subFiles, subFile =>
                  {
                      string clientSubDirPath = $@"{installDir}\{modName}\{subDir.Substring(subDir.IndexOf('/') + 1)}";
                      string clientSubFilePath = $@"{clientSubDirPath}\{subFile.Substring(subFile.IndexOf('/') + 1)}";

                      if (!Directory.Exists(clientSubDirPath))
                      {
                          DirectoryInfo di = Directory.CreateDirectory(clientSubDirPath);
                      }

                      if (subFile.Contains("."))
                      {
                          if (File.Exists(clientSubFilePath))
                          {
                              long serverFileSize = ServerFileSize($@"{serverModPath}{modName}/{subDir.Substring(subDir.IndexOf('/') + 1)}/{subFile.Substring(subFile.LastIndexOf("/") + 1)}");
                              long clientFileSize = new FileInfo(clientSubFilePath).Length;
                              if (serverFileSize != clientFileSize)
                              {
                                  _ = Invoke(new Action(() =>
                                  {
                                      progressBar2.Increment(1);
                                      scanningFileLabel.Text = $"{clientSubFilePath}";
                                  }));
                                  DownloadFile($@"{modName}/{subFile}", clientSubFilePath);
                              }
                          }
                          else
                          {
                              _ = Invoke(new Action(() =>
                              {
                                  scanningFileLabel.Text = $"{clientSubFilePath}";
                              }));
                              DownloadFile($@"{modName}/{subFile}", clientSubFilePath);
                          }
                      }
                      else //Is a Tertiary folder
                      {
                          if (!Directory.Exists(clientSubFilePath)) //Create Tertiary Folder
                          {
                              DirectoryInfo di = Directory.CreateDirectory(clientSubFilePath);
                          }

                          List<string> tertFiles = DirFiles($@"{serverModPath}/{modName}/{subFile}"); //subFile = tertDir

                          Parallel.ForEach(tertFiles, tertFile =>
                          {
                              string clientTertFilePath = $@"{installDir}\{modName}\{subFile}\{tertFile.Substring(tertFile.IndexOf('/') + 1)}";

                              if (tertFile.Contains("."))
                              {
                                  if (File.Exists(clientTertFilePath))
                                  {
                                      long serverFileSize = ServerFileSize($@"{serverModPath}{subDir}/{tertFile}");
                                      long clientFileSize = new FileInfo(clientTertFilePath).Length;
                                      if (serverFileSize != clientFileSize)
                                      {
                                          DownloadFile($@"{modName}/{subFile}/{tertFile.Substring(tertFile.IndexOf('/') + 1)}", clientTertFilePath);
                                      }
                                  }
                                  else
                                  {
                                      DownloadFile($@"{modName}/{subFile}/{tertFile.Substring(tertFile.IndexOf('/') + 1)} ", clientTertFilePath);
                                  }
                              }
                          });
                      }
                  });
               }
               _ = Invoke(new Action(() =>
               {
                   progressBar2.Increment(1);
               }));
           });

            if (totFileNo == 0)
            {
                _ = Invoke(new Action(() =>
                {
                    progressBar2.Value = 1;
                }));
            }
        }


        // FUNCTIONS //

        private float DownloadFile(string serverModDir, string downloadPath)
        {
            try
            {
                float totalSize = 0;
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverModPath + serverModDir);
                ServicePoint sp = request.ServicePoint;
                sp.ConnectionLimit = 10;
                request.Credentials = credentials;
                request.Timeout = -1;
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();

                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(downloadPath))
                {
                    ftpStream.CopyTo(fileStream);
                    totalSize += fileStream.Length;
                }
                return totalSize;
            }
            catch
            {
                MessageBox.Show($"Something went wrong whilst downloading {serverModDir} {downloadPath}");
                return 0;
            }
        }

        private List<string> DirFiles(string serverDir)
        {
            try
            {
                FtpWebRequest newRequest = (FtpWebRequest)WebRequest.Create(serverDir);
                ServicePoint sp = newRequest.ServicePoint;
                sp.ConnectionLimit = 10;
                newRequest.Credentials = credentials;
                newRequest.KeepAlive = false;
                newRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)newRequest.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);

                string item;
                List<string> itemsInDir = new List<string>();

                while ((item = reader.ReadLine()) != null)
                {
                    if (item.Contains("."))
                    {
                        itemsInDir.Add(item);
                    }
                    else
                    {
                        //Add support for sub sub dirs
                        itemsInDir.Add(item);
                    }
                }
                newRequest.Abort();
                return itemsInDir;
            }
            catch
            {
                MessageBox.Show("Failed to retrieve directory " + serverDir);
                return null;
            }
        }

        private long ServerFileSize(string serverDir)
        {
            try
            {                
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverDir);
                ServicePoint sp = request.ServicePoint;
                sp.ConnectionLimit = 10;
                request.Credentials = credentials;
                request.Timeout = -1;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Method = WebRequestMethods.Ftp.GetFileSize;
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                long size = response.ContentLength;
                response.Close();
                request.Abort();

                return size;
            }
            catch (WebException e)
            {
                MessageBox.Show($"Something went wrong whilst getting the Server File Size {e.Message}");

                return 0;
            }
        }
                                    
        private async void CheckDirs()
        {
            if (armaDir == "null")
            {
                MessageBox.Show("Please set your Arma 3 Directory", "Arma Directory is not set!");
                _ = Invoke(new Action(() =>
                {
                    SetArmaDir();
                }));
            }
            else if (!File.Exists(armaDir + "\\" + "arma3battleye.exe"))
            {
                MessageBox.Show("Incorrect Arma 3 Directory, please set the correct Arma 3 Directory", "Arma Directory is incorrect!");
                _ = Invoke(new Action(() =>
                {
                    SetArmaDir();
                }));
            }
            else
            {
                _ = Invoke(new Action(() =>
                {
                    checkForUpdatesButton.Enabled = false;
                }));
                await Task.Run(() => CheckForUpdates());
            }
        }

        private void CreateUserData(bool createFolder)
        {
            if (createFolder)
            {
                Directory.CreateDirectory(dataFolder);
            }

            string[] lines =
            {
            "null", "null", "false", "false", "false", "Default", "true", "false"
            };

            if (!File.Exists(dataFolder + "//userData.txt"))
            {
                FileStream str = File.Create(dataFolder + "//userData.txt");
                str.Close();
            }

            File.WriteAllLines(dataFolder + "//userData.txt", lines);
            CheckDirs();
        }

        private async void GetUserData()
        {
            string[] lines = File.ReadAllLines(dataFolder + "//userData.txt");

            armaDir = lines[0];
            armaDirTextBox.Text = armaDir;

            modDir = lines[1];
            modDirTextBox.Text = modDir;
            if (modDir == "null")
                modDirTextBox.Text = "Same as above";

            if (lines[2] == "true")
                noSplashBox.Checked = true;

            if (lines[3] == "true")
                noPauseBox.Checked = true;

            if (lines[4] == "true")
                hugePagesBox.Checked = true;

            profileBox.Items.Add("Default");
            profileBox.Text = profileBox.Items[0].ToString();

            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + "Arma 3 - Other Profiles";
            string[] profiles = Directory.GetDirectories(path);

            foreach (string profile in profiles)
            {
                if (profile.Contains(lines[5]))
                    profileBox.SelectedIndex = profileBox.Items.Add(profile.Split('\\').Last());
                else
                    profileBox.Items.Add(profile.Split('\\').Last());
            }

            if (lines[6] == "false")
                optionalModsBox.Checked = false;

            if (lines[7] == "true")
                mmmBox.Checked = true;

            await Task.Run(() => CheckDirs());
        }

        private void SetArmaDir()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = false;

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                armaDirTextBox.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
                armaDir = folderDlg.SelectedPath;
                string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
                arrLine[0] = armaDir;
                File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
            }
        }

        private void SetModDir(bool state)  
        {
            if (state)
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();
                folderDlg.ShowNewFolderButton = false;

                DialogResult result = folderDlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    modDirTextBox.Text = folderDlg.SelectedPath;
                    Environment.SpecialFolder root = folderDlg.RootFolder;
                    modDir = @folderDlg.SelectedPath;
                    string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
                    arrLine[1] = modDir;
                    File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
                }
            }
            else
            {
                modDirTextBox.Text = "Same as above";
                modDir = "null";
                string[] arrLine = File.ReadAllLines(dataFolder + "//userData.txt");
                arrLine[1] = modDir;
                File.WriteAllLines(dataFolder + "//userData.txt", arrLine);
            }
            Application.Restart();
            Environment.Exit(0);
        }

        public void LaunchArma()
        {
            try
            {
                WebClient launchRequest = new WebClient();
                string url1 = "ftp://188.165.239.165/" + "launchPars.txt";
                launchRequest.Credentials = credentials;
                string[] mods = System.Text.Encoding.UTF8.GetString(launchRequest.DownloadData(url1)).Split(';');

                List<string> modSet = new List<string>();

                int i = 0;
                foreach (string mod in mods)
                {
                    if (modDirTextBox.Text != "Same as above" && mod != "")
                        if (i >= 1)
                            modSet.Add(mod.Insert(0, $";{modDir}\\"));
                        else
                            modSet.Add(mod.Insert(0, $"{modDir}\\"));
                    else if (modDirTextBox.Text == "Same as above" && mod != "")
                        if (i >= 1)
                            modSet.Add(mod.Insert(0, ";"));
                        else
                            modSet.Add(mod);

                    i += 1;
                }



                string launchPars = "";

                if (noSplashBox.Checked)
                    launchPars += " -nosplash";

                if (noPauseBox.Checked)
                    launchPars += " -noPause";

                if (hugePagesBox.Checked)
                    launchPars += " -hugepages";

                if (profileBox.Text != "Default")
                    launchPars += $@""" -name={profileBox.Text}""";

                if (missionMakerMode == false)
                    launchPars += " -connect=188.165.239.165 -port=2302 -password=Scones";

                if (optionalMods && missionMakerMode == false)
                {
                    WebClient optionalRequest = new WebClient();
                    string url2 = "ftp://188.165.239.165/" + "optionalMods.txt";
                    launchRequest.Credentials = credentials;
                    string[] opMods = System.Text.Encoding.UTF8.GetString(launchRequest.DownloadData(url2)).Split(';');

                    foreach (string oMod in opMods)
                    {
                        if (modDirTextBox.Text != "Same as above" && oMod != "")
                            if (i >= 1)
                                modSet.Add(oMod.Insert(0, $";{modDir}\\"));
                            else
                                modSet.Add(oMod.Insert(0, $"{modDir}\\"));
                        else if (modDirTextBox.Text == "Same as above" && oMod != "")
                            if (i >= 1)
                                modSet.Add(oMod.Insert(0, ";"));
                            else
                                modSet.Add(oMod);

                        i += 1;
                    }
                }

                string modArgs = $@"{string.Join("", modSet)}";

                System.Diagnostics.Process.Start($"{armaDir}\\arma3battleye.exe", $@"{launchPars}" + $@" -mod=""{modArgs};""");
                using (StreamWriter sw = File.CreateText($@"{dataFolder}\log.txt"))
                {
                    sw.WriteLine($"*** StowMarines Interface Log | Version:{versionLabel.Text} ***");
                    sw.WriteLine($"\n\nBoot line: {armaDir}\\arma3battleye.exe {launchPars} -mod={modArgs}");
                    sw.WriteLine($"\n\nMods that need updating: {string.Join(", ", modsToUpdate)}");
                }
                this.Close();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    MessageBox.Show("Something went wrong");
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

    }
}

// 0 = armaDir //
// 1 = modDir //
// 2 = -noSplash //
// 3 = -noPause //
// 4 = -hugePages //
// 5 = -name=ProfileName //
// 6 = Optional Mods //
// 7 = Mission Maker Mode //