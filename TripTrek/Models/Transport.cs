using System;
using System.Collections.Generic;

namespace TripTrek.Models;

public partial class Transport
{
    static int newId = 100;
    public int Id { get; set; } = newId++;

    public int? TypeId { get; set; }

    public decimal? Price { get; set; }

    public DateTime? Duration { get; set; }

    public DateTime? DepartureTime { get; set; }

    public int? FromLocationId { get; set; }

    public int? ToLocationId { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();

    public virtual TransportType? Type { get; set; }
}
