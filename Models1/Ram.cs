using System;
using System.Collections.Generic;

namespace WebApplicationLab2.Models1;

public partial class Ram
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Computer> Computers { get; } = new List<Computer>();
}
