using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_17SE111.QuanLyNhapHang
{
    public partial class Frm_NhapHang_Modifies : Form
    {
        public Frm_NhapHang_Modifies()
        {
            InitializeComponent();
        }
        BLL_NhapHang bd;
        string err = string.Empty;
        int count = 0;
        DTO_NhapHang nhapHang;
        public string maPhieuNhap = string.Empty;
        public DateTime ngayNhap;
     
        public bool StatusTaoPhieu = false;
        private void Frm_NhapHang_Modifies_Load(object sender, EventArgs e)
        {
            bd = new BLL_NhapHang();
            HienThicboLoaiSanPham();
            HienThicboNhaCungCap();
            HienThicboDonViTinh();
            if (StatusTaoPhieu)//Thêm mới
            {
                TaoMaPhieuNhap();
            }
            else//Update
            {
                txtMaPhieuNhap.Text = maPhieuNhap;
                dtpNgayNhap.Value = ngayNhap;
                HienThiChiTietNhap(maPhieuNhap);
            }
          
        }

        private void HienThicboDonViTinh()
        {
            DataTable dt = new DataTable();
            dt = bd.LayDuLieuComboDonViTinh(ref err);
            cboDonViTinh.DataSource = dt;
            cboDonViTinh.DisplayMember = "TenDonViTinh";
            cboDonViTinh.ValueMember = "MaDonViTinh";
            cboDonViTinh.SelectedIndex = -1;
            cboDonViTinh.Text = "Chọn Đơn vị tính";
        }

        private void HienThicboNhaCungCap()
        {
            DataTable dt = new DataTable();
            dt = bd.LayDuLieuComboNhaCungCap(ref err);
            cboNhaCungCap.DataSource = dt;
            cboNhaCungCap.DisplayMember = "TenNhaCungCap";
            cboNhaCungCap.ValueMember = "MaNhaCungCap";
            cboNhaCungCap.SelectedIndex = -1;
            cboNhaCungCap.Text = "Chọn Nhà cung cấp";
        }
        bool statusLoadboLoaiSanPham = false;
        private void HienThicboLoaiSanPham()
        {
            statusLoadboLoaiSanPham = false;
            DataTable dt = new DataTable();
            dt = bd.LayDuLieuComboLoaiSanPham(ref err);
            cboLoaiSanPham.DataSource = dt;
            cboLoaiSanPham.DisplayMember = "TenLoaiSanPham";
            cboLoaiSanPham.ValueMember = "MaLoaiSanPham";
            cboLoaiSanPham.SelectedIndex = -1;
            cboLoaiSanPham.Text = "Chọn loại sản phẩm";
            statusLoadboLoaiSanPham = true;
        }

        private void TaoMaPhieuNhap()
        {
            object obj = null;
            string maPhieuNhap = string.Empty;
            obj = bd.LayMaPhieuNhapLonNhat(ref err, Cls_Main.maNhanVien);
            if (obj != null)
            {
                maPhieuNhap = string.Format("PN{0}{1:00}{2:00}{3:0000}", DateTime.Now.Year.ToString().Substring(2, 2), DateTime.Now.Month, Convert.ToInt32(Cls_Main.maNhanVien), Convert.ToInt32(obj) + 1);
            }
            else
            {
                MessageBox.Show("Không lấy được mã phiếu trong database");
                this.Close();
            }
            txtMaPhieuNhap.Text = maPhieuNhap;
            this.Text = string.Format("Form[NHẬP HÀNG][Mã phiếu nhập hiện tại : {0}]",maPhieuNhap);
        }
        private void TaoMaPhieuNhap(DateTime ngayNhap)
        {
            object obj = null;
            string maPhieuNhap = string.Empty;
            obj = bd.LayMaPhieuNhapLonNhat(ref err, Cls_Main.maNhanVien, ngayNhap);
            if (obj != null)
            {
                maPhieuNhap = string.Format("PN{0}{1:00}{2:00}{3:0000}", ngayNhap.Year.ToString().Substring(2, 2), ngayNhap.Month, Convert.ToInt32(Cls_Main.maNhanVien), Convert.ToInt32(obj) + 1);
            }
            else
            {
                MessageBox.Show("Không lấy được mã phiếu trong database");
                this.Close();
            }
            txtMaPhieuNhap.Text = maPhieuNhap;
        }

        private void dtpNgayNhap_ValueChanged(object sender, EventArgs e)
        {
            if (StatusTaoPhieu)
                TaoMaPhieuNhap(dtpNgayNhap.Value);
        }
        DataTable dtSanPham;
        private void cboLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiSanPham.SelectedIndex >= 0 && statusLoadboLoaiSanPham == true)
            {
                dtSanPham = new DataTable();
                dtSanPham = bd.LayDanhSachSanPhamTheoLoai(ref err, cboLoaiSanPham.SelectedValue.ToString());
                AutoCompleteStringCollection list = new AutoCompleteStringCollection();
                for (int i = 0; i < dtSanPham.Rows.Count; i++)
                {
                    list.Add(dtSanPham.Rows[i]["TenSanPham"].ToString());
                }
                txtTenSanPham.AutoCompleteCustomSource = list;
                txtTenSanPham.AutoCompleteMode = AutoCompleteMode.Suggest;
            }
        }

        private void txtTenSanPham_Leave(object sender, EventArgs e)
        {
            if (statusUpdate == false)
            {
                if (!string.IsNullOrEmpty(txtTenSanPham.Text.Trim()))
                {
                    foreach (DataRow item in dtSanPham.Rows)
                    {
                        if (item["TenSanPham"].ToString().Equals(txtTenSanPham.Text.Trim()))
                        {
                            txtMaSanPham.Text = item["MaSanPham"].ToString();
                            cboDonViTinh.SelectedValue = item["MaDonViTinh"].ToString();
                            cboNhaCungCap.SelectedValue = item["MaNhaCungCap"].ToString();
                            txtDonGiaNhap.Text = item["DonGiaBinhQuan"].ToString();
                            txtDonGiaBan.Text = item["GiaBanHienHanh"].ToString();
                            return;
                        }
                    }
                }
                txtDonGiaBan.Enabled = false;
                txtMaSanPham.Text = "0";
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (StatusTaoPhieu == false)
            {
                TaoMaPhieuNhap(dtpNgayNhap.Value);
                StatusTaoPhieu = true;
            }

            if (!string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                if (!string.IsNullOrEmpty(txtSoLuongNhap.Text))
                {
                    if (cboLoaiSanPham.SelectedIndex >= 0)
                    {
                        //Lấy dữ liệu cho đối tượng DTO_NhapHang
                        LayDuLieuNhapHang();
                        if (nhapHang != null)
                        {
                            if (bd.InserttChiTietPhieuNhap(ref err, ref count, nhapHang))
                            {
                                if (count > 0)
                                {
                                    //Load lại lưới
                                    HienThiChiTietNhap(txtMaPhieuNhap.Text);
                                    ResetControl();
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn loại sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập Số lượng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập tên sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Phương thức để chuyển các control về mặc định ban đầu.
        /// </summary>
        private void ResetControl()
        {
            txtMaSanPham.Text = "0";
            txtTenSanPham.ResetText();
            cboNhaCungCap.SelectedIndex = -1;
            cboNhaCungCap.Text = "Chọn nhà cung cấp";
            cboDonViTinh.SelectedIndex = -1;
            cboDonViTinh.Text = "Chọn đơn vị tính";
            txtSoLuongNhap.Text = "0";
            txtDonGiaNhap.Text = "0";
            txtDonGiaBan.Text = "0";
            txtTenSanPham.Focus();
        }

        private void LayDuLieuNhapHang()
        {
            nhapHang = new DTO_NhapHang();
            nhapHang.MaPhieuNhap = txtMaPhieuNhap.Text;
            nhapHang.NgayNhap = dtpNgayNhap.Value;
            nhapHang.MaSanPham = txtMaSanPham.Text;
            nhapHang.TenSanPham = txtTenSanPham.Text;
            nhapHang.MoTa = "";
            nhapHang.MaLoaiSanPham = cboLoaiSanPham.SelectedValue.ToString();
            nhapHang.MaDonViTinh = cboDonViTinh.SelectedValue.ToString();
            nhapHang.MaNhaCungCap = cboNhaCungCap.SelectedValue.ToString();
            nhapHang.SoLuongNhap = Convert.ToInt64(txtSoLuongNhap.Text);
            nhapHang.DonGiaNhap = Convert.ToInt64(txtDonGiaNhap.Text);
            nhapHang.MaNhanVien = Cls_Main.maNhanVien;
            nhapHang.GiaBanHienHanh = Convert.ToInt64(txtDonGiaBan.Text);
        }
        DataTable dtChiTietNhap;
        private void HienThiChiTietNhap(string p)
        {
            try
            {
                dtChiTietNhap = new DataTable();
                dtChiTietNhap = bd.LayChiTietNhapHang(ref err, txtMaPhieuNhap.Text);
                dgvChiTietNhapHang.DataSource = dtChiTietNhap.DefaultView;
            }
            catch (Exception ex)
            {
                lblerr.Text = string.Format("{0} - {1}", err, ex.Message);
            }
        }

        private void dgvChiTietNhapHang_Click(object sender, EventArgs e)
        {

            if (dgvChiTietNhapHang.Rows.Count > 0)
            {

                LayDuLieuTrenLuoiVaoDTO_NhapHang();

                SetValueToControl(nhapHang);
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                statusUpdate = true;
            }
        }

        private void LayDuLieuTrenLuoiVaoDTO_NhapHang()
        {
            nhapHang = new DTO_NhapHang();
            nhapHang.MaPhieuNhap = dgvChiTietNhapHang.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString();
            nhapHang.NgayNhap = Convert.ToDateTime(dgvChiTietNhapHang.CurrentRow.Cells["colNgayNhap"].Value.ToString());
            nhapHang.MaSanPham = dgvChiTietNhapHang.CurrentRow.Cells["colMaSanPham"].Value.ToString();
            nhapHang.TenSanPham = dgvChiTietNhapHang.CurrentRow.Cells["colTenSanPham"].Value.ToString();
            nhapHang.MoTa = "";
            nhapHang.MaLoaiSanPham = dgvChiTietNhapHang.CurrentRow.Cells["colMaLoaiSanPham"].Value.ToString();
            nhapHang.MaDonViTinh = dgvChiTietNhapHang.CurrentRow.Cells["colMaDonViTinh"].Value.ToString();
            nhapHang.MaNhaCungCap = dgvChiTietNhapHang.CurrentRow.Cells["colMaNhaCungCap"].Value.ToString();
            nhapHang.SoLuongNhap = Convert.ToInt64(dgvChiTietNhapHang.CurrentRow.Cells["colSoLuongNhap"].Value.ToString());
            nhapHang.DonGiaNhap = Convert.ToInt64(dgvChiTietNhapHang.CurrentRow.Cells["colDonGiaNhap"].Value.ToString());
            nhapHang.MaNhanVien = Cls_Main.maNhanVien;
            nhapHang.GiaBanHienHanh = Convert.ToInt64(dgvChiTietNhapHang.CurrentRow.Cells["colGiaBanHienHanh"].Value.ToString());
        }
        private void LayDuLieuTrenLuoiVaoDTO_NhapHang(int index)
        {
            nhapHang = new DTO_NhapHang();
            nhapHang.MaPhieuNhap = dgvChiTietNhapHang.Rows[index].Cells["colMaPhieuNhap"].Value.ToString();
            nhapHang.NgayNhap = Convert.ToDateTime(dgvChiTietNhapHang.Rows[index].Cells["colNgayNhap"].Value.ToString());
            nhapHang.MaSanPham = dgvChiTietNhapHang.Rows[index].Cells["colMaSanPham"].Value.ToString();
            nhapHang.TenSanPham = dgvChiTietNhapHang.Rows[index].Cells["colTenSanPham"].Value.ToString();
            nhapHang.MoTa = "";
            nhapHang.MaLoaiSanPham = dgvChiTietNhapHang.Rows[index].Cells["colMaLoaiSanPham"].Value.ToString();
            nhapHang.MaDonViTinh = dgvChiTietNhapHang.Rows[index].Cells["colMaDonViTinh"].Value.ToString();
            nhapHang.MaNhaCungCap = dgvChiTietNhapHang.Rows[index].Cells["colMaNhaCungCap"].Value.ToString();
            nhapHang.SoLuongNhap = Convert.ToInt64(dgvChiTietNhapHang.Rows[index].Cells["colSoLuongNhap"].Value.ToString());
            nhapHang.DonGiaNhap = Convert.ToInt64(dgvChiTietNhapHang.Rows[index].Cells["colDonGiaNhap"].Value.ToString());
            nhapHang.MaNhanVien = Cls_Main.maNhanVien;
            nhapHang.GiaBanHienHanh = Convert.ToInt64(dgvChiTietNhapHang.Rows[index].Cells["colGiaBanHienHanh"].Value.ToString());
        }


        private void SetValueToControl(DTO_NhapHang nhapHang)
        {
            if (nhapHang != null)
            {
                txtMaSanPham.Text = nhapHang.MaSanPham;
                cboLoaiSanPham.SelectedValue = nhapHang.MaLoaiSanPham;
                cboDonViTinh.SelectedValue = nhapHang.MaDonViTinh;
                cboNhaCungCap.SelectedValue = nhapHang.MaNhaCungCap;
                txtTenSanPham.Text = nhapHang.TenSanPham;
                txtSoLuongNhap.Text = nhapHang.SoLuongNhap.ToString();
                txtDonGiaNhap.Text = nhapHang.DonGiaNhap.ToString();
                txtDonGiaBan.Text = nhapHang.GiaBanHienHanh.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenSanPham.Text))
            {
                if (!string.IsNullOrEmpty(txtSoLuongNhap.Text))
                {
                    if (cboLoaiSanPham.SelectedIndex >= 0)
                    {
                        //Lấy dữ liệu cho đối tượng DTO_NhapHang
                        LayDuLieuNhapHang();
                        if (nhapHang != null)
                        {
                            if (bd.UpdateChiTietPhieuNhap(ref err, ref count, nhapHang))
                            {
                                if (count > 0)
                                {
                                    //Load lại lưới
                                    HienThiChiTietNhap(txtMaPhieuNhap.Text);
                                    ResetControl();
                                    btnXoa.Enabled = false;
                                    btnSua.Enabled = false;
                                    statusUpdate = false;
                                }
                                else
                                {
                                    MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Chưa chọn loại sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa nhập Số lượng", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa nhập tên sản phẩm", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool statusUpdate = false;

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Lấy dữ liệu cho đối tượng DTO_NhapHang
            LayDuLieuNhapHang();
            if (nhapHang != null)
            {
                if (bd.DeleteChiTietPhieuNhap(ref err, ref count, nhapHang))
                {
                    if (count > 0)
                    {
                        //Load lại lưới
                        HienThiChiTietNhap(txtMaPhieuNhap.Text);
                        ResetControl();
                        btnXoa.Enabled = false;
                        btnSua.Enabled = false;
                        statusUpdate = false;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show(string.Format("Sản phẩm không thêm được \n Lý do: {0}", err), "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHuyPhieuNhap_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvChiTietNhapHang.Rows.Count; i++)
            {
                //Lấy dữ liệu cho đối tượng DTO_NhapHang
                LayDuLieuTrenLuoiVaoDTO_NhapHang(i);
                if (nhapHang != null)
                {
                    bd.DeleteChiTietPhieuNhap(ref err, ref count, nhapHang);
                }
            }
            HienThiChiTietNhap(txtMaPhieuNhap.Text);
            ResetControl();
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            statusUpdate = false;
          
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            ResetControl();
   
            TaoMaPhieuNhap();   
            HienThiChiTietNhap(txtMaPhieuNhap.Text);
            txtTenSanPham.Focus();
        }
    }
}
