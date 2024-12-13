using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string MethodPayment { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
