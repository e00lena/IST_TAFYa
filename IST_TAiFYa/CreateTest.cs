using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace IST_TAiFYa
{
    public partial class CreateTest : Form
    {
        string Username;
        int ID_Test;
        DataTable dtGroups, dtAllowed;
        public CreateTest()
        {
            InitializeComponent();          
        }
        private void LoadDataToTable()
        {
            SqlConnection sqlConnection = new Connection().GetConnection();
            sqlConnection.Open();
            SqlCommand cmd;
            if (ID_Test == 0)
            {
                string q1 = "update Test set Creator = '" + Username + "',  DateCreated = '" + DateTime.Now.ToShortDateString() + "' where ID_Test = 0";
                cmd = new SqlCommand(q1, sqlConnection);
                cmd.ExecuteNonQuery();
                LabelDateCreated.Text += DateTime.Now.ToLongDateString();
            }
            DataTable dtGrade = new DataTable();
            SqlDataAdapter adapt = new SqlDataAdapter("select MaxPoints, Grade3, Grade4, Grade5 from Test where ID_Test = " + ID_Test, sqlConnection);
            adapt.Fill(dtGrade);
            decimal max = decimal.Parse(dtGrade.Rows[0].ItemArray[0].ToString());
            numGrade5.Maximum = max;
            numGrade4.Maximum = max - (decimal)0.1;
            numGrade3.Maximum = max - (decimal)0.2;
            LabelMaxPoints.Text = "Всего баллов за тест: " + max;
            if (dtGrade.Rows[0].ItemArray[3] != DBNull.Value)
            {
                numGrade3.Value = decimal.Parse(dtGrade.Rows[0].ItemArray[1].ToString().Replace('.',','));
                numGrade4.Value = decimal.Parse(dtGrade.Rows[0].ItemArray[2].ToString().Replace('.', ','));
                numGrade5.Value = decimal.Parse(dtGrade.Rows[0].ItemArray[3].ToString().Replace('.', ','));
            }
            DataTable dt = new DataTable();
            DataTable dtRight = new DataTable();
           
            adapt = new SqlDataAdapter("select * from [QuestionView] where ID_Test = " + ID_Test, sqlConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i< dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells["Номер вопроса"].Value = i+1;
            }
            dataGridView1.Columns["ID_Test"].Visible = false;
            dataGridView1.Columns["ID_Question"].Visible = false;
            dt = new DataTable();
            adapt = new SqlDataAdapter("select * from [RightAnswersView] where ID_Test = " + ID_Test, sqlConnection);
            adapt.Fill(dt);
          
            dataGridView2.DataSource = dt;
            dataGridView2.Columns["ID_Test"].Visible = false;
            dataGridView2.Columns["ID_Question"].Visible = false;
            dtGroups = new DataTable();
            adapt = new SqlDataAdapter("select ID_Group, [Group] from [Group] order by ID_Specialty", sqlConnection);
            adapt.Fill(dtGroups);
            dtAllowed = new DataTable();
            adapt = new SqlDataAdapter("select ID_AllowedTest, ID_Group from [AllowedTest] where ID_Test = " + ID_Test +" order by ID_Group", sqlConnection);
            adapt.Fill(dtAllowed);
            clbGroups.Items.Clear();
            int x = -1;
            if (dtAllowed.Rows.Count > x+1)
            {
                x++;
            }
            for (int i = 0; i < dtGroups.Rows.Count;  i++)
            {               
                if (x!=-1 && (int)dtAllowed.Rows[x].ItemArray[1] == (int)dtGroups.Rows[i].ItemArray[0])
                {
                    clbGroups.Items.Add(dtGroups.Rows[i].ItemArray[1], true);
                    if (dtAllowed.Rows.Count > x+1)
                    {
                        x++;
                    }
                }
                else
                {
                    clbGroups.Items.Add(dtGroups.Rows[i].ItemArray[1], false);
                }               
            }
            sqlConnection.Close();
        }
        public void SetUsername(string name)
        {
            Username = name;
            LabelCreator.Text += Username;
        }
        public void SetID_Test(int id)
        {
            ID_Test = id;
            SqlConnection sqlConnection = new Connection().GetConnection();
            sqlConnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select Name, Creator, DateCreated, Time, Tries from Test where ID_Test = " + ID_Test, sqlConnection);
            adapt.Fill(dt);
            tbName.Text = dt.Rows[0].ItemArray[0].ToString();
            LabelCreator.Text = "Создатель: " + dt.Rows[0].ItemArray[1];
            LabelDateCreated.Text = "Дата создания: " + ((DateTime)dt.Rows[0].ItemArray[2]).ToLongDateString();
            if (DBNull.Value != dt.Rows[0].ItemArray[3])
            {
                checkBox1.Checked = false;
                numericUpDown1.Value = (int)dt.Rows[0].ItemArray[3];
            }
            if (DBNull.Value != dt.Rows[0].ItemArray[4])
            {
                checkBox2.Checked = false;
                numericUpDown2.Value = (int)dt.Rows[0].ItemArray[4];
            }          
            sqlConnection.Close();
            LoadDataToTable();
        }

        private void BtnAddQuestion_Click(object sender, EventArgs e)
        {
            if (ID_Test == 0)
            {
                MessageBox.Show("Перед добавлением вопросов необходимо сохранить параметры теста.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                CreateQuestion QuestionCreate = new CreateQuestion();
                QuestionCreate.SetID_Test(ID_Test);
                if (QuestionCreate.ShowDialog() == DialogResult.OK)
                {
                    LoadDataToTable();
                }
            }             
        }

        private void BtnDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DialogResult result = MessageBox.Show("Вы точно хотите удалить вопрос №" +
                    (dataGridView1.CurrentRow.Index + 1) + "?", "Подтверждение удаления",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                  int ID_Question = (int)dataGridView1.CurrentRow.Cells["Номер вопроса"].Value;
                    SqlConnection sqlConnection = new Connection().GetConnection();
                    sqlConnection.Open();
                    string q = "select Value from [Parameter] where Parameter = 'PicturesPath'";
                    SqlCommand cmd = new SqlCommand(q, sqlConnection);
                    string path = cmd.ExecuteScalar().ToString();
                    path += "\\" + ID_Question;
                    if (File.Exists(path + ".BMP"))
                    {
                        path += ".BMP";
                        File.Delete(path);
                    }
                    else if (File.Exists(path + ".JPG"))
                    {
                        path += ".JPG";
                        File.Delete(path);
                    }
                    else if (File.Exists(path + ".GIF"))
                    {
                        path += ".GIF";
                        File.Delete(path);
                    }
                    else if (File.Exists(path + ".PNG"))
                    {
                        path += ".PNG";
                        File.Delete(path);
                    }
                    q = "delete from Answer where ID_Question = "+ ID_Question;
                   cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    q = "delete from Question where ID_Question = " + ID_Question;
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    q = "select COUNT(ID_Question) from Question where ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    string QuestionCount = cmd.ExecuteScalar().ToString();
                    q = "update Test set QuestionCount = " + QuestionCount + " where ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    LoadDataToTable();
                }
            }
        }

        private void BtnSaveTest_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new Connection().GetConnection();
            string q;
            SqlCommand cmd;
            sqlConnection.Open();
            if (ID_Test == 0)
            {
                string time, tries;
                if (checkBox1.Checked)
                {
                    time = "null";
                }
                else
                {
                    time = numericUpDown1.Value.ToString();
                }
                if (checkBox2.Checked)
                {
                    tries = "null";
                }
                else
                {
                    tries = numericUpDown2.Value.ToString();
                }
                q = "EXEC CountMaxPoints @ID_Test = " + ID_Test;
                cmd = new SqlCommand(q, sqlConnection);
                string MaxPoints = cmd.ExecuteScalar().ToString();
                q = "insert into [Test] (Name, Creator, DateCreated, Time, Tries, MaxPoints, Grade3, Grade4, Grade5) values ('" +
                tbName.Text + "','" + Username + "', '" + DateTime.Now.ToShortDateString() + "', "+time+", "+tries+", '"+ 
                MaxPoints + "', '"+numGrade3.Value.ToString().Replace(',','.')+"', '"+ numGrade4.Value.ToString().Replace(',', '.') 
                + "', '"+ numGrade5.Value.ToString().Replace(',', '.') + "')";
                cmd = new SqlCommand(q, sqlConnection);
                cmd.ExecuteNonQuery();
                q = "SELECT TOP 1 ID_Test FROM [Test] ORDER BY ID_Test DESC";
                cmd = new SqlCommand(q, sqlConnection);
                ID_Test = (int)cmd.ExecuteScalar();          
                for (int i = 0; i < clbGroups.Items.Count;i++)
                {
                    if (clbGroups.GetItemCheckState(i) == CheckState.Checked)
                    {
                        q = "insert into AllowedTest (ID_Test, ID_Group) values (" + ID_Test + ", "+ dtGroups.Rows[i].ItemArray[0] + ")";
                        cmd = new SqlCommand(q, sqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                }
                
            }
            else
            {
                string time, tries;
                if (checkBox1.Checked)
                {
                    time = "null";
                }
                else
                {
                    time = numericUpDown1.Value.ToString();
                }
                if (checkBox2.Checked)
                {
                    tries = "null";
                }
                else
                {
                    tries = numericUpDown2.Value.ToString();
                }
                q = "update [Test] set Name = '" + tbName.Text + "', Time = "+time+", Tries = " +tries+ 
                    ", Grade3 = '"+ numGrade3.Value.ToString().Replace(',', '.') +
                    "', Grade4 = '" + numGrade4.Value.ToString().Replace(',', '.') +
                    "', Grade5 = '" + numGrade5.Value.ToString().Replace(',', '.') +
                    "' where ID_Test = " +ID_Test;
                cmd = new SqlCommand(q, sqlConnection);
                cmd.ExecuteNonQuery();
                q = "EXEC CountMaxPoints @ID_Test = " + ID_Test;
                cmd = new SqlCommand(q, sqlConnection);
                string MaxPoints = cmd.ExecuteScalar().ToString();
                q = "update Test set MaxPoints = '" + MaxPoints + "' where ID_Test = " + ID_Test;
                cmd = new SqlCommand(q, sqlConnection);
                cmd.ExecuteNonQuery();
                if (clbGroups.CheckedItems.Count >= dtAllowed.Rows.Count) //если добавили новые ответы
                {
                    for (int i = 0; i < dtAllowed.Rows.Count; i++)
                    {                     
                            q = "update AllowedTest set ID_Test = " + ID_Test + ", ID_Group = " + dtGroups.Rows[clbGroups.Items.IndexOf(clbGroups.CheckedItems[i])].ItemArray[0] + " where ID_AllowedTest = " + dtAllowed.Rows[i].ItemArray[0];
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();                      
                    }
                    if (clbGroups.CheckedItems.Count > dtAllowed.Rows.Count)
                    {
                        for (int i = dtAllowed.Rows.Count; i < clbGroups.CheckedItems.Count; i++)
                        {
                            q = "insert into AllowedTest (ID_Test, ID_Group) values (" + ID_Test + ", " + dtGroups.Rows[clbGroups.Items.IndexOf(clbGroups.CheckedItems[i])].ItemArray[0] + ")";
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                else //если удалили ответы
                {
                    for (int i = 0; i < clbGroups.CheckedItems.Count; i++)
                    {
                        q = "update AllowedTest set ID_Test = " + ID_Test + ", ID_Group = " + dtGroups.Rows[clbGroups.Items.IndexOf(clbGroups.CheckedItems[i])].ItemArray[0] + " where ID_AllowedTest = " + dtAllowed.Rows[i].ItemArray[0];
                        cmd = new SqlCommand(q, sqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                    for (int i = clbGroups.CheckedItems.Count; i < dtAllowed.Rows.Count; i++)
                    {
                        q = "DELETE FROM AllowedTest where ID_AllowedTest = " + dtAllowed.Rows[i].ItemArray[0];
                        cmd = new SqlCommand(q, sqlConnection);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            sqlConnection.Close();
            DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CreateQuestion QuestionCreate = new CreateQuestion();
            QuestionCreate.SetID_Test(ID_Test);
            QuestionCreate.SetID_Question((int)dataGridView1.CurrentRow.Cells["ID_Question"].Value);
            QuestionCreate.Text = "Редактирование вопроса";
            QuestionCreate.ShowDialog();
            LoadDataToTable();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) {
                numericUpDown1.Visible = false;
                label4.Visible = false;
            }
            else
            {
                numericUpDown1.Visible = true;
                label4.Visible = true;
            }
        }

        private void MI_Update_Click(object sender, EventArgs e)
        {
            CreateQuestion QuestionCreate = new CreateQuestion();
            QuestionCreate.SetID_Test(ID_Test);
            QuestionCreate.SetID_Question((int)dataGridView1.CurrentRow.Cells["Номер вопроса"].Value);
            QuestionCreate.Text = "Редактирование вопроса";
            QuestionCreate.ShowDialog();
            LoadDataToTable();
        }

        private void MI_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                DialogResult result = MessageBox.Show("Вы точно хотите удалить вопрос №" +
                    (dataGridView1.CurrentRow.Index + 1) + "?", "Подтверждение удаления",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int ID_Question = (int)dataGridView1.CurrentRow.Cells["Номер вопроса"].Value;
                    SqlConnection sqlConnection = new Connection().GetConnection();
                    sqlConnection.Open();
                    string q = "select Value from [Parameter] where Parameter = 'PicturesPath'";
                    SqlCommand cmd = new SqlCommand(q, sqlConnection);
                    string path = cmd.ExecuteScalar().ToString();
                    path += "\\" + ID_Question;
                    if (File.Exists(path + ".BMP"))
                    {
                        path += ".BMP";
                        File.Delete(path);
                    }
                    else if (File.Exists(path + ".JPG"))
                    {
                        path += ".JPG";
                        File.Delete(path);
                    }
                    else if (File.Exists(path + ".GIF"))
                    {
                        path += ".GIF";
                        File.Delete(path);
                    }
                    else if (File.Exists(path + ".PNG"))
                    {
                        path += ".PNG";
                        File.Delete(path);
                    }
                    q = "delete from Answer where ID_Question = " + ID_Question;
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    q = "delete from Question where ID_Question = " + ID_Question;
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    q = "select COUNT(ID_Question) from Question where ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    string QuestionCount = cmd.ExecuteScalar().ToString();
                    q = "update Test set QuestionCount = " + QuestionCount + " where ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    LoadDataToTable();
                }
            }
        }

        private void MI_Copy_Click(object sender, EventArgs e)
        {
            CopyQuestion CopyQuestion = new CopyQuestion();
            CopyQuestion.SetID((int)dataGridView1.CurrentRow.Cells["Номер вопроса"].Value, ID_Test);
            if(CopyQuestion.ShowDialog() == DialogResult.OK)
            {
                LoadDataToTable();
            }         
        }

        private void numGrade3_ValueChanged(object sender, EventArgs e)
        {
            numGrade4.Minimum = numGrade3.Value + (decimal)0.1;
            numGrade4.ReadOnly = false;
        }

        private void numGrade4_ValueChanged(object sender, EventArgs e)
        {
            numGrade5.Minimum = numGrade4.Value + (decimal)0.1;
            numGrade5.ReadOnly = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                numericUpDown2.Visible = false;
            }
            else
            {
                numericUpDown2.Visible = true;
            }
        }
    }
}