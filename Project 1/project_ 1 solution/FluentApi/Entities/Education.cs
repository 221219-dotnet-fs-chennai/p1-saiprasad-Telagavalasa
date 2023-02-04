using System;
using System.Collections.Generic;

namespace FluentApi.Entities;

public partial class Education
{
    public int EduId { get; set; }

    public int? TrainerId { get; set; }

    public string? Institution { get; set; }

    public string? Degree { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
