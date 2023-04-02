using System;
using System.Collections.Generic;

namespace WebApplicationLab2.Models1;

public partial class Food
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<FoodOrder> FoodOrders { get; } = new List<FoodOrder>();
}
