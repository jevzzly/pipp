using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public partial class Album
{
    public string AlbumName { get; set; } = null!;

    public int? Year { get; set; }

    public int ArtistId { get; set; }

    public int AlbumId { get; set; }

    public virtual Artist Artist { get; set; } = null!;
}
