namespace flowers
{
    partial class main
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.winMoving = new System.Windows.Forms.PictureBox();
            this.butExit = new System.Windows.Forms.Button();
            this.butMinimalizeWin = new System.Windows.Forms.Button();
            this.picBoxFlower = new System.Windows.Forms.PictureBox();
            this.StartBut = new System.Windows.Forms.Button();
            this.ans1But = new System.Windows.Forms.Button();
            this.ans2But = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.winMoving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFlower)).BeginInit();
            this.SuspendLayout();
            // 
            // winMoving
            // 
            this.winMoving.BackColor = System.Drawing.SystemColors.ControlDark;
            this.winMoving.Location = new System.Drawing.Point(0, 0);
            this.winMoving.Name = "winMoving";
            this.winMoving.Size = new System.Drawing.Size(751, 24);
            this.winMoving.TabIndex = 0;
            this.winMoving.TabStop = false;
            this.winMoving.MouseDown += new System.Windows.Forms.MouseEventHandler(this.winMoving_MouseDown);
            // 
            // butExit
            // 
            this.butExit.Location = new System.Drawing.Point(800, 8);
            this.butExit.Margin = new System.Windows.Forms.Padding(2);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(25, 25);
            this.butExit.TabIndex = 1;
            this.butExit.Text = "X";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butMinimalizeWin
            // 
            this.butMinimalizeWin.Location = new System.Drawing.Point(771, 8);
            this.butMinimalizeWin.Margin = new System.Windows.Forms.Padding(2);
            this.butMinimalizeWin.Name = "butMinimalizeWin";
            this.butMinimalizeWin.Size = new System.Drawing.Size(25, 25);
            this.butMinimalizeWin.TabIndex = 2;
            this.butMinimalizeWin.Text = "_";
            this.butMinimalizeWin.UseVisualStyleBackColor = true;
            this.butMinimalizeWin.Click += new System.EventHandler(this.butMinimalizeWin_Click);
            // 
            // picBoxFlower
            // 
            this.picBoxFlower.Location = new System.Drawing.Point(12, 30);
            this.picBoxFlower.Name = "picBoxFlower";
            this.picBoxFlower.Size = new System.Drawing.Size(588, 309);
            this.picBoxFlower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxFlower.TabIndex = 3;
            this.picBoxFlower.TabStop = false;
            // 
            // StartBut
            // 
            this.StartBut.Location = new System.Drawing.Point(12, 430);
            this.StartBut.Margin = new System.Windows.Forms.Padding(2);
            this.StartBut.Name = "StartBut";
            this.StartBut.Size = new System.Drawing.Size(827, 42);
            this.StartBut.TabIndex = 5;
            this.StartBut.Text = "START";
            this.StartBut.UseVisualStyleBackColor = true;
            this.StartBut.Click += new System.EventHandler(this.StartBut_Click);
            // 
            // ans1But
            // 
            this.ans1But.Location = new System.Drawing.Point(11, 344);
            this.ans1But.Margin = new System.Windows.Forms.Padding(2);
            this.ans1But.Name = "ans1But";
            this.ans1But.Size = new System.Drawing.Size(412, 195);
            this.ans1But.TabIndex = 6;
            this.ans1But.Text = "Ans1";
            this.ans1But.UseVisualStyleBackColor = true;
            this.ans1But.Visible = false;
            this.ans1But.Click += new System.EventHandler(this.ans1But_Click);
            // 
            // ans2But
            // 
            this.ans2But.Location = new System.Drawing.Point(427, 344);
            this.ans2But.Margin = new System.Windows.Forms.Padding(2);
            this.ans2But.Name = "ans2But";
            this.ans2But.Size = new System.Drawing.Size(412, 195);
            this.ans2But.TabIndex = 7;
            this.ans2But.Text = "Ans2";
            this.ans2But.UseVisualStyleBackColor = true;
            this.ans2But.Visible = false;
            this.ans2But.Click += new System.EventHandler(this.ans2But_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.StartBut);
            this.Controls.Add(this.ans2But);
            this.Controls.Add(this.ans1But);
            this.Controls.Add(this.picBoxFlower);
            this.Controls.Add(this.butMinimalizeWin);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.winMoving);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bio flowers";
            this.Load += new System.EventHandler(this.mainLoad);
            ((System.ComponentModel.ISupportInitialize)(this.winMoving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxFlower)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox winMoving;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butMinimalizeWin;
        private System.Windows.Forms.PictureBox picBoxFlower;
        private System.Windows.Forms.Button StartBut;
        private System.Windows.Forms.Button ans1But;
        private System.Windows.Forms.Button ans2But;
    }
}

