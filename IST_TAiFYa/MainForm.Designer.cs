namespace IST_TAiFYa
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.MI_Test = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_TestCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_TestChange = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_TestStart = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_TestDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_TestRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Statistic = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Structure = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Admin = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_AdminUserList = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_AdminUserAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MI_Parameters = new System.Windows.Forms.ToolStripMenuItem();
            this.LableGreeting = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnChangeUser = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_Test,
            this.MI_Statistic,
            this.MI_Structure,
            this.MI_Admin});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 33);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // MI_Test
            // 
            this.MI_Test.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_TestCreate,
            this.MI_TestChange,
            this.MI_TestStart,
            this.MI_TestDelete,
            this.MI_TestRestore});
            this.MI_Test.Image = ((System.Drawing.Image)(resources.GetObject("MI_Test.Image")));
            this.MI_Test.Name = "MI_Test";
            this.MI_Test.Size = new System.Drawing.Size(76, 29);
            this.MI_Test.Text = "Тесты";
            // 
            // MI_TestCreate
            // 
            this.MI_TestCreate.Image = ((System.Drawing.Image)(resources.GetObject("MI_TestCreate.Image")));
            this.MI_TestCreate.Name = "MI_TestCreate";
            this.MI_TestCreate.Size = new System.Drawing.Size(181, 22);
            this.MI_TestCreate.Text = "Создать новый тест";
            this.MI_TestCreate.Click += new System.EventHandler(this.MI_TestCreate_Click);
            // 
            // MI_TestChange
            // 
            this.MI_TestChange.Image = ((System.Drawing.Image)(resources.GetObject("MI_TestChange.Image")));
            this.MI_TestChange.Name = "MI_TestChange";
            this.MI_TestChange.Size = new System.Drawing.Size(181, 22);
            this.MI_TestChange.Text = "Редактировать тест";
            this.MI_TestChange.Click += new System.EventHandler(this.MI_TestChange_Click);
            // 
            // MI_TestStart
            // 
            this.MI_TestStart.Image = ((System.Drawing.Image)(resources.GetObject("MI_TestStart.Image")));
            this.MI_TestStart.Name = "MI_TestStart";
            this.MI_TestStart.Size = new System.Drawing.Size(181, 22);
            this.MI_TestStart.Text = "Пройти тест";
            this.MI_TestStart.Click += new System.EventHandler(this.MI_TestStart_Click);
            // 
            // MI_TestDelete
            // 
            this.MI_TestDelete.Image = ((System.Drawing.Image)(resources.GetObject("MI_TestDelete.Image")));
            this.MI_TestDelete.Name = "MI_TestDelete";
            this.MI_TestDelete.Size = new System.Drawing.Size(181, 22);
            this.MI_TestDelete.Text = "Удалить тест";
            this.MI_TestDelete.Click += new System.EventHandler(this.MI_TestDelete_Click);
            // 
            // MI_TestRestore
            // 
            this.MI_TestRestore.Image = ((System.Drawing.Image)(resources.GetObject("MI_TestRestore.Image")));
            this.MI_TestRestore.Name = "MI_TestRestore";
            this.MI_TestRestore.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MI_TestRestore.Size = new System.Drawing.Size(181, 22);
            this.MI_TestRestore.Text = "Восстановить тест";
            this.MI_TestRestore.Click += new System.EventHandler(this.MI_TestRestore_Click);
            // 
            // MI_Statistic
            // 
            this.MI_Statistic.Image = ((System.Drawing.Image)(resources.GetObject("MI_Statistic.Image")));
            this.MI_Statistic.Name = "MI_Statistic";
            this.MI_Statistic.Size = new System.Drawing.Size(105, 29);
            this.MI_Statistic.Text = "Статистика";
            this.MI_Statistic.Click += new System.EventHandler(this.MI_Statistic_Click);
            // 
            // MI_Structure
            // 
            this.MI_Structure.Image = ((System.Drawing.Image)(resources.GetObject("MI_Structure.Image")));
            this.MI_Structure.Name = "MI_Structure";
            this.MI_Structure.Size = new System.Drawing.Size(100, 29);
            this.MI_Structure.Text = "Структура";
            this.MI_Structure.Click += new System.EventHandler(this.MI_Structure_Click);
            // 
            // MI_Admin
            // 
            this.MI_Admin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MI_AdminUserList,
            this.MI_AdminUserAdd,
            this.MI_Parameters});
            this.MI_Admin.Image = ((System.Drawing.Image)(resources.GetObject("MI_Admin.Image")));
            this.MI_Admin.Name = "MI_Admin";
            this.MI_Admin.Size = new System.Drawing.Size(159, 29);
            this.MI_Admin.Text = "Администрирование";
            // 
            // MI_AdminUserList
            // 
            this.MI_AdminUserList.Image = ((System.Drawing.Image)(resources.GetObject("MI_AdminUserList.Image")));
            this.MI_AdminUserList.Name = "MI_AdminUserList";
            this.MI_AdminUserList.Size = new System.Drawing.Size(246, 22);
            this.MI_AdminUserList.Text = "Список пользователей";
            this.MI_AdminUserList.Click += new System.EventHandler(this.MI_AdminUserList_Click);
            // 
            // MI_AdminUserAdd
            // 
            this.MI_AdminUserAdd.Image = ((System.Drawing.Image)(resources.GetObject("MI_AdminUserAdd.Image")));
            this.MI_AdminUserAdd.Name = "MI_AdminUserAdd";
            this.MI_AdminUserAdd.Size = new System.Drawing.Size(246, 22);
            this.MI_AdminUserAdd.Text = "Добавить нового пользователя";
            // 
            // MI_Parameters
            // 
            this.MI_Parameters.Image = ((System.Drawing.Image)(resources.GetObject("MI_Parameters.Image")));
            this.MI_Parameters.Name = "MI_Parameters";
            this.MI_Parameters.Size = new System.Drawing.Size(246, 22);
            this.MI_Parameters.Text = "Параметры системы";
            this.MI_Parameters.Click += new System.EventHandler(this.MI_Parameters_Click);
            // 
            // LableGreeting
            // 
            this.LableGreeting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LableGreeting.AutoSize = true;
            this.LableGreeting.Location = new System.Drawing.Point(12, 6);
            this.LableGreeting.Name = "LableGreeting";
            this.LableGreeting.Size = new System.Drawing.Size(83, 13);
            this.LableGreeting.TabIndex = 2;
            this.LableGreeting.Text = "Здравствуйте, ";
            // 
            // btnChangeUser
            // 
            this.btnChangeUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangeUser.Location = new System.Drawing.Point(629, 0);
            this.btnChangeUser.Name = "btnChangeUser";
            this.btnChangeUser.Size = new System.Drawing.Size(171, 27);
            this.btnChangeUser.TabIndex = 3;
            this.btnChangeUser.Text = "Сменить пользователя";
            this.btnChangeUser.UseVisualStyleBackColor = true;
            this.btnChangeUser.Click += new System.EventHandler(this.btnChangeUser_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 33);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnChangeUser);
            this.splitContainer1.Panel2.Controls.Add(this.LableGreeting);
            this.splitContainer1.Size = new System.Drawing.Size(800, 417);
            this.splitContainer1.SplitterDistance = 386;
            this.splitContainer1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 386);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellDoubleClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информационная система тестирования по ТАиФЯ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem MI_Test;
        private System.Windows.Forms.ToolStripMenuItem MI_TestCreate;
        private System.Windows.Forms.ToolStripMenuItem MI_Statistic;
        private System.Windows.Forms.ToolStripMenuItem MI_Admin;
        private System.Windows.Forms.ToolStripMenuItem MI_AdminUserList;
        private System.Windows.Forms.ToolStripMenuItem MI_AdminUserAdd;
        private System.Windows.Forms.Label LableGreeting;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripMenuItem MI_Parameters;
        private System.Windows.Forms.ToolStripMenuItem MI_Structure;
        private System.Windows.Forms.Button btnChangeUser;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem MI_TestDelete;
        private System.Windows.Forms.ToolStripMenuItem MI_TestChange;
        private System.Windows.Forms.ToolStripMenuItem MI_TestStart;
        private System.Windows.Forms.ToolStripMenuItem MI_TestRestore;
    }
}

