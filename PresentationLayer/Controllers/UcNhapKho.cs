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
    public partial class UcNhapKho : UserControl
    {
        public UcNhapKho()
        {
            InitializeComponent();
        }

        SanPhamBL sanphamBL = new SanPhamBL();
        NhaCungCapBL nhacungcapBL = new NhaCungCapBL();
        NhapKhoBL nhapkhoBL = new NhapKhoBL();
        NhanVienBL nhanvienBL = new NhanVienBL();

        private void Reset_NhapKho()
        {
            cbNCC.SelectedIndex = 0;
            cbSanPham.SelectedIndex = -1;

            txtDonGia.Clear();
            txtGhiChu.Clear();
            txtSoLuong.Clear();

            dgvSanPham_NK.Rows.Clear();
        }

        private void UcNhapKho_Load(object sender, EventArgs e)
        {
            // Load dữ liệu cho combobox Nhà cung cấp
            cbNCC.DataSource = nhacungcapBL.LayDS_NCC();
            cbNCC.DisplayMember = "tenNCC";
            cbNCC.ValueMember = "maNCC";

            // Load dữ liệu cho combobox Sản phẩm
            cbSanPham.DataSource = sanphamBL.LayDS_SanPham();
            cbSanPham.DisplayMember = "maSP";
            cbSanPham.ValueMember = "maSP";

            dgvNhapKho.DataSource = nhapkhoBL.LayDS_NhapKho();
            lbMaNK.Text = "";
            lbTenNV.Text = "";
            lbTenNCC.Text = "";
            lbGhiChu.Text = "";

            Reset_NhapKho();
        }

        // ------------- TAB NHẬP KHO ---------------

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtDonGia.Text) || string.IsNullOrEmpty(txtDonGia.Text) || cbSanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin để thêm sản phẩm vào danh sách!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy mã sản phẩm được chọn từ ComboBox
            string maSP = cbSanPham.SelectedValue.ToString();

            // Duyệt qua các dòng để kiểm tra trùng mã
            foreach (DataGridViewRow row in dgvSanPham_NK.Rows)
            {

                if (row.Cells["maSP"].Value.ToString() == maSP)
                {
                    MessageBox.Show("Sản phẩm này đã có trong danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            dgvSanPham_NK.Rows.Add(cbSanPham.SelectedValue, txtSoLuong.Text, txtDonGia.Text);
        }

        
        private void dgvSanPham_NK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSanPham_NK.Columns["delete"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa dòng này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    dgvSanPham_NK.Rows.RemoveAt(e.RowIndex);  // Xóa dòng
                }
            }
            else
            {
                // Đảm bảo không click vào header
                if (e.RowIndex < 0) return;
            }
        }

        int chiSoDong = -1;

        private void dgvSanPham_NK_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham_NK.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox tương ứng
                txtSoLuong.Text = row.Cells["soLuongNhap"].Value.ToString();
                txtDonGia.Text = row.Cells["donGiaNhap"].Value.ToString();
                cbSanPham.SelectedValue = row.Cells["maSP"].Value;

                // Lưu chỉ số dòng lại nếu cần(để cập nhật)
                chiSoDong = e.RowIndex;
            }
        }

        private void btnCapNhatSP_Click(object sender, EventArgs e)
        {
            if (chiSoDong >= 0 && chiSoDong < dgvSanPham_NK.Rows.Count)
            {
                dgvSanPham_NK.Rows[chiSoDong].Cells["maSP"].Value = cbSanPham.SelectedValue;
                dgvSanPham_NK.Rows[chiSoDong].Cells["soLuongNhap"].Value = txtSoLuong.Text;
                dgvSanPham_NK.Rows[chiSoDong].Cells["donGiaNhap"].Value = txtDonGia.Text;

                MessageBox.Show("Cập nhật dòng thành công!");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần cập nhật!");
            }
        }

        

        private void btnLuuTT_Click(object sender, EventArgs e)
        {
            if(dgvSanPham_NK.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập danh sách sản phẩm được nhập thêm vào kho!!!","Cảnh báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            try
            {
                NhapKhoTO nk = new NhapKhoTO(0, dtNgayNhapKho.Value, 1, Convert.ToInt32(cbNCC.SelectedValue), txtGhiChu.Text);
                int maNK = nhapkhoBL.ThemNhapKho(nk);
                if (maNK == -1)
                {
                    MessageBox.Show("Thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach(DataGridViewRow row in dgvSanPham_NK.Rows)
                {
                    ChiTietNhapKhoTO c = new ChiTietNhapKhoTO(
                        maNK,
                        Convert.ToInt32(row.Cells["maSP"].Value),
                        Convert.ToInt32(row.Cells["soLuongNhap"].Value),
                        Convert.ToDecimal(row.Cells["donGiaNhap"].Value)
                    );

                    bool kq = nhapkhoBL.ThemChiTietNhapKho(c);
                    if(!kq)
                    {
                        MessageBox.Show("Thêm chi tiết nhập kho thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }    
                }
                MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnHuyNhapKho_Click(object sender, EventArgs e)
        {
            Reset_NhapKho();
            
        }


        // ------------- LỊCH SỬ NHẬP KHO ---------------

        private void Reset_LichSuNhapKho()
        {
            dgvNhapKho.DataSource = nhapkhoBL.LayDS_NhapKho();
            dtNgayNhapKho.Value = DateTime.Today;
            lbMaNK.Text = "";
            lbTenNV.Text = "";
            lbTenNCC.Text = "";
            lbGhiChu.Text = "";

            dgvSanPham_ChiTietNK.Rows.Clear();
        }

        private void btnTimKiemNK_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = nhapkhoBL.LayDSNhapKho_NgayNhap(dtNgay_NK_TK.Value);

                if(dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có phiếu nhập kho nào trong thời gian đucợ chỉ định!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                dgvNhapKho.DataSource = dt;
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset_LichSuNhapKho();
        }

        private void dgvNhapKho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvNhapKho.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var maNK = dgvNhapKho.Rows[e.RowIndex].Cells["maNK"].Value;
                if (maNK != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa phiếu nhập kho này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (nhapkhoBL.XoaNhapKho(Convert.ToInt32(maNK)))
                        {
                            MessageBox.Show("Đã xóa phiếu nhập kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset_LichSuNhapKho();
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

        private void dgvNhapKho_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                dgvSanPham_ChiTietNK.Rows.Clear();
                DataGridViewRow row = dgvNhapKho.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox tương ứng
                lbMaNK.Text = row.Cells["maNK"].Value.ToString();

                int maNV = Convert.ToInt32(row.Cells["maNV"].Value);
                lbTenNV.Text = nhanvienBL.LayTenNV_maNV(maNV);

                int maNCC = Convert.ToInt32(row.Cells["maNCC"].Value);
                lbTenNCC.Text = nhacungcapBL.LayTenNCC(maNCC);

                lbGhiChu.Text = row.Cells["ghiChu"].Value.ToString();

                DataTable dt = nhapkhoBL.LayChiTietNhapKho(Convert.ToInt32(row.Cells["maNK"].Value));
                // Thêm cột tenSP 
                dt.Columns.Add("tenSP", typeof(string));

                // Duyệt từng dòng và gán tên sản phẩm
                foreach (DataRow dr in dt.Rows)
                {
                    int maSP = Convert.ToInt32(dr["maSP"]); 
                    string tenSP = sanphamBL.LaySP_maSP(maSP); 
                    dr["tenSP"] = tenSP;

                    dgvSanPham_ChiTietNK.Rows.Add(dr["maSP"], dr["tenSP"], dr["soLuongNhap"], dr["donGiaNhap"]);
                }

                
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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
