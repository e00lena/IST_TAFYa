using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IST_TAiFYa
{
    public partial class CreateQuestion : Form
    {
        int ID_Question = -1;
        int ID_Test;
        string PicturePath;
        int CurrentAnswer = -1;
        int QuestionType; //Тип вопроса, 0 - один ответ, 1 - несколько, 2 - свободный, 3 - сопоставление
        public CreateQuestion()
        {
            InitializeComponent();
        }
        private void LoadDataToTable()
        {
            SqlConnection sqlConnection = new Connection().GetConnection();
            sqlConnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select Answer, Correct, Points from [Answer] where ID_Question = " + ID_Question, sqlConnection);
            adapt.Fill(dt);
            SqlCommand cmd = new SqlCommand("select ID_QuestionType from Question where ID_Question = " + ID_Question, sqlConnection);
            QuestionType = (int)cmd.ExecuteScalar();
            tabControl1.SelectedIndex = QuestionType;
            cmd = new SqlCommand("select Question from Question where ID_Question = " + ID_Question, sqlConnection);
            tbQuestion.Text = cmd.ExecuteScalar().ToString();
            string q = "select Value from [Parameter] where Parameter = 'PicturesPath'";
            cmd = new SqlCommand(q, sqlConnection);
            string path = cmd.ExecuteScalar().ToString();
            path += "\\" + ID_Question;
            if (File.Exists(path + ".BMP"))
            {
                path += ".BMP";
                PictureLoad(path);
            }
            else if (File.Exists(path + ".JPG"))
            {
                path += ".JPG";
                PictureLoad(path);
            }
            else if (File.Exists(path + ".GIF"))
            {
                path += ".GIF";
                PictureLoad(path);
            }
            else if (File.Exists(path + ".PNG"))
            {
                path += ".PNG";
                PictureLoad(path);
            }
           
            switch (QuestionType)
            {
                case 0: // одного ответа
                    lbAnswers.Items.Clear();
                    for (int i = 0; i<dt.Rows.Count;i++)
                    {
                        lbAnswers.Items.Add(dt.Rows[i].ItemArray[0]);
                        cbRightAnswer.Items.Add(i+1);
                        if ((bool)dt.Rows[i].ItemArray[1])
                        {
                            cbRightAnswer.SelectedIndex = i;
                            labelRightAnswer.Text = dt.Rows[i].ItemArray[0].ToString();
                            numPointsOne.Value = decimal.Parse(dt.Rows[i].ItemArray[2].ToString());
                        }
                    }                  
                    break;
                case 1:// нескольких ответов
                    clbAnswers.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        clbAnswers.Items.Add(dt.Rows[i].ItemArray[0]);
                        if ((bool)dt.Rows[i].ItemArray[1])
                        {
                            clbAnswers.SetItemChecked(i,true);
                            if (numPointsMult.Value == 0) {
                                numPointsMult.Value = decimal.Parse(dt.Rows[i].ItemArray[2].ToString());
                            }
                        }
                    }
                    break;
                case 2:// свободного ответа
                    if (dt.Rows.Count!=0) {
                        tbAnswerFree.Text = dt.Rows[0].ItemArray[0].ToString();
                        numPointsFree.Value = decimal.Parse(dt.Rows[0].ItemArray[2].ToString());
                    }
                    break;
            }           
            sqlConnection.Close();
        }
        private void PictureLoad(string path)
        {
            Bitmap image = new Bitmap(path);
            PicturePath = path;
            image = new Bitmap(image, new Size(330, 220));
            pictureBox1.Image = image;
            pictureBox1.Invalidate();
        }
        public void SetID_Test(int id)
        {
            ID_Test = id;
        }
        public void SetID_Question(int id)
        {
            ID_Question = id;
            LoadDataToTable();
        }
        #region Загрузка картинки
        private void BtnLoadPicture_Click(object sender, EventArgs e)
        {
            Bitmap image; //Bitmap для открываемого изображения
            OpenFileDialog open_dialog = new OpenFileDialog(); //создание диалогового окна для выбора файла
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
            if (open_dialog.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    image = new Bitmap(open_dialog.FileName);
                    PicturePath = open_dialog.FileName;
                    image = new Bitmap(image, new Size(330, 220));
                    pictureBox1.Image = image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult result = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Для одного ответа
        private void LbAnswers_DoubleClick(object sender, EventArgs e)
        {
            if (lbAnswers.SelectedIndex != -1)
            {
                CurrentAnswer = lbAnswers.SelectedIndex;
                tbAnswerOne.Text = lbAnswers.SelectedItem.ToString();
            }
        }
        private void CbRightAnswer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRightAnswer.SelectedIndex != -1)
            {
                labelRightAnswer.Text = lbAnswers.Items[cbRightAnswer.SelectedIndex].ToString();
            }
            else
            {
                labelRightAnswer.Text = "не выбрано";
            }
        }

        private void BtnDeleteAnswerOne_Click(object sender, EventArgs e)
        {
            if (lbAnswers.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Вы точно хотите удалить ответ №" +
                    (lbAnswers.SelectedIndex + 1) + "?", "Подтверждение удаления",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    cbRightAnswer.Items.Clear();
                    for (int i = 1; i < lbAnswers.Items.Count; i++)
                    {
                        cbRightAnswer.Items.Add(i);
                    }
                    cbRightAnswer.SelectedIndex = -1;
                    cbRightAnswer.Text = "";
                    labelRightAnswer.Text = "не выбрано";
                    lbAnswers.Items.RemoveAt(lbAnswers.SelectedIndex);
                }
            }
        }

        private void BtnClearAnswerOne_Click(object sender, EventArgs e)
        {
            tbAnswerOne.Clear();
            CurrentAnswer = -1;
        }

        private void BtnAddAnswerOne_Click(object sender, EventArgs e)
        {
            if (tbAnswerOne.Text.Trim(' ') != "")
            {
                if (CurrentAnswer == -1)
                {
                    lbAnswers.Items.Add(tbAnswerOne.Text);
                    cbRightAnswer.Items.Add(lbAnswers.Items.Count);
                    tbAnswerOne.Clear();
                }
                else
                {
                    lbAnswers.Items[CurrentAnswer] = tbAnswerOne.Text;
                    if (CurrentAnswer==cbRightAnswer.SelectedIndex) {
                        labelRightAnswer.Text = tbAnswerOne.Text;
                    }
                    tbAnswerOne.Clear();
                }
            }
            else
            {
                MessageBox.Show("Введите текст ответа!", "Пустое поле ответа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion
        #region Для нескольких ответов
        private void ClbAnswers_DoubleClick(object sender, EventArgs e)
        {
            if (clbAnswers.SelectedIndex != -1)
            {
                CurrentAnswer = clbAnswers.SelectedIndex;
                tbAnswerMult.Text = clbAnswers.SelectedItem.ToString();
            }
        }

        private void BtnDeleteAnswerMult_Click(object sender, EventArgs e)
        {
            if (clbAnswers.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Вы точно хотите удалить ответ №" +
                    (clbAnswers.SelectedIndex + 1) + "?", "Подтверждение удаления",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    clbAnswers.Items.RemoveAt(clbAnswers.SelectedIndex);
                }
            }
        }

        private void BtnClearAnswerMult_Click(object sender, EventArgs e)
        {
            CurrentAnswer = -1;
            tbAnswerMult.Clear();
        }
        private void BtnAddAnswerMult_Click(object sender, EventArgs e)
        {
            if (tbAnswerMult.Text.Trim(' ') != "")
            {
                if (CurrentAnswer == -1)
                {
                    clbAnswers.Items.Add(tbAnswerMult.Text);
                    tbAnswerMult.Clear();
                }
                else
                {
                    clbAnswers.Items[CurrentAnswer] = tbAnswerMult.Text;
                    tbAnswerMult.Clear();
                }
            }
            else
            {
                MessageBox.Show("Введите текст ответа!", "Пустое поле ответа", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        #endregion

        private void ClearTab()
        {
            switch (QuestionType)
            {
                case 0: //Очистка настроек одного ответа
                    lbAnswers.SelectedIndex = -1;
                    lbAnswers.Items.Clear();
                    cbRightAnswer.SelectedIndex = -1;
                    labelRightAnswer.Text = "не выбрано";
                    cbRightAnswer.Items.Clear();
                    numPointsOne.Value =  1;
                    tbAnswerOne.Clear();
                    CurrentAnswer = -1;
                    break;
                case 1://Очистка настроек нескольких ответов
                    clbAnswers.SelectedIndex = -1;
                    clbAnswers.Items.Clear();
                    numPointsMult.Value = 1;
                    tbAnswerMult.Clear();
                    CurrentAnswer = -1;
                    break;
                case 2://Очистка настроек свободного ответа
                    numPointsFree.Value = 1;
                    tbAnswerFree.Text = "";
                    CurrentAnswer = -1;
                    break;
            }

        }

        private void TabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (ID_Question != -1 && e.TabPageIndex != QuestionType)
            {
                MessageBox.Show("Вы не можете изменить тип сохраненного вопроса!", "Ошибка перехода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tabControl1.SelectedIndex = QuestionType;
                return;
            }
            if (e.TabPageIndex != QuestionType)
            {
                DialogResult result = MessageBox.Show("Вы точно хотите изменить тип вопроса? При смене типа вопроса введенные ответы не сохраняются!", "Подтверждение перехода",
                     MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    ClearTab();
                    QuestionType = tabControl1.SelectedIndex;
                }
                else
                {
                    tabControl1.SelectedIndex = QuestionType;
                }
            }
        }

        private void QuestionCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ID_Question == -1)
            {
                DialogResult dialogResult = MessageBox.Show("Внесенные изменения не сохранены. Вы точно хотите закрыть это окно?", "Подтверждение выхода", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ID_Question == -1) //Добавление вопроса
            {
                DialogResult result = MessageBox.Show("После сохранения нельзя будет изменить тип вопроса. Сохранить?", "Подтверждение сохранения",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlConnection sqlConnection = new Connection().GetConnection();
                    sqlConnection.Open();
                    string q;
                    SqlCommand cmd;
                    q = "insert into Question (ID_Test, Question, ID_QuestionType) values (" + ID_Test + ", N'" + tbQuestion.Text + "', " + QuestionType + ")";
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    q = "SELECT TOP 1 ID_Question FROM [Question] ORDER BY ID_Question DESC";
                    cmd = new SqlCommand(q, sqlConnection);
                    ID_Question = (int)cmd.ExecuteScalar();
                    string points = "";
                    switch (QuestionType)
                    {
                        case 0: //Сохранение вопроса с одним ответом                           
                            for (int i = 0; i < lbAnswers.Items.Count; i++) {
                                bool check = cbRightAnswer.SelectedIndex == i;
                                points = "0";
                                if (check)
                                {
                                    points = numPointsOne.Value.ToString();
                                    points = points.Replace(',', '.');
                                }
                                q = "insert into Answer (ID_Question, Answer, Correct, Points) values " +
                                    "(" + ID_Question + ", N'" + lbAnswers.Items[i].ToString() + "', '" + check + "', '" + points + "')";
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                            break;
                        case 1:// Сохранение вопроса с несколькими ответами
                            bool added = false;
                            for (int i = 0; i < clbAnswers.Items.Count; i++)
                            {
                                bool check = clbAnswers.GetItemCheckState(i) == CheckState.Checked;
                                points = "0";
                                if (check && !added)
                                {
                                    points = numPointsMult.Value.ToString();
                                    points = points.Replace(',', '.');
                                    added = true;
                                }
                                q = "insert into Answer (ID_Question, Answer, Correct, Points) values " +
                                    "(" + ID_Question + ", N'" + clbAnswers.Items[i].ToString() + "', '" + check + "', '" + points + "')";
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                            break;
                        case 2://Сохранение свободного ответа
                            q = "insert into Answer (ID_Question, Answer, Correct, Points) values " +
                                 "(" + ID_Question + ", N'" + tbAnswerFree.Text + "', '1', '" + numPointsFree.Value.ToString().Replace(',', '.') + "')";
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();
                            break;
                    }
                    if (PicturePath!=null) {
                        q = "select Value from [Parameter] where Parameter = 'PicturesPath'";
                        cmd = new SqlCommand(q, sqlConnection);
                        string path = cmd.ExecuteScalar().ToString();
                        path += "\\" + ID_Question + "." + PicturePath.Split('.').Last();
                        File.Copy(PicturePath, path, true);
                    }
                    q = "EXEC CountMaxPoints @ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                   string MaxPoints = cmd.ExecuteScalar().ToString();
                    q = "update Test set MaxPoints = '" + MaxPoints + "' where ID_Test = " + ID_Test;
                    cmd = new SqlCommand(q, sqlConnection);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            else //Редактирование вопроса
            {
                SqlConnection sqlConnection = new Connection().GetConnection();
                sqlConnection.Open();
                string q;
                SqlCommand cmd;
                q = "update Question set Question = N'" + tbQuestion.Text + "' where ID_Question = " + ID_Question;
                cmd = new SqlCommand(q, sqlConnection);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt = new SqlDataAdapter("select ID_Answer from [Answer] where ID_Question = " + ID_Question, sqlConnection);
                adapt.Fill(dt);
                string points = "";
                switch (QuestionType)
                {
                    case 0: //Сохранение вопроса с одним ответом     
                        if (lbAnswers.Items.Count >= dt.Rows.Count) //если добавили новые ответы
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                bool check = cbRightAnswer.SelectedIndex == i;
                                points = "0";
                                if (check)
                                {
                                    points = numPointsOne.Value.ToString();
                                    points = points.Replace(',', '.');
                                }
                                q = "update Answer set Answer = N'" + lbAnswers.Items[i].ToString() + "'," +
                                    " Correct = '" + check + "', Points = '" + points + "' where ID_Answer = " + dt.Rows[i].ItemArray[0];
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                            if (lbAnswers.Items.Count > dt.Rows.Count)
                            {
                                for (int i = dt.Rows.Count; i < lbAnswers.Items.Count; i++)
                                {
                                    bool check = cbRightAnswer.SelectedIndex == i;
                                    points = "0";
                                    if (check)
                                    {
                                        points = numPointsOne.Value.ToString();
                                        points = points.Replace(',', '.');
                                    }
                                    q = "insert into Answer (ID_Question, Answer, Correct, Points) values " +
                                        "(" + ID_Question + ", N'" + lbAnswers.Items[i].ToString() + "', '" + check + "', '" + points + "')";
                                    cmd = new SqlCommand(q, sqlConnection);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else //если удалили ответы
                        {
                            for (int i = 0; i < lbAnswers.Items.Count; i++)
                            {
                                bool check = cbRightAnswer.SelectedIndex == i;
                                points = "0";
                                if (check)
                                {
                                    points = numPointsOne.Value.ToString();
                                    points = points.Replace(',', '.');
                                }
                                q = "update Answer set Answer = N'" + lbAnswers.Items[i].ToString() + "'," +
                                    " Correct = '" + check + "', Points = '" + points + "' where ID_Answer = " + dt.Rows[i].ItemArray[0];
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                            for (int i = lbAnswers.Items.Count; i < dt.Rows.Count; i++)
                            {
                                q = "DELETE FROM Answer where ID_Answer = " + dt.Rows[i].ItemArray[0];
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        break;
                    case 1:// Сохранение вопроса с несколькими ответами

                        if (clbAnswers.Items.Count >= dt.Rows.Count) //если добавили новые ответы
                        {
                            bool added = false;
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                bool check = clbAnswers.GetItemCheckState(i) == CheckState.Checked;
                                points = "0";
                                if (check && !added)
                                {
                                    points = numPointsMult.Value.ToString();
                                    points = points.Replace(',', '.');
                                    added = true;
                                }
                                q = "update Answer set Answer = N'" + clbAnswers.Items[i].ToString() + "'," +
                                       " Correct = '" + check + "', Points = '" + points + "' where ID_Answer = " + dt.Rows[i].ItemArray[0];
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                            if (clbAnswers.Items.Count > dt.Rows.Count)
                            {
                                for (int i = dt.Rows.Count; i < clbAnswers.Items.Count; i++)
                                {
                                    bool check = clbAnswers.GetItemCheckState(i) == CheckState.Checked;
                                    points = "0";
                                    if (check && !added)
                                    {
                                        points = numPointsMult.Value.ToString();
                                        points = points.Replace(',', '.');
                                    }
                                    q = "insert into Answer (ID_Question, Answer, Correct, Points) values " +
                                        "(" + ID_Question + ", N'" + clbAnswers.Items[i].ToString() + "', '" + check + "', '" + points + "')";
                                    cmd = new SqlCommand(q, sqlConnection);
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else //если удалили ответы
                        {
                            bool added = false;
                            for (int i = 0; i < clbAnswers.Items.Count; i++)
                            {
                                bool check = clbAnswers.GetItemCheckState(i) == CheckState.Checked;
                                points = "0";
                                if (check && !added)
                                {
                                    points = numPointsMult.Value.ToString();
                                    points = points.Replace(',', '.');
                                    added = true;
                                }
                                q = "update Answer set Answer = N'" + clbAnswers.Items[i].ToString() + "'," +
                                       " Correct = '" + check + "', Points = '" + points + "' where ID_Answer = " + dt.Rows[i].ItemArray[0];
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                            for (int i = clbAnswers.Items.Count; i < dt.Rows.Count; i++)
                            {
                                q = "DELETE FROM Answer where ID_Answer = " + dt.Rows[i].ItemArray[0];
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        break;
                    case 2://Сохранение свободного ответа
                        q = "update Answer set Answer = N'" + tbAnswerFree.Text + "', Points = '" + numPointsFree.Value.ToString().Replace(',', '.') + "' where ID_Answer = " + dt.Rows[0].ItemArray[0];
                        cmd = new SqlCommand(q, sqlConnection);
                        cmd.ExecuteNonQuery();
                        break;
                }
                if (PicturePath!=null) {
                    q = "select Value from [Parameter] where Parameter = 'PicturesPath'";
                    cmd = new SqlCommand(q, sqlConnection);
                    string path = cmd.ExecuteScalar().ToString();
                    path += "\\" + ID_Question;
                    if (path + "." + PicturePath.Split('.').Last() != PicturePath) {
                        if (File.Exists(path + ".BMP"))
                        {
                            File.Delete(path + ".BMP");
                        }
                        if (File.Exists(path + ".JPG"))
                        {
                            File.Delete(path + ".JPG");
                        }
                        if (File.Exists(path + ".GIF"))
                        {
                            File.Delete(path + ".GIF");
                        }
                        if (File.Exists(path + ".PNG"))
                        {
                            File.Delete(path + ".PNG");
                        }
                        path += "." + PicturePath.Split('.').Last();
                        File.Copy(PicturePath, path, true);
                    }
                }
                q = "EXEC CountMaxPoints @ID_Test = " + ID_Test;
                cmd = new SqlCommand(q, sqlConnection);
                string MaxPoints = cmd.ExecuteScalar().ToString();
                string QuestionCount = cmd.ExecuteScalar().ToString();
                q = "update Test set MaxPoints = '" + MaxPoints + "' where ID_Test = " + ID_Test;
                cmd = new SqlCommand(q, sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                DialogResult = DialogResult.OK;
            }
        }
        private void MI_InsertInQuestion_Click(object sender, EventArgs e)
        {
            Symbols Symbols = new Symbols();
            Symbols.tb = tbQuestion;
            Symbols.ShowDialog();
        }

        private void MI_InsertIntoTbAnswer_Click(object sender, EventArgs e)
        {
            Symbols Symbols = new Symbols();
            switch (tabControl1.SelectedIndex) {
                case 0:
                    Symbols.tb = tbAnswerOne;
                    break;
                case 1:
                    Symbols.tb = tbAnswerMult;
                    break;
                case 2:
                    Symbols.tb = tbAnswerFree;
                    break;
            }         
            Symbols.ShowDialog();
        }
    }
}
