using System;
using System.Collections.Generic;

namespace BakeryShop.Util;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public decimal Fee { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
