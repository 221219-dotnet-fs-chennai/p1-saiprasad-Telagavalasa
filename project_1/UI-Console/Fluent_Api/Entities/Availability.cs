using System;
using System.Collections.Generic;

namespace Fluent_Api.Entities;

public partial class Availability
{
    public int AvaId { get; set; }

    public int? TrainerId { get; set; }

    public string? Day { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public string? HourlyRate { get; set; }

    public virtual Trainer? Trainer { get; set; }
}
