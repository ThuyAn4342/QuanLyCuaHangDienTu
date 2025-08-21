using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace PresentationLayer.Controllers
{
    public partial class UcSanPham : UserControl
    {
        public UcSanPham()
        {
            InitializeComponent();
        }

        SanPhamBL sanphamBL = new SanPhamBL();
        KhuyenMaiBL khuyenmaiBL = new KhuyenMaiBL();

        // Load dữ liệu lên giao diện
        private void LoadDL()
        {
            dgvSanPham.DataSource = sanphamBL.LayDS_SanPham();
            dgvLoaiSanPham.DataSource = sanphamBL.LayDSLoaiSP();
            dgvHangSX.DataSource = sanphamBL.LayDSHangSX();

            //Load combobox tìm kiếm loại SP
            cbTK_LoaiSP.DataSource = sanphamBL.LayDSLoaiSP();
            cbTK_LoaiSP.DisplayMember = "tenLoai";
            cbTK_LoaiSP.ValueMember = "maLoai";
            cbTK_LoaiSP.SelectedIndex = -1;

            //Load combobox tìm kiếm hãng SX
            cbTK_HangSX.DataSource = sanphamBL.LayDSHangSX();
            cbTK_HangSX.DisplayMember = "tenHang";
            cbTK_HangSX.ValueMember = "maHang";
            cbTK_HangSX.SelectedIndex = -1;

            // Load combobox loại SP
            cbLoaiSP.DataSource = sanphamBL.LayDSLoaiSP();
            cbLoaiSP.DisplayMember = "tenLoai";
            cbLoaiSP.ValueMember = "maLoai";
            cbLoaiSP.SelectedIndex = 0;

            // Load combobox hãng SX
            cbHangSP.DataSource = sanphamBL.LayDSHangSX();
            cbHangSP.DisplayMember = "tenHang";
            cbHangSP.ValueMember = "maHang";
            cbHangSP.SelectedIndex = 0;

            // Load combobox khuyến mãi
            cbKhuyenMai.DataSource = khuyenmaiBL.LayDSKhuyenMai();
            cbKhuyenMai.DisplayMember = "tenKM";
            cbKhuyenMai.ValueMember = "maKM";
            cbKhuyenMai.SelectedIndex = -1;

            cbTrangThaiSP.SelectedIndex = 0;
        }

        private void reset_SanPham()
        {
            dgvSanPham.DataSource = sanphamBL.LayDS_SanPham();

            //Thiết lập lại combobox
            cbTK_LoaiSP.SelectedIndex = -1;
            cbTK_HangSX.SelectedIndex = -1;
            cbLoaiSP.SelectedIndex = 0;
            cbHangSP.SelectedIndex = 0;
            cbKhuyenMai.SelectedIndex = -1;
            cbTrangThaiSP.SelectedIndex = 0;

            txtTenSP.Clear();
            txtGiaBanSP.Clear();
            txtGiaNhapSP.Clear();
            txtTonKho.Clear();
        }
        private void UcSanPham_Load(object sender, EventArgs e)
        {
            LoadDL();
        }


        private void btnHuyThemSP_Click(object sender, EventArgs e)
        {
            reset_SanPham();

        }

        private void btnCapNhatSP_Click(object sender, EventArgs e)
        {
            // Kiểm tra dòng được chọn
            if (dgvSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenSP = txtTenSP.Text;
            int maLoai = Convert.ToInt32(cbLoaiSP.SelectedValue);
            int maHang = Convert.ToInt32(cbHangSP.SelectedValue);        
            decimal donGiaNhap = decimal.Parse(txtGiaNhapSP.Text);           
            decimal donGiaBan = decimal.Parse(txtGiaBanSP.Text);
            int tonKho = Convert.ToInt32(txtTonKho.Text);
            int maKM = Convert.ToInt32(cbKhuyenMai.SelectedValue);
            string trangThai = cbTrangThaiSP.Text;
            string thongBao;

            if (string.IsNullOrEmpty(tenSP))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(dgvSanPham.CurrentRow.Cells["maSP"].Value);

            SanPhamTO s = new SanPhamTO(maSP, tenSP, maLoai, maHang, donGiaNhap, donGiaBan,
                tonKho, maKM, trangThai);          

            if (sanphamBL.CapNhatSP(s, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_SanPham();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string tenSP = txtTenSP.Text;
            int maLoai = Convert.ToInt32(cbLoaiSP.SelectedValue);
            int maHang = Convert.ToInt32(cbHangSP.SelectedValue);
            decimal donGiaNhap = decimal.Parse(txtGiaNhapSP.Text);
            decimal donGiaBan = decimal.Parse(txtGiaBanSP.Text);
            int.TryParse(txtTonKho.Text, out int tonKho);
            int maKM = Convert.ToInt32(cbKhuyenMai.SelectedValue);
            string trangThai = cbTrangThaiSP.Text;
            string thongBao;
           

            try
            {
                if(string.IsNullOrEmpty(tenSP))
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm!");
                    return;
                }

                SanPhamTO s = new SanPhamTO(0, tenSP, maLoai, maHang, donGiaNhap, donGiaBan,
                tonKho, maKM, trangThai);

                if (sanphamBL.ThemSanPham(s,out thongBao))
                {
                    MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reset_SanPham();

                }
                else
                {
                    MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }    
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void dgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string thongBao;
            try
            {
                if (e.ColumnIndex == dgvSanPham.Columns["delete"].Index && e.RowIndex >= 0)
                {
                    var maSP = dgvSanPham.Rows[e.RowIndex].Cells["maSP"].Value;
                    if (maSP != null)
                    {
                        DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm mã {maSP} không?", "Xác nhận", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            if (sanphamBL.XoaSanPham(Convert.ToInt32(maSP), out thongBao))
                            {
                                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                reset_SanPham();
                            }
                            else
                            {
                                MessageBox.Show(thongBao, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }
                    }
                    else
                    {
                        // Đảm bảo không click vào header
                        if (e.RowIndex < 0) return;
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }

        private void dgvSanPham_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                //Gán giá trị vào từng textbox tương ứng
                txtTenSP.Text = row.Cells["tenSP"].Value.ToString();
                cbLoaiSP.SelectedValue = row.Cells["maLoai_SP"].Value;
                cbHangSP.SelectedValue = row.Cells["maHang_SP"].Value;
                txtGiaBanSP.Text = row.Cells["donGiaBan"].Value.ToString();
                txtGiaNhapSP.Text = row.Cells["donGiaNhap"].Value.ToString();
                txtTonKho.Text = row.Cells["tonKho"].Value.ToString();
                if (row.Cells["maKM"].Value != DBNull.Value)
                    cbKhuyenMai.SelectedValue = Convert.ToInt32(row.Cells["maKM"].Value);
                cbTrangThaiSP.Text = row.Cells["trangThai"].Value.ToString();
            }    
        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {

            if (txtTK_MaSP.Text != "")
            {
                int maSP = Convert.ToInt32(txtTK_MaSP.Text);
                if(sanphamBL.TimKiemMaSP(maSP))
                {
                    dgvSanPham.DataSource = sanphamBL.TimKiemSP_maSP(maSP);
                    cbTK_LoaiSP.SelectedIndex = -1;
                    cbTK_HangSX.SelectedIndex = -1;
                }
                else
                    MessageBox.Show($"Không tìm thấy sản phẩm có mã {maSP} !!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (cbTK_LoaiSP.SelectedValue != null)
            {
                int maLoai;
                maLoai = Convert.ToInt32(cbTK_LoaiSP.SelectedValue);

                if(cbTK_HangSX.SelectedValue != null)
                {
                    int maHang;
                    maHang = Convert.ToInt32(cbTK_HangSX.SelectedValue);
                    dgvSanPham.DataSource = sanphamBL.TimKiemSP_maLoaiVAmaHang(maLoai, maHang);
                }    
                else
                {
                    dgvSanPham.DataSource = sanphamBL.TimKiemSP_maLoai(maLoai);
                }    
            }    
            else if(cbTK_HangSX.SelectedValue != null)
            {
                int maHang;
                maHang = Convert.ToInt32(cbTK_HangSX.SelectedValue);
            }    
            else
            {
                MessageBox.Show("Không có thông tin nào để tìm kiếm!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    


        }

        private void reset_HangSX()
        {
            dgvHangSX.DataSource = sanphamBL.LayDSHangSX();
            txtHangSX.Clear();
            txtQuocGia.Clear();
        }

        private void dgvHangSX_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string thongBao;
            if(e.ColumnIndex == dgvHangSX.Columns["delete_HangSX"].Index && e.RowIndex >=0)
            {
                var maHang = dgvHangSX.Rows[e.RowIndex].Cells["maHang"].Value;
                if(maHang != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hãng sản xuất này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if(result == DialogResult.Yes)
                    {
                        if(sanphamBL.XoaHangSX(Convert.ToInt32(maHang),out thongBao))
                        {
                            MessageBox.Show(thongBao,"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            reset_HangSX();
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


        private void dgvHangSX_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHangSX.Rows[e.RowIndex];
                txtHangSX.Text = row.Cells["tenHang"].Value.ToString();
                txtQuocGia.Text = row.Cells["quocGia"].Value.ToString();
            }
        }

        private void reset_LoaiSP()
        {
            dgvLoaiSanPham.DataSource = sanphamBL.LayDSLoaiSP();
            txtTenLoaiSP.Clear();
        }

        private void dgvLoaiSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string thongBao;
            if (e.ColumnIndex == dgvLoaiSanPham.Columns["delete_LoaiSP"].Index && e.RowIndex >= 0)
            {
                var maLoai = dgvLoaiSanPham.Rows[e.RowIndex].Cells["maLoai"].Value;
                if (maLoai != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (sanphamBL.XoaLoaiSanPham(Convert.ToInt32(maLoai), out thongBao))
                        {
                            MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reset_LoaiSP();
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

        private void dgvLoaiSanPham_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiSanPham.Rows[e.RowIndex];
                txtTenLoaiSP.Text = row.Cells["tenLoai"].Value.ToString();
               
            }
        }

        private void btnThem_LoaiSP_Click(object sender, EventArgs e)
        {
            string tenLoai, thongBao;

            tenLoai = txtTenLoaiSP.Text;

            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sanphamBL.ThemLoaiSP(tenLoai,  out thongBao))
            {

                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_LoaiSP();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCapNhat_LoaiSP_Click(object sender, EventArgs e)
        {
            string tenLoai, thongBao;

            tenLoai = txtTenLoaiSP.Text;

            if (dgvLoaiSanPham.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maLoai = Convert.ToInt32(dgvLoaiSanPham.CurrentRow.Cells["maLoai"].Value);

            if (string.IsNullOrEmpty(tenLoai))
            {
                MessageBox.Show("Vui lòng nhập tên loại sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sanphamBL.CapNhatLoaiSP(maLoai, tenLoai, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_LoaiSP();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuyThem_LoaiSP_Click(object sender, EventArgs e)
        {
            reset_LoaiSP();
        }


     

        private void btnCapNhat_HangSX_Click(object sender, EventArgs e)
        {
            string tenHang, quocGia, thongBao;

            tenHang = txtHangSX.Text;
            quocGia = txtQuocGia.Text;

            if (dgvHangSX.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một dòng để cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHang = Convert.ToInt32(dgvHangSX.CurrentRow.Cells["maHang"].Value);

            if(string.IsNullOrEmpty(tenHang) && string.IsNullOrEmpty(quocGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ;
            }    

            if (sanphamBL.CapNhatHangSX(maHang, tenHang, quocGia, out thongBao))
            {
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_HangSX();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }    
        }

        private void btnThem_HangSX_Click(object sender, EventArgs e)
        {
            string tenHang, quocGia, thongBao;

            tenHang = txtHangSX.Text;
            quocGia = txtQuocGia.Text;

            if (string.IsNullOrEmpty(tenHang) && string.IsNullOrEmpty(quocGia))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (sanphamBL.ThemHangSX( tenHang, quocGia, out thongBao))
            {
                
                MessageBox.Show(thongBao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset_HangSX();
            }
            else
            {
                MessageBox.Show(thongBao, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnHuy_HangSX_Click(object sender, EventArgs e)
        {
            reset_HangSX();
        }

        private void txtTonKho_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtGiaNhapSP_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtGiaBanSP_KeyPress(object sender, KeyPressEventArgs e)
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
