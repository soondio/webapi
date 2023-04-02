using System;
using System.Collections.Generic;

namespace WebApplicationLab2.Models1;

public partial class Computer
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ProcessorId { get; set; }

    public int VideoCardId { get; set; }

    public int MonitorId { get; set; }

    public int RamId { get; set; }

    public decimal? Priceperhour { get; set; }

    public virtual Monitor Monitor { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; } = new List<Order>();

    public virtual Processor Processor { get; set; } = null!;

    public virtual Ram Ram { get; set; } = null!;

    public virtual VideoCard VideoCard { get; set; } = null!;
}
