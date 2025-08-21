using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer.Controllers;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer
{
    public partial class QuanLyCuaHangDienTu : Form
    {
        public QuanLyCuaHangDienTu()
        {
            InitializeComponent();
        }

        NhanVienBL nhanvienBL = new NhanVienBL();

        private void LoadController(UserControl us)
        {
            pnMain.Controls.Clear();
            us.Dock = DockStyle.Fill;
            pnMain.Controls.Add(us);

            
        }

      
        //Tạo hàm xử lý hoạt động khi các nút được click
        private void ActivateButton(Button clickedButton)
        {
            // Reset tất cả nút trước
            foreach (Control ctrl in pnDieuKhien.Controls)
            {
                if (ctrl is Button btn && btn != clickedButton)
                {
                    btn.BackColor = Color.AliceBlue;      
                    btn.ForeColor = Color.DarkBlue;      
                }
                // Thiết lập nút đang chọn
                clickedButton.BackColor = Color.LightBlue;  // màu nổi bật
                clickedButton.ForeColor = Color.DarkBlue;

            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSanPham);
            LoadController(new UcSanPham());
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            ActivateButton(btnKhuyenMai);
            LoadController(new UcKhuyenMai());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ActivateButton(btnHoaDon);
            LoadController(new UcHoaDon());
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNhapKho);
            LoadController(new UcNhapKho());
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNCC);
            LoadController(new UcNhaCungCap());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ActivateButton(btnKhachHang);
            LoadController(new UcKhachHang());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ActivateButton(btnNhanVien);
            LoadController(new UcNhanVien());
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(btnTaiKhoan);
            LoadController(new UcTaiKhoan());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LoadController(new UcHome());
        }
       

        private void QuanLyCuaHangDienTu_Load(object sender, EventArgs e)
        {
            DangNhap dangnhap = new DangNhap();
            this.Hide();

            DialogResult result = dangnhap.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
                lbChucVu.Text = nhanvienBL.LayChucVu_maNV(TaiKhoanHienTai.TaiKhoan.maNV);
                lbName.Text = nhanvienBL.LayTenNV_maNV(TaiKhoanHienTai.TaiKhoan.maNV);

            }
            else
            {
                Application.Exit();
            }

            ActivateButton(btnHome);
            LoadController(new UcHome());

            
        }

        private void btnThongKe_BC_Click(object sender, EventArgs e)
        {
            ActivateButton(btnThongKe_BC);
            LoadController(new UcThongKe_BaoCao());
        }

        private void thôngTinNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mở form thông tin người dùng
            FrThongTinND f = new FrThongTinND();
            f.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Xác nhận trước khi đăng xuất
            DialogResult resultDangXuat = MessageBox.Show($"Bạn có chắc muốn đăng xuất không?", "Xác nhận đăng xuất",
                                                  MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (resultDangXuat != DialogResult.OK)
            {
                return; // Người dùng chọn Cancel
            }

            // Xóa người dùng hiện tại
            TaiKhoanHienTai.TaiKhoan = null;
            TaiKhoanHienTai.thoiGianDN = null;

            DangNhap dangNhap = new DangNhap();
            this.Hide();

            DialogResult result = dangNhap.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
                lbChucVu.Text = nhanvienBL.LayChucVu_maNV(TaiKhoanHienTai.TaiKhoan.maNV);
                lbName.Text = nhanvienBL.LayTenNV_maNV(TaiKhoanHienTai.TaiKhoan.maNV);

                ActivateButton(btnHome);

            }
            else
            {
                Application.Exit();
            }
            LoadController(new UcHome());
        }
    }
}
