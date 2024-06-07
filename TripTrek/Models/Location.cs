﻿using System;
using System.Collections.Generic;

namespace TripTrek.Models;

public partial class Location
{
    static int newId = 100;
    public int Id { get; set; } = newId++;

    public string Country { get; set; } = null!;

    public string City { get; set; } = null!;

    public decimal? TotalRating { get; set; }

    public string? Street { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
