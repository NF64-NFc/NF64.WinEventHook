using System;
using NF64.WinEventHooks.Win32.WinEvent;

namespace NF64.WinEventHooks.Win32
{
    public sealed class NfWindowForegoundEventArgs
    {
        public IntPtr WindowHandle => this._sourceEventArgs.WindowHandle;

        public string WindowTitle { get; }

        public int ProcessId { get; }


        private readonly WinEventHookedEventArgs _sourceEventArgs;


        internal NfWindowForegoundEventArgs(WinEventHookedEventArgs e)
        {
            this._sourceEventArgs = e ?? throw new ArgumentNullException(nameof(e));

            this.ProcessId = (int)NfWin.GetWindowThreadProcessId(e.WindowHandle);
            this.WindowTitle = NfWin.GetWindowText(e.WindowHandle);
        }
    }
}
