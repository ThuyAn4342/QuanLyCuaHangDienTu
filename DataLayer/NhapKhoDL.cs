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
    public class NhapKhoDL: DataProvider
    {
        // ----- PHIẾU NHẬP KHO -----


        // Lấy danh sách nhập kho
        public DataTable LayDS_NhapKho()
        {
            try
            {
                string sql = "SELECT * FROM NhapKho";
                return MyExecuteReader(sql, CommandType.Text);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thêm phiếu nhập kho
        public int ThemNhapKho_LayMaNK(NhapKhoTO nk)
        {
            try
            {
                string sql = "sp_ThemNhapKho";

                SqlParameter[] param = {
                        new SqlParameter("@ngayNhap", nk.ngayNhap),
                        new SqlParameter("@maNV", nk.maNV),
                        new SqlParameter("@maNCC", nk.maNCC),
                        new SqlParameter("@ghiChu", string.IsNullOrEmpty(nk.ghiChu) ? (object)DBNull.Value : nk.ghiChu),
                        new SqlParameter("@maNK", SqlDbType.Int)  // output param
                        {
                            Direction = ParameterDirection.Output
                        }
        };

                if(MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0)
                {
                    if (param[4].Value == DBNull.Value)
                        return -1;
                    else
                    {
                        return (int)param[4].Value; // trả về mã NK mới
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



        // Lấy danh sách phiếu nhập kho từ ngày nhập
        public DataTable LayDSNhapKho_NgayNhap(DateTime ngayNhap)
        {
            try
            {
                string sql = "sp_LayDSNhapKho_NgayNhap";
                SqlParameter[] param = { new SqlParameter("@ngayNhap",ngayNhap)};
                return MyExecuteReader(sql, CommandType.StoredProcedure, param);
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }


        // Xóa phiếu nhập kho
        public bool XoaNhapKho(int maNK)
        {
            try
            {
                string sql = "DELETE FROM NhapKho WHERE maNK = " + maNK;
                return MyExecuteNonQuery(sql, CommandType.Text) > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }




        // ----- CHI TIẾT PHIẾU NHẬP KHO -----


        // Lấy thông tin chi tiết của phiếu nhập kho
        public DataTable LayChiTietNhapKho(int maNK)
        {
            try
            {
                string sql = "SELECT * FROM ChiTietNhapKho WHERE maNK = " + maNK;
                DataTable dt = MyExecuteReader(sql, CommandType.Text);               
                return dt;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
      

        // Thêm thông tin chi tiết cho phiếu nhập kho
        public bool ThemChiTietNhapKho(ChiTietNhapKhoTO c)
        {
            try
            {
                string sql = "sp_ThemChiTietNhapKho";
                SqlParameter[] param = { new SqlParameter("@maNK",c.maNK),
                                         new SqlParameter("@maSP",c.maSP),
                                         new SqlParameter("@soLuongNhap",c.soLuongNhap),
                                         new SqlParameter("@donGiaNhap",c.donGiaNhap)
                };

                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Xóa thông tin chi tiết phiếu nhập kho
        public bool XoaChiTietNhapKho(int maNK)
        {
            try
            {
                string sql = "sp_XoaChiTietNhapKho";
                SqlParameter[] param = { new SqlParameter("@maNK", maNK) };
                return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }
}
