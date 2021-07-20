using System;
using NF64.WinEventHooks.Win32;

namespace NF64.WinEventHooks
{
    internal sealed class NfWindowActivationChangedEventArgs
    {
        public IntPtr WindowHandle { get; }

        public DateTime DateTime { get; }

        public string WindowTitle { get; }

        public int ProcessId { get; }


        internal NfWindowActivationChangedEventArgs(NfWindowForegoundEventArgs e)
            : this(e.WindowHandle, e.DateTime) { }

        internal NfWindowActivationChangedEventArgs(IntPtr windowHandle, DateTime dateTime)
        {
            if (windowHandle == IntPtr.Zero)
                throw new ArgumentException($"Invalid window handle. ({windowHandle})", nameof(windowHandle));

            this.WindowHandle = windowHandle;
            this.DateTime = dateTime;
            this.ProcessId = (int)NfWin.GetWindowThreadProcessId(this.WindowHandle);
            this.WindowTitle = NfWin.GetWindowText(this.WindowHandle);
        }
    }
}
