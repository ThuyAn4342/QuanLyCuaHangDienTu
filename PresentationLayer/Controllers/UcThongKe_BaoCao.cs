using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransferObject;
using BusinessLayer;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace PresentationLayer.Controllers
{
    public partial class UcThongKe_BaoCao : UserControl
    {
        public UcThongKe_BaoCao()
        {
            InitializeComponent();
        }

        ThongKeBaoCaoBL thongkeBL = new ThongKeBaoCaoBL();

        private void CapNhatThongKe(int thang, int nam)
        {
            decimal tongDT = thongkeBL.LayTongDoanhThu(thang, nam);
            lbTongDoanhThu.Text = tongDT.ToString("N2") +" VNĐ" ;

            int tongHD = thongkeBL.LayTongHoaDon(thang,nam);
            lbTongHoaDon.Text = tongHD.ToString();

            decimal TongTienNhap = thongkeBL.LayTongTienNhap(thang,nam);
            decimal loiNhuan = tongDT - TongTienNhap;
            lbTongLoiNhuan.Text = loiNhuan.ToString("N2") + " VNĐ";

            DataTable dt = thongkeBL.LayDoanhThu_LoaiSP(thang, nam);

            // nếu chưa có cột tyLe thì thêm vào
            if (!dt.Columns.Contains("tyLe"))
            {
                dt.Columns.Add("tyLe", typeof(decimal));
            }

            // duyệt từng dòng và tính tỷ lệ
            foreach (DataRow row in dt.Rows)
            {
                if (row["doanhThu"] != DBNull.Value && tongDT > 0)
                {
                    decimal doanhThuLoai = Convert.ToDecimal(row["doanhThu"]);
                    decimal tyLe = Math.Round((doanhThuLoai / tongDT) * 100, 2);
                    row["tyLe"] = tyLe; 
                }
                else
                {
                    row["tyLe"] = "0";
                }
            }

            dgvDoanhThu_LoaiSP.DataSource = dt;

        }


        private void VeBieuDoTyLe()
        {
            // Xóa dữ liệu cũ nếu có
            chartTyLe_LoaiSP.Series.Clear();
            chartTyLe_LoaiSP.ChartAreas.Clear();
            chartTyLe_LoaiSP.Titles.Clear();

            // Tạo chart area
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartTyLe_LoaiSP.ChartAreas.Add(chartArea);

            // Tạo series cho biểu đồ tròn
            Series series = new Series("Tỷ lệ doanh thu");
            series.ChartType = SeriesChartType.Pie; // dạng Pie Chart
            series.Font = new Font("Arial", 10, FontStyle.Bold);

            // Lấy dữ liệu từ dgv
            foreach (DataGridViewRow row in dgvDoanhThu_LoaiSP.Rows)
            {
                if (row.Cells["loaiSP"].Value != null && row.Cells["tyLe"].Value != null)
                {
                    string loaiSP = row.Cells["loaiSP"].Value.ToString();

                    // Cột "tyLe" trong dgv đang có dạng "73,41" hoặc "22,51"
                    // Ta parse thành decimal (chú ý dấu phẩy/dấu chấm)
                  
                    if (decimal.TryParse(row.Cells["tyLe"].Value.ToString(), out decimal tyLe))
                    {
                        series.Points.AddXY(loaiSP, tyLe);
                    }
                }
            }

            // Thêm series vào chart
            chartTyLe_LoaiSP.Series.Add(series);

            // Hiển thị % trên biểu đồ
            series.Label = "#PERCENT{P2}";   // hiển thị tỷ lệ %
            series.LegendText = "#VALX";     // hiển thị tên loại SP trong chú thích

            // Thêm title
            chartTyLe_LoaiSP.Titles.Add("Biểu đồ tỷ lệ doanh thu theo loại sản phẩm");
            chartTyLe_LoaiSP.Titles[0].Font = new System.Drawing.Font("Arial", 11);

        }

        // Hàm vẽ biểu đồ kết hợp
        private void VeBieuDoKetHop(DataTable dt, int thang, int nam)
        {
            // Xóa dữ liệu cũ nếu có
            chartBieuDoKetHop.Series.Clear();
            chartBieuDoKetHop.ChartAreas.Clear();
            chartBieuDoKetHop.Titles.Clear();

            // Thêm ChartArea
            ChartArea chartArea = new ChartArea("ChartArea1");
            chartArea.AxisX.Title = "Ngày";
            chartArea.AxisY.Title = "Doanh thu (VNĐ)";
            chartArea.AxisX.Interval = 1; // hiển thị từng ngày
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartBieuDoKetHop.ChartAreas.Add(chartArea);

            // Series 1: Cột (biểu diễn doanh thu)
            Series colSeries = new Series("Doanh thu");
            colSeries.ChartType = SeriesChartType.Column;
            colSeries.Color = System.Drawing.Color.DodgerBlue;
            colSeries.BorderWidth = 2;

            // Series 2: Đường (xu hướng)
            Series lineSeries = new Series("Xu hướng");
            lineSeries.ChartType = SeriesChartType.Line;
            lineSeries.Color = System.Drawing.Color.Red;
            lineSeries.BorderWidth = 3;
            lineSeries.MarkerStyle = MarkerStyle.Circle;
            lineSeries.MarkerSize = 7;

            // Thêm dữ liệu từ DataTable vào chart
            foreach (DataRow row in dt.Rows)
            {
                DateTime ngay = Convert.ToDateTime(row["ngay"]);
                decimal doanhThu = Convert.ToDecimal(row["doanhThu"]);

                colSeries.Points.AddXY(ngay.Day, doanhThu);
                lineSeries.Points.AddXY(ngay.Day, doanhThu);
            }

            // Thêm series vào chart
            chartBieuDoKetHop.Series.Add(colSeries);
            chartBieuDoKetHop.Series.Add(lineSeries);

            // Tiêu đề
            chartBieuDoKetHop.Titles.Add("Biểu đồ kết hợp: Doanh thu theo từng ngày trong tháng " + thang + "/"+nam);
            chartBieuDoKetHop.Titles[0].Font = new System.Drawing.Font("Arial", 11);
        }

        private void UcThongKe_BaoCao_Load(object sender, EventArgs e)
        {
            CapNhatThongKe(DateTime.Now.Month, DateTime.Now.Year);
            CapNhatThongKe_SP(DateTime.Now.Month, DateTime.Now.Year);

            if(dgvDoanhThu_LoaiSP != null || dgvDoanhThu_LoaiSP.Rows.Count > 0)
            {
                VeBieuDoTyLe();
            }

            txtThang.Text = DateTime.Now.Month.ToString();
            txtNam.Text = DateTime.Now.Year.ToString();
            txtThang_TKSP.Text= DateTime.Now.Month.ToString();
            txtNam_TKSP.Text= DateTime.Now.Year.ToString();

            lbNgayHienTai.Text = "Ngày: " + DateTime.Today.ToString("dd/MM/yyyy");
            lbTongDT_Ngay.Text = thongkeBL.LayTongDoanhThu(0,0).ToString("N2") + " VNĐ";
            lbSoDonHang.Text = thongkeBL.LayTongHoaDon(0, 0).ToString();
            lbLoiNhuan.Text = (thongkeBL.LayTongDoanhThu(0, 0) - thongkeBL.LayTongTienNhap(0,0) ).ToString("N2");

            DataTable dt_doanhthu_ngay = thongkeBL.LayDT_Ngay(DateTime.Now.Month, DateTime.Now.Year);
            if(dt_doanhthu_ngay != null || dt_doanhthu_ngay.Rows.Count > 0)
            {
                VeBieuDoKetHop(dt_doanhthu_ngay, DateTime.Now.Month, DateTime.Now.Year);
            }    
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtThang.Text))
                {
                    if (string.IsNullOrEmpty(txtNam.Text))
                    {
                        CapNhatThongKe(DateTime.Now.Month, DateTime.Now.Year);
                        if (dgvDoanhThu_LoaiSP != null || dgvDoanhThu_LoaiSP.Rows.Count > 0)
                        {
                            VeBieuDoTyLe();
                        }

                        DataTable dt_doanhthu_ngay = thongkeBL.LayDT_Ngay(DateTime.Now.Month, DateTime.Now.Year);
                        if (dt_doanhthu_ngay != null || dt_doanhthu_ngay.Rows.Count > 0)
                        {
                            VeBieuDoKetHop(dt_doanhthu_ngay, DateTime.Now.Month, DateTime.Now.Year);
                        }
                        txtThang.Text = DateTime.Now.Month.ToString();
                        txtNam.Text = DateTime.Now.Year.ToString();
                    }
                    else
                    {
                        CapNhatThongKe(0, Convert.ToInt32(txtNam.Text));
                        if (dgvDoanhThu_LoaiSP != null || dgvDoanhThu_LoaiSP.Rows.Count > 0)
                        {
                            VeBieuDoTyLe();
                        }

                        DataTable dt_doanhthu_ngay = thongkeBL.LayDT_Ngay(DateTime.Now.Month, DateTime.Now.Year);
                        if (dt_doanhthu_ngay != null || dt_doanhthu_ngay.Rows.Count > 0)
                        {
                            VeBieuDoKetHop(dt_doanhthu_ngay, DateTime.Now.Month, DateTime.Now.Year);
                        }
                    }
                }
                else if (string.IsNullOrEmpty(txtNam.Text))
                {
                    MessageBox.Show("Vui lòng nhập thêm năm để thống kê!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    CapNhatThongKe(Convert.ToInt32(txtThang.Text), Convert.ToInt32(txtNam.Text));
                    if (dgvDoanhThu_LoaiSP != null || dgvDoanhThu_LoaiSP.Rows.Count > 0)
                    {
                        VeBieuDoTyLe();
                    }

                    DataTable dt_doanhthu_ngay = thongkeBL.LayDT_Ngay(Convert.ToInt32(txtThang.Text), Convert.ToInt32(txtNam.Text));
                    if (dt_doanhthu_ngay != null || dt_doanhthu_ngay.Rows.Count > 0)
                    {
                        VeBieuDoKetHop(dt_doanhthu_ngay, Convert.ToInt32(txtThang.Text), Convert.ToInt32(txtNam.Text));
                    }
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }  
        }

        private void txtThang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNam_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private string BaoCaoThongKe_Excel(Panel pnBieuDoTyLe, Panel pnBieuDoKetHop,
                                  DataGridView dgvDoanhThu_LoaiSP,
                                  string thang, string nam,
                                  string tongDT, string tongHD, string tongLN)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "BaoCaoThongKe" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx"; ;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("BaoCao");

                    int row = 1;

                    // Thông tin chung
                    worksheet.Cell(row++, 1).Value = "BÁO CÁO THỐNG KÊ";
                    worksheet.Cell(row++, 1).Value = "Tháng: " + thang;
                    worksheet.Cell(row++, 1).Value = "Năm: " + nam;
                    worksheet.Cell(row++, 1).Value = "Tổng doanh thu: " + tongDT;
                    worksheet.Cell(row++, 1).Value = "Tổng số đơn hàng: " + tongHD;
                    worksheet.Cell(row++, 1).Value = "Tổng lợi nhuận: " + tongLN;
                    row += 2;

                    worksheet.Cell(row++, 1).Value = "Doanh thu bán hàng theo từng loại sản phẩm";
                    // Xuất bảng từ DataGridView
                    for (int col = 0; col < dgvDoanhThu_LoaiSP.Columns.Count; col++)
                    {
                        worksheet.Cell(row, col + 1).Value = dgvDoanhThu_LoaiSP.Columns[col].HeaderText;
                        worksheet.Cell(row, col + 1).Style.Font.Bold = true;
                    }
                    row++;

                    for (int i = 0; i < dgvDoanhThu_LoaiSP.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvDoanhThu_LoaiSP.Columns.Count; j++)
                        {
                            worksheet.Cell(row + i, j + 1).Value = dgvDoanhThu_LoaiSP.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents();
                    row += dgvDoanhThu_LoaiSP.Rows.Count + 2;

                    // Dán hình Panel vào Excel
                    DanBieuDoVaoExcel(pnBieuDoTyLe, worksheet, row, 1);
                    row += 20;
                    DanBieuDoVaoExcel(pnBieuDoKetHop, worksheet, row, 1);

                    // Lưu file
                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("In báo cáo Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return saveFileDialog.FileName;   // Trả về đường dẫn file Excel
            }

            return null;   // Nếu người dùng bấm Cancel
        }


        private void DanBieuDoVaoExcel(Panel panel, IXLWorksheet worksheet, int row, int col)
        {
            using (Bitmap bmp = new Bitmap(panel.Width, panel.Height))
            {
                panel.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                using (MemoryStream ms = new MemoryStream())
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    ms.Position = 0;

                    var picture = worksheet.AddPicture(ms)
                                           .MoveTo(worksheet.Cell(row, col));
                    //picture.Scale(0.6); // Thu nhỏ ảnh nếu cần
                }
            }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtThang.Text) || string.IsNullOrEmpty(txtNam.Text))
            {
                MessageBox.Show("Thông tin tháng và năm thống kê không rõ ràng, KHÔNG thể in báo cáo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filePath=BaoCaoThongKe_Excel(pnBieuDoTron, pnBieuDoKetHop, dgvDoanhThu_LoaiSP,
                txtThang.Text, txtNam.Text, lbTongDoanhThu.Text, lbTongHoaDon.Text, lbTongLoiNhuan.Text);
        }

        private bool SendMail(Panel pnBieuDoTyLe, Panel pnBieuDoKetHop,
                                  DataGridView dgvDoanhThu_LoaiSP,
                                  string thang, string nam,
                                  string tongDT, string tongHD, string tongLN)
        {
            try
            {
                string filePath = BaoCaoThongKe_Excel(pnBieuDoTyLe,pnBieuDoKetHop,
                                   dgvDoanhThu_LoaiSP,
                                   thang, nam,
                                   tongDT, tongHD, tongLN);

                string fromAdd = "phamthithuyan.k55ltk@gmail.com";
                string toAdd = TaiKhoanHienTai.TaiKhoan.mail;
                string subject = "Báo cáo doanh thu bán hàng tháng "+thang + "/" + nam + " (Excel)";
                string body = "File Excel báo cáo doanh thu bán hàng được đính kèm.";

                using (MailMessage mail = new MailMessage(fromAdd, toAdd, subject, body))
                {
                    using (Attachment attachment = new Attachment(filePath))
                    {
                        mail.Attachments.Add(attachment);

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential(fromAdd, "kgwp ihub jykp mzwe");
                            smtp.EnableSsl = true;

                            smtp.Send(mail);
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

        private void btnGuiMail_Click(object sender, EventArgs e)
        {
            // Gọi hàm gửi mail
            bool result = SendMail(pnBieuDoTron, pnBieuDoKetHop,
                                   dgvDoanhThu_LoaiSP,
                                   txtThang.Text, txtNam.Text,
                                  lbTongDoanhThu.Text, lbTongHoaDon.Text, lbTongLoiNhuan.Text);

            // Kiểm tra kết quả và thông báo
            if (result)
            {
                MessageBox.Show("Gửi mail thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gửi mail thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void VeBieuDoTron(Chart bieuDo, string s, DataTable dt, string nhan,string giaTri, string tenBieuDo)
        {
            // Xóa dữ liệu cũ nếu có
            bieuDo.Series.Clear();
            bieuDo.ChartAreas.Clear();
            bieuDo.Titles.Clear();

            // Tạo chart area
            ChartArea chartArea = new ChartArea("ChartArea1");
            bieuDo.ChartAreas.Add(chartArea);

            // Tạo series cho biểu đồ tròn
            Series series = new Series(s);
            series.ChartType = SeriesChartType.Pie; // dạng Pie Chart
            series.Font = new Font("Arial", 6, FontStyle.Bold);

            // nếu chưa có cột tyLe thì thêm vào
            if (!dt.Columns.Contains("tyLeTK"))
            {
                dt.Columns.Add("tyLeTK", typeof(decimal));
            }
            decimal tong = 0;
            foreach (DataRow row in dt.Rows)
            {
                tong += Convert.ToDecimal(row[giaTri]);
            }
            // duyệt từng dòng và tính tỷ lệ
            foreach (DataRow row in dt.Rows)
            {
                if (row[giaTri] != DBNull.Value && tong > 0)
                {

                    decimal x = Convert.ToDecimal(row[giaTri]);
                    decimal tyLe = Math.Round((x / tong) * 100, 2);
                    row["tyLeTK"] = tyLe;
                }
                else
                {
                    row["tyLeTK"] = "0";
                }
            }
            // Lấy dữ liệu từ dt
            foreach (DataRow row in dt.Rows)
            {
                if (row[nhan] != null && row["tyLeTK"] != null)
                {
                    string tenNhan = row[nhan].ToString();
                    if (decimal.TryParse(row["tyLeTK"].ToString(), out decimal tyLe))
                    {
                        series.Points.AddXY(tenNhan, tyLe);
                    }
                }
            }

            // Thêm series vào chart
            bieuDo.Series.Add(series);

            // Hiển thị % trên biểu đồ
            series.Label = "#PERCENT{P2}";   // hiển thị tỷ lệ %
            series.LegendText = "#VALX";     // hiển thị tên nhãn trong chú thích

            // Thêm title
            bieuDo.Titles.Add(tenBieuDo);
            bieuDo.Titles[0].Font = new System.Drawing.Font("Arial", 11);

        }

        private void VeBieuCot(Chart bieuDo, string s, DataTable dt, string nhan, string giaTri, string tenBieuDo)
        {
            // Xóa dữ liệu cũ nếu có
            bieuDo.Series.Clear();
            bieuDo.ChartAreas.Clear();
            bieuDo.Titles.Clear();

            // Thêm ChartArea
            ChartArea chartArea = new ChartArea("ChartArea1");
            bieuDo.ChartAreas.Add(chartArea);

            // Series: Cột 
            Series colSeries = new Series(s);
            colSeries.ChartType = SeriesChartType.Column;
            colSeries.Font= new Font("Arial", 8, FontStyle.Bold);
            colSeries.BorderWidth = 2;            

            // Thêm dữ liệu từ DataTable vào chart
            foreach (DataRow row in dt.Rows)
            {
                string tenNhan = row[nhan].ToString();
                int x = Convert.ToInt32(row[giaTri]);

                colSeries.Points.AddXY(tenNhan, x);
                
            }

            // Thêm series vào chart
            bieuDo.Series.Add(colSeries);
          

            // Tiêu đề
            bieuDo.Titles.Add(tenBieuDo);
            bieuDo.Titles[0].Font = new System.Drawing.Font("Arial", 11);
        }


        private void CapNhatThongKe_SP(int thang, int nam)
        {
            DataTable dt = thongkeBL.ThongKeSLSanPham(thang, nam);
            dgvThongKeSP.DataSource = dt;

            VeBieuCot(chartSanPham, "Số lượng", dt, "tenSP", "soLuongBan", "Biểu đồ số lượng đã bán của các sản phẩm");

            DataTable dt_NhapKho = thongkeBL.ThongKeNhapKhoSanPham(thang, nam);
            VeBieuCot(chartSanPham_NhapKho, "Số lượng", dt_NhapKho, "tenSP", "soLuongNhap", "Biểu đồ số lượng được nhập của các sản phẩm");


            DataTable dt_HangSX = thongkeBL.ThongKeHangSX(thang, nam);
            VeBieuDoTron(chartHangSX, "Tỷ lệ sản phẩm đã bán của hãng sản xuất", dt_HangSX,
                "tenHang", "soLuong", "Biểu đồ tỷ lệ sản phẩm đã bán của các hãng sản xuất ");

            DataTable dt_LoaiSP = ((DataTable)dgvDoanhThu_LoaiSP.DataSource).Copy();
            VeBieuDoTron(chartLoaiSP, "Tỷ lệ sản phẩm đã bán của loại sản phẩm", dt_LoaiSP,
                "loaiSP", "soLuongBan", "Biểu đồ tỷ lệ sản phẩm đã bán của các loại sản phẩm ");


        }

        private void btnThongKe_SP_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(txtThang_TKSP.Text))
                {
                    if(string.IsNullOrEmpty(txtNam_TKSP.Text))
                    {
                        CapNhatThongKe_SP(0, 0);
                    }
                    else
                    {
                        CapNhatThongKe_SP(0, Convert.ToInt32(txtNam_TKSP.Text));
                    }    
                }
                else if(string.IsNullOrEmpty(txtNam_TKSP.Text))
                {
                    MessageBox.Show("Vui lòng nhập thêm năm để thống kê!!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    CapNhatThongKe_SP(Convert.ToInt32(txtThang_TKSP.Text), Convert.ToInt32(txtNam_TKSP.Text));
                }    
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }


        private string BaoCaoThongKeSanPham_Excel(Panel pnBieuDo, Panel pnBieuDo2,
                                 DataGridView dgvThongKeSP,
                                 string thang, string nam)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "BaoCaoThongKeSanPham" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("BaoCao");

                    int row = 1;

                    // Thông tin chung
                    worksheet.Cell(row++, 1).Value = "BÁO CÁO THỐNG KÊ SẢN PHẨM";
                    worksheet.Cell(row++, 1).Value = "Tháng: " + thang;
                    worksheet.Cell(row++, 1).Value = "Năm: " + nam;
                    row += 2;

                    worksheet.Cell(row++, 2).Value = "Thông tin tồn kho và số lượng đã bán của các sản phẩm";
                    row += 1;
                    // Xuất bảng từ DataGridView
                    for (int col = 0; col < dgvThongKeSP.Columns.Count; col++)
                    {
                        worksheet.Cell(row, col + 1).Value = dgvThongKeSP.Columns[col].HeaderText;
                        worksheet.Cell(row, col + 1).Style.Font.Bold = true;
                    }
                    row++;

                    for (int i = 0; i < dgvThongKeSP.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvThongKeSP.Columns.Count; j++)
                        {
                            worksheet.Cell(row + i, j + 1).Value = dgvThongKeSP.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    worksheet.Columns().AdjustToContents();
                    row += dgvThongKeSP.Rows.Count + 2;

                    // Dán hình Panel vào Excel
                    DanBieuDoVaoExcel(pnBieuDo2, worksheet, row, 1);
                    DanBieuDoVaoExcel(pnBieuDo, worksheet, row, 3);
                   
                    

                    // Lưu file
                    workbook.SaveAs(saveFileDialog.FileName);
                }

                MessageBox.Show("In báo cáo Excel thành công!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return saveFileDialog.FileName;   // Trả về đường dẫn file Excel
            }

            return null;   // Nếu người dùng bấm Cancel
        }

        private void btnInBaoCao_SP_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtThang_TKSP.Text) || string.IsNullOrEmpty(txtNam_TKSP.Text))
            {
                MessageBox.Show("Thông tin tháng và năm thống kê không rõ ràng, KHÔNG thể in báo cáo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string filePath = BaoCaoThongKeSanPham_Excel(pnBieuDo, pnBieuDo2, dgvThongKeSP, txtThang_TKSP.Text, txtNam_TKSP.Text);
        }


        private bool SendMailBaoCaoSP(Panel pnBieuDo, Panel pnBieuDo2,
                                   DataGridView dgvThongKeSP,
                                   string thang, string nam)
        {
            try
            {
                string filePath = BaoCaoThongKeSanPham_Excel(pnBieuDo, pnBieuDo2, dgvThongKeSP, thang, nam);
                string fromAdd = "phamthithuyan.k55ltk@gmail.com";
                string toAdd = TaiKhoanHienTai.TaiKhoan.mail;
                string subject = "Báo cáo thông tin tồn kho và số lượng đã bán của các sản phẩm " + thang + "/" + nam + " (Excel)";
                string body = "File Excel báo cáo thông tin tồn kho và số lượng đã bán của các sản phẩm được đính kèm.";

                using (MailMessage mail = new MailMessage(fromAdd, toAdd, subject, body))
                {
                    using (Attachment attachment = new Attachment(filePath))
                    {
                        mail.Attachments.Add(attachment);

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential(fromAdd, "kgwp ihub jykp mzwe");
                            smtp.EnableSsl = true;

                            smtp.Send(mail);
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

        private void btnGuiMai_SP_Click(object sender, EventArgs e)
        {
            // Gọi hàm gửi mail
            bool result = SendMailBaoCaoSP(pnBieuDo, pnBieuDo2,
                                   dgvThongKeSP,
                                   txtThang_TKSP.Text, txtNam_TKSP.Text);

            // Kiểm tra kết quả và thông báo
            if (result)
            {
                MessageBox.Show("Gửi mail thành công!", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Gửi mail thất bại!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtThang_TKSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNam_TKSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
