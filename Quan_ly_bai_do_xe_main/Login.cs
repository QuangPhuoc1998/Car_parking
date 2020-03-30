using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;


namespace Quan_ly_bai_do_xe_main
{
    public partial class Login_form : Form
    {
        SqlConnection connection;
        SqlCommand command;
        SqlDataAdapter adapter;
        Thread th;
        //
        string connectionstring = @"Data Source=DESKTOP-VPC6GRQ\SQLDEV2020;Initial Catalog=Quan_ly_bai_do_xe;Integrated Security=True";
        public Login_form()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(connectionstring))
            {
                try
                {
                    connection.Open();

                    string tk = txt_username.Text;
                    string mk = txt_password.Text;
                    string sql = "select *from Login where user_name = '" + tk + "' and password = '" + mk + "'";
                    command = new SqlCommand(sql, connection);
                    SqlDataReader data = command.ExecuteReader();
                    if (data.Read() == true)
                    {
                        this.Close();
                        th = new Thread(opennewform);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("LỖI kết nối");
                }

            }
        }

        private void opennewform()
        {
            Application.Run(new Menu());
        }

        private void Login_form_Load(object sender, EventArgs e)
        {

        }

        private void txt_username_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void txt_username_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_username.Clear();
        }

        private void txt_password_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_password.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
