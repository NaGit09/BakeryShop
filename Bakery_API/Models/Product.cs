using System;
using System.Collections.Generic;

namespace Bakery_API.Models;

public partial class Product
{
    public int ProductId { get; set; }
    public string description { get; set; }
    public string Img { get; set; }
    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public int ProductCategoryId { get; set; }

    public int GroupProductId { get; set; }

    public virtual ICollection<Color> Colors { get; set; } = new List<Color>();

    public virtual GroupProduct GroupProduct { get; set; } = null!;

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
}
