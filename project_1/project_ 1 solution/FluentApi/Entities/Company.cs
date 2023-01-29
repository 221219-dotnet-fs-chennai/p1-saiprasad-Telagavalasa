using System;
using System.Collections.Generic;

namespace FluentApi.Entities;

public partial class Company
{
    public int CmpId { get; set; }

    public int? TrainerId { get; set; }

    public string? CmpName { get; set; }

    public string? Role { get; set; }

    public int? Experience { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
