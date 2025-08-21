using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class ChiTietNhapKhoTO
    {
        public int maNK { get; set; }
        public int maSP { get; set; }
        public int soLuongNhap { get; set; }
        public decimal donGiaNhap { get; set; }

        public ChiTietNhapKhoTO(int maNK, int maSP, int soLuongNhap, decimal donGiaNhap)
        {
            this.maNK = maNK;
            this.maSP = maSP;
            this.soLuongNhap = soLuongNhap;
            this.donGiaNhap = donGiaNhap;
        }
    }
}
