using System.Drawing;
using System.Windows.Forms;
namespace Exemplu_interfete
{
    /// <summary>
    /// Changes the UserControl theme
    /// </summary>
    public static class ThemeHelper
    {
        /// <summary>
        /// Will apply desired theme to a control
        /// </summary>
        /// <param name="control">Control to have the theme set</param>
        /// <param name="isDarkTheme">True for dark theme, false for light theme</param>
        public static void ApplyTheme(Control control, bool isDarkTheme)
        {
            Color backgroundColor = isDarkTheme ? Color.LightSteelBlue : Color.AliceBlue;
            Color foregroundColor = isDarkTheme ? Color.White : Color.Black;

            control.BackColor = backgroundColor;
            control.ForeColor = foregroundColor;

            ApplyThemeToControls(control.Controls, isDarkTheme);
        }

        /// <summary>
        /// Will apply desired theme to a collection of controls
        /// </summary>
        /// <param name="controls">Control set to have the theme set</param>
        /// <param name="isDarkTheme">True for dark theme, false for light theme</param>
        private static void ApplyThemeToControls(Control.ControlCollection controls, bool isDarkTheme)
        {
            foreach (Control control in controls)
            {
                // Apply theme to control panels
                if (control is Panel)
                {
                    Panel panel = (Panel)control;
                    if (panel.Name == "containerPanel1")
                    {
                        panel.BackColor = isDarkTheme ? Color.LightSteelBlue : Color.AliceBlue;
                        panel.ForeColor = isDarkTheme ? Color.White : Color.Black;
                    }
                    else if (panel.Name == "containerPanel2")
                    {
                        panel.BackColor = isDarkTheme ? Color.LightSlateGray : Color.LightSteelBlue;
                        panel.ForeColor = isDarkTheme ? Color.White : Color.Black;
                    }
                    else if (panel.Name == "welcomePanel")
                    {
                        panel.BackColor = isDarkTheme ? Color.LightSlateGray : Color.LightSteelBlue;
                        panel.ForeColor = isDarkTheme ? Color.White : Color.Black;
                    }
                    else
                    {
                        control.BackColor = isDarkTheme ? Color.LightSteelBlue : Color.AliceBlue;
                        control.ForeColor = isDarkTheme ? Color.White : Color.Black;
                    }
                    //       ApplyThemeToControls(panel.Controls, isDarkTheme);

                }
                else
                {
                    if (control is UserControl)
                    {
                        control.BackColor = isDarkTheme ? Color.LightSteelBlue : Color.AliceBlue;
                        control.ForeColor = isDarkTheme ? Color.White : Color.Black;
                    }
                }

                ApplyThemeToControls(control.Controls, isDarkTheme);
            }

        }
    }
}
