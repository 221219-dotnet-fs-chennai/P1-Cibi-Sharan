using System;
using System.Collections.Generic;

namespace TrainerEntity.Entities;

public partial class UserTable
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? EmailId { get; set; }

    public string? Password { get; set; }

    public virtual Detail? Detail { get; set; }

    public virtual Education? Education { get; set; }

    public virtual Experience? Experience { get; set; }

    public virtual Skill? Skill { get; set; }
}
