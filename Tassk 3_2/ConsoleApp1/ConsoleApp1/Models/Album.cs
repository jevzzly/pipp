/*using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CrudApp1.Models
{
    [Table("albums")]
    public class Album
    {
        [Column("album_id")]
        public int album_id { get; set; }
        [Column("album_name")]
        public string album_name { get; set; }
        [Column("year")]
        public int year { get; set; }
        [ForeignKey("artist_id")]
        public Artist artist { get; set; }
    }
}*/