using System;
using System.Collections.Generic;

namespace KR2RPM5.Models;

public partial class User
{
    public int Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();
}
