using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class NhaCungCapBL
    {
        NhaCungCapDL nhacungcapDL = new NhaCungCapDL();

        // Lấy danh sách nhà cung cấp
        public DataTable LayDS_NCC()
        {
            try
            {
                return nhacungcapDL.LayDS_NCC();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thêm nhà cung cấp
        public bool ThemNhaCungCap(NhaCungCapTO n, out string thongBao)
        {
            try
            {
                if(nhacungcapDL.KiemTraTenNCC(n.tenNCC))
                {
                    thongBao = "Nhà cung cấp này đã tồn tại!!!";
                    return false; 
                }
                
                if(nhacungcapDL.ThemNCC(n))
                {
                    thongBao = "Thêm thành công!!";
                    return true;
                } 
                else
                {
                    thongBao = "Thất bại";
                    return false;
                }    
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Cập nhật nhà cung cấp
        public bool CapNhatCungCap(NhaCungCapTO n, out string thongBao)
        {
            try
            {
                string tenNCC = nhacungcapDL.LayTenNCC(n.maNCC);
                if(tenNCC.Equals(n.tenNCC) == false)
                {
                    if (nhacungcapDL.KiemTraTenNCC(n.tenNCC))
                    {
                        thongBao = "Nhà cung cấp này đã tồn tại!!!";
                        return false;
                    }
                }    

                if (nhacungcapDL.CapNhatNCC(n))
                {
                    thongBao = "Cập nhật thành công!!";
                    return true;
                }
                else
                {
                    thongBao = "Thất bại";
                    return false;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Xóa nhà cung cấp
        public bool Xoa_NCC(int maNCC, out string thongBao)
        {
            try
            {
                if(nhacungcapDL.KT_TruocKhiXoa(maNCC))
                {
                    thongBao = "Nhà cung cấp này có quan hệ ràng buộc với dữ liệu khác. Không thể xóa!!!";
                    return false;
                } 
                
                if(nhacungcapDL.XoaNCC(maNCC))
                {
                    thongBao = "Xóa thành công!";
                    return true;
                }  
                else
                {
                    thongBao = "Thất bại";
                    return false;
                }    
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tên NCC qua mã NCC
        public string LayTenNCC(int maNCC)
        {
            try
            {
                return nhacungcapDL.LayTenNCC(maNCC);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
