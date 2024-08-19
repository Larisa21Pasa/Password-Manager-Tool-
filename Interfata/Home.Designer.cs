namespace Exemplu_interfete
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.addPasswordButton = new System.Windows.Forms.Button();
            this.viewAccountButton = new System.Windows.Forms.Button();
            this.containerPanel2 = new System.Windows.Forms.Panel();
            this.containerPanel1 = new System.Windows.Forms.Panel();
            this.dropDownSearch = new System.Windows.Forms.ComboBox();
            this.searchWordText = new System.Windows.Forms.TextBox();
            this.submitSignUpButton = new System.Windows.Forms.Button();
            this.LoginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.containerPanel2.SuspendLayout();
            this.containerPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // addPasswordButton
            // 
            this.addPasswordButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.addPasswordButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.addPasswordButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addPasswordButton.Font = new System.Drawing.Font("Cambria Math", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPasswordButton.Location = new System.Drawing.Point(20, 55);
            this.addPasswordButton.Name = "addPasswordButton";
            this.addPasswordButton.Size = new System.Drawing.Size(182, 79);
            this.addPasswordButton.TabIndex = 1;
            this.addPasswordButton.Text = "Add New Password";
            this.addPasswordButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.addPasswordButton.UseCompatibleTextRendering = true;
            this.addPasswordButton.UseVisualStyleBackColor = false;
            this.addPasswordButton.Click += new System.EventHandler(this.addPasswordButton_Click);
            // 
            // viewAccountButton
            // 
            this.viewAccountButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.viewAccountButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.AliceBlue;
            this.viewAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewAccountButton.Font = new System.Drawing.Font("Cambria Math", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAccountButton.Location = new System.Drawing.Point(20, 224);
            this.viewAccountButton.Name = "viewAccountButton";
            this.viewAccountButton.Size = new System.Drawing.Size(182, 79);
            this.viewAccountButton.TabIndex = 2;
            this.viewAccountButton.Text = "View Account";
            this.viewAccountButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.viewAccountButton.UseCompatibleTextRendering = true;
            this.viewAccountButton.UseVisualStyleBackColor = false;
            this.viewAccountButton.Click += new System.EventHandler(this.viewAccountButton_Click);
            // 
            // containerPanel2
            // 
            this.containerPanel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.containerPanel2.Controls.Add(this.addPasswordButton);
            this.containerPanel2.Controls.Add(this.viewAccountButton);
            this.containerPanel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.containerPanel2.Location = new System.Drawing.Point(0, 0);
            this.containerPanel2.Name = "containerPanel2";
            this.containerPanel2.Size = new System.Drawing.Size(228, 395);
            this.containerPanel2.TabIndex = 4;
            this.containerPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.containerPanel2_Paint);
            // 
            // containerPanel1
            // 
            this.containerPanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.containerPanel1.Controls.Add(this.dropDownSearch);
            this.containerPanel1.Controls.Add(this.searchWordText);
            this.containerPanel1.Controls.Add(this.submitSignUpButton);
            this.containerPanel1.Controls.Add(this.LoginLabel);
            this.containerPanel1.Controls.Add(this.label1);
            this.containerPanel1.Location = new System.Drawing.Point(222, -3);
            this.containerPanel1.Name = "containerPanel1";
            this.containerPanel1.Size = new System.Drawing.Size(581, 398);
            this.containerPanel1.TabIndex = 5;
            // 
            // dropDownSearch
            // 
            this.dropDownSearch.AutoCompleteCustomSource.AddRange(new string[] {
            "User",
            "Email",
            "Domain",
            "Password"});
            this.dropDownSearch.DropDownWidth = 60;
            this.dropDownSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dropDownSearch.ItemHeight = 15;
            this.dropDownSearch.Items.AddRange(new object[] {
            "User",
            "Email",
            "Domain",
            "Password"});
            this.dropDownSearch.Location = new System.Drawing.Point(450, 151);
            this.dropDownSearch.Name = "dropDownSearch";
            this.dropDownSearch.Size = new System.Drawing.Size(116, 23);
            this.dropDownSearch.TabIndex = 10;
            this.dropDownSearch.Text = "User";
            // 
            // searchWordText
            // 
            this.searchWordText.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.searchWordText.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchWordText.ForeColor = System.Drawing.SystemColors.InfoText;
            this.searchWordText.Location = new System.Drawing.Point(29, 97);
            this.searchWordText.Name = "searchWordText";
            this.searchWordText.Size = new System.Drawing.Size(409, 32);
            this.searchWordText.TabIndex = 15;
            this.searchWordText.Text = "your search here . . . ";
            this.searchWordText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.nameSignUpText_MouseClick);
            this.searchWordText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.searchWordText_KeyPress);
            // 
            // submitSignUpButton
            // 
            this.submitSignUpButton.BackColor = System.Drawing.Color.Transparent;
            this.submitSignUpButton.FlatAppearance.BorderSize = 0;
            this.submitSignUpButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.submitSignUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitSignUpButton.Font = new System.Drawing.Font("Cambria Math", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitSignUpButton.Image = ((System.Drawing.Image)(resources.GetObject("submitSignUpButton.Image")));
            this.submitSignUpButton.Location = new System.Drawing.Point(481, 97);
            this.submitSignUpButton.Name = "submitSignUpButton";
            this.submitSignUpButton.Size = new System.Drawing.Size(53, 42);
            this.submitSignUpButton.TabIndex = 12;
            this.submitSignUpButton.UseCompatibleTextRendering = true;
            this.submitSignUpButton.UseVisualStyleBackColor = false;
            this.submitSignUpButton.Click += new System.EventHandler(this.submitSignUpButton_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.BackColor = System.Drawing.Color.Transparent;
            this.LoginLabel.Font = new System.Drawing.Font("Cambria Math", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginLabel.ForeColor = System.Drawing.Color.Black;
            this.LoginLabel.Location = new System.Drawing.Point(85, 22);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(382, 41);
            this.LoginLabel.TabIndex = 9;
            this.LoginLabel.Text = "Let\'s find a password";
            this.LoginLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LoginLabel.UseCompatibleTextRendering = true;
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
            // Home
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.containerPanel1);
            this.Controls.Add(this.containerPanel2);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(800, 395);
            this.containerPanel2.ResumeLayout(false);
            this.containerPanel1.ResumeLayout(false);
            this.containerPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addPasswordButton;
        private System.Windows.Forms.Button viewAccountButton;
        private System.Windows.Forms.Panel containerPanel2;
        private System.Windows.Forms.Panel containerPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button submitSignUpButton;
        private System.Windows.Forms.ComboBox dropDownSearch;
        private System.Windows.Forms.Label LoginLabel;
        private System.Windows.Forms.TextBox searchWordText;
    }
}
