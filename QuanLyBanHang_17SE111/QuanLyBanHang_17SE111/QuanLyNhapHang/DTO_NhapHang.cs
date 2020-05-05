using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHang_17SE111.QuanLyNhapHang
{
    public class DTO_NhapHang
    {
        private string maPhieuNhap, maNhanVien, maSanPham, tenSanPham, moTa, maDonViTinh, maLoaiSanPham, maNhaCungCap;

        public string MaNhaCungCap
        {
            get { return maNhaCungCap; }
            set { maNhaCungCap = value; }
        }

        public string MaLoaiSanPham
        {
            get { return maLoaiSanPham; }
            set { maLoaiSanPham = value; }
        }

        public string MaDonViTinh
        {
            get { return maDonViTinh; }
            set { maDonViTinh = value; }
        }

        public string MoTa
        {
            get { return moTa; }
            set { moTa = value; }
        }

        public string TenSanPham
        {
            get { return tenSanPham; }
            set { tenSanPham = value; }
        }

        public string MaSanPham
        {
            get { return maSanPham; }
            set { maSanPham = value; }
        }

        public string MaNhanVien
        {
            get { return maNhanVien; }
            set { maNhanVien = value; }
        }

        public string MaPhieuNhap
        {
            get { return maPhieuNhap; }
            set { maPhieuNhap = value; }
        }
        private DateTime ngayNhap;

        public DateTime NgayNhap
        {
            get { return ngayNhap; }
            set { ngayNhap = value; }
        }

        private long soLuongNhap, donGiaNhap, giaBanHienHanh;

        public long GiaBanHienHanh
        {
            get { return giaBanHienHanh; }
            set { giaBanHienHanh = value; }
        }

        public long DonGiaNhap
        {
            get { return donGiaNhap; }
            set { donGiaNhap = value; }
        }

        public long SoLuongNhap
        {
            get { return soLuongNhap; }
            set { soLuongNhap = value; }
        }

    }
}
