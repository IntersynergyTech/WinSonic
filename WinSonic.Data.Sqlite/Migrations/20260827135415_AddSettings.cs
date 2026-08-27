using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CheckForUpdates = table.Column<bool>(type: "INTEGER", nullable: false),
                    LanguageIetf = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false),
                    ThemeKey = table.Column<string>(type: "TEXT", maxLength: 64, nullable: true),
                    SyncLyrics = table.Column<bool>(type: "INTEGER", nullable: false),
                    OutputDevice = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ReplayGainMode = table.Column<int>(type: "INTEGER", nullable: false),
                    ClippingPrevention = table.Column<int>(type: "INTEGER", nullable: false),
                    Preamp = table.Column<double>(type: "REAL", nullable: true),
                    ServerAddress = table.Column<string>(type: "TEXT", maxLength: 512, nullable: false),
                    Username = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    PasswordCredentialKey = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false),
                    IgnoreSslErrors = table.Column<bool>(type: "INTEGER", nullable: false),
                    ScrobbleToServer = table.Column<bool>(type: "INTEGER", nullable: false),
                    ScrobbleMinimumPercentage = table.Column<double>(type: "REAL", nullable: true),
                    ScrobbleMinimumSeconds = table.Column<double>(type: "REAL", nullable: true),
                    SyncPlayQueue = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
