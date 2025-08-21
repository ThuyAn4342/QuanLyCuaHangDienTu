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
    public partial class UcKhachHang : UserControl
    {
        public UcKhachHang()
        {
            InitializeComponent();
        }

        KhachHangBL khachhangBL = new KhachHangBL();

        private void Reset_KhachHang()
        {
            dgvKhachHang.DataSource = khachhangBL.LayDS_KhachHang();
            txtTenKH.Clear();
            txtHoKH.Clear();
            txtSoDT_KH.Clear();
            txtEmail_KH.Clear();
            txtDiaChi_KH.Clear();
            txtSĐT_TK.Clear();
            txtTenKH_TK.Clear();
            cbHangKH.SelectedIndex = 1;

        }

        private void UcKhachHang_Load(object sender, EventArgs e)
        {
            
            //Load combobox hạng khách hàng
            cbHangKH.DataSource = khachhangBL.LayDS_HangKH();
            cbHangKH.DisplayMember = "maHangKH";
            cbHangKH.ValueMember = "maHangKH";
           
            Reset_KhachHang();
        }

        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtSĐT_TK.Text))
                {
                    if(string.IsNullOrEmpty(txtTenKH_TK.Text))
                    {
                        MessageBox.Show("Vui lòng nhập thông tin để tìm kiếm!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    } 
                    else
                    {
                        string tenKH = txtTenKH_TK.Text.Trim();
                        if (tenKH.Contains(" "))
                        {
                            MessageBox.Show("Tên khách hàng chỉ được là một từ, không chứa khoảng trắng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        try
                        {
                            DataTable dt = khachhangBL.TimKiem_tenKH(tenKH);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                dgvKhachHang.DataSource = dt;
                            }
                            else
                            {
                                MessageBox.Show("Khách hàng này KHÔNG có trong hệ thống!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        DataTable dt = khachhangBL.TimKiem_soDT(txtSĐT_TK.Text);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            dgvKhachHang.DataSource = dt;
                            txtTenKH_TK.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Khách hàng này KHÔNG có trong hệ thống!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (SqlException ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                }    
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvKhachHang.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var maKH = dgvKhachHang.Rows[e.RowIndex].Cells["maKH"].Value;
                if (maKH != null)
                {
                    if(Convert.ToInt32(maKH) == 1)
                    {
                        MessageBox.Show("Không thể xóa khách hàng mặc định này!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }    
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (khachhangBL.KT_XoaKH(Convert.ToInt32(maKH)))
                        {
                            DialogResult re = MessageBox.Show("Khách hàng này có quan hệ ràng buộc với nhiều đơn hàng. Bạn chắc chắc xóa???", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (re == DialogResult.Yes)
                            {
                                if (khachhangBL.XoaKhachHang(Convert.ToInt32(maKH)))
                                {
                                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Reset_KhachHang();
                                }
                                else
                                {
                                    MessageBox.Show("Thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            if (khachhangBL.XoaKhachHang(Convert.ToInt32(maKH)))
                            {
                                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Reset_KhachHang();
                            }
                            else
                            {
                                MessageBox.Show("Thất bại", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
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

        private void dgvKhachHang_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhachHang.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox, combobox tương ứng
                txtHoKH.Text = row.Cells["hoKH"].Value.ToString();
                txtTenKH.Text = row.Cells["tenKH"].Value.ToString();
                txtDiaChi_KH.Text = row.Cells["diaChi"].Value.ToString();
                txtEmail_KH.Text = row.Cells["email"].Value.ToString();
                txtSoDT_KH.Text = row.Cells["soDT"].Value.ToString();
                cbHangKH.SelectedValue = row.Cells["hangKH"].Value;
                
            }
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtHoKH.Text) || string.IsNullOrEmpty(txtTenKH.Text)|| string.IsNullOrEmpty(txtSoDT_KH.Text))
            {
                MessageBox.Show("Họ tên và số điện thoại của khách hàng KHÔNG được để trống!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            KhachHangTO k = new KhachHangTO(0, txtHoKH.Text, txtTenKH.Text, txtSoDT_KH.Text, txtEmail_KH.Text, txtDiaChi_KH.Text, cbHangKH.SelectedValue.ToString());

            try
            {
                if (khachhangBL.ThemKhachHang(k))
                {
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_KhachHang();
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

        private void btnCapNhatKH_Click(object sender, EventArgs e)
        {
            // Kiểm tra dòng được chọn
            if (dgvKhachHang.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtHoKH.Text) || string.IsNullOrEmpty(txtTenKH.Text) || string.IsNullOrEmpty(txtSoDT_KH.Text))
            {
                MessageBox.Show("Họ tên và số điện thoại của khách hàng KHÔNG được để trống!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int maKH = Convert.ToInt32(dgvKhachHang.CurrentRow.Cells["maKH"].Value);
            KhachHangTO k = new KhachHangTO(maKH, txtHoKH.Text, txtTenKH.Text, txtSoDT_KH.Text, txtEmail_KH.Text, txtDiaChi_KH.Text, cbHangKH.SelectedValue.ToString());

            try
            {
                if (khachhangBL.CapNhatKhachHang(k))
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_KhachHang();
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

        private void btnHuyThemKH_Click(object sender, EventArgs e)
        {
            txtTenKH.Clear();
            txtHoKH.Clear();
            txtSoDT_KH.Clear();
            txtEmail_KH.Clear();
            txtDiaChi_KH.Clear();
            txtSĐT_TK.Clear();
            txtTenKH_TK.Clear();
            cbHangKH.SelectedIndex = 1;
        }
    }
}
