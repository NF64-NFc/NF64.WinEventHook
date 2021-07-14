using System;
using System.Windows.Forms;

namespace NF64.WinEventHook
{
    internal static class App
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
