using QuanLyBanHang_17SE111.DanhMuc;
using QuanLyBanHang_17SE111.HeThong;
using QuanLyBanHang_17SE111.QuanLyNhapHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_17SE111
{
    public partial class Frm_Main: Form
    {
        public Frm_Main()
        {
            InitializeComponent();
        }

        private void Frm_Main_Load(object sender, EventArgs e)
        {
            Frm_DangNhap frm_DangNhap = new Frm_DangNhap();
            frm_DangNhap.ShowDialog();
            lblTenNhanVien.Text = Cls_Main.tenNhanVien;
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            Frm_DangNhap frm_DangNhap = new Frm_DangNhap();
            frm_DangNhap.ShowDialog();
            lblTenNhanVien.Text = Cls_Main.tenNhanVien;
        }

        private void mnuQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            Frm_NhanVien_Main frm_NhanVien_Main = new Frm_NhanVien_Main();
            frm_NhanVien_Main.MdiParent = this;
            frm_NhanVien_Main.Show();
        }

        private void mnuSaoLuu_Click(object sender, EventArgs e)
        {
            Frm_SaoLuuPhucHoi frm_SaoLuuPhucHoi = new Frm_SaoLuuPhucHoi();
            frm_SaoLuuPhucHoi.saoLuuStatus = true;
            frm_SaoLuuPhucHoi.ShowDialog();
        }

        private void mnuPhucHoi_Click(object sender, EventArgs e)
        {
            Frm_SaoLuuPhucHoi frm_SaoLuuPhucHoi = new Frm_SaoLuuPhucHoi();
            frm_SaoLuuPhucHoi.saoLuuStatus = false;
            frm_SaoLuuPhucHoi.ShowDialog();
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            Frm_DoiMatKhau frm_DoiMatKhau = new Frm_DoiMatKhau();
            frm_DoiMatKhau.ShowDialog();
        }

        private void mnuChiTietNhap_Click(object sender, EventArgs e)
        {
            Frm_NhapHang_Main frmNhapHang = new Frm_NhapHang_Main();
            frmNhapHang.ShowDialog();
        }

        private void mnuDonViTinh_Click(object sender, EventArgs e)
        {
            Frm_DonViTinh_Main frm_DonViTinh = new Frm_DonViTinh_Main();
            frm_DonViTinh.MdiParent = this;
            frm_DonViTinh.Show();
        }
    }
}
