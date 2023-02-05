using System;
using System.Collections.Generic;

namespace TrainerEntity.Entities;

public partial class Experience
{
    public int UserId { get; set; }

    public string Company1 { get; set; } = null!;

    public string? Company2 { get; set; }

    public string? Company3 { get; set; }

    public virtual UserTable User { get; set; } = null!;
}
