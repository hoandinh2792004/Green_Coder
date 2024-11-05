using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Image { get; set; }

    public int Quantity { get; set; }

    public string Status { get; set; } = null!;

    public decimal SellingPrice { get; set; }

    public decimal CostPrice { get; set; }

    public int CategoryId { get; set; }

    public int SupplierId { get; set; }

    
    public string Description { get; set; } 

    public DateTime? CreatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ProductCategory Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Supplier Supplier { get; set; } = null!;
}
