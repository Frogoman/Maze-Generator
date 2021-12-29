
namespace Laberynth
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.canvas = new System.Windows.Forms.Panel();
            this.gamePaused = new System.Windows.Forms.Label();
            this.player = new System.Windows.Forms.PictureBox();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.BackCounter = new System.Windows.Forms.Timer(this.components);
            this.counter = new System.Windows.Forms.Label();
            this.secondCounter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.canvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Controls.Add(this.gamePaused);
            this.canvas.Controls.Add(this.player);
            this.canvas.Dock = System.Windows.Forms.DockStyle.Top;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(648, 555);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // gamePaused
            // 
            this.gamePaused.BackColor = System.Drawing.Color.DarkRed;
            this.gamePaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gamePaused.ForeColor = System.Drawing.Color.Yellow;
            this.gamePaused.Location = new System.Drawing.Point(195, 229);
            this.gamePaused.Name = "gamePaused";
            this.gamePaused.Size = new System.Drawing.Size(124, 31);
            this.gamePaused.TabIndex = 1;
            this.gamePaused.Text = "Game paused";
            this.gamePaused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.player.Location = new System.Drawing.Point(241, 163);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(48, 52);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // BackCounter
            // 
            this.BackCounter.Enabled = true;
            this.BackCounter.Interval = 1000;
            this.BackCounter.Tick += new System.EventHandler(this.BackCounter_Tick);
            // 
            // counter
            // 
            this.counter.AutoSize = true;
            this.counter.Dock = System.Windows.Forms.DockStyle.Left;
            this.counter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.counter.Location = new System.Drawing.Point(0, 0);
            this.counter.Name = "counter";
            this.counter.Size = new System.Drawing.Size(63, 20);
            this.counter.TabIndex = 1;
            this.counter.Text = "Moves: ";
            // 
            // secondCounter
            // 
            this.secondCounter.AutoSize = true;
            this.secondCounter.Dock = System.Windows.Forms.DockStyle.Right;
            this.secondCounter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.secondCounter.Location = new System.Drawing.Point(542, 0);
            this.secondCounter.Name = "secondCounter";
            this.secondCounter.Size = new System.Drawing.Size(106, 20);
            this.secondCounter.TabIndex = 2;
            this.secondCounter.Text = "Seconds left: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.secondCounter);
            this.panel1.Controls.Add(this.counter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 567);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 20);
            this.panel1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(648, 587);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyNotPressed);
            this.canvas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Timer BackCounter;
        private System.Windows.Forms.Label secondCounter;
        private System.Windows.Forms.Label counter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label gamePaused;
    }
}

