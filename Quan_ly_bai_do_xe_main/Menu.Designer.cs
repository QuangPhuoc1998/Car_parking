namespace Quan_ly_bai_do_xe_main
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_information = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_home = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_search = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_statistical = new Bunifu.Framework.UI.BunifuTileButton();
            this.btn_exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.sql1 = new Quan_ly_bai_do_xe_main.SQL();
            this.connect1 = new Quan_ly_bai_do_xe_main.connect();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_information);
            this.panel1.Controls.Add(this.btn_home);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.btn_statistical);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(148, 1000);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 54);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_information
            // 
            this.btn_information.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_information.color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_information.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(144)))), ((int)(((byte)(241)))));
            this.btn_information.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_information.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_information.ForeColor = System.Drawing.Color.White;
            this.btn_information.Image = ((System.Drawing.Image)(resources.GetObject("btn_information.Image")));
            this.btn_information.ImagePosition = 14;
            this.btn_information.ImageZoom = 30;
            this.btn_information.LabelPosition = 29;
            this.btn_information.LabelText = "Information";
            this.btn_information.Location = new System.Drawing.Point(0, 458);
            this.btn_information.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_information.Name = "btn_information";
            this.btn_information.Size = new System.Drawing.Size(154, 106);
            this.btn_information.TabIndex = 4;
            // 
            // btn_home
            // 
            this.btn_home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_home.color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_home.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(144)))), ((int)(((byte)(241)))));
            this.btn_home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_home.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_home.ForeColor = System.Drawing.Color.White;
            this.btn_home.Image = ((System.Drawing.Image)(resources.GetObject("btn_home.Image")));
            this.btn_home.ImagePosition = 10;
            this.btn_home.ImageZoom = 30;
            this.btn_home.LabelPosition = 29;
            this.btn_home.LabelText = "Home";
            this.btn_home.Location = new System.Drawing.Point(0, 181);
            this.btn_home.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_home.Name = "btn_home";
            this.btn_home.Size = new System.Drawing.Size(154, 93);
            this.btn_home.TabIndex = 2;
            this.btn_home.Click += new System.EventHandler(this.btn_home_Click);
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_search.color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_search.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(144)))), ((int)(((byte)(241)))));
            this.btn_search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_search.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Image = ((System.Drawing.Image)(resources.GetObject("btn_search.Image")));
            this.btn_search.ImagePosition = 14;
            this.btn_search.ImageZoom = 30;
            this.btn_search.LabelPosition = 29;
            this.btn_search.LabelText = "Search";
            this.btn_search.Location = new System.Drawing.Point(0, 272);
            this.btn_search.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(154, 93);
            this.btn_search.TabIndex = 3;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_statistical
            // 
            this.btn_statistical.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_statistical.color = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(115)))), ((int)(((byte)(217)))));
            this.btn_statistical.colorActive = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(144)))), ((int)(((byte)(241)))));
            this.btn_statistical.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_statistical.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_statistical.ForeColor = System.Drawing.Color.White;
            this.btn_statistical.Image = ((System.Drawing.Image)(resources.GetObject("btn_statistical.Image")));
            this.btn_statistical.ImagePosition = 14;
            this.btn_statistical.ImageZoom = 30;
            this.btn_statistical.LabelPosition = 29;
            this.btn_statistical.LabelText = "Statistical";
            this.btn_statistical.Location = new System.Drawing.Point(0, 365);
            this.btn_statistical.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_statistical.Name = "btn_statistical";
            this.btn_statistical.Size = new System.Drawing.Size(154, 93);
            this.btn_statistical.TabIndex = 2;
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btn_exit.FlatAppearance.BorderSize = 0;
            this.btn_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btn_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.btn_exit.Image = ((System.Drawing.Image)(resources.GetObject("btn_exit.Image")));
            this.btn_exit.Location = new System.Drawing.Point(1489, 3);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(37, 37);
            this.btn_exit.TabIndex = 0;
            this.btn_exit.UseVisualStyleBackColor = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(99)))), ((int)(((byte)(198)))));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(1446, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(37, 37);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sql1
            // 
            this.sql1.BackColor = System.Drawing.Color.White;
            this.sql1.Location = new System.Drawing.Point(154, 50);
            this.sql1.Name = "sql1";
            this.sql1.Size = new System.Drawing.Size(1546, 944);
            this.sql1.TabIndex = 3;
            this.sql1.Load += new System.EventHandler(this.connect1_Load);
            // 
            // connect1
            // 
            this.connect1.BackColor = System.Drawing.Color.White;
            this.connect1.Location = new System.Drawing.Point(154, 50);
            this.connect1.Name = "connect1";
            this.connect1.Size = new System.Drawing.Size(1546, 944);
            this.connect1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_exit);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(171, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1529, 44);
            this.panel2.TabIndex = 4;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1700, 1000);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.sql1);
            this.Controls.Add(this.connect1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(150, 0);
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuTileButton btn_information;
        private Bunifu.Framework.UI.BunifuTileButton btn_home;
        private Bunifu.Framework.UI.BunifuTileButton btn_search;
        private Bunifu.Framework.UI.BunifuTileButton btn_statistical;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button button1;
        private connect connect1;
        private SQL sql1;
        private System.Windows.Forms.Panel panel2;
    }
}