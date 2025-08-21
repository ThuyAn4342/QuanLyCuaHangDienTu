using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class SanPhamTO
    {
        public int maSP { get; set; }
        public string tenSP { get; set; }
        public int maLoai { get; set; }
        public int maHang { get; set; }
        public decimal donGiaNhap { get; set; }
        public decimal donGiaBan { get; set; }
        public int tonKho { get; set; }
        public int maKM { get; set; }
        public string trangThai { get; set; }

        public SanPhamTO(int maSP, string tenSP, int maLoai, int maHang,
            decimal donGiaNhap, decimal donGiaBan, int tonKho, int maKM, string trangThai)
        {
            this.maSP = maSP;
            this.tenSP = tenSP;
            this.maLoai = maLoai;
            this.maHang = maHang;
            this.donGiaNhap = donGiaNhap;
            this.donGiaBan = donGiaBan;
            this.tonKho = tonKho;
            this.maKM = maKM;
            this.trangThai = trangThai;
        }
    }
}
