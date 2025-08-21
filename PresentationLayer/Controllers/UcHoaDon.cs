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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Xml.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using DocumentFormat.OpenXml.Presentation;


namespace PresentationLayer.Controllers
{
    public partial class UcHoaDon : UserControl
    {
        public UcHoaDon()
        {
            InitializeComponent();
        }

        HoaDonBL hoadonBL = new HoaDonBL();
        NhanVienBL nhanvienBL = new NhanVienBL();
        KhachHangBL khachhangBL = new KhachHangBL();
        SanPhamBL sanphamBL = new SanPhamBL();
        KhuyenMaiBL khuyenmaiBL = new KhuyenMaiBL();
        private void Reset_HoaDon()
        {
            dgvHoaDon.DataSource = hoadonBL.LayDS_HoaDon();
            dgvChiTietHD.Rows.Clear();
            
            dtNgay.Value = DateTime.Today;

            lbMaHD.Text = "";
            lbTenKH.Text = "";
            lbTenNV.Text = "";
            lbPhuongThucTT.Text = "";
            lbTongTien.Text = "";
            lbNgayLapHD.Text = "";
        }

        private void UcHoaDon_Load(object sender, EventArgs e)
        {
            Reset_HoaDon();
        }

        private void btnTimKiemHD_Click(object sender, EventArgs e)
        {
            if(dtNgay.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Ngày được chọn KHÔNG được sau ngày hôm nay!!!","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            DataTable dt = hoadonBL.LayDSHoaDon_NgayLapHD(dtNgay.Value.Date);
            if(dt.Rows.Count >0)
            {
                dgvHoaDon.DataSource = dt;
            } 
            else
            {
                MessageBox.Show("Không có hóa đơn nào phù hợp với điều kiện tìm kiếm!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void btnHienThi_All_HD_Click(object sender, EventArgs e)
        {
            Reset_HoaDon();
        }


       
        private void btnInHD_Click(object sender, EventArgs e)
        {
            if (dgvChiTietHD.Rows.Count <= 0)
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
                doc.Add(new Paragraph("Khuyến mãi: " + lbKhuyenMai.Text, normalFont));
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
                doc.Add(new Paragraph("Tổng tiền (tính trên giá gốc): " + lbTongTien.Text, normalFont));
                doc.Add(new Paragraph("Số tiền phải thanh toán: " + lbSoTienThanhToan.Text, boldFont));
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

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvHoaDon.Columns["delete"].Index && e.RowIndex >= 0)
            {
                var maHD = dgvHoaDon.Rows[e.RowIndex].Cells["maHD"].Value;
                if (maHD != null)
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        if (hoadonBL.XoaHoaDon(Convert.ToInt32(maHD)))
                        {
                            MessageBox.Show("Đã xóa hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Reset_HoaDon();
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
                lbNgayLapHD.Text = Convert.ToDateTime(row.Cells["ngayLapHD"].Value).ToString("dd/MM/yyyy HH:mm");

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

                    rowHD.Cells["maSP"].Value = dr["maSP"];
                    rowHD.Cells["tenSP"].Value = tenSP;
                    rowHD.Cells["soLuong"].Value = dr["soLuong"];
                    rowHD.Cells["donGiaBan"].Value = dr["donGiaBan"];
                    rowHD.Cells["tyLeGiamGia"].Value = giamGiaText;
                    rowHD.Cells["thanhTien"].Value = thanhTien;
 
                }

                // Tính tổng tiền
                decimal tongTien = 0;
                decimal tonTien_TT = 0;

                // Lấy khuyến mãi
                List < string > ds_Km = new List<string>();

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

                    if(dr["tyLeGiamGia"] != DBNull.Value && !string.IsNullOrEmpty(dr["tyLeGiamGia"].ToString()))
                    {
                        string tenKM = khuyenmaiBL.LayKM_maSP(Convert.ToInt32(dr["maSP"]));
                        if(!string.IsNullOrEmpty(tenKM))
                            ds_Km.Add(tenKM);

                    }    
                }


                if (ds_Km.Count > 0)
                {
                    foreach (string tenKM in ds_Km)
                    {
                        lbKhuyenMai.Text = string.Join(", ", ds_Km);
                    }
                    
                }
                else
                    lbKhuyenMai.Text = "Không có.";

                lbTongTien.Text = tongTien.ToString("N0") + " VND";
                lbSoTienThanhToan.Text = tonTien_TT.ToString("N0") + " VND";

            }

               

            
        }
    }
}
