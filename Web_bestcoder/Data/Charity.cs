using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class Charity
{
    public int DonationId { get; set; }

    public int UserId { get; set; }

    public string DonationContent { get; set; } = null!;

    public DateTime? DonationDate { get; set; }

    public bool? IsAnonymous { get; set; }

    public virtual User User { get; set; } = null!;
}
