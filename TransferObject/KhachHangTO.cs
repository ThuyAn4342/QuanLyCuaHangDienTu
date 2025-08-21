using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class KhachHangTO
    {
        public int maKH { get; set; }
        public string hoKH { get; set; }
        public string tenKH { get; set; }
        public string soDT { get; set; }
        public string email { get; set; }
        public string diaChi { get; set; }
        public string hangKH { get; set; }

        public KhachHangTO(int maKH, string hoKH, string tenKH,
            string soDT, string email, string diaChi, string hangKH)
        {
            this.maKH = maKH;
            this.hoKH = hoKH;
            this.tenKH = tenKH;
            this.soDT = soDT;
            this.email = email;
            this.diaChi = diaChi;
            this.hangKH = hangKH;
        }
    }
}
