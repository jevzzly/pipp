using System;
using System.Collections.Generic;

namespace WebApplication1.Entities;

public partial class Artist
{
    public string ArtistName { get; set; } = null!;

    public int ArtistId { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
