using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace Admin.Models;
using Admin.Validations; 

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

   
    [AllowExtensionFile(new string[] { ".png", ".jpg", ".jpeg" })]
    [AllowSizeFile(5 * 1024 * 1024)]
    public IFormFile? AnhSanPham { get; set; }

    // view ten anh
    [AllowNull]
    public string? TenAnhSanPham { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
