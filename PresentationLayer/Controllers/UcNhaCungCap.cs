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

namespace PresentationLayer.Controllers
{
    public partial class UcNhaCungCap : UserControl
    {
        public UcNhaCungCap()
        {
            InitializeComponent();
        }

        NhaCungCapBL nhacungcapBL = new NhaCungCapBL();
        private void Reset_NCC()
        {
            dgvNCC.DataSource = nhacungcapBL.LayDS_NCC();
            txtDiaChi_NCC.Clear();
            txtEmail_NCC.Clear();
            txtSoDT_NCC.Clear();
            txtTenNCC.Clear();
        }

        private void UcNhaCungCap_Load(object sender, EventArgs e)
        {
            Reset_NCC();
        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == dgvNCC.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var maNCC = dgvNCC.Rows[e.RowIndex].Cells["maNCC"].Value;
                if (maNCC != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa Nhà cung cấp này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        string thongBao;
                        if ( nhacungcapBL.Xoa_NCC(Convert.ToInt32(maNCC),out thongBao))
                        {
                            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset_NCC();
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

        private void dgvNCC_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNCC.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox tương ứng
                txtTenNCC.Text = row.Cells["tenNCC"].Value.ToString();
                txtSoDT_NCC.Text = row.Cells["soDT"].Value.ToString();
                txtEmail_NCC.Text = row.Cells["email"].Value.ToString();
                txtDiaChi_NCC.Text = row.Cells["diaChi"].Value.ToString();
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            string tenNCC, soDT, email, diaChi, thongBao;

            if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtSoDT_NCC.Text) || string.IsNullOrEmpty(txtEmail_NCC.Text)
                || string.IsNullOrEmpty(txtDiaChi_NCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tenNCC = txtTenNCC.Text;
            soDT = txtSoDT_NCC.Text;
            email=txtEmail_NCC.Text;
            diaChi = txtDiaChi_NCC.Text;

            NhaCungCapTO n = new NhaCungCapTO(0,tenNCC,soDT,email,diaChi);

            try
            {
                if(nhacungcapBL.ThemNhaCungCap(n,out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_NCC();
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

        private void btnCapNhatNCC_Click(object sender, EventArgs e)
        {
            string tenNCC, soDT, email, diaChi, thongBao;
            int maNCC;

            if (string.IsNullOrEmpty(txtTenNCC.Text) || string.IsNullOrEmpty(txtSoDT_NCC.Text) || string.IsNullOrEmpty(txtEmail_NCC.Text)
                || string.IsNullOrEmpty(txtDiaChi_NCC.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tenNCC = txtTenNCC.Text;
            soDT = txtSoDT_NCC.Text;
            email = txtEmail_NCC.Text;
            diaChi = txtDiaChi_NCC.Text;
            maNCC = Convert.ToInt32(dgvNCC.CurrentRow.Cells["maNCC"].Value);

            NhaCungCapTO n = new NhaCungCapTO(maNCC, tenNCC, soDT, email, diaChi);

            try
            {
                if (nhacungcapBL.CapNhatCungCap(n, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_NCC();
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

        private void btnHuyThemNCC_Click(object sender, EventArgs e)
        {
            txtDiaChi_NCC.Clear();
            txtEmail_NCC.Clear();
            txtSoDT_NCC.Clear();
            txtTenNCC.Clear();
        }

        private void txtSoDT_NCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
