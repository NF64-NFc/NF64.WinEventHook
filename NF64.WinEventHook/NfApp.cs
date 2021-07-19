using System;
using System.Windows.Forms;

namespace NF64.WinEventHooks
{
    internal static class NfApp
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NfMainForm());
        }
    }
}
