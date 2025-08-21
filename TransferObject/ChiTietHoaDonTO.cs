using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class ChiTietHoaDonTO
    {
        public int maHD { get; set; }
        public int maSP { get; set; }
        public int soLuong { get; set; }
        public decimal donGiaBan { get; set; }
        public float tyLeGiamGia { get; set; }

        public ChiTietHoaDonTO(int maHD, int maSP, int soLuong, decimal donGiaBan, float tyLeGiamGia)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.soLuong = soLuong;
            this.donGiaBan = donGiaBan;
            this.tyLeGiamGia = tyLeGiamGia;
        }
    }
}
