using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quan_ly_bai_do_xe_main
{
    public partial class SQL : UserControl
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        string connectionstring = @"Data Source=DESKTOP-VPC6GRQ\SQLDEV2020;Initial Catalog=Quan_ly_bai_do_xe;Integrated Security=True";
        /*-----------*/
        int vi_tri_trong;
        public SQL()
        {
            InitializeComponent();
            Load_data(GetAllData());
        }

        private void SQL_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[2].Width = 120;
            dataGridView1.Columns[3].Width = 145;
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].Width = 100;
            timer1.Start();
        }
        void Load_data(DataSet data)
        {
            dataGridView1.DataSource = data.Tables[0];
        }
        DataSet GetAllData()
        {
            DataSet data = new DataSet();
            //
            string query = "select * from Bai_do_xe";
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }
        /*------------Search-------------*/
        DataSet Search_Data(string information)
        {
            DataSet data = new DataSet();
            //
            string query = "select * from Bai_do_xe where Location = '" + information + "'";
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);

                connection.Close();
            }
            return data;
        }
        /*-------------------------------*/
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Load_data(GetAllData());
            /*---------------*/
            lb_trong.Text = dem_vi_tri_trong().ToString();

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Load_data(Search_Data(txt_vitri.Text));
            //
            try
            {
                int i = dataGridView1.CurrentRow.Index;
                txt_vitri.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                txt_trangthai.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                txt_bienso.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                txt_loaixe.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                txt_maso.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
                txt_time.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            }
            catch
            {
                MessageBox.Show("Không tìm thấy đối tượng", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txt_vitri.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txt_trangthai.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txt_bienso.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            txt_loaixe.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            txt_maso.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txt_time.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            lb_hour.Text = dt.ToString("hh:mm:ss");
            lb_date.Text = dt.ToString("dd/MM/yyyy");
        }

        private void lb_tong_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        int dem_vi_tri_trong()
        {
            int index = 24;
            /*-----------------*/
            DataTable data = new DataTable();
            string query = "select Status from Bai_do_xe ";
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            for (int x = 0; x < 24; x++)
            {
                if (data.Rows[x][0].ToString().Trim() == "Co") index--;
            }
            /*-----------------*/
            return index;
        }
    }
}
