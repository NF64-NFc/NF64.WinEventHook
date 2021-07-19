using System;
using System.Runtime.InteropServices;

namespace NF64.WinEventHooks.Win32.WinEvent
{
    internal static class WinEventHook
    {
        public static event EventHandler<WinEventHookedEventArgs> Hooked;


        public static WinEvents EventMin { get; set; } = WinEvents.EVENT_MIN;

        public static WinEvents EventMax { get; set; } = WinEvents.EVENT_MAX;

        public static WinEventFlags Flag { get; set; } = WinEventFlags.WINEVENT_OUTOFCONTEXT;


        private static readonly WinEventDelegate _hookMethod = new WinEventDelegate(WinEventProc);


        public static void Execute()
        {
            SetWinEventHook(
                    EventMin,
                    EventMax,
                    IntPtr.Zero,
                    _hookMethod,
                    0,
                    0,
                    Flag
                );
        }

        private static void WinEventProc(
                IntPtr hWinEventHook,
                WinEvents eventType,
                IntPtr hwnd,
                int idObject,
                int idChild,
                uint dwEventThread,
                uint dwmsEventTime
            )
        {
            Hooked?.Invoke(null, new WinEventHookedEventArgs(
                    eventType,
                    hwnd,
                    idObject,
                    idChild,
                    dwmsEventTime
                ));
        }


        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(
                WinEvents eventMin,
                WinEvents eventMax,
                IntPtr hmodWinEventProc,
                WinEventDelegate lpfnWinEventProc,
                uint idProcess,
                uint idThread,
                WinEventFlags dwFlags
            );

        private delegate void WinEventDelegate(
                IntPtr hWinEventHook,
                WinEvents eventType,
                IntPtr hwnd,
                int idObject,
                int idChild,
                uint dwEventThread,
                uint dwmsEventTime
            );
    }
}
