﻿

namespace BakeryShop.Util;

public partial class Status
{
    public int StatusId { get; set; }

    public string Name { get; set; } = null!;

    public int OrderId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
