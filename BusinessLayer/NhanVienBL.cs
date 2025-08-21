using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TransferObject;
using DataLayer;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public class NhanVienBL
    {
        NhanVienDL nhanvienDL = new NhanVienDL();

        // Lấy danh sách nhân viên
        public DataTable LayDS_NhanVien()
        {
            try
            {
                return nhanvienDL.LayDS_NhanVien();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thêm nhân viên
        public bool ThemNhanVien(NhanVienTO nv)
        {
            try
            {
                return nhanvienDL.ThemNhanVien(nv);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Cập nhật thông tin nhân viên
        public bool CapNhatNhanVien(NhanVienTO nv)
        {
            try
            {
                return nhanvienDL.CapNhatNhanVien(nv);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Xóa nhân viên
        public bool XoaNhanVien(int maNV, out string thongBao)
        {
            try
            {
                if (nhanvienDL.KT_XoaNV(maNV))
                {
                    thongBao = "Nhân viên này có quan hệ ràng buộc với dữ liệu khác. Không thể xóa!!!";
                    return false;
                }

                if (nhanvienDL.XoaNhanVien(maNV))
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

        // Tìm kiếm theo mã Nhân viên
        public DataTable TimKiem_maNV(int maNV)
        {
            try
            {
                return nhanvienDL.TimKiem_maNV(maNV);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Hàm chuẩn hóa tên NV
        private string ChuanHoaTen(string tenNV)
        {
            if (string.IsNullOrWhiteSpace(tenNV))
                return "";

            tenNV = tenNV.Trim().ToLower(); // bỏ khoảng trắng và viết thường hết
            return char.ToUpper(tenNV[0]) + tenNV.Substring(1);
        }


        // Tìm kiếm theo tên Nhân viên
        public DataTable TimKiem_tenNV(string tenNV)
        {
            try
            {
                tenNV = ChuanHoaTen(tenNV);
                return nhanvienDL.TimKiem_tenNV(tenNV);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tên nhân viên qua mã nhân viên
        public string LayTenNV_maNV(int maNV)
        {
            try
            {
                return nhanvienDL.LayTenNV_maNV(maNV);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy chức vụ qua mã nhân viên
        public string LayChucVu_maNV(int maNV)
        {
            try
            {
                return nhanvienDL.LayChucVu_maNV(maNV);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }
}
