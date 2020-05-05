using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang_17SE111.HeThong
{
    public partial class Frm_SaoLuuPhucHoi : Form
    {
        public Frm_SaoLuuPhucHoi()
        {
            InitializeComponent();
        }
        BLL_HeThong bd;
        string err = string.Empty;
        int count = 0;

        public bool saoLuuStatus = false;
        private void btnChonFile_Click(object sender, EventArgs e)
        {
            if (saoLuuStatus)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Title = "Chọn nơi chứa file backup";
                save.DefaultExt = "bak";
                save.AddExtension = true;
                save.RestoreDirectory = true;

                save.Filter = "Backup files (*.bak)|*.bak";
                save.FileName = string.Format("FileBackup_{0}{1:00}{2:00}{3:00}{4:00}{5:00}", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                if (save.ShowDialog() == DialogResult.OK)
                {
                    txtPath.Text = save.FileName;
                }
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Backup files (*.bak)|*.bak";
                open.RestoreDirectory = true;
                if(open.ShowDialog()==DialogResult.OK)
                {
                    txtPath.Text = open.FileName;
                }
            }
        }

        private void btnThucThi_Click(object sender, EventArgs e)
        {
            if (saoLuuStatus)
            {
                if (!string.IsNullOrEmpty(txtPath.Text))
                {
                    if (!File.Exists(txtPath.Text))
                    {
                        if (bd.SaoLuuDuLieu(ref err, ref count, txtPath.Text))
                        {
                            MessageBox.Show("Sao lưu dữ liệu thành công");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Sao lưu dữ liệu không thành công", "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(txtPath.Text))
                {
                    if (File.Exists(txtPath.Text))
                    {
                        string sql = string.Format("USE Master \n ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE" + " RESTORE DATABASE {1} FROM DISK = N'{2}' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10" + " ALTER DATABASE {3} SET MULTI_USER", Cls_Main.DatabaseName, Cls_Main.DatabaseName, txtPath.Text, Cls_Main.DatabaseName);
                        if (bd.PhucHoiDuLieu(ref err, ref count, sql))
                        {
                            MessageBox.Show("Phục hồi dữ liệu thành công");
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Phục hồi dữ liệu không thành công\n"+err, "Cảnh bảo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void Frm_SaoLuuPhucHoi_Load(object sender, EventArgs e)
        {
            bd = new BLL_HeThong();
            if(saoLuuStatus)
            {
                this.Text = "Thực hiện thao tác sao lưu dữ liệu";
                btnThucThi.Text = "Sao lưu";
            }
            else
            {
                this.Text = "Thực hiện thao tác phục hồi dữ liệu";
                btnThucThi.Text = "Phục hồi";
            }
        }
    }
}
