using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang_17SE111.QuanLyNhapHang
{
    public class BLL_NhapHang
    {
        Database data;
        public BLL_NhapHang()
        {
            data = new Database();
        }
        /// <summary>
        /// Phương thức dùng để thực thi thủ tục trả về dữ liệu dạng bảng
        /// </summary>
        /// <param name="err">Biến lưu lỗi</param>
        /// <returns>Bảng dữ liệu lấy từ database</returns>
        public DataTable LayChiTietNhapHang(ref string err, string maPhieuNhap)
        {
            return data.GetDataTable(ref err, "PSP_NhapHang_LayChiTietNhapHang", CommandType.StoredProcedure, new SqlParameter("@MaPhieuNhap", maPhieuNhap));
        }
        public object LayMaPhieuNhapLonNhat(ref string err, string maNhanVien)
        {
            return data.MyExecuteScalar(ref err, "PSP_NhapHang_LayMaPhieuNhapLonNhat", CommandType.StoredProcedure,
                new SqlParameter("@MaNhanVien", maNhanVien));
        }
        public object LayMaPhieuNhapLonNhat(ref string err, string maNhanVien, DateTime ngayNhap)
        {
            return data.MyExecuteScalar(ref err, "PSP_NhapHang_LayMaPhieuNhapLonNhatTheoNgay", CommandType.StoredProcedure,
                new SqlParameter("@MaNhanVien", maNhanVien),
                new SqlParameter("@NgayNhap", ngayNhap));
        }
        public DataTable LayDuLieuComboLoaiSanPham(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_NhapHang_LayLoaiSanPhamCbo", CommandType.StoredProcedure, null);
        }
        public DataTable LayDuLieuComboDonViTinh(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_NhapHang_LayDonViTinhCbo", CommandType.StoredProcedure, null);
        }
        public DataTable LayDuLieuComboNhaCungCap(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_NhapHang_LayNhaCungCapCbo", CommandType.StoredProcedure, null);
        }

        public DataTable LayDanhSachSanPhamTheoLoai(ref string err, string maLoaiSanPham)
        {
            return data.GetDataTable(ref err, "PSP_NhapHang_LayThongTinSanPhamTheoLoai", CommandType.StoredProcedure,
                new SqlParameter("@MaLoaiSanPham", maLoaiSanPham));
        }
        public bool InserttChiTietPhieuNhap(ref string err, ref int count, DTO_NhapHang nhapHang)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhapHang_InsertChiTietPhieuNhap", CommandType.StoredProcedure,
                new SqlParameter("@MaPhieuNhap", nhapHang.MaPhieuNhap),
                new SqlParameter("@NgayNhap", nhapHang.NgayNhap),
                new SqlParameter("@MaNhanVien", nhapHang.MaNhanVien),
                new SqlParameter("@MaSanPham", nhapHang.MaSanPham),
                new SqlParameter("@TenSanPham", nhapHang.TenSanPham),
                new SqlParameter("@MoTa", nhapHang.MoTa),
                new SqlParameter("@SoLuongNhap", nhapHang.SoLuongNhap),
                new SqlParameter("@DonGiaNhap", nhapHang.DonGiaNhap),
                new SqlParameter("@MaLoaiSanPham", nhapHang.MaLoaiSanPham),
                new SqlParameter("@MaDonViTinh", nhapHang.MaDonViTinh),
                new SqlParameter("@MaNhaCungCap", nhapHang.MaNhaCungCap),
                   new SqlParameter("@DonGiaBan", nhapHang.GiaBanHienHanh));
        }
        public bool UpdateChiTietPhieuNhap(ref string err, ref int count, DTO_NhapHang nhapHang)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhapHang_UpdateChiTietPhieuNhap", CommandType.StoredProcedure,
                new SqlParameter("@MaPhieuNhap", nhapHang.MaPhieuNhap),
                new SqlParameter("@NgayNhap", nhapHang.NgayNhap),
                new SqlParameter("@MaNhanVien", nhapHang.MaNhanVien),
                new SqlParameter("@MaSanPham", nhapHang.MaSanPham),
                new SqlParameter("@TenSanPham", nhapHang.TenSanPham),
                new SqlParameter("@MoTa", nhapHang.MoTa),
                new SqlParameter("@SoLuongNhap", nhapHang.SoLuongNhap),
                new SqlParameter("@DonGiaNhap", nhapHang.DonGiaNhap),
                new SqlParameter("@MaLoaiSanPham", nhapHang.MaLoaiSanPham),
                new SqlParameter("@MaDonViTinh", nhapHang.MaDonViTinh),
                new SqlParameter("@MaNhaCungCap", nhapHang.MaNhaCungCap),
                 new SqlParameter("@GiaBanHienHanh", nhapHang.GiaBanHienHanh));
        }
        public bool DeleteChiTietPhieuNhap(ref string err, ref int count, DTO_NhapHang nhapHang)
        {
            return data.MyExcuteNonQuery(ref err, ref count, "PSP_NhapHang_XoaChiTietPhieuNhap", CommandType.StoredProcedure,
                new SqlParameter("@MaPhieuNhap", nhapHang.MaPhieuNhap),
                new SqlParameter("@MaSanPham", nhapHang.MaSanPham));
        }

        public DataTable LayTenColumn(ref string err)
        {
            return data.GetDataTable(ref err, "PSP_LayTenColumnChiTietNhapHang", CommandType.StoredProcedure, null);
        }
        public bool XoaPhieuNhapTheoMaPhieu(ref string err, string maPhieuNhap)
        {
            return data.MyExcuteNonQuery(ref err, "PSP_NhapHang_XoaPhieuNhapThepMaPhieu", CommandType.StoredProcedure,
                new SqlParameter("@MaPhieuNhap", maPhieuNhap));
        }
    }
}
