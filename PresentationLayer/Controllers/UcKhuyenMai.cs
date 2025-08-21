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
    public partial class UcKhuyenMai : UserControl
    {
        public UcKhuyenMai()
        {
            InitializeComponent();
        }

        KhuyenMaiBL khuyenmaiBL = new KhuyenMaiBL();

        private void Reset_KhuyenMai()
        {
            dgvKhuyenMai.DataSource = khuyenmaiBL.LayDSKhuyenMai();

            txtTenKM.Clear();
            txtGiamGia.Clear();
            txtGhiChu.Clear();

            cbLoaiKM.SelectedIndex = 0;

            dtNgayBatDau.Value = DateTime.Today;
            dtNgayKetThuc.Value = DateTime.Today;
        }

        private void UcKhuyenMai_Load(object sender, EventArgs e)
        {
            Reset_KhuyenMai();
        }

        private void dgvKhuyenMai_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKhuyenMai.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox, datetime tương ứng
                txtTenKM.Text = row.Cells["tenKM"].Value.ToString();
                cbLoaiKM.Text = row.Cells["loaiKM"].Value.ToString();
                txtGiamGia.Text = row.Cells["tyLeGiam"].Value.ToString();
                txtGhiChu.Text = row.Cells["ghiChu"].Value.ToString();
                dtNgayBatDau.Value = Convert.ToDateTime(row.Cells["ngayBatDau"].Value);
                dtNgayKetThuc.Value = Convert.ToDateTime(row.Cells["ngayKetThuc"].Value);

            }
        }

        private void dgvKhuyenMai_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvKhuyenMai.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var maKM = dgvKhuyenMai.Rows[e.RowIndex].Cells["maKM"].Value;
                string thongBao;
                if (maKM != null)
                {
                    
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khuyến mãi này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (khuyenmaiBL.XoaKhuyenMai(Convert.ToInt32(maKM),out thongBao))
                        {
                            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset_KhuyenMai();
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

        private void btnThemKM_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenKM.Text) || string.IsNullOrEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Tên khuyến mãi, tỷ lệ giảm giá KHÔNG được phép để trống!!!", 
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string thongBao;

            try
            {
                KhuyenMaiTO km = new KhuyenMaiTO(0, txtTenKM.Text, float.Parse(txtGiamGia.Text), cbLoaiKM.Text,
               Convert.ToDateTime(dtNgayBatDau.Value), Convert.ToDateTime(dtNgayKetThuc.Value), txtGhiChu.Text);

                if(khuyenmaiBL.ThemKhuyenMai(km,out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_KhuyenMai();
                }    
                else
                {
                    MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }    
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhatKM_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKM.Text) || string.IsNullOrEmpty(txtGiamGia.Text))
            {
                MessageBox.Show("Tên khuyến mãi, tỷ lệ giảm giá KHÔNG được phép để trống!!!",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string thongBao;

            try
            {
                int maKM = Convert.ToInt32(dgvKhuyenMai.CurrentRow.Cells["maKM"].Value);
                KhuyenMaiTO km = new KhuyenMaiTO(maKM, txtTenKM.Text, float.Parse(txtGiamGia.Text), cbLoaiKM.Text,
               Convert.ToDateTime(dtNgayBatDau.Value), Convert.ToDateTime(dtNgayKetThuc.Value), txtGhiChu.Text);

                if (khuyenmaiBL.CapNhatKhuyenMai(km, out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Reset_KhuyenMai();
                }
                else
                {
                    MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuyThemKM_Click(object sender, EventArgs e)
        {
            txtTenKM.Clear();
            txtGiamGia.Clear();
            txtGhiChu.Clear();

            cbLoaiKM.SelectedIndex = 0;

            dtNgayBatDau.Value = DateTime.Today;
            dtNgayKetThuc.Value = DateTime.Today;
        }

        private void txtGiamGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số, phím điều khiển và dấu phẩy `,`
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu phẩy
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void txtDieuKien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số, phím điều khiển và dấu phẩy `,`
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Chỉ cho phép một dấu phẩy
            if (e.KeyChar == ',' && (sender as TextBox).Text.Contains(","))
            {
                e.Handled = true;
            }
        }
    }
}
