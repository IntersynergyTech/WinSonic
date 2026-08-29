using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddTranscodeSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RequestOriginalFiles",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "TranscodeBitrate",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 320);

            migrationBuilder.AddColumn<int>(
                name: "TranscodeFormat",
                table: "Settings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestOriginalFiles",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TranscodeBitrate",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "TranscodeFormat",
                table: "Settings");
        }
    }
}
