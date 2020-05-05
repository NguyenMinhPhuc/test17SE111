using QuanLyBanHang_17SE111.DTO;
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
    public partial class Frm_NhanVien_Modifies : Form
    {
        public Frm_NhanVien_Modifies()
        {
            InitializeComponent();
        }
        public bool Them = false;
        BLL_HeThong bd;
        string err = string.Empty;
        int count = 0;
       public NhanVien nhanVien;
        
        private void Frm_NhanVien_Modifies_Load(object sender, EventArgs e)
        {
            bd = new BLL_HeThong();
            LayDuLieuVaoCboTaiKhoan();
            if(Them)
            {
                txtMaNhanVien.Text = "0";
                txtTenNhanVien.Focus();
            }else //sửa
            {
                //view thông nhân viên cần sửa
                LayDuLieuVaoControl(nhanVien);
            }
        }

        private void LayDuLieuVaoControl(NhanVien nhanVien)
        {
            txtMaNhanVien.Text = nhanVien.MaNhanVien;
            txtTenNhanVien.Text = nhanVien.TenNhanVien;
            dtpNgaySinh.Value = nhanVien.NgaySinh;
            txtDienThoai.Text = nhanVien.DienThoai;
            cboTaiKhoan.SelectedValue = nhanVien.MaTaiKhoan;
            txtTenDangNhap.Text = nhanVien.TenDangNhap;
            txtMatKhau.Text = nhanVien.MatKhau;
        }

        private void LayDuLieuVaoCboTaiKhoan()
        {
            DataTable dt = new DataTable();
            dt = bd.LayDuLieuComboTaiKhoan(ref err);
            cboTaiKhoan.DataSource = dt;
            cboTaiKhoan.ValueMember = "MaTaiKhoan";
            cboTaiKhoan.DisplayMember = "TenTaiKhoan";
            cboTaiKhoan.SelectedIndex = -1;
            cboTaiKhoan.Text = "Chọn tài khoản";
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtTenNhanVien.Text))
            {
                LayThongTinNhanVienTuControl();
                if(bd.CapNhatNhanVien(ref err,ref count,nhanVien))
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Chưa thêm thành công nhân viên");
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập tên nhân viên");
                txtTenNhanVien.Focus();
            }
        }

        private void LayThongTinNhanVienTuControl()
        {
            nhanVien = new NhanVien();
            nhanVien.MaNhanVien = txtMaNhanVien.Text;
            nhanVien.TenNhanVien = txtTenNhanVien.Text;
            nhanVien.NgaySinh = dtpNgaySinh.Value;
            nhanVien.DienThoai = txtDienThoai.Text;
            nhanVien.MaTaiKhoan = cboTaiKhoan.SelectedValue.ToString();
            nhanVien.TenDangNhap = txtTenDangNhap.Text;
            nhanVien.MatKhau = txtMatKhau.Text;
        }
    }
}
