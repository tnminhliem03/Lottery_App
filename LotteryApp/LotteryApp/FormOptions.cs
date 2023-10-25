using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices;
using System.Management;

namespace LotteryApp
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        FormOption1 f1;
        FormTicket f2;
        FormHistory f3;   

        private void FormOptions_Load(object sender, EventArgs e)
        {
            nhacNen.URL = Application.StartupPath + @"\Nhac-Xo-So-Remix.wav";
            nhacNen.settings.setMode("loop", true); 
        }

        private void btOption1_Click(object sender, EventArgs e)
        {
            f1 = new FormOption1(this);
            f1.Show();
            this.Hide();
        }

        private void btOption3_Click(object sender, EventArgs e)
        {
            f3 = new FormHistory(this);
            f3.Show();
            this.Hide();
        }

        private void btOption2_Click(object sender, EventArgs e)
        {
            f2 = new FormTicket();
            Random rd = new Random();
            nhacNen.close();
            f2.luaChon = f2.mauPhieu = rd.Next(1, 5);
            f2.soDuDoan = rd.Next(5, 91);
            f2.Show();
            this.Hide();
        }

        private void FormOptions_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
