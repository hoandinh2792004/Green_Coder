using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class Users
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string? FullName { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
     //public string? AvatarUrl { get; set; }
    public string PasswordHash { get; set; } = null!;
    public DateTime? CreatedDate { get; set; }
    public bool? IsActive { get; set; }


    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
    public virtual ICollection<Charity> Charities { get; set; } = new List<Charity>();
    public virtual ICollection<CharityRegistration> CharityRegistrations { get; set; } = new List<CharityRegistration>();
    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();
}