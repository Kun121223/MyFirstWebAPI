using System;
using System.Collections.Generic;

namespace Web.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime PaymentDate { get; set; }

    public string? TransactionCode { get; set; }

    public virtual Order Order { get; set; } = null!;
}
