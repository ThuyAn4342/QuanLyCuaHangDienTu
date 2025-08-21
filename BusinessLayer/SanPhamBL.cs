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
    public class SanPhamBL
    {
        SanPhamDL sanphamDL = new SanPhamDL();

        //Lấy danh sách sản phẩm
        public DataTable LayDS_SanPham()
        {
            return sanphamDL.LayDS_SanPham();
        }

        //Kiểm tra mã sản phẩm có hợp lệ không?
        public bool TimKiemMaSP(int maSP)
        {
            return sanphamDL.TimKiemMaSP(maSP);
        }

        // Lấy tên sản phẩm qua mã SP
        public string LaySP_maSP(int maSP)
        {
            try
            {
                return sanphamDL.LaySP_maSP(maSP);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Tìm kiếm sản phẩm theo mã SP
        public DataTable TimKiemSP_maSP(int maSP)
        {
            try
            {
                return sanphamDL.LayDS_SanPham_MaSP(maSP);

            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Tìm kiếm sản phẩm theo Loại SP
        public DataTable TimKiemSP_maLoai(int maLoai)
        {
            try
            {
                return sanphamDL.LayDS_SanPham_LoaiSP(maLoai);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Tìm kiếm sản phẩm theo Hãng SP
        public DataTable TimKiemSP_maHang(int maHang)
        {
            try
            {
                return sanphamDL.LayDS_SanPham_HangSP(maHang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Tìm kiếm sản phẩm theo loại SP và hãng SX
        public DataTable TimKiemSP_maLoaiVAmaHang(int maLoai, int maHang)
        {
            try
            {
                return sanphamDL.LayDSSP_LoaiSP_HangSX(maLoai,maHang);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Thêm sản phẩm
        public bool ThemSanPham(SanPhamTO s, out string thongBao)
        {
            try
            {
                if (sanphamDL.KiemTraSanPham(s.tenSP))
                {
                    thongBao = "Sản phẩm này đã tồn tại trong hệ thống.";
                    return false;
                }    
                else
                {
                    bool kq = sanphamDL.ThemSanPham(s);
                    if (kq)
                    {
                        thongBao = "Thêm sản phẩm thành công!!!";
                        return true;
                    }    
                    else
                    {
                        thongBao = " Thêm sản phẩm thất bại!";
                        return false;
                    }    
                }    
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Cập nhật sản phẩm
        public bool CapNhatSP(SanPhamTO s, out string thongBao)
        {
            try
            {
                string tenSP = sanphamDL.LaySP_maSP(s.maSP);
               if(tenSP.Equals(s.tenSP) == false)
                {
                    if (sanphamDL.KiemTraSanPham(s.tenSP))
                    {
                        thongBao = "Sản phẩm này đã tồn tại trong hệ thống.";
                        return false;
                    }
                }


                bool kq = sanphamDL.CapNhatSP(s);
                if (kq)
                {
                    thongBao = "Cập nhật thành công!!!";
                    return true;
                }
                else
                {
                    thongBao = " Cập nhật thất bại!";
                    return false;
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Xóa sản phẩm
        public bool XoaSanPham(int maSP, out string thongBao)
        {
            try
            {
                if (sanphamDL.KiemTraTruocKhiXoaSP(maSP))
                {
                    thongBao = "Sản phẩm này đã tồn tại trong giao dich. Không thể xóa!!!";
                    return false;
                }
                else
                {
                    bool kq = sanphamDL.XoaSanPham(maSP);
                    if (kq)
                    {
                        thongBao = "Xóa thành công!!!";
                        return true;
                    }
                    else
                    {
                        thongBao = "Thất bại!";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        // Lấy tỷ lệ giảm của sản phẩm
        public decimal LayTyLeGiam_maSP(int maSP)
        {
            try
            {
                return sanphamDL.LayTyLeGiam_maSP(maSP);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //-------- LOẠI SẢN PHẨM ---------

        // Lấy danh sách loại sản phẩm
        public DataTable LayDSLoaiSP()
        {
            try
            {
                return sanphamDL.LayDSLoaiSP();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thêm loại sản phẩm
        public bool ThemLoaiSP(string tenLoai, out string thongBao)
        {
            try
            {
                if(sanphamDL.KiemTraLoaiSP(tenLoai))
                {
                    thongBao = "Loại sản phẩm này có nhiều sản phẩm, không thể xóa!!";
                    return false;
                }else
                {

                    bool kq = sanphamDL.ThemLoaiSP(tenLoai);
                    if (kq)
                    {
                        thongBao = "Thêm thành công!!!";
                        return true;
                    }
                    else
                    {
                        thongBao = " Thất bại!";
                        return false;
                    }
                }    
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Cập nhật loại SP
        public bool CapNhatLoaiSP(int maLoai, string tenLoai, out string thongBao)
        {
            try
            {
                if (sanphamDL.KiemTraLoaiSP(tenLoai))
                {
                    thongBao = "Loại sản phẩm này đã tồn tại trong hệ thống.";
                    return false;
                }
                else
                {
                    bool kq = sanphamDL.CapNhatLoaiSP(maLoai,tenLoai);
                    if (kq)
                    {
                        thongBao = "Cập nhật thành công!!!";
                        return true;
                    }
                    else
                    {
                        thongBao = " Cập nhật thất bại!";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Xóa loại sản phẩm
        public bool XoaLoaiSanPham(int maLoai, out string thongBao)
        {
            try
            {
                if (sanphamDL.KiemTra_XoaLoaiSP(maLoai))
                {
                    thongBao = "Loại sản phẩm này có nhiều sản phẩm. Không thể xóa!!!";
                    return false;
                }
                else
                {
                    bool kq = sanphamDL.XoaLoaiSP(maLoai);
                    if (kq)
                    {
                        thongBao = "Xóa thành công!!!";
                        return true;
                    }
                    else
                    {
                        thongBao = "Thất bại!";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }



        //-------- HÃNG SẢN XUẤT ---------

        // Lấy danh sách hãng sản xuất
        public DataTable LayDSHangSX()
        {
            try
            {
                return sanphamDL.LayDSHangSX();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thêm hãng sx
        public bool ThemHangSX(string tenHang, string quocGia, out string thongBao)
        {
            try
            {
                if (sanphamDL.KiemTraHangSX(tenHang))
                {
                    thongBao = "Hãng sản xuất này có nhiều sản phẩm, không thể xóa!!";
                    return false;
                }
                else
                {

                    bool kq = sanphamDL.ThemHangSX(tenHang,quocGia);
                    if (kq)
                    {
                        thongBao = "Thêm thành công!!!";
                        return true;
                    }
                    else
                    {
                        thongBao = " Thất bại!";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Cập nhật hãng SX
        public bool CapNhatHangSX(int maHang, string tenHang, string quocGia, out string thongBao)
        {
            try
            {
                string ten = sanphamDL.LayHangSX_maHang(maHang);
                if(ten.Equals(tenHang) == false)
                {
                    if (sanphamDL.KiemTraHangSX(tenHang))
                    {
                        thongBao = "Hãng sản xuất này đã tồn tại trong hệ thống.";
                        return false;
                    }
                }

                bool kq = sanphamDL.CapNhatHangSX(maHang, tenHang, quocGia);
                if (kq)
                {
                    thongBao = "Cập nhật thành công!!!";
                    return true;
                }
                else
                {
                    thongBao = " Cập nhật thất bại!";
                    return false;
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //Xóa hãng sản xuất
        public bool XoaHangSX(int maHang, out string thongBao)
        {
            try
            {
                if (sanphamDL.KiemTra_XoaHangSX(maHang))
                {
                    thongBao = "Hãng sản xuất này có nhiều sản phẩm, không thể xóa!!!";
                    return false;
                }
                else
                {
                    bool kq = sanphamDL.XoaHangSX(maHang);
                    if (kq)
                    {
                        thongBao = "Xóa thành công!!!";
                        return true;
                    }
                    else
                    {
                        thongBao = "Thất bại!";
                        return false;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }




    }
}
