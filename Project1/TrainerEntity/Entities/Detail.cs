using System;
using System.Collections.Generic;

namespace TrainerEntity.Entities;

public partial class Detail
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? AboutMe { get; set; }

    public string? PhoneNo { get; set; }

    public string? EmailId { get; set; }

    public string? Website { get; set; }

    public virtual UserTable User { get; set; } = null!;
}
