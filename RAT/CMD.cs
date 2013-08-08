using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace RAT
{
    class CMD
    {
        public CMD() { }

        public enum State { Idle, Waiting };
        private State _State = State.Idle;
        Process _Process;

        public State CurState
        {
            get { return _State; }
        }

        public string Run(string command)
        {
            if (_State == State.Idle)
            {
                _Process = new Process();
                _Process.StartInfo = new ProcessStartInfo("cmd", "/c " + command)
                {
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = false
                };
                _Process.OutputDataReceived += new DataReceivedEventHandler(DataReceived);

                _Process.Start();
                _Process.BeginOutputReadLine();
                while(_Process.WaitForInputIdle()) {
                    _State = State.Waiting;
                }
                
            }

            string output = "";
            /*
            string output = ">>" + command + "\n";
            output += _Process.StandardOutput.ReadToEnd();
            string error = _Process.StandardError.ReadToEnd();
            output += error;
            output += "\n";*/
            _Process.WaitForExit();
            _Process.Close();
            _State = State.Idle;
            return output;
        }

        private void DataReceived(object sender, DataReceivedEventArgs e)
        {
            MessageBox.Show(e.Data);
        }
    }
}
