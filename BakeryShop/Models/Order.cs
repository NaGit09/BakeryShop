using System;
using System.Collections.Generic;

namespace BakeryShop.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string DeliveryAddress { get; set; } = null!;

    public decimal TotalPrice { get; set; }

    public int UserId { get; set; }

    public int PaymentId { get; set; }

    public int DeliveryId { get; set; }

    public virtual Delivery Delivery { get; set; } = null!;

    public virtual Payment Payment { get; set; } = null!;

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();

    public virtual User User { get; set; } = null!;
}
