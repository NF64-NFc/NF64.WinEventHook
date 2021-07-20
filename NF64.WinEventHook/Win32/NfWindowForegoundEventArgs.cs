using System;
using NF64.WinEventHooks.Win32.WinEvent;

namespace NF64.WinEventHooks.Win32
{
    internal sealed class NfWindowForegoundEventArgs
    {
        public IntPtr WindowHandle => this._sourceEventArgs.WindowHandle;

        public DateTime DateTime { get; }


        private readonly WinEventHookedEventArgs _sourceEventArgs;


        internal NfWindowForegoundEventArgs(WinEventHookedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (e.WindowHandle == IntPtr.Zero)
                throw new ArgumentException($"Invalid window handle. ({e.WindowHandle})", nameof(e));

            this._sourceEventArgs = e ?? throw new ArgumentNullException(nameof(e));

            this.DateTime = DateTime.Now.AddMilliseconds(this._sourceEventArgs.EventMilliseconds - Environment.TickCount);
        }
    }
}
