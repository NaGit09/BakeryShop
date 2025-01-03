using System;
using System.Collections.Generic;

namespace BakeryShop.Util;

public partial class Size
{
    public int SizeId { get; set; }

    public int Stock { get; set; }

    public string Size1 { get; set; } = null!;

    public int ColorId { get; set; }

    public virtual Color Color { get; set; } = null!;
}
