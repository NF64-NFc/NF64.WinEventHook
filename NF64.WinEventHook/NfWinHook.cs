using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NF64.WinEventHook
{
    internal static class NfWinHook
    {
        private delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);


        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);


        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;



        public static event EventHandler<NfWinEventArgs> Evented;


        private static readonly WinEventDelegate _proc = new WinEventDelegate(WinEventProc);
        private static IntPtr _hook;

        public static void Exec()
        {
            _hook = SetWinEventHook(
                    EVENT_SYSTEM_FOREGROUND,
                    EVENT_SYSTEM_FOREGROUND,
                    IntPtr.Zero,
                    _proc,
                    0,
                    0,
                    WINEVENT_OUTOFCONTEXT
                );
        }

        static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            Evented?.Invoke(null, new NfWinEventArgs() {
                HWND = hwnd
            });
        }
    }
}
