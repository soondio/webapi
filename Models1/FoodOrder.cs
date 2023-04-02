using System;
using System.Collections.Generic;

namespace WebApplicationLab2.Models1;

public partial class FoodOrder
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public DateTime Date { get; set; }

    public decimal Price { get; set; }

    public int FoodId { get; set; }

    public int? Quantity { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual Food Food { get; set; } = null!;
}
