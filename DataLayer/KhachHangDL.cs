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
    public class KhachHangDL: DataProvider
    {
        // Lấy danh sách khách hàng
        public DataTable LayDS_KhachHang()
        {
            try
            {
                string sql = "SELECT * FROM KhachHang";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thêm khách hàng
        public bool ThemKhachHang(KhachHangTO k)
        {
            try
            {
                string sql = "sp_ThemKhachHang";
                SqlParameter[] param = { new SqlParameter("@hoKH",k.hoKH),
                                         new SqlParameter("@tenKH",k.tenKH),
                                         new SqlParameter("@soDT",k.soDT),
                                         new SqlParameter("@email", string.IsNullOrEmpty(k.email) ? (object)DBNull.Value : k.email),
                                         new SqlParameter("@diaChi", string.IsNullOrEmpty(k.diaChi) ? (object)DBNull.Value : k.diaChi),
                                         new SqlParameter("@hangKH",k.hangKH)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Cập nhật thông tin khách hàng
        public bool CapNhatKhachHang(KhachHangTO k)
        {
            try
            {
                string sql = "sp_CapNhatKhachHang";
                SqlParameter[] param = { new SqlParameter("maKH",k.maKH),
                                         new SqlParameter("@hoKH",k.hoKH),
                                         new SqlParameter("@tenKH",k.tenKH),
                                         new SqlParameter("@soDT",k.soDT),
                                         new SqlParameter("@email", string.IsNullOrEmpty(k.email) ? (object)DBNull.Value : k.email),
                                         new SqlParameter("@diaChi", string.IsNullOrEmpty(k.diaChi) ? (object)DBNull.Value : k.diaChi),
                                         new SqlParameter("@hangKH",k.hangKH)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra trước khi xóa khách hàng
        public bool KT_XoaKH(int maKH)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM HoaDon WHERE maKH = "+maKH;
              
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }


        // Xóa khách hàng
        public bool XoaKhachHang(int maKH)
        {
            try
            {
                string sql = "sp_XoaKhachHang";
                SqlParameter[] param = { new SqlParameter("@maKH", maKH)};
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure,param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        // Tìm kiếm theo số điện thoại
        public DataTable TimKiem_soDT(string soDT)
        {
            try
            {
                string sql = "SELECT * FROM KhachHang WHERE soDT LIKE '%" + soDT + "%' ";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Tìm kiếm theo tên khách hàng 
        public DataTable TimKiem_tenKH(string tenKH)
        {
            try
            {
                string sql = "SELECT * FROM KhachHang WHERE tenKH = N'" + tenKH + "'";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy danh sách hạng khách hàng
        public DataTable LayDS_HangKH()
        {
            try
            {
                string sql = "SELECT * FROM HangKhachHang";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tên khách hàng qua mã khách hàng
        public string LayTenKH_maKH(int maKH)
        {
            try
            {
                string sql = "SELECT hoKH + ' ' + tenKH FROM KhachHang WHERE maKH = " + maKH;
                object tenKH = MyExecuteScalar(sql, CommandType.Text);
                return tenKH.ToString();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
