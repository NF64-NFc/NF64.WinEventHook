using System;
using System.Diagnostics;
using System.Windows.Forms;
using NF64.WinEventHooks.Win32;
using NF64.WinEventHooks.Win32.WinEvent;

namespace NF64.WinEventHooks
{
    public partial class NfMainForm : Form
    {
        public NfMainForm()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }


        private void Initialize()
        {
            WinEventHook.Hooked += this.WinEventHook_Hooked;
            WinEventHook.Execute();
        }

        private void WinEventHook_Hooked(object sender, WinEventHookedEventArgs e)
        {
            if (e.EventType == WinEvents.EVENT_SYSTEM_FOREGROUND)
                this.WinEventHook_Hooked_Foreground(e);
        }

        private void WinEventHook_Hooked_Foreground(WinEventHookedEventArgs e)
        {
            var hwnd = e.WindowHandle;
            var pHwnd = NfWin.GetParent(hwnd);
            var text = NfWin.GetWindowText(hwnd);

            var status = string.Join(", ", new[] {
                $"IsWindow = {NfWin.IsWindow(hwnd)}",
                $"IsWindowVisible = {NfWin.IsWindowVisible(hwnd)}",
                $"IsWindowEnabled = {NfWin.IsWindowEnabled(hwnd)}",
            });

            var pid = (int)NfWin.GetWindowThreadProcessId(hwnd);
            var process = Process.GetProcessById(pid);

            var info = string.Join(", ", new[] {
                $"PID = {process.Id}",
                $"HWND = {hwnd}({pHwnd})",
                $"NAME = {process.ProcessName}",
                $"TITLE = '{text}'('{process.MainWindowTitle}')",
            });

            this.AddLine($"[{info}] : {status}");
        }


        private void AddLine(string s)
        {
            this.textBox1.Text += $"{s}{Environment.NewLine}";
            this.textBox1.SelectionStart = this.textBox1.Text.Length - 1;
        }
    }
}
