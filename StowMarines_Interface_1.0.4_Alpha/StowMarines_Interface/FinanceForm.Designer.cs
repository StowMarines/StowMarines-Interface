
namespace StowMarines_Interface
{
    partial class FinanceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinanceForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BackButton = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.teamFinanceGrid = new System.Windows.Forms.DataGridView();
            this.teamBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.changeBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.submitChangeButton = new System.Windows.Forms.Button();
            this.amountUpDown = new System.Windows.Forms.NumericUpDown();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.teamFinanceGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            resources.ApplyResources(this.BackButton, "BackButton");
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BackButton.Name = "BackButton";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.BackColor = System.Drawing.Color.Lime;
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Name = "titleLabel";
            // 
            // teamFinanceGrid
            // 
            this.teamFinanceGrid.AllowUserToAddRows = false;
            this.teamFinanceGrid.AllowUserToDeleteRows = false;
            this.teamFinanceGrid.BackgroundColor = System.Drawing.Color.Gray;
            this.teamFinanceGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.teamFinanceGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.teamFinanceGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.teamFinanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.teamFinanceGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Team,
            this.Balance});
            this.teamFinanceGrid.Cursor = System.Windows.Forms.Cursors.No;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.teamFinanceGrid.DefaultCellStyle = dataGridViewCellStyle6;
            this.teamFinanceGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.teamFinanceGrid.GridColor = System.Drawing.Color.Gray;
            resources.ApplyResources(this.teamFinanceGrid, "teamFinanceGrid");
            this.teamFinanceGrid.Name = "teamFinanceGrid";
            this.teamFinanceGrid.ReadOnly = true;
            // 
            // teamBox
            // 
            resources.ApplyResources(this.teamBox, "teamBox");
            this.teamBox.FormattingEnabled = true;
            this.teamBox.Name = "teamBox";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Name = "label2";
            // 
            // changeBox
            // 
            resources.ApplyResources(this.changeBox, "changeBox");
            this.changeBox.FormattingEnabled = true;
            this.changeBox.Name = "changeBox";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Name = "label3";
            // 
            // submitChangeButton
            // 
            resources.ApplyResources(this.submitChangeButton, "submitChangeButton");
            this.submitChangeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.submitChangeButton.Name = "submitChangeButton";
            this.submitChangeButton.UseVisualStyleBackColor = true;
            this.submitChangeButton.Click += new System.EventHandler(this.submitChangeButton_Click);
            // 
            // amountUpDown
            // 
            resources.ApplyResources(this.amountUpDown, "amountUpDown");
            this.amountUpDown.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.amountUpDown.Name = "amountUpDown";
            // 
            // Team
            // 
            resources.ApplyResources(this.Team, "Team");
            this.Team.Name = "Team";
            this.Team.ReadOnly = true;
            // 
            // Balance
            // 
            resources.ApplyResources(this.Balance, "Balance");
            this.Balance.Name = "Balance";
            this.Balance.ReadOnly = true;
            // 
            // FinanceForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.amountUpDown);
            this.Controls.Add(this.submitChangeButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.changeBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.teamBox);
            this.Controls.Add(this.teamFinanceGrid);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.BackButton);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FinanceForm";
            this.Load += new System.EventHandler(this.FinanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.teamFinanceGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.DataGridView teamFinanceGrid;
        private System.Windows.Forms.ComboBox teamBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox changeBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitChangeButton;
        private System.Windows.Forms.NumericUpDown amountUpDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balance;
    }
}