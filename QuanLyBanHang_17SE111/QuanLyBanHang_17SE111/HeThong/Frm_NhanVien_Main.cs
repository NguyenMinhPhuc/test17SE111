using MyLibrary;
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
    public partial class Frm_NhanVien_Main : Form
    {
        public Frm_NhanVien_Main()
        {
            InitializeComponent();
        }
        BLL_HeThong bd;
        string err = string.Empty;
        int count = 0;
        DataTable dataTable;
        NhanVien nhanVien;
        private void Frm_NhanVien_Main_Load(object sender, EventArgs e)
        {
            bd = new BLL_HeThong();
            HienThiDanhSachNhanVien();
        }

        private void HienThiDanhSachNhanVien()
        {
            dataTable = new DataTable();
            dataTable = bd.LayDanhSachNhanVien(ref err);
            dgvDanhSachNhanVien.DataSource = dataTable;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Frm_NhanVien_Modifies frm_NhanVien_Modifies = new Frm_NhanVien_Modifies();
            frm_NhanVien_Modifies.Them = true;
            frm_NhanVien_Modifies.ShowDialog();
            HienThiDanhSachNhanVien();
        }

        private void dgvDanhSachNhanVien_Click(object sender, EventArgs e)
        {
            if(dgvDanhSachNhanVien.Rows.Count>0)
            {
                nhanVien = new NhanVien();
                nhanVien.MaNhanVien = dgvDanhSachNhanVien.CurrentRow.Cells["colMaNhanVien"].Value.ToString();
                nhanVien.TenNhanVien = dgvDanhSachNhanVien.CurrentRow.Cells["colTenNhanVien"].Value.ToString();
                nhanVien.NgaySinh =Convert.ToDateTime( dgvDanhSachNhanVien.CurrentRow.Cells["colNgaySinh"].Value.ToString());
                nhanVien.DienThoai = dgvDanhSachNhanVien.CurrentRow.Cells["colDienThoai"].Value.ToString();
                nhanVien.MaTaiKhoan = dgvDanhSachNhanVien.CurrentRow.Cells["colMaTaiKhoan"].Value.ToString();
                nhanVien.TenDangNhap = dgvDanhSachNhanVien.CurrentRow.Cells["colTenDangNhap"].Value.ToString();
                nhanVien.MatKhau = dgvDanhSachNhanVien.CurrentRow.Cells["colMatKhau"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            Frm_NhanVien_Modifies frm_NhanVien_Modifies = new Frm_NhanVien_Modifies();
            frm_NhanVien_Modifies.Them = false;
            frm_NhanVien_Modifies.nhanVien = nhanVien;
            frm_NhanVien_Modifies.ShowDialog();
            HienThiDanhSachNhanVien();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (nhanVien != null)
            {
                if (MessageBox.Show(string.Format("Chương trình sẽ thực hiện thao tác xóa nhân viên {0} khỏi hệ thống\n Việc này sẽ làm cho dữ liệu của nhân viên {1} bị thay đổi và không thể phục hồi\n Bạn có chắc chắn muốn xóa dữ liệu này không?\n Nếu đồng ý chọn OK. Ngược lại chọn Cancel",nhanVien.TenNhanVien,nhanVien.TenNhanVien), "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    count = 0;
                    if (bd.XoaNhanVienByDeleteByUpdateIsDelete(ref err, ref count, nhanVien.MaNhanVien))
                    {
                        if (count > 0)
                        {
                            MessageBox.Show("Xóa thành công");
                            HienThiDanhSachNhanVien();
                        }
                        else
                        {
                            MessageBox.Show("Xóa không thành công\n" + err);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa không thành công\n" + err);
                    }
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Nơi chứa file Exprot Excel";
            save.DefaultExt = "xls";
            save.AddExtension = true;
            save.Filter = "File Excel (*.xls)|*.xls";
            save.RestoreDirectory = true;
            save.FileName = string.Format("ExportExcel_{0}{1:00}{2:00}{3:00}{4:00}{5:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            if (save.ShowDialog() == DialogResult.OK)
            {
               // Cls_Main.ExportExcelByMicrosoft(dgvDanhSachNhanVien, "Danh sách nhân viên", save.FileName, 65, "A2");
                ExportExcel.ExportExcelByMicrosoft(dgvDanhSachNhanVien, "Danh sách nhân viên", save.FileName, 65, "A2");
                // Cls_Main.ExportToExcel(dgvChiTietNhapHang, save.FileName, ref err, "Chi Tiết nhập hàng", "Chủ cửa hàng");
                // MessageBox.Show("Export Thành công");
            }
        }
    }
}
