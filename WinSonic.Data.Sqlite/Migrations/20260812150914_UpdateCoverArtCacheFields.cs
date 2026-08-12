using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCoverArtCacheFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Length",
                table: "CachedCoverArt");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "CachedCoverArt");

            migrationBuilder.AddColumn<int>(
                name: "Dimension",
                table: "CachedCoverArt",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimension",
                table: "CachedCoverArt");

            migrationBuilder.AddColumn<int>(
                name: "Length",
                table: "CachedCoverArt",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "CachedCoverArt",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
