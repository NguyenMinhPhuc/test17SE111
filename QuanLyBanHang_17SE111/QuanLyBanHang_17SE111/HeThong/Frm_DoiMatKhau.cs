using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_17SE111.HeThong
{
    public partial class Frm_DoiMatKhau : Form
    {
        public Frm_DoiMatKhau()
        {
            InitializeComponent();
        }
        BLL_HeThong bd;
        string err = string.Empty;
        int count = 0;

        private void Frm_DoiMatKhau_Load(object sender, EventArgs e)
        {
            bd = new BLL_HeThong();
            if(Cls_Main.maTaiKhoan.Equals("1"))
            {
                gbCapLaiMatKhau.Enabled = true;
                LayDuLieuVaoCboNhanVien();
            }else
            {
                gbCapLaiMatKhau.Enabled = false;
            }
        }

        private void LayDuLieuVaoCboNhanVien()
        {
            DataTable dataTable = new DataTable();
            dataTable = bd.LayDuLieuCboNhanVien(ref err);
            cboNhanVien.DataSource = dataTable;
            cboNhanVien.DisplayMember = "TenNhanVien";
            cboNhanVien.ValueMember = "MaNhanVien";
            cboNhanVien.SelectedIndex = -1;
            cboNhanVien.Text = "Chọn nhân viên";
        }

        private void btnResetMatKhau_Click(object sender, EventArgs e)
        {
            if(cboNhanVien.SelectedIndex>=0)
            {
                if(bd.ResetMatKhau(ref err,ref count,cboNhanVien.SelectedValue.ToString()))
                {
                    if(count>0)
                    {
                        MessageBox.Show("Reset mật khẩu thành công");
                    }
                    else
                    {
                        MessageBox.Show("Reset mật khẩu không thành công\n"+err);
                    }
                }
                else
                {
                    MessageBox.Show("Reset mật khẩu không thành công\n" + err);
                }
            }
        }

        private void txtMatKhau1_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMatKhau1.Text))
            {
                if(!txtMatKhau1.Text.Equals(txtMatKhau.Text))
                {
                    MessageBox.Show("Mật khẩu không khớp\n Xin vui lòng nhập lại");
                    txtMatKhau1.ResetText();
                    txtMatKhau1.Focus();
                }
                else
                {
                    txtMatKhau.Enabled = false;
                    txtMatKhau1.Enabled = false;
                    btnDoiMatKhau.Enabled = true;
                }
            }
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMatKhau1.Text))
            {
                if (!string.IsNullOrEmpty(txtMatKhau.Text))
                {
                    if (bd.DoiMatKhau(ref err, ref count, Cls_Main.maNhanVien,txtMatKhau.Text))
                    {
                        if (count > 0)
                        {
                            MessageBox.Show("Reset mật khẩu thành công");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Reset mật khẩu không thành công\n" + err);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Reset mật khẩu không thành công\n" + err);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập mật khẩu\n Xin vui lòng nhập lại");
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập mật khẩu\n Xin vui lòng nhập lại");
            }
        }
    }
}
