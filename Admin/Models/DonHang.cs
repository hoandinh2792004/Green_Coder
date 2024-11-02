using System;
using System.Collections.Generic;

namespace Admin.Models;

public partial class DonHang
{
    public int Id { get; set; }

    public string? TenKhachHang { get; set; }

    public int? Sdt { get; set; }

    public string? DiaChi { get; set; }

    public string? TenNguoiBan { get; set; }

    public string? SoHieuNguoiBan { get; set; }

    public DateTime? NgayBan { get; set; }

    public string? TenSanPham { get; set; }

    public int? MaSanPham { get; set; }

    public int? SoLuong { get; set; }

    public string? TinhTrang { get; set; }

    public string? GhiChu { get; set; }

    public virtual SanPham? MaSanPhamNavigation { get; set; }
}
