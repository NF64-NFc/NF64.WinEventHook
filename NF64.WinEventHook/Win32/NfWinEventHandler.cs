using System;
using NF64.WinEventHooks.Win32.WinEvent;

namespace NF64.WinEventHooks.Win32
{
    public static class NfWinEventHandler
    {
        public static event EventHandler<NfWindowForegoundEventArgs> WindowForeground;


        public static void Execute()
        {
            WinEventHook.EventMin = WinEvents.EVENT_SYSTEM_FOREGROUND;
            WinEventHook.EventMax = WinEvents.EVENT_SYSTEM_FOREGROUND;
            WinEventHook.Hooked += WinEventHook_Hooked;

            WinEventHook.Execute();
        }


        private static void WinEventHook_Hooked(object sender, WinEventHookedEventArgs e)
        {
            switch (e.EventType)
            {
            case WinEvents.EVENT_SYSTEM_FOREGROUND:
                if (e.WindowHandle != IntPtr.Zero)
                    WindowForeground?.Invoke(null, new NfWindowForegoundEventArgs(e));
                break;
            }
        }
    }
}
