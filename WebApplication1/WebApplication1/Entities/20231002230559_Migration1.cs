#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplication1.Entities;

/// <inheritdoc />
public partial class Migration1 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "artists",
            table => new
            {
                artist_id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                artist_name = table.Column<string>("character varying", nullable: false)
            },
            constraints: table => { table.PrimaryKey("artists_pk", x => x.artist_id); });

        migrationBuilder.CreateTable(
            "albums",
            table => new
            {
                album_id = table.Column<int>("integer", nullable: false)
                    .Annotation("Npgsql:ValueGenerationStrategy",
                        NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                album_name = table.Column<string>("character varying", nullable: false),
                year = table.Column<int>("integer", nullable: true),
                artist_id = table.Column<int>("integer", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("albums_pk", x => x.album_id);
                table.ForeignKey(
                    "albums_fk",
                    x => x.artist_id,
                    "artists",
                    "artist_id");
            });

        migrationBuilder.CreateIndex(
            "IX_albums_artist_id",
            "albums",
            "artist_id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "albums");

        migrationBuilder.DropTable(
            "artists");
    }
}