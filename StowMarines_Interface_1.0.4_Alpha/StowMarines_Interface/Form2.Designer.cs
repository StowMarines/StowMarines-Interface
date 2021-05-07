
namespace StowMarines_Interface
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.testButton2 = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.usrNamBox = new System.Windows.Forms.TextBox();
            this.pswBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginBox = new System.Windows.Forms.GroupBox();
            this.financeButton = new System.Windows.Forms.Button();
            this.loginBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // testButton2
            // 
            resources.ApplyResources(this.testButton2, "testButton2");
            this.testButton2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.testButton2.Name = "testButton2";
            this.testButton2.UseVisualStyleBackColor = true;
            this.testButton2.Click += new System.EventHandler(this.testButton2_Click);
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.BackColor = System.Drawing.Color.Lime;
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Name = "titleLabel";
            // 
            // usrNamBox
            // 
            resources.ApplyResources(this.usrNamBox, "usrNamBox");
            this.usrNamBox.Name = "usrNamBox";
            // 
            // pswBox
            // 
            resources.ApplyResources(this.pswBox, "pswBox");
            this.pswBox.Name = "pswBox";
            this.pswBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Name = "label3";
            // 
            // loginButton
            // 
            resources.ApplyResources(this.loginButton, "loginButton");
            this.loginButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loginButton.Name = "loginButton";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // loginBox
            // 
            this.loginBox.BackColor = System.Drawing.Color.Gray;
            this.loginBox.Controls.Add(this.loginButton);
            this.loginBox.Controls.Add(this.pswBox);
            this.loginBox.Controls.Add(this.label3);
            this.loginBox.Controls.Add(this.usrNamBox);
            this.loginBox.Controls.Add(this.label2);
            resources.ApplyResources(this.loginBox, "loginBox");
            this.loginBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.loginBox.Name = "loginBox";
            this.loginBox.TabStop = false;
            // 
            // financeButton
            // 
            this.financeButton.BackColor = System.Drawing.Color.DimGray;
            resources.ApplyResources(this.financeButton, "financeButton");
            this.financeButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.financeButton.Name = "financeButton";
            this.financeButton.UseVisualStyleBackColor = false;
            this.financeButton.Click += new System.EventHandler(this.financeButton_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.financeButton);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.testButton2);
            this.Controls.Add(this.loginBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load_1);
            this.loginBox.ResumeLayout(false);
            this.loginBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button testButton2;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox usrNamBox;
        private System.Windows.Forms.TextBox pswBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.GroupBox loginBox;
        private System.Windows.Forms.Button financeButton;
    }
}