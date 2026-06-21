# WinSonic.Subsonic.Client.Model.PodcastEpisode

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The id of the media. | 
**Parent** | **string** | The id of the parent (folder/album) | [optional] 
**IsDir** | **bool** | The media is a directory | 
**Title** | **string** | The media name. | 
**Album** | **string** | The album name. | [optional] 
**Artist** | **string** | The artist name. | [optional] 
**Track** | **int** | The track number. | [optional] 
**Year** | **int** | The media year. | [optional] 
**Genre** | **string** | The media genre | [optional] 
**CoverArt** | **string** | The coverArt id. | [optional] 
**Size** | **int** | A file size of the media. | [optional] 
**ContentType** | **string** | The mimeType of the media. | [optional] 
**Suffix** | **string** | The file suffix of the media. | [optional] 
**TranscodedContentType** | **string** | The transcoded mediaType if transcoding should happen. | [optional] 
**TranscodedSuffix** | **string** | The file suffix of the transcoded media. | [optional] 
**Duration** | **int** | The duration of the media in seconds. | [optional] 
**BitRate** | **int** | The bitrate of the media. | [optional] 
**BitDepth** | **int** | The bit depth of the media. | [optional] 
**SamplingRate** | **int** | The sampling rate of the media. | [optional] 
**ChannelCount** | **int** | The number of channels of the media. | [optional] 
**Path** | **string** | The full path of the media. | [optional] 
**IsVideo** | **bool** | Media is a video | [optional] 
**UserRating** | **int** | The user rating of the media [1-5] | [optional] 
**AverageRating** | **decimal** | The average rating of the media [1.0-5.0] | [optional] 
**PlayCount** | **int** | The play count. | [optional] 
**DiscNumber** | **int** | The disc number. | [optional] 
**Created** | **DateTime** | Date the media was created. [ISO 8601] | [optional] 
**Starred** | **DateTime** | Date the media was starred. [ISO 8601] | [optional] 
**AlbumId** | **string** | The corresponding album id | [optional] 
**ArtistId** | **string** | The corresponding artist id | [optional] 
**Type** | **GenericMediaType** |  | [optional] 
**MediaType** | **MediaType** |  | [optional] 
**BookmarkPosition** | **int** | The bookmark position in seconds | [optional] 
**OriginalWidth** | **int** | The video original Width | [optional] 
**OriginalHeight** | **int** | The video original Height | [optional] 
**Played** | **DateTime** | Date the album was last played. [ISO 8601] | [optional] 
**Bpm** | **int** | The BPM of the song. | [optional] 
**Comment** | **string** | The comment tag of the song. | [optional] 
**SortName** | **string** | The song sort name. | [optional] 
**MusicBrainzId** | **string** | The track MusicBrainzID. | [optional] 
**Isrc** | **List&lt;string&gt;** | The track ISRC(s). | [optional] 
**Genres** | [**List&lt;ItemGenre&gt;**](ItemGenre.md) | The list of all genres of the song. | [optional] 
**Artists** | [**List&lt;ArtistID3&gt;**](ArtistID3.md) | The list of all song artists of the song. (Note: Only the required &#x60;ArtistID3&#x60; fields should be returned by default) | [optional] 
**DisplayArtist** | **string** | The single value display artist. | [optional] 
**AlbumArtists** | [**List&lt;ArtistID3&gt;**](ArtistID3.md) | The list of all album artists of the song. (Note: Only the required &#x60;ArtistID3&#x60; fields should be returned by default) | [optional] 
**DisplayAlbumArtist** | **string** | The single value display album artist. | [optional] 
**Contributors** | [**List&lt;Contributor&gt;**](Contributor.md) | The list of all contributor artists of the song. | [optional] 
**DisplayComposer** | **string** | The single value display composer. | [optional] 
**Moods** | **List&lt;string&gt;** | The list of all moods of the song. | [optional] 
**ReplayGain** | [**ReplayGain**](ReplayGain.md) | The replay gain data of the song. | [optional] 
**ExplicitStatus** | **ExplicitStatus** |  | [optional] 
**Works** | [**List&lt;Work&gt;**](Work.md) | The list of works associated with the song. | [optional] 
**Movements** | [**List&lt;Movement&gt;**](Movement.md) | The list of movements associated with the song. | [optional] 
**Groupings** | **List&lt;string&gt;** | The list of groupings associated with the song. | [optional] 
**StreamId** | **string** | ID used for streaming podcast | [optional] 
**ChannelId** | **string** | TID of the podcast channel | 
**Description** | **string** | Episode description | [optional] 
**Status** | **PodcastStatus** |  | 
**PublishDate** | **DateTime** | Date the episode was published [ISO 8601] | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

