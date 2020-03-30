using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Data.SqlClient;

namespace Quan_ly_bai_do_xe_main
{
    public partial class Quan_ly : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        string connectionstring = @"Data Source=DESKTOP-VPC6GRQ\SQLDEV2020;Initial Catalog=Quan_ly_bai_do_xe;Integrated Security=True";
        public Quan_ly()
        {
            InitializeComponent();
            // Cài đặt các thông số cho COM
            // Mảng string port để chứ tất cả các cổng COM đang có trên máy tính
            string[] ports = SerialPort.GetPortNames();
            // Thêm toàn bộ các COM đã tìm được vào combox cbCom
            cbCom.Items.AddRange(ports); // Sử dụng AddRange thay vì dùng foreach 
            Serial_port.ReadTimeout = 1000;
            // P.DataReceived += new SerialDataReceivedEventHandler(DataReceive);
            // Cài đặt cho BaudRate
            string[] BaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
            cbRate.Items.AddRange(BaudRate);
            // Cài đặt cho DataBits
            string[] Databits = { "6", "7", "8" };
            cbData.Items.AddRange(Databits);
            //Cho Parity
            string[] Parity = { "None", "Odd", "Even" };
            cbParity.Items.AddRange(Parity);
            //Cho Stop bit
            string[] stopbit = { "1", "1.5", "2" };
            cbStop.Items.AddRange(stopbit);
        }

        private void Quan_ly_Load(object sender, EventArgs e)
        {
            Serial_port.Encoding = Encoding.GetEncoding(28591);
            cbCom.SelectedIndex = 0; // chọn COM được tìm thấy đầu tiên
            cbRate.SelectedIndex = 3; // 9600
            cbData.SelectedIndex = 2; // 8
            cbParity.SelectedIndex = 0; // None
            cbStop.SelectedIndex = 0; // None
            groupBox1.Enabled = true;
            groupBox3.Enabled = false;
        }

        private void cbCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Close(); // Nếu đang mở Port thì phải đóng lại
            }
            Serial_port.PortName = cbCom.SelectedItem.ToString(); // Gán PortName bằng COM đã chọn
        }

        private void cbRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Close();
            }
            Serial_port.BaudRate = Convert.ToInt32(cbRate.Text);
        }

        private void cbData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Close();
            }
            Serial_port.DataBits = Convert.ToInt32(cbData.Text);
        }

        private void cbParity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Close();
            }
            switch (cbParity.SelectedItem.ToString())
            {
                case "Odd":
                    Serial_port.Parity = Parity.Odd;
                    break;
                case "None":
                    Serial_port.Parity = Parity.None;
                    break;
                case "Even":
                    Serial_port.Parity = Parity.Even;
                    break;
            }
        }

        private void cbStop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Close();
            }
            switch (cbStop.SelectedItem.ToString())
            {
                case "1":
                    Serial_port.StopBits = StopBits.One;
                    break;
                case "1.5":
                    Serial_port.StopBits = StopBits.OnePointFive;
                    break;
                case "2":
                    Serial_port.StopBits = StopBits.Two;
                    break;
            }
        }

        private void btKetnoi_Click(object sender, EventArgs e)
        {
            try
            {
                Serial_port.Open();
                groupBox1.Enabled = false;
                groupBox3.Enabled = true;
                Load_data();
            }
            catch
            {
                MessageBox.Show("Không thể mở công COM");
            }
        }

        private void btNgat_Click(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Close();
                groupBox1.Enabled = true;
                groupBox3.Enabled = false;
            }
        }
        // Hàm nhận dữ liệu
        Action<string> serialPortReceiverAction;
        private void Serial_port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            serialPortReceiverAction = serialPortReceiver;
            try
            {
                this.BeginInvoke(serialPortReceiverAction, Serial_port.ReadExisting());
            }
            catch { }
        }
        private void serialPortReceiver(string input)
        {
            txtNumberData.Text = "";
            char[] chrs = input.ToCharArray();
            foreach (char c in chrs)
            {
                txtNumberData.Text += ((int)c).ToString();
            }
            /*---------------------------*/
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x01) == 0x01) Set(true, "001"); else Set(false, "001");
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x02) == 0x02) Set(true, "002"); else Set(false, "002");
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x04) == 0x03) Set(true, "003"); else Set(false, "003");
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x08) == 0x08) Set(true, "004"); else Set(false, "004");
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x10) == 0x10) Set(true, "005"); else Set(false, "005");
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x20) == 0x20) Set(true, "006"); else Set(false, "006");
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x40) == 0x40) Set(true, "007"); else Set(false, "007");
            if (Convert.ToInt32(Int32.Parse(txtNumberData.Text) & 0x80) == 0x80) Set(true, "008"); else Set(false, "008");
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /*-----------------------------------------*/
        void Load_data()
        {
            dataGridView1.DataSource = GetAllData().Tables[0];
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
        public void Set(Boolean Co_xe, string Vi_tri)
        {
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                command = connection.CreateCommand();
                if(Co_xe == true)
                {
                    command.CommandText = "update Bai_do_xe set Tinh_trang = N'" + "Có xe" + "' where Vi_tri = '" + Vi_tri + "'";
                }
                else
                {
                    command.CommandText = "update Bai_do_xe set Tinh_trang = N'" + "Trống" + "' where Vi_tri = '" + Vi_tri + "'";
                }
                command.ExecuteNonQuery();

                Load_data();
                connection.Close();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Set(true,"003");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
