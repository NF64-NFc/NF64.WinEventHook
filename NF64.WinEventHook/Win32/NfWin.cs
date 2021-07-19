using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NF64.WinEventHooks.Win32
{
    internal static class NfWin
    {
        [DllImport("user32.dll", ExactSpelling=true, CharSet=CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);


        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        public static string GetWindowText(IntPtr hwnd)
        {
            // max length in window title is 255 chars.
            const int nChars = 256;
            var sb = new StringBuilder(nChars);
            GetWindowText(hwnd, sb, nChars);
            return sb.ToString();
        }


        [DllImport("user32.dll", SetLastError=true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        public static uint GetWindowThreadProcessId(IntPtr hWnd)
        {
            GetWindowThreadProcessId(hWnd, out uint ret);
            return ret;
        }
    }
}
