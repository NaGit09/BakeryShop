using System;
using System.Collections.Generic;

namespace Bakery_API.Models;

public partial class Image
{
    public int ImageId { get; set; }

    public int ColorId { get; set; }

    public String Image1 { get; set; } = null!;

    public virtual Color Color { get; set; } = null!;
}
