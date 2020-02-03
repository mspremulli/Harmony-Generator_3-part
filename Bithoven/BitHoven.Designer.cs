namespace WindowsFormsApplication1
{
    partial class BitHoven
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BitHoven));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCurFile = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.prgProcessing = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.selHarmony = new System.Windows.Forms.RadioButton();
            this.selFull = new System.Windows.Forms.RadioButton();
            this.selOriginal = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picKeySig = new System.Windows.Forms.PictureBox();
            this.lblAvgVel = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblAvgVelCaption = new System.Windows.Forms.Label();
            this.lblTempoCaption = new System.Windows.Forms.Label();
            this.timeSigDenom = new System.Windows.Forms.PictureBox();
            this.timeSignNum = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.startBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKeySig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSigDenom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSignNum)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(457, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.saveMenu,
            this.toolStripMenuItem1,
            this.exitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "&File";
            // 
            // openMenu
            // 
            this.openMenu.Image = global::WindowsFormsApplication1.Properties.Resources.FileOpen;
            this.openMenu.Name = "openMenu";
            this.openMenu.Size = new System.Drawing.Size(200, 22);
            this.openMenu.Text = "&Open MIDI File...";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Enabled = false;
            this.saveMenu.Image = global::WindowsFormsApplication1.Properties.Resources.FormRegionSave;
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(200, 22);
            this.saveMenu.Text = "&Save Processed File As...";
            this.saveMenu.Click += new System.EventHandler(this.saveMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(197, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(200, 22);
            this.exitMenu.Text = "E&xit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current File:";
            // 
            // lblCurFile
            // 
            this.lblCurFile.AutoSize = true;
            this.lblCurFile.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurFile.Location = new System.Drawing.Point(110, 59);
            this.lblCurFile.Name = "lblCurFile";
            this.lblCurFile.Size = new System.Drawing.Size(107, 15);
            this.lblCurFile.TabIndex = 3;
            this.lblCurFile.Text = "Please open a file...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(110, 97);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(89, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Not Processed. ";
            // 
            // prgProcessing
            // 
            this.prgProcessing.Location = new System.Drawing.Point(293, 119);
            this.prgProcessing.Name = "prgProcessing";
            this.prgProcessing.Size = new System.Drawing.Size(127, 20);
            this.prgProcessing.TabIndex = 6;
            this.prgProcessing.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.saveBtn);
            this.groupBox1.Controls.Add(this.playBtn);
            this.groupBox1.Controls.Add(this.selHarmony);
            this.groupBox1.Controls.Add(this.selFull);
            this.groupBox1.Controls.Add(this.selOriginal);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 244);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 137);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // saveBtn
            // 
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Image = global::WindowsFormsApplication1.Properties.Resources.FormRegionSave;
            this.saveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveBtn.Location = new System.Drawing.Point(274, 59);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(127, 27);
            this.saveBtn.TabIndex = 5;
            this.saveBtn.Text = "Save";
            this.toolTip1.SetToolTip(this.saveBtn, "Click here to save the chosen selection to disk.");
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Enabled = false;
            this.playBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Image = global::WindowsFormsApplication1.Properties.Resources._25705247;
            this.playBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playBtn.Location = new System.Drawing.Point(274, 22);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(127, 27);
            this.playBtn.TabIndex = 4;
            this.playBtn.Text = "Play";
            this.toolTip1.SetToolTip(this.playBtn, "Click here to play the chosen selection.");
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // selHarmony
            // 
            this.selHarmony.AutoSize = true;
            this.selHarmony.Enabled = false;
            this.selHarmony.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selHarmony.Location = new System.Drawing.Point(28, 85);
            this.selHarmony.Name = "selHarmony";
            this.selHarmony.Size = new System.Drawing.Size(103, 19);
            this.selHarmony.TabIndex = 3;
            this.selHarmony.Text = "Harmony Only";
            this.toolTip1.SetToolTip(this.selHarmony, "Play back only the processed harmony (no melody). ");
            this.selHarmony.UseVisualStyleBackColor = true;
            this.selHarmony.CheckedChanged += new System.EventHandler(this.selHarmony_CheckedChanged);
            // 
            // selFull
            // 
            this.selFull.AutoSize = true;
            this.selFull.Enabled = false;
            this.selFull.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selFull.Location = new System.Drawing.Point(28, 59);
            this.selFull.Name = "selFull";
            this.selFull.Size = new System.Drawing.Size(118, 19);
            this.selFull.TabIndex = 2;
            this.selFull.Text = "Harmonized MIDI";
            this.toolTip1.SetToolTip(this.selFull, "Play the results of the harmonization process, including the melody and harmony.");
            this.selFull.UseVisualStyleBackColor = true;
            this.selFull.CheckedChanged += new System.EventHandler(this.selFull_CheckedChanged);
            // 
            // selOriginal
            // 
            this.selOriginal.AutoSize = true;
            this.selOriginal.Checked = true;
            this.selOriginal.Enabled = false;
            this.selOriginal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selOriginal.Location = new System.Drawing.Point(28, 32);
            this.selOriginal.Name = "selOriginal";
            this.selOriginal.Size = new System.Drawing.Size(95, 19);
            this.selOriginal.TabIndex = 1;
            this.selOriginal.TabStop = true;
            this.selOriginal.Text = "Original MIDI";
            this.toolTip1.SetToolTip(this.selOriginal, "Plays the melody of the originally selected file. ");
            this.selOriginal.UseVisualStyleBackColor = true;
            this.selOriginal.CheckedChanged += new System.EventHandler(this.selOriginal_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picKeySig);
            this.panel1.Controls.Add(this.lblAvgVel);
            this.panel1.Controls.Add(this.lblTempo);
            this.panel1.Controls.Add(this.lblAvgVelCaption);
            this.panel1.Controls.Add(this.lblTempoCaption);
            this.panel1.Controls.Add(this.timeSigDenom);
            this.panel1.Controls.Add(this.timeSignNum);
            this.panel1.Location = new System.Drawing.Point(18, 156);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(429, 82);
            this.panel1.TabIndex = 12;
            // 
            // picKeySig
            // 
            this.picKeySig.Location = new System.Drawing.Point(65, 17);
            this.picKeySig.Name = "picKeySig";
            this.picKeySig.Size = new System.Drawing.Size(92, 46);
            this.picKeySig.TabIndex = 9;
            this.picKeySig.TabStop = false;
            this.toolTip1.SetToolTip(this.picKeySig, "This is the key signature of the music.");
            // 
            // lblAvgVel
            // 
            this.lblAvgVel.AutoSize = true;
            this.lblAvgVel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgVel.Location = new System.Drawing.Point(220, 37);
            this.lblAvgVel.Name = "lblAvgVel";
            this.lblAvgVel.Size = new System.Drawing.Size(12, 15);
            this.lblAvgVel.TabIndex = 8;
            this.lblAvgVel.Text = "?";
            this.toolTip1.SetToolTip(this.lblAvgVel, "This is the average velocity of the notes. ");
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(220, 15);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(12, 15);
            this.lblTempo.TabIndex = 7;
            this.lblTempo.Text = "?";
            this.toolTip1.SetToolTip(this.lblTempo, "This is the temp of the music in beats per minute (BPM). ");
            // 
            // lblAvgVelCaption
            // 
            this.lblAvgVelCaption.AutoSize = true;
            this.lblAvgVelCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvgVelCaption.Location = new System.Drawing.Point(165, 37);
            this.lblAvgVelCaption.Name = "lblAvgVelCaption";
            this.lblAvgVelCaption.Size = new System.Drawing.Size(56, 15);
            this.lblAvgVelCaption.TabIndex = 6;
            this.lblAvgVelCaption.Text = "Avg. Vel:";
            // 
            // lblTempoCaption
            // 
            this.lblTempoCaption.AutoSize = true;
            this.lblTempoCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempoCaption.Location = new System.Drawing.Point(165, 15);
            this.lblTempoCaption.Name = "lblTempoCaption";
            this.lblTempoCaption.Size = new System.Drawing.Size(49, 15);
            this.lblTempoCaption.TabIndex = 5;
            this.lblTempoCaption.Text = "Tempo:";
            // 
            // timeSigDenom
            // 
            this.timeSigDenom.Location = new System.Drawing.Point(28, 37);
            this.timeSigDenom.Name = "timeSigDenom";
            this.timeSigDenom.Size = new System.Drawing.Size(26, 27);
            this.timeSigDenom.TabIndex = 1;
            this.timeSigDenom.TabStop = false;
            // 
            // timeSignNum
            // 
            this.timeSignNum.Location = new System.Drawing.Point(28, 15);
            this.timeSignNum.Name = "timeSignNum";
            this.timeSignNum.Size = new System.Drawing.Size(26, 27);
            this.timeSignNum.TabIndex = 0;
            this.timeSignNum.TabStop = false;
            this.toolTip1.SetToolTip(this.timeSignNum, "This is the time signature of the music.");
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Bithoven Help";
            // 
            // startBtn
            // 
            this.startBtn.Enabled = false;
            this.startBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Image = global::WindowsFormsApplication1.Properties.Resources._1354422196_Music_Green;
            this.startBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startBtn.Location = new System.Drawing.Point(293, 73);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(128, 39);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start Processing";
            this.startBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.startBtn, "Click here to begin the harmonization process. ");
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // BitHoven
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 395);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.prgProcessing);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblCurFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BitHoven";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bit-hoven";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BitHoven_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picKeySig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSigDenom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSignNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar prgProcessing;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.RadioButton selHarmony;
        private System.Windows.Forms.RadioButton selFull;
        private System.Windows.Forms.RadioButton selOriginal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox timeSignNum;
        private System.Windows.Forms.PictureBox timeSigDenom;
        private System.Windows.Forms.Label lblTempoCaption;
        private System.Windows.Forms.Label lblAvgVelCaption;
        private System.Windows.Forms.Label lblAvgVel;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.PictureBox picKeySig;
        private System.Windows.Forms.ToolTip toolTip1;
   
    }
}

