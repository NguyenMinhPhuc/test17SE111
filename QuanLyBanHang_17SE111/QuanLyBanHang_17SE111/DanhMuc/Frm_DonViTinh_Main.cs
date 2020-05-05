using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_17SE111.DanhMuc
{
    public partial class Frm_DonViTinh_Main : Form
    {
        public Frm_DonViTinh_Main()
        {
            InitializeComponent();
        }
        BLL_DanhMuc bd;
        string err=string.Empty;

        DataTable dtDonViTinh;
        private void Frm_DonViTinh_Main_Load(object sender, EventArgs e)
        {
            bd = new BLL_DanhMuc();
            HienThiDanhSachDonViTinh();
        }

        private void HienThiDanhSachDonViTinh()
        {
            dtDonViTinh = new DataTable();
            dtDonViTinh = bd.LayDanhSachDonViTinh(ref err);
            dgvDonViTinh.DataSource = dtDonViTinh;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dgvDonViTinh.EndEdit();
            for(int i=dgvDonViTinh.RowCount-1;i>=0;i--)
            {
                if(dgvDonViTinh.Rows[i].Cells["colChonXoa"].Value.ToString().Equals("1"))
                {
                    bd.DeleteDonViTinh(ref err, dgvDonViTinh.Rows[i].Cells["colMaDonViTinh"].Value.ToString());
                }
            }
            HienThiDanhSachDonViTinh();
        }
    }
}
