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
    public class TaiKhoanDL:DataProvider
    {
        // Lấy danh sách tài khoản
        public DataTable LayDS_Taikhoan()
        {
            try
            {
                string sql = "SELECT * FROM TaiKhoan";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Kiểm tra tên tài khoản đã tồn tại trước đó chưa
        public bool KiemTraTaiKhoan(string tenDangNhap)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE tenDangNhap = '" + tenDangNhap + "'";

                object sl = MyExecuteScalar(sql, CommandType.Text);
                return Convert.ToInt32(sl) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Kiểm maNV đã có tài khoản trước đó chưa
        public bool KiemTraTK_maNV(int maNV)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE maNV = " + maNV;

                object sl = MyExecuteScalar(sql, CommandType.Text);
                return Convert.ToInt32(sl) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tên đăng nhập qua mã NV
        public string LayTenDN(int maNV)
        {
            try
            {
                string sql = "SELECT tenDangNhap FROM TaiKhoan WHERE maNV = " + maNV;

                object tenDangNhap = MyExecuteScalar(sql, CommandType.Text);
                return tenDangNhap.ToString();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thêm tài khoản
        public bool ThemTaiKhoan(TaiKhoanTO ac)
        {
            try
            {
                string sql = "sp_ThemTaiKhoan";
                SqlParameter[] param = {
                new SqlParameter("@maNV", ac.maNV),
                new SqlParameter("@tenDangNhap", ac.tenDangNhap),
                new SqlParameter("@matKhau", ac.matKhau),
                new SqlParameter("@chucNang", ac.chucNang),
                new SqlParameter("@mail", ac.mail)
            };
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

       

        //Cập nhật tài khoản
        public bool CapNhatTaiKhoan(TaiKhoanTO ac)
        {
            try
            {
                string sql = "sp_CapNhatTaiKhoan";

                SqlParameter[] param = {
                new SqlParameter("@maNV", ac.maNV),
                new SqlParameter("@tenDangNhap", ac.tenDangNhap),
                new SqlParameter("@matKhau", ac.matKhau),
                new SqlParameter("@chucNang", ac.chucNang),
                new SqlParameter("@mail", ac.mail)
            };
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
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
                string sql = "DELETE FROM TaiKhoan WHERE maNV = " + maNV;

                return MyExecuteNonQuery(sql, CommandType.Text) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra đăng nhập
        public bool KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM TaiKhoan WHERE tenDangNhap = '" + tenDangNhap + "' AND matKhau = '" + matKhau + "'";
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;
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
                string sql = "SELECT * FROM TaiKhoan WHERE tenDangNhap = '" + tenDangNhap + "'";
                DataTable dt = MyExecuteReader(sql, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    return new TaiKhoanTO(Convert.ToInt32(row["maNV"]), row["tenDangNhap"].ToString(),
                        row["matKhau"].ToString(), row["chucNang"].ToString(), row["mail"].ToString());
                }
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
                string sql = "sp_DoiMatKhau";
                SqlParameter[] param = { new SqlParameter("@tenDangNhap", tenDangNhap),
                                         new SqlParameter("@matKhau", matKhauMoi)};

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
