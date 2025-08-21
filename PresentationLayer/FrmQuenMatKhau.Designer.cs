namespace PresentationLayer
{
    partial class FrmQuenMatKhau
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnMain = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnGuiMaXN = new System.Windows.Forms.Button();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnTieuDe = new System.Windows.Forms.Panel();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.pnMain.SuspendLayout();
            this.pnTieuDe.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMain
            // 
            this.pnMain.Controls.Add(this.label4);
            this.pnMain.Controls.Add(this.btnThoat);
            this.pnMain.Controls.Add(this.btnGuiMaXN);
            this.pnMain.Controls.Add(this.txtTenDN);
            this.pnMain.Controls.Add(this.label2);
            this.pnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnMain.Location = new System.Drawing.Point(0, 67);
            this.pnMain.Name = "pnMain";
            this.pnMain.Size = new System.Drawing.Size(536, 254);
            this.pnMain.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(292, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "*";
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Coral;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.ForeColor = System.Drawing.Color.White;
            this.btnThoat.Location = new System.Drawing.Point(44, 192);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(149, 39);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnGuiMaXN
            // 
            this.btnGuiMaXN.BackColor = System.Drawing.Color.Teal;
            this.btnGuiMaXN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiMaXN.ForeColor = System.Drawing.Color.White;
            this.btnGuiMaXN.Location = new System.Drawing.Point(312, 192);
            this.btnGuiMaXN.Name = "btnGuiMaXN";
            this.btnGuiMaXN.Size = new System.Drawing.Size(183, 39);
            this.btnGuiMaXN.TabIndex = 4;
            this.btnGuiMaXN.Text = "Gửi mã xác nhận";
            this.btnGuiMaXN.UseVisualStyleBackColor = false;
            this.btnGuiMaXN.Click += new System.EventHandler(this.btnGuiMaXN_Click);
            // 
            // txtTenDN
            // 
            this.txtTenDN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDN.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtTenDN.Location = new System.Drawing.Point(141, 89);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(253, 30);
            this.txtTenDN.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(136, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên đăng nhập ";
            // 
            // pnTieuDe
            // 
            this.pnTieuDe.Controls.Add(this.lbTieuDe);
            this.pnTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnTieuDe.Name = "pnTieuDe";
            this.pnTieuDe.Size = new System.Drawing.Size(536, 67);
            this.pnTieuDe.TabIndex = 2;
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbTieuDe.Location = new System.Drawing.Point(163, 18);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(186, 29);
            this.lbTieuDe.TabIndex = 0;
            this.lbTieuDe.Text = "Quên mật khẩu?";
            // 
            // FrmQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 321);
            this.Controls.Add(this.pnMain);
            this.Controls.Add(this.pnTieuDe);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmQuenMatKhau";
            this.Text = "Quên mật khẩu";
            this.pnMain.ResumeLayout(false);
            this.pnMain.PerformLayout();
            this.pnTieuDe.ResumeLayout(false);
            this.pnTieuDe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnGuiMaXN;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnTieuDe;
        private System.Windows.Forms.Label lbTieuDe;
    }
}