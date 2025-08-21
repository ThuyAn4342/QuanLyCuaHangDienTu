using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class TaiKhoanTO
    {
        public int maNV { get; set; }
        public string tenDangNhap { get; set; }
        public string matKhau { get; set; }
        public string chucNang { get; set; }
        public string mail { get; set; }

        public TaiKhoanTO(int maNV, string tenDangNhap, string matKhau, string chucNang, string mail)
        {
            this.maNV = maNV;
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
            this.chucNang = chucNang;
            this.mail = mail;
        }
    }

    
}
