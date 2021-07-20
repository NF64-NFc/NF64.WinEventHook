using System;
using System.Windows.Forms;
using NF64.WinEventHooks.Win32;

namespace NF64.WinEventHooks
{
    internal static class NfApp
    {
        [STAThread]
        private static void Main()
        {
            NfWinEventHandler.Execute();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NfMainForm());
        }
    }
}
