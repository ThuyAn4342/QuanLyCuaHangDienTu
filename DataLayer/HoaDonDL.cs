using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class HoaDonDL:DataProvider
    {
        // ----- HÓA ĐƠN -----


        // Lấy danh sách hóa đơn
        public DataTable LayDS_HoaDon()
        {
            try
            {
                string sql = "SELECT * FROM HoaDon";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy danh sách hóa đơn theo mã nhân viên
        public DataTable LayDS_HoaDon_maNV(int maNV)
        {
            try
            {
                string sql = "SELECT * FROM HoaDon WHERE maNV = "+ maNV;
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thêm hóa đơn
        public int ThemHoaDon_LayMaHD(HoaDonTO h)
        {
            try
            {
                string sql = "sp_ThemHoaDon";

                SqlParameter[] param = {
                        new SqlParameter("@ngayLapHD", h.ngayLapHD),
                        new SqlParameter("@maNV", h.maNV),
                        new SqlParameter("@maKH", h.maKH),
                        new SqlParameter("@phuongThucTT", h.phuongThucTT),
                        new SqlParameter("@maHD", SqlDbType.Int)  // output param
                        {
                            Direction = ParameterDirection.Output
                        }
        };

                if (MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0)
                {
                    if (param[4].Value == DBNull.Value)
                        return -1;
                    else
                    {
                        return (int)param[4].Value; // trả về mã HD mới
                    }
                }
                else
                    return -1;


            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }



        // Lấy danh sách các hóa đơn từ ngày được chọn
        public DataTable LayDSHoaDon_NgayLapHD(DateTime ngayLapHD)
        {
            try
            {
                string sql = "sp_LayDSHoaDon_ngayLapHD";
                SqlParameter[] param = { new SqlParameter("@ngayLapHD", ngayLapHD) };
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        // Lấy danh sách các hóa đơn từ ngày được chọn theo mã nhân viên
        public DataTable LayDSHoaDon_maNV_NgayLapHD(int maNV, DateTime ngayLapHD)
        {
            try
            {
                string sql = "sp_LayDSHoaDon_maNV_ngayLapHD";
                SqlParameter[] param = { new SqlParameter("@maNV",maNV),new SqlParameter("@ngayLapHD", ngayLapHD) };
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }

        // Xóa hóa đơn
        public bool XoaHoaDon(int maHD)
        {
            try
            {
                string sql = "DELETE FROM HoaDon WHERE maHD = " + maHD;
                return MyExecuteNonQuery(sql, CommandType.Text) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }




        // ----- CHI TIẾT HÓA ĐƠN -----


        // Lấy thông tin chi tiết của hóa đơn
        public DataTable LayChiTietHoaDon(int maHD)
        {
            try
            {
                string sql = "SELECT * FROM ChiTietHD WHERE maHD = " + maHD;
                DataTable dt = MyExecuteReader(sql, CommandType.Text);
                return dt;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thêm thông tin chi tiết cho hóa đơn
        public bool ThemChiTietHoaDon(ChiTietHoaDonTO c)
        {
            try
            {
                string sql = "sp_ThemChiTietHD";
                SqlParameter[] param = { new SqlParameter("@maHD",c.maHD),
                                         new SqlParameter("@maSP",c.maSP),
                                         new SqlParameter("@soLuong",c.soLuong),
                                         new SqlParameter("@donGiaBan",c.donGiaBan),
                                         new SqlParameter("@tyLeGiamGia",c.tyLeGiamGia == 0 ? (object)DBNull.Value : c.tyLeGiamGia)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Cập nhật số lượng sản phẩm được thêm vào hóa đơn
        public bool CapNhapSlSP(int maSP,int soLuong)
        {
            try
            {
                string sql = "UPDATE SanPham SET soLuong = soLuong - " + soLuong + "WHERE maSP = " + maSP;
                return MyExecuteNonQuery(sql, CommandType.Text) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Xóa thông tin chi tiết hóa đơn
        public bool XoaChiTietHoaDon(int maHD)
        {
            try
            {
                string sql = "sp_XoaChiTietHoaDon";
                SqlParameter[] param = { new SqlParameter("@maHD", maHD) };
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Kiểm tra các sản phẩm trong hóa đơn có khuyến mãi không?
        public bool KT_KhuyenMai(int maHD)
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM ChiTietHD WHERE maHD = " + maHD + " AND tyLeGiamGia > 0";
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
    }
}
