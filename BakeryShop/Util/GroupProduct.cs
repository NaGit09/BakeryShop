﻿using System;
using System.Collections.Generic;

namespace BakeryShop.Util;

public partial class GroupProduct
{
    public int GroupProductId { get; set; }

    public string Name { get; set; } = null!;

    public byte[]? Image { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
