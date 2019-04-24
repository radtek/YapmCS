using Microsoft.VisualBasic;
using Common;
using System.Collections.Generic;
using System;

namespace Scripting
{
    public class Engine
    {

        // ========================================
        // Private constants
        // ========================================


        // ========================================
        // Private attributes
        // ========================================

        // Script (as plain text)
        private string _script;

        // Machines
        private List<Scripting.Items.Machine> _machines = new List<Scripting.Items.Machine>();

        // Commands 
        private List<Scripting.Items.Command> _commands = new List<Scripting.Items.Command>();

        // Threads
        private List<System.Threading.Thread> _threads = new List<System.Threading.Thread>();



        // ========================================
        // Public properties
        // ========================================

        // Script (as plain text)
        public string Script
        {
            get
            {
                return _script;
            }
            set
            {
                _script = value;
            }
        }

        // List of machines
        public List<Scripting.Items.Machine> Machines
        {
            get
            {
                return _machines;
            }
            set
            {
                _machines = value;
            }
        }

        // Commands 
        public List<Scripting.Items.Command> Commands
        {
            get
            {
                return _commands;
            }
            set
            {
                _commands = value;
            }
        }



        // ========================================
        // Public functions
        // ========================================

        // Constructors
        public Engine(string scriptFilePath)
        {
            try
            {
                _script = System.IO.File.ReadAllText(scriptFilePath, System.Text.Encoding.Default);
            }
            catch (Exception ex)
            {
                Misc.ShowDebugError(ex);
            }
        }
        public Engine()
        {
        }

        // Execute the script
        public void Execute()
        {
            if (CheckGrammar())
            {
                this.Build();
                this.Launch();
            }
        }

        // Verify the grammar
        public bool CheckGrammar()
        {
            return this.Verify();
        }



        // ========================================
        // Private functions
        // ========================================

        // Check grammar
        public bool Verify(ref string msg = null)
        {
            return true; // TOCHANGE
        }

        // Parse and build the script
        private void Build()
        {

            // Get the script as lines
            _script = _script.Replace(Constants.vbCr, Constants.vbNullString);
            _script = _script.Replace(Constants.vbLf, Constants.vbNewLine);
            string[] _s = _script.Split(System.Convert.ToChar(Constants.vbNewLine));
            List<string> _lines = new List<string>();
            var loopTo = _s.Length - 1;

            // All to lowercase
            for (int x = 0; x <= loopTo; x++)
            {
                if ((_s[x] != null) && (_s[x].Length > 1))
                    _lines.Add(_s[x].ToLowerInvariant().Trim());
            }

            var loopTo1 = _lines.Count - 1;

            // Retrieve the list of machines
            for (int x = 0; x <= loopTo1; x++)
            {
                if (_lines[x] == "with machines")
                {
                    x += 1;
                    // Ok, now we create some machines with the different lines
                    while (_lines[x] != "end with")
                    {
                        _machines.Add(new Items.Machine(_lines[x]));
                        x += 1;
                    }
                }
            }

            var loopTo2 = _lines.Count - 1;

            // Retrieve the list of commands
            for (int x = 0; x <= loopTo2; x++)
            {
                if (_lines[x] == "end with")
                {
                    x += 1;
                    // Ok, create commands
                    while (x != _lines.Count)
                    {
                        _commands.Add(new Items.Command(_lines[x]));
                        x += 1;
                    }
                }
            }

            // Create a new thread for each machine
            foreach (Scripting.Items.Machine it in _machines)
                _threads.Add(new System.Threading.Thread(it.ExecuteCommands()));
        }

        // Launch now
        private void Launch()
        {
            foreach (System.Threading.Thread th in _threads)
                th.Start(_commands);
        }
    }
}

