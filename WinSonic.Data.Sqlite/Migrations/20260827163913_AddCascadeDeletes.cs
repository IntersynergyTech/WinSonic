using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class AddCascadeDeletes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumMedia_CoverArt_CoverArtId",
                table: "AlbumMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_CoverArt_CoverArtId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_CoverArt_CoverArtId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_CoverArt_CoverArtId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_CoverArt_CoverArtId",
                table: "Songs");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumMedia_CoverArt_CoverArtId",
                table: "AlbumMedia",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_CoverArt_CoverArtId",
                table: "Albums",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_CoverArt_CoverArtId",
                table: "Artists",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_CoverArt_CoverArtId",
                table: "Playlists",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_CoverArt_CoverArtId",
                table: "Songs",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlbumMedia_CoverArt_CoverArtId",
                table: "AlbumMedia");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_CoverArt_CoverArtId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_CoverArt_CoverArtId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_CoverArt_CoverArtId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_CoverArt_CoverArtId",
                table: "Songs");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumMedia_CoverArt_CoverArtId",
                table: "AlbumMedia",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_CoverArt_CoverArtId",
                table: "Albums",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_CoverArt_CoverArtId",
                table: "Artists",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_CoverArt_CoverArtId",
                table: "Playlists",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_CoverArt_CoverArtId",
                table: "Songs",
                column: "CoverArtId",
                principalTable: "CoverArt",
                principalColumn: "Id");
        }
    }
}
