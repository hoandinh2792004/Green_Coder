using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class DonationManagement
{
    public int DonationId { get; set; }

    public int? UserId { get; set; }

    public int? DonatedProductId { get; set; }

    public int Quantity { get; set; }

    public int? LocationId { get; set; }

    public DateTime? DonationDate { get; set; }

    public virtual Product? DonatedProduct { get; set; }

    public virtual Location? Location { get; set; }

    public virtual User? User { get; set; }
}
