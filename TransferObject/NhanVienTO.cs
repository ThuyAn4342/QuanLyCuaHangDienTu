using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class NhanVienTO
    {
        public int maNV { get; set; }
        public string hoNV { get; set; }
        public string tenNV { get; set; }
        public DateTime ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string chucVu { get; set; }
        public string soDT { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public string tinhTrang { get; set; }

        public NhanVienTO(int maNV, string hoNV, string tenNV, 
            DateTime ngaySinh, string gioiTinh, string chucVu,
            string soDT, string email, string diaChi, string tinhTrang)
        {
            this.maNV = maNV;
            this.hoNV = hoNV;
            this.tenNV = tenNV;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.chucVu = chucVu;
            this.soDT = soDT;
            this.email = email;
            this.diaChi = diaChi;
            this.tinhTrang = tinhTrang;
        }
    }
}
