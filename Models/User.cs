using System;
using System.Collections.Generic;

namespace Web.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public byte Active { get; set; }

    public string? Password { get; set; }

    public string Role { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual Staff? Staff { get; set; }
}
