using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace PresentationLayer.QuenMatKhau
{
    public partial class ucThayDoiMatKhau : UserControl
    {
        public ucThayDoiMatKhau()
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


        private void btnLuu_Click(object sender, EventArgs e)
        {
            string pass = txtMatKhauMoi.Text;
            string passXN = txtNhapLaiMK.Text;
            var parentForm = this.FindForm() as FrmQuenMatKhau;

            if (pass != passXN)
            {
                MessageBox.Show("Mật khẩu không trùng khớp! Vui lòng kiểm tra lại!!!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNhapLaiMK.Clear();
                txtNhapLaiMK.Focus();
            }
            else
            {
                try
                {
                    if (taikhoanBL.DoiMatKhau(parentForm.tenDangNhap, HashPassword(pass)))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        parentForm.Close();
                    }
                    else
                    {
                        MessageBox.Show("Đổi mật khẩu thất bại!!!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as FrmQuenMatKhau;
            parentForm.Close();
        }
    }
}
