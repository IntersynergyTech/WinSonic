using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoverArt",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoverArt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CachedCoverArt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Filename = table.Column<string>(type: "TEXT", nullable: false),
                    ParentItemId = table.Column<string>(type: "TEXT", nullable: true),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CachedCoverArt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CachedCoverArt_CoverArt_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    SongCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CoverArtId = table.Column<string>(type: "TEXT", nullable: true),
                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsReadOnly = table.Column<bool>(type: "INTEGER", nullable: false),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlists_CoverArt_CoverArtId",
                        column: x => x.CoverArtId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlbumMedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlbumId = table.Column<string>(type: "TEXT", nullable: true),
                    DiscId = table.Column<int>(type: "INTEGER", nullable: false),
                    CoverArtId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumMedia_CoverArt_CoverArtId",
                        column: x => x.CoverArtId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    SortTitle = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleaseDateType = table.Column<int>(type: "INTEGER", nullable: true),
                    Version = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistName = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistId = table.Column<string>(type: "TEXT", nullable: true),
                    CoverArtId = table.Column<string>(type: "TEXT", nullable: true),
                    SongCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Duration = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StarredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PlayedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DisplayArtist = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompilation = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsExplicit = table.Column<bool>(type: "INTEGER", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: true),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_CoverArt_CoverArtId",
                        column: x => x.CoverArtId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    SortTitle = table.Column<string>(type: "TEXT", nullable: true),
                    CoverArtId = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumCount = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    StarredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Disambiguation = table.Column<string>(type: "TEXT", nullable: true),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: true),
                    AlbumId = table.Column<string>(type: "TEXT", nullable: true),
                    SongId = table.Column<string>(type: "TEXT", nullable: true),
                    SongId1 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Artists_CoverArt_CoverArtId",
                        column: x => x.CoverArtId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayArtist = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayAlbumArtist = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumId = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistId = table.Column<string>(type: "TEXT", nullable: true),
                    Track = table.Column<int>(type: "INTEGER", nullable: true),
                    CoverArtId = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Bpm = table.Column<int>(type: "INTEGER", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    SortTitle = table.Column<string>(type: "TEXT", nullable: true),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleaseDateType = table.Column<int>(type: "INTEGER", nullable: true),
                    Rating = table.Column<int>(type: "INTEGER", nullable: true),
                    StarredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    SampleRate = table.Column<int>(type: "INTEGER", nullable: false),
                    BitDepth = table.Column<int>(type: "INTEGER", nullable: false),
                    Bitrate = table.Column<int>(type: "INTEGER", nullable: false),
                    ChannelCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Filesize = table.Column<int>(type: "INTEGER", nullable: false),
                    PlaylistId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Songs_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Songs_CoverArt_CoverArtId",
                        column: x => x.CoverArtId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Songs_Playlists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "Playlists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CachedSongs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsOriginal = table.Column<bool>(type: "INTEGER", nullable: false),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Filename = table.Column<string>(type: "TEXT", nullable: false),
                    ParentItemId = table.Column<string>(type: "TEXT", nullable: true),
                    SampleRate = table.Column<int>(type: "INTEGER", nullable: false),
                    BitDepth = table.Column<int>(type: "INTEGER", nullable: false),
                    Bitrate = table.Column<int>(type: "INTEGER", nullable: false),
                    ChannelCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Filesize = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CachedSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CachedSongs_Songs_ParentItemId",
                        column: x => x.ParentItemId,
                        principalTable: "Songs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedia_AlbumId",
                table: "AlbumMedia",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedia_CoverArtId",
                table: "AlbumMedia",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ArtistId",
                table: "Albums",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CoverArtId",
                table: "Albums",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_AlbumId",
                table: "Artists",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CoverArtId",
                table: "Artists",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_SongId",
                table: "Artists",
                column: "SongId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_SongId1",
                table: "Artists",
                column: "SongId1");

            migrationBuilder.CreateIndex(
                name: "IX_CachedCoverArt_ParentItemId",
                table: "CachedCoverArt",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CachedSongs_ParentItemId",
                table: "CachedSongs",
                column: "ParentItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlists_CoverArtId",
                table: "Playlists",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_AlbumId",
                table: "Songs",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_ArtistId",
                table: "Songs",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CoverArtId",
                table: "Songs",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_AlbumMedia_Albums_AlbumId",
                table: "AlbumMedia",
                column: "AlbumId",
                principalTable: "Albums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistId",
                table: "Albums",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Songs_SongId",
                table: "Artists",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artists_Songs_SongId1",
                table: "Artists",
                column: "SongId1",
                principalTable: "Songs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artists_Albums_AlbumId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Albums_AlbumId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Artists_CoverArt_CoverArtId",
                table: "Artists");

            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_CoverArt_CoverArtId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_CoverArt_CoverArtId",
                table: "Songs");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Artists_ArtistId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "AlbumMedia");

            migrationBuilder.DropTable(
                name: "CachedCoverArt");

            migrationBuilder.DropTable(
                name: "CachedSongs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "CoverArt");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
