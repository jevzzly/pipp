using System.Collections.Generic;
using System.Linq;
using CrudApp1.Models;
using Dapper;
using Npgsql;

namespace CrudApp1.Repositories
{
    internal class ArtistsRepository : IArtistsRepository

    {
        private readonly NpgsqlConnection _connection;

        public ArtistsRepository(string connectionString)
        {
            _connection = new NpgsqlConnection(connectionString);
            _connection.Open();
        }

        public IList<Artist> GetAll()
        {
            var result = new List<Artist>();
            using var cmd = _connection.CreateCommand();
            var CommandText = "SELECT * FROM artists";

            result = _connection.Query<Artist>(CommandText).ToList();

            return result;
        }

        public void Insert(Artist artist)
        {
            var CommandText = "INSERT INTO artists (artist_name) VALUES (@name)";

            var queryArguments = new
            {
                name = artist.artist_name
            };

            _connection.Execute(CommandText, queryArguments);
        }

        public void DeleteByName(Artist artist)
        {
            var CommandText = "DELETE FROM artists WHERE artist_name = (@name)";

            var queryArguments = new
            {
                name = artist.artist_name
            };

            _connection.Execute(CommandText, queryArguments);
        }

        public void UpdateById(Artist artist)
        {
            var CommandText = "UPDATE artists SET artist_name = (@name) where artist_id = (@id)";

            var queryArguments = new
            {
                id = artist.artist_id,
                name = artist.artist_name
            };

            _connection.Execute(CommandText, queryArguments);
        }
    }
}