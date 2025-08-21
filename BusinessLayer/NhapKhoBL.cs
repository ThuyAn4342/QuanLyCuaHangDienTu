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
    public class NhapKhoBL
    {
        NhapKhoDL nhapkhoDL = new NhapKhoDL();
       
        // Lấy danh sách nhập kho
        public DataTable LayDS_NhapKho()
        {
            try
            {
                return nhapkhoDL.LayDS_NhapKho();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thêm phiếu nhập kho
        public int ThemNhapKho(NhapKhoTO nk)
        {
            try
            {
                return nhapkhoDL.ThemNhapKho_LayMaNK(nk);
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
                return nhapkhoDL.LayDSNhapKho_NgayNhap(ngayNhap); 
                
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
                // Xóa chi tiết nhập kho
                if (nhapkhoDL.XoaChiTietNhapKho(maNK))
                {
                    // Xóa phiếu nhập kho
                    return nhapkhoDL.XoaNhapKho(maNK);
                }
                else
                    return false;
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
                return nhapkhoDL.ThemChiTietNhapKho(c);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }



        // Lấy thông tin chi tiết của phiếu nhập kho
        public DataTable LayChiTietNhapKho(int maNK)
        {
            try
            {
                return nhapkhoDL.LayChiTietNhapKho(maNK);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        

        
    }
}
