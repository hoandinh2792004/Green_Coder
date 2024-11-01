using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class DonationRegistration
{
    public int RegistrationId { get; set; }

    public int UserId { get; set; }

    public int LocationId { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime ParticipationDate { get; set; }

    public string? Status { get; set; }

    public virtual Location Location { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
