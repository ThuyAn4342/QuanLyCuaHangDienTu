using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class KhuyenMaiTO
    {
        public int maKM { get; set; }
        public string tenKM { get; set; }
        public float tyLeGiam { get; set; }
        public string loaiKM { get; set; }
        public DateTime ngayBatDau { get; set; }
        public DateTime ngayKetThuc { get; set; }
        public string ghiChu { get; set; }

        public KhuyenMaiTO(int maKM, string tenKM, float tyLeGiam, string loaiKM, 
            DateTime ngayBatDau, DateTime ngayKetThuc, string ghiChu)
        {
            this.maKM = maKM;
            this.tenKM = tenKM;
            this.tyLeGiam = tyLeGiam;
            this.loaiKM = loaiKM;
            this.ngayBatDau = ngayBatDau;
            this.ngayKetThuc = ngayKetThuc;
            this.ghiChu = ghiChu;
        }
    }
}
