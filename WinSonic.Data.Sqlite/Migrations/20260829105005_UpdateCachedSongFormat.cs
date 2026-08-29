using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCachedSongFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BitDepth",
                table: "CachedSongs");

            migrationBuilder.DropColumn(
                name: "ChannelCount",
                table: "CachedSongs");

            migrationBuilder.DropColumn(
                name: "SampleRate",
                table: "CachedSongs");

            migrationBuilder.AddColumn<string>(
                name: "Format",
                table: "CachedSongs",
                type: "TEXT",
                nullable: false,
                defaultValue: "unknown");

            migrationBuilder.Sql(
                """
                UPDATE CachedSongs
                SET Format = CASE
                    WHEN IsOriginal = 1 THEN 'raw'
                    WHEN instr(Filename, '.') > 0 THEN lower(substr(Filename, instr(Filename, '.') + 1))
                    ELSE 'unknown'
                END
                """
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Format",
                table: "CachedSongs");

            migrationBuilder.AddColumn<int>(
                name: "BitDepth",
                table: "CachedSongs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ChannelCount",
                table: "CachedSongs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SampleRate",
                table: "CachedSongs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
