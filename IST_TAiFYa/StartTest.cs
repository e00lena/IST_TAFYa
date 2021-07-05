using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace IST_TAiFYa
{
    public partial class StartTest : Form
    {
        TabPage tabOne, tabMult, tabFree;
        SqlConnection sqlConnection = new Connection().GetConnection();
        SqlDataAdapter adapt;
        DataTable dtQuestions;
        DataTable[] dtAnswers;
        List<string>[] SelectedAnswers;
        List<string>[] ResultAnswer;
        int indexQuestion = -1;
        int ID_Test, ID_Student =-1;
        string TestName, Time;
        string PicturesPath = "";
        int QuestionType; //Тип вопроса, 0 - один ответ, 1 - несколько, 2 - свободный, 3 - сопоставление      
        int Try = -1, minutes = -1, seconds = -1, TimeMin = 0 , TimeSec = 0;
        float TestResult, MaxPoints, Grade3 = 0, Grade4 = 0, Grade5 = 0;
        public StartTest()
        {
            InitializeComponent();
            tbTime.Visible = timeLabel.Visible = false;
            tabOne = tabControl1.TabPages[0];
            tabMult = tabControl1.TabPages[1];
            tabFree = tabControl1.TabPages[2];
            tabControl1.TabPages.RemoveAt(1);
            tabControl1.TabPages.RemoveAt(1);
            MI_Previous.Enabled = false;
            MI_Finish.Visible = false;
        }
        public void SetID(int idTest, int idStud, int numberTry)
        {
            Try = numberTry;
            ID_Test = idTest;
            ID_Student = idStud;
            dtQuestions = new DataTable();
            adapt = new SqlDataAdapter("select ID_Question, Question, ID_QuestionType from Question where ID_Test = " + ID_Test, sqlConnection);
            adapt.Fill(dtQuestions);
            LoadDataToTable();
            indexQuestion++;
            LoadQuestion();
            if (dtQuestions.Rows.Count == 1)
            {
                MI_Next.Visible = false;
                MI_Finish.Visible = true;
            }
        }
        private void LoadDataToTable()
        {
            sqlConnection.Open();
            DataTable dt = new DataTable();
            string q = "select Value from [Parameter] where Parameter = 'PicturesPath'";
            SqlCommand cmd = new SqlCommand(q, sqlConnection);
            PicturesPath = cmd.ExecuteScalar().ToString();

            sqlConnection.Close();
            q = "select MaxPoints, Time, Grade3, Grade4, Grade5, Name from Test where ID_Test = " + ID_Test;
            adapt = new SqlDataAdapter(q, sqlConnection);
            adapt.Fill(dt);
            if (dt.Rows[0].ItemArray[0] != DBNull.Value)
            {
                MaxPoints = float.Parse(dt.Rows[0].ItemArray[0].ToString());
            }
            if (dt.Rows[0].ItemArray[1] != DBNull.Value)
            {
                minutes = int.Parse(dt.Rows[0].ItemArray[1].ToString());
                seconds = 0;
                tbTime.Text = minutes + ":" + seconds;
                timeLabel.Visible = tbTime.Visible = true;
            }
            if (dt.Rows[0].ItemArray[4] != DBNull.Value)
            {
                Grade3 = float.Parse(dt.Rows[0].ItemArray[2].ToString().Replace('.',','));
                Grade4 = float.Parse(dt.Rows[0].ItemArray[3].ToString().Replace('.', ','));
                Grade5 = float.Parse(dt.Rows[0].ItemArray[4].ToString().Replace('.', ','));
            }
            TestName = dt.Rows[0].ItemArray[5].ToString();
            dtAnswers = new DataTable[dtQuestions.Rows.Count];
            SelectedAnswers = new List<string> [dtQuestions.Rows.Count];
            ResultAnswer = new List<string>[dtQuestions.Rows.Count];
            for (int i = 0; i < dtQuestions.Rows.Count; i++)
            {
                ResultAnswer[i] = new List<string>();
                ResultAnswer[i].Add(dtQuestions.Rows[i].ItemArray[1].ToString()); //question
                ResultAnswer[i].Add("");//answer
                ResultAnswer[i].Add("0");//correct
                ResultAnswer[i].Add("0");//points
                SelectedAnswers[i] = new List<string>();
                dtAnswers[i] = new DataTable();
                adapt = new SqlDataAdapter("select ID_Answer, Answer, Correct, Points from [Answer] where ID_Question = " + dtQuestions.Rows[i].ItemArray[0], sqlConnection);
                adapt.Fill(dtAnswers[i]);
            }
        }

        private void LoadQuestion()
        {
            tbQuestion.Text = "Вопрос "+(indexQuestion + 1)+" из "+ dtQuestions.Rows.Count+ ": "+dtQuestions.Rows[indexQuestion].ItemArray[1].ToString();
            GetPicture();
            QuestionType = (int)dtQuestions.Rows[indexQuestion].ItemArray[2];
            switch (QuestionType)
            {
                case 0: // одного ответа
                    tabControl1.TabPages.RemoveAt(0);
                    tabControl1.TabPages.Add(tabOne);
                    clbAnswersOne.Items.Clear();
                    for (int i = 0; i < dtAnswers[indexQuestion].Rows.Count; i++)
                    {
                        clbAnswersOne.Items.Add(dtAnswers[indexQuestion].Rows[i].ItemArray[1]);
                    }
                    if ( SelectedAnswers[indexQuestion].Count > 0)
                    {
                        clbAnswersOne.SetItemChecked(clbAnswersOne.Items.IndexOf(SelectedAnswers[indexQuestion][0]), true);
                    }
                    break;
                case 1:// нескольких ответов
                    tabControl1.TabPages.RemoveAt(0);
                    tabControl1.TabPages.Add(tabMult);
                    clbAnswersMult.Items.Clear();
                    for (int i = 0; i < dtAnswers[indexQuestion].Rows.Count; i++)
                    {
                        clbAnswersMult.Items.Add(dtAnswers[indexQuestion].Rows[i].ItemArray[1]);
                    }
                    for (int i = 0; i < SelectedAnswers[indexQuestion].Count; i++)
                    {
                        clbAnswersMult.SetItemChecked(clbAnswersMult.Items.IndexOf(SelectedAnswers[indexQuestion][i]), true);
                    }
                    break;
                case 2:
                    tabControl1.TabPages.RemoveAt(0);
                    tabControl1.TabPages.Add(tabFree);
                    tbAnswerFree.Clear();
                    if (SelectedAnswers[indexQuestion].Count > 0)
                    {
                        tbAnswerFree.Text = SelectedAnswers[indexQuestion][0];
                    }
                    break;
            }
        }

        private void MI_Insert_Click(object sender, EventArgs e)
        {
            Symbols Symbols = new Symbols();
            Symbols.tb = tbAnswerFree;
            Symbols.ShowDialog();
        }

        private void GetPicture()
        {
            string path = PicturesPath + "\\" + dtQuestions.Rows[indexQuestion].ItemArray[0];
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
            else
            {
                splitContainer2.Panel2Collapsed = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimeSec++;
            if(TimeSec == 60)
            {
                TimeMin++;
                TimeSec = 0;
            }
            Time = "";
            string t = TimeMin.ToString();
            if (t.Length == 1)
            {
                Time += 0 + TimeMin.ToString();
            }
            else
            {
                Time += TimeMin.ToString();
            }
            t = TimeSec.ToString();
            if (t.Length == 1)
            {
                Time += ":"+0 + TimeSec.ToString();
            }
            else
            {
                Time += ":"+TimeSec.ToString();
            }
        }

        private void PictureLoad(string path)
        {
            Bitmap image = new Bitmap(path);
            image = new Bitmap(image, new Size(330, 220));
            pictureBox1.Image = image;
            splitContainer2.Panel2Collapsed = false;
            pictureBox1.Invalidate();
        }
                   

        private void ClbAnswersOne_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked) {
                for (int i = 0; i < clbAnswersOne.Items.Count; i++)
                {
                    if (i != e.Index && clbAnswersOne.GetItemChecked(i)) {
                        clbAnswersOne.SetItemChecked(i, false);
                    }
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds--;
            if (seconds ==-1)
            {
                minutes--;
                seconds = 59;
                if (minutes ==-1)
                {
                    timer1.Enabled = false;
                    MessageBox.Show("Время, отведенное на прохождение данного теста, истекло. Результаты будут сохранены","Принудительное завершение тестирования",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SaveAnswer();
                    CountResult();
                }
            }
            tbTime.Text = minutes + ":" + seconds;         
        }

        private void StartTest_Load(object sender, EventArgs e)
        {
            if (tbTime.Visible)
            {
                timer1.Enabled = true;
            }         
        }

        private void SaveAnswer()
        {
            switch (QuestionType)
            {
                case 0: // одного ответа
                    SelectedAnswers[indexQuestion].Clear();
                    if (clbAnswersOne.CheckedItems.Count > 0)
                    {
                        SelectedAnswers[indexQuestion].Add(clbAnswersOne.CheckedItems[0].ToString());
                    }
                    break;
                case 1:// нескольких ответов
                    SelectedAnswers[indexQuestion].Clear();
                    for (int i = 0; i < clbAnswersMult.CheckedItems.Count; i++)
                    {
                        SelectedAnswers[indexQuestion].Add(clbAnswersMult.CheckedItems[i].ToString());
                    }
                    break;
                case 2:
                    SelectedAnswers[indexQuestion].Clear();
                    if (tbAnswerFree.Text.Trim(' ') != "")
                    {
                        SelectedAnswers[indexQuestion].Add(tbAnswerFree.Text);
                    }
                    break;
            }
            ResultAnswer[indexQuestion][1] = "";
            for (int i = 0; i < SelectedAnswers[indexQuestion].Count; i++)
            {
                if (ResultAnswer[indexQuestion][1]=="")
                {
                    ResultAnswer[indexQuestion][1] = SelectedAnswers[indexQuestion][i];
                }
                else
                {
                    ResultAnswer[indexQuestion][1] += "; " + SelectedAnswers[indexQuestion][i];
                }              
            }
        }

        private void MI_Previous_Click(object sender, EventArgs e)
        {
            SaveAnswer();
            indexQuestion--;
            MI_Next.Visible = true;
            MI_Finish.Visible = false;
            if (indexQuestion == 0)
            {
                MI_Previous.Enabled = false;
            }
            LoadQuestion();
        }

        private void MI_Next_Click(object sender, EventArgs e)
        {
            SaveAnswer();

            if (dtQuestions.Rows.Count > indexQuestion + 1)
            {
                if (dtQuestions.Rows.Count == indexQuestion + 2)
                {
                    MI_Next.Visible = false;
                    MI_Finish.Visible = true;
                }
                indexQuestion++;
                MI_Previous.Enabled = true;
                LoadQuestion();
            }

        }

        private void MI_Finish_Click(object sender, EventArgs e)
        {
            timer1.Enabled = timer2.Enabled = false;
            SaveAnswer();
            // Проверка наличия всех ответов
            for (int i = 0; i < SelectedAnswers.Length; i++)
            {
                if (SelectedAnswers[i].Count == 0)
                {
                    DialogResult res = MessageBox.Show("Нет ответа на вопрос №" + (i + 1) + "! Вернуться?", "Нет ответа на вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (res == DialogResult.Yes)
                    {
                        if (i != indexQuestion)
                        {
                            indexQuestion = i;
                            MI_Next.Visible = true;
                            MI_Finish.Visible = false;
                            if (indexQuestion != 0)
                            {
                                MI_Previous.Enabled = true;
                            }
                            else
                            {
                                MI_Previous.Enabled = false;
                            }
                            LoadQuestion();
                        }
                        return;
                    }
                }
            }
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            // Сохранение результатов теста
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            CountResult();
        }

        private void CountResult()
        {           
            // Подсчет результатов
            for (int i = 0; i < dtAnswers.Length; i++)
            {
                int x = 0;
                if (x < SelectedAnswers[i].Count)
                {
                    switch ((int)dtQuestions.Rows[i].ItemArray[2])
                    {
                        case 0:
                            //один ответ
                            for (int j = 0; j < dtAnswers[i].Rows.Count; j++)
                            {
                                if (SelectedAnswers[i][x] == dtAnswers[i].Rows[j].ItemArray[1].ToString())
                                {
                                    if ((bool)dtAnswers[i].Rows[j].ItemArray[2])
                                    {
                                        ResultAnswer[i][2] = "1";
                                        ResultAnswer[i][3] = dtAnswers[i].Rows[j].ItemArray[3].ToString();
                                        TestResult += float.Parse(dtAnswers[i].Rows[j].ItemArray[3].ToString());
                                    }
                                    if (SelectedAnswers[i].Count > x + 1)
                                    {
                                        x++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                            break;
                        case 1: //несколько ответов 
                            string rightAnswer = "";
                            
                            for (int j = 0; j < dtAnswers[i].Rows.Count; j++)
                            {
                                if ((bool)dtAnswers[i].Rows[j].ItemArray[2])
                                {
                                    if (rightAnswer == "")
                                    {
                                        rightAnswer = dtAnswers[i].Rows[j].ItemArray[1].ToString();
                                    }
                                    else
                                    {
                                      
                                        rightAnswer += "; " + dtAnswers[i].Rows[j].ItemArray[1].ToString();
                                    }                                   
                                }
                            }
                            if (ResultAnswer[i][1] == rightAnswer)
                            {
                                ResultAnswer[i][2] = "1";
                                for (int k =0;k< dtAnswers[i].Rows.Count; k++)
                                {
                                    if (dtAnswers[i].Rows[k].ItemArray[3].ToString() != "0")
                                    {
                                        ResultAnswer[i][3] = dtAnswers[i].Rows[k].ItemArray[3].ToString();
                                        TestResult += float.Parse(dtAnswers[i].Rows[k].ItemArray[3].ToString());
                                        break;
                                    }
                                }                               
                            }
                            break;
                        case 2: //свободный ответ                           
                            if (SelectedAnswers[i][0].ToLower().Trim(' ') == dtAnswers[i].Rows[0].ItemArray[1].ToString().ToLower().Trim(' '))
                            {
                                ResultAnswer[i][2] = "1";
                                ResultAnswer[i][3] = dtAnswers[i].Rows[0].ItemArray[3].ToString();
                                TestResult += float.Parse(dtAnswers[i].Rows[0].ItemArray[3].ToString());
                            }
                            break;
                    }
                }
            }
            // Сохранение результатов теста
            string Grade = "null";
            if (Grade5 != 0)
            {
                if (TestResult >= Grade5)
                {
                    Grade = "5";
                }
                else if (TestResult >= Grade4)
                {
                    Grade = "4";
                }
                else if (TestResult >= Grade3)
                {
                    Grade = "3";
                }
                else
                {
                    Grade = "2";
                }
            }
            if (ID_Student!=-1) {                            
                string q = "insert into Result (ID_Student, TestName, Result, Grade, Try, Time, Date) " +
                    "values ("+ID_Student+", '"+TestName+"', "+ TestResult.ToString().Replace(',','.') + ", "+Grade+", "+Try+", '"+Time+"', '"+DateTime.Now.ToShortDateString()+"')";
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(q, sqlConnection);
                cmd.ExecuteNonQuery();
                q = "SELECT TOP 1 ID_Result FROM [Result] ORDER BY ID_Result DESC";
                cmd = new SqlCommand(q, sqlConnection);
                int ID_Result = int.Parse(cmd.ExecuteScalar().ToString());
                q = "insert into ResultAnswer (ID_Result, Question, Answer, Correct, Points) " +
                    "values ("+ ID_Result + ", '" + ResultAnswer[0][0] + "', '" + ResultAnswer[0][1] + "',"+ ResultAnswer[0][2] + " , "+ ResultAnswer[0][3].Replace(',','.') + ")";
                for (int i = 1; i < ResultAnswer.Length; i++)
                {
                    q += ", (" + ID_Result + ", '" + ResultAnswer[i][0] + "', '" + ResultAnswer[i][1] + "'," + ResultAnswer[i][2] + " , " + ResultAnswer[i][3].Replace(',', '.') + ")";
                    
                }
                cmd = new SqlCommand(q, sqlConnection);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            // Вывод окна с результатом
            string message = "Результат теста: " + TestResult + " из " + MaxPoints+ " баллов";
            if (Grade != "null")
            {
                message += ".\nОценка: " + Grade;
            }
            MessageBox.Show(message, "Результат тестирования", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
        private void StartTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK) {
                if (ID_Student != -1) {
                    e.Cancel = true;
                    return;
                }
                DialogResult dialogResult = MessageBox.Show("Ответы не будут сохранены. Вы точно хотите закрыть это окно?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
