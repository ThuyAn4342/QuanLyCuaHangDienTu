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
    public class SanPhamDL : DataProvider
    {
        // Lấy danh sách sản phẩm
        public DataTable LayDS_SanPham()
        {
            string sql = "SELECT * FROM SanPham";
            return MyExecuteReader(sql, CommandType.Text);
        }

        //Tìm kiếm sản phẩm theo mã SP
        public bool TimKiemMaSP(int maSP)
        {
            string sql = "SELECT COUNT(*) FROM SanPham WHERE maSP = @maSP";
            SqlParameter[] param = { new SqlParameter("@maSP", maSP) };
            object sl = MyExecuteScalar(sql, CommandType.Text, param);
            return Convert.ToInt32(sl) > 0;
        }

       

        // Lấy danh sách sản phẩm theo mã sản phẩm
        public DataTable LayDS_SanPham_MaSP(int maSP)
        {
            string sql = "SELECT * FROM SanPham WHERE maSP = @maSP";
            SqlParameter[] param = { new SqlParameter("@maSP", maSP) };
            return MyExecuteReader(sql, CommandType.Text, param);
        }

       
        // Lấy danh sách sản phẩm theo loại sản phẩm
        public DataTable LayDS_SanPham_LoaiSP(int maLoai)
        {
            string sql = "SELECT * FROM SanPham WHERE maLoai = @maLoai";
            SqlParameter[] param = { new SqlParameter("@maLoai", maLoai) };
            return MyExecuteReader(sql, CommandType.Text, param);
        }

        // Lấy danh sách sản phẩm theo hãng sản phẩm
        public DataTable LayDS_SanPham_HangSP(int maHang)
        {
            string sql = "SELECT * FROM SanPham WHERE maHang = @maHang";
            SqlParameter[] param = { new SqlParameter("@maHang", maHang) };
            return MyExecuteReader(sql, CommandType.Text, param);
        }

        // Lấy danh sách sản phẩm theo loại và hãng sản phẩm
        public DataTable LayDSSP_LoaiSP_HangSX(int maLoai, int maHang)
        {
            string sql = "SELECT * FROM SanPham WHERE maHang = @maHang AND maLoai = @maLoai";
            SqlParameter[] param = { new SqlParameter("@maHang", maHang), new SqlParameter("@maLoai", maLoai) };
            return MyExecuteReader(sql, CommandType.Text, param);
        }

        //Kiểm tra sản phẩm đã tồn tại trước đó chưa
        public bool KiemTraSanPham(string tenSP)
        {
            string sql = "SELECT COUNT(*) FROM SanPham WHERE tenSP = @tenSP";
            SqlParameter[] param = { new SqlParameter("@tenSP", tenSP) };

            object sl = MyExecuteScalar(sql, CommandType.Text, param);
            return Convert.ToInt32(sl) > 0;
        }

        // Lấy tên sản phẩm qua mã SP
        public string LaySP_maSP(int maSP)
        {
            try
            {
                string sql = "SELECT tenSP FROM SanPham WHERE maSP = " + maSP;

                object tenSP = MyExecuteScalar(sql, CommandType.Text);
                return tenSP.ToString();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        // Thêm sản phẩm
        public bool ThemSanPham(SanPhamTO s)
        {
            string sql = "sp_ThemSanPham";
            SqlParameter[] param = {
                new SqlParameter("@tenSP", s.tenSP),
                new SqlParameter("@maLoai", s.maLoai),
                new SqlParameter("@maHang", s.maHang),
                new SqlParameter("@donGiaNhap", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = s.donGiaNhap
                    },
                new SqlParameter("@donGiaBan", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = s.donGiaBan
                    },
                new SqlParameter("@tonKho", s.tonKho),
                new SqlParameter("@maKM",s.maKM == 0 ? (object)DBNull.Value : s.maKM),
                new SqlParameter("@trangThai", s.trangThai)
            };
            return MyExecuteNonQuery(sql, CommandType.StoredProcedure, param) > 0;
        }

        //Cập nhật sản phẩm
        public bool CapNhatSP (SanPhamTO s)
        {
            string sql = "sp_CapNhatSP";

            SqlParameter[] param =
            {
                new SqlParameter("@maSP", s.maSP),
                new SqlParameter("@tenSP", s.tenSP),
                new SqlParameter("@maLoai", s.maLoai),
                new SqlParameter("@maHang", s.maHang),
               new SqlParameter("@donGiaNhap", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = s.donGiaNhap
                    },
                new SqlParameter("@donGiaBan", SqlDbType.Decimal)
                    {
                        Precision = 18,
                        Scale = 2,
                        Value = s.donGiaBan
                    },
                new SqlParameter("@tonKho", s.tonKho),
                new SqlParameter("@maKM",s.maKM == 0 ? (object)DBNull.Value : s.maKM),
                new SqlParameter("@trangThai", s.trangThai)
            };

            return MyExecuteNonQuery (sql, CommandType.StoredProcedure, param) > 0;

        }

        // Kiểm tra sản phẩm đã từng được bán chưa
        public bool KiemTraTruocKhiXoaSP(int maSP)
        {
            string sql = "sp_KTXoaSP";
            SqlParameter[] param = { new SqlParameter("@maSP", maSP)};
            object kq = MyExecuteScalar(sql, CommandType.StoredProcedure, param);
            return Convert.ToInt32(kq) > 0;
        }

        // Xóa sản phẩm
        public bool XoaSanPham(int maSP)
        {
            try
            {
                string sql = "DELETE FROM SanPham WHERE maSP = @maSP";
                SqlParameter[] param = { new SqlParameter("@maSP", maSP) };
                return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
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
                string sql = "sp_LayTyLeGiam";
                SqlParameter[] param = { new SqlParameter("@maSP", maSP) };
                return Convert.ToDecimal(MyExecuteScalar(sql, CommandType.StoredProcedure, param));
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        //---------- LOẠI SẢN PHẨM ----------

        // Lấy danh sách loại sản phẩm
        public DataTable LayDSLoaiSP()
        {
            string sql = "SELECT * FROM LoaiSanPham";
            return MyExecuteReader(sql, CommandType.Text);
        }

        // Kiểm tra loại sản phẩm đã tồn tại trước đó chưa?
        public bool KiemTraLoaiSP(string tenLoai)
        {
            string sql = "SELECT COUNT(*) FROM LoaiSanPham WHERE tenLoai = @tenLoai";
            SqlParameter[] param = { new SqlParameter("@tenLoai", tenLoai) };
            return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text, param)) > 0;
        }

        // Thêm loại sản phẩm
        public bool ThemLoaiSP(string tenLoai)
        {
            string sql = "INSERT INTO LoaiSanPham(tenLoai) VALUES (@TenLoai)";
            SqlParameter[] param = { new SqlParameter("@tenLoai", tenLoai) };
            return MyExecuteNonQuery(sql,CommandType.Text,param) > 0;
        }

        // Cập nhật loại sản phẩm
        public bool CapNhatLoaiSP(int maLoai, string tenLoai)
        {
            string sql = "UPDATE LoaiSanPham SET tenLoai = '" + tenLoai +"' WHERE maLoai = "+ maLoai ;

            return MyExecuteNonQuery(sql, CommandType.Text) > 0;
        }

        //Kiểm tra loại sp trước khi xóa
        public bool KiemTra_XoaLoaiSP(int maLoai)
        {
            string sql = "SELECT COUNT(*) FROM SanPham WHERE maLoai = " + maLoai;
            return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;
        }
        //Xóa loại sản phẩm
        public bool XoaLoaiSP(int maLoai)
        {
            string sql = "DELETE FROM LoaiSanPham WHERE maLoai = " + maLoai;
            return MyExecuteNonQuery(sql,CommandType.Text) > 0;
        }


        //---------- HÃNG SẢN XUẤT ----------
        //Lấy danh sách hãng sản xuất
        public DataTable LayDSHangSX()
        {
            string sql = "SELECT * FROM HangSanXuat";
            return MyExecuteReader(sql, CommandType.Text);
        }

        // Kiểm tra loại sản phẩm đã tồn tại trước đó chưa?
        public bool KiemTraHangSX(string tenHang)
        {
            string sql = "SELECT COUNT(*) FROM HangSanXuat WHERE tenHang = @tenHang";
            SqlParameter[] param = { new SqlParameter("@tenHang", tenHang) };
            return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text, param)) > 0;
        }

        // Thêm hãng sản xuất
        public bool ThemHangSX(string tenHang, string quocGia)
        {
            string sql = "INSERT INTO HangSanXuat(tenHang, quocGia) VALUES (@TenHang, @quocGia)";
            SqlParameter[] param = { new SqlParameter("@tenHang", tenHang), new SqlParameter("@quocGia", quocGia) };
            return MyExecuteNonQuery(sql, CommandType.Text, param) > 0;
        }

        // Lấy tên hãng SP qua mã hãng SX
        public string LayHangSX_maHang(int maHang)
        {
            string sql = "SELECT tenHang FROM HangSanXuat WHERE maHang = " + maHang;

            object tenHang = MyExecuteScalar(sql, CommandType.Text);
            return tenHang.ToString();
        }

        // Cập nhật hãng sản xuất
        public bool CapNhatHangSX(int maHang, string tenHang, string quocGia)
        {
            string sql = "sp_CapNhatHangSX";
            SqlParameter[] param = {new SqlParameter("@maHang", maHang),
                                    new SqlParameter("@tenhang", tenHang),
                                    new SqlParameter("@quocGia", quocGia)};

            return MyExecuteNonQuery(sql, CommandType.StoredProcedure,param) > 0;
        }

        //Kiểm tra hãng sx trước khi xóa
        public bool KiemTra_XoaHangSX(int maHang)
        {
            string sql = "SELECT COUNT(*) FROM SanPham WHERE maHang = " + maHang;
            return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text)) > 0;
        }
        //Xóa hãng sx
        public bool XoaHangSX(int maHang)
        {
            string sql = "DELETE FROM HangSanXuat WHERE maHang = " + maHang;
            return MyExecuteNonQuery(sql, CommandType.Text) > 0;
        }

        
    }
}
