using System;
using System.Collections.Generic;

namespace TrainerEntity.Entities;

public partial class Education
{
    public long RegisterNo { get; set; }

    public int UserId { get; set; }

    public string? CollegeName { get; set; }

    public string? Stream { get; set; }

    public string? Branch { get; set; }

    public double? Percentage { get; set; }

    public int? StartYear { get; set; }

    public int? EndYear { get; set; }

    public virtual UserTable User { get; set; } = null!;
}
