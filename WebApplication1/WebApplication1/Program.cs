using WebApplication1.Context;
using WebApplication1.Entities;
using WebApplication1.DTO;

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
    using (MyDbContext db = new MyDbContext()) //Read
    {
        var albums = 
            db.Albums.Select(x => new {x.Artist.ArtistName, x.AlbumName}).ToList();
        return albums;
    }
});
    
app.MapGet("/artists", () =>
    {
        using (MyDbContext db = new MyDbContext()) //Read
        {
            var artists = db.Artists.ToList();
            return artists;
        }
    });
app.MapDelete("/albums/delete/{id}", (string id) =>
{
    using (MyDbContext db = new MyDbContext()) //Delete
    {
        var albums = db.Albums;
        Album? album = albums.FirstOrDefault(a => a.AlbumId == Convert.ToInt32(id));
        if (album == null) return Results.NotFound(new { message = "album not found" });
        albums.Remove(album);
        return Results.Json(album);
    }
});
app.MapPost("/albums/Post", (AlbumlDto album, string artistName) =>
    {
        using (MyDbContext db = new MyDbContext()) //Post
        {
            var artist = db.Artists.SingleOrDefault(a => a.ArtistName == artistName);
            Album a = new Album
            {
                AlbumName = album.albumName,
                Year = album.Year,
            };
            a.ArtistId = artist.ArtistId;
            db.Albums.Add(a);
            db.SaveChanges();
        }
    });

app.MapPut("/albums/Put", (string artistName, AlbumlDto albumData) => {
        using (MyDbContext db = new MyDbContext())
        {
            // получаем альбом по id
            var album = db.Albums.FirstOrDefault(a => a.AlbumName == albumData.albumName);
            var artist = db.Artists.SingleOrDefault(a => a.ArtistName == artistName);
            // если не найден, отправляем статусный код и сообщение об ошибке
            if (album == null) return Results.NotFound(new { message = "Пользователь не найден" });
            // если альбом найден, изменяем его данные и отправляем обратно клиенту
            album.Year = albumData.Year;
            album.AlbumName = albumData.albumName;
            album.ArtistId = artist.ArtistId;
            db.SaveChanges();
            return Results.Ok(albumData.albumName);

        }
    })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();
//TODO put + patch