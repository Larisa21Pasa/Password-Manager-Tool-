using Interfata;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BazaDeDate.DataClasses;

namespace Exemplu_interfete
{
    public partial class Form1 : Form
    {
        private static Form1 s_obj;
        static public ViewAccount ViewAcc { get; set; } = new ViewAccount();
        static public AddPassword AddPass { get; set; } = new AddPassword();
        static public SettingsPage SettingsPage { get; set; } = new SettingsPage();
        static public Home HomePage { get; set; } = new Home();
        static public Login Login { get; set; } = new Login();

        public static string User { get; set; }

        private bool _isDarkTheme = false;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        private readonly Dictionary<string, string> _previousPages = new Dictionary<string, string>()
        {
            { "Home", "Login" },
            { "SignUp", "Login" },
            { "ViewAccount", "Home" },
            { "AddPassword", "Home" },
            { "SettingsPage","Login" },
            // Add more mappings for other pages if needed
        };

        public static Form1 Instance
        {
            get
            {
                if (null == s_obj)
                {
                    s_obj = new Form1();
                }
                return s_obj;
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public Panel PanelContainer
        {
            get { return panelContainer; }
            set { panelContainer = value; }
        }

        public Button BackButton
        {
            get { return backButton; }
            set { backButton = value; }
        }
        public string CurrentPage { get; set; } = "Login";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backButton.Visible = false;
            s_obj = this;

            Login.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(Login);
        }
     
        public void NavigateToPage(string pageName, UserControl newPage)
        {
            if (!Form1.Instance.PanelContainer.Controls.ContainsKey(pageName))
            {
                newPage.Dock = DockStyle.Fill;
                Form1.Instance.PanelContainer.Controls.Add(newPage);
            }

            Form1.Instance.PanelContainer.Controls[pageName].BringToFront();
            Form1.Instance.CurrentPage = pageName;
            Form1.Instance.BackButton.Visible = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            //  panelContainer.Controls["Login"].BringToFront();
            // backButton.Visible = false;

            if (_previousPages.TryGetValue(CurrentPage, out string previousPage))
            {
                Console.WriteLine("backButton_Click " + CurrentPage);

                panelContainer.Controls[previousPage].BringToFront();
                CurrentPage = previousPage;
            }

            backButton.Visible = CurrentPage != "Login";
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
        private void HelpButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                string helpfilePath = "PasswordManagerTool.chm";
                string helpPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, helpfilePath);
                Console.WriteLine("helpPath = " + helpPath);
                Help.ShowHelp(this, helpPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string despreProiect = "Aplicatie de gestiune a parolelor - 2023 \n Grupa 1306B \n Budacă M. Marius-Andrei \n Budu V. Daniel \n Pașa P.C. Anamaria-Larisa \n Pintilie V. Răzvan-Nicolae\n";
            MessageBox.Show(despreProiect, "About");
        }
      

        private void Logo_Click(object sender, EventArgs e)
        {
            SettingsPage.ThemeButtonClicked += HandleThemeButtonClicked;
            Form1.Instance.NavigateToPage("SettingsPage", SettingsPage);

        }
        private void HandleThemeButtonClicked(object sender, string buttonText)
        {
            _isDarkTheme = buttonText.Equals("Dark", StringComparison.OrdinalIgnoreCase);
            ApplyTheme();
        }
        private void ApplyTheme()
        {

            ThemeHelper.ApplyTheme(this, _isDarkTheme);
            ThemeHelper.ApplyTheme(SettingsPage, _isDarkTheme);
            ThemeHelper.ApplyTheme(HomePage, _isDarkTheme);
            ThemeHelper.ApplyTheme(AddPass, _isDarkTheme);
            ThemeHelper.ApplyTheme(ViewAcc, _isDarkTheme);
        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        
        public void UnexpectedError() => MessageBox.Show("An unknown error has occurred", "Error");
    }
}
