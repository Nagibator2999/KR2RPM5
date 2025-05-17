using System;
using System.Collections.Generic;

namespace KR2RPM5.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public string ArticleNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int Status { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
