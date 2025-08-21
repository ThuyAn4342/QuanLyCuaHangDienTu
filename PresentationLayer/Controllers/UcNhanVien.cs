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

namespace PresentationLayer.Controllers
{
    public partial class UcNhanVien : UserControl
    {
        public UcNhanVien()
        {
            InitializeComponent();
        }

        NhanVienBL nhanvienBL = new NhanVienBL();

        private void Reset_NhanVien()
        {
            dgvNhanVien.DataSource = nhanvienBL.LayDS_NhanVien();

            cbChucVu.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;
            cbTinhTrang.SelectedIndex = 0;

            txtHoNV.Clear();
            txtTenNV.Clear();
            txtSoDT.Clear();
            txtMaNV.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTenNV_TK.Clear();
            dtNgaySinh.Value = DateTime.Today;
        }

        private void UcNhanVien_Load(object sender, EventArgs e)
        {
            Reset_NhanVien();
        }

        private void btnTimKiemNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                if(string.IsNullOrEmpty(txtTenNV_TK.Text))
                {
                    MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                } 
                else
                {
                    string tenNV = txtTenNV_TK.Text.Trim();
                    if (tenNV.Contains(" "))
                    {
                        MessageBox.Show("Tên nhân viên chỉ được là một từ, không chứa khoảng trắng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    try
                    {
                        DataTable dt = nhanvienBL.TimKiem_tenNV(tenNV);
                        if (dt != null)
                        {
                            dgvNhanVien.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên này trong hệ thống!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (SqlException ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }    
            }
            else
            {
                try
                {
                    DataTable dt = nhanvienBL.TimKiem_maNV(Convert.ToInt32(txtMaNV.Text));
                    if (dt != null)
                    {
                        dgvNhanVien.DataSource = dt;
                        txtTenNV_TK.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên này trong hệ thống!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }    
        }

        private void dgvNhanVien_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox, combobox tương ứng
                txtHoNV.Text = row.Cells["hoNV"].Value.ToString();
                txtTenNV.Text = row.Cells["tenNV"].Value.ToString();
                txtDiaChi.Text = row.Cells["diaChi"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtSoDT.Text = row.Cells["soDT"].Value.ToString();
                cbChucVu.Text = row.Cells["chucVu"].Value.ToString();
                cbGioiTinh.Text = row.Cells["gioiTinh"].Value.ToString();
                cbTinhTrang.Text = row.Cells["tinhTrang"].Value.ToString();
                dtNgaySinh.Value = Convert.ToDateTime(row.Cells["ngaySinh"].Value);
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvNhanVien.Columns["delete"].Index && e.RowIndex >= 0)
            {
                string thongBao;
                var maNV = dgvNhanVien.Rows[e.RowIndex].Cells["maNV"].Value;
                if (maNV != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (nhanvienBL.XoaNhanVien(Convert.ToInt32(maNV),out thongBao))
                        {
                            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset_NhanVien();
                        }
                        else
                        {
                            MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtHoNV.Text) || string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtSoDT.Text))
            {
                MessageBox.Show("Họ tên và số điện thoại của nhân viên KHÔNG được để trống!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            NhanVienTO nv = new NhanVienTO(0, txtHoNV.Text, txtTenNV.Text, dtNgaySinh.Value, cbGioiTinh.Text, cbChucVu.Text, txtSoDT.Text, txtEmail.Text,
                txtDiaChi.Text, cbTinhTrang.Text);
            try
            {
                if(nhanvienBL.ThemNhanVien(nv))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_NhanVien();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);


            }
        }

        private void btnCapNhatNV_Click(object sender, EventArgs e)
        {
            // Kiểm tra dòng được chọn
            if (dgvNhanVien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtHoNV.Text) || string.IsNullOrEmpty(txtTenNV.Text) || string.IsNullOrEmpty(txtSoDT.Text))
            {
                MessageBox.Show("Họ tên và số điện thoại của nhân viên KHÔNG được để trống!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maNV = Convert.ToInt32(dgvNhanVien.CurrentRow.Cells["maNV"].Value);

            NhanVienTO nv = new NhanVienTO(maNV, txtHoNV.Text, txtTenNV.Text, dtNgaySinh.Value, cbGioiTinh.Text, cbChucVu.Text, txtSoDT.Text, txtEmail.Text,
                txtDiaChi.Text, cbTinhTrang.Text);
            try
            {
                if (nhanvienBL.CapNhatNhanVien(nv))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_NhanVien();
                }
                else
                {
                    MessageBox.Show("Thất bại!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnHuyThemNV_Click(object sender, EventArgs e)
        {
            cbChucVu.SelectedIndex = 0;
            cbGioiTinh.SelectedIndex = 0;
            cbTinhTrang.SelectedIndex = 0;

            txtHoNV.Clear();
            txtTenNV.Clear();
            txtSoDT.Clear();
            txtMaNV.Clear();
            txtEmail.Clear();
            txtDiaChi.Clear();
            txtTenNV_TK.Clear();
            dtNgaySinh.Value = DateTime.Today;
        }

        private void txtMaNV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenNV_TK_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Không cho nhập dấu cách
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự space
            }
        }
    }
}
