using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentationLayer.QuenMatKhau;
using BusinessLayer;
using TransferObject;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace PresentationLayer
{
    public partial class FrmQuenMatKhau : Form
    {
        public FrmQuenMatKhau()
        {
            InitializeComponent();
        }

        public void LoadController(UserControl us)
        {
            pnMain.Controls.Clear();
            us.Dock = DockStyle.Fill;
            pnMain.Controls.Add(us);
            
        }

        public string TieuDe
        {
            get { return lbTieuDe.Text; }
            set { lbTieuDe.Text = value; }
        }


        private string TaoMaNgauNhien()
        {
            // Tạo mã xác nhận ngẫu nhiên:
            return new Random().Next(1000, 9999).ToString();
        }

        
        public string MaXacNhanDaGui { get; set; }
        TaiKhoanBL taikhoanBL = new TaiKhoanBL();
        public string mail;
        public string tenDangNhap;
        
        private async void btnGuiMaXN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDN.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDN.Focus();
                return;
            }

            tenDangNhap = txtTenDN.Text;
            if (!taikhoanBL.KiemTraTaiKhoan(tenDangNhap))
            {
                MessageBox.Show("Tên đăng nhập không tồn tại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenDN.Focus();
                return;
            }

            try
            {
                TaiKhoanTO user = taikhoanBL.LayTaiKhoan_tenDangNhap(tenDangNhap);
                mail = user.mail;

                string ma = TaoMaNgauNhien(); // Tạo mã xác nhận

                bool result = false;

                try
                {
                    // Gửi mail trong Task để không block UI
                    result = await Task.Run(() => GuiMaXacNhan(ma, mail));
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                 

                if (result)
                {
                    MaXacNhanDaGui = ma;
                    LoadController(new ucMaXacNhan()); // Hiển thị form nhập mã xác nhận
                }
                else
                {
                    MessageBox.Show("Không gửi được mã xác nhận.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool GuiMaXacNhan(string maXacNhan, string usermail)
        {
            try
            {
                string fromAdd = "phamthithuyan.k55ltk@gmail.com";
                string fromPassword = "wwnm rtct wnit igql";  // Mật khẩu ứng dụng (App password từ Google)

                string toAdd = usermail; // Lấy email người dùng
                string subject = "Mã xác nhận đặt lại mật khẩu";
                string body = $"Xin chào,\n\nMã xác nhận để đặt lại mật khẩu của bạn là: {maXacNhan}\n\nVui lòng không chia sẻ mã này với bất kỳ ai.\n\nTrân trọng.";

                using (MailMessage mail = new MailMessage(fromAdd, toAdd, subject, body))
                {
                    using (MailMessage message = new MailMessage(fromAdd, toAdd))
                    {
                        message.Subject = subject;
                        message.Body = body;
                        message.IsBodyHtml = false;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential(fromAdd, "kgwp ihub jykp mzwe");
                            smtp.EnableSsl = true;

                            smtp.Send(message);
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
                return false;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
