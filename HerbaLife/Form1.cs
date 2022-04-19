using System;
using MetroFramework;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Application = System.Windows.Forms.Application;
using System.IO;
using System.Windows.Forms;

namespace HerbaLife
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        //this.BackgroundImage = new Bitmap(@"W:\Проекты\HerbaLife\HerbaLife\HerbaLife\Resources\8-1.jpg");
        //this.BackgroundImageLayout = ImageLayout.Center;
        //public DataGridView dg1 = new DataGridView();
        static public string mybdpath = @"HerbaLife.mdb";
        static public string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HerbaLife.mdb";
        public void AddUpdate(string a)
        {
            using (OleDbConnection conn = new OleDbConnection(con))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                conn.Open();
                OleDbCommand com = new OleDbCommand(a, conn);
                conn.Close();
                adapter.SelectCommand = com;
                DataTable table = new DataTable();
                adapter.Fill(table);
                metroGrid1.DataSource=(table);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddUpdate("Select idc, fio As [ФИО], phone As [Телефон], age As [Возраст], private As [Приглашение], hpb As [День Рождения], visit As [Кол-во посещений] From Client");
            metroGrid1.Columns[0].Visible = false;
            metroGrid1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//---------------------------------------------------------------
        }

        private void ДобавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Client C = new Client();
                C.dg1 = metroGrid1;
                C.metroButton1.Text = "Добавить";
                C.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void ИзменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Client C = new Client();
                C.dg1 = metroGrid1;
                C.metroButton1.Text = "Изменить";
                C.id = Convert.ToInt32(metroGrid1[0, metroGrid1.CurrentRow.Index].Value);
                C.selected = Convert.ToInt32(metroGrid1.Rows[metroGrid1.CurrentRow.Index].Cells[0].Value);
                C.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Mtb1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CurrencyManager cManager = metroGrid1.BindingContext[metroGrid1.DataSource, metroGrid1.DataMember] as CurrencyManager;
                cManager.SuspendBinding();
                cManager.ResumeBinding();
                for (int i = 0; i < metroGrid1.RowCount; i++)
                {
                    metroGrid1.Rows[i].Selected = false;
                }
                if (mtb1.Text == "")
                    for (int i = 0; i < metroGrid1.RowCount; i++)
                    {
                        metroGrid1.Rows[i].Selected = false;
                        metroGrid1.Rows[i].Visible = true;
                    }
                else
                {
                    for (int i = 0; i < metroGrid1.RowCount; i++)
                    {
                        metroGrid1.Rows[i].Selected = false;
                        for (int j = 0; j < metroGrid1.ColumnCount; j++)
                            if (metroGrid1.Rows[i].Cells[j].Value != null)

                                if (metroGrid1.Rows[i].Cells[j].Value.ToString().Contains(mtb1.Text))
                                {
                                    metroGrid1.Rows[i].Selected = true;
                                    metroGrid1.Rows[i].Visible = true;
                                    break;
                                }
                                else
                                {
                                    metroGrid1.Rows[i].Selected = false;
                                    metroGrid1.Rows[i].Visible = false;
                                }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ахтунг, обращайтесь к Андрею!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void УдалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var question = MessageBox.Show("Вы действительно желаете удалить данные?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (question == DialogResult.Yes)
                {
                    AddUpdate("delete from Client where idc =" + metroGrid1[0, metroGrid1.CurrentRow.Index].Value.ToString());
                    AddUpdate("Select idc, fio As [ФИО], phone As [Телефон], age As [Возраст], private As [Приглашение], hpb As [День Рождения], visit As [Кол-во посещений] From Client");
                    metroGrid1.Columns[0].Visible = false;
                    MessageBox.Show("Запись удалена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void ПосещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Visited C = new Visited();
                C.id = Convert.ToInt32(metroGrid1[0, metroGrid1.CurrentRow.Index].Value);
                C.name = Convert.ToString(metroGrid1[1, metroGrid1.CurrentRow.Index].Value);
                C.visit = Convert.ToString(metroGrid1[6, metroGrid1.CurrentRow.Index].Value);
            C.dg1 = metroGrid1;
            C.ShowDialog();
        }
            catch
            {
                MessageBox.Show("Ахтунг, обращайтесь к Андрею!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
}

        private void ЗамерыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                zameri C = new zameri();
                C.id = Convert.ToInt32(metroGrid1[0, metroGrid1.CurrentRow.Index].Value);
                C.name = Convert.ToString(metroGrid1[1, metroGrid1.CurrentRow.Index].Value);
                C.ShowDialog();
        }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
}

        private void ОплатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Oplata C = new Oplata();
                C.id = Convert.ToInt32(metroGrid1[0, metroGrid1.CurrentRow.Index].Value);
                C.name = Convert.ToString(metroGrid1[1, metroGrid1.CurrentRow.Index].Value);
            C.dgg1 = metroGrid1;
                C.ShowDialog();
        }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
}
    }
    }
 
       
