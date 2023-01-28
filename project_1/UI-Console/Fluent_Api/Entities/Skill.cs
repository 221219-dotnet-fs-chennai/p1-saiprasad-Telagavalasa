using System;
using System.Collections.Generic;

namespace Fluent_Api.Entities;

public partial class Skill
{
    public int SkillId { get; set; }

    public int? TrainerId { get; set; }

    public string? SkillName { get; set; }

    public string? Proficiency { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
