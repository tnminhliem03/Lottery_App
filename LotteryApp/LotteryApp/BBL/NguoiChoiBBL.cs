using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using LotteryApp.DTO;

namespace LotteryApp.BBL
{
    public class NguoiChoiBBL
    {
        XmlDocument doc;
        XmlElement root;
        string fileName = @"D:\LapTrinhGiaoDien_C#\LotteryApp_L4\LotteryApp\LotteryApp\XMLNguoiChoi.xml";
        public NguoiChoiBBL()
        {
            doc = new XmlDocument();
            doc.Load(fileName);
            root = doc.DocumentElement;
        }

        public int getTongTienHienTai()
        {
            int temp = 0;
            int soDong = 0;
            XmlNodeList ds = root.SelectNodes("nguoiChoi");

            foreach (XmlNode item in ds)
            {
                temp += int.Parse(item.SelectSingleNode("soTien").InnerText);
                soDong++;
            }

            return temp;
        }

        public int getMaLanChoi()
        {
            int temp = 1;
            int soDong = 0;
            XmlNodeList ds = root.SelectNodes("nguoiChoi");

            foreach (XmlNode item in ds)
            {
                
                temp += 1;
                soDong++;
            }

            return temp;
        }
        public void Them(NguoiChoi playerNew)
        {
            // tao nut player
            XmlNode player = doc.CreateElement("nguoiChoi");

            // tao nut con cua player
            XmlElement maLanChoi = doc.CreateElement("maLanChoi");
            maLanChoi.InnerText = playerNew.MaLanChoi; // gan gia tri cho maLanChoi
            player.AppendChild(maLanChoi); // themmaNguoiChoi vao trong player

            XmlElement mauPhieu = doc.CreateElement("mauPhieu");
            mauPhieu.InnerText = playerNew.MauPhieu;
            player.AppendChild(mauPhieu);

            XmlElement ketQua = doc.CreateElement("ketQua");
            ketQua.InnerText = playerNew.KetQua;
            player.AppendChild(ketQua);

            XmlElement soTien = doc.CreateElement("soTien");
            soTien.InnerText = playerNew.SoTien.ToString();
            player.AppendChild(soTien);

            root.AppendChild(player); // them player vao goc root
            doc.Save(fileName); // luu du lieu
        }

        public void Sua(NguoiChoi playerSua)
        {
          //  lay vi tri can sua theo maNguoiChoi
           XmlNode nguoiChoiCu = root.SelectSingleNode("nguoiChoi[maLanChoi ='" + playerSua.MaLanChoi + "']");
            if (nguoiChoiCu != null)
            {
                if (nguoiChoiCu.ChildNodes[0].InnerText != "")
                {
                    nguoiChoiCu.ChildNodes[0].InnerText = playerSua.MaLanChoi;
                }
                
                if (nguoiChoiCu.ChildNodes[1].InnerText != "")
                {
                    nguoiChoiCu.ChildNodes[1].InnerText = playerSua.MauPhieu;
                }

                if (nguoiChoiCu.ChildNodes[2].InnerText != "")
                {
                    nguoiChoiCu.ChildNodes[2].InnerText = playerSua.KetQua;
                }

                if (nguoiChoiCu.ChildNodes[3].InnerText != "")
                {
                    nguoiChoiCu.ChildNodes[3].InnerText = playerSua.SoTien.ToString();
                }

                doc.Save(fileName);
                //nguoiChoiCu.ChildNodes[0].Value = "1";
                //XmlNode playerSuaMoi = doc.CreateElement("nguoiChoi");

                //  tao nut con cua player
                //XmlNodeList ds = root.SelectNodes("nguoiChoi");
                //  foreach (XmlNode item in ds)
                //  {

                //  }
                //  XmlElement maLanChoi = doc.CreateElement("maLanChoi");
                //  maLanChoi.InnerText = playerSua.MaLanChoi; // gan gia tri cho maLanChoi
                //  playerSuaMoi.AppendChild(maLanChoi); // themMaNguoiChoi vao trong player sua

                //  XmlElement mauPhieu = doc.CreateElement("mauPhieu");
                //  mauPhieu.InnerText = playerSua.MauPhieu;
                //  playerSuaMoi.AppendChild(mauPhieu);

                //  XmlElement ketQua = doc.CreateElement("ketQua");
                //  ketQua.InnerText = playerSua.KetQua;
                //  playerSuaMoi.AppendChild(ketQua);

                //  XmlElement soTien = doc.CreateElement("soTien");
                //  soTien.InnerText = playerSua.SoTien.ToString();
                //  playerSuaMoi.AppendChild(soTien);

                ////  thay the nguoi choi cu thanh nguoi choi moi
                //  root.ReplaceChild(playerSuaMoi, nguoiChoiCu);
                //doc.Save(fileName);
            }
        }

        public void Xoa(NguoiChoi playerXoa)
        {
            XmlNode playerCanXoa = root.SelectSingleNode("nguoiChoi[maLanChoi='" + playerXoa.MaLanChoi + "']");

            if (playerCanXoa != null)
            {
                root.RemoveChild(playerCanXoa);

                doc.Save(fileName);
            }
        }

        public void TimKiem(NguoiChoi playerTim, DataGridView dgv)
        {
            dgv.Rows.Clear();
            XmlNode playerCanTim = root.SelectSingleNode("nguoiChoi[maLanChoi='" + playerTim.MaLanChoi + "']");

            if (playerCanTim != null)
            {
                dgv.ColumnCount = 4; // khai bao so cot
                dgv.Rows.Add(); // them mot dong moi

                // dua du lieu vao dong vua tao
                XmlNode maNguoiChoi = playerCanTim.SelectSingleNode("maLanChoi");
                dgv.Rows[0].Cells[0].Value = maNguoiChoi.InnerText;

                XmlNode mauPhieu = playerCanTim.SelectSingleNode("mauPhieu");
                dgv.Rows[0].Cells[1].Value = mauPhieu.InnerText;

                XmlNode ketQua = playerCanTim.SelectSingleNode("ketQua");
                dgv.Rows[0].Cells[2].Value = ketQua.InnerText;

                XmlNode soTien = playerCanTim.SelectSingleNode("soTien");
                dgv.Rows[0].Cells[3].Value = soTien.InnerText;
            }
        }

        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 4;
            int soDong = 0;
            XmlNodeList ds = root.SelectNodes("nguoiChoi");

            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add(); // them 1 dong
                dgv.Rows[soDong].Cells[0].Value = item.SelectSingleNode("maLanChoi").InnerText;
                dgv.Rows[soDong].Cells[1].Value = item.SelectSingleNode("mauPhieu").InnerText;
                dgv.Rows[soDong].Cells[2].Value = item.SelectSingleNode("ketQua").InnerText;
                dgv.Rows[soDong].Cells[3].Value = item.SelectSingleNode("soTien").InnerText;
                soDong++;
            }
        }
    }
}
