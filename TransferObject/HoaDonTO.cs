using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class HoaDonTO
    {
        public int maHD { get; set; }
        public DateTime ngayLapHD { get; set; }
        public int maNV { get; set; }
        public int maKH { get; set; }
        public string phuongThucTT { get; set; }

        public HoaDonTO(int maHD, DateTime ngayLapHD, int maNV, int maKH, string phuongThucTT)
        {
            this.maHD = maHD;
            this.ngayLapHD = ngayLapHD;
            this.maNV = maNV;
            this.maKH = maKH;
            this.phuongThucTT = phuongThucTT;
        }
    }
}
