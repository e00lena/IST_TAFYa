namespace IST_TAiFYa
{
    partial class Structure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Structure));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MI_AddFaculty = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_AddSpecialty = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_AddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView1.Location = new System.Drawing.Point(0, 33);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(650, 331);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseDoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_AddFaculty,
            this.MI_AddSpecialty,
            this.MI_AddGroup,
            this.MI_Delete});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(650, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MI_AddFaculty
            // 
            this.MI_AddFaculty.Image = ((System.Drawing.Image)(resources.GetObject("MI_AddFaculty.Image")));
            this.MI_AddFaculty.Name = "MI_AddFaculty";
            this.MI_AddFaculty.Size = new System.Drawing.Size(155, 29);
            this.MI_AddFaculty.Text = "Добавить факультет";
            this.MI_AddFaculty.Click += new System.EventHandler(this.MI_AddFaculty_Click);
            // 
            // MI_AddSpecialty
            // 
            this.MI_AddSpecialty.Image = ((System.Drawing.Image)(resources.GetObject("MI_AddSpecialty.Image")));
            this.MI_AddSpecialty.Name = "MI_AddSpecialty";
            this.MI_AddSpecialty.Size = new System.Drawing.Size(171, 29);
            this.MI_AddSpecialty.Text = "Добавить направление";
            this.MI_AddSpecialty.Click += new System.EventHandler(this.MI_AddSpecialty_Click);
            // 
            // MI_AddGroup
            // 
            this.MI_AddGroup.Image = ((System.Drawing.Image)(resources.GetObject("MI_AddGroup.Image")));
            this.MI_AddGroup.Name = "MI_AddGroup";
            this.MI_AddGroup.Size = new System.Drawing.Size(137, 29);
            this.MI_AddGroup.Text = "Добавить группу";
            this.MI_AddGroup.Click += new System.EventHandler(this.MI_AddGroup_Click);
            // 
            // MI_Delete
            // 
            this.MI_Delete.Image = ((System.Drawing.Image)(resources.GetObject("MI_Delete.Image")));
            this.MI_Delete.Name = "MI_Delete";
            this.MI_Delete.Size = new System.Drawing.Size(88, 29);
            this.MI_Delete.Text = "Удалить";
            this.MI_Delete.Click += new System.EventHandler(this.MI_Delete_Click);
            // 
            // Structure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 364);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Structure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Структура";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MI_AddFaculty;
        private System.Windows.Forms.ToolStripMenuItem MI_AddSpecialty;
        private System.Windows.Forms.ToolStripMenuItem MI_AddGroup;
        private System.Windows.Forms.ToolStripMenuItem MI_Delete;
    }
}