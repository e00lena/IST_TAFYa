using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace IST_TAiFYa
{
    public partial class Structure : Form
    {
        DataTable dtFacuties;
        DataTable[] dtSpecialties;
        DataTable[][] dtGroups;
        SqlConnection sqlConnection = new Connection().GetConnection();
        public Structure()
        {
            InitializeComponent();
            sqlConnection.Open();
            string q = "select [Value] from [Parameter] where [Parameter] = 'Organization'";
            SqlCommand cmd = new SqlCommand(q, sqlConnection);
            Text += " "+cmd.ExecuteScalar();
            sqlConnection.Close();
            FillNodes();
            treeView1.ExpandAll();
        }
        private void FillNodes()
        {
            sqlConnection.Open();
            dtFacuties = new DataTable();
            string q;
            SqlDataAdapter adapt;
            treeView1.Nodes.Clear();
            //Список факультетов
            q = "select ID_Faculty, Faculty from [Faculty]";
            adapt = new SqlDataAdapter(q, sqlConnection);
            adapt.Fill(dtFacuties);
            dtSpecialties = new DataTable[dtFacuties.Rows.Count];
            dtGroups = new DataTable[dtFacuties.Rows.Count][];
            for (int i = 0; i < dtFacuties.Rows.Count; i++)
            {
                treeView1.Nodes.Add(dtFacuties.Rows[i].ItemArray[1].ToString());
                dtSpecialties[i] = new DataTable();
                q = "select ID_Specialty, Specialty from [Specialty] where ID_Faculty = " + dtFacuties.Rows[i].ItemArray[0];
                adapt = new SqlDataAdapter(q, sqlConnection);
                adapt.Fill(dtSpecialties[i]);
                dtGroups[i] = new DataTable[dtSpecialties[i].Rows.Count];
                for (int j = 0; j < dtSpecialties[i].Rows.Count; j++)
                {
                    treeView1.Nodes[i].Nodes.Add(dtSpecialties[i].Rows[j].ItemArray[1].ToString());
                    dtGroups[i][j] = new DataTable();
                    q = "select ID_Group, [Group] from [Group] where ID_Specialty = " + dtSpecialties[i].Rows[j].ItemArray[0];
                    adapt = new SqlDataAdapter(q, sqlConnection);
                    adapt.Fill(dtGroups[i][j]);
                    for (int k = 0; k < dtGroups[i][j].Rows.Count; k++)
                    {
                        treeView1.Nodes[i].Nodes[j].Nodes.Add(dtGroups[i][j].Rows[k].ItemArray[1].ToString());
                    }
                }
            }
            sqlConnection.Close();
        }
        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {           
                switch (treeView1.SelectedNode.Level)
                {
                    case 0:
                        CreateFaculty CreateFaculty = new CreateFaculty();
                        CreateFaculty.Text = "Редактирование факультета";
                        CreateFaculty.SetID_Faculty((int)dtFacuties.Rows[treeView1.SelectedNode.Index].ItemArray[0]);
                        if (CreateFaculty.ShowDialog() == DialogResult.OK)
                        {
                            FillNodes();
                            treeView1.ExpandAll();
                        }
                        break;
                    case 1:
                        CreateSpecialty CreateSpecialty = new CreateSpecialty();
                        CreateSpecialty.Text = "Редактирование направления";
                        CreateSpecialty.SetID_Specialty((int)dtSpecialties[treeView1.SelectedNode.Parent.Index].Rows[treeView1.SelectedNode.Index].ItemArray[0], treeView1.SelectedNode.Parent.Index);
                        if (CreateSpecialty.ShowDialog() == DialogResult.OK)
                        {
                            FillNodes();
                            treeView1.ExpandAll();
                        }
                        break;
                    case 2:
                        CreateGroup CreateGroup = new CreateGroup();
                        CreateGroup.Text = "Редактирование группы";
                        int ID_Group = (int)dtGroups[treeView1.SelectedNode.Parent.Parent.Index][treeView1.SelectedNode.Parent.Index].Rows[treeView1.SelectedNode.Index].ItemArray[0];
                        CreateGroup.SetID_Group(ID_Group, treeView1.SelectedNode.Parent.Index, treeView1.SelectedNode.Parent.Parent.Index);
                        if (CreateGroup.ShowDialog() == DialogResult.OK)
                        {
                            FillNodes();
                            treeView1.ExpandAll();
                        }
                        break;
                }
            }
        }

        private void MI_AddFaculty_Click(object sender, EventArgs e)
        {
            CreateFaculty CreateFaculty = new CreateFaculty();
            if (CreateFaculty.ShowDialog() == DialogResult.OK)
            {
                FillNodes();
                treeView1.ExpandAll();
            }
        }

        private void MI_AddSpecialty_Click(object sender, EventArgs e)
        {
            CreateSpecialty CreateSpecialty = new CreateSpecialty();
            if (CreateSpecialty.ShowDialog() == DialogResult.OK)
            {
                FillNodes();
                treeView1.ExpandAll();
            }
        }

        private void MI_AddGroup_Click(object sender, EventArgs e)
        {
            CreateGroup CreateGroup = new CreateGroup();
            if (CreateGroup.ShowDialog() == DialogResult.OK)
            {
                FillNodes();
                treeView1.ExpandAll();
            }
        }

        private void MI_Delete_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                DialogResult r;
                string q = "";
                SqlConnection sqlConnection = new Connection().GetConnection();
                sqlConnection.Open();
                SqlCommand cmd;

                switch (treeView1.SelectedNode.Level)
                {
                    case 0:
                        r = MessageBox.Show("Вы дествительно хотите удалить факультет \"" + treeView1.SelectedNode.Text + "\"? Все направления и группы на этом факультете также будут удалены.", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (r == DialogResult.Yes)
                        {
                            int ID_Faculty = (int)dtFacuties.Rows[treeView1.SelectedNode.Index].ItemArray[0];
                            q = "select ID_Student from [Student] left join [Group] on [Student].ID_Group = [Group].ID_Group left join [Specialty] on [Group].ID_Specialty = Specialty.ID_Specialty where ID_Faculty = " + ID_Faculty;
                            cmd = new SqlCommand(q, sqlConnection);
                            if (cmd.ExecuteScalar() != DBNull.Value)
                            {
                                MessageBox.Show("Вы не можете удалить факультет \"" + treeView1.SelectedNode.Text + "\" так как к нему причислены студенты. Обратитесь к Администратору.", "Удаление запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            int ID_Specialty;
                            for (int i = 0; i < dtSpecialties[treeView1.SelectedNode.Index].Rows.Count; i++)
                            {
                                ID_Specialty = (int)dtSpecialties[treeView1.SelectedNode.Index].Rows[i].ItemArray[0];
                                q = "delete from [Group] where ID_Specialty = " + ID_Specialty;
                                cmd = new SqlCommand(q, sqlConnection);
                                cmd.ExecuteNonQuery();
                            }
                            q = "delete from [Specialty] where ID_Faculty = " + ID_Faculty;
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();
                            q = "delete from [Faculty] where ID_Faculty = " + ID_Faculty;
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 1:
                        r = MessageBox.Show("Вы дествительно хотите удалить направление \"" + treeView1.SelectedNode.Text + "\"? Все группы на этом направлении также будут удалены.", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (r == DialogResult.Yes)
                        {
                            int ID_Specialty = (int)dtSpecialties[treeView1.SelectedNode.Parent.Index].Rows[treeView1.SelectedNode.Index].ItemArray[0];
                            q = "select ID_Student from [Student] left join [Group] on [Student].ID_Group = [Group].ID_Group where ID_Specialty = " + ID_Specialty;
                            cmd = new SqlCommand(q, sqlConnection);
                            if (cmd.ExecuteScalar() != DBNull.Value)
                            {
                                MessageBox.Show("Вы не можете удалить направление \"" + treeView1.SelectedNode.Text + "\" так как к нему причислены студенты. Обратитесь к Администратору.", "Удаление запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            q = "delete from [Group] where ID_Specialty = " + ID_Specialty;
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();
                            q = "delete from [Specialty] where ID_Specialty = " + ID_Specialty;
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                    case 2:
                        r = MessageBox.Show("Вы дествительно хотите удалить группу \"" + treeView1.SelectedNode.Text + "\"?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (r == DialogResult.Yes)
                        {
                            int ID_Group = (int)dtGroups[treeView1.SelectedNode.Parent.Parent.Index][treeView1.SelectedNode.Parent.Index].Rows[treeView1.SelectedNode.Index].ItemArray[0];
                            q = "select ID_Student from [Student] where ID_Group = " + ID_Group;
                            cmd = new SqlCommand(q, sqlConnection);
                            if (cmd.ExecuteScalar() != null)
                            {
                                MessageBox.Show("Вы не можете удалить группу \"" + treeView1.SelectedNode.Text + "\" так как к ней причислены студенты. Обратитесь к Администратору.", "Удаление запрещено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            q = "delete from [Group] where ID_Group = " + ID_Group;
                            cmd = new SqlCommand(q, sqlConnection);
                            cmd.ExecuteNonQuery();
                        }
                        break;
                }
                sqlConnection.Close();
                FillNodes();
                treeView1.ExpandAll();
            }
        }
    }
}
