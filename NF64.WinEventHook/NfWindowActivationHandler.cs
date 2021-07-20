using System;
using NF64.WinEventHooks.Win32;

namespace NF64.WinEventHooks
{
    internal sealed class NfWindowActivationHandler
    {
        public event EventHandler<NfWindowActivationChangedEventArgs> WindowActivate;
        public event EventHandler<NfWindowActivationChangedEventArgs> WindowDeactivate;


        public IntPtr ActiveWindowHandle { get; private set; }


        public NfWindowActivationHandler()
        {
            NfWinEventHandler.WindowForeground += this.NfWinEventHandler_WindowForeground;
        }


        private void NfWinEventHandler_WindowForeground(object sender, NfWindowForegoundEventArgs e)
        {
            if (this.ActiveWindowHandle != IntPtr.Zero)
                this.WindowDeactivate?.Invoke(this, new NfWindowActivationChangedEventArgs(this.ActiveWindowHandle, DateTime.Now));

            this.ActiveWindowHandle = e.WindowHandle;
            this.WindowActivate?.Invoke(this, new NfWindowActivationChangedEventArgs(e));
        }
    }
}
