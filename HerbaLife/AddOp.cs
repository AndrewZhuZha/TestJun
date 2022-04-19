using System;
using MetroFramework;
using System.Data.OleDb;
using DataTable = System.Data.DataTable;
using Application = System.Windows.Forms.Application;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace HerbaLife
{
    public partial class AddOp : MetroFramework.Forms.MetroForm
    {
        public AddOp()
        {
            InitializeComponent();
        }

        //static public string mybdpath = @"HerbaLife.mdb";
        static public string con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=HerbaLife.mdb";
        public DataGridView dg1 = new DataGridView();
        public int id,vis,idop;
        public string visit;
        public DataGridView dgg1 = new DataGridView();

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
                dg1.DataSource = (table);
            }
        }
        public void Update(string a)
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
                dgg1.DataSource = (table);
            }
        }

        public void Viss()
        {
            string cmdtxt = "SELECT visit FROM Client Where idc=" + id + "";
            OleDbDataAdapter dA = new OleDbDataAdapter(cmdtxt, con);
            DataSet ds = new DataSet();
            dA.Fill(ds);
            try
            {
                visit = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
        }

        private void AddOp_Load(object sender, EventArgs e)
        {
            try
            {
                if (metroButton1.Text == "Изменить")
                {
                    OleDbConnection conn = new OleDbConnection(con);
                    conn.Open();
                    OleDbCommand comm = new OleDbCommand("Select * From oplata WHERE idop =" + idop, conn);
                    OleDbDataReader sqlReader = comm.ExecuteReader();
                    sqlReader.Read();
                    mtb2.Text = sqlReader[3].ToString();
                    mtb1.Text = sqlReader[4].ToString();
                    conn.Close();
                }
        }
            catch
            {
                MessageBox.Show("Возможно вы не выбрали запись, иначе обратитесь к Андрею и запишите где и когда была ошибка!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
}

        private void MetroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (metroButton1.Text == "Добавить")
                {
                    Viss();
                    string a = mtb1.Text;
                    vis = Convert.ToInt32(visit) + Convert.ToInt32(a);
                    AddUpdate("INSERT INTO oplata (idc,dateop,summa,kol) VALUES (" + id + ",'" + metroDateTime1.Value.ToShortDateString() + "','" + mtb2.Text + "','" + mtb1.Text + "')");
                    AddUpdate("Update Client Set visit='" + vis + "' WHERE idc=" + id + "");
                    AddUpdate("SELECT idop, idc, dateop AS [Дата оплаты], summa AS [Сумма], kol AS [Количество почещений] FROM oplata where idc=" + id + "");
                    Update("Select idc, fio As [ФИО], phone As [Телефон], age As [Возраст], private As [Приглашение], hpb As [День Рождения], visit As [Кол-во посещений] From Client");
                    dg1.Columns[1].Visible = false;
                    dg1.Columns[0].Visible = false;
                    mtb1.Text = "";
                    mtb2.Text = "";
                    MessageBox.Show("Запись добавлена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Close();
                }
                else
                {
                    Viss();
                    string a = mtb1.Text;
                    vis = Convert.ToInt32(visit) + Convert.ToInt32(a);
                    AddUpdate("Update oplata Set idc='"+id+"', dateop='"+metroDateTime1.Value.ToShortDateString()+"',summa='"+mtb2.Text+"',kol='"+mtb1.Text+"' Where idop="+idop+"");
                    AddUpdate("Update Client Set visit='" + vis + "' WHERE idc=" + id + "");
                    AddUpdate("SELECT idop, idc, dateop AS [Дата оплаты], summa AS [Сумма], kol AS [Количество почещений] FROM oplata where idc=" + id + "");
                    Update("Select idc, fio As [ФИО], phone As [Телефон], age As [Возраст], private As [Приглашение], hpb As [День Рождения], visit As [Кол-во посещений] From Client");
                    dg1.Columns[1].Visible = false;
                    dg1.Columns[0].Visible = false;
                    mtb1.Text = "";
                    mtb2.Text = "";
                    MessageBox.Show("Запись изменена!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.Close();
                }
        }
            catch
            {
                MessageBox.Show("Ахтунг, обращайтесь к Андрею!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
}
    }
}
