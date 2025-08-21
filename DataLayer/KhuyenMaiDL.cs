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
    public class KhuyenMaiDL: DataProvider
    {
        // Lấy danh sách khuyến mãi
        public DataTable LayDSKhuyenMai()
        {
            try
            {
                string sql = " SELECT * FROM KhuyenMai";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy khuyến mãi qua mã sản phẩm
        public string LayKM_maSP(int maSP)
        {
            try
            {
                string sql = "SELECT k.tenKM FROM SanPham s JOIN KhuyenMai k ON s.maKM = k.maKM WHERE s.maSP = " + maSP;
                object kq = MyExecuteScalar(sql, CommandType.Text);
                if (kq != null && kq != DBNull.Value)
                    return kq.ToString();
                else return "";
            }
            catch (SqlException ex)
            {

                throw ex;
            } 
        }

        // Thêm khuyến mãi

        public bool ThemKhuyenMai(KhuyenMaiTO km)
        {
            try
            {
                string sql = "sp_ThemKhuyenMai";
                SqlParameter[] param = { new SqlParameter("@tenKM", km.tenKM),
                                     new SqlParameter("@tyLeGiam", km.tyLeGiam),
                                     new SqlParameter("@loaiKM", km.loaiKM),
                                     new SqlParameter("@ngayBatDau", km.ngayBatDau),
                                     new SqlParameter("@ngayKetThuc", km.ngayKetThuc),
                                     new SqlParameter("@ghiChu", string.IsNullOrEmpty(km.ghiChu) ? (object)DBNull.Value : km.ghiChu)
                };
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra thời hạn của khuyến mãi
        public bool KT_ThoiHanKM(int maKM)
        {
            try
            {
                string sql = "sp_KTHanSuDungCuaKM";
                SqlParameter[] param = { new SqlParameter("@maKM", maKM)};
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.StoredProcedure, param)) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra trước khi xóa khuyến mãi
        public bool KT_XoaKM(int maKM)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM SanPham WHERE maKM = "+ maKM;
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Cập nhật khuyến mãi
        public bool CapNhatKhuyenMai(KhuyenMaiTO km)
        {
            try
            {
                string sql = "sp_CapNhatKhuyenMai";
                SqlParameter[] param = { new SqlParameter("@maKM",km.maKM),
                                     new SqlParameter("@tenKM", km.tenKM),
                                     new SqlParameter("@tyLeGiam", km.tyLeGiam),
                                     new SqlParameter("@loaiKM", km.loaiKM),
                                     new SqlParameter("@ngayBatDau", km.ngayBatDau),
                                     new SqlParameter("@ngayKetThuc", km.ngayKetThuc),
                                     new SqlParameter("@ghiChu", string.IsNullOrEmpty(km.ghiChu) ? (object)DBNull.Value : km.ghiChu)
                };
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Xóa khuyến mãi
        public bool XoaKhuyenMai(int maKM)
        {
            try
            {
                string sql = "DELETE FROM KhuyenMai WHERE maKM = "+maKM;
                return MyExecuteNonQuery(sql, CommandType.Text) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Lấy khuyến mãi cho mã khách hàng
        public DataTable LayKhuyenMai_maKH(int maKH)
        {
            try
            {
                string sql = "sp_LayKhuyenMai_maKH";
                SqlParameter[] param = { new SqlParameter("@maKH", maKH) };

                return MyExecuteReader(sql,CommandType.StoredProcedure,param);
                
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
