using System;
using System.Windows.Forms;
using WatsonTest.EZPlugin;

namespace WatsonTest.WinForms
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var f = new MainForm
            {
                TopLevel = true,
                HelpButton = false,
                ShowIcon = false,
                ControlBox = true,
                Exitable = true
            };

            try
            {
                Application.Run(f);
            }
            catch (Exception)
            {
                //ignore ez-builder close exception
            }
        }
    }
}