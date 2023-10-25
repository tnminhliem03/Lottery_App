using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryApp.DTO
{
    public class NguoiChoi
    {
        private string _MaLanChoi;
        private string _MauPhieu;
        private string _KetQua;
        private int _SoTien;

        public global::System.String MaLanChoi { get => _MaLanChoi; set => _MaLanChoi = value; }
        public global::System.String MauPhieu { get => _MauPhieu; set => _MauPhieu = value; }
        public global::System.String KetQua { get => _KetQua; set => _KetQua = value; }
        public global::System.Int32 SoTien { get => _SoTien; set => _SoTien = value; }
    }

}
