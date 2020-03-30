using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_ly_bai_do_xe_main
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void connect1_Load(object sender, EventArgs e)
        {
            
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            connect1.BringToFront();
            //btn_exit.Location = new Point(panel2.Size.Width - 30, btn_exit.Location.Y);
            //btn_up.Location = new Point(panel2.Size.Width - 65, btn_up.Location.Y);
            //btn_Restaurar.Location = new Point(panel2.Size.Width - 65, btn_Restaurar.Location.Y);
            //btn_down.Location = new Point(panel2.Size.Width - 100, btn_down.Location.Y);
        }

        private void btn_up_Click(object sender, EventArgs e)
        {

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            connect1.BringToFront();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            sql1.BringToFront();
        }
    }
}
