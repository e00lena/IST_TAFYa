namespace IST_TAiFYa
{
    partial class StartTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartTest));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbQuestion = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tbAnswerFree = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MI_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clbAnswersMult = new System.Windows.Forms.CheckedListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.clbAnswersOne = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MI_Previous = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Next = new System.Windows.Forms.ToolStripMenuItem();
            this.tbTime = new System.Windows.Forms.ToolStripTextBox();
            this.timeLabel = new System.Windows.Forms.ToolStripTextBox();
            this.MI_Finish = new System.Windows.Forms.ToolStripMenuItem();
            this.аToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 220);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbQuestion
            // 
            this.tbQuestion.BackColor = System.Drawing.Color.White;
            this.tbQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbQuestion.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQuestion.Location = new System.Drawing.Point(0, 0);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.ReadOnly = true;
            this.tbQuestion.Size = new System.Drawing.Size(379, 220);
            this.tbQuestion.TabIndex = 2;
            this.tbQuestion.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbAnswerFree);
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(705, 130);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Свободный ответ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tbAnswerFree
            // 
            this.tbAnswerFree.ContextMenuStrip = this.contextMenuStrip1;
            this.tbAnswerFree.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAnswerFree.Location = new System.Drawing.Point(3, 3);
            this.tbAnswerFree.Name = "tbAnswerFree";
            this.tbAnswerFree.Size = new System.Drawing.Size(697, 124);
            this.tbAnswerFree.TabIndex = 20;
            this.tbAnswerFree.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Insert});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 26);
            // 
            // MI_Insert
            // 
            this.MI_Insert.Name = "MI_Insert";
            this.MI_Insert.Size = new System.Drawing.Size(167, 22);
            this.MI_Insert.Text = "Вставить символ";
            this.MI_Insert.Click += new System.EventHandler(this.MI_Insert_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.clbAnswersMult);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(705, 130);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Несколько ответов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clbAnswersMult
            // 
            this.clbAnswersMult.CheckOnClick = true;
            this.clbAnswersMult.ColumnWidth = 320;
            this.clbAnswersMult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAnswersMult.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clbAnswersMult.FormattingEnabled = true;
            this.clbAnswersMult.Location = new System.Drawing.Point(3, 3);
            this.clbAnswersMult.MultiColumn = true;
            this.clbAnswersMult.Name = "clbAnswersMult";
            this.clbAnswersMult.Size = new System.Drawing.Size(699, 124);
            this.clbAnswersMult.TabIndex = 32;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(713, 162);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.clbAnswersOne);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 130);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Один ответ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // clbAnswersOne
            // 
            this.clbAnswersOne.CheckOnClick = true;
            this.clbAnswersOne.ColumnWidth = 320;
            this.clbAnswersOne.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbAnswersOne.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clbAnswersOne.FormattingEnabled = true;
            this.clbAnswersOne.Location = new System.Drawing.Point(3, 3);
            this.clbAnswersOne.MultiColumn = true;
            this.clbAnswersOne.Name = "clbAnswersOne";
            this.clbAnswersOne.Size = new System.Drawing.Size(699, 124);
            this.clbAnswersOne.TabIndex = 31;
            this.clbAnswersOne.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ClbAnswersOne_ItemCheck);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Controls.Add(this.menuStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(713, 417);
            this.splitContainer1.SplitterDistance = 220;
            this.splitContainer1.TabIndex = 10;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tbQuestion);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Size = new System.Drawing.Size(713, 220);
            this.splitContainer2.SplitterDistance = 379;
            this.splitContainer2.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Previous,
            this.MI_Next,
            this.tbTime,
            this.timeLabel,
            this.MI_Finish,
            this.аToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 160);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(713, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MI_Previous
            // 
            this.MI_Previous.Image = ((System.Drawing.Image)(resources.GetObject("MI_Previous.Image")));
            this.MI_Previous.Name = "MI_Previous";
            this.MI_Previous.Size = new System.Drawing.Size(161, 29);
            this.MI_Previous.Text = "Предыдущий вопрос";
            this.MI_Previous.Click += new System.EventHandler(this.MI_Previous_Click);
            // 
            // MI_Next
            // 
            this.MI_Next.Image = ((System.Drawing.Image)(resources.GetObject("MI_Next.Image")));
            this.MI_Next.Name = "MI_Next";
            this.MI_Next.Size = new System.Drawing.Size(155, 29);
            this.MI_Next.Text = "Следующий вопрос";
            this.MI_Next.Click += new System.EventHandler(this.MI_Next_Click);
            // 
            // tbTime
            // 
            this.tbTime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tbTime.BackColor = System.Drawing.SystemColors.Window;
            this.tbTime.Name = "tbTime";
            this.tbTime.ReadOnly = true;
            this.tbTime.Size = new System.Drawing.Size(50, 29);
            // 
            // timeLabel
            // 
            this.timeLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(100, 29);
            this.timeLabel.Text = "Осталось минут:";
            // 
            // MI_Finish
            // 
            this.MI_Finish.Image = ((System.Drawing.Image)(resources.GetObject("MI_Finish.Image")));
            this.MI_Finish.Name = "MI_Finish";
            this.MI_Finish.Size = new System.Drawing.Size(105, 29);
            this.MI_Finish.Text = "Завершить";
            this.MI_Finish.Click += new System.EventHandler(this.MI_Finish_Click);
            // 
            // аToolStripMenuItem
            // 
            this.аToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.аToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("аToolStripMenuItem.Image")));
            this.аToolStripMenuItem.Name = "аToolStripMenuItem";
            this.аToolStripMenuItem.Size = new System.Drawing.Size(37, 29);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // StartTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 421);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Прохождение теста";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartTest_FormClosing);
            this.Load += new System.EventHandler(this.StartTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox tbQuestion;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox tbAnswerFree;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckedListBox clbAnswersOne;
        private System.Windows.Forms.CheckedListBox clbAnswersMult;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MI_Previous;
        private System.Windows.Forms.ToolStripMenuItem MI_Next;
        private System.Windows.Forms.ToolStripTextBox tbTime;
        private System.Windows.Forms.ToolStripTextBox timeLabel;
        private System.Windows.Forms.ToolStripMenuItem MI_Finish;
        private System.Windows.Forms.ToolStripMenuItem аToolStripMenuItem;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MI_Insert;
    }
}