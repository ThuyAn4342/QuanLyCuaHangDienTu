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
    public class KhachHangBL
    {
        KhachHangDL khachhangDL = new KhachHangDL();

        // Lấy danh sách Khách hàng
        public DataTable LayDS_KhachHang()
        {
            try
            {
                return khachhangDL.LayDS_KhachHang();
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
                return khachhangDL.ThemKhachHang(k);
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
                return khachhangDL.CapNhatKhachHang(k);
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
                return khachhangDL.KT_XoaKH(maKH);
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
                return khachhangDL.XoaKhachHang(maKH);
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
               return khachhangDL.TimKiem_soDT(soDT);
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
                return khachhangDL.TimKiem_tenKH(tenKH);
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
                return khachhangDL.LayDS_HangKH();
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
                return khachhangDL.LayTenKH_maKH(maKH);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
