namespace IST_TAiFYa
{
    partial class Tests
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tests));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTestCreate = new System.Windows.Forms.Button();
            this.btnTestDelete = new System.Windows.Forms.Button();
            this.btnTestStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(690, 376);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentDoubleClick);
            // 
            // btnTestCreate
            // 
            this.btnTestCreate.Location = new System.Drawing.Point(12, 394);
            this.btnTestCreate.Name = "btnTestCreate";
            this.btnTestCreate.Size = new System.Drawing.Size(177, 23);
            this.btnTestCreate.TabIndex = 5;
            this.btnTestCreate.Text = "Создать новый тест";
            this.btnTestCreate.UseVisualStyleBackColor = true;
            this.btnTestCreate.Click += new System.EventHandler(this.BtnTestCreate_Click);
            // 
            // btnTestDelete
            // 
            this.btnTestDelete.Location = new System.Drawing.Point(533, 394);
            this.btnTestDelete.Name = "btnTestDelete";
            this.btnTestDelete.Size = new System.Drawing.Size(145, 23);
            this.btnTestDelete.TabIndex = 6;
            this.btnTestDelete.Text = "Удалить тест";
            this.btnTestDelete.UseVisualStyleBackColor = true;
            this.btnTestDelete.Click += new System.EventHandler(this.BtnTestDelete_Click);
            // 
            // btnTestStart
            // 
            this.btnTestStart.Location = new System.Drawing.Point(260, 394);
            this.btnTestStart.Name = "btnTestStart";
            this.btnTestStart.Size = new System.Drawing.Size(177, 23);
            this.btnTestStart.TabIndex = 7;
            this.btnTestStart.Text = "Пройти тест";
            this.btnTestStart.UseVisualStyleBackColor = true;
            this.btnTestStart.Click += new System.EventHandler(this.BtnTestStart_Click);
            // 
            // Tests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 426);
            this.Controls.Add(this.btnTestStart);
            this.Controls.Add(this.btnTestDelete);
            this.Controls.Add(this.btnTestCreate);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список тестов";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnTestCreate;
        private System.Windows.Forms.Button btnTestDelete;
        private System.Windows.Forms.Button btnTestStart;
    }
}