using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel;
namespace WebApplicationLab2.Models1;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public decimal Balance { get; set; }

    public int Bonus { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<FoodOrder> FoodOrders { get; } = new List<FoodOrder>();

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}

public class ClientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
