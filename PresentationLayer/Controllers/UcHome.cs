using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;
using TransferObject;
using static System.Net.Mime.MediaTypeNames;

namespace PresentationLayer.Controllers
{
    public partial class UcHome : UserControl
    {
        public UcHome()
        {
            InitializeComponent();
        }

        NhanVienBL nhanvienBL = new NhanVienBL();
        KhachHangBL khachhangBL = new KhachHangBL();
        SanPhamBL sanphamBL = new SanPhamBL();
        KhuyenMaiBL khuyenmaiBL = new KhuyenMaiBL();
        HoaDonBL hoadonBL = new HoaDonBL();

        private void Reset()
        {
            // Load combobox loại SP
            cbLoaiSP.DataSource = sanphamBL.LayDSLoaiSP();
            cbLoaiSP.DisplayMember = "tenLoai";
            cbLoaiSP.ValueMember = "maLoai";
            cbLoaiSP.SelectedIndex = -1;

            // Load combobox hãng SX
            cbHangSP.DataSource = sanphamBL.LayDSHangSX();
            cbHangSP.DisplayMember = "tenHang";
            cbHangSP.ValueMember = "maHang";
            cbHangSP.SelectedIndex = -1;

            // Load combobox khuyến mãi
            cbKhuyenMai.DataSource = khuyenmaiBL.LayDSKhuyenMai();
            cbKhuyenMai.DisplayMember = "tenKM";
            cbKhuyenMai.ValueMember = "maKM";
            cbKhuyenMai.SelectedIndex = -1;

            txtTK_MaSP.Clear();
            txtTenSP.Clear();
            txtTonKho.Clear();
            txtGiaBanSP.Clear();
        }

        private void Load_ThongTin()
        {
            dgvGioHang.Rows.Clear();
            txtMaKH.Text = "1";
            txtTenKH.Text = khachhangBL.LayTenKH_maKH(1);
            lbKhuyenMai.Text = "Không có.";
            lbTongTien.Text = "0";
            lbSoTienThanhToan.Text = "0";
            rbtn_TienMat.Checked = true;

        }
        private void UcHome_Load(object sender, EventArgs e)
        {
            txtTenNV.Text = nhanvienBL.LayTenNV_maNV(TaiKhoanHienTai.TaiKhoan.maNV);
            txtThoiGianMoQuay.Text = TaiKhoanHienTai.thoiGianDN;
            Load_ThongTin();
            Reset();
        }

        private void txtTK_MaSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }


        }

        private void txtMaKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void btnTimKiemSP_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTK_MaSP.Text))
            {
                MessageBox.Show("Mã sản phẩm chưa được nhập!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DataTable dt = sanphamBL.TimKiemSP_maSP(Convert.ToInt32(txtTK_MaSP.Text));
                DataRow row = dt.Rows[0];

                txtTenSP.Text = row["tenSP"].ToString();
                cbLoaiSP.SelectedValue = row["maLoai"];
                cbHangSP.SelectedValue = row["maHang"];
                cbKhuyenMai.SelectedValue = row["maKM"];
                txtGiaBanSP.Text = row["donGiaBan"].ToString();
                txtTonKho.Text = row["tonKho"].ToString();

                btnThemSP.Enabled = true;

                if (Convert.ToInt32(txtTonKho.Text) == 0)
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnThemSP.Enabled = false;
                }

            
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        decimal tongTien, tongTien_TT;

        private void TinhTongTien()
        {
            tongTien = 0;
            tongTien_TT = 0;
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                decimal donGia = Convert.ToDecimal(row.Cells["donGiaBan"].Value);
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                // Lấy tỷ lệ giảm hiện tại (nếu có trong cột tyLeGiamGia)
                decimal giamGia = 0;
                if (row.Cells["tyLeGiamGia"].Value != null && row.Cells["tyLeGiamGia"].Value.ToString() != "")
                {
                    string giamGiaStr = row.Cells["tyLeGiamGia"].Value.ToString().Replace("%", "");
                    giamGia = Convert.ToDecimal(giamGiaStr) / 100;
                }

                // Tính lại thành tiền với số lượng mới
                tongTien_TT += soLuong * donGia * (1 - giamGia);
                tongTien += soLuong * donGia;
            }
        }

        private void CapNhatTongTienVaKhuyenMai()
        {
            lbTongTien.Text = tongTien.ToString("N0") + " VND";

            // 1. Lấy khuyến mãi của khách hàng (nếu có)
            DataTable dt_km = khuyenmaiBL.LayKhuyenMai_maKH(Convert.ToInt32(txtMaKH.Text));
            if (dt_km.Rows.Count > 0)
            {
                DataRow r = dt_km.Rows[0];
                string tenKM = r["tenKM"].ToString();
                decimal tyLeKM_KH = Convert.ToDecimal(r["tyLeGiam"]);

                lbKhuyenMai.Text = tenKM + " giảm " + tyLeKM_KH.ToString() + "%";

                // 2. Tính tổng giá trị giỏ hàng (trước giảm)
                decimal tongGiaTri = 0;
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    if (row.Cells["donGiaBan"].Value != null)
                    {
                        decimal donGia = Convert.ToDecimal(row.Cells["donGiaBan"].Value);
                        int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);

                        tongGiaTri += donGia * soLuong; // chưa tính giảm
                    }
                }

                // 3. Tổng giảm giá theo KH
                decimal tongGiamGia = tongGiaTri * (tyLeKM_KH / 100);

                // 4. Phân bổ giảm giá theo tỷ lệ từng sản phẩm
                decimal tongThanhToan = 0;
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    int maSP_GioHang = Convert.ToInt32(row.Cells["maSP"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["donGiaBan"].Value);
                    int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);

                    decimal giaTriSP = donGia * soLuong;

                    // Giảm giá phân bổ cho sản phẩm i
                    decimal giamGiaSP_PhanBo = (giaTriSP / tongGiaTri) * tongGiamGia;

                    // Tỷ lệ giảm phân bổ
                    decimal tyLeGiam_PhanBo = giamGiaSP_PhanBo / giaTriSP * 100;

                    // --- Nếu SP có sẵn giảm giá riêng ---
                    decimal tyLeGiam_SP = sanphamBL.LayTyLeGiam_maSP(maSP_GioHang);

                    // Tổng tỷ lệ giảm = giảm riêng + giảm phân bổ
                    decimal tongTyLeGiam = tyLeGiam_SP + tyLeGiam_PhanBo;

                    // Doanh thu sau giảm của sản phẩm i
                    decimal thanhTienSauGiam = giaTriSP * (1 - tongTyLeGiam / 100);

                    // Update vào grid
                    row.Cells["tyLeGiamGia"].Value = tongTyLeGiam.ToString("0.##") + "%";
                    row.Cells["thanhTien"].Value = thanhTienSauGiam;

                    tongThanhToan += thanhTienSauGiam;
                }

                // 5. Update tổng thanh toán sau khi phân bổ
                lbSoTienThanhToan.Text = tongThanhToan.ToString("N0") + " VND";
            }
            else
            {
                lbKhuyenMai.Text = "Không có";
                lbSoTienThanhToan.Text = tongTien_TT.ToString("N0") + " VND";
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(numSoLuong.Value) > Convert.ToInt32(txtTonKho.Text))
            {
                MessageBox.Show("Sản phẩm không đủ số lượng để thêm vào giỏ hàng!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            // Lấy mã sản phẩm 
            int maSP = Convert.ToInt32(txtTK_MaSP.Text);

            // Duyệt qua các dòng để kiểm tra trùng mã
            foreach (DataGridViewRow row in dgvGioHang.Rows)
            {
                if (row.Cells["maSP"].Value.ToString() == maSP.ToString())
                {
                    int sl = Convert.ToInt32(row.Cells["soLuong"].Value) + Convert.ToInt32(numSoLuong.Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["donGiaBan"].Value);

                    // Lấy tỷ lệ giảm hiện tại (nếu có trong cột tyLeGiamGia)
                    decimal giamGia = 0;
                    if (row.Cells["tyLeGiamGia"].Value != null && row.Cells["tyLeGiamGia"].Value.ToString() != "")
                    {
                        string giamGiaStr = row.Cells["tyLeGiamGia"].Value.ToString().Replace("%", "");
                        giamGia = Convert.ToDecimal(giamGiaStr) / 100;
                    }

                    // Tính lại thành tiền với số lượng mới
                    decimal tt = sl * donGia * (1 - giamGia);
                    row.Cells["soLuong"].Value = sl;
                    row.Cells["thanhTien"].Value = tt;

                    TinhTongTien();
                    CapNhatTongTienVaKhuyenMai();
                    return;
                }
            }

            // Nếu sản phẩm chưa có trong giỏ thì thêm mới
            int soLuong = Convert.ToInt32(numSoLuong.Value);
            decimal donGiaBan = Convert.ToDecimal(txtGiaBanSP.Text);

            // Lấy khuyến mãi theo sản phẩm (nếu có)
            decimal giamGiaSP = cbKhuyenMai.SelectedIndex != -1 ? sanphamBL.LayTyLeGiam_maSP(maSP) / 100 : 0;
            string giamGiaText = cbKhuyenMai.SelectedIndex != -1 ? sanphamBL.LayTyLeGiam_maSP(maSP).ToString() + "%" : "";

            decimal thanhTien = soLuong * donGiaBan * (1 - giamGiaSP);
            dgvGioHang.Rows.Add(maSP,sanphamBL.LaySP_maSP(maSP), soLuong, donGiaBan,giamGiaText,thanhTien);

            // Tính tổng tiền
            TinhTongTien();
            CapNhatTongTienVaKhuyenMai();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void pic_TraCuuKH_Click(object sender, EventArgs e)
        {
            txtTenKH.Text = khachhangBL.LayTenKH_maKH(Convert.ToInt32(txtMaKH.Text));
            
            DataTable dt_km = khuyenmaiBL.LayKhuyenMai_maKH(Convert.ToInt32(txtMaKH.Text));
            if (dt_km.Rows.Count > 0)
            {
                DataRow r = dt_km.Rows[0];
                lbKhuyenMai.Text = r["tenKM"].ToString() + " giảm " + r["tyLeGiam"].ToString() + "%";
               
            }
            else
            {
                lbKhuyenMai.Text = "Không có";
             
            }

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaKH.Text) || string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Mã khách hàng và tên khách hàng KHÔNG được để trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  
            if(dgvGioHang.Rows.Count < 1)
            {

                MessageBox.Show("Không có sản phẩm nào trong giỏ hàng để thanh toán!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string phuongThucTT = rbtn_TienMat.Checked ? rbtn_TienMat.Text : rbtn_ChuyenKhoan.Text;

            // Tạo đơn hàng
            HoaDonTO h = new HoaDonTO(0, DateTime.Now, TaiKhoanHienTai.TaiKhoan.maNV, Convert.ToInt32(txtMaKH.Text), phuongThucTT);
            int maHD = hoadonBL.ThemHoaDon_LayMaHD(h); 
            if(maHD == 0)
            {
                MessageBox.Show("Không thể tạo đơn hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    

            // Tạo chi tiết đơn hàng
            foreach(DataGridViewRow row in dgvGioHang.Rows)
            {
                int maSP = Convert.ToInt32(row.Cells["maSP"].Value);
                int soLuong = Convert.ToInt32(row.Cells["soLuong"].Value);
                decimal donGiaBan = Convert.ToDecimal(row.Cells["donGiaBan"].Value);
                float tyLeGiamGia = 0;
                if(!string.IsNullOrEmpty(row.Cells["tyLeGiamGia"].Value.ToString()))
                {
                    tyLeGiamGia = float.Parse(row.Cells["tyLeGiamGia"].Value.ToString().Replace("%", "").Trim());
                }    
                ChiTietHoaDonTO c = new ChiTietHoaDonTO(maHD, maSP, soLuong, donGiaBan, tyLeGiamGia);

                bool kq = hoadonBL.ThemChiTietHoaDon(c);
                if (!kq)
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn thất bại!!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }    

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF file|*.pdf";
            save.Title = "Lưu hóa đơn PDF";
            save.FileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                doc.Open();

                // Font hỗ trợ tiếng Việt
                BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font italicFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.ITALIC);

                // Tiêu đề
                Paragraph title = new Paragraph("THÔNG TIN CHI TIẾT HÓA ĐƠN", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                doc.Add(new Paragraph("\n"));

                // Thông tin chung
                doc.Add(new Paragraph("Mã hóa đơn: " + maHD, normalFont));
                doc.Add(new Paragraph("Ngày lập: " + h.ngayLapHD, normalFont));
                doc.Add(new Paragraph("Nhân viên: " + txtTenNV.Text, normalFont));
                doc.Add(new Paragraph("Khách hàng: " + txtTenKH.Text, normalFont));
                doc.Add(new Paragraph("Khuyến mãi: " + lbKhuyenMai.Text, normalFont));
                doc.Add(new Paragraph("* Tỷ lệ giảm giá của hạng khách hàng trên tổng hóa đơn được áp dụng bằng cách phân bổ thêm vào tỷ lệ giảm giá của các sản phẩm có trong đơn hàng. " , italicFont));

                doc.Add(new Paragraph("\n"));

                // Bảng sản phẩm (trừ cột cuối)
                PdfPTable table = new PdfPTable(dgvGioHang.Columns.Count - 1);
                table.WidthPercentage = 100;

                // Header
                foreach (DataGridViewColumn column in dgvGioHang.Columns)
                {
                    if (string.IsNullOrEmpty(column.HeaderText)) // bỏ cột có header rỗng
                        continue;

                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, titleFont));
                    cell.BackgroundColor = new BaseColor(230, 230, 250);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                // Nội dung bảng
                foreach (DataGridViewRow row in dgvGioHang.Rows)
                {
                    for (int i = 0; i < dgvGioHang.Columns.Count; i++)
                    {
                        if (string.IsNullOrEmpty(dgvGioHang.Columns[i].HeaderText)) // bỏ cột header rỗng
                            continue;

                        string value = row.Cells[i].Value?.ToString() ?? "";
                        PdfPCell dataCell = new PdfPCell(new Phrase(value, normalFont));
                        dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(dataCell);
                    }
                }

                doc.Add(table);

                doc.Add(new Paragraph("\n"));

                // Thông tin khuyến mãi và số tiền thanh toán
                doc.Add(new Paragraph("Tổng tiền (tính trên giá gốc): " + lbTongTien.Text, normalFont));
                doc.Add(new Paragraph("Số tiền phải thanh toán: " + lbSoTienThanhToan.Text, boldFont));
                doc.Add(new Paragraph("Phương thức thanh toán: " + phuongThucTT, normalFont));

                // Đường kẻ
                doc.Add(new Paragraph("\n"));
                doc.Add(new LineSeparator(0.5f, 100, BaseColor.GRAY, Element.ALIGN_CENTER, -2));
                doc.Add(new Paragraph("\n"));

                // Lưu ý
                Paragraph noteTitle = new Paragraph("Lưu ý:", boldFont);
                noteTitle.SpacingBefore = 10;
                doc.Add(noteTitle);

                string luuY =
                    "- Sản phẩm được bảo hành theo quy định của nhà sản xuất, vui lòng giữ hóa đơn để được hỗ trợ.\n" +
                    "- Đổi trả trong vòng 7 ngày nếu sản phẩm bị lỗi do nhà sản xuất (còn nguyên tem, không trầy xước, đầy đủ phụ kiện và hộp).\n" +
                    "- Không hỗ trợ đổi trả với sản phẩm lỗi do người dùng gây ra (rơi vỡ, vô nước, tự ý sửa chữa,...).\n" +
                    "- Quý khách vui lòng kiểm tra kỹ sản phẩm trước khi rời khỏi cửa hàng.\n\n" +
                    "**Liên hệ hỗ trợ:**\n" +
                    "- Hotline: 0964 766 634\n" +
                    "- Email: 225105CNTT@ou.edu.vn\n" +
                    "- Địa chỉ: Phước Kiển, Nhà Bè, TP. Hồ Chí Minh\n" +
                    "- Giờ làm việc: 8:00 - 21:00 (Tất cả các ngày trong tuần)";

                Paragraph noteBody = new Paragraph(luuY, normalFont);
                noteBody.SpacingAfter = 10;
                doc.Add(noteBody);

                doc.Close();

                MessageBox.Show("Thanh toán và xuất hóa đơn PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Load lại trang bán hàng
                Reset();
                Load_ThongTin();
            }
        }

        private void dgvGioHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvGioHang.Columns["delete"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvGioHang.Rows[e.RowIndex];

                tongTien = tongTien - Convert.ToDecimal(row.Cells["thanhTien"].Value);

                lbTongTien.Text = tongTien.ToString("N0") + " VND";

                // Tính số tiền phải thanh toán nếu hạng khách hàng có khuyến mãi
                DataTable km = khuyenmaiBL.LayKhuyenMai_maKH(Convert.ToInt32(txtMaKH.Text));
                if (km.Rows.Count > 0)
                {
                    DataRow r = km.Rows[0];
                    decimal tyLe = Convert.ToDecimal(r["tyLeGiam"]);
                    decimal thanhToan = tongTien * (1 - tyLe / 100);
                    lbSoTienThanhToan.Text = thanhToan.ToString("N0") + " VND";
                }
                else
                {
                    lbSoTienThanhToan.Text = tongTien.ToString("N0") + " VND";
                }

                dgvGioHang.Rows.RemoveAt(e.RowIndex);
            }
            else
            {
                // Đảm bảo không click vào header
                if (e.RowIndex < 0) return;
            }
        }



        private void tabBanHangDienTu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabBanHangDienTu.SelectedTab == tabLichSuBH)
            {
                dgvChiTietHD.Rows.Clear();
                dgvHoaDon.DataSource = hoadonBL.LayDS_HoaDon_maNV(TaiKhoanHienTai.TaiKhoan.maNV);

                lbMaHD.Text = "";
                lbTenKH.Text = "";
                lbTenNV.Text = "";
                lbNgayLapHD.Text = "";
                lbTongTien_CTDH.Text = "";
                lbThanhToan_CTDH.Text = "";
                lbKM_CTDH.Text = "";
                lbPhuongThucTT.Text = "";
            } 
                
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            
            if (dtNgay.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Ngày được chọn không hợp lệ!!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    

            DataTable dt = hoadonBL.LayDSHoaDon_maNV_NgayLapHD(TaiKhoanHienTai.TaiKhoan.maNV, dtNgay.Value.Date);

            if(dt.Rows.Count > 0)
            {
                dgvHoaDon.DataSource = dt;
            }  
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn nào!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);   
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            if(dgvChiTietHD.Rows.Count <= 0)
            {
                MessageBox.Show("Không có thông tin chi tiết hóa đơn nào để in hóa đơn!!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }    
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF file|*.pdf";
            save.Title = "Lưu hóa đơn PDF";
            save.FileName = "HoaDon_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                doc.Open();

                // Font hỗ trợ tiếng Việt
                BaseFont bf = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 14, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font italicFont = new iTextSharp.text.Font(bf, 11, iTextSharp.text.Font.ITALIC);

                // Tiêu đề
                Paragraph title = new Paragraph("THÔNG TIN CHI TIẾT HÓA ĐƠN", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);

                doc.Add(new Paragraph("\n"));

                // Thông tin chung
                doc.Add(new Paragraph("Mã hóa đơn: " + lbMaHD.Text, normalFont));
                doc.Add(new Paragraph("Ngày lập: " + lbNgayLapHD.Text, normalFont));
                doc.Add(new Paragraph("Nhân viên: " + lbTenNV.Text, normalFont));
                doc.Add(new Paragraph("Khách hàng: " + lbTenKH.Text, normalFont));
                doc.Add(new Paragraph("Khuyến mãi: " + lbKM_CTDH.Text, normalFont));
                doc.Add(new Paragraph("* Tỷ lệ giảm giá của hạng khách hàng trên tổng hóa đơn được áp dụng bằng cách phân bổ thêm vào tỷ lệ giảm giá của các sản phẩm có trong đơn hàng. ", italicFont));

                doc.Add(new Paragraph("\n"));

                // Bảng sản phẩm
                PdfPTable table = new PdfPTable(dgvChiTietHD.Columns.Count);
                table.WidthPercentage = 100;

                // Header
                foreach (DataGridViewColumn column in dgvChiTietHD.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, titleFont));
                    cell.BackgroundColor = new BaseColor(230, 230, 250);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                // Nội dung bảng
                foreach (DataGridViewRow row in dgvChiTietHD.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            string value = cell.Value?.ToString() ?? "";
                            PdfPCell dataCell = new PdfPCell(new Phrase(value, normalFont));
                            dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            table.AddCell(dataCell);
                        }
                    }
                }

                doc.Add(table);

                doc.Add(new Paragraph("\n"));

                // Thông tin khuyến mãi và số tiền thanh toán
                doc.Add(new Paragraph("Tổng tiền (tính trên giá gốc): " + lbTongTien_CTDH.Text, normalFont));
                doc.Add(new Paragraph("Số tiền phải thanh toán: " + lbThanhToan_CTDH.Text, boldFont));
                doc.Add(new Paragraph("Phương thức thanh toán: " + lbPhuongThucTT.Text, normalFont));

                // Đường kẻ
                doc.Add(new Paragraph("\n"));
                doc.Add(new LineSeparator(0.5f, 100, BaseColor.GRAY, Element.ALIGN_CENTER, -2));
                doc.Add(new Paragraph("\n"));

                // Lưu ý
                Paragraph noteTitle = new Paragraph("Lưu ý:", boldFont);
                noteTitle.SpacingBefore = 10;
                doc.Add(noteTitle);

                string luuY =
                    "- Sản phẩm được bảo hành theo quy định của nhà sản xuất, vui lòng giữ hóa đơn để được hỗ trợ.\n" +
                    "- Đổi trả trong vòng 7 ngày nếu sản phẩm bị lỗi do nhà sản xuất (còn nguyên tem, không trầy xước, đầy đủ phụ kiện và hộp).\n" +
                    "- Không hỗ trợ đổi trả với sản phẩm lỗi do người dùng gây ra (rơi vỡ, vô nước, tự ý sửa chữa,...).\n" +
                    "- Quý khách vui lòng kiểm tra kỹ sản phẩm trước khi rời khỏi cửa hàng.\n\n" +
                    "**Liên hệ hỗ trợ:**\n" +
                    "- Hotline: 0964 766 634\n" +
                    "- Email: 225105CNTT@ou.edu.vn\n" +
                    "- Địa chỉ: Phước Kiển, Nhà Bè, TP. Hồ Chí Minh\n" +
                    "- Giờ làm việc: 8:00 - 21:00 (Tất cả các ngày trong tuần)";

                Paragraph noteBody = new Paragraph(luuY, normalFont);
                noteBody.SpacingAfter = 10;
                doc.Add(noteBody);

                doc.Close();

                MessageBox.Show("Xuất hóa đơn PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvHoaDon_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy thông tin dòng được chọn
            if (e.RowIndex >= 0)
            {
                dgvChiTietHD.Rows.Clear();
                lbKhuyenMai.Text = "";
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];

                //Gán giá trị vào từng label tương ứng
                lbMaHD.Text = row.Cells["maHD"].Value.ToString();
                lbNgayLapHD.Text = Convert.ToDateTime(row.Cells["ngayLapHD"].Value).ToString();

                int maNV = Convert.ToInt32(row.Cells["maNV"].Value);
                lbTenNV.Text = nhanvienBL.LayTenNV_maNV(maNV);

                int maKH = Convert.ToInt32(row.Cells["maKH"].Value);
                lbTenKH.Text = khachhangBL.LayTenKH_maKH(maKH);

                lbPhuongThucTT.Text = row.Cells["phuongThucTT"].Value.ToString();

                DataTable dt = hoadonBL.LayChiTietHoaDon(Convert.ToInt32(row.Cells["maHD"].Value));
                // Thêm cột tenSP và thanhTien
                dt.Columns.Add("tenSP", typeof(string));
                dt.Columns.Add("thanhTien", typeof(decimal));

                // Duyệt từng dòng và gán tên sản phẩm và tính thành tiền
                foreach (DataRow dr in dt.Rows)
                {
                    int maSP = Convert.ToInt32(dr["maSP"]);
                    string tenSP = sanphamBL.LaySP_maSP(maSP);
                    dr["tenSP"] = tenSP;

                    int soLuong = Convert.ToInt32(dr["soLuong"]);
                    decimal donGia = Convert.ToDecimal(dr["donGiaBan"]);
                    decimal giamGia = dr["tyLeGiamGia"] != DBNull.Value ? Convert.ToDecimal(dr["tyLeGiamGia"]) / 100 : 0;
                    string giamGiaText = dr["tyLeGiamGia"] != DBNull.Value ? Convert.ToDecimal(dr["tyLeGiamGia"]).ToString() + "%" : "";

                    decimal thanhTien = soLuong * donGia * (1 - giamGia);
                    dr["thanhTien"] = thanhTien;

                    // Thêm vào DataGridView (đã có cột sẵn)
                    int rowIndex = dgvChiTietHD.Rows.Add();
                    DataGridViewRow rowHD = dgvChiTietHD.Rows[rowIndex];

                    rowHD.Cells["maSP_CTHD"].Value = dr["maSP"];
                    rowHD.Cells["tenSP_CTHD"].Value = tenSP;
                    rowHD.Cells["soLuong_CTHD"].Value = dr["soLuong"];
                    rowHD.Cells["donGiaBan_CTHD"].Value = dr["donGiaBan"];
                    rowHD.Cells["tyLeGiamGia_CTHD"].Value = giamGiaText;
                    rowHD.Cells["thanhTien_CTHD"].Value = thanhTien;

                    
                }

                // Tính tổng tiền
                decimal tongTien = 0;
                decimal tonTien_TT = 0;

                // Lấy khuyến mãi
                List<string> ds_Km = new List<string>();

                // Nếu hạng khách hàng có khuyến mãi
                DataTable dt_km = khuyenmaiBL.LayKhuyenMai_maKH(maKH);
                if (dt_km.Rows.Count > 0)
                {
                    DataRow r = dt_km.Rows[0];
                    string tenKM = r["tenKM"].ToString();
                    ds_Km.Add(tenKM);

                }
                // Lấy khuyến mãi của mỗi sản phẩm
                foreach (DataRow dr in dt.Rows)
                {
                    tonTien_TT += Convert.ToDecimal(dr["thanhTien"]);
                    tongTien += Convert.ToDecimal(dr["donGiaBan"]) * Convert.ToInt32(dr["soLuong"]);

                    if (dr["tyLeGiamGia"] != DBNull.Value && !string.IsNullOrEmpty(dr["tyLeGiamGia"].ToString()))
                    {
                        string tenKM = khuyenmaiBL.LayKM_maSP(Convert.ToInt32(dr["maSP"]));
                        if (!string.IsNullOrEmpty(tenKM))
                            ds_Km.Add(tenKM);

                    }
                }


                if (ds_Km.Count > 0)
                {
                    foreach (string tenKM in ds_Km)
                    {
                        lbKM_CTDH.Text = string.Join(", ", ds_Km);
                    }

                }
                else
                    lbKM_CTDH.Text = "Không có.";

                lbTongTien_CTDH.Text = tongTien.ToString("N0") + " VND";
                lbThanhToan_CTDH.Text = tonTien_TT.ToString("N0") + " VND";
            }

        }
    }
}
