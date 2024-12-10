using System;
using System.Collections.Generic;

namespace Bakery_API.Models;

public partial class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
