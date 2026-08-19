using System;
using System.Collections.Generic;

namespace Web.Models;

public partial class ProductImg
{
    public int ProductImgId { get; set; }

    public int ProductId { get; set; }

    public string? ProductUrl { get; set; }

    public virtual Product Product { get; set; } = null!;
}
