using System;
using System.Collections.Generic;

namespace Web_bestcoder.Data;

public partial class UserRole
{
    public int? UserId { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual Users? User { get; set; }
}
