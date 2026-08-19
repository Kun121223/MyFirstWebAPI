using System;
using System.Collections.Generic;

namespace Web.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public int StoreId { get; set; }

    public int? ManagerId { get; set; }

    public virtual ICollection<Staff> InverseManager { get; set; } = new List<Staff>();

    public virtual Staff? Manager { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual User StaffNavigation { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
