using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LotteryApp.BBL;

namespace LotteryApp
{
    public partial class FormTicket : Form
    {
        FormHistory frH = new FormHistory();
        FormOptions frO = new FormOptions();
        NguoiChoiBBL playerBBL= new NguoiChoiBBL();
        public static int maLanChoi; // tu tang
        public int mauPhieu, soDuDoan; // mau phieu (vd: xanh la 1), soDuDoan: so da du doan de kiem tra thang
        bool win = false;
        public int luaChon;
        Random rd = new Random();
        int lengthRandom = 1; // kiem tra cho arrInt
        int lengthTimer = 1; // so lan da keu so
        int[] arrInt = new int[91]; // arr từ 1-90 vị trí ngẫu nhiên
        int[] arrIntTemp = new int[91]; // arr đánh dấu trùng cho arrInt
        int[] arrSoDaBoc = new int[91]; // arr những số đã kêu
        int[] arrSoDaBocAuto = new int[91]; // arr những số đã kêu
        int[,] arrPhieuDo = new int[10, 6];
        int soVuaRandom, iDauVet, viTriDongDaThang = 0;
        bool checkDauVet = false;
        public static int result1 = 0, result2 = 0, result3 = 0, result4 = 0, result5 = 0, result6 = 0, result7 = 0, result8 = 0, result9 = 0;
        public FormTicket()
        {
            InitializeComponent();
        }
        public void closeForm()
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            frH.maLanChoi = playerBBL.getMaLanChoi(); // tu dong tang
            frH.mauPhieu = mauPhieu;
            this.FormBorderStyle= FormBorderStyle.None;
            timer2.Enabled = false;
            timer1.Interval= 5000;
            timer2.Interval= timer1.Interval + 1;
            soundTrack.URL = "Nhac-Xo-So-Remix.wav";
            soundTrack.settings.setMode("loop", true);
            lbSoDuDoan.Text = String.Format("Tìm vận may đến ngay Lô tô 2023 - Dự đoán số lần gọi số: {0}", soDuDoan);
            switch (luaChon)
            {
                case 1:
                    openTicket1();
                    break;
                case 2:
                    openTicket2();
                    break;
                case 3:
                    openTicket3();
                    break;
                case 4:
                    openTicket4();
                    break;
            }

            for (int i = 1; i < 91; i++)
                arrIntTemp[i] = 0;

            while (lengthRandom < 91)
            {
                int x = rd.Next(1, 91);
                if (arrIntTemp[x] == 0)
                {
                    arrInt[lengthRandom] = x;
                    arrIntTemp[x] = 1;
                    lengthRandom++;
                }
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (win == false) // chua thang
            {
                timer1.Enabled = true;
                if (autoCheck.Checked) { timer2.Enabled = true; }
                //timer1.Interval= 1000;
                //timer2.Interval = 1001;
                //timer1.Interval = 3000;
                //timer2.Interval = 3001;
                btnContinue.Hide();
                soundTrack.settings.mute = false;
                btnPause.Show();
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            soundTrack.settings.mute = true;
            btnPause.Hide();
            btnContinue.Show();
            timer1.Enabled = false;
            timer2.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           if (win == true)
            {
                if (soDuDoan >= lengthTimer)
                {
                    frH.ketQua = "Win - " + lengthTimer + "/" + soDuDoan; // số lần đã kêu số / Số dự đoán
                    frH.soTien = (soDuDoan - lengthTimer) * 10; // (số dự đoán - số lần đã kêu số) * 10
                }
                else
                {
                    frH.ketQua = "Lose - " + lengthTimer + "/" + soDuDoan; // số lần đã kêu số / Số dự đoán
                    frH.soTien = -1 * ((lengthTimer - soDuDoan) * 10); // (số lần đã kêu số - số dự đoán) * 10
                }
                this.Hide();
                frH.Show();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            frO.Show();
            soundTrack.close();
            this.Close();
        }

        private void btnSpeedDown_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer2.Interval = timer1.Interval + 1;
        }

        private void btnSpeedUp_Click(object sender, EventArgs e)
        {
            timer1.Interval = 3200;
            timer2.Interval = timer1.Interval + 1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //timer2.Interval = 3001;
            foreach (Control item in grNumber.Controls)
            {
                if (item.Text == lbNewNumber.Text)
                {
                    item.BackColor = Color.Black;
                    item.ForeColor = Color.White;
                    bool check = false;
                    for (int i = 1; i <= 9; i++)
                    {
                        for (int j = 1; j <= 5; j++)
                        {
                            if (item.Text == arrPhieuDo[i, j].ToString())
                            {
                                check = true;
                                iDauVet = i;
                                break;
                            }
                        }
                        if (check == true)
                        {
                            check = false;
                            break;
                        }
                    }

                    switch (iDauVet)
                    {
                        case 1:
                            ++result1;
                            if (result1 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result1 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 1;
                                DaThang();
                            }
                            break;
                        case 2:
                            ++result2;
                            if (result2 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result2 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 2;
                                DaThang();
                            }
                            break;
                        case 3:
                            ++result3;
                            if (result3 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result3 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 3;
                                DaThang();
                            }
                            break;
                        case 4:
                            ++result4;
                            if (result4 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result4 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 4;
                                DaThang();
                            }
                            break;
                        case 5:
                            ++result5;
                            if (result5 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result5 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 5;
                                DaThang();
                            }
                            break;
                        case 6:
                            ++result6;
                            if (result6 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result6 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 6;
                                DaThang();
                            }
                            break;
                        case 7:
                            ++result7;
                            if (result7 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result7 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 7;
                                DaThang();
                            }
                            break;
                        case 8:
                            ++result8;
                            if (result8 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result8 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 8;
                                DaThang();
                            }
                            break;
                        case 9:
                            ++result9;
                            if (result9 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result9 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 9;
                                DaThang();
                            }
                            break;
                    }

                    break;
                }
            }
        }

        private void autoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (autoCheck.Checked)
            {
                timer2.Enabled = true;
                timer2.Interval = timer1.Interval + 1;
            }
            else
            {
                timer2.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lengthTimer == 91)
            {
                timer1.Stop();
                timer2.Stop();
                return;
            }
            //timer2.Enabled = false;
            arrSoDaBoc[lengthTimer] = arrInt[lengthTimer];
            lbNewNumber.Text = arrInt[lengthTimer].ToString();
            Label lbClone = new Label();
            lbClone.Font = lbNewNumber.Font;
            lbClone.ImageAlign = lbNewNumber.ImageAlign;
            lbClone.Size = lbNewNumber.Size;
            lbClone.Text = lbNewNumber.Text;
            lbClone.BorderStyle = lbNewNumber.BorderStyle;
            flowNumberCurr.Controls.Add(lbClone);
            lengthTimer++;
            //timer1.Interval = 3000;
        }

        public void checkLabel(Label lb)
        {
            if (lb.Text == "")
                return;
            else
            {
                bool check = false;
                for (int i = 1; i <= lengthTimer; i++)
                {
                    if (int.Parse(lb.Text) == arrSoDaBoc[i])
                    {
                        check = true;
                        soVuaRandom = arrSoDaBoc[i];
                        break;
                    }
                }

                if (check == true)
                {
                    check = false;
                    lb.BackColor = Color.Black;
                    lb.ForeColor = Color.White;

                    for (int i = 1; i <= 9; i++)
                    {
                        for (int j = 1; j <= 5; j++)
                        {
                            if (arrPhieuDo[i, j] == soVuaRandom)
                            {
                                iDauVet = i;
                                checkDauVet = true;
                                break;
                            }
                        }
                        if (checkDauVet == true)
                        {
                            checkDauVet = false;
                            break;
                        }
                    }

                    switch (iDauVet)
                    {
                        case 1:
                            ++result1;
                            if (result1 == 4)
                            {
                  
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;              lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result1 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 1;
                                DaThang();
                            }
                            break;
                        case 2:
                            ++result2;
                            if (result2 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result2 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 2;
                                DaThang();
                            }
                            break;
                        case 3:
                            ++result3;
                            if (result3 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result3 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 3;
                                DaThang();
                            }
                            break;
                        case 4:
                            ++result4;
                            if (result4 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result4 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 4;
                                DaThang();
                            }
                            break;
                        case 5:
                            ++result5;
                            if (result5 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result5 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 5;
                                DaThang();
                            }
                            break;
                        case 6:
                            ++result6;
                            if (result6 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result6 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 6;
                                DaThang();
                            }
                            break;
                        case 7:
                            ++result7;
                            if (result7 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result7 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 7;
                                DaThang();
                            }
                            break;
                        case 8:
                            ++result8;
                            if (result8 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result8 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 8;
                                DaThang();
                            }
                            break;
                        case 9:
                            ++result9;
                            if (result9 == 4)
                            {
                                lbKetQua.BackColor = Color.OrangeRed;
                                lbKetQua.ForeColor = Color.White;
                                lbKetQua.Font = lbNewNumber.Font;
                                lbKetQua.ImageAlign = lbNewNumber.ImageAlign;
                                lbKetQua.BorderStyle = lbNewNumber.BorderStyle;
                                lbKetQua.Text = "HÒ! Một số nữa thui :3";
                            }
                            else if (result9 == 5)
                            {
                                lbKetQua.Text = "WIN! Sơ hở là KINH";
                                viTriDongDaThang = 9;
                                DaThang();
                            }
                            break;
                    }
                }
            }
        }


        public void hienWin(int i)
        {
            string temp = String.Format("Bạn đã kinh với các số: {0} {1} {2} {3} {4}", 
                arrPhieuDo[i, 1],
                arrPhieuDo[i, 2],
                arrPhieuDo[i, 3],
                arrPhieuDo[i ,4],
                arrPhieuDo[i, 5]);
            MessageBox.Show(temp, "Chúc mừng bạn",
                        MessageBoxButtons.OK);
        }
        public void DaThang()
        {
            win = true;
            btnPause.Hide();
            btnContinue.Show();
            timer1.Enabled = false;
            timer2.Enabled = false;
            switch (viTriDongDaThang)
            {
                case 1:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb2.BackColor = lb3.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.OrangeRed;
                    }
                    hienWin(1);
                    break;
                case 2:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb11.BackColor = lb13.BackColor = lb14.BackColor = lb16.BackColor = lb17.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb10.BackColor = lb12.BackColor = lb13.BackColor = lb15.BackColor = lb17.BackColor = Color.OrangeRed;
                    }
                    hienWin(2);
                    break;
                case 3:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb19.BackColor = lb21.BackColor = lb22.BackColor = lb24.BackColor = lb26.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb19.BackColor = lb22.BackColor = lb24.BackColor = lb25.BackColor = lb27.BackColor = Color.OrangeRed;
                    }
                    hienWin(3);
                    break;
                case 4:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb28.BackColor = lb30.BackColor = lb32.BackColor = lb34.BackColor = lb35.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb28.BackColor = lb30.BackColor = lb31.BackColor = lb33.BackColor = lb35.BackColor = Color.OrangeRed;
                    }
                    hienWin(4);
                    break;
                case 5:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb38.BackColor = lb40.BackColor = lb42.BackColor = lb43.BackColor = lb45.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb37.BackColor = lb41.BackColor = lb42.BackColor = lb44.BackColor = lb45.BackColor = Color.OrangeRed;
                    }
                    hienWin(5);
                    break;
                case 6:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb47.BackColor = lb49.BackColor = lb50.BackColor = lb53.BackColor = lb54.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb47.BackColor = lb48.BackColor = lb50.BackColor = lb52.BackColor = lb54.BackColor = Color.OrangeRed;
                    }
                    hienWin(6);
                    break;
                case 7:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb56.BackColor = lb57.BackColor = lb60.BackColor = lb62.BackColor = lb63.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb57.BackColor = lb59.BackColor = lb60.BackColor = lb62.BackColor = lb63.BackColor = Color.OrangeRed; lb56.BackColor = lb57.BackColor = lb60.BackColor = lb62.BackColor = lb63.BackColor = Color.OrangeRed;
                    }
                    hienWin(7);
                    break;
                case 8:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb65.BackColor = lb67.BackColor = lb68.BackColor = lb70.BackColor = lb72.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb64.BackColor = lb65.BackColor = lb67.BackColor = lb68.BackColor = lb70.BackColor = Color.OrangeRed;
                    }
                    hienWin(8);
                    break;
                case 9:
                    if (luaChon == 1 || luaChon == 3)
                    {
                        lb73.BackColor = lb75.BackColor = lb76.BackColor = lb78.BackColor = lb79.BackColor = Color.OrangeRed;
                    }
                    else if (luaChon == 2 || luaChon == 4)
                    {
                        lb74.BackColor = lb75.BackColor = lb78.BackColor = lb80.BackColor = lb81.BackColor = Color.OrangeRed;
                    }
                    hienWin(9);
                    break;
            }
        }
        private void lb1_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            checkLabel(lb);
            
        }

        void openTicket1()
        {
            //lb1.Text = "9"; lb2.Text = "16"; lb5.Text = "46"; lb7.Text = "65"; lb9.Text = "80";
            for (int j = 1; j <= 5;)
            {
                lb1.Text = "9";
                arrPhieuDo[1, j] = int.Parse(lb1.Text); j++;
                lb2.Text = "16";
                arrPhieuDo[1, j] = int.Parse(lb2.Text); ++j;
                lb5.Text = "46";
                arrPhieuDo[1, j] = int.Parse(lb5.Text); ++j;
                lb7.Text = "65";
                arrPhieuDo[1, j] = int.Parse(lb7.Text); ++j;
                lb9.Text = "80";
                arrPhieuDo[1, j] = int.Parse(lb9.Text); ++j;

                lb3.BackColor = lb4.BackColor = lb6.BackColor = lb8.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb11.Text = "11"; lb13.Text = "32"; lb14.Text = "45"; lb16.Text = "68"; lb17.Text = "78";
            for (int j = 1; j <= 5;)
            {
                lb11.Text = "11";
                arrPhieuDo[2, j] = int.Parse(lb11.Text); j++;
                lb13.Text = "32";
                arrPhieuDo[2, j] = int.Parse(lb13.Text); ++j;
                lb14.Text = "45";
                arrPhieuDo[2, j] = int.Parse(lb14.Text); ++j;
                lb16.Text = "68";
                arrPhieuDo[2, j] = int.Parse(lb16.Text); ++j;
                lb17.Text = "78";
                arrPhieuDo[2, j] = int.Parse(lb17.Text); ++j;

                lb10.BackColor = lb12.BackColor = lb15.BackColor = lb18.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb19.Text = "8"; lb21.Text = "21"; lb22.Text = "33"; lb24.Text = "57"; lb26.Text = "73";
            for (int j = 1; j <= 5;)
            {
                lb19.Text = "8";
                arrPhieuDo[3, j] = int.Parse(lb19.Text); j++;
                lb21.Text = "21";
                arrPhieuDo[3, j] = int.Parse(lb21.Text); ++j;
                lb22.Text = "33";
                arrPhieuDo[3, j] = int.Parse(lb22.Text); ++j;
                lb24.Text = "57";
                arrPhieuDo[3, j] = int.Parse(lb24.Text); ++j;
                lb26.Text = "73";
                arrPhieuDo[3, j] = int.Parse(lb26.Text); ++j;

                lb20.BackColor = lb23.BackColor = lb25.BackColor = lb27.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb28.Text = "6"; lb30.Text = "20"; lb32.Text = "43"; lb34.Text = "63"; lb35.Text = "77";
            for (int j = 1; j <= 5;)
            {
                lb28.Text = "6";
                arrPhieuDo[4, j] = int.Parse(lb28.Text); j++;
                lb30.Text = "20";
                arrPhieuDo[4, j] = int.Parse(lb30.Text); ++j;
                lb32.Text = "43";
                arrPhieuDo[4, j] = int.Parse(lb32.Text); ++j;
                lb34.Text = "63";
                arrPhieuDo[4, j] = int.Parse(lb34.Text); ++j;
                lb35.Text = "77";
                arrPhieuDo[4, j] = int.Parse(lb35.Text); ++j;

                lb29.BackColor = lb31.BackColor = lb33.BackColor = lb36.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb38.Text = "12"; lb40.Text = "31"; lb42.Text = "54"; lb43.Text = "62"; lb45.Text = "85";
            for (int j = 1; j <= 5;)
            {
                lb38.Text = "12";
                arrPhieuDo[5, j] = int.Parse(lb38.Text); j++;
                lb40.Text = "31";
                arrPhieuDo[5, j] = int.Parse(lb40.Text); ++j;
                lb42.Text = "54";
                arrPhieuDo[5, j] = int.Parse(lb42.Text); ++j;
                lb43.Text = "62";
                arrPhieuDo[5, j] = int.Parse(lb43.Text); ++j;
                lb45.Text = "85";
                arrPhieuDo[5, j] = int.Parse(lb45.Text); ++j;

                lb37.BackColor = lb39.BackColor = lb41.BackColor = lb44.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb47.Text = "19"; lb49.Text = "39"; lb50.Text = "40"; lb53.Text = "70"; lb54.Text = "82";
            for (int j = 1; j <= 5;)
            {
                lb47.Text = "19";
                arrPhieuDo[6, j] = int.Parse(lb47.Text); j++;
                lb49.Text = "39";
                arrPhieuDo[6, j] = int.Parse(lb49.Text); ++j;
                lb50.Text = "40";
                arrPhieuDo[6, j] = int.Parse(lb50.Text); ++j;
                lb53.Text = "70";
                arrPhieuDo[6, j] = int.Parse(lb53.Text); ++j;
                lb54.Text = "82";
                arrPhieuDo[6, j] = int.Parse(lb54.Text); ++j;

                lb46.BackColor = lb48.BackColor = lb51.BackColor = lb52.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb56.Text = "18"; lb57.Text = "29"; lb60.Text = "58"; lb62.Text = "74"; lb63.Text = "90";
            for (int j = 1; j <= 5;)
            {
                lb56.Text = "18";
                arrPhieuDo[7, j] = int.Parse(lb56.Text); j++;
                lb57.Text = "29";
                arrPhieuDo[7, j] = int.Parse(lb57.Text); ++j;
                lb60.Text = "58";
                arrPhieuDo[7, j] = int.Parse(lb60.Text); ++j;
                lb62.Text = "74";
                arrPhieuDo[7, j] = int.Parse(lb62.Text); ++j;
                lb63.Text = "90";
                arrPhieuDo[7, j] = int.Parse(lb63.Text); ++j;

                lb55.BackColor = lb58.BackColor = lb59.BackColor = lb61.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb65.Text = "17"; lb67.Text = "38"; lb68.Text = "44"; lb70.Text = "69"; lb72.Text = "88";
            for (int j = 1; j <= 5;)
            {
                lb65.Text = "17";
                arrPhieuDo[8, j] = int.Parse(lb65.Text); j++;
                lb67.Text = "38";
                arrPhieuDo[8, j] = int.Parse(lb67.Text); ++j;
                lb68.Text = "44";
                arrPhieuDo[8, j] = int.Parse(lb68.Text); ++j;
                lb70.Text = "69";
                arrPhieuDo[8, j] = int.Parse(lb70.Text); ++j;
                lb72.Text = "88";
                arrPhieuDo[8, j] = int.Parse(lb72.Text); ++j;

                lb64.BackColor = lb66.BackColor = lb69.BackColor = lb71.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb73.Text = "2"; lb75.Text = "27"; lb76.Text = "37"; lb78.Text = "55"; lb79.Text = "67";
            for (int j = 1; j <= 5;)
            {
                lb73.Text = "2";
                arrPhieuDo[9, j] = int.Parse(lb73.Text); j++;
                lb75.Text = "27";
                arrPhieuDo[9, j] = int.Parse(lb75.Text); ++j;
                lb76.Text = "37";
                arrPhieuDo[9, j] = int.Parse(lb76.Text); ++j;
                lb78.Text = "55";
                arrPhieuDo[9, j] = int.Parse(lb78.Text); ++j;
                lb79.Text = "67";
                arrPhieuDo[9, j] = int.Parse(lb79.Text); ++j;

                lb74.BackColor = lb77.BackColor = lb80.BackColor = lb81.BackColor = Color.FromArgb(28, 153, 210);
            }
        }

        void openTicket2()
        {
            //lb2.Text = "13"; lb3.Text = "22"; lb5.Text = "41"; lb7.Text = "61"; lb9.Text = "86";
            for (int j = 1; j <= 5;)
            {
                lb2.Text = "13";
                arrPhieuDo[1, j] = int.Parse(lb2.Text); j++;
                lb3.Text = "22";
                arrPhieuDo[1, j] = int.Parse(lb3.Text); ++j;
                lb5.Text = "41";
                arrPhieuDo[1, j] = int.Parse(lb5.Text); ++j;
                lb7.Text = "61";
                arrPhieuDo[1, j] = int.Parse(lb7.Text); ++j;
                lb9.Text = "86";
                arrPhieuDo[1, j] = int.Parse(lb9.Text); ++j;

                lb1.BackColor = lb4.BackColor = lb6.BackColor = lb8.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb10.Text = "3"; lb12.Text = "24"; lb13.Text = "34"; lb15.Text = "52"; lb17.Text = "71";
            for (int j = 1; j <= 5;)
            {
                lb10.Text = "3";
                arrPhieuDo[2, j] = int.Parse(lb10.Text); j++;
                lb12.Text = "24";
                arrPhieuDo[2, j] = int.Parse(lb12.Text); ++j;
                lb13.Text = "34";
                arrPhieuDo[2, j] = int.Parse(lb13.Text); ++j;
                lb15.Text = "52";
                arrPhieuDo[2, j] = int.Parse(lb15.Text); ++j;
                lb17.Text = "71";
                arrPhieuDo[2, j] = int.Parse(lb17.Text); ++j;

                lb11.BackColor = lb14.BackColor = lb16.BackColor = lb18.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb19.Text = "1"; lb22.Text = "35"; lb24.Text = "56"; lb25.Text = "64"; lb27.Text = "83";
            for (int j = 1; j <= 5;)
            {
                lb19.Text = "1";
                arrPhieuDo[3, j] = int.Parse(lb19.Text); j++;
                lb22.Text = "35";
                arrPhieuDo[3, j] = int.Parse(lb22.Text); ++j;
                lb24.Text = "56";
                arrPhieuDo[3, j] = int.Parse(lb24.Text); ++j;
                lb25.Text = "64";
                arrPhieuDo[3, j] = int.Parse(lb25.Text); ++j;
                lb27.Text = "83";
                arrPhieuDo[3, j] = int.Parse(lb27.Text); ++j;

                lb20.BackColor = lb21.BackColor = lb23.BackColor = lb26.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb28.Text = "7"; lb30.Text = "23"; lb31.Text = "36"; lb33.Text = "53"; lb35.Text = "75";
            for (int j = 1; j <= 5;)
            {
                lb28.Text = "7";
                arrPhieuDo[4, j] = int.Parse(lb28.Text); j++;
                lb30.Text = "23";
                arrPhieuDo[4, j] = int.Parse(lb30.Text); ++j;
                lb31.Text = "36";
                arrPhieuDo[4, j] = int.Parse(lb31.Text); ++j;
                lb33.Text = "53";
                arrPhieuDo[4, j] = int.Parse(lb33.Text); ++j;
                lb35.Text = "75";
                arrPhieuDo[4, j] = int.Parse(lb35.Text); ++j;

                lb29.BackColor = lb32.BackColor = lb34.BackColor = lb36.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb37.Text = "5"; lb41.Text = "48"; lb42.Text = "59"; lb44.Text = "72"; lb45.Text = "84";
            for (int j = 1; j <= 5;)
            {
                lb37.Text = "5";
                arrPhieuDo[5, j] = int.Parse(lb37.Text); j++;
                lb41.Text = "48";
                arrPhieuDo[5, j] = int.Parse(lb41.Text); ++j;
                lb42.Text = "59";
                arrPhieuDo[5, j] = int.Parse(lb42.Text); ++j;
                lb44.Text = "72";
                arrPhieuDo[5, j] = int.Parse(lb44.Text); ++j;
                lb45.Text = "84";
                arrPhieuDo[5, j] = int.Parse(lb45.Text); ++j;

                lb38.BackColor = lb39.BackColor = lb40.BackColor = lb43.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb47.Text = "14"; lb48.Text = "28"; lb50.Text = "42"; lb52.Text = "60"; lb54.Text = "87";
            for (int j = 1; j <= 5;)
            {
                lb47.Text = "14";
                arrPhieuDo[6, j] = int.Parse(lb47.Text); j++;
                lb48.Text = "28";
                arrPhieuDo[6, j] = int.Parse(lb48.Text); ++j;
                lb50.Text = "42";
                arrPhieuDo[6, j] = int.Parse(lb50.Text); ++j;
                lb52.Text = "60";
                arrPhieuDo[6, j] = int.Parse(lb52.Text); ++j;
                lb54.Text = "87";
                arrPhieuDo[6, j] = int.Parse(lb54.Text); ++j;

                lb46.BackColor = lb49.BackColor = lb51.BackColor = lb53.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb57.Text = "26"; lb59.Text = "47"; lb60.Text = "50"; lb62.Text = "79"; lb63.Text = "89";
            for (int j = 1; j <= 5;)
            {
                lb57.Text = "26";
                arrPhieuDo[7, j] = int.Parse(lb57.Text); j++;
                lb59.Text = "47";
                arrPhieuDo[7, j] = int.Parse(lb59.Text); ++j;
                lb60.Text = "50";
                arrPhieuDo[7, j] = int.Parse(lb60.Text); ++j;
                lb62.Text = "79";
                arrPhieuDo[7, j] = int.Parse(lb62.Text); ++j;
                lb63.Text = "89";
                arrPhieuDo[7, j] = int.Parse(lb63.Text); ++j;

                lb55.BackColor = lb56.BackColor = lb58.BackColor = lb61.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb64.Text = "4"; lb65.Text = "10"; lb67.Text = "30"; lb68.Text = "49"; lb70.Text = "66";
            for (int j = 1; j <= 5;)
            {
                lb64.Text = "4";
                arrPhieuDo[8, j] = int.Parse(lb64.Text); j++;
                lb65.Text = "10";
                arrPhieuDo[8, j] = int.Parse(lb65.Text); ++j;
                lb67.Text = "30";
                arrPhieuDo[8, j] = int.Parse(lb67.Text); ++j;
                lb68.Text = "49";
                arrPhieuDo[8, j] = int.Parse(lb68.Text); ++j;
                lb70.Text = "66";
                arrPhieuDo[8, j] = int.Parse(lb70.Text); ++j;

                lb66.BackColor = lb69.BackColor = lb71.BackColor = lb72.BackColor = Color.FromArgb(28, 153, 210);
            }

            //lb74.Text = "15"; lb75.Text = "25"; lb78.Text = "51"; lb80.Text = "76"; lb81.Text = "81";
            for (int j = 1; j <= 5;)
            {
                lb74.Text = "15";
                arrPhieuDo[9, j] = int.Parse(lb74.Text); j++;
                lb75.Text = "25";
                arrPhieuDo[9, j] = int.Parse(lb75.Text); ++j;
                lb78.Text = "51";
                arrPhieuDo[9, j] = int.Parse(lb78.Text); ++j;
                lb80.Text = "76";
                arrPhieuDo[9, j] = int.Parse(lb80.Text); ++j;
                lb81.Text = "81";
                arrPhieuDo[9, j] = int.Parse(lb81.Text); ++j;

                lb73.BackColor = lb76.BackColor = lb77.BackColor = lb79.BackColor = Color.FromArgb(28, 153, 210);
            }
        }

        void openTicket3()
        {
            //lb1.Text = "6"; lb2.Text = "18"; lb5.Text = "47"; lb7.Text = "69"; lb9.Text = "86";
            for (int j = 1; j <= 5;)
            {
                lb1.Text = "6";
                arrPhieuDo[1, j] = int.Parse(lb1.Text); ++j;
                lb2.Text = "18";
                arrPhieuDo[1, j] = int.Parse(lb2.Text); ++j;
                lb5.Text = "47";
                arrPhieuDo[1, j] = int.Parse(lb5.Text); ++j;
                lb7.Text = "69";
                arrPhieuDo[1, j] = int.Parse(lb7.Text); ++j;
                lb9.Text = "86";
                arrPhieuDo[1, j] = int.Parse(lb9.Text); ++j;
                lb3.BackColor = lb4.BackColor = lb6.BackColor = lb8.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb11.Text = "13"; lb13.Text = "31"; lb14.Text = "44"; lb16.Text = "61"; lb17.Text = "70";
            for (int j = 1; j <= 5;)
            {
                lb11.Text = "13";
                arrPhieuDo[2, j] = int.Parse(lb11.Text); ++j;
                lb13.Text = "31";
                arrPhieuDo[2, j] = int.Parse(lb13.Text); ++j;
                lb14.Text = "44";
                arrPhieuDo[2, j] = int.Parse(lb14.Text); ++j;
                lb16.Text = "61";
                arrPhieuDo[2, j] = int.Parse(lb16.Text); ++j;
                lb17.Text = "70";
                arrPhieuDo[2, j] = int.Parse(lb17.Text); ++j;
                lb12.BackColor = lb15.BackColor = lb18.BackColor = lb10.BackColor = Color.FromArgb(92, 136, 86);

                //lb11.BackColor = lb13.BackColor = lb14.BackColor = lb16.BackColor = lb17.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb19.Text = "7"; lb21.Text = "24"; lb22.Text = "34"; lb24.Text = "56"; lb26.Text = "71";
            for (int j = 1; j <= 5;)
            {
                lb19.Text = "7";
                arrPhieuDo[3, j] = int.Parse(lb19.Text); ++j;
                lb21.Text = "24";
                arrPhieuDo[3, j] = int.Parse(lb21.Text); ++j;
                lb22.Text = "34";
                arrPhieuDo[3, j] = int.Parse(lb22.Text); ++j;
                lb24.Text = "56";
                arrPhieuDo[3, j] = int.Parse(lb24.Text); ++j;
                lb26.Text = "71";
                arrPhieuDo[3, j] = int.Parse(lb26.Text); ++j;
                lb20.BackColor = lb23.BackColor = lb25.BackColor = lb27.BackColor = Color.FromArgb(92, 136, 86);
                //lb19.BackColor = lb21.BackColor = lb22.BackColor = lb24.BackColor = lb26.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb28.Text = "5"; lb30.Text = "23"; lb32.Text = "41"; lb34.Text = "65"; lb35.Text = "74";
            for (int j = 1; j <= 5;)
            {
                lb28.Text = "5";
                arrPhieuDo[4, j] = int.Parse(lb28.Text); ++j;
                lb30.Text = "23";
                arrPhieuDo[4, j] = int.Parse(lb30.Text); ++j;
                lb32.Text = "41";
                arrPhieuDo[4, j] = int.Parse(lb32.Text); ++j;
                lb34.Text = "65";
                arrPhieuDo[4, j] = int.Parse(lb34.Text); ++j;
                lb35.Text = "74";
                arrPhieuDo[4, j] = int.Parse(lb35.Text); ++j;
                lb29.BackColor = lb31.BackColor = lb33.BackColor = lb36.BackColor = Color.FromArgb(92, 136, 86);

                //lb28.BackColor = lb30.BackColor = lb32.BackColor = lb34.BackColor = lb35.BackColor = Color.FromArgb(92, 136, 86);
            }


            //lb38.Text = "10"; lb40.Text = "37"; lb42.Text = "53"; lb43.Text = "60"; lb45.Text = "89";
            for (int j = 1; j <= 5;)
            {
                lb38.Text = "10";
                arrPhieuDo[5, j] = int.Parse(lb38.Text); ++j;
                lb40.Text = "37";
                arrPhieuDo[5, j] = int.Parse(lb40.Text); ++j;
                lb42.Text = "53";
                arrPhieuDo[5, j] = int.Parse(lb42.Text); ++j;
                lb43.Text = "60";
                arrPhieuDo[5, j] = int.Parse(lb43.Text); ++j;
                lb45.Text = "89";
                arrPhieuDo[5, j] = int.Parse(lb45.Text); ++j;
                lb37.BackColor = lb39.BackColor = lb41.BackColor = lb44.BackColor = Color.FromArgb(92, 136, 86);

                //lb38.BackColor = lb40.BackColor = lb42.BackColor = lb43.BackColor = lb45.BackColor = Color.FromArgb(92, 136, 86);
            }


            //lb47.Text = "17"; lb49.Text = "38"; lb50.Text = "42"; lb53.Text = "75"; lb54.Text = "84";
            for (int j = 1; j <= 5;)
            {
                lb47.Text = "17";
                arrPhieuDo[6, j] = int.Parse(lb47.Text); ++j;
                lb49.Text = "38";
                arrPhieuDo[6, j] = int.Parse(lb49.Text); ++j;
                lb50.Text = "42";
                arrPhieuDo[6, j] = int.Parse(lb50.Text); ++j;
                lb53.Text = "75";
                arrPhieuDo[6, j] = int.Parse(lb53.Text); ++j;
                lb54.Text = "84";
                arrPhieuDo[6, j] = int.Parse(lb54.Text); ++j;
                lb46.BackColor = lb48.BackColor = lb51.BackColor = lb52.BackColor = Color.FromArgb(92, 136, 86);

                //lb47.BackColor = lb49.BackColor = lb50.BackColor = lb53.BackColor = lb54.BackColor = Color.FromArgb(92, 136, 86);
            }


            //lb56.Text = "15"; lb57.Text = "25"; lb60.Text = "51"; lb62.Text = "77"; lb63.Text = "85";
            for (int j = 1; j <= 5;)
            {
                lb56.Text = "15";
                arrPhieuDo[7, j] = int.Parse(lb56.Text); ++j;
                lb57.Text = "25";
                arrPhieuDo[7, j] = int.Parse(lb57.Text); ++j;
                lb60.Text = "51";
                arrPhieuDo[7, j] = int.Parse(lb60.Text); ++j;
                lb62.Text = "77";
                arrPhieuDo[7, j] = int.Parse(lb62.Text); ++j;
                lb63.Text = "85";
                arrPhieuDo[7, j] = int.Parse(lb63.Text); ++j;
                lb55.BackColor = lb58.BackColor = lb59.BackColor = lb61.BackColor = Color.FromArgb(92, 136, 86);

                //lb56.BackColor = lb57.BackColor = lb60.BackColor = lb62.BackColor = lb63.BackColor = Color.FromArgb(92, 136, 86);
            }


            //lb65.Text = "12"; lb67.Text = "36"; lb68.Text = "43"; lb70.Text = "64"; lb72.Text = "82";
            for (int j = 1; j <= 5;)
            {
                lb65.Text = "12";
                arrPhieuDo[8, j] = int.Parse(lb65.Text); ++j;
                lb67.Text = "36";
                arrPhieuDo[8, j] = int.Parse(lb67.Text); ++j;
                lb68.Text = "43";
                arrPhieuDo[8, j] = int.Parse(lb68.Text); ++j;
                lb70.Text = "64";
                arrPhieuDo[8, j] = int.Parse(lb70.Text); ++j;
                lb72.Text = "82";
                arrPhieuDo[8, j] = int.Parse(lb72.Text); ++j;
                lb64.BackColor = lb66.BackColor = lb69.BackColor = lb71.BackColor = Color.FromArgb(92, 136, 86);

                //lb65.BackColor = lb67.BackColor = lb68.BackColor = lb70.BackColor = lb72.BackColor = Color.FromArgb(92, 136, 86);
            }


            //lb73.Text = "3"; lb75.Text = "26"; lb76.Text = "39"; lb78.Text = "58"; lb79.Text = "66";
            for (int j = 1; j <= 5;)
            {
                lb73.Text = "3";
                arrPhieuDo[9, j] = int.Parse(lb73.Text); ++j;
                lb75.Text = "26";
                arrPhieuDo[9, j] = int.Parse(lb75.Text); ++j;
                lb76.Text = "39";
                arrPhieuDo[9, j] = int.Parse(lb76.Text); ++j;
                lb78.Text = "58";
                arrPhieuDo[9, j] = int.Parse(lb78.Text); ++j;
                lb79.Text = "66";
                arrPhieuDo[9, j] = int.Parse(lb79.Text); ++j;
                lb74.BackColor = lb77.BackColor = lb80.BackColor = lb81.BackColor = Color.FromArgb(92, 136, 86);

                //lb73.BackColor = lb75.BackColor = lb76.BackColor = lb78.BackColor = lb79.BackColor = Color.FromArgb(92, 136, 86);
            }


            //lb3.BackColor = lb4.BackColor = lb6.BackColor = lb8.BackColor = lb10.BackColor = lb12.BackColor =
            //   lb15.BackColor = lb18.BackColor = lb20.BackColor = lb23.BackColor = lb25.BackColor = lb27.BackColor
            //   = lb29.BackColor = lb31.BackColor = lb33.BackColor = lb36.BackColor = lb37.BackColor = lb39.BackColor
            //   = lb41.BackColor = lb44.BackColor = lb46.BackColor = lb48.BackColor = lb51.BackColor = lb52.BackColor
            //   = lb55.BackColor = lb58.BackColor = lb59.BackColor = lb61.BackColor = lb64.BackColor = lb66.BackColor
            //   = lb69.BackColor = lb71.BackColor = lb74.BackColor = lb77.BackColor = lb80.BackColor = lb81.BackColor
            //   = Color.FromArgb(92, 136, 86);
        }

        void openTicket4()
        {
            //lb2.Text = "16"; lb3.Text = "28"; lb5.Text = "45"; lb7.Text = "68"; lb9.Text = "87";
            for (int j = 1; j <= 5;)
            {
                lb2.Text = "16";
                arrPhieuDo[1, j] = int.Parse(lb2.Text); ++j;
                lb3.Text = "28";
                arrPhieuDo[1, j] = int.Parse(lb3.Text); ++j;
                lb5.Text = "45";
                arrPhieuDo[1, j] = int.Parse(lb5.Text); ++j;
                lb7.Text = "68";
                arrPhieuDo[1, j] = int.Parse(lb7.Text); ++j;
                lb9.Text = "87";
                arrPhieuDo[1, j] = int.Parse(lb9.Text); ++j;
                lb1.BackColor = lb4.BackColor = lb6.BackColor = lb8.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb10.Text = "4"; lb12.Text = "29"; lb13.Text = "35"; lb15.Text = "55"; lb17.Text = "73";
            for (int j = 1; j <= 5;)
            {
                lb10.Text = "4";
                arrPhieuDo[2, j] = int.Parse(lb10.Text); ++j;
                lb12.Text = "29";
                arrPhieuDo[2, j] = int.Parse(lb12.Text); ++j;
                lb13.Text = "35";
                arrPhieuDo[2, j] = int.Parse(lb13.Text); ++j;
                lb15.Text = "55";
                arrPhieuDo[2, j] = int.Parse(lb15.Text); ++j;
                lb17.Text = "73";
                arrPhieuDo[2, j] = int.Parse(lb17.Text); ++j;

                lb11.BackColor = lb14.BackColor = lb16.BackColor = lb18.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb19.Text = "9"; lb22.Text = "30"; lb24.Text = "54"; lb25.Text = "62"; lb27.Text = "88";
            for (int j = 1; j <= 5;)
            {
                lb19.Text = "9";
                arrPhieuDo[3, j] = int.Parse(lb19.Text); ++j;
                lb22.Text = "30";
                arrPhieuDo[3, j] = int.Parse(lb22.Text); ++j;
                lb24.Text = "54";
                arrPhieuDo[3, j] = int.Parse(lb24.Text); ++j;
                lb25.Text = "62";
                arrPhieuDo[3, j] = int.Parse(lb25.Text); ++j;
                lb27.Text = "88";
                arrPhieuDo[3, j] = int.Parse(lb27.Text); ++j;

                lb20.BackColor = lb21.BackColor = lb23.BackColor = lb26.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb28.Text = "1"; lb30.Text = "21"; lb31.Text = "33"; lb33.Text = "52"; lb35.Text = "76";
            for (int j = 1; j <= 5;)
            {
                lb28.Text = "1";
                arrPhieuDo[4, j] = int.Parse(lb28.Text); ++j;
                lb30.Text = "21";
                arrPhieuDo[4, j] = int.Parse(lb30.Text); ++j;
                lb31.Text = "33";
                arrPhieuDo[4, j] = int.Parse(lb31.Text); ++j;
                lb33.Text = "52";
                arrPhieuDo[4, j] = int.Parse(lb33.Text); ++j;
                lb35.Text = "76";
                arrPhieuDo[4, j] = int.Parse(lb35.Text); ++j;

                lb29.BackColor = lb32.BackColor = lb34.BackColor = lb36.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb37.Text = "8"; lb41.Text = "40"; lb42.Text = "50"; lb44.Text = "79"; lb45.Text = "81";
            for (int j = 1; j <= 5;)
            {
                lb37.Text = "8";
                arrPhieuDo[5, j] = int.Parse(lb37.Text); ++j;
                lb41.Text = "40";
                arrPhieuDo[5, j] = int.Parse(lb41.Text); ++j;
                lb42.Text = "50";
                arrPhieuDo[5, j] = int.Parse(lb42.Text); ++j;
                lb44.Text = "79";
                arrPhieuDo[5, j] = int.Parse(lb44.Text); ++j;
                lb45.Text = "81";
                arrPhieuDo[5, j] = int.Parse(lb45.Text); ++j;

                lb43.BackColor = lb39.BackColor = lb38.BackColor = lb40.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb47.Text = "11"; lb48.Text = "20"; lb50.Text = "46"; lb52.Text = "63"; lb54.Text = "83";
            for (int j = 1; j <= 5;)
            {
                lb47.Text = "11";
                arrPhieuDo[6, j] = int.Parse(lb47.Text); ++j;
                lb48.Text = "20";
                arrPhieuDo[6, j] = int.Parse(lb48.Text); ++j;
                lb50.Text = "46";
                arrPhieuDo[6, j] = int.Parse(lb50.Text); ++j;
                lb52.Text = "63";
                arrPhieuDo[6, j] = int.Parse(lb52.Text); ++j;
                lb54.Text = "83";
                arrPhieuDo[6, j] = int.Parse(lb54.Text); ++j;

                lb46.BackColor = lb49.BackColor = lb51.BackColor = lb53.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb57.Text = "27"; lb59.Text = "49"; lb60.Text = "59"; lb62.Text = "72"; lb63.Text = "80";
            for (int j = 1; j <= 5;)
            {
                lb57.Text = "27";
                arrPhieuDo[7, j] = int.Parse(lb57.Text); ++j;
                lb59.Text = "49";
                arrPhieuDo[7, j] = int.Parse(lb59.Text); ++j;
                lb60.Text = "59";
                arrPhieuDo[7, j] = int.Parse(lb60.Text); ++j;
                lb62.Text = "72";
                arrPhieuDo[7, j] = int.Parse(lb62.Text); ++j;
                lb63.Text = "80";
                arrPhieuDo[7, j] = int.Parse(lb63.Text); ++j;

                lb55.BackColor = lb56.BackColor = lb58.BackColor = lb61.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }

            //lb64.Text = "2"; lb65.Text = "19"; lb67.Text = "32"; lb68.Text = "48"; lb70.Text = "67";
            for (int j = 1; j <= 5;)
            {
                lb64.Text = "2";
                arrPhieuDo[8, j] = int.Parse(lb64.Text); ++j;
                lb65.Text = "19";
                arrPhieuDo[8, j] = int.Parse(lb65.Text); ++j;
                lb67.Text = "32";
                arrPhieuDo[8, j] = int.Parse(lb67.Text); ++j;
                lb68.Text = "48";
                arrPhieuDo[8, j] = int.Parse(lb68.Text); ++j;
                lb70.Text = "67";
                arrPhieuDo[8, j] = int.Parse(lb70.Text); ++j;

                lb66.BackColor = lb69.BackColor = lb71.BackColor = lb72.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }
            //lb74.Text = "14"; lb75.Text = "22"; lb78.Text = "57"; lb80.Text = "78"; lb81.Text = "90";
            for (int j = 1; j <= 5;)
            {
                lb74.Text = "14";
                arrPhieuDo[9, j] = int.Parse(lb74.Text); ++j;
                lb75.Text = "22";
                arrPhieuDo[9, j] = int.Parse(lb75.Text); ++j;
                lb78.Text = "57";
                arrPhieuDo[9, j] = int.Parse(lb78.Text); ++j;
                lb80.Text = "78";
                arrPhieuDo[9, j] = int.Parse(lb80.Text); ++j;
                lb81.Text = "90";
                arrPhieuDo[9, j] = int.Parse(lb81.Text); ++j;

                lb73.BackColor = lb76.BackColor = lb77.BackColor = lb79.BackColor = Color.FromArgb(92, 136, 86);
                //lb1.BackColor = lb2.BackColor = lb5.BackColor = lb7.BackColor = lb9.BackColor = Color.FromArgb(92, 136, 86);
            }
        }
    }
}
