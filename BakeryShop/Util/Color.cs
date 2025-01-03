using System;
using System.Collections.Generic;

namespace BakeryShop.Util;

public partial class Color
{
    public int ColorId { get; set; }

    public string HexCode { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int ProductId { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();
}
