using System;
using System.Collections.Generic;

namespace Web.Models;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public int ProductId { get; set; }

    public decimal DiscountPercent { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Product Product { get; set; } = null!;
}
