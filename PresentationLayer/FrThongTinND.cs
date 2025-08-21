using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer
{
    public partial class FrThongTinND : Form
    {
        public FrThongTinND()
        {
            InitializeComponent();
        }

        TaiKhoanBL taikhoanBL = new TaiKhoanBL();
        NhanVienBL nhanvienBL = new NhanVienBL();

        private void Reset_ThongTinND()
        {
            txtHoTen.Text = nhanvienBL.LayTenNV_maNV(TaiKhoanHienTai.TaiKhoan.maNV);
            txtTenDN.Text = TaiKhoanHienTai.TaiKhoan.tenDangNhap;
            txtMatKhau.Text = TaiKhoanHienTai.TaiKhoan.matKhau;
            txtMail.Text = TaiKhoanHienTai.TaiKhoan.mail;
            cbChucNang.Text = TaiKhoanHienTai.TaiKhoan.chucNang;

            txtMatKhau.Enabled = false;
            cbChucNang.Enabled = false;
        }

        private void FrThongTinND_Load(object sender, EventArgs e)
        {
            Reset_ThongTinND();
        }

        private void btnCapNhatTT_Click(object sender, EventArgs e)
        {
            try
            {
                string tenDangNhap, matKhau, chucNang, mail, thongBao;

                if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtMail.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maNV = TaiKhoanHienTai.TaiKhoan.maNV;
                tenDangNhap = txtTenDN.Text;
                matKhau = txtMatKhau.Text;
                chucNang = cbChucNang.Text;
                mail = txtMail.Text;

                TaiKhoanTO ac = new TaiKhoanTO(maNV, tenDangNhap, matKhau, chucNang, mail);

                if (taikhoanBL.CapNhatTaiKhoan(ac, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TaiKhoanHienTai.TaiKhoan = ac;
                    Reset_ThongTinND();
                }
                else
                {
                    MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void btnHuyThaoTac_Click(object sender, EventArgs e)
        {
            Reset_ThongTinND();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmQuenMatKhau FrmQuenMK = new FrmQuenMatKhau();
            FrmQuenMK.Text = "Thay đổi mật khẩu";
            FrmQuenMK.TieuDe = "Thay đổi mật khẩu";
            FrmQuenMK.ShowDialog();
            this.Show();
        }
    }
}
