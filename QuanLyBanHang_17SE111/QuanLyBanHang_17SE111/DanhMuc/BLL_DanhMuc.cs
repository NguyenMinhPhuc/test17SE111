using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang_17SE111.DanhMuc
{
   public class BLL_DanhMuc
    {
       Database data;
       public BLL_DanhMuc()
       {
           data = new Database();
       }
       public DataTable LayDanhSachDonViTinh(ref string err)
       {
           return data.GetDataTable(ref err, "PSP_DonViTinh_Select", CommandType.StoredProcedure, null);
       }
       public bool DeleteDonViTinh(ref string err, string maDonViTinh)
       {
           return data.MyExcuteNonQuery(ref err, "PSP_DonViTinh_Delete", CommandType.StoredProcedure,
               new SqlParameter("@MaDonViTinh", maDonViTinh));
       }
    }
}
