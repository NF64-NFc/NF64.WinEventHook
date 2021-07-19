using System;

namespace NF64.WinEventHooks.Win32.WinEvent
{
    internal sealed class WinEventHookedEventArgs
    {
        /// <summary>
        /// Specifies the event that occurred. This value is one of the event constants.
        /// </summary>
        public WinEvents EventType { get; }

        /// <summary>
        /// Handle to the window that generates the event,
        /// or NULL if no window is associated with the event.
        /// For example, the mouse pointer is not associated with a window.
        /// </summary>
        public IntPtr WindowHandle { get; }

        /// <summary>
        /// Identifies the object associated with the event.
        /// This is one of the object identifiers or a custom object ID.
        /// </summary>
        public int ObjectId { get; }

        /// <summary>
        /// Identifies whether the event was triggered by an object or a child element of the object.
        /// If this value is CHILDID_SELF, the event was triggered by the object;
        /// otherwise, this value is the child ID of the element that triggered the event.
        /// </summary>
        public int ChildId { get; }

        /// <summary>
        /// Specifies the time, in milliseconds, that the event was generated.
        /// </summary>
        public uint EventMilliseconds { get; }


        public WinEventHookedEventArgs(
                WinEvents eventType,
                IntPtr windowHandle,
                int objectId,
                int childId,
                uint eventMilliseconds
            )
        {
            this.EventType = eventType;
            this.WindowHandle = windowHandle;
            this.ObjectId = objectId;
            this.ChildId = childId;
            this.EventMilliseconds = eventMilliseconds;
        }
    }
}
