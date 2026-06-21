using WinSonic.Core.Models;
using Api = WinSonic.Subsonic.Client.Model;

namespace WinSonic.Subsonic.Helpers;

public static class SubsonicModelExtensions
{
    public static Artist ToArtist(Api.ArtistID3 artist)
    {
        return new Artist(artist.Id, artist.Name, artist.SortName);
    }

    public static Song ToSong(Api.Child song)
    {
        if (song.MediaType != Api.MediaType.Song)
        {
            throw new ArgumentException("The provided child is not a song.");
        }
        return new Song(song.Id, song.Album, song.AlbumId, song.Artist, song.Artists.ConvertArray(ToArtist), song.CoverArt, song.IsExplicit(), ToReplayGain(song.ReplayGain));
    }

    public static bool IsExplicit(this Api.Child child)
    {
        return child.ExplicitStatus == Api.ExplicitStatus.Explicit;
    }

    public static ReplayGain ToReplayGain(Api.ReplayGain replayGain)
    {
        return new ReplayGain(replayGain.TrackGain, replayGain.TrackPeak, replayGain.AlbumGain, replayGain.AlbumPeak);
    }
}
