using System;
using System.Collections.Generic;

namespace Bakery_API.Models;

public partial class ProductCategory
{
    public int ProductCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
