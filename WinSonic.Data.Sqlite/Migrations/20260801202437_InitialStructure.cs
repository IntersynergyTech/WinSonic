using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WinSonic.Data.Sqlite.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
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
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    SortTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ReleaseDateType = table.Column<int>(type: "INTEGER", nullable: true),
                    Version = table.Column<string>(type: "TEXT", nullable: true),
                    ArtistName = table.Column<string>(type: "TEXT", nullable: true),
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
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    SortTitle = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    CoverArtId = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumCount = table.Column<int>(type: "INTEGER", nullable: true),
                    Type = table.Column<int>(type: "INTEGER", nullable: true),
                    StarredAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Disambiguation = table.Column<string>(type: "TEXT", nullable: true),
                    CacheLastUpdated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CacheExpires = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CacheId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rating = table.Column<int>(type: "INTEGER", nullable: true),
                    Types = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_CoverArt_CoverArtId",
                        column: x => x.CoverArtId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
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
                    ParentItemId = table.Column<string>(type: "TEXT", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Owner = table.Column<string>(type: "TEXT", nullable: true),
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
                    AlbumId = table.Column<string>(type: "TEXT", nullable: false),
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
                        name: "FK_AlbumMedia_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumMedia_CoverArt_CoverArtId",
                        column: x => x.CoverArtId,
                        principalTable: "CoverArt",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AlbumArtist",
                columns: table => new
                {
                    AlbumsId = table.Column<string>(type: "TEXT", nullable: false),
                    ArtistsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumArtist", x => new { x.AlbumsId, x.ArtistsId });
                    table.ForeignKey(
                        name: "FK_AlbumArtist_Albums_AlbumsId",
                        column: x => x.AlbumsId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumArtist_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    DisplayArtist = table.Column<string>(type: "TEXT", nullable: true),
                    DisplayAlbumArtist = table.Column<string>(type: "TEXT", nullable: true),
                    AlbumId = table.Column<string>(type: "TEXT", nullable: true),
                    Track = table.Column<int>(type: "INTEGER", nullable: true),
                    CoverArtId = table.Column<string>(type: "TEXT", nullable: true),
                    Genre = table.Column<string>(type: "TEXT", nullable: true),
                    Bpm = table.Column<int>(type: "INTEGER", nullable: true),
                    Comment = table.Column<string>(type: "TEXT", nullable: true),
                    SortTitle = table.Column<string>(type: "TEXT", nullable: true),
                    Duration = table.Column<int>(type: "INTEGER", nullable: true),
                    IsExplicit = table.Column<bool>(type: "INTEGER", nullable: false),
                    ArtistId = table.Column<string>(type: "TEXT", nullable: true),
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
                    RgTrackGain = table.Column<decimal>(type: "TEXT", nullable: true),
                    RgAlbumGain = table.Column<decimal>(type: "TEXT", nullable: true),
                    RgTrackPeak = table.Column<decimal>(type: "TEXT", nullable: true),
                    RgAlbumPeak = table.Column<decimal>(type: "TEXT", nullable: true)
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
                    ParentItemId = table.Column<string>(type: "TEXT", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSong",
                columns: table => new
                {
                    AppearsInPlaylistsId = table.Column<string>(type: "TEXT", nullable: false),
                    SongsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSong", x => new { x.AppearsInPlaylistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Playlists_AppearsInPlaylistsId",
                        column: x => x.AppearsInPlaylistsId,
                        principalTable: "Playlists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSong_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongToAlbumArtists",
                columns: table => new
                {
                    AlbumArtistsId = table.Column<string>(type: "TEXT", nullable: false),
                    SongsAsAlbumArtistId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongToAlbumArtists", x => new { x.AlbumArtistsId, x.SongsAsAlbumArtistId });
                    table.ForeignKey(
                        name: "FK_SongToAlbumArtists_Artists_AlbumArtistsId",
                        column: x => x.AlbumArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongToAlbumArtists_Songs_SongsAsAlbumArtistId",
                        column: x => x.SongsAsAlbumArtistId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongToArtists",
                columns: table => new
                {
                    ArtistsId = table.Column<string>(type: "TEXT", nullable: false),
                    SongsId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongToArtists", x => new { x.ArtistsId, x.SongsId });
                    table.ForeignKey(
                        name: "FK_SongToArtists_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongToArtists_Songs_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumArtist_ArtistsId",
                table: "AlbumArtist",
                column: "ArtistsId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedia_AlbumId",
                table: "AlbumMedia",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumMedia_CoverArtId",
                table: "AlbumMedia",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_CoverArtId",
                table: "Albums",
                column: "CoverArtId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_CoverArtId",
                table: "Artists",
                column: "CoverArtId");

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
                name: "IX_PlaylistSong_SongsId",
                table: "PlaylistSong",
                column: "SongsId");

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
                name: "IX_SongToAlbumArtists_SongsAsAlbumArtistId",
                table: "SongToAlbumArtists",
                column: "SongsAsAlbumArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SongToArtists_SongsId",
                table: "SongToArtists",
                column: "SongsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumArtist");

            migrationBuilder.DropTable(
                name: "AlbumMedia");

            migrationBuilder.DropTable(
                name: "CachedCoverArt");

            migrationBuilder.DropTable(
                name: "CachedSongs");

            migrationBuilder.DropTable(
                name: "PlaylistSong");

            migrationBuilder.DropTable(
                name: "SongToAlbumArtists");

            migrationBuilder.DropTable(
                name: "SongToArtists");

            migrationBuilder.DropTable(
                name: "Playlists");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "CoverArt");
        }
    }
}
