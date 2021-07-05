using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IST_TAiFYa
{
    public partial class Tests : Form
    {
        string Username;
        int ID_Role, ID_Group, ID_Student =-1;
        string query;
        public Tests()
        {
            InitializeComponent();           
        }
        private void LoadDataToTable()
        {
            SqlConnection sqlConnection = new Connection().GetConnection();
            sqlConnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter(query, sqlConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();          
        }
        public void SetUser(string name, int idRole, int idUser)
        {
           // dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Username = name;
            ID_Role = idRole;        
            if (ID_Role == 1)
            {
                query = "select * from [TestView]";
                LoadDataToTable();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells["Номер"].Value = i + 1;
                }
                dataGridView1.Columns["ID_Test"].Visible = false;
            }
            else if (ID_Role == 2) //Только разрешенные тесты для данной группы!
            {
                SqlConnection sqlConnection = new Connection().GetConnection();
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select ID_Group from [Student] where ID_User = " + idUser, sqlConnection);
                ID_Group = (int)cmd.ExecuteScalar();
                cmd = new SqlCommand("select ID_Student from [Student] where ID_User = " + idUser, sqlConnection);
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
                btnTestCreate.Visible = false;
                btnTestDelete.Visible = false;
            }
            
        }
        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ID_Role == 1) {
                CreateTest TestCreate = new CreateTest();
                TestCreate.SetID_Test((int)dataGridView1.CurrentRow.Cells[0].Value);
                TestCreate.Text = "Редактирование теста";
                if (TestCreate.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToTable();
                }
            }
        }

        private void BtnTestDelete_Click(object sender, EventArgs e)
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

        private void BtnTestCreate_Click(object sender, EventArgs e)
        {
            CreateTest TestCreate = new CreateTest();
            TestCreate.SetUsername(Username);
            if (TestCreate.ShowDialog() == DialogResult.OK)
            {
                LoadDataToTable();
            }
        }

        private void BtnTestStart_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index != -1)
            {
                DialogResult result = MessageBox.Show("Вы  хотите пройти тест \"" +
                    dataGridView1.CurrentRow.Cells["Название"].Value + "\"?", "Подтверждение",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if ((int)dataGridView1.CurrentRow.Cells["Вопросов"].Value ==0)
                    {
                        MessageBox.Show("В выбранном тесте нет вопросов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    int ID_Test = (int)dataGridView1.CurrentRow.Cells["Номер"].Value;
                    string q = "EXEC CountTries @ID_Test = " + ID_Test + ",  @ID_Student = " + ID_Student;
                    SqlConnection sqlConnection = new Connection().GetConnection();
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand(q, sqlConnection);
                    int Try = int.Parse(cmd.ExecuteScalar().ToString());
                    q = "select Tries from Test where ID_Test = "+ ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    object ob = cmd.ExecuteScalar();
                    if (ob != DBNull.Value) {
                        int MaxTries = int.Parse(ob.ToString());
                        sqlConnection.Close();
                        if (Try == MaxTries)
                        {
                            MessageBox.Show("Исчерпано доступное число попыток", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    StartTest StartTest = new StartTest();
                    StartTest.SetID(ID_Test, ID_Student, Try+1);
                    StartTest.Text += " \"" + dataGridView1.CurrentRow.Cells["Название"].Value + "\"";
                    StartTest.ShowDialog();
                }
            }
        }
    }
}
