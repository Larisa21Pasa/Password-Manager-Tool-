namespace Interfata
{
    partial class SettingsPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsPage));
            this.containerPanel2 = new System.Windows.Forms.Panel();
            this.toolLabelInfo = new System.Windows.Forms.Label();
            this.pictureInfoLogin = new System.Windows.Forms.PictureBox();
            this.managementLabelInfo = new System.Windows.Forms.Label();
            this.passwordLabelInfo = new System.Windows.Forms.Label();
            this.containerPanel1 = new System.Windows.Forms.Panel();
            this.themes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.containerPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureInfoLogin)).BeginInit();
            this.containerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerPanel2
            // 
            this.containerPanel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.containerPanel2.Controls.Add(this.toolLabelInfo);
            this.containerPanel2.Controls.Add(this.pictureInfoLogin);
            this.containerPanel2.Controls.Add(this.managementLabelInfo);
            this.containerPanel2.Controls.Add(this.passwordLabelInfo);
            this.containerPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.containerPanel2.Location = new System.Drawing.Point(0, 0);
            this.containerPanel2.Name = "containerPanel2";
            this.containerPanel2.Size = new System.Drawing.Size(228, 395);
            this.containerPanel2.TabIndex = 3;
            // 
            // toolLabelInfo
            // 
            this.toolLabelInfo.BackColor = System.Drawing.Color.Transparent;
            this.toolLabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toolLabelInfo.Font = new System.Drawing.Font("Myanmar Text", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolLabelInfo.ForeColor = System.Drawing.Color.Black;
            this.toolLabelInfo.Location = new System.Drawing.Point(86, 264);
            this.toolLabelInfo.Name = "toolLabelInfo";
            this.toolLabelInfo.Size = new System.Drawing.Size(96, 38);
            this.toolLabelInfo.TabIndex = 9;
            this.toolLabelInfo.Text = "Tool";
            this.toolLabelInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolLabelInfo.UseCompatibleTextRendering = true;
            // 
            // pictureInfoLogin
            // 
            this.pictureInfoLogin.BackColor = System.Drawing.Color.Transparent;
            this.pictureInfoLogin.Image = ((System.Drawing.Image)(resources.GetObject("pictureInfoLogin.Image")));
            this.pictureInfoLogin.Location = new System.Drawing.Point(30, 32);
            this.pictureInfoLogin.Name = "pictureInfoLogin";
            this.pictureInfoLogin.Size = new System.Drawing.Size(183, 116);
            this.pictureInfoLogin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureInfoLogin.TabIndex = 0;
            this.pictureInfoLogin.TabStop = false;
            // 
            // managementLabelInfo
            // 
            this.managementLabelInfo.BackColor = System.Drawing.Color.Transparent;
            this.managementLabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.managementLabelInfo.Font = new System.Drawing.Font("Myanmar Text", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managementLabelInfo.ForeColor = System.Drawing.Color.Black;
            this.managementLabelInfo.Location = new System.Drawing.Point(0, 211);
            this.managementLabelInfo.Name = "managementLabelInfo";
            this.managementLabelInfo.Size = new System.Drawing.Size(182, 42);
            this.managementLabelInfo.TabIndex = 8;
            this.managementLabelInfo.Text = "Management";
            this.managementLabelInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.managementLabelInfo.UseCompatibleTextRendering = true;
            // 
            // passwordLabelInfo
            // 
            this.passwordLabelInfo.BackColor = System.Drawing.Color.Transparent;
            this.passwordLabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passwordLabelInfo.Font = new System.Drawing.Font("Myanmar Text", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabelInfo.ForeColor = System.Drawing.Color.Black;
            this.passwordLabelInfo.Location = new System.Drawing.Point(42, 165);
            this.passwordLabelInfo.Name = "passwordLabelInfo";
            this.passwordLabelInfo.Size = new System.Drawing.Size(141, 37);
            this.passwordLabelInfo.TabIndex = 7;
            this.passwordLabelInfo.Text = "Password";
            this.passwordLabelInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.passwordLabelInfo.UseCompatibleTextRendering = true;
            // 
            // containerPanel1
            // 
            this.containerPanel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.containerPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.containerPanel1.Controls.Add(this.themes);
            this.containerPanel1.Controls.Add(this.label1);
            this.containerPanel1.Location = new System.Drawing.Point(219, 0);
            this.containerPanel1.Name = "containerPanel1";
            this.containerPanel1.Size = new System.Drawing.Size(581, 398);
            this.containerPanel1.TabIndex = 4;
            this.containerPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.containerPanel1_Paint);
            // 
            // themes
            // 
            this.themes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.themes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.themes.Location = new System.Drawing.Point(205, 165);
            this.themes.Name = "themes";
            this.themes.Size = new System.Drawing.Size(136, 39);
            this.themes.TabIndex = 6;
            this.themes.Text = "Dark";
            this.themes.UseVisualStyleBackColor = true;
            this.themes.Click += new System.EventHandler(this.themes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // SettingsPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.containerPanel1);
            this.Controls.Add(this.containerPanel2);
            this.Name = "SettingsPage";
            this.Size = new System.Drawing.Size(800, 395);
            this.containerPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureInfoLogin)).EndInit();
            this.containerPanel1.ResumeLayout(false);
            this.containerPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel containerPanel2;
        private System.Windows.Forms.Label toolLabelInfo;
        private System.Windows.Forms.PictureBox pictureInfoLogin;
        private System.Windows.Forms.Label managementLabelInfo;
        private System.Windows.Forms.Label passwordLabelInfo;
        private System.Windows.Forms.Panel containerPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button themes;
    }
}
