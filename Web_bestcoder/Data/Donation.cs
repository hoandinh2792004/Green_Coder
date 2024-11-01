using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class Donation
{
    public int DonationId { get; set; }

    public int? UserId { get; set; }

    public decimal Amount { get; set; }

    public DateTime? DonationDate { get; set; }

    public virtual User? User { get; set; }
}
