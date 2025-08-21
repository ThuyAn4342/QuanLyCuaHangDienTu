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
using System.Security.Cryptography;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer.Controllers
{
    public partial class UcTaiKhoan : UserControl
    {
        public UcTaiKhoan()
        {
            InitializeComponent();
        }

        TaiKhoanBL taikhoanBL = new TaiKhoanBL();
        NhanVienBL nhanvienBL = new NhanVienBL();

        private void Reset_TaiKhoan()
        {
            dgvTaiKhoan.DataSource = taikhoanBL.LayDS_Taikhoan();
            txtMatKhau.Clear();
            txtTenDangNhap.Clear();
            txtMail.Clear();
            cbChucNang.SelectedIndex = 0;
            cbNV.SelectedIndex = -1;
        }

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

        private void UcTaiKhoan_Load(object sender, EventArgs e)
        {
            Reset_TaiKhoan();

            // Load combobox mã nhân viên
            cbNV.DataSource = nhanvienBL.LayDS_NhanVien() ;
            cbNV.DisplayMember = "maNV";
            cbNV.ValueMember = "maNV";
            cbNV.SelectedIndex = -1;
        }

        private void dgvTaiKhoan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvTaiKhoan.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var maNV = dgvTaiKhoan.Rows[e.RowIndex].Cells["maNV"].Value;
                if (maNV != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (taikhoanBL.XoaTaiKhoan(Convert.ToInt32(maNV)))
                        {
                            MessageBox.Show("Đã xóa tài khoản!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset_TaiKhoan();
                        }
                        else
                        {
                            MessageBox.Show("Thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                // Đảm bảo không click vào header
                if (e.RowIndex < 0) return;
            }
        }

        private void dgvTaiKhoan_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTaiKhoan.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox tương ứng
                txtTenDangNhap.Text = row.Cells["tenDangNhap"].Value.ToString();
                txtMatKhau.Text = row.Cells["matKhau"].Value.ToString();
                txtMail.Text = row.Cells["mail"].Value.ToString();
                cbChucNang.Text = row.Cells["chucNang"].Value.ToString();
                cbNV.SelectedValue = row.Cells["maNV"].Value;
            }
        }

        private void btnThemTK_Click(object sender, EventArgs e)
        {
            string tenDangNhap, matKhau, chucNang, thongBao, mail;
            int maNV;

            if(string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtMail.Text) || cbNV.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            maNV = Convert.ToInt32(cbNV.SelectedValue);
            tenDangNhap = txtTenDangNhap.Text;
            matKhau = HashPassword(txtMatKhau.Text);
            chucNang = cbChucNang.Text;
            mail = txtMail.Text;

            TaiKhoanTO ac = new TaiKhoanTO(maNV,tenDangNhap, matKhau, chucNang,mail);

            if(taikhoanBL.ThemTaiKhoan(ac, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset_TaiKhoan();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }    
        }

        private void btnCapNhatTK_Click(object sender, EventArgs e)
        {
            string tenDangNhap, matKhau, chucNang,mail, thongBao;

            if (dgvTaiKhoan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(txtMatKhau.Text) || string.IsNullOrEmpty(txtMail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maNV = Convert.ToInt32(dgvTaiKhoan.CurrentRow.Cells["maNV"].Value);
            string matKhau_Old = dgvTaiKhoan.CurrentRow.Cells["matKhau"].Value.ToString(); // Lấy mật khẩu trước khi cập nhật
            tenDangNhap = txtTenDangNhap.Text;
            matKhau = txtMatKhau.Text; // Mật khẩu sau khi người dùng cập nhật
            chucNang = cbChucNang.Text;
            mail = txtMail.Text;

            if(matKhau_Old.Equals(matKhau) == false) // Kiểm tra mật khẩu trước đó và sau khi sửa đổi có giống nhau không?
            {
                matKhau = HashPassword(matKhau);
            }

            TaiKhoanTO ac = new TaiKhoanTO(maNV, tenDangNhap, matKhau, chucNang,mail);

            if (taikhoanBL.CapNhatTaiKhoan(ac, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset_TaiKhoan();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuyThemTK_Click(object sender, EventArgs e)
        {
            txtMatKhau.Clear();
            txtTenDangNhap.Clear();
            txtMail.Clear();
            cbChucNang.SelectedIndex = 0;
            cbNV.SelectedIndex = -1;
        }
    }
}
