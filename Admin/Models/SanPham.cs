using System;
using System.Collections.Generic;

namespace Admin.Models;

public partial class SanPham
{
    public int Id { get; set; }

    public string TenSanPham { get; set; } = null!;

    public int SoLuong { get; set; }

    public string? TinhTrang { get; set; }

    public string? DanhMuc { get; set; }

    public string? NhaCungCap { get; set; }

    public int GiaBan { get; set; }

    public int? GiaVon { get; set; }

    public string? AnhSanPham { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
