﻿

namespace BakeryShop.Util;

public partial class User
{
    public int UserId { get; set; }

    public string Gmail { get; set; } = null!;

    public decimal Point { get; set; }

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public int? MembershipId { get; set; }

    public string? RememberMeToken { get; set; }

    public byte Gender { get; set; }

    public String Name { get; set; } = null!;



    public virtual Membership? Membership { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
