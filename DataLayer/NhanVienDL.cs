using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using TransferObject;

namespace DataLayer
{
    public class NhanVienDL: DataProvider
    {
        // Lấy danh sách nhân viên
        public DataTable LayDS_NhanVien()
        {
            try
            {
                string sql = "SELECT * FROM NhanVien";
                return MyExecuteReader(sql, CommandType.Text);
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
                string sql = "sp_ThemNhanVien";
                SqlParameter[] param = { new SqlParameter("@hoNV",nv.hoNV),
                                         new SqlParameter("@tenNV",nv.tenNV),
                                         new SqlParameter("@ngaySinh",nv.ngaySinh),
                                         new SqlParameter("@gioiTinh", string.IsNullOrEmpty(nv.gioiTinh) ? (object)DBNull.Value : nv.gioiTinh),
                                         new SqlParameter("@chucVu",nv.chucVu),
                                         new SqlParameter("@soDT",nv.soDT),
                                         new SqlParameter("@email", string.IsNullOrEmpty(nv.email) ? (object)DBNull.Value : nv.email),
                                         new SqlParameter("@diaChi", string.IsNullOrEmpty(nv.diaChi) ? (object)DBNull.Value : nv.diaChi),
                                         new SqlParameter("@tinhTrang",nv.tinhTrang)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
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
                string sql = "sp_CapNhatNhanVien";
                SqlParameter[] param = { new SqlParameter("@maNV",nv.maNV),
                                         new SqlParameter("@hoNV",nv.hoNV),
                                         new SqlParameter("@tenNV",nv.tenNV),
                                         new SqlParameter("@ngaySinh",nv.ngaySinh),
                                         new SqlParameter("@gioiTinh", string.IsNullOrEmpty(nv.gioiTinh) ? (object)DBNull.Value : nv.gioiTinh),
                                         new SqlParameter("@chucVu",nv.chucVu),
                                         new SqlParameter("@soDT",nv.soDT),
                                         new SqlParameter("@email", string.IsNullOrEmpty(nv.email) ? (object)DBNull.Value : nv.email),
                                         new SqlParameter("@diaChi", string.IsNullOrEmpty(nv.diaChi) ? (object)DBNull.Value : nv.diaChi),
                                         new SqlParameter("@tinhTrang",nv.tinhTrang)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra trước khi xóa nhân viên
        public bool KT_XoaNV(int maNV)
        {
            try
            {
                string sql = "sp_KiemTraTruocKhiXoaNV";
                SqlParameter[] param = { new SqlParameter("@maNV",maNV) };
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.StoredProcedure,param)) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }


        // Xóa nhân viên
        public bool XoaNhanVien(int maNV)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE maNV = "+maNV;
                return MyExecuteNonQuery(sql,CommandType.Text) > 0;
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
                string sql = "SELECT * FROM NhanVien WHERE maNV = " + maNV;
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Tìm kiếm theo tên Nhân viên
        public DataTable TimKiem_tenNV(string tenNV)
        {
            try
            {
                string sql = "SELECT * FROM NhanVien WHERE tenNV = N'" + tenNV + "'";
                return MyExecuteReader(sql, CommandType.Text);
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
                string sql = "SELECT hoNV + tenNV FROM NhanVien WHERE maNV = " + maNV;
                object tenNV = MyExecuteScalar(sql, CommandType.Text);
                return tenNV.ToString();
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
                string sql = "SELECT chucVu FROM NhanVien WHERE maNV = " + maNV;
                object chucVu = MyExecuteScalar(sql, CommandType.Text);
                return chucVu.ToString();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
