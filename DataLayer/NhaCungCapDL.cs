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
    public class NhaCungCapDL: DataProvider
    {
        // Lấy danh sách nhà cung cấp
        public DataTable LayDS_NCC()
        {
            try
            {
                string sql = "SELECT * FROM NhaCungCap";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra tên NCC đã có chưa
        public bool KiemTraTenNCC(string tenNCC)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM NhaCungCap WHERE tenNCC = '" + tenNCC + "'";
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;
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
                string sql = "SELECT tenNCC FROM NhaCungCap WHERE maNCC = " + maNCC;
                return MyExecuteScalar(sql, CommandType.Text).ToString();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thêm nhà cung cấp
        public bool ThemNCC(NhaCungCapTO n)
        {
            try
            {
                string sql = "sp_ThemNhaCungCap";
                SqlParameter[] param = { new SqlParameter("@tenNCC",n.tenNCC),
                                         new SqlParameter("@soDT",n.soDT),
                                         new SqlParameter("@email",n.email),
                                         new SqlParameter("@diaChi",n.diaChi)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Cập nhật thông tin nhà cung cấp
        public bool CapNhatNCC(NhaCungCapTO n)
        {
            try
            {
                string sql = "sp_CapNhatNCC";
                SqlParameter[] param = { new SqlParameter("@maNCC",n.maNCC),
                                         new SqlParameter("@tenNCC",n.tenNCC),
                                         new SqlParameter("@soDT",n.soDT),
                                         new SqlParameter("@email",n.email),
                                         new SqlParameter("@diaChi",n.diaChi)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra nhà cung cấp trước khi xóa
        public bool KT_TruocKhiXoa(int maNCC)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM NhapKho WHERE maNCC =" + maNCC;
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        // Xóa nhà cung cấp
        public bool XoaNCC(int maNCC)
        {
            try
            {
                string sql = "DELETE FROM NhaCungCap WHERE maNCC ="+maNCC;
                
                return MyExecuteNonQuery(sql, CommandType.Text) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }
}
