using System;
using System.Collections.Generic;

namespace TrainerEntity.Entities;

public partial class Skill
{
    public int UserId { get; set; }

    public string Skill1 { get; set; } = null!;

    public string? Skill2 { get; set; }

    public string? Skill3 { get; set; }

    public virtual UserTable User { get; set; } = null!;
}
