using System;
using System.Collections.Generic;

namespace Web.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int OrderId { get; set; }

    public virtual Order Order { get; set; } = null!;
}
