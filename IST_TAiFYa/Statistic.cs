using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace IST_TAiFYa
{
    public partial class Statistic : Form
    {
        SqlConnection sqlConnection = new Connection().GetConnection();
        SqlDataAdapter adapt;
        DataTable dtTests, dtGroups;
        string query = "";
        public Statistic()
        {
            InitializeComponent();
            query = "select * from StatisticsView";
            LoadData();
            dtTests = new DataTable();
            query = "select distinct [TestName] from Result";
            adapt = new SqlDataAdapter(query, sqlConnection);
            adapt.Fill(dtTests);
            cbTests.Items.Clear();
            cbTests.Items.Add("<не выбрано>");
            cbTests.SelectedIndex = 0;
            for (int i = 0; i < dtTests.Rows.Count;i++)
            {
                cbTests.Items.Add(dtTests.Rows[i].ItemArray[0]);
            }
            dtGroups = new DataTable();
            query = "select distinct [Группа] from StatisticsView";
            adapt = new SqlDataAdapter(query, sqlConnection);
            adapt.Fill(dtGroups);
            cbGroups.Items.Clear();
            cbGroups.Items.Add("<не выбрано>");
            cbGroups.SelectedIndex = 0;
            for (int i = 0; i < dtGroups.Rows.Count; i++)
            {
                cbGroups.Items.Add(dtGroups.Rows[i].ItemArray[0]);
            }
        }
        private void LoadData()
        {          
            DataTable dt = new DataTable();                    
            adapt = new SqlDataAdapter(query, sqlConnection);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                if (dataGridView1.Columns[i].HeaderText.Contains("ID"))
                {
                    dataGridView1.Columns[i].Visible = false;
                }
            }          
        }
        public void SetStudentMode(int ID_Student)
        {
            menuStrip1.Hide();
            splitContainer1.Panel1.Hide();
            query = "select * from StatisticsView where ID_Student = " + ID_Student;
            LoadData();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StatisticDetail StatisticDetail = new StatisticDetail();
            string q = "select * from ResultAnswerView where ID_Result = " + dataGridView1.CurrentRow.Cells["ID_Result"].Value;
            StatisticDetail.LoadData(q);
            StatisticDetail.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "select * from StatisticsView";
            if (cbGroups.SelectedIndex!=0 && cbTests.SelectedIndex != 0)
            {
                query += " where [Группа] = '"+ cbGroups.Items[cbGroups.SelectedIndex] + "' and [Название теста] = '"+ cbTests.Items[cbTests.SelectedIndex] + "'";
            }
            else if (cbGroups.SelectedIndex != 0)
            {
                query += " where [Группа] = '" + cbGroups.Items[cbGroups.SelectedIndex] + "'";
            }
            else if (cbTests.SelectedIndex != 0)
            {
                query += " where [Название теста] = '" + cbTests.Items[cbTests.SelectedIndex] + "'";
            }
            LoadData();
        }
    }
}
