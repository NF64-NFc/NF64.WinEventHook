namespace NF64.WinEventHooks.Win32.WinEvent
{
    internal enum WinEventFlags : uint
    {
        /// <summary>
        /// Events are ASYNC
        /// </summary>
        WINEVENT_OUTOFCONTEXT = 0x0000,

        /// <summary>
        /// Don't call back for events on installer's thread
        /// </summary>
        WINEVENT_SKIPOWNTHREAD = 0x0001,

        /// <summary>
        /// Don't call back for events on installer's process
        /// </summary>
        WINEVENT_SKIPOWNPROCESS = 0x0002,

        /// <summary>
        /// Events are SYNC, this causes your dll to be injected into every process
        /// </summary>
        WINEVENT_INCONTEXT = 0x0004,
    }
}
