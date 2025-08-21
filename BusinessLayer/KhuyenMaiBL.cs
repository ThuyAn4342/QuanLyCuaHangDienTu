using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DataLayer;
using TransferObject;
using System.Data.SqlClient;

namespace BusinessLayer
{
    public class KhuyenMaiBL
    {
        KhuyenMaiDL khuyenmaiDL = new KhuyenMaiDL();

        // Lấy DS khuyến mãi
        public DataTable LayDSKhuyenMai()
        {
            try
            {
                return khuyenmaiDL.LayDSKhuyenMai();
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
                return khuyenmaiDL.LayKM_maSP(maSP);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Thêm khuyến mãi

        public bool ThemKhuyenMai(KhuyenMaiTO km, out string thongBao)
        {
            try
            {
                if(km.ngayBatDau <= km.ngayKetThuc)
                {
                    if(km.ngayBatDau >= DateTime.Today)
                    {
                        if(khuyenmaiDL.ThemKhuyenMai(km))
                        {
                            thongBao = "Thêm thành công!!!";
                            return true;
                        } 
                        else
                        {
                            thongBao = "Thất bại!";
                            return false;
                        }    
                    }
                    else
                    {
                        thongBao = " Ngày bắt đầu KHÔNG thể được thiết lập trước ngày hôm nay!!!";
                        return false;
                    }    
                }
                else
                {
                    thongBao = " Ngày bắt đầu KHÔNG thể được thiết lập sau ngày kết thúc!!!";
                    return false;
                }    
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
                return khuyenmaiDL.KT_ThoiHanKM(maKM);
               
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Cập nhật khuyến mãi
        public bool CapNhatKhuyenMai(KhuyenMaiTO km, out string thongBao)
        {
            try
            {
                if (km.ngayBatDau <= km.ngayKetThuc)
                {
                    if (khuyenmaiDL.CapNhatKhuyenMai(km))
                    {
                        thongBao = "Cập nhật thành công!!!";
                        return true;
                    }
                    else
                    {
                        thongBao = "Thất bại!";
                        return false;
                    }
                }
                else
                {
                    thongBao = " Ngày bắt đầu KHÔNG thể được thiết lập sau ngày kết thúc!!!";
                    return false;
                }

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Xóa khuyến mãi
        public bool XoaKhuyenMai(int maKM, out string thongBao)
        {
            try
            {
                if(khuyenmaiDL.KT_XoaKM(maKM))
                {
                    thongBao = "Khuyến mãi này có quan hệ ràng buộc trong giao dịch khác, KHÔNG thể xóa!!!";
                    return false;
                } 
                else
                {
                    if(khuyenmaiDL.XoaKhuyenMai(maKM))
                    {
                        thongBao = "Xóa thành công!";
                        return true;

                    }  
                    else
                    {
                        thongBao = "Thất bại";
                        return false;
                    }    
                }    
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Lấy tỷ lệ giảm giá cho mã khách hàng
        public DataTable LayKhuyenMai_maKH(int maKH)
        {
            try
            {
                return khuyenmaiDL.LayKhuyenMai_maKH(maKH);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
