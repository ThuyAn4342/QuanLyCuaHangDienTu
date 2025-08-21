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
    public class TaiKhoanBL
    {
        TaiKhoanDL taikhoanDL = new TaiKhoanDL();

        // Lấy danh sách tài khoản
        public DataTable LayDS_Taikhoan()
        {
            return taikhoanDL.LayDS_Taikhoan();
        }

        //Kiểm tra tên tài khoản đã tồn tại trước đó chưa
        public bool KiemTraTaiKhoan(string tenDangNhap)
        {
            try
            {
                return taikhoanDL.KiemTraTaiKhoan(tenDangNhap);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thêm tài khoản
        public bool ThemTaiKhoan(TaiKhoanTO ac, out string thongBao)
        {
            try
            {
                if(taikhoanDL.KiemTraTaiKhoan(ac.tenDangNhap) )
                {
                    thongBao = "Tên đăng nhập đã tồn tại! Vui lòng chọn tên khác.";
                    return false;
                }
                else if(taikhoanDL.KiemTraTK_maNV(ac.maNV))
                {
                    thongBao = "Nhân viên này đã có tài khoản!! Không thể tạo thêm.";
                    return false;
                }    
                else 
                {
                    if(taikhoanDL.ThemTaiKhoan(ac))
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
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        //Cập nhật tài khoản
        public bool CapNhatTaiKhoan(TaiKhoanTO ac, out string thongBao)
        {
            try
            {
                string tenDN = taikhoanDL.LayTenDN(ac.maNV);
                if (tenDN.Equals(ac.tenDangNhap) == false)
                {
                    if(taikhoanDL.KiemTraTaiKhoan(ac.tenDangNhap))
                    {
                        thongBao = "Tên đăng nhập đã tồn tại! Vui lòng chọn tên khác.";
                        return false;
                    }
                }

                if (taikhoanDL.CapNhatTaiKhoan(ac))
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

        // Xóa tài khoản
        public bool XoaTaiKhoan(int maNV)
        {
            try
            {
                return taikhoanDL.XoaTaiKhoan(maNV);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tài khoản qua tên đăng nhập
        public TaiKhoanTO LayTaiKhoan_tenDangNhap(string tenDangNhap)
        {
            try
            {
                return taikhoanDL.LayTaiKhoan_tenDangNhap(tenDangNhap);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Đăng Nhập
        public TaiKhoanTO DangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                if (taikhoanDL.KiemTraDangNhap(tenDangNhap, matKhau))
                    return LayTaiKhoan_tenDangNhap(tenDangNhap);
                else
                    return null;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Đổi mật khẩu
        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            try
            {
                return taikhoanDL.DoiMatKhau(tenDangNhap, matKhauMoi);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
