using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;


namespace QuanLyBanHang_17SE111.QuanLyNhapHang
{
    public partial class Frm_NhapHang_Main : Form
    {
        public Frm_NhapHang_Main()
        {
            InitializeComponent();

        }
        BLL_NhapHang bd;
        string err = string.Empty;
        DataTable dtChiTietNhap;
        string maPhieuNhap = String.Empty;
        long TongThanhTien = 0;

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_NhapHang_Main_Load(object sender, EventArgs e)
        {
            bd = new BLL_NhapHang();
            HienThiDuLieu();
            TinhTongThanhTien();
            LayDuLieuCboField(dgvChiTietNhapHang,cboField);
        }

        private void TinhTongThanhTien()
        {
            TongThanhTien = 0;
            //for (int i = 0; i < dtChiTietNhap.Rows.Count; i++)
            //{
            //    TongThanhTien += Convert.ToInt64(dtChiTietNhap.Rows[i]["ThanhTienNhap"].ToString());
            //}
            for (int i = 0; i < dgvChiTietNhapHang.Rows.Count; i++)
            {

                TongThanhTien += Convert.ToInt64(dgvChiTietNhapHang.Rows[i].Cells["colThanhTienNhap"].Value.ToString());
            }
            lblTongThanhTien.Text = string.Format("Tổng thành tiền: {0:#,###0}", TongThanhTien);
        }

        private void LayDuLieuCboField()
        {
            DataTable dt = new DataTable();
            dt = bd.LayTenColumn(ref err);
            cboField.DataSource = dt;
            cboField.ValueMember = "name";
            cboField.DisplayMember = "name";
            cboField.SelectedIndex = -1;
            cboField.Text = "Chọn field";
        }
        private void LayDuLieuCboField(DataGridView dgv, ComboBox cbo)
        {
            DataTable dtField = new DataTable();
            DataColumn cl;
            cl = new DataColumn("Value", typeof(string));
            dtField.Columns.Add(cl);
            cl = new DataColumn("Display", typeof(string));
            dtField.Columns.Add(cl);

            DataRow dr;
            for (int i = 0; i < dgvChiTietNhapHang.ColumnCount; i++)
            {
                if (dgvChiTietNhapHang.Columns[i].Visible == true)
                {
                    dr = dtField.NewRow();
                    dr["Value"] = dgvChiTietNhapHang.Columns[i].DataPropertyName.ToString();
                    dr["Display"] = dgvChiTietNhapHang.Columns[i].HeaderText.ToString();
                    dtField.Rows.Add(dr);
                }

            }
            cbo.DataSource = dtField;
            cbo.ValueMember = "Value";
            cbo.DisplayMember = "Display";
            cbo.SelectedIndex = -1;
            cbo.Text = "Chọn field";
        }

        private void HienThiDuLieu()
        {
            try
            {
                dtChiTietNhap = new DataTable();
                dtChiTietNhap = bd.LayChiTietNhapHang(ref err,"0");
                dgvChiTietNhapHang.DataSource = dtChiTietNhap.DefaultView;
                TinhTongThanhTien();
            }
            catch (Exception ex)
            {
                lblerr.Text =string.Format("{0} - {1}", err , ex.Message);
            }
           
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            Frm_NhapHang_Modifies frmNhapHang = new Frm_NhapHang_Modifies();
            frmNhapHang.StatusTaoPhieu = true;
            frmNhapHang.ShowDialog();
            HienThiDuLieu();
        }

        private void btnSuaPhieuNhap_Click(object sender, EventArgs e)
        {
            Frm_NhapHang_Modifies frmNhapHang = new Frm_NhapHang_Modifies();
            frmNhapHang.maPhieuNhap = maPhieuNhap;
            frmNhapHang.ngayNhap = ngayNhap;
            frmNhapHang.StatusTaoPhieu = false;
            frmNhapHang.ShowDialog();
            HienThiDuLieu();
            maPhieuNhap = string.Empty;
            
        }
        DateTime ngayNhap;
        private void dgvChiTietNhapHang_Click(object sender, EventArgs e)
        {
            if(dgvChiTietNhapHang.Rows.Count>0)
            {
                maPhieuNhap = dgvChiTietNhapHang.CurrentRow.Cells["colMaPhieuNhap"].Value.ToString();
                ngayNhap = Convert.ToDateTime( dgvChiTietNhapHang.CurrentRow.Cells["colNgayNhap"].Value.ToString());
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dtChiTietNhap.DefaultView;
            if(!string.IsNullOrEmpty(txtSearch.Text))
            {
                dv.RowFilter = string.Format("CONVERT({0}, System.String) like '%{1}%'", cboField.SelectedValue.ToString(), txtSearch.Text);
            }
            else
            {
                dv.RowFilter="";
            }
            dgvChiTietNhapHang.DataSource = dv;
            TinhTongThanhTien();
        }

        private void btnASC_Click(object sender, EventArgs e)
        {
            DataView dv = dtChiTietNhap.DefaultView;
            if (btnASC.Text=="ASC")
            {
                dv.Sort = string.Format("{0} ASC",cboField.SelectedValue.ToString());
                btnASC.Text="DESC";
                this.btnASC.Image = global::QuanLyBanHang_17SE111.Properties.Resources.reversed_numerical_sorting_32px;
            }
            else
            {
                dv.Sort = string.Format("{0} DESC", cboField.SelectedValue.ToString());
                btnASC.Text = "ASC";
                this.btnASC.Image = global::QuanLyBanHang_17SE111.Properties.Resources.alphabetical_sorting_32px;
            }
            dgvChiTietNhapHang.DataSource = dv;
        }

        private void btnXoaPhieuNhap_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(maPhieuNhap))
            {
                bd.XoaPhieuNhapTheoMaPhieu(ref err, maPhieuNhap);
                HienThiDuLieu();
            }
            else
            {
                MessageBox.Show("Chưa chọn mã phiếu cần xóa");
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
               Cls_Main.ExportExcelByMicrosoft(dgvChiTietNhapHang, "Danh sách chi tiết nhập hàng", save.FileName,65,"A2");
               // Cls_Main.ExportToExcel(dgvChiTietNhapHang, save.FileName, ref err, "Chi Tiết nhập hàng", "Chủ cửa hàng");
               // MessageBox.Show("Export Thành công");
            }
          
        }
        
    }
}
