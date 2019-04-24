using Common;
using System;

namespace Scripting.Items
{
    public class Command
    {

        // This is an example of command :
        // process,kill,pid,eq,520
        // litteral : object,action,condition,operator,name,arg1

        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================

        // Object
        private Enums.Object _object;

        // Operation
        private string _action;

        // Condition
        private Enums.Condition _condition;

        // Operator
        private Enums.Operator _operator;

        // Name
        private string _name;

        // Arg1
        private string _arg1;



        // ========================================
        // Public properties
        // ========================================

        // Object
        public Enums.Object Object
        {
            get
            {
                return _object;
            }
            set
            {
                _object = value;
            }
        }

        // Action
        public string Action
        {
            get
            {
                return _action;
            }
            set
            {
                _action = value;
            }
        }

        // User
        public Enums.Condition Condition
        {
            get
            {
                return _condition;
            }
            set
            {
                _condition = value;
            }
        }

        // Password
        public Enums.Operator Operator
        {
            get
            {
                return _operator;
            }
            set
            {
                _operator = value;
            }
        }

        // Name
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        // Arg1
        public string Arg1
        {
            get
            {
                return _arg1;
            }
            set
            {
                _arg1 = value;
            }
        }



        // ========================================
        // Public functions
        // ========================================

        // Constructors
        public Command(string commandLine)
        {
            // Here we parse the line
            // Example :
            // process,kill,name,eq,explorer.exe
            // litteral : object,action,condition,operator,name,arg1
            try
            {
                string[] s = commandLine.Split(System.Convert.ToChar(","));
                this.Object = (Enums.Object)Enum.Parse(typeof(Enums.Object), s[0], true);
                this.Action = s[1];
                this.Condition = (Enums.Condition)Enum.Parse(typeof(Enums.Condition), s[2], true);
                this.Operator = (Enums.Operator)Enum.Parse(typeof(Enums.Operator), s[3], true);
                this.Name = s[4];
                this.Arg1 = s[5];
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }

        // Execute command
        public void Execute(cConnection connection)
        {
            switch (this.Object)
            {
                case Enums.Object.Process:
                    {
                        // Process
                        Enums.ProcessOperation sAction = (Enums.ProcessOperation)Enum.Parse(typeof(Enums.ProcessOperation), this.Action, true);
                        switch (sAction)
                        {
                            case Enums.ProcessOperation.Kill:
                                {
                                    int pid = int.Parse(this.Name);
                                    this.Kill(pid, connection);
                                    break;
                                }

                            case Enums.ProcessOperation.KillTree:
                                {
                                    break;
                                }

                            case Enums.ProcessOperation.Pause:
                                {
                                    break;
                                }

                            case Enums.ProcessOperation.Resume:
                                {
                                    break;
                                }

                            case Enums.ProcessOperation.SetAffinity:
                                {
                                    break;
                                }

                            case Enums.ProcessOperation.SetPriority:
                                {
                                    break;
                                }
                        }

                        break;
                    }

                case Enums.Object.Service:
                    {
                        break;
                    }
            }
        }


        // ========================================
        // Private functions
        // ========================================


        private asyncCallbackProcKill _killP;
        private int Kill(int pid, cConnection con)
        {
            if (_killP == null)
                _killP = new asyncCallbackProcKill(new asyncCallbackProcKill.HasKilled(killDone), ref new cProcessConnection(null, ref con, ref null));

            System.Threading.WaitCallback t = new System.Threading.WaitCallback(_killP.Process());
            int newAction = cGeneralObject.GetActionCount();

            System.Threading.ThreadPool.QueueUserWorkItem(t, new asyncCallbackProcKill.poolObj(pid, newAction));
        }
        private void killDone(bool Success, int pid, string msg, int actionNumber)
        {
        }
    }
}

