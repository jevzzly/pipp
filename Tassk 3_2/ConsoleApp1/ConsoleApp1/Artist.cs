using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public partial class Artist
{
    public string ArtistName { get; set; } = null!;

    public int ArtistId { get; set; }

    public virtual ICollection<Album> Albums { get; set; } = new List<Album>();
}
