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
    public class ThongKeBaoCaoBL
    {
        ThongKeBaoCaoDL thongkeBL = new ThongKeBaoCaoDL();
        // Lấy tổng doanh thu
        public decimal LayTongDoanhThu(int thang, int nam)
        {
            try
            {
                return thongkeBL.LayTongDoanhThu(thang, nam);
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
                return thongkeBL.LayDoanhThu_LoaiSP(thang, nam);
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
                return thongkeBL.LayTongHoaDon(thang, nam);
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
                return thongkeBL.LayTongTienNhap(thang, nam);
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
                return thongkeBL.LayDT_Ngay(thang, nam);
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
                return thongkeBL.ThongKeSLSanPham(thang, nam);
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
                return thongkeBL.ThongKeNhapKhoSanPham(thang, nam);
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
                return thongkeBL.ThongKeHangSX(thang, nam);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

    }
}
