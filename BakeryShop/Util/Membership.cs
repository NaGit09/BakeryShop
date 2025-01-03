using System;
using System.Collections.Generic;

namespace BakeryShop.Util;

public partial class Membership
{
    public int MembershipId { get; set; }

    public int PointsRequired { get; set; }

    public string Endow { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
