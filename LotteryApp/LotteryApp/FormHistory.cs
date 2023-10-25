using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotteryApp.BBL;
using LotteryApp.DTO;

namespace LotteryApp
{
    public partial class FormHistory : Form
    {
        FormOptions frmOp = new FormOptions();
        NguoiChoi playerDTO;
        NguoiChoiBBL playerBBL;
        public int maLanChoi;
        public int mauPhieu;
        public string ketQua;
        public int soTien, soTienHienTai;
        public FormHistory()
        {
            InitializeComponent();
        }

        public void closeForm()
        {
            this.Close();
        }

        public FormHistory(FormOptions f)
        {
            InitializeComponent();
            this.frmOp = f;
        }

        private void FormHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.frmOp.Hide();
        }

        private void lbPlay_Click(object sender, EventArgs e)
        {

        }

        private void FormHistory_Load(object sender, EventArgs e)
        {
            playerDTO = new NguoiChoi();
            playerBBL = new NguoiChoiBBL();
            //gan du lieu vao DTO
            if (maLanChoi != 0)
            {
                playerDTO.MaLanChoi = maLanChoi.ToString();
                if (mauPhieu == 1) playerDTO.MauPhieu = "Xanh duong 1";
                else if (mauPhieu == 2) playerDTO.MauPhieu = "Xanh duong 2";
                else if (mauPhieu == 3) playerDTO.MauPhieu = "Xanh la 1";
                else playerDTO.MauPhieu = "Xanh la 2";
                playerDTO.KetQua = ketQua;
                playerDTO.SoTien = soTien;

                playerBBL.Them(playerDTO);
            }

            lbSoTienHienTai.Text = "Số tiền hiện có: " + playerBBL.getTongTienHienTai().ToString();

            playerBBL.HienThi(dgv);
        }

        //private void btnXoa_Click(object sender, EventArgs e)
        //{
        //    if (txtMaLanChoi.Text.ToLower().Trim() != "")
        //    {
        //        //gan du lieu vao DTO
        //        playerDTO.MaLanChoi = txtMaLanChoi.Text.ToLower();

        //        // goi BBL thuc hien
        //        playerBBL.Xoa(playerDTO);

        //        lbSoTienHienTai.Text = "Số tiền hiện có: " + playerBBL.getTongTienHienTai().ToString();

        //        //hien len DGV
        //        playerBBL.HienThi(dgv);
        //    }
        //}

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.closeForm();
            frmOp.Show();      
        }

        private void btnHienDs_Click(object sender, EventArgs e)
        {
            playerBBL.HienThi(dgv);
        }

        private void btnXóa_Click(object sender, EventArgs e)
        {
            if (txtMaLanChoi.Text.ToLower().Trim() != "")
            {
                //gan du lieu vao DTO
                playerDTO.MaLanChoi = txtMaLanChoi.Text.ToLower();

                // goi BBL thuc hien
                playerBBL.Xoa(playerDTO);

                lbSoTienHienTai.Text = "Số tiền hiện có: " + playerBBL.getTongTienHienTai().ToString();

                //hien len DGV
                playerBBL.HienThi(dgv);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaLanChoi.Text.ToLower().Trim() != "")
            {
                //gan du lieu vao DTO
                playerDTO.MaLanChoi = txtMaLanChoi.Text.ToLower();
                playerDTO.MauPhieu = txtMauPhieu.Text;
                playerDTO.KetQua = txtKetQua.Text;
                playerDTO.SoTien = int.Parse(txtSoTien.Text);
                // goi BBL thuc hien
                playerBBL.Sua(playerDTO);

                lbSoTienHienTai.Text = "Số tiền hiện có: " + playerBBL.getTongTienHienTai().ToString();

                //hien len DGV
                playerBBL.HienThi(dgv);
            }
        }

        private void dgv_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;//row dang click 
            txtMaLanChoi.Text = dgv.Rows[row].Cells[0].Value.ToString();
            txtMauPhieu.Text = dgv.Rows[row].Cells[1].Value.ToString();
            txtKetQua.Text = dgv.Rows[row].Cells[2].Value.ToString();
            txtSoTien.Text = dgv.Rows[row].Cells[3].Value.ToString();

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txtMaLanChoi.Text.ToLower().Trim() != "")
            {
                //gan du lieu vao DTO
                playerDTO.MaLanChoi = txtMaLanChoi.Text.ToLower();

                // goi BBL thuc hien & hien len DGV
                playerBBL.TimKiem(playerDTO, dgv);
            }
        }
    }
}
