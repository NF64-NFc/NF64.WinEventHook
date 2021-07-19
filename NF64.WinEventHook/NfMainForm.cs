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
            var text = NfWin.GetWindowText(hwnd);

            var pid = (int)NfWin.GetWindowThreadProcessId(hwnd);
            var process = Process.GetProcessById(pid);

            var info = string.Join(", ", new[] {
                $"PID = {process.Id}",
                $"HWND = {hwnd}",
                $"NAME = {process.ProcessName}",
                $"TITLE = '{text}'('{process.MainWindowTitle}')",
            });

            this.AddLine($"[{info}]");
        }


        private void AddLine(string s)
        {
            this.textBox1.Text += $"{s}{Environment.NewLine}";
            this.textBox1.SelectionStart = this.textBox1.Text.Length - 1;
        }
    }
}
