using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.QuenMatKhau
{
    public partial class ucMaXacNhan : UserControl
    {
        public ucMaXacNhan()
        {
            InitializeComponent();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                var parentForm = this.FindForm() as FrmQuenMatKhau;
                if (parentForm != null)
                {
                    if (txtMaXacNhan.Text == parentForm.MaXacNhanDaGui)
                    {
                        // Gọi hàm load controller có sẵn trong form
                        parentForm.LoadController(new ucThayDoiMatKhau());

                    }
                    else
                    {
                        MessageBox.Show("Mã xác nhận không đúng!", "Cảnh báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaXacNhan.Clear();
                        txtMaXacNhan.Focus();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as FrmQuenMatKhau;
            parentForm.Close();
        }

        private void ucMaXacNhan_Load(object sender, EventArgs e)
        {
            var parentForm = this.FindForm() as FrmQuenMatKhau;

            lbMail.Text = parentForm.mail;
        }
    }
}
