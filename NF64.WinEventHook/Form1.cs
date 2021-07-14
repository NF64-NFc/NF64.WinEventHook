using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace NF64.WinEventHook
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            NfWinHook.Evented += (o, ev) => {
                var hwnd = ev.HWND;
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
            };
            NfWinHook.Exec();
        }


        private void AddLine(string s)
        {
            this.textBox1.Text += $"{s}{Environment.NewLine}";
            this.textBox1.SelectionStart = this.textBox1.Text.Length - 1;
        }
    }
}
