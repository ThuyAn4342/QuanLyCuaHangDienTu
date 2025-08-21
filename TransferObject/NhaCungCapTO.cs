using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class NhaCungCapTO
    {
        public int maNCC { get; set; }
        public string tenNCC { get; set; }
        public string soDT { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }

        public NhaCungCapTO(int maNCC, string tenNCC, string soDT, string email, string diaChi)
        {
            this.maNCC = maNCC;
            this.tenNCC = tenNCC;
            this.soDT = soDT;
            this.email = email;
            this.diaChi = diaChi;
        }
    }
}
