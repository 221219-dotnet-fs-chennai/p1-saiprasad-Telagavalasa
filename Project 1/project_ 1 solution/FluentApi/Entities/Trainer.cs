using System;
using System.Collections.Generic;

namespace FluentApi.Entities;

public partial class Trainer
{
    public int TrainerId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public byte? Age { get; set; }

    public string? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? City { get; set; }

    public string? Zipcode { get; set; }

    public virtual ICollection<Availability> Availabilities { get; } = new List<Availability>();

    public virtual ICollection<Company> Companies { get; } = new List<Company>();

    public virtual ICollection<Education> Educations { get; } = new List<Education>();

    public virtual ICollection<Skill> Skills { get; } = new List<Skill>();
}
