using WebApplication1.Context;
using WebApplication1.DTO;
using WebApplication1.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapGet("/albums", () =>
{
    var db = new MyDbContext(); //Read

    var albums =
        db.Albums.Select(x => new { x.Artist.ArtistName, x.AlbumName }).ToList();
    return albums;
});

app.MapGet("/artists", () =>
{
    var db = new MyDbContext(); //Read
    var artists = db.Artists.ToList();
    return artists;
});

app.MapDelete("/albums/delete/{id}", (int id) =>
{
    var db = new MyDbContext(); //Delete
    var albums = db.Albums;
    var album = albums.FirstOrDefault(a => a.AlbumId == id);
    if (album == null) return Results.NotFound(new { message = "album not found" });
    albums.Remove(album);
    return Results.Json(album);
});
app.MapPost("/albums/Post", (AlbumlDto album) =>
{
    var db = new MyDbContext(); //Post
    var artist = db.Artists.SingleOrDefault(a => a.ArtistName == album.artist_name);
    if (artist == null) return Results.NotFound(new { message = "No such artist" });
    Album a = new Album
    {
        AlbumName = album.albumName,
        Year = album.Year,
        ArtistId = artist.ArtistId
    };
    db.Albums.Add(a);
    db.SaveChanges();
    return Results.Ok(album);
});

app.MapPut("/albums/Put", (AlbumlDto albumData) =>
    {
        var db = new MyDbContext();

        var album = db.Albums.FirstOrDefault(a => a.AlbumName == albumData.albumName);
        if (album == null) return Results.NotFound(new { message = "No such album" });

        var artist = db.Artists.SingleOrDefault(a => a.ArtistName == albumData.artist_name);
        if (artist == null) return Results.NotFound(new { message = "No such artist" });

        album.Year = albumData.Year;
        album.AlbumName = albumData.albumName;
        album.ArtistId = artist.ArtistId;
        db.SaveChanges();
        return Results.Ok(albumData.albumName);
    })
    .WithOpenApi();

app.Run();