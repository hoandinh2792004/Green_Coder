using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? RoleId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<DonationManagement> DonationManagements { get; set; } = new List<DonationManagement>();

    public virtual ICollection<DonationRegistration> DonationRegistrations { get; set; } = new List<DonationRegistration>();

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual Role? Role { get; set; }
}
