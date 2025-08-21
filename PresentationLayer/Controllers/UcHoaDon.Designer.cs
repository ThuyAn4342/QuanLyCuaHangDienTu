namespace PresentationLayer.Controllers
{
    partial class UcHoaDon
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.label13 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.dtNgay = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.btnTimKiemHD = new System.Windows.Forms.Button();
            this.btnHienThi_All_HD = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvChiTietHD = new System.Windows.Forms.DataGridView();
            this.maSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyLeGiamGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInHD = new System.Windows.Forms.Button();
            this.lbMaHD = new System.Windows.Forms.Label();
            this.lbTenNV = new System.Windows.Forms.Label();
            this.lbTenKH = new System.Windows.Forms.Label();
            this.lbPhuongThucTT = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbSoTienThanhToan = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbKhuyenMai = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbNgayLapHD = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayLapHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phuongthucTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maHD,
            this.ngayLapHD,
            this.maNV,
            this.maKH,
            this.phuongthucTT,
            this.delete});
            this.dgvHoaDon.Location = new System.Drawing.Point(8, 206);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(548, 466);
            this.dgvHoaDon.TabIndex = 159;
            this.dgvHoaDon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoaDon_CellContentClick);
            this.dgvHoaDon.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHoaDon_RowHeaderMouseClick);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label13.Location = new System.Drawing.Point(567, -12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(3, 750);
            this.label13.TabIndex = 182;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Navy;
            this.label22.Location = new System.Drawing.Point(169, 14);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(218, 29);
            this.label22.TabIndex = 183;
            this.label22.Text = "Danh sách hóa đơn";
            // 
            // dtNgay
            // 
            this.dtNgay.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtNgay.CalendarTitleBackColor = System.Drawing.Color.MidnightBlue;
            this.dtNgay.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgay.Location = new System.Drawing.Point(102, 79);
            this.dtNgay.Name = "dtNgay";
            this.dtNgay.Size = new System.Drawing.Size(285, 27);
            this.dtNgay.TabIndex = 186;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(17, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 25);
            this.label12.TabIndex = 185;
            this.label12.Text = "Ngày:";
            // 
            // btnTimKiemHD
            // 
            this.btnTimKiemHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnTimKiemHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiemHD.ForeColor = System.Drawing.Color.White;
            this.btnTimKiemHD.Location = new System.Drawing.Point(423, 79);
            this.btnTimKiemHD.Name = "btnTimKiemHD";
            this.btnTimKiemHD.Size = new System.Drawing.Size(134, 34);
            this.btnTimKiemHD.TabIndex = 184;
            this.btnTimKiemHD.Text = "Tìm kiếm";
            this.btnTimKiemHD.UseVisualStyleBackColor = false;
            this.btnTimKiemHD.Click += new System.EventHandler(this.btnTimKiemHD_Click);
            // 
            // btnHienThi_All_HD
            // 
            this.btnHienThi_All_HD.BackColor = System.Drawing.Color.SeaGreen;
            this.btnHienThi_All_HD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHienThi_All_HD.ForeColor = System.Drawing.Color.White;
            this.btnHienThi_All_HD.Location = new System.Drawing.Point(423, 132);
            this.btnHienThi_All_HD.Name = "btnHienThi_All_HD";
            this.btnHienThi_All_HD.Size = new System.Drawing.Size(134, 34);
            this.btnHienThi_All_HD.TabIndex = 187;
            this.btnHienThi_All_HD.Text = "Tất cả";
            this.btnHienThi_All_HD.UseVisualStyleBackColor = false;
            this.btnHienThi_All_HD.Click += new System.EventHandler(this.btnHienThi_All_HD_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(725, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 29);
            this.label1.TabIndex = 188;
            this.label1.Text = "Thông tin chi tiết hóa đơn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(592, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 25);
            this.label3.TabIndex = 191;
            this.label3.Text = "Mã hóa đơn: ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(592, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 25);
            this.label4.TabIndex = 190;
            this.label4.Text = "Khách hàng:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(592, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 25);
            this.label6.TabIndex = 189;
            this.label6.Text = "Nhân viên:";
            // 
            // dgvChiTietHD
            // 
            this.dgvChiTietHD.AllowUserToAddRows = false;
            this.dgvChiTietHD.AllowUserToDeleteRows = false;
            this.dgvChiTietHD.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvChiTietHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maSP,
            this.tenSP,
            this.soLuong,
            this.donGiaBan,
            this.tyLeGiamGia,
            this.thanhTien});
            this.dgvChiTietHD.Location = new System.Drawing.Point(582, 238);
            this.dgvChiTietHD.Name = "dgvChiTietHD";
            this.dgvChiTietHD.RowHeadersWidth = 51;
            this.dgvChiTietHD.RowTemplate.Height = 24;
            this.dgvChiTietHD.Size = new System.Drawing.Size(553, 284);
            this.dgvChiTietHD.TabIndex = 195;
            // 
            // maSP
            // 
            this.maSP.DataPropertyName = "maSP";
            this.maSP.HeaderText = "Mã SP";
            this.maSP.MinimumWidth = 6;
            this.maSP.Name = "maSP";
            this.maSP.Width = 35;
            // 
            // tenSP
            // 
            this.tenSP.DataPropertyName = "tenSP";
            this.tenSP.HeaderText = "Sản phẩm";
            this.tenSP.MinimumWidth = 6;
            this.tenSP.Name = "tenSP";
            this.tenSP.Width = 102;
            // 
            // soLuong
            // 
            this.soLuong.DataPropertyName = "soLuong";
            this.soLuong.HeaderText = "SL";
            this.soLuong.MinimumWidth = 6;
            this.soLuong.Name = "soLuong";
            this.soLuong.Width = 30;
            // 
            // donGiaBan
            // 
            this.donGiaBan.DataPropertyName = "donGiaBan";
            this.donGiaBan.HeaderText = "Đơn giá";
            this.donGiaBan.MinimumWidth = 6;
            this.donGiaBan.Name = "donGiaBan";
            this.donGiaBan.Width = 75;
            // 
            // tyLeGiamGia
            // 
            this.tyLeGiamGia.DataPropertyName = "tyLeGiamGia";
            this.tyLeGiamGia.HeaderText = "Giảm giá";
            this.tyLeGiamGia.MinimumWidth = 6;
            this.tyLeGiamGia.Name = "tyLeGiamGia";
            this.tyLeGiamGia.Width = 43;
            // 
            // thanhTien
            // 
            this.thanhTien.HeaderText = "Thành tiền";
            this.thanhTien.MinimumWidth = 6;
            this.thanhTien.Name = "thanhTien";
            this.thanhTien.Width = 75;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(753, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 25);
            this.label2.TabIndex = 196;
            this.label2.Text = "Danh sách sản phẩm";
            // 
            // btnInHD
            // 
            this.btnInHD.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnInHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInHD.ForeColor = System.Drawing.Color.White;
            this.btnInHD.Location = new System.Drawing.Point(1007, 690);
            this.btnInHD.Name = "btnInHD";
            this.btnInHD.Size = new System.Drawing.Size(134, 38);
            this.btnInHD.TabIndex = 197;
            this.btnInHD.Text = "In hóa đơn";
            this.btnInHD.UseVisualStyleBackColor = false;
            this.btnInHD.Click += new System.EventHandler(this.btnInHD_Click);
            // 
            // lbMaHD
            // 
            this.lbMaHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaHD.AutoSize = true;
            this.lbMaHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaHD.ForeColor = System.Drawing.Color.Navy;
            this.lbMaHD.Location = new System.Drawing.Point(725, 74);
            this.lbMaHD.Name = "lbMaHD";
            this.lbMaHD.Size = new System.Drawing.Size(23, 25);
            this.lbMaHD.TabIndex = 198;
            this.lbMaHD.Text = "1";
            // 
            // lbTenNV
            // 
            this.lbTenNV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTenNV.AutoSize = true;
            this.lbTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNV.ForeColor = System.Drawing.Color.Navy;
            this.lbTenNV.Location = new System.Drawing.Point(725, 114);
            this.lbTenNV.Name = "lbTenNV";
            this.lbTenNV.Size = new System.Drawing.Size(172, 25);
            this.lbTenNV.TabIndex = 199;
            this.lbTenNV.Text = "Nguyễn Thanh Hà";
            // 
            // lbTenKH
            // 
            this.lbTenKH.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTenKH.AutoSize = true;
            this.lbTenKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenKH.ForeColor = System.Drawing.Color.Navy;
            this.lbTenKH.Location = new System.Drawing.Point(725, 159);
            this.lbTenKH.Name = "lbTenKH";
            this.lbTenKH.Size = new System.Drawing.Size(89, 25);
            this.lbTenKH.TabIndex = 200;
            this.lbTenKH.Text = "Khách lẻ";
            // 
            // lbPhuongThucTT
            // 
            this.lbPhuongThucTT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPhuongThucTT.AutoSize = true;
            this.lbPhuongThucTT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhuongThucTT.ForeColor = System.Drawing.Color.Navy;
            this.lbPhuongThucTT.Location = new System.Drawing.Point(812, 657);
            this.lbPhuongThucTT.Name = "lbPhuongThucTT";
            this.lbPhuongThucTT.Size = new System.Drawing.Size(88, 25);
            this.lbPhuongThucTT.TabIndex = 202;
            this.lbPhuongThucTT.Text = "Tiền mặt";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(578, 657);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(225, 25);
            this.label7.TabIndex = 201;
            this.label7.Text = "Phương thức thanh toán:";
            // 
            // lbTongTien
            // 
            this.lbTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.Color.Navy;
            this.lbTongTien.Location = new System.Drawing.Point(693, 539);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(83, 25);
            this.lbTongTien.TabIndex = 204;
            this.lbTongTien.Text = "100,000";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(578, 539);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 25);
            this.label8.TabIndex = 203;
            this.label8.Text = "Tổng tiền:";
            // 
            // lbSoTienThanhToan
            // 
            this.lbSoTienThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSoTienThanhToan.AutoSize = true;
            this.lbSoTienThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoTienThanhToan.ForeColor = System.Drawing.Color.Navy;
            this.lbSoTienThanhToan.Location = new System.Drawing.Point(809, 617);
            this.lbSoTienThanhToan.Name = "lbSoTienThanhToan";
            this.lbSoTienThanhToan.Size = new System.Drawing.Size(83, 25);
            this.lbSoTienThanhToan.TabIndex = 208;
            this.lbSoTienThanhToan.Text = "100,000";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(578, 578);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 25);
            this.label9.TabIndex = 207;
            this.label9.Text = "Khuyến mãi:";
            // 
            // lbKhuyenMai
            // 
            this.lbKhuyenMai.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbKhuyenMai.AutoSize = true;
            this.lbKhuyenMai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKhuyenMai.ForeColor = System.Drawing.Color.Navy;
            this.lbKhuyenMai.Location = new System.Drawing.Point(710, 578);
            this.lbKhuyenMai.Name = "lbKhuyenMai";
            this.lbKhuyenMai.Size = new System.Drawing.Size(152, 25);
            this.lbKhuyenMai.TabIndex = 206;
            this.lbKhuyenMai.Text = "Khách hàng Vip";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(578, 617);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(218, 25);
            this.label11.TabIndex = 205;
            this.label11.Text = "Số tiền phải thanh toán:";
            // 
            // lbNgayLapHD
            // 
            this.lbNgayLapHD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNgayLapHD.AutoSize = true;
            this.lbNgayLapHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayLapHD.ForeColor = System.Drawing.Color.Navy;
            this.lbNgayLapHD.Location = new System.Drawing.Point(936, 74);
            this.lbNgayLapHD.Name = "lbNgayLapHD";
            this.lbNgayLapHD.Size = new System.Drawing.Size(23, 25);
            this.lbNgayLapHD.TabIndex = 210;
            this.lbNgayLapHD.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(835, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 25);
            this.label10.TabIndex = 209;
            this.label10.Text = "Ngày lập:";
            // 
            // maHD
            // 
            this.maHD.DataPropertyName = "maHD";
            this.maHD.HeaderText = "Mã HD";
            this.maHD.MinimumWidth = 6;
            this.maHD.Name = "maHD";
            this.maHD.Width = 40;
            // 
            // ngayLapHD
            // 
            this.ngayLapHD.DataPropertyName = "ngayLapHD";
            this.ngayLapHD.HeaderText = "Ngày Lập HD";
            this.ngayLapHD.MinimumWidth = 6;
            this.ngayLapHD.Name = "ngayLapHD";
            this.ngayLapHD.Width = 110;
            // 
            // maNV
            // 
            this.maNV.DataPropertyName = "maNV";
            this.maNV.HeaderText = "Mã NV";
            this.maNV.MinimumWidth = 6;
            this.maNV.Name = "maNV";
            this.maNV.Width = 32;
            // 
            // maKH
            // 
            this.maKH.DataPropertyName = "maKH";
            this.maKH.HeaderText = "Mã KH";
            this.maKH.MinimumWidth = 6;
            this.maKH.Name = "maKH";
            this.maKH.Width = 32;
            // 
            // phuongthucTT
            // 
            this.phuongthucTT.DataPropertyName = "phuongthucTT";
            this.phuongthucTT.HeaderText = "Phương thức TT";
            this.phuongthucTT.MinimumWidth = 6;
            this.phuongthucTT.Name = "phuongthucTT";
            this.phuongthucTT.Width = 90;
            // 
            // delete
            // 
            this.delete.HeaderText = "";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.Width = 35;
            // 
            // UcHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbNgayLapHD);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbSoTienThanhToan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbKhuyenMai);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbTongTien);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbPhuongThucTT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTenKH);
            this.Controls.Add(this.lbTenNV);
            this.Controls.Add(this.lbMaHD);
            this.Controls.Add(this.btnInHD);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvChiTietHD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnHienThi_All_HD);
            this.Controls.Add(this.dtNgay);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnTimKiemHD);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "UcHoaDon";
            this.Size = new System.Drawing.Size(1150, 738);
            this.Load += new System.EventHandler(this.UcHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnTimKiemHD;
        private System.Windows.Forms.Button btnHienThi_All_HD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvChiTietHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInHD;
        private System.Windows.Forms.Label lbMaHD;
        private System.Windows.Forms.Label lbTenNV;
        private System.Windows.Forms.Label lbTenKH;
        private System.Windows.Forms.Label lbPhuongThucTT;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn maSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn donGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn tyLeGiamGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhTien;
        private System.Windows.Forms.Label lbSoTienThanhToan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbKhuyenMai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbNgayLapHD;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn maHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayLapHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn maNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn phuongthucTT;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
