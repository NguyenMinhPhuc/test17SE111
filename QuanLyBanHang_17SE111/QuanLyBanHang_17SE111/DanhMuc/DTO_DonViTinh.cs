using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang_17SE111.DanhMuc
{
    public class DTO_DonViTinh
    {
        string maDonViTinh, tenDonViTinh, moTa;

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        public string TenDonViTinh
        {
            get { return tenDonViTinh; }
            set { tenDonViTinh = value; }
        }

        public string MaDonViTinh
        {
            get { return maDonViTinh; }
            set { maDonViTinh = value; }
        }
        bool isDelete;

        public bool IsDelete
        {
            get { return isDelete; }
            set { isDelete = value; }
        }
    }
}
