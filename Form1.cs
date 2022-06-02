using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Forms;
using System.Net;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Json.Net;
using Newtonsoft.Json;

namespace flowers
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        //public vars
        public static string rAns = "";
        public static Dictionary<string, string> dict;
        public static Random r = new Random();

        #region drag window part
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        private void butExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void winMoving_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void butMinimalizeWin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void mainLoad(object sender, EventArgs e)
        {

            string json = @"{""key1"":""https://dm0qx8t0i9gc9.cloudfront.net/thumbnails/video/YSvEcxy/videoblocks-corvus-corax-clarionensis-large-common-raven-head-closeup-black-raven-eyes-and-beak-macro-wild-bird-close-up-black-crow-head-close-up-black-crow-looking-straight-into-camera_rlugsa6m8_thumbnail-1080_01.png"",""key2"":""https://www.bylinkyprovsechny.cz/images/byliny-bylinky-fotografie-obrazek/kokoska-pastusi-tobolka-ucinky-na-zdravi-co-leci-pouziti-uzivani.jpg""}";
            dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            Console.WriteLine("dict ready");
        }

        private void StartBut_Click(object sender, EventArgs e)
        {

            picBoxFlower.Load(dict.ElementAt(r.Next(0, dict.Count)).Value);
        }

        private void ans1But_Click(object sender, EventArgs e)
        {

        }

        private void ans2But_Click(object sender, EventArgs e)
        {

        }
    }
}