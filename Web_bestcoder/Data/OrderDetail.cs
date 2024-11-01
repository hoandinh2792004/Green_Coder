using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Price { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Product? Product { get; set; }
}
