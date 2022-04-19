using System;
using MetroFramework;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Application = System.Windows.Forms.Application;
using System.IO;
using System.Windows.Forms;

namespace HerbaLife
{
    public partial class Client : MetroFramework.Forms.MetroForm
    {
        public Client()
        {
            InitializeComponent();
        }

        static public string mybdpath = @"HerbaLife.mdb";
        static public string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HerbaLife.mdb";
        public DataGridView dg1 = new DataGridView();
        public int id, selected;

        public void AddUpdate(string a)
        {
            try
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
                    dg1.DataSource = (table);
                }
            }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись, иначе обратитесь к Андрею и запишите где и когда была ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void Client_Load(object sender, EventArgs e)
        {
            try
            {
                if (metroButton1.Text == "Изменить")
                {
                    OleDbConnection conn = new OleDbConnection(con);
                    conn.Open();
                OleDbCommand comm = new OleDbCommand("Select * From Client WHERE idc =" + id, conn);
                    OleDbDataReader sqlReader = comm.ExecuteReader();
                    sqlReader.Read();
                    mtb1.Text = sqlReader[1].ToString();
                    mtb2.Text = sqlReader[2].ToString();
                    mtb3.Text = sqlReader[3].ToString();
                    mtb4.Text = sqlReader[4].ToString();
                    mtb5.Text = sqlReader[6].ToString();
                    conn.Close();
                }
        }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись, иначе обратитесь к Андрею и запишите где и когда была ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void Mtb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') | (e.KeyChar == '+')) return;
            else
                e.Handled = true;
        }

        private void Mtb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((Char.IsNumber(e.KeyChar) | e.KeyChar == '\b')) return;
            else
                e.Handled = true;
        }

        private void Mtb5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsNumber(e.KeyChar) | e.KeyChar == '\b')) return;
            else
                e.Handled = true;
        }

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroButton1.Text == "Добавить")
                {
                    AddUpdate("INSERT INTO Client (fio,phone,age,private,hpb,visit) VALUES ('" + mtb1.Text + "','" + mtb2.Text + "','" + mtb3.Text + "','" + mtb4.Text + "','" + mdt1.Value.ToShortDateString() + "','" + mtb5.Text + "')");
                    mtb1.Text = "";
                    mtb2.Text = "";
                    mtb3.Text = "";
                    mtb4.Text = "";
                    mtb5.Text = "";
                    MessageBox.Show("Клиент добавлен!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    AddUpdate("Select idc, fio As [ФИО], phone As [Телефон], age As [Возраст], private As [Приглашение], hpb As [День Рождения], visit As [Кол-во посещений] From Client");
                    dg1.Columns[0].Visible = false;
                }
                else
                {
                    var question = MessageBox.Show("Вы действительно желаете изменить данные?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (question == DialogResult.Yes)
                    {
                        AddUpdate("Update Client Set fio='" + mtb1.Text + "',phone='" + mtb2.Text + "',age='" + mtb3.Text + "',private='" + mtb4.Text + "',hpb='" + mdt1.Value.ToShortDateString() + "', visit='" + mtb5.Text + "' WHERE idc=" + id + ";");
                        mtb1.Text = "";
                        mtb2.Text = "";
                        mtb3.Text = "";
                        mtb4.Text = "";
                        mtb5.Text = "";
                        MessageBox.Show("Информация о клиенте изменена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        AddUpdate("Select idc, fio As [ФИО], phone As [Телефон], age As [Возраст], private As [Приглашение], hpb As [День Рождения], visit As [Кол-во посещений] From Client");
                        dg1.Columns[0].Visible = false;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Возможно вы не выбрали запись, иначе обратитесь к Андрею и запишите где и когда была ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
} 
