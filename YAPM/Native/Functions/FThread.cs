using System.Diagnostics;

namespace Native.Functions
{
    public class Thread
    {


        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================


        // ========================================
        // Public properties
        // ========================================

        // ========================================
        // Other public
        // ========================================


        // ========================================
        // Public functions
        // ========================================

        // Return a class from an int (concerning priority)
        public static System.Diagnostics.ThreadPriorityLevel GetThreadPriorityClassFromInt(int priority)
        {
            if (priority >= 15)
                return ThreadPriorityLevel.TimeCritical;
            else if (priority >= 2)
                return ThreadPriorityLevel.Highest;
            else if (priority >= 1)
                return ThreadPriorityLevel.AboveNormal;
            else if (priority >= 0)
                return ThreadPriorityLevel.Normal;
            else if (priority >= -1)
                return ThreadPriorityLevel.BelowNormal;
            else if (priority >= -2)
                return ThreadPriorityLevel.Lowest;
            else
                return ThreadPriorityLevel.Idle;
        }
    }
}

