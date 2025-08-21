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
    public class ThongKeBaoCaoDL: DataProvider
    {
        // Lấy tổng doanh thu
        public decimal LayTongDoanhThu(int thang, int nam)
        {
            try
            {
                string sql = "sp_DoanhThuTong";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam",nam)};
                object kq = MyExecuteScalar(sql, CommandType.StoredProcedure, param);

                if(kq == null || kq == DBNull.Value)
                    return 0;

                return Convert.ToDecimal(kq);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy doanh thu theo từng loại sản phẩm
        public DataTable LayDoanhThu_LoaiSP(int thang, int nam)
        {
            try
            {
                string sql = "sp_ThongKeLoaiSP";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam", nam) };
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tổng số hóa đơn
        public int LayTongHoaDon(int thang, int nam)
        {
            try
            {
                string sql = "sp_LayTongHoaDon";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam", nam) };
                object kq = MyExecuteScalar(sql, CommandType.StoredProcedure, param);

                if (kq == null || kq == DBNull.Value)
                    return 0;

                return Convert.ToInt32(kq);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tổng tiền nhập hàng
        public decimal LayTongTienNhap(int thang, int nam)
        {
            try
            {
                string sql = "sp_LayTongTienNhap";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam", nam) };
                object kq = MyExecuteScalar(sql, CommandType.StoredProcedure, param);

                if (kq == null || kq == DBNull.Value)
                    return 0;

                return Convert.ToDecimal(kq);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy doanh thu từng ngày trong tháng
        public DataTable LayDT_Ngay(int thang, int nam)
        {
            try
            {
                string sql = "sp_LayDoanhThuTungNgayTrongThang";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam", nam) };
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thống kê tồn kho và số lượt bán của sản phẩm
        public DataTable ThongKeSLSanPham(int thang, int nam)
        {
            try
            {
                string sql = "sp_ThongKeSLSanPham";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam", nam) };
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thống kê nhập kho sản phẩm
        public DataTable ThongKeNhapKhoSanPham(int thang, int nam)
        {
            try
            {
                string sql = "sp_ThongKeNhapKho";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam", nam) };
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thống kê nhập hãng sản xuất
        public DataTable ThongKeHangSX(int thang, int nam)
        {
            try
            {
                string sql = "sp_ThongKeHangSX";
                SqlParameter[] param = { new SqlParameter("@Thang", thang), new SqlParameter("@Nam", nam) };
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


    }
}
