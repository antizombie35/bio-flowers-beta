using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace flowers
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        
        //public vars
        public static string[] rawFlowers = {};
        public static string rAns = "";
        public static int rAnsIndex = 0;
        public static int rBut = 0;
        public static string linkAnsLine = "";
        public static string[] rAnsLinks = {};
        public static string rAnsLink = "";
        bool isReady = false;

        public static int wAnsIndex = 0;
        public static string wAns = ""; 
        
        public static int rAnsN = 0;
        public static int wAnsN = 0;

        public static Random r = new Random();
        public static string[] flowerIndex = {};
        public static int flowersN = 0;


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
            Icon = new Icon(@"icon.ico");
            rawFlowers = System.IO.File.ReadAllLines(@"flowers.flist");
            flowerIndex = rawFlowers[0].Split(',');
            flowersN = rawFlowers.Length;
            isReady = true;
        }
        
        public void Question()
        {
            rAnsIndex = r.Next(1, flowersN);
            rAns = flowerIndex[rAnsIndex]; //roll index
            //Console.WriteLine(rAns);
            linkAnsLine = rawFlowers[rAnsIndex]; //line linkde by index
            rAnsLinks = linkAnsLine.Split(','); //split line to strings
            rAnsLink = rAnsLinks[r.Next(1, rAnsLinks.Length)]; //ch link
            //Console.WriteLine(rAnsLink);
            picBoxFlower.Load(rAnsLink);

            rBut = r.Next(1, 3);
            wAnsCh:
            wAnsIndex = r.Next(1, flowersN);
            if (rAnsIndex == wAnsIndex)
            {
                goto wAnsCh;
            }

            wAns = flowerIndex[wAnsIndex];
            if (rBut == 1)
            {
                ans1But.Text = rAns;
                ans2But.Text = wAns;
            }else{
                ans1But.Text = wAns;
                ans2But.Text = rAns;
            }

        }
        
        private void StartBut_Click(object sender, EventArgs e)
        {
            if (isReady)
            {
                Question();
                ans1But.Visible = true;
                ans2But.Visible = true;
                StartBut.Visible = false;
                startInfo.Visible = false;
                rAnsCLabel.Visible = true;
                wAnsCLabel.Visible = true;
            }
            else{
                MessageBox.Show("obj0 not loaded properly! restart the program");
            }

        }

        private void ans1But_Click(object sender, EventArgs e)
        {
            verify(1);
        }

        private void ans2But_Click(object sender, EventArgs e)
        {
            verify(2);
        }

        public void verify(int ans)
        {
            if (ans == rBut)
            {
                rAnsN++;
                rAnsCLabel.Text = "RIGHT: " + rAnsN.ToString();
            }
            else
            {
                wAnsN++;
                wAnsCLabel.Text = "WRONG: " + wAnsN.ToString();
            }
            Question();
        }
    }
}