
namespace Scripting
{
    public class Enums
    {

        // Operators
        public enum Operator
        {
            eq          // =
,
            neq         // <>
,
            gt          // >
,
            lt          // <
,
            goe         // >=
,
            loe         // <=
,
            cont        // contains (for a string)
        }

        // Objects
        public enum Object
        {
            Process,
            Service
        }

        // Condition
        public enum Condition
        {
            Name,
            Pid
        }

        // Machine types
        public enum MachineType
        {
            Local,
            Wmi
        }

        // Process operation
        public enum ProcessOperation
        {
            Kill,
            KillTree,
            Pause,
            Resume,
            SetPriority     // arg1 (0 (idle), ..., 5 (real time))
,
            SetAffinity     // arg1 (1,2...)
        }

        // Service operation
        public enum ServiceOperation
        {
            Start,
            Stop,
            Delete,
            Pause,
            Resume,
            SetStartType    // arg1 (0 (disabled), 1 (on demand), 2 (auto))
        }
    }
}

