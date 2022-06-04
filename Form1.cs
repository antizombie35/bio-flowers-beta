using System;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

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
        
        //guessing
        public static int guessState = 0;


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
            rawFlowers = System.IO.File.ReadAllLines(@"flowers.flist");             //raw flowers
            string rawflowersIndex = System.IO.File.ReadAllText(@"flowers.flist");  //raw index
            flowerIndex = rawFlowers[0].Split(',');

            string flowerIndexRaw = Regex.Replace(rawflowersIndex, "(?<==).*(?=\n)", "").Replace(" =","").Replace("\n",",");       //*
            flowerIndexRaw = flowerIndexRaw.Remove(flowerIndexRaw.Length-1);
            flowerIndexRaw = flowerIndexRaw.Remove(0,0);
            flowerIndex = flowerIndexRaw.Split(',');
            Console.WriteLine("r= " + flowerIndexRaw);
            flowersN = rawFlowers.Length;
            isReady = true;
        }
        
        public void Question()
        {
            Question:
            try
            {
                rAnsIndex = r.Next(0, flowersN); //roll index
                rAns = flowerIndex[rAnsIndex]; //find linked word
                Console.WriteLine(rAns);
                linkAnsLine = rawFlowers[rAnsIndex]; //line linkde by index
                rAnsLinks = linkAnsLine.Split(','); //split line to strings
                rAnsLink = rAnsLinks[r.Next(0, rAnsLinks.Length)]; //ch link
                Console.WriteLine(rAnsLink);
                picBoxFlower.Load(rAnsLink);

                rBut = r.Next(1, 3);
                wAnsIndex = r.Next(0, flowersN);
                if (rAnsIndex == wAnsIndex)
                {
                    goto Question;
                }

                wAns = flowerIndex[wAnsIndex];
                if (rBut == 1)
                {
                    ans1But.Text = rAns;
                    ans2But.Text = wAns;
                }
                else
                {
                    ans1But.Text = wAns;
                    ans2But.Text = rAns;
                }
            }
            catch
            {
                Console.WriteLine("error");
                goto Question;
            }


        }
        
        private void StartABBut_Click(object sender, EventArgs e)
        {
            if (isReady)
            {
                ans1But.Visible = true;
                ans2But.Visible = true;
                StartBut.Visible = false;
                startInfo.Visible = false;
                rAnsCLabel.Visible = true;
                wAnsCLabel.Visible = true;
                StartGuessingBut.Visible = false;
                GuessNextBut.Visible = false;
                SupportLinkLab.Visible = false;
                Question();
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

        private void StartGuessingBut_Click(object sender, EventArgs e)
        {
            if (isReady)
            {
                StartBut.Visible = false;
                startInfo.Visible = false;
                StartGuessingBut.Visible = false;
                GuessNextBut.Visible = false;
                GuessNextBut.Visible =true;
                SupportLinkLab.Visible = false;
                Quess();
            }
            else
            {
                MessageBox.Show("obj0 not loaded properly! restart the program");
            }
        }
        
        public void Quess()
        {
        Quess:
            try
            {
                switch(guessState)
                {
                    case 0:
                        rAnsIndex = r.Next(0, flowersN); //roll index
                        rAns = flowerIndex[rAnsIndex]; //find linked word
                        Console.WriteLine(rAns);
                        linkAnsLine = rawFlowers[rAnsIndex]; //line linkde by index
                        rAnsLinks = linkAnsLine.Split(','); //split line to strings
                        rAnsLink = rAnsLinks[r.Next(0, rAnsLinks.Length)]; //ch link
                        Console.WriteLine(rAnsLink);
                        picBoxFlower.Load(rAnsLink);
                        GuessAnsLab.Visible = false;
                        break;

                    case 1:
                        GuessAnsLab.Text = rAns;
                        GuessAnsLab.Visible = true;
                        break;
                    
                    default:
                        MessageBox.Show("error");
                        break;
                }
            }
            catch
            {
                goto Quess;
            }

            guessState++;
            guessState = guessState % 2 ;;
        }

        private void GuessNextBut_Click(object sender, EventArgs e)
        {
            Quess();
        }

        private void SupportLinkLab_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://docs.google.com/spreadsheets/d/1iW5f8xUUuDp5pVIRJRww_3FVjXcryEUrwIsB_akfFrQ/edit?usp=sharing");
        }
    }
}