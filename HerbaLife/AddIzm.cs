using System;
using MetroFramework;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Application = System.Windows.Forms.Application;
using System.IO;
using System.Windows.Forms;

namespace HerbaLife
{
    public partial class AddIzm : MetroFramework.Forms.MetroForm
    {
        public AddIzm()
        {
            InitializeComponent();
        }

        static public string mybdpath = @"HerbaLife.mdb";
        static public string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HerbaLife.mdb";
        public int id,selected;
        public string text1, name;
        public DataGridView dg1 = new DataGridView();

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

        private void Mtb1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar("."))) return;
            else
                e.Handled = true;
        }

        private void Mtb2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar("."))) return;
            else
                e.Handled = true;
        }

        private void Mtb3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b' ) return;
            else
                e.Handled = true;
        }

        private void Mtb4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void Mtb5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar("."))) return;
            else
                e.Handled = true;
        }

        private void Mtb6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar("."))) return;
            else
                e.Handled = true;
        }

        private void Mtb7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar("."))) return;
            else
                e.Handled = true;
        }

        private void Mtb8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar("."))) return;
            else
                e.Handled = true;
        }

        private void Mtb9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | e.KeyChar == '\b') return;
            else
                e.Handled = true;
        }

        private void Mtb10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar(".")) | (e.KeyChar == Convert.ToChar("/"))) return;
            else
                e.Handled = true;
        }

        private void Mtb11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar(".")) | (e.KeyChar == Convert.ToChar("/"))) return;
            else
                e.Handled = true;
        }
        private void Mtb12_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar(".")) | (e.KeyChar == Convert.ToChar("/"))) return;
            else
                e.Handled = true;
        }
        private void Mtb13_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) | e.KeyChar == '\b' | (e.KeyChar == Convert.ToChar(".")) | (e.KeyChar == Convert.ToChar("/"))) return;
            else
                e.Handled = true;
        }
        private void MetroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroButton1.Text == "Добавить")
                {
                    if ((mtb1.Text == "") || (mtb2.Text == "") || (mtb3.Text == "") || (mtb4.Text == "") || (mtb5.Text == "") || (mtb6.Text == "") || (mtb7.Text == "") || (mtb8.Text == "") || (mtb9.Text == "") || (mtb10.Text == "") || (mtb11.Text == "") || (mtb12.Text == "") || (mtb13.Text == ""))
                    {
                        MessageBox.Show("Заполните все поля!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    else
                    {
                        //AddUpdate("INSERT INTO parametrs (idc,datezam,massa,fat,lvlobmvv,metabolage,water,fatin,costi,muskuli,fistip,grud,talia,jivot,bedra) VALUES ('" + id + "','" + DateTime.Now.ToShortDateString() + "','" + mtb1.Text + "','" + mtb2.Text + "','" + mtb3.Text + "','" + mtb4.Text + "','" + mtb5.Text + "','" + mtb6.Text + "','" + mtb7.Text + "','" + mtb8.Text + "','" + mtb9.Text + "','" + mtb10.Text + "','" + mtb11.Text + "','" + mtb12.Text + "','" + mtb13.Text + "')");
                        AddUpdate("INSERT INTO parametrs (idc,datezam,massa,fat,lvlobmvv,metabolage,water,fatin,costi,muskuli,fistip,grud,talia,jivot,bedra) VALUES ('" + id + "','" + metroDateTime1.Value.ToShortDateString() + "','" + mtb1.Text + "','" + mtb2.Text + "','" + mtb3.Text + "','" + mtb4.Text + "','" + mtb5.Text + "','" + mtb6.Text + "','" + mtb7.Text + "','" + mtb8.Text + "','" + mtb9.Text + "','" + mtb10.Text + "','" + mtb11.Text + "','" + mtb12.Text + "','" + mtb13.Text + "')");
                        AddUpdate("SELECT idparam,idc,datezam AS [Дата замера],massa AS [Вес],fat AS [% жира],lvlobmvv AS [Уровень обмена в-в],metabolage AS [Метаболический возраст],water AS [% воды],fatin AS [% внутреннего жира],costi AS [Костная масса],muskuli AS [Мышечная масса],fistip AS [Физический тип],grud AS [Грудь],talia AS [Талия],jivot AS [Живот],bedra AS [Бёдра] FROM parametrs WHERE idc=" + id + "");
                        dg1.Columns[0].Visible = false;
                        dg1.Columns[1].Visible = false;
                        MessageBox.Show("Запись Добавлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Close();
                    }
                }
                else
                {
                    var question = MessageBox.Show("Вы действительно желаете изменить данные?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (question == DialogResult.Yes)
                    {
                        AddUpdate("Update parametrs SET massa ='" + mtb1.Text + "', fat ='" + mtb2.Text + "', lvlobmvv ='" + mtb3.Text + "', metabolage ='" + mtb4.Text + "', water ='" + mtb5.Text + "', fatin ='" + mtb6.Text + "', costi ='" + mtb7.Text + "', muskuli ='" + mtb8.Text + "', fistip ='" + mtb9.Text + "', grud ='" + mtb10.Text + "', talia ='" + mtb11.Text + "', jivot ='" + mtb12.Text + "', bedra ='" + mtb13.Text + "'WHERE idparam =" + dg1[0, dg1.CurrentRow.Index].Value.ToString() + ";");
                        AddUpdate("SELECT idparam,idc,datezam AS [Дата замера],massa AS [Вес],fat AS [% жира],lvlobmvv AS [Уровень обмена в-в],metabolage AS [Метаболический возраст],water AS [% воды],fatin AS [% внутреннего жира],costi AS [Костная масса],muskuli AS [Мышечная масса],fistip AS [Физический тип],grud AS [Грудь],talia AS [Талия],jivot AS [Живот],bedra AS [Бёдра] FROM parametrs WHERE idc=" + id + "");
                        dg1.Columns[0].Visible = false;
                        dg1.Columns[1].Visible = false;
                        MessageBox.Show("Запись изменена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись, иначе обратитесь к Андрею и запишите где и когда была ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        private void AddIzm_Load(object sender, EventArgs e)
        {
            try
            {
                if (metroButton1.Text == "Изменить")
                {
                    OleDbConnection conn = new OleDbConnection(con);
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand("Select * From parametrs WHERE idc =" + id, conn);
                    OleDbDataReader sqlReader = comm.ExecuteReader();
                    sqlReader.Read();
                    mtb1.Text = sqlReader[3].ToString();
                    mtb2.Text = sqlReader[4].ToString();
                    mtb3.Text = sqlReader[5].ToString();
                    mtb4.Text = sqlReader[6].ToString();
                    mtb5.Text = sqlReader[7].ToString();
                    mtb6.Text = sqlReader[8].ToString();
                    mtb7.Text = sqlReader[9].ToString();
                    mtb8.Text = sqlReader[10].ToString();
                    mtb9.Text = sqlReader[11].ToString();
                    mtb10.Text = sqlReader[12].ToString();
                    mtb11.Text = sqlReader[13].ToString();
                    mtb12.Text = sqlReader[14].ToString();
                    mtb13.Text = sqlReader[15].ToString();
                    conn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись, иначе обратитесь к Андрею и запишите где и когда была ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
    }
}
