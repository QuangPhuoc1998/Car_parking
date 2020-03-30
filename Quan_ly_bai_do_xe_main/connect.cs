using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml;
using System.Data.SqlClient;

namespace Quan_ly_bai_do_xe_main
{
    public partial class connect : UserControl
    {
        string Receive_data_string;
        char[] Receive_data_char;
        string vi_tri_in;
        string ma_so_in;
        string ma_so_out;
        bool done = true;
        bool Car_in_signal = false;
        bool Car_out_signal = false;
        bool Admin_test = false;
        /* ERROR LIST
        E0 OKE
        E1 Đã có xe tại vị trí đó
        E2 Thẻ đã được xử dụng
        E3 Chưa đồng bộ dữ liệu
        E4 Có lỗi xảy ra
        E5 Thẻ chưa được xử dụng
        */
        /*-------------------SQL Server----------------------*/
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        string connectionstring = @"Data Source=DESKTOP-VPC6GRQ\SQLDEV2020;Initial Catalog=Quan_ly_bai_do_xe;Integrated Security=True";
        /*---------------------------------------------------*/
        public connect()
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
            //

        }

        private void connect_Load(object sender, EventArgs e)
        {
            Serial_port.Encoding = Encoding.GetEncoding(28591);
            cbCom.SelectedIndex = 0; // chọn COM được tìm thấy đầu tiên
            cbRate.SelectedIndex = 3; // 9600
            cbData.SelectedIndex = 2; // 8
            cbParity.SelectedIndex = 0; // None
            cbStop.SelectedIndex = 0; // None
            //
            gb_managament.Enabled = false;
            check_car_parking();
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

        private void btn_ketnoi_Click(object sender, EventArgs e)
        {
            try
            {
                Serial_port.Open();
                groupBox1.Enabled = false;
                gb_managament.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Không thể mở công COM");
            }
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Close();
                groupBox1.Enabled = true;
                gb_managament.Enabled = false;
            }
        }
        /*-------------------USB---------------------*/
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
            if (input != "\r")
            {
                Receive_data_string += input;
            }
            else
            {
                txt_receive.Text = Receive_data_string;
                Receive_data_char = Receive_data_string.ToCharArray();
                /*-------------------Car IN signal---------------------*/
                if (Receive_data_char[0] == 'i')
                {
                    Car_in_signal = true;
                }
                if (Car_in_signal == true && Car_out_signal == false)
                {
                    if (Receive_data_char[0] == 'L')
                    {
                        vi_tri_in = Receive_data_string.Substring(1);
                    }
                    else
                    if (Receive_data_char[0] == 'C')
                    {
                        ma_so_in = Receive_data_string.Substring(1);
                        /*--------------------------*/
                        DateTime dt = DateTime.Now;
                        /*--------------------------*/
                        Car_in(vi_tri_in, ma_so_in, dt.ToString("hh:mm:ss"), dt.ToString("dd/MM/yyyy"));
                        Car_in_signal = false;
                    }
                }
                /*-------------------Car OUT signal---------------------*/
                if (Receive_data_char[0] == 'o')
                {
                    Car_out_signal = true;
                }
                if (Car_out_signal == true && Car_in_signal == false)
                {
                    if (Receive_data_char[0] == 'C')
                    {
                        ma_so_out = Receive_data_string.Substring(1);
                        txt_maso.Text = ma_so_out;
                        txt_time.Text = "";
                        txt_date.Text = "";
                        /*--------------------------*/
                        Car_out(Cheack_location_car(ma_so_out));
                        Car_out_signal = false;
                    }
                }
                /*----------------------------------------*/
                    Receive_data_string = "";
            }
        }
        /*----------------------------------------*/
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (Serial_port.IsOpen)
            {
                Serial_port.Write(txt_send.Text);
            }
            else
            {
                MessageBox.Show("Chưa mở cổng COM", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void txt_send_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        /*-------------------Set location----------------------*/
        public void Set_status(Boolean Co_xe, string Vi_tri)
        {
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                command = connection.CreateCommand();
                if (Co_xe == true)
                {
                    command.CommandText = "update Bai_do_xe set Status = N'" + "Co" + "' where Location = '" + Vi_tri + "'";
                }
                else
                {
                    command.CommandText = "update Bai_do_xe set Status = N'" + "Ko" + "' where Location = '" + Vi_tri + "'";
                }
                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        /*-------------------Set location----------------------*/
        public void Set_ID_card_time(string ID_card, string time, string date, string Vi_tri)
        {
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                command = connection.CreateCommand();

                command.CommandText = "update Bai_do_xe set ID_card = N'" + ID_card + "',Time = '" + time + "', Date =  '" + date + "' where Location = '" + Vi_tri + "'";

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
        /*-------------------Set location----------------------*/
        private void btn_clr_Click(object sender, EventArgs e)
        {
            txt_send.Clear();
        }

        private void txt_receive_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Admin_test = true;
            Car_in(txt_vitri.Text, txt_maso.Text, txt_time.Text, txt_date.Text);
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        private void btn_Start_v2_Click(object sender, EventArgs e)
        {
            Admin_test = true;
            Car_out(txt_vitri.Text);
        }
        /*-------------------simulation----------------------*/
        /*---------IN----------*/
        /*---Time 1---*/
        private void Timer_1_Tick(object sender, EventArgs e)
        {
            pic_car.Location = new Point(pic_car.Location.X + 10, pic_car.Location.Y);
            if (pic_car.Location.X > 300)
            {
                Timer_1.Stop();
                pic_car.Visible = false;
                pic_car.Location = new Point(0, pic_car.Location.Y);
                pic_car_v2.Image = new Bitmap(Application.StartupPath + "\\picture\\er.png");
                Timer_2.Start();
            }
        }
        /*---Time 2---*/
        private void Timer_2_Tick(object sender, EventArgs e) // 284 184 84 -6
        {
            pic_car_v2.Location = new Point(pic_car_v2.Location.X, pic_car_v2.Location.Y - 10);
            if (pic_car_v2.Location.Y < 284)
            {
                pic_car_v2.Image = new Bitmap(Application.StartupPath + "\\picture\\123.png");
                Set_in(txt_vitri.Text);
                Timer_2.Stop();
                Timer_3.Start();
            }
        }
        /*---Time 3---*/
        private void Timer_3_Tick(object sender, EventArgs e)
        {
            pic_car_v2.Location = new Point(pic_car_v2.Location.X, pic_car_v2.Location.Y + 10);
            if (pic_car_v2.Location.Y > 340)
            {
                Timer_3.Stop();
                done = true;
            }
        }
        /*---------OUT----------*/
        /*---Time 4---*/
        private void Timer_4_Tick(object sender, EventArgs e)
        {
            pic_car_v2.Location = new Point(pic_car_v2.Location.X, pic_car_v2.Location.Y - 10);
            if (pic_car_v2.Location.Y < 284)
            {
                pic_car_v2.Image = new Bitmap(Application.StartupPath + "\\picture\\er.png");
                Set_out(txt_vitri.Text);
                Timer_4.Stop();
                Timer_5.Start();
            }
        }
        /*---Time 5---*/
        private void Timer_5_Tick(object sender, EventArgs e)
        {
            pic_car_v2.Location = new Point(pic_car_v2.Location.X, pic_car_v2.Location.Y + 10);
            if (pic_car_v2.Location.Y > 340)
            {
                Timer_5.Stop();
                pic_car_v2.Image = new Bitmap(Application.StartupPath + "\\picture\\123.png");
                pic_car_v3.Visible = true;
                Timer_6.Start();
            }
        }
        /*---Time 6---*/
        private void Timer_6_Tick(object sender, EventArgs e)
        {
            pic_car_v3.Location = new Point(pic_car_v3.Location.X + 10, pic_car_v3.Location.Y);
            // txt_maso.Text = pic_car_v3.Location.ToString();
            if (pic_car_v3.Location.X > 900)
            {
                Timer_6.Stop();
                pic_car_v3.Visible = false;
                pic_car_v3.Location = new Point(687, pic_car_v3.Location.Y);
                done = true;

            }
        }
        /*-------------------IN + OUT funtions----------------------*/
        /*---Set IN---*/
        void Set_in(string in_location) // Set image có xe tại ví trị đặt vào
        {
            switch (in_location)
            {
                case "1":
                    pic_11.Image = new Bitmap(Application.StartupPath + "\\picture\\cm.png");
                    L11.On = true;
                    break;
                case "2":
                    pic_12.Image = new Bitmap(Application.StartupPath + "\\picture\\cm.png");
                    L12.On = true;
                    break;
                case "3":
                    pic_13.Image = new Bitmap(Application.StartupPath + "\\picture\\cm.png");
                    L13.On = true;
                    break;
                case "4":
                    pic_14.Image = new Bitmap(Application.StartupPath + "\\picture\\cm.png");
                    L14.On = true;
                    break;
                case "5":
                    pic_15.Image = new Bitmap(Application.StartupPath + "\\picture\\cm.png");
                    L15.On = true;
                    break;
                case "6":
                    pic_16.Image = new Bitmap(Application.StartupPath + "\\picture\\cm.png");
                    L16.On = true;
                    break;
                default:
                    break;
            }
        }
        /*---Set OUT---*/
        void Set_out(string out_location) // Set image không có xe tại vị trí đặt vào
        {
            switch (out_location)
            {
                case "1":
                    pic_11.Image = new Bitmap(Application.StartupPath + "\\picture\\789.png");
                    L11.On = false;
                    break;
                case "2":
                    pic_12.Image = new Bitmap(Application.StartupPath + "\\picture\\789.png");
                    L12.On = false;
                    break;
                case "3":
                    pic_13.Image = new Bitmap(Application.StartupPath + "\\picture\\789.png");
                    L13.On = false;
                    break;
                case "4":
                    pic_14.Image = new Bitmap(Application.StartupPath + "\\picture\\789.png");
                    L14.On = false;
                    break;
                case "5":
                    pic_15.Image = new Bitmap(Application.StartupPath + "\\picture\\789.png");
                    L15.On = false;
                    break;
                case "6":
                    pic_16.Image = new Bitmap(Application.StartupPath + "\\picture\\789.png");
                    L16.On = false;
                    break;
                default:
                    break;
            }
        }
        /*---Car IN---*/
        void Car_in(string in_location, string in_maso, string in_time, string in_date) // đưa xe vào với vị trí, mã thẻ, thời gian, ngày
        {
            try
            {
                if (IsNumber(in_location) && Convert.ToInt32(in_location) <= 6 && Convert.ToInt32(in_location) > 0 && done == true)
                {
                    if (check_in_car(in_location) == true && check_ID_car_in(in_maso) == true)
                    {
                        if (Admin_test == false) Serial_port.Write("E0"); // OKE
                        else Admin_test = false;
                        lb_error.Text = "Complete";
                        txt_vitri.Text = in_location;
                        txt_maso.Text = in_maso;
                        txt_time.Text = in_time;
                        txt_date.Text = in_date;
                        done = false;
                        pic_car.Visible = true;
                        Set_status(true, in_location);
                        Set_ID_card_time(in_maso, in_time, in_date, in_location);
                        Timer_1.Start();
                    }
                    else
                    {
                        if (check_in_car(in_location) == false)
                        {
                            Serial_port.Write("E3"); // Chưa đồng bộ dữ liệu
                            lb_error.Text = "Upload";
                        }
                        else if (check_ID_car_in(in_maso) == false)
                        {
                            Serial_port.Write("E2"); // Thẻ đã được xử dụng
                            lb_error.Text = "Used card";
                        } 

                    }
                }
                else
                {
                    lb_error.Text = "Upload";
                    Serial_port.Write("E3"); // Chưa đồng bộ dữ liệu
                }
            }
            catch
            {
                lb_error.Text = "Error";
                if (Serial_port.IsOpen)
                {
                    Serial_port.Write("E4"); //Có lỗi xảy ra
                }
                else MessageBox.Show("Chưa mở cổng COM");
                
            }

        }
        /*---Car OUT---*/
        void Car_out(string out_location) // lấy xe ra với vị trí với mã thẻ
        {
            try
            {
                if (IsNumber(out_location) && Convert.ToInt32(out_location) <= 6 && Convert.ToInt32(out_location) > 0 && done == true)
                {
                    if (check_out_car(out_location) == true)
                    {
                        if (Admin_test == false) Serial_port.Write("E0"); // OKE
                        else Admin_test = false;
                        lb_error.Text = "Complete";
                        done = false;
                        txt_vitri.Text = out_location;
                        Set_status(false, out_location);
                        Set_ID_card_time("", "", "", out_location);
                        Timer_4.Start();
                    }
                    else
                    {
                        MessageBox.Show("Chưa có xe tại vị trí đó","ERROR",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    Serial_port.Write("E5"); // Thẻ chưa đc xử dụng
                    lb_error.Text = "Card error";
                }
            }
            catch
            {
                lb_error.Text = "Error";
                if (Serial_port.IsOpen)
                {
                    Serial_port.Write("E4"); //Có lỗi xảy ra
                }
                else MessageBox.Show("Chưa mở cổng COM");
            }

        } 
        /*--------------Check car parking ---------------*/
        /*---All car---*/
        void check_car_parking()
        {
            DataTable data = new DataTable();
            string query = "select Status from Bai_do_xe ";
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            for (int x = 0; x < 6; x++)
            {
                if (data.Rows[x][0].ToString().Trim() == "Co") Set_in((x + 1).ToString());
                else Set_out((x + 1).ToString());
            }
        } // kiểm tra các vị trí để load lần đầu
        /*---car in---*/
        bool check_in_car(string in_location)
        {
            try
            {
                DataTable data = new DataTable();
                string query = "select Status from Bai_do_xe ";
                using (connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);
                    connection.Close();
                }
                if (data.Rows[(Convert.ToInt32(in_location) - 1)][0].ToString().Trim() == "Ko") return true; else return false;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
            return false;
        } // kiểm tra ở vị trí đó có xe không để đưa xe vào
        /*---car out---*/
        bool check_out_car(string out_location)
        {
            try
            {
                DataTable data = new DataTable();
                string query = "select Status from Bai_do_xe ";
                using (connection = new SqlConnection(connectionstring))
                {
                    connection.Open();

                    adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(data);
                    connection.Close();
                }
                if (data.Rows[(Convert.ToInt32(out_location) - 1)][0].ToString().Trim() == "Co") return true; else return false;
            }
            catch
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
            return false;
        } // kiểm tra ở vị trí đó có xe không để lấy xe ra
        /*---ID car in---*/
        bool check_ID_car_in(string in_ID_card) // kiểm tra xem thẻ vừa đưa vào đã được xử dụng chưa
        {
            DataTable data = new DataTable();
            string query = "select ID_Card from Bai_do_xe ";
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            //int index = 0;
            //while (index < 6)
            //{
            //    if (data.Rows[index][0].ToString().Trim() == in_ID_card.Trim()) return false;
            //    else return true;
            //    index++;
            //}
            for (int x = 0; x < 6; x++)
            {
                if (data.Rows[x][0].ToString().Trim() == in_ID_card.Trim()) return false;
            }
            return true;
        }
        /*---ID car out---*/
        bool check_ID_car_out(string out_location, string in_ID_card) // kiểm tra xem thẻ vừa đưa vào đã được xử dụng chưa
        {
            DataTable data = new DataTable();
            string query = "select ID_Card from Bai_do_xe ";
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            if (data.Rows[Convert.ToInt32(out_location)-1][0].ToString().Trim() == in_ID_card.Trim()) return true;
                else return false;
        }
        string Cheack_location_car(string in_ID_card)
        {
            DataTable data = new DataTable();
            string query = "select ID_card from Bai_do_xe ";
            using (connection = new SqlConnection(connectionstring))
            {
                connection.Open();

                adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(data);
                connection.Close();
            }
            for (int x = 0; x < 6; x++)
            {
                if (data.Rows[x][0].ToString().Trim() == in_ID_card.Trim()) return (x+1).ToString();
            }
            return "";
        }
    }
}
