using System;
using System.Collections.Generic;

namespace Fluent_Api.Entities;

public partial class Company
{
    public int CmpId { get; set; }

    public int? TrainerId { get; set; }

    public string? CmpName { get; set; }

    public string? Role { get; set; }

    public int? Experience { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
