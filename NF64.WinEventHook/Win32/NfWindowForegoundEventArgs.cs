using NF64.WinEventHooks.Win32.WinEvent;

namespace NF64.WinEventHooks.Win32
{
    public sealed class NfWindowForegoundEventArgs
    {
        public int ProcessId { get; }

        public string WindowTitle { get; }


        internal NfWindowForegoundEventArgs(WinEventHookedEventArgs e)
        {
            this.ProcessId = (int)NfWin.GetWindowThreadProcessId(e.WindowHandle);
            this.WindowTitle = NfWin.GetWindowText(e.WindowHandle);
        }
    }
}
