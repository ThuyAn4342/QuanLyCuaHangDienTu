using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class HoaDonBL
    {
        HoaDonDL hoadonDL = new HoaDonDL();

        // Lấy danh sách hóa đơn
        public DataTable LayDS_HoaDon()
        {
            try
            {
                return hoadonDL.LayDS_HoaDon();
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
                return hoadonDL.LayDS_HoaDon_maNV(maNV);
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
                return hoadonDL.ThemHoaDon_LayMaHD(h);
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
                return hoadonDL.LayDSHoaDon_NgayLapHD(ngayLapHD);
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
                return hoadonDL.LayDSHoaDon_maNV_NgayLapHD(maNV, ngayLapHD);
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
                return hoadonDL.XoaHoaDon(maHD);
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Lấy thông tin chi tiết của hóa đơn
        public DataTable LayChiTietHoaDon(int maHD)
        {
            try
            {
                return hoadonDL.LayChiTietHoaDon(maHD);
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
                return hoadonDL.ThemChiTietHoaDon(c);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Cập nhật số lượng sản phẩm được thêm vào hóa đơn
        public bool CapNhapSlSP(int maSP, int soLuong)
        {
            try
            {
                return hoadonDL.CapNhapSlSP(maSP, soLuong);
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
                return hoadonDL.XoaChiTietHoaDon(maHD);
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
                return hoadonDL.KT_KhuyenMai(maHD);
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
    }
}
