using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryApp
{
    public partial class FormOption1 : Form
    {
        FormOptions frm1;
        FormTicket frmTicket;
        public FormOption1()
        {
            InitializeComponent();
        }

        public void closeForm()
        {
            this.Close();
        }

        public FormOption1(FormOptions f0)
        {
            InitializeComponent();
            this.frm1 = f0;
        }

        void frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.frm1.Close();  
        }

        private void pic1_Click(object sender, EventArgs e)
        {
            if (frmTicket.soDuDoan >=5 && frmTicket.soDuDoan <= 90)
            {
                frmTicket.luaChon = 1;
                frmTicket.mauPhieu= 1;
                frmTicket.Show();
                this.Hide();
                frm1.nhacNen.close();
            }
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            if (frmTicket.soDuDoan >= 5 && frmTicket.soDuDoan <= 90)
            {
                frmTicket.luaChon = 2;
                frmTicket.mauPhieu = 2;
                frmTicket.Show();
                this.Hide();
                frm1.nhacNen.close();
            }
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            if (frmTicket.soDuDoan >= 5 && frmTicket.soDuDoan <= 90)
            {
                frmTicket.luaChon = 3;
                frmTicket.mauPhieu = 3;
                frmTicket.Show();
                this.Hide();
                frm1.nhacNen.close();
            }
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            if (frmTicket.soDuDoan >= 5 && frmTicket.soDuDoan <= 90)
            {
                frmTicket.luaChon = 4;
                frmTicket.mauPhieu = 4;
                frmTicket.Show();
                this.Hide();
                frm1.nhacNen.close();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormOption1_Load(object sender, EventArgs e)
        {
            frmTicket = new FormTicket();
        }

        private void txtGuess_TextChanged(object sender, EventArgs e)
        {
            if (txtGuess.Text != "")
                frmTicket.soDuDoan = int.Parse(txtGuess.Text);
        }
    }
}
