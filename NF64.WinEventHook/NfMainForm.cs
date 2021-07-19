using System;
using System.Diagnostics;
using System.Windows.Forms;
using NF64.WinEventHooks.Win32;

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
            NfWinEventHandler.Execute();
            NfWinEventHandler.WindowForeground += this.NfWinEventHandler_WindowForeground;
        }

        private void NfWinEventHandler_WindowForeground(object sender, NfWindowForegoundEventArgs e)
        {
            var title = NfWin.GetWindowText(e.WindowHandle);
            var process = Process.GetProcessById(e.ProcessId);

            var info = string.Join(", ", new[] {
                $"P.ID = {process.Id}",
                $"HWND = {e.WindowHandle}",
                $"P.NAME = {process.ProcessName}",
                $"TITLE = '{title}' ('{process.MainWindowTitle}')",
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
