using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class NhapKhoTO
    {
        public int maNK { get; set; }
        public DateTime ngayNhap { get; set; }
        public int maNV { get; set; }
        public int maNCC { get; set; }
        public string ghiChu { get; set; }

        public NhapKhoTO(int maNK, DateTime ngayNhap, int maNV, int maNCC, string ghiChu)
        {
            this.maNK = maNK;
            this.ngayNhap = ngayNhap;
            this.maNV = maNV;
            this.maNCC = maNCC;
            this.ghiChu = ghiChu;
        }
    }
}
