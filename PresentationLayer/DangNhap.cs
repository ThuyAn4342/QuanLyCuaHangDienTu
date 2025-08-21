using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessLayer;
using TransferObject;
using System.Security.Cryptography;

namespace PresentationLayer
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        TaiKhoanBL taikhoanBL = new TaiKhoanBL();

        //Hàm băm mật khẩu
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Chuyển mảng byte thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public void ResetDangNhap()
        {
            txtTenDN.Clear();
            txtMatKhau.Clear();
            txtTenDN.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDN.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                TaiKhoanTO ac = taikhoanBL.DangNhap(txtTenDN.Text.Trim(), HashPassword(txtMatKhau.Text.Trim()));

                if (ac != null)
                {
                    if (ac.chucNang.Equals("ADMIN")) // Chỉ cho phép quản trị viên đăng nhập
                    {
                        // Gán tài khoản vào tài khoản hiện tại
                        TaiKhoanHienTai.TaiKhoan = ac;
                        TaiKhoanHienTai.thoiGianDN = DateTime.Now.ToString();

                        this.DialogResult = DialogResult.OK;
                        this.Close(); // login thành công
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản của bạn không có quyền truy cập hệ thống.", "Phân quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ResetDangNhap();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng! Vui lòng kiểm tra lại!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetDangNhap();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            FrmQuenMatKhau FrmQuenMK = new FrmQuenMatKhau();
            FrmQuenMK.ShowDialog();
            this.Show();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.Text = "1";
            txtTenDN.Text = "thuyan";
        }
    }
}
