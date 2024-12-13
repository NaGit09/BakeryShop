using System;
using System.Collections.Generic;

namespace BakeryShop.Models {

    public partial class Image
    {
        public int ImageId { get; set; }

        public int ColorId { get; set; }

        public byte[] Image1 { get; set; } = null!;

        public virtual Color Color { get; set; } = null!;
    }

}
