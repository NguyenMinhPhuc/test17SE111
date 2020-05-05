namespace QuanLyBanHang_17SE111.QuanLyNhapHang
{
    partial class Frm_NhapHang_Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnNhapHang = new System.Windows.Forms.ToolStripButton();
            this.btnSuaPhieuNhap = new System.Windows.Forms.ToolStripButton();
            this.btnXoaPhieuNhap = new System.Windows.Forms.ToolStripButton();
            this.btnXuatExcel = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.btnASC = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblerr = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTongThanhTien = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgvChiTietNhapHang = new System.Windows.Forms.DataGridView();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.colSTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaPhieuNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNgayNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenLoaiSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongNhapTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBanHienHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGiaNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colThanhTienNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaLoaiSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhapHang)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnNhapHang,
            this.btnSuaPhieuNhap,
            this.btnXoaPhieuNhap,
            this.btnXuatExcel,
            this.btnThoat,
            this.toolStripLabel1,
            this.toolStripComboBox1,
            this.txtSearch,
            this.btnASC});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1261, 28);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::QuanLyBanHang_17SE111.Properties.Resources.refresh_32px;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 25);
            this.btnRefresh.Text = "Nạp lại";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnNhapHang
            // 
            this.btnNhapHang.Image = global::QuanLyBanHang_17SE111.Properties.Resources.add_new_32px;
            this.btnNhapHang.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNhapHang.Name = "btnNhapHang";
            this.btnNhapHang.Size = new System.Drawing.Size(107, 25);
            this.btnNhapHang.Text = "Nhập hàng";
            this.btnNhapHang.Click += new System.EventHandler(this.btnNhapHang_Click);
            // 
            // btnSuaPhieuNhap
            // 
            this.btnSuaPhieuNhap.Image = global::QuanLyBanHang_17SE111.Properties.Resources.update_32px;
            this.btnSuaPhieuNhap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSuaPhieuNhap.Name = "btnSuaPhieuNhap";
            this.btnSuaPhieuNhap.Size = new System.Drawing.Size(138, 25);
            this.btnSuaPhieuNhap.Text = "Sửa phiếu nhập";
            this.btnSuaPhieuNhap.Click += new System.EventHandler(this.btnSuaPhieuNhap_Click);
            // 
            // btnXoaPhieuNhap
            // 
            this.btnXoaPhieuNhap.Image = global::QuanLyBanHang_17SE111.Properties.Resources.delete_bin_32px;
            this.btnXoaPhieuNhap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoaPhieuNhap.Name = "btnXoaPhieuNhap";
            this.btnXoaPhieuNhap.Size = new System.Drawing.Size(138, 25);
            this.btnXoaPhieuNhap.Text = "Xóa phiếu nhập";
            this.btnXoaPhieuNhap.Click += new System.EventHandler(this.btnXoaPhieuNhap_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Image = global::QuanLyBanHang_17SE111.Properties.Resources.microsoft_excel_32px;
            this.btnXuatExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(99, 25);
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = global::QuanLyBanHang_17SE111.Properties.Resources.close_window_32px;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(69, 25);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(87, 25);
            this.toolStripLabel1.Text = "Chọn Field:";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(121, 28);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(120, 28);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnASC
            // 
            this.btnASC.Image = global::QuanLyBanHang_17SE111.Properties.Resources.alphabetical_sorting_32px;
            this.btnASC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnASC.Name = "btnASC";
            this.btnASC.Size = new System.Drawing.Size(59, 25);
            this.btnASC.Text = "ASC";
            this.btnASC.Click += new System.EventHandler(this.btnASC_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblerr,
            this.lblTongThanhTien});
            this.statusStrip1.Location = new System.Drawing.Point(0, 334);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1261, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblerr
            // 
            this.lblerr.ForeColor = System.Drawing.Color.Red;
            this.lblerr.Name = "lblerr";
            this.lblerr.Size = new System.Drawing.Size(16, 17);
            this.lblerr.Text = "...";
            // 
            // lblTongThanhTien
            // 
            this.lblTongThanhTien.Name = "lblTongThanhTien";
            this.lblTongThanhTien.Size = new System.Drawing.Size(122, 17);
            this.lblTongThanhTien.Text = "Tổng thành tiền : N/A";
            // 
            // dgvChiTietNhapHang
            // 
            this.dgvChiTietNhapHang.AllowUserToAddRows = false;
            this.dgvChiTietNhapHang.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvChiTietNhapHang.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietNhapHang.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietNhapHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietNhapHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietNhapHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSTT,
            this.colMaPhieuNhap,
            this.colNgayNhap,
            this.colMaNhanVien,
            this.colMaSanPham,
            this.colTenLoaiSanPham,
            this.colTenSanPham,
            this.colSoLuongNhap,
            this.colSoLuongNhapTon,
            this.colGiaBanHienHanh,
            this.colMaDonViTinh,
            this.colTenDonViTinh,
            this.colDonGiaNhap,
            this.colThanhTienNhap,
            this.colMaLoaiSanPham,
            this.colTenNhanVien,
            this.colMaNhaCungCap,
            this.colTenNhaCungCap});
            this.dgvChiTietNhapHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietNhapHang.Location = new System.Drawing.Point(0, 28);
            this.dgvChiTietNhapHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChiTietNhapHang.Name = "dgvChiTietNhapHang";
            this.dgvChiTietNhapHang.ReadOnly = true;
            this.dgvChiTietNhapHang.RowHeadersVisible = false;
            this.dgvChiTietNhapHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietNhapHang.Size = new System.Drawing.Size(1261, 306);
            this.dgvChiTietNhapHang.TabIndex = 2;
            this.dgvChiTietNhapHang.Click += new System.EventHandler(this.dgvChiTietNhapHang_Click);
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Location = new System.Drawing.Point(849, 2);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(121, 24);
            this.cboField.TabIndex = 3;
            // 
            // colSTT
            // 
            this.colSTT.DataPropertyName = "STT";
            this.colSTT.HeaderText = "STT";
            this.colSTT.Name = "colSTT";
            this.colSTT.ReadOnly = true;
            this.colSTT.Width = 60;
            // 
            // colMaPhieuNhap
            // 
            this.colMaPhieuNhap.DataPropertyName = "MaPhieuNhap";
            this.colMaPhieuNhap.HeaderText = "Phiếu nhập";
            this.colMaPhieuNhap.Name = "colMaPhieuNhap";
            this.colMaPhieuNhap.ReadOnly = true;
            // 
            // colNgayNhap
            // 
            this.colNgayNhap.DataPropertyName = "NgayNhap";
            this.colNgayNhap.HeaderText = "Ngày nhập";
            this.colNgayNhap.Name = "colNgayNhap";
            this.colNgayNhap.ReadOnly = true;
            // 
            // colMaNhanVien
            // 
            this.colMaNhanVien.DataPropertyName = "MaNhanVien";
            this.colMaNhanVien.HeaderText = "MaNV";
            this.colMaNhanVien.Name = "colMaNhanVien";
            this.colMaNhanVien.ReadOnly = true;
            this.colMaNhanVien.Visible = false;
            // 
            // colMaSanPham
            // 
            this.colMaSanPham.DataPropertyName = "MaSanPham";
            this.colMaSanPham.HeaderText = "Mã sản phẩm";
            this.colMaSanPham.Name = "colMaSanPham";
            this.colMaSanPham.ReadOnly = true;
            this.colMaSanPham.Visible = false;
            // 
            // colTenLoaiSanPham
            // 
            this.colTenLoaiSanPham.DataPropertyName = "TenLoaiSanPham";
            this.colTenLoaiSanPham.HeaderText = "Loại sản phẩm";
            this.colTenLoaiSanPham.Name = "colTenLoaiSanPham";
            this.colTenLoaiSanPham.ReadOnly = true;
            // 
            // colTenSanPham
            // 
            this.colTenSanPham.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTenSanPham.DataPropertyName = "TenSanPham";
            this.colTenSanPham.HeaderText = "Tên sản phẩm";
            this.colTenSanPham.Name = "colTenSanPham";
            this.colTenSanPham.ReadOnly = true;
            // 
            // colSoLuongNhap
            // 
            this.colSoLuongNhap.DataPropertyName = "SoLuongNhap";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,###0";
            dataGridViewCellStyle3.NullValue = "0";
            this.colSoLuongNhap.DefaultCellStyle = dataGridViewCellStyle3;
            this.colSoLuongNhap.HeaderText = "SL";
            this.colSoLuongNhap.Name = "colSoLuongNhap";
            this.colSoLuongNhap.ReadOnly = true;
            this.colSoLuongNhap.Width = 50;
            // 
            // colSoLuongNhapTon
            // 
            this.colSoLuongNhapTon.DataPropertyName = "SoLuongNhapTon";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,###0";
            dataGridViewCellStyle4.NullValue = "0";
            this.colSoLuongNhapTon.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSoLuongNhapTon.HeaderText = "SLT";
            this.colSoLuongNhapTon.Name = "colSoLuongNhapTon";
            this.colSoLuongNhapTon.ReadOnly = true;
            this.colSoLuongNhapTon.Width = 50;
            // 
            // colGiaBanHienHanh
            // 
            this.colGiaBanHienHanh.DataPropertyName = "GiaBanHienHanh";
            this.colGiaBanHienHanh.HeaderText = "Giá bán";
            this.colGiaBanHienHanh.Name = "colGiaBanHienHanh";
            this.colGiaBanHienHanh.ReadOnly = true;
            // 
            // colMaDonViTinh
            // 
            this.colMaDonViTinh.DataPropertyName = "MaDonViTinh";
            this.colMaDonViTinh.HeaderText = "ĐVT";
            this.colMaDonViTinh.Name = "colMaDonViTinh";
            this.colMaDonViTinh.ReadOnly = true;
            this.colMaDonViTinh.Visible = false;
            // 
            // colTenDonViTinh
            // 
            this.colTenDonViTinh.DataPropertyName = "TenDonViTinh";
            this.colTenDonViTinh.HeaderText = "ĐVT";
            this.colTenDonViTinh.Name = "colTenDonViTinh";
            this.colTenDonViTinh.ReadOnly = true;
            // 
            // colDonGiaNhap
            // 
            this.colDonGiaNhap.DataPropertyName = "DonGiaNhap";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,###0";
            dataGridViewCellStyle5.NullValue = "0";
            this.colDonGiaNhap.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDonGiaNhap.HeaderText = "Đơn giá";
            this.colDonGiaNhap.Name = "colDonGiaNhap";
            this.colDonGiaNhap.ReadOnly = true;
            // 
            // colThanhTienNhap
            // 
            this.colThanhTienNhap.DataPropertyName = "ThanhTienNhap";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#,###0";
            dataGridViewCellStyle6.NullValue = "0";
            this.colThanhTienNhap.DefaultCellStyle = dataGridViewCellStyle6;
            this.colThanhTienNhap.HeaderText = "Thành tiền";
            this.colThanhTienNhap.Name = "colThanhTienNhap";
            this.colThanhTienNhap.ReadOnly = true;
            // 
            // colMaLoaiSanPham
            // 
            this.colMaLoaiSanPham.DataPropertyName = "MaLoaiSanPham";
            this.colMaLoaiSanPham.HeaderText = "MaLoaiSanPham";
            this.colMaLoaiSanPham.Name = "colMaLoaiSanPham";
            this.colMaLoaiSanPham.ReadOnly = true;
            this.colMaLoaiSanPham.Visible = false;
            // 
            // colTenNhanVien
            // 
            this.colTenNhanVien.DataPropertyName = "TenNhanVien";
            this.colTenNhanVien.HeaderText = "Tên nhân viên";
            this.colTenNhanVien.Name = "colTenNhanVien";
            this.colTenNhanVien.ReadOnly = true;
            this.colTenNhanVien.Width = 150;
            // 
            // colMaNhaCungCap
            // 
            this.colMaNhaCungCap.DataPropertyName = "MaNhaCungCap";
            this.colMaNhaCungCap.HeaderText = "NCC";
            this.colMaNhaCungCap.Name = "colMaNhaCungCap";
            this.colMaNhaCungCap.ReadOnly = true;
            this.colMaNhaCungCap.Visible = false;
            // 
            // colTenNhaCungCap
            // 
            this.colTenNhaCungCap.DataPropertyName = "TenNhaCungCap";
            this.colTenNhaCungCap.HeaderText = "Nhà CC";
            this.colTenNhaCungCap.Name = "colTenNhaCungCap";
            this.colTenNhaCungCap.ReadOnly = true;
            // 
            // Frm_NhapHang_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 356);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.dgvChiTietNhapHang);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm_NhapHang_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CHI TIẾT NHẬP HÀNG";
            this.Load += new System.EventHandler(this.Frm_NhapHang_Main_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietNhapHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblerr;
        private System.Windows.Forms.ToolStripButton btnNhapHang;
        private System.Windows.Forms.ToolStripButton btnSuaPhieuNhap;
        private System.Windows.Forms.ToolStripButton btnXoaPhieuNhap;
        private System.Windows.Forms.ToolStripButton btnXuatExcel;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private System.Windows.Forms.DataGridView dgvChiTietNhapHang;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.ToolStripStatusLabel lblTongThanhTien;
        private System.Windows.Forms.ToolStripButton btnASC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaPhieuNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgayNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenLoaiSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongNhapTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBanHienHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGiaNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThanhTienNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaLoaiSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNhanVien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenNhaCungCap;
    }
}