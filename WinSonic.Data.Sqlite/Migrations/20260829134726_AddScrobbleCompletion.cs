using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddScrobbleCompletion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ScrobbleOnCompletion",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScrobbleOnCompletion",
                table: "Settings");
        }
    }
}
