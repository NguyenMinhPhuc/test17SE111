using QuanLyBanHang_17SE111.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang_17SE111.HeThong
{
    public class BLL_HeThong
    {
        Database data;
        public BLL_HeThong()
        {
            data = new Database();
        }

        public DataTable KiemTraDangNhap(ref string err,string tenDangNhap  ,string matKhau)
        {
            return data.GetDataTable(ref err, "PSP_NhanVien_KiemTraDangNhap", CommandType.StoredProcedure, 
                new SqlParameter("@TenDangNhap", tenDangNhap),
                new SqlParameter("@MatKhau",matKhau));
        }
        public DataTable LayDanhSachNhanVien(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_NhanVien_LayDanhSachNhanVien", CommandType.StoredProcedure, null);
        }
        public bool CapNhatNhanVien(ref string err,ref int count,NhanVien nhanVien)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhanVien_InsertVaUpdate", CommandType.StoredProcedure,
                new SqlParameter("@MaNhanVien", nhanVien.MaNhanVien),
                new SqlParameter("@TenNhanVien", nhanVien.TenNhanVien),
                new SqlParameter("@TenDangNhap", nhanVien.TenDangNhap),
                new SqlParameter("@NgaySinh", nhanVien.NgaySinh),
                new SqlParameter("@DienThoai", nhanVien.DienThoai),
                new SqlParameter("@MaTaiKhoan", nhanVien.MaTaiKhoan),
                new SqlParameter("@MatKhau", nhanVien.MatKhau));
        }
        public DataTable LayDuLieuComboTaiKhoan(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_TaiKhoan_LayCombo", CommandType.StoredProcedure, null);
        }

        public bool XoaNhanVienByDelete(ref string err,ref int count, string maNhanVien)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhanVien_Delete", CommandType.StoredProcedure,
                new SqlParameter("@MaNhanVien", maNhanVien));
        }

        public bool XoaNhanVienByDeleteByUpdateIsDelete(ref string err, ref int count, string maNhanVien)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhanVien_DeleteByUpdateIsDelete", CommandType.StoredProcedure,
                new SqlParameter("@MaNhanVien", maNhanVien));
        }
        public bool SaoLuuDuLieu(ref string err, ref int count,string pathFile)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_SaoLuuDuLieu", CommandType.StoredProcedure,
                new SqlParameter("@duongdan", pathFile));
        }
        public bool PhucHoiDuLieu(ref string err, ref int count,string sql)
        {
            return data.MyExcuteNonQuery(ref err, ref count, sql, CommandType.Text,
              null);
        }

        #region Chức năng đổi mật khẩu
        public DataTable LayDuLieuCboNhanVien(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_NhanVien_LayDuLieuCbo", CommandType.StoredProcedure, null);
        }

        public bool ResetMatKhau(ref string err, ref int count,string maNhanVien)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhanVien_ResetMatKhau", CommandType.StoredProcedure,
                new SqlParameter("@MaNhanVien", maNhanVien));
        }

        public bool DoiMatKhau(ref string err, ref int count, string maNhanVien,string matKhau)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhanVien_DoiMatKhau", CommandType.StoredProcedure,
                new SqlParameter("@MaNhanVien", maNhanVien),
                 new SqlParameter("@MatKhau", matKhau));
        }
        #endregion
    }
}
