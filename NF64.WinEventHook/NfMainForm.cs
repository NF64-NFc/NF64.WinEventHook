using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using NF64.WinEventHooks.Win32;

namespace NF64.WinEventHooks
{
    public partial class NfMainForm : Form
    {
        private readonly NfWindowActivationHandler _handler = new NfWindowActivationHandler();


        public NfMainForm()
        {
            this.InitializeComponent();
        }


        private void NfMainForm_Load(object sender, EventArgs e)
        {
            this._handler.WindowActivate += this.NfWindowActivationHandler_WindowActivate;
            this._handler.WindowDeactivate += this.NfWindowActivationHandler_WindowDeactivate;
        }


        private void NfWindowActivationHandler_WindowActivate(object sender, NfWindowActivationChangedEventArgs e)
        {
            // 最低100msの遅延を設けないとエクスプローラーのタイトルを正しく取得できない
            Thread.Sleep(100);

            var title = NfWin.GetWindowText(e.WindowHandle);
            var process = Process.GetProcessById(e.ProcessId);

            var info = string.Join(", ", new[] {
                $"P.ID = {process.Id}",
                $"HWND = {e.WindowHandle}",
                $"P.NAME = {process.ProcessName}",
                $"TITLE = '{title}' ('{process.MainWindowTitle}')",
                $"DateTime = '{e.DateTime}'",
            });

            this.AddLine($"[{info}]");
        }

        private void NfWindowActivationHandler_WindowDeactivate(object sender, NfWindowActivationChangedEventArgs e)
        {
            var title = NfWin.GetWindowText(e.WindowHandle);
            var process = Process.GetProcessById(e.ProcessId);

             var info = string.Join(", ", new[] {
                $"P.ID = {process.Id}",
                $"HWND = {e.WindowHandle}",
                $"P.NAME = {process.ProcessName}",
                $"TITLE = '{title}' ('{process.MainWindowTitle}')",
                $"DateTime = '{e.DateTime}'",
            });

            this.AddLine($"Deactivate : [{info}]");
        }


        private void AddLine(string s)
        {
            this.textBox1.Text += $"{s}{Environment.NewLine}";
            this.textBox1.SelectionStart = this.textBox1.Text.Length - 1;
        }
    }
}
