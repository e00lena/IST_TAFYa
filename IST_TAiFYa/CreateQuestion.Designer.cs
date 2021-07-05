namespace IST_TAiFYa
{
    partial class CreateQuestion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateQuestion));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadPicture = new System.Windows.Forms.Button();
            this.tbQuestion = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MI_InsertInQuestion = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.numPointsFree = new System.Windows.Forms.NumericUpDown();
            this.tbAnswerFree = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MI_InsertIntoTbAnswer = new System.Windows.Forms.ToolStripMenuItem();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numPointsMult = new System.Windows.Forms.NumericUpDown();
            this.btnClearAnswerMult = new System.Windows.Forms.Button();
            this.btnDeleteAnswerMult = new System.Windows.Forms.Button();
            this.tbAnswerMult = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddAnswerMult = new System.Windows.Forms.Button();
            this.clbAnswers = new System.Windows.Forms.CheckedListBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbAnswerOne = new System.Windows.Forms.RichTextBox();
            this.numPointsOne = new System.Windows.Forms.NumericUpDown();
            this.labelRightAnswer = new System.Windows.Forms.Label();
            this.cbRightAnswer = new System.Windows.Forms.ComboBox();
            this.lbAnswers = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClearAnswerOne = new System.Windows.Forms.Button();
            this.btnDeleteAnswerOne = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddAnswerOne = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsFree)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsMult)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsOne)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(349, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 220);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadPicture
            // 
            this.btnLoadPicture.Location = new System.Drawing.Point(467, 238);
            this.btnLoadPicture.Name = "btnLoadPicture";
            this.btnLoadPicture.Size = new System.Drawing.Size(142, 23);
            this.btnLoadPicture.TabIndex = 1;
            this.btnLoadPicture.Text = "Загрузить картинку";
            this.btnLoadPicture.UseVisualStyleBackColor = true;
            this.btnLoadPicture.Click += new System.EventHandler(this.BtnLoadPicture_Click);
            // 
            // tbQuestion
            // 
            this.tbQuestion.ContextMenuStrip = this.contextMenuStrip1;
            this.tbQuestion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbQuestion.Location = new System.Drawing.Point(12, 12);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(331, 220);
            this.tbQuestion.TabIndex = 2;
            this.tbQuestion.Text = "Введите текст вопроса";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_InsertInQuestion});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(168, 26);
            // 
            // MI_InsertInQuestion
            // 
            this.MI_InsertInQuestion.Name = "MI_InsertInQuestion";
            this.MI_InsertInQuestion.Size = new System.Drawing.Size(167, 22);
            this.MI_InsertInQuestion.Text = "Вставить символ";
            this.MI_InsertInQuestion.Click += new System.EventHandler(this.MI_InsertInQuestion_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(296, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Выберите тип ответа:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.numPointsFree);
            this.tabPage3.Controls.Add(this.tbAnswerFree);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(663, 174);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Свободный ответ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // numPointsFree
            // 
            this.numPointsFree.DecimalPlaces = 1;
            this.numPointsFree.Location = new System.Drawing.Point(343, 24);
            this.numPointsFree.Name = "numPointsFree";
            this.numPointsFree.Size = new System.Drawing.Size(56, 20);
            this.numPointsFree.TabIndex = 34;
            // 
            // tbAnswerFree
            // 
            this.tbAnswerFree.ContextMenuStrip = this.contextMenuStrip2;
            this.tbAnswerFree.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAnswerFree.Location = new System.Drawing.Point(182, 82);
            this.tbAnswerFree.Name = "tbAnswerFree";
            this.tbAnswerFree.Size = new System.Drawing.Size(302, 58);
            this.tbAnswerFree.TabIndex = 20;
            this.tbAnswerFree.Text = "";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_InsertIntoTbAnswer});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(168, 26);
            // 
            // MI_InsertIntoTbAnswer
            // 
            this.MI_InsertIntoTbAnswer.Name = "MI_InsertIntoTbAnswer";
            this.MI_InsertIntoTbAnswer.Size = new System.Drawing.Size(167, 22);
            this.MI_InsertIntoTbAnswer.Text = "Вставить символ";
            this.MI_InsertIntoTbAnswer.Click += new System.EventHandler(this.MI_InsertIntoTbAnswer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(158, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Баллов за правильный ответ:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(179, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Введите текст ответа:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numPointsMult);
            this.tabPage2.Controls.Add(this.btnClearAnswerMult);
            this.tabPage2.Controls.Add(this.btnDeleteAnswerMult);
            this.tabPage2.Controls.Add(this.tbAnswerMult);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnAddAnswerMult);
            this.tabPage2.Controls.Add(this.clbAnswers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(663, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Несколько ответов";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numPointsMult
            // 
            this.numPointsMult.DecimalPlaces = 1;
            this.numPointsMult.Location = new System.Drawing.Point(516, 12);
            this.numPointsMult.Name = "numPointsMult";
            this.numPointsMult.Size = new System.Drawing.Size(56, 20);
            this.numPointsMult.TabIndex = 34;
            // 
            // btnClearAnswerMult
            // 
            this.btnClearAnswerMult.Location = new System.Drawing.Point(451, 146);
            this.btnClearAnswerMult.Name = "btnClearAnswerMult";
            this.btnClearAnswerMult.Size = new System.Drawing.Size(110, 23);
            this.btnClearAnswerMult.TabIndex = 18;
            this.btnClearAnswerMult.Text = "Новый";
            this.btnClearAnswerMult.UseVisualStyleBackColor = false;
            this.btnClearAnswerMult.Click += new System.EventHandler(this.BtnClearAnswerMult_Click);
            // 
            // btnDeleteAnswerMult
            // 
            this.btnDeleteAnswerMult.Location = new System.Drawing.Point(355, 146);
            this.btnDeleteAnswerMult.Name = "btnDeleteAnswerMult";
            this.btnDeleteAnswerMult.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteAnswerMult.TabIndex = 17;
            this.btnDeleteAnswerMult.Text = "Удалить";
            this.btnDeleteAnswerMult.UseVisualStyleBackColor = true;
            this.btnDeleteAnswerMult.Click += new System.EventHandler(this.BtnDeleteAnswerMult_Click);
            // 
            // tbAnswerMult
            // 
            this.tbAnswerMult.ContextMenuStrip = this.contextMenuStrip2;
            this.tbAnswerMult.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbAnswerMult.Location = new System.Drawing.Point(355, 82);
            this.tbAnswerMult.Name = "tbAnswerMult";
            this.tbAnswerMult.Size = new System.Drawing.Size(302, 58);
            this.tbAnswerMult.TabIndex = 16;
            this.tbAnswerMult.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Баллов за правильный ответ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(352, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Введите текст ответа:";
            // 
            // btnAddAnswerMult
            // 
            this.btnAddAnswerMult.Location = new System.Drawing.Point(567, 146);
            this.btnAddAnswerMult.Name = "btnAddAnswerMult";
            this.btnAddAnswerMult.Size = new System.Drawing.Size(90, 23);
            this.btnAddAnswerMult.TabIndex = 12;
            this.btnAddAnswerMult.Text = "Сохранить";
            this.btnAddAnswerMult.UseVisualStyleBackColor = true;
            this.btnAddAnswerMult.Click += new System.EventHandler(this.BtnAddAnswerMult_Click);
            // 
            // clbAnswers
            // 
            this.clbAnswers.CheckOnClick = true;
            this.clbAnswers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clbAnswers.FormattingEnabled = true;
            this.clbAnswers.Location = new System.Drawing.Point(6, 3);
            this.clbAnswers.Name = "clbAnswers";
            this.clbAnswers.Size = new System.Drawing.Size(338, 151);
            this.clbAnswers.TabIndex = 11;
            this.clbAnswers.DoubleClick += new System.EventHandler(this.ClbAnswers_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbAnswerOne);
            this.tabPage1.Controls.Add(this.numPointsOne);
            this.tabPage1.Controls.Add(this.labelRightAnswer);
            this.tabPage1.Controls.Add(this.cbRightAnswer);
            this.tabPage1.Controls.Add(this.lbAnswers);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnClearAnswerOne);
            this.tabPage1.Controls.Add(this.btnDeleteAnswerOne);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.btnAddAnswerOne);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Один ответ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbAnswerOne
            // 
            this.tbAnswerOne.ContextMenuStrip = this.contextMenuStrip2;
            this.tbAnswerOne.Location = new System.Drawing.Point(355, 81);
            this.tbAnswerOne.Name = "tbAnswerOne";
            this.tbAnswerOne.Size = new System.Drawing.Size(302, 60);
            this.tbAnswerOne.TabIndex = 34;
            this.tbAnswerOne.Text = "";
            // 
            // numPointsOne
            // 
            this.numPointsOne.DecimalPlaces = 1;
            this.numPointsOne.Location = new System.Drawing.Point(520, 12);
            this.numPointsOne.Name = "numPointsOne";
            this.numPointsOne.Size = new System.Drawing.Size(56, 20);
            this.numPointsOne.TabIndex = 33;
            // 
            // labelRightAnswer
            // 
            this.labelRightAnswer.AutoSize = true;
            this.labelRightAnswer.Location = new System.Drawing.Point(516, 39);
            this.labelRightAnswer.Name = "labelRightAnswer";
            this.labelRightAnswer.Size = new System.Drawing.Size(60, 13);
            this.labelRightAnswer.TabIndex = 32;
            this.labelRightAnswer.Text = "не выбран";
            // 
            // cbRightAnswer
            // 
            this.cbRightAnswer.FormattingEnabled = true;
            this.cbRightAnswer.Location = new System.Drawing.Point(463, 36);
            this.cbRightAnswer.Name = "cbRightAnswer";
            this.cbRightAnswer.Size = new System.Drawing.Size(47, 21);
            this.cbRightAnswer.TabIndex = 31;
            this.cbRightAnswer.SelectedIndexChanged += new System.EventHandler(this.CbRightAnswer_SelectedIndexChanged);
            // 
            // lbAnswers
            // 
            this.lbAnswers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbAnswers.FormattingEnabled = true;
            this.lbAnswers.ItemHeight = 19;
            this.lbAnswers.Location = new System.Drawing.Point(6, 6);
            this.lbAnswers.Name = "lbAnswers";
            this.lbAnswers.Size = new System.Drawing.Size(340, 156);
            this.lbAnswers.TabIndex = 30;
            this.lbAnswers.DoubleClick += new System.EventHandler(this.LbAnswers_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(352, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Правильный ответ:";
            // 
            // btnClearAnswerOne
            // 
            this.btnClearAnswerOne.Location = new System.Drawing.Point(451, 146);
            this.btnClearAnswerOne.Name = "btnClearAnswerOne";
            this.btnClearAnswerOne.Size = new System.Drawing.Size(110, 23);
            this.btnClearAnswerOne.TabIndex = 27;
            this.btnClearAnswerOne.Text = "Новый";
            this.btnClearAnswerOne.UseVisualStyleBackColor = false;
            this.btnClearAnswerOne.Click += new System.EventHandler(this.BtnClearAnswerOne_Click);
            // 
            // btnDeleteAnswerOne
            // 
            this.btnDeleteAnswerOne.Location = new System.Drawing.Point(355, 146);
            this.btnDeleteAnswerOne.Name = "btnDeleteAnswerOne";
            this.btnDeleteAnswerOne.Size = new System.Drawing.Size(90, 23);
            this.btnDeleteAnswerOne.TabIndex = 26;
            this.btnDeleteAnswerOne.Text = "Удалить";
            this.btnDeleteAnswerOne.UseVisualStyleBackColor = true;
            this.btnDeleteAnswerOne.Click += new System.EventHandler(this.BtnDeleteAnswerOne_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(352, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Баллов за правильный ответ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Введите текст ответа:";
            // 
            // btnAddAnswerOne
            // 
            this.btnAddAnswerOne.Location = new System.Drawing.Point(567, 146);
            this.btnAddAnswerOne.Name = "btnAddAnswerOne";
            this.btnAddAnswerOne.Size = new System.Drawing.Size(90, 23);
            this.btnAddAnswerOne.TabIndex = 21;
            this.btnAddAnswerOne.Text = "Сохранить";
            this.btnAddAnswerOne.UseVisualStyleBackColor = true;
            this.btnAddAnswerOne.Click += new System.EventHandler(this.BtnAddAnswerOne_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 267);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 200);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl1_Selected);
            // 
            // CreateQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 507);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.btnLoadPicture);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CreateQuestion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Создание вопроса";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QuestionCreate_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsFree)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsMult)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPointsOne)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadPicture;
        private System.Windows.Forms.RichTextBox tbQuestion;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox tbAnswerFree;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnClearAnswerMult;
        private System.Windows.Forms.Button btnDeleteAnswerMult;
        private System.Windows.Forms.RichTextBox tbAnswerMult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddAnswerMult;
        private System.Windows.Forms.CheckedListBox clbAnswers;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label labelRightAnswer;
        private System.Windows.Forms.ComboBox cbRightAnswer;
        private System.Windows.Forms.ListBox lbAnswers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClearAnswerOne;
        private System.Windows.Forms.Button btnDeleteAnswerOne;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddAnswerOne;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.NumericUpDown numPointsFree;
        private System.Windows.Forms.NumericUpDown numPointsMult;
        private System.Windows.Forms.NumericUpDown numPointsOne;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MI_InsertInQuestion;
        private System.Windows.Forms.RichTextBox tbAnswerOne;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem MI_InsertIntoTbAnswer;
    }
}