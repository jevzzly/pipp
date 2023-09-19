using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Npgsql;
using Microsoft.EntityFrameworkCore;


namespace CrudApp1.Models
{
    [Table("albums")]
    public class Album
    {
        [Key]
        [Column("album_id")]
        public int album_id { get; set; }
        [Column("album_name")]
        public string album_name { get; set; }
        [Column("year")]
        public int year { get; set; }
        [ForeignKey("artist_id")]
        public Artist artist { get; set; }
    }
    
    [Table("artists")]
    public class Artist
    {
        [Key]
        [Column("artist_id")]
        public int artist_id { get; set; }
        [Column("artist_name")]
        public string artist_name { get; set; }
    }
    public class Database : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
 
        public Database()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=ep-broad-disk-66916092.us-east-2.aws.neon.tech;Username=dimamatveevdenismatveev;Password=5VnTI3eWMZRQ;Database=neondb");
        }
    }
}