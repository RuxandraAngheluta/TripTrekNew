using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TripTrek.Models;

public partial class Account
{
    static int newId = 200;
    public int Id { get; set; } = newId++;

    public string Email { get; set; } = null!;

    public long PhoneNr { get; set; }

    public string Password { get; set; } = null!;

    public int? UserId { get; set; }
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
