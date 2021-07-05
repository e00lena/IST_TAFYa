using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IST_TAiFYa
{
    public partial class MainForm : Form
    {
        string Username;
        int ID_Role, ID_Group, ID_Student = -1, ID_User = -1;
        string query;
        SqlConnection sqlConnection = new Connection().GetConnection();
        //Переменные для контроля открытых окон
        Users Users = new Users();
        Tests Tests = new Tests();
        Structure Structure = new Structure();

        public MainForm()
        {
            InitializeComponent();
            LableGreeting.Select();
        }
        //Режим Администратора
        public void SetAdminMode()
        {
            MI_TestCreate.Visible = false;
            ID_Role = 0;
        }
        //Режим Преподавателя
        public void SetTeacherMode()
        {
            MI_Admin.Visible = false;
            ID_Role = 1;
        }
        //Режим Студента
        public void SetStudentMode()
        {
            MI_Admin.Visible = false;
            MI_TestCreate.Visible = false;
            MI_Structure.Visible = false;
            ID_Role = 2;
        }
        //Установка имени пользователя
        public void SetUsername(string user, int Id)
        {
            ID_User = Id;
            Username = user;
            LableGreeting.Text += user;
            switch (ID_Role) {
                case 0://Администратор
                    query = "select * from [TestView]";
                    LoadDataToTable();
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Cells["Номер"].Value = i + 1;
                    }
                    dataGridView1.Columns["ID_Test"].Visible = false;
                    MI_TestCreate.Visible = false;
                    MI_TestStart.Visible = false;
                    MI_TestChange.Visible = false;
                    break;
                case 1://Преподаватель
                    query = "select * from [TestView] WHERE [Удален] = 0";
                    LoadDataToTable();
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Cells["Номер"].Value = i + 1;
                    }
                    dataGridView1.Columns["ID_Test"].Visible = false;
                    dataGridView1.Columns["Удален"].Visible = false;
                    MI_TestRestore.Visible = false;
                    break;
                case 2://Студент
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("select ID_Group from [Student] where ID_User = " + ID_User, sqlConnection);
                    ID_Group = (int)cmd.ExecuteScalar();
                    cmd = new SqlCommand("select ID_Student from [Student] where ID_User = " + ID_User, sqlConnection);
                    ID_Student = (int)cmd.ExecuteScalar();
                    sqlConnection.Close();
                    query = "select * from [StudentTestView] where ID_Group = " + ID_Group;
                    LoadDataToTable();
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        dataGridView1.Rows[i].Cells["Номер"].Value = i + 1;
                    }
                    dataGridView1.Columns["ID_Group"].Visible = false;
                    dataGridView1.Columns["ID_Test"].Visible = false;
                    MI_TestCreate.Visible = false;
                    MI_TestChange.Visible = false;
                    MI_TestRestore.Visible = false;
                    MI_TestDelete.Visible = false;
                    break;
            }
        }
    
        //Завершение работы программы при закрытии главной формы
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Завершить работу с системой?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }   
        }
        private void LoadDataToTable()
        {          
            sqlConnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter(query, sqlConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (ID_Role)
            {
                case 0://Администратор
                    if (dataGridView1.CurrentRow.Index != -1)
                    {
                        if (!(bool)dataGridView1.CurrentRow.Cells[dataGridView1.ColumnCount-1].Value)
                        {
                            DialogResult result = MessageBox.Show("Вы точно хотите удалить тест №" +
                                (dataGridView1.CurrentRow.Index + 1) + "?", "Подтверждение удаления",
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                int ID_Test = (int)dataGridView1.CurrentRow.Cells[0].Value;
                                SqlConnection sqlConnection = new Connection().GetConnection();
                                sqlConnection.Open();
                                string q = "update Test set Deleted = 1 where ID_Test = " + ID_Test;
                                SqlCommand cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                                q = "delete from AllowedTest where ID_Test = " + ID_Test;
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                                sqlConnection.Close();
                                LoadDataToTable();
                            }
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Вы точно хотите восстановить тест №" +
                               (dataGridView1.CurrentRow.Index + 1) + "?", "Подтверждение восстановления",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (result == DialogResult.OK)
                            {
                                int ID_Test = (int)dataGridView1.CurrentRow.Cells[0].Value;
                                SqlConnection sqlConnection = new Connection().GetConnection();
                                sqlConnection.Open();
                                string q = "update Test set Deleted = 0 where ID_Test = " + ID_Test;
                                SqlCommand cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();                               
                                sqlConnection.Close();
                                LoadDataToTable();
                            }
                        }
                    }
                    break;
                case 1://Преподаватель
                    CreateTest TestCreate = new CreateTest();
                    TestCreate.SetID_Test((int)dataGridView1.CurrentRow.Cells[0].Value);
                    TestCreate.Text = "Редактирование теста";
                    if (TestCreate.ShowDialog() == DialogResult.OK)
                    {
                        LoadDataToTable();
                    }
                    break;
                case 2://Студент
                    if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
                    {
                        DialogResult result = MessageBox.Show("Вы  хотите пройти тест \"" +
                            dataGridView1.CurrentRow.Cells["Название"].Value + "\"?", "Подтверждение",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (result == DialogResult.OK)
                        {
                            if ((int)dataGridView1.CurrentRow.Cells["Вопросов"].Value == 0)
                            {
                                MessageBox.Show("В выбранном тесте нет вопросов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            int ID_Test = (int)dataGridView1.CurrentRow.Cells["ID_Test"].Value;
                            string q = "EXEC CountTries @ID_Test = " + ID_Test + ",  @ID_Student = " + ID_Student;
                            SqlConnection sqlConnection = new Connection().GetConnection();
                            sqlConnection.Open();
                            SqlCommand cmd = new SqlCommand(q, sqlConnection);
                            int Try = int.Parse(cmd.ExecuteScalar().ToString());
                            q = "select Tries from Test where ID_Test = " + ID_Test;
                            cmd = new SqlCommand(q, sqlConnection);
                            object ob = cmd.ExecuteScalar();
                            if (ob != DBNull.Value)
                            {
                                int MaxTries = int.Parse(ob.ToString());
                                sqlConnection.Close();
                                if (Try >= MaxTries)
                                {
                                    MessageBox.Show("Исчерпано доступное число попыток", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            StartTest StartTest = new StartTest();
                            StartTest.SetID(ID_Test, ID_Student, Try + 1);
                            StartTest.Text += " \"" + dataGridView1.CurrentRow.Cells["Название"].Value + "\"";
                            StartTest.ShowDialog();
                        }
                    }
                    break;
            }
        }
        //Вызов формы создания теста (конструктора)
        private void MI_TestCreate_Click(object sender, EventArgs e)
        {
            CreateTest TestCreate = new CreateTest();
            TestCreate.SetUsername(Username);
            if (TestCreate.ShowDialog() == DialogResult.OK)
            {
                LoadDataToTable();
            }
        }
        //Редактировать тест
        private void MI_TestChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
            {
                CreateTest TestCreate = new CreateTest();
                TestCreate.SetID_Test((int)dataGridView1.CurrentRow.Cells[0].Value);
                TestCreate.Text = "Редактирование теста";
                if (TestCreate.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToTable();
                }
            }
        }
        //Пройти тест
        private void MI_TestStart_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
            {
                DialogResult result = MessageBox.Show("Вы  хотите пройти тест \"" +
                    dataGridView1.CurrentRow.Cells["Название"].Value + "\"?", "Подтверждение",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if ((int)dataGridView1.CurrentRow.Cells["Вопросов"].Value == 0)
                    {
                        MessageBox.Show("В выбранном тесте нет вопросов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int ID_Test = (int)dataGridView1.CurrentRow.Cells["ID_Test"].Value;
                    string q = "EXEC CountTries @ID_Test = " + ID_Test + ",  @ID_Student = " + ID_Student;
                    SqlConnection sqlConnection = new Connection().GetConnection();
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(q, sqlConnection);
                    int Try = int.Parse(cmd.ExecuteScalar().ToString());
                    q = "select Tries from Test where ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    object ob = cmd.ExecuteScalar();
                    if (ob != DBNull.Value)
                    {
                        int MaxTries = int.Parse(ob.ToString());
                        sqlConnection.Close();
                        if (Try == MaxTries)
                        {
                            MessageBox.Show("Исчерпано доступное число попыток", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    StartTest StartTest = new StartTest();
                    StartTest.SetID(ID_Test, ID_Student, Try + 1);
                    StartTest.Text += " \"" + dataGridView1.CurrentRow.Cells["Название"].Value + "\"";
                    StartTest.ShowDialog();
                }
            }
        }
        //Восстановить тест
        private void MI_TestRestore_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DialogResult result = MessageBox.Show("Вы точно хотите восстановить тест №" +
                    (dataGridView1.CurrentRow.Index + 1) + "?", "Подтверждение восстановления",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int ID_Test = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    SqlConnection sqlConnection = new Connection().GetConnection();
                    sqlConnection.Open();
                    string q = "update Test set Deleted = 0 where ID_Test = " + ID_Test;
                    SqlCommand cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    LoadDataToTable();
                }
            }
        }
        //Удаление теста
        private void MI_TestDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DialogResult result = MessageBox.Show("Вы точно хотите удалить тест №" +
                    (dataGridView1.CurrentRow.Index + 1) + "?", "Подтверждение удаления",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int ID_Test = (int)dataGridView1.CurrentRow.Cells[0].Value;
                    SqlConnection sqlConnection = new Connection().GetConnection();
                    sqlConnection.Open();
                    string q = "update Test set Deleted = 1 where ID_Test = " + ID_Test;
                    SqlCommand cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    q = "delete from AllowedTest where ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    LoadDataToTable();
                }
            }
        } 

        private void MI_Parameters_Click(object sender, EventArgs e)
        {
            SystemParameters SystemParameters = new SystemParameters();
            SystemParameters.ShowDialog();
        }

        private void MI_AdminUserList_Click(object sender, EventArgs e)
        {
            if (Users.Created == false)
            {
                Users = new Users();
                Users.Show();
            }
            Users.Activate();
            Users.WindowState = FormWindowState.Normal;

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (ID_Role == 0) {
                if (!(bool)dataGridView1.CurrentRow.Cells[dataGridView1.ColumnCount - 1].Value)
                {
                    MI_TestRestore.Visible = false;
                    MI_TestDelete.Visible = true;
                }
                else
                {
                    MI_TestRestore.Visible = true;
                    MI_TestDelete.Visible = false;
                }
            }
        }

        private void MI_Structure_Click(object sender, EventArgs e)
        {
            if (Structure.Created == false)
            {
                Structure = new Structure();
                Structure.Show();
            }
            Structure.Activate();
            Structure.WindowState = FormWindowState.Normal;
        }

        private void MI_Statistic_Click(object sender, EventArgs e)
        {
            Statistic Statistic = new Statistic();
            if (ID_Role == 2)
            {
                Statistic.SetStudentMode(ID_Student);
            }
            Statistic.ShowDialog();
        }

        private void btnChangeUser_Click(object sender, EventArgs e)
        {
            Hide();
            new FormAutorisation().ShowDialog();
        }
    }
}
