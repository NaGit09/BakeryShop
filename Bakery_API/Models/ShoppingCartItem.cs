using System;
using System.Collections.Generic;

namespace Bakery_API.Models;

public partial class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }

    public int Quantity { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
    public int CartId { get; internal set; } // dung de xac dinh gio hang tuong tu nhu sessionID
}
