namespace PresentationLayer.Controllers
{
    partial class UcKhuyenMai
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGiamGia = new System.Windows.Forms.TextBox();
            this.txtTenKM = new System.Windows.Forms.TextBox();
            this.btnCapNhatKM = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnHuyThemKM = new System.Windows.Forms.Button();
            this.btnThemKM = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvKhuyenMai = new System.Windows.Forms.DataGridView();
            this.maKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyLeGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loaiKM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayBatDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ngayKetThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.dtNgayBatDau = new System.Windows.Forms.DateTimePicker();
            this.dtNgayKetThuc = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbLoaiKM = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).BeginInit();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(684, 473);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(134, 25);
            this.label12.TabIndex = 177;
            this.label12.Text = "Ngày bắt đầu:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(684, 581);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 25);
            this.label10.TabIndex = 174;
            this.label10.Text = "Ghi chú:";
            // 
            // txtGiamGia
            // 
            this.txtGiamGia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiamGia.ForeColor = System.Drawing.Color.Navy;
            this.txtGiamGia.Location = new System.Drawing.Point(228, 527);
            this.txtGiamGia.MaxLength = 10;
            this.txtGiamGia.Name = "txtGiamGia";
            this.txtGiamGia.Size = new System.Drawing.Size(86, 28);
            this.txtGiamGia.TabIndex = 173;
            this.txtGiamGia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGiamGia_KeyPress);
            // 
            // txtTenKM
            // 
            this.txtTenKM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKM.ForeColor = System.Drawing.Color.Navy;
            this.txtTenKM.Location = new System.Drawing.Point(228, 475);
            this.txtTenKM.Name = "txtTenKM";
            this.txtTenKM.Size = new System.Drawing.Size(268, 28);
            this.txtTenKM.TabIndex = 170;
            // 
            // btnCapNhatKM
            // 
            this.btnCapNhatKM.BackColor = System.Drawing.Color.Blue;
            this.btnCapNhatKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatKM.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatKM.Location = new System.Drawing.Point(472, 655);
            this.btnCapNhatKM.Name = "btnCapNhatKM";
            this.btnCapNhatKM.Size = new System.Drawing.Size(134, 34);
            this.btnCapNhatKM.TabIndex = 169;
            this.btnCapNhatKM.Text = "Cập nhật";
            this.btnCapNhatKM.UseVisualStyleBackColor = false;
            this.btnCapNhatKM.Click += new System.EventHandler(this.btnCapNhatKM_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(53, 475);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 25);
            this.label3.TabIndex = 168;
            this.label3.Text = "Tên khuyến mãi:";
            // 
            // btnHuyThemKM
            // 
            this.btnHuyThemKM.BackColor = System.Drawing.Color.Red;
            this.btnHuyThemKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThemKM.ForeColor = System.Drawing.Color.White;
            this.btnHuyThemKM.Location = new System.Drawing.Point(51, 655);
            this.btnHuyThemKM.Name = "btnHuyThemKM";
            this.btnHuyThemKM.Size = new System.Drawing.Size(134, 34);
            this.btnHuyThemKM.TabIndex = 167;
            this.btnHuyThemKM.Text = "Hủy";
            this.btnHuyThemKM.UseVisualStyleBackColor = false;
            this.btnHuyThemKM.Click += new System.EventHandler(this.btnHuyThemKM_Click);
            // 
            // btnThemKM
            // 
            this.btnThemKM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnThemKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemKM.ForeColor = System.Drawing.Color.White;
            this.btnThemKM.Location = new System.Drawing.Point(897, 655);
            this.btnThemKM.Name = "btnThemKM";
            this.btnThemKM.Size = new System.Drawing.Size(134, 34);
            this.btnThemKM.TabIndex = 166;
            this.btnThemKM.Text = "Thêm";
            this.btnThemKM.UseVisualStyleBackColor = false;
            this.btnThemKM.Click += new System.EventHandler(this.btnThemKM_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(53, 579);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 25);
            this.label4.TabIndex = 164;
            this.label4.Text = "Loại khuyến mãi:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(684, 527);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 25);
            this.label5.TabIndex = 162;
            this.label5.Text = "Ngày kết thúc:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.ForeColor = System.Drawing.Color.Navy;
            this.txtGhiChu.Location = new System.Drawing.Point(843, 581);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(243, 28);
            this.txtGhiChu.TabIndex = 161;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(53, 526);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 160;
            this.label6.Text = "Giảm giá: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(465, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 25);
            this.label7.TabIndex = 159;
            this.label7.Text = "Quản lý khuyến mãi";
            // 
            // dgvKhuyenMai
            // 
            this.dgvKhuyenMai.AllowUserToAddRows = false;
            this.dgvKhuyenMai.AllowUserToDeleteRows = false;
            this.dgvKhuyenMai.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhuyenMai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhuyenMai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKhuyenMai.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maKM,
            this.tenKM,
            this.tyLeGiam,
            this.loaiKM,
            this.ngayBatDau,
            this.ngayKetThuc,
            this.ghiChu,
            this.delete});
            this.dgvKhuyenMai.Location = new System.Drawing.Point(23, 61);
            this.dgvKhuyenMai.Name = "dgvKhuyenMai";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhuyenMai.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKhuyenMai.RowHeadersWidth = 51;
            this.dgvKhuyenMai.RowTemplate.Height = 24;
            this.dgvKhuyenMai.Size = new System.Drawing.Size(1092, 331);
            this.dgvKhuyenMai.TabIndex = 158;
            this.dgvKhuyenMai.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhuyenMai_CellContentClick);
            this.dgvKhuyenMai.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvKhuyenMai_RowHeaderMouseClick);
            // 
            // maKM
            // 
            this.maKM.DataPropertyName = "maKM";
            this.maKM.HeaderText = "Mã KM";
            this.maKM.MinimumWidth = 6;
            this.maKM.Name = "maKM";
            this.maKM.Width = 45;
            // 
            // tenKM
            // 
            this.tenKM.DataPropertyName = "tenKM";
            this.tenKM.HeaderText = "Tên khuyến mãi";
            this.tenKM.MinimumWidth = 6;
            this.tenKM.Name = "tenKM";
            this.tenKM.Width = 180;
            // 
            // tyLeGiam
            // 
            this.tyLeGiam.DataPropertyName = "tyLeGiam";
            this.tyLeGiam.FillWeight = 50F;
            this.tyLeGiam.HeaderText = "Giảm giá";
            this.tyLeGiam.MinimumWidth = 6;
            this.tyLeGiam.Name = "tyLeGiam";
            this.tyLeGiam.Width = 50;
            // 
            // loaiKM
            // 
            this.loaiKM.DataPropertyName = "loaiKM";
            this.loaiKM.HeaderText = "Loại KM";
            this.loaiKM.MinimumWidth = 6;
            this.loaiKM.Name = "loaiKM";
            this.loaiKM.Width = 90;
            // 
            // ngayBatDau
            // 
            this.ngayBatDau.DataPropertyName = "ngayBatDau";
            this.ngayBatDau.HeaderText = "Ngày bắt đầu";
            this.ngayBatDau.MinimumWidth = 6;
            this.ngayBatDau.Name = "ngayBatDau";
            this.ngayBatDau.Width = 115;
            // 
            // ngayKetThuc
            // 
            this.ngayKetThuc.DataPropertyName = "ngayKetThuc";
            this.ngayKetThuc.HeaderText = "Ngày kết thúc";
            this.ngayKetThuc.MinimumWidth = 6;
            this.ngayKetThuc.Name = "ngayKetThuc";
            this.ngayKetThuc.Width = 115;
            // 
            // ghiChu
            // 
            this.ghiChu.DataPropertyName = "ghiChu";
            this.ghiChu.HeaderText = "Ghi chú";
            this.ghiChu.MinimumWidth = 6;
            this.ghiChu.Name = "ghiChu";
            this.ghiChu.Width = 130;
            // 
            // delete
            // 
            this.delete.DataPropertyName = "delete";
            this.delete.HeaderText = "";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.Width = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(439, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 25);
            this.label1.TabIndex = 179;
            this.label1.Text = "Danh sách khuyến mãi";
            // 
            // dtNgayBatDau
            // 
            this.dtNgayBatDau.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayBatDau.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtNgayBatDau.CalendarTitleBackColor = System.Drawing.Color.MidnightBlue;
            this.dtNgayBatDau.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayBatDau.Location = new System.Drawing.Point(843, 473);
            this.dtNgayBatDau.Name = "dtNgayBatDau";
            this.dtNgayBatDau.Size = new System.Drawing.Size(230, 27);
            this.dtNgayBatDau.TabIndex = 180;
            // 
            // dtNgayKetThuc
            // 
            this.dtNgayKetThuc.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayKetThuc.CalendarForeColor = System.Drawing.Color.MidnightBlue;
            this.dtNgayKetThuc.CalendarTitleBackColor = System.Drawing.Color.MidnightBlue;
            this.dtNgayKetThuc.CalendarTitleForeColor = System.Drawing.Color.MidnightBlue;
            this.dtNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtNgayKetThuc.Location = new System.Drawing.Point(843, 527);
            this.dtNgayKetThuc.Name = "dtNgayKetThuc";
            this.dtNgayKetThuc.Size = new System.Drawing.Size(230, 27);
            this.dtNgayKetThuc.TabIndex = 181;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(319, 529);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 25);
            this.label2.TabIndex = 182;
            this.label2.Text = "%";
            // 
            // cbLoaiKM
            // 
            this.cbLoaiKM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoaiKM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLoaiKM.ForeColor = System.Drawing.Color.Navy;
            this.cbLoaiKM.FormattingEnabled = true;
            this.cbLoaiKM.Items.AddRange(new object[] {
            "Sản phẩm",
            "Hóa đơn"});
            this.cbLoaiKM.Location = new System.Drawing.Point(228, 583);
            this.cbLoaiKM.Name = "cbLoaiKM";
            this.cbLoaiKM.Size = new System.Drawing.Size(150, 28);
            this.cbLoaiKM.TabIndex = 219;
            // 
            // UcKhuyenMai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbLoaiKM);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtNgayKetThuc);
            this.Controls.Add(this.dtNgayBatDau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtGiamGia);
            this.Controls.Add(this.txtTenKM);
            this.Controls.Add(this.btnCapNhatKM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHuyThemKM);
            this.Controls.Add(this.btnThemKM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvKhuyenMai);
            this.Name = "UcKhuyenMai";
            this.Size = new System.Drawing.Size(1150, 738);
            this.Load += new System.EventHandler(this.UcKhuyenMai_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhuyenMai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGiamGia;
        private System.Windows.Forms.TextBox txtTenKM;
        private System.Windows.Forms.Button btnCapNhatKM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnHuyThemKM;
        private System.Windows.Forms.Button btnThemKM;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvKhuyenMai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtNgayBatDau;
        private System.Windows.Forms.DateTimePicker dtNgayKetThuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbLoaiKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn maKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn tyLeGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn loaiKM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayBatDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn ngayKetThuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghiChu;
        private System.Windows.Forms.DataGridViewImageColumn delete;
    }
}
