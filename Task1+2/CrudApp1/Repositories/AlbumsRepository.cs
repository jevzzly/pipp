using System.Collections.Generic;
using System.Linq;
using CrudApp1.Models;
using Dapper;
using Npgsql;

namespace CrudApp1.Repositories
{
    internal class AlbumsRepository : IAlbumsRepository
    {
        private readonly NpgsqlConnection _connection;

        public AlbumsRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public IList<Album> GetAll()
        {
            var result = new List<Album>();
            using var cmd = _connection.CreateCommand();
            var CommandText = "SELECT * FROM albums";


            result = _connection.Query<Album>(CommandText).ToList();

            return result;
        }

        public void Insert(Album album)
        {
            var CommandText = "INSERT INTO albums (album_name, year, artist_id) VALUES (@name, @y, @artist)";

            var queryArguments = new
            {
                name = album.album_name,
                y = album.year,
                artist = album.artist_id
            };

            _connection.Execute(CommandText, queryArguments);
        }

        public void DeleteByName(Album album)
        {
            var CommandText = "DELETE FROM albums WHERE album_name = (@name)";

            var queryArguments = new
            {
                name = album.album_name
            };

            _connection.Execute(CommandText, queryArguments);
        }

        public void UpdateById(Album album)
        {
            var CommandText =
                "UPDATE albums SET album_name = @name, year = @y, artist_id = @artist where album_id = @id";

            var queryArguments = new
            {
                id = album.album_id,
                name = album.album_name,
                y = album.year,
                artist = album.artist_id
            };

            _connection.Execute(CommandText, queryArguments);
        }
    }
}