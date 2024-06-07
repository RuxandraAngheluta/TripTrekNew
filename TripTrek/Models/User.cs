using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;

namespace TripTrek.Models;

public partial class User
{
    static int newId = 200;
    public int Id { get; set; } = newId++;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? BirthDate { get; set; }

    public int AccountId { get; set; }
    
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
    [JsonIgnore]
    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
