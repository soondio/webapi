using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace WebApplicationLab2.Models1;

public partial class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int ComputerId { get; set; }

    public DateTime Date { get; set; }

    public DateTime EndDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Client Client { get; set; }

    public virtual Computer Computer { get; set; }




}

public class OrderDto
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public decimal? TotalPrice { get; set; }
    public int ComputerId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public ClientDto? Client { get; set; }
}
