
namespace StowMarines_Interface
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.checkForUpdatesButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.startGameButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.modInfoLabel = new System.Windows.Forms.Label();
            this.noSplashBox = new System.Windows.Forms.CheckBox();
            this.launchParContainer = new System.Windows.Forms.GroupBox();
            this.profileBox = new System.Windows.Forms.ComboBox();
            this.hugePagesBox = new System.Windows.Forms.CheckBox();
            this.noPauseBox = new System.Windows.Forms.CheckBox();
            this.modNoLabel = new System.Windows.Forms.Label();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.scanningFileLabel = new System.Windows.Forms.Label();
            this.a3DirLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.armaDirButton = new System.Windows.Forms.Button();
            this.armaDirTextBox = new System.Windows.Forms.TextBox();
            this.downloadSpeedLabel = new System.Windows.Forms.Label();
            this.modDirButton = new System.Windows.Forms.Button();
            this.customModDirLabel = new System.Windows.Forms.Label();
            this.modDirTextBox = new System.Windows.Forms.TextBox();
            this.clearModDirButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.optionalModsBox = new System.Windows.Forms.CheckBox();
            this.mmmBox = new System.Windows.Forms.CheckBox();
            this.launchParContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkForUpdatesButton
            // 
            resources.ApplyResources(this.checkForUpdatesButton, "checkForUpdatesButton");
            this.checkForUpdatesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkForUpdatesButton.Name = "checkForUpdatesButton";
            this.checkForUpdatesButton.UseVisualStyleBackColor = true;
            this.checkForUpdatesButton.Click += new System.EventHandler(this.checkForUpdatesButton_Click);
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Name = "titleLabel";
            // 
            // startGameButton
            // 
            resources.ApplyResources(this.startGameButton, "startGameButton");
            this.startGameButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // exitButton
            // 
            resources.ApplyResources(this.exitButton, "exitButton");
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitButton.Name = "exitButton";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click_1);
            // 
            // progressBar1
            // 
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // modInfoLabel
            // 
            resources.ApplyResources(this.modInfoLabel, "modInfoLabel");
            this.modInfoLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.modInfoLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.modInfoLabel.Name = "modInfoLabel";
            // 
            // noSplashBox
            // 
            resources.ApplyResources(this.noSplashBox, "noSplashBox");
            this.noSplashBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.noSplashBox.Name = "noSplashBox";
            this.toolTip1.SetToolTip(this.noSplashBox, resources.GetString("noSplashBox.ToolTip"));
            this.noSplashBox.UseVisualStyleBackColor = true;
            this.noSplashBox.CheckedChanged += new System.EventHandler(this.noSplashBox_CheckedChanged);
            // 
            // launchParContainer
            // 
            this.launchParContainer.BackColor = System.Drawing.Color.Gray;
            this.launchParContainer.Controls.Add(this.mmmBox);
            this.launchParContainer.Controls.Add(this.optionalModsBox);
            this.launchParContainer.Controls.Add(this.profileBox);
            this.launchParContainer.Controls.Add(this.hugePagesBox);
            this.launchParContainer.Controls.Add(this.noPauseBox);
            this.launchParContainer.Controls.Add(this.noSplashBox);
            resources.ApplyResources(this.launchParContainer, "launchParContainer");
            this.launchParContainer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.launchParContainer.Name = "launchParContainer";
            this.launchParContainer.TabStop = false;
            // 
            // profileBox
            // 
            this.profileBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.profileBox, "profileBox");
            this.profileBox.FormattingEnabled = true;
            this.profileBox.Name = "profileBox";
            this.toolTip1.SetToolTip(this.profileBox, resources.GetString("profileBox.ToolTip"));
            this.profileBox.SelectedIndexChanged += new System.EventHandler(this.profileBox_SelectedIndexChanged_1);
            // 
            // hugePagesBox
            // 
            resources.ApplyResources(this.hugePagesBox, "hugePagesBox");
            this.hugePagesBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.hugePagesBox.Name = "hugePagesBox";
            this.toolTip1.SetToolTip(this.hugePagesBox, resources.GetString("hugePagesBox.ToolTip"));
            this.hugePagesBox.UseVisualStyleBackColor = true;
            this.hugePagesBox.CheckedChanged += new System.EventHandler(this.hugePagesBox_CheckedChanged);
            // 
            // noPauseBox
            // 
            resources.ApplyResources(this.noPauseBox, "noPauseBox");
            this.noPauseBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.noPauseBox.Name = "noPauseBox";
            this.toolTip1.SetToolTip(this.noPauseBox, resources.GetString("noPauseBox.ToolTip"));
            this.noPauseBox.UseVisualStyleBackColor = true;
            this.noPauseBox.CheckedChanged += new System.EventHandler(this.noPauseBox_CheckedChanged);
            // 
            // modNoLabel
            // 
            resources.ApplyResources(this.modNoLabel, "modNoLabel");
            this.modNoLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.modNoLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.modNoLabel.Name = "modNoLabel";
            // 
            // progressBar2
            // 
            resources.ApplyResources(this.progressBar2, "progressBar2");
            this.progressBar2.Name = "progressBar2";
            // 
            // scanningFileLabel
            // 
            resources.ApplyResources(this.scanningFileLabel, "scanningFileLabel");
            this.scanningFileLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.scanningFileLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.scanningFileLabel.Name = "scanningFileLabel";
            // 
            // a3DirLabel
            // 
            resources.ApplyResources(this.a3DirLabel, "a3DirLabel");
            this.a3DirLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.a3DirLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.a3DirLabel.Name = "a3DirLabel";
            // 
            // armaDirButton
            // 
            this.armaDirButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.armaDirButton, "armaDirButton");
            this.armaDirButton.Name = "armaDirButton";
            this.toolTip1.SetToolTip(this.armaDirButton, resources.GetString("armaDirButton.ToolTip"));
            this.armaDirButton.UseVisualStyleBackColor = true;
            this.armaDirButton.Click += new System.EventHandler(this.armaDirButton_Click);
            // 
            // armaDirTextBox
            // 
            resources.ApplyResources(this.armaDirTextBox, "armaDirTextBox");
            this.armaDirTextBox.Name = "armaDirTextBox";
            this.armaDirTextBox.ReadOnly = true;
            // 
            // downloadSpeedLabel
            // 
            resources.ApplyResources(this.downloadSpeedLabel, "downloadSpeedLabel");
            this.downloadSpeedLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.downloadSpeedLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.downloadSpeedLabel.Name = "downloadSpeedLabel";
            // 
            // modDirButton
            // 
            this.modDirButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.modDirButton, "modDirButton");
            this.modDirButton.Name = "modDirButton";
            this.toolTip1.SetToolTip(this.modDirButton, resources.GetString("modDirButton.ToolTip"));
            this.modDirButton.UseVisualStyleBackColor = true;
            this.modDirButton.Click += new System.EventHandler(this.modDirButton_Click);
            // 
            // customModDirLabel
            // 
            resources.ApplyResources(this.customModDirLabel, "customModDirLabel");
            this.customModDirLabel.BackColor = System.Drawing.Color.LimeGreen;
            this.customModDirLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.customModDirLabel.Name = "customModDirLabel";
            // 
            // modDirTextBox
            // 
            resources.ApplyResources(this.modDirTextBox, "modDirTextBox");
            this.modDirTextBox.Name = "modDirTextBox";
            this.modDirTextBox.ReadOnly = true;
            // 
            // clearModDirButton
            // 
            this.clearModDirButton.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.clearModDirButton, "clearModDirButton");
            this.clearModDirButton.Name = "clearModDirButton";
            this.toolTip1.SetToolTip(this.clearModDirButton, resources.GetString("clearModDirButton.ToolTip"));
            this.clearModDirButton.UseVisualStyleBackColor = true;
            this.clearModDirButton.Click += new System.EventHandler(this.clearModDirButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stopButton
            // 
            resources.ApplyResources(this.stopButton, "stopButton");
            this.stopButton.BackColor = System.Drawing.Color.Transparent;
            this.stopButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stopButton.Name = "stopButton";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click_1);
            // 
            // versionLabel
            // 
            resources.ApplyResources(this.versionLabel, "versionLabel");
            this.versionLabel.BackColor = System.Drawing.Color.DarkSlateGray;
            this.versionLabel.ForeColor = System.Drawing.Color.White;
            this.versionLabel.Name = "versionLabel";
            // 
            // optionalModsBox
            // 
            resources.ApplyResources(this.optionalModsBox, "optionalModsBox");
            this.optionalModsBox.Checked = true;
            this.optionalModsBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optionalModsBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.optionalModsBox.Name = "optionalModsBox";
            this.toolTip1.SetToolTip(this.optionalModsBox, resources.GetString("optionalModsBox.ToolTip"));
            this.optionalModsBox.UseVisualStyleBackColor = true;
            this.optionalModsBox.CheckedChanged += new System.EventHandler(this.optionalModsBox_CheckedChanged);
            // 
            // mmmBox
            // 
            resources.ApplyResources(this.mmmBox, "mmmBox");
            this.mmmBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.mmmBox.Name = "mmmBox";
            this.toolTip1.SetToolTip(this.mmmBox, resources.GetString("mmmBox.ToolTip"));
            this.mmmBox.UseVisualStyleBackColor = true;
            this.mmmBox.CheckedChanged += new System.EventHandler(this.mmmBox_CheckedChanged);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.clearModDirButton);
            this.Controls.Add(this.modDirButton);
            this.Controls.Add(this.customModDirLabel);
            this.Controls.Add(this.modDirTextBox);
            this.Controls.Add(this.downloadSpeedLabel);
            this.Controls.Add(this.armaDirButton);
            this.Controls.Add(this.a3DirLabel);
            this.Controls.Add(this.armaDirTextBox);
            this.Controls.Add(this.scanningFileLabel);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.modNoLabel);
            this.Controls.Add(this.launchParContainer);
            this.Controls.Add(this.modInfoLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.checkForUpdatesButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.TransparencyKey = System.Drawing.Color.LimeGreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.launchParContainer.ResumeLayout(false);
            this.launchParContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button checkForUpdatesButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label modInfoLabel;
        private System.Windows.Forms.CheckBox noSplashBox;
        private System.Windows.Forms.GroupBox launchParContainer;
        private System.Windows.Forms.CheckBox noPauseBox;
        private System.Windows.Forms.CheckBox hugePagesBox;
        private System.Windows.Forms.Label modNoLabel;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label scanningFileLabel;
        private System.Windows.Forms.Label a3DirLabel;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button armaDirButton;
        private System.Windows.Forms.TextBox armaDirTextBox;
        private System.Windows.Forms.Label downloadSpeedLabel;
        private System.Windows.Forms.ComboBox profileBox;
        private System.Windows.Forms.Button modDirButton;
        private System.Windows.Forms.Label customModDirLabel;
        private System.Windows.Forms.TextBox modDirTextBox;
        private System.Windows.Forms.Button clearModDirButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.CheckBox optionalModsBox;
        private System.Windows.Forms.CheckBox mmmBox;
    }
}

