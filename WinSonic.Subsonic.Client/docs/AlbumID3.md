# WinSonic.Subsonic.Client.Model.AlbumID3
Album with songs.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | The id of the album | 
**Name** | **string** | The album name. | 
**VarVersion** | **string** | The album version name (Remastered, Anniversary Box Set, …). | [optional] 
**Artist** | **string** | Artist name. | [optional] 
**ArtistId** | **string** | The id of the artist | [optional] 
**CoverArt** | **string** | A covertArt id. | [optional] 
**SongCount** | **int** | Number of songs | 
**Duration** | **int** | Total duration of the album in seconds | 
**PlayCount** | **int** | Number of play of the album | [optional] 
**Created** | **DateTime** | Date the album was added. [ISO 8601] | 
**Starred** | **DateTime** | Date the album was added. [ISO 8601] | [optional] 
**Year** | **int** | The album year | [optional] 
**Genre** | **string** | The album genre | [optional] 
**Played** | **DateTime** | Date the album was last played. [ISO 8601] | [optional] 
**UserRating** | **int** | The user rating of the album. [1-5] | [optional] 
**RecordLabels** | [**List&lt;RecordLabel&gt;**](RecordLabel.md) | The labels producing the album. | [optional] 
**MusicBrainzId** | **string** | The album MusicBrainzID. | [optional] 
**Genres** | [**List&lt;ItemGenre&gt;**](ItemGenre.md) | The list of all genres of the album. | [optional] 
**Artists** | [**List&lt;ArtistID3&gt;**](ArtistID3.md) | The list of all album artists of the album. | [optional] 
**DisplayArtist** | **string** | The single value display artist. | [optional] 
**ReleaseTypes** | **List&lt;string&gt;** | The types of this album release. (Album, Compilation, EP, Remix, …). | [optional] 
**Moods** | **List&lt;string&gt;** | The list of all moods of the album. | [optional] 
**SortName** | **string** | The album sort name. | [optional] 
**OriginalReleaseDate** | [**ItemDate**](ItemDate.md) | Date the album was originally released. | [optional] 
**ReleaseDate** | [**ItemDate**](ItemDate.md) | Date the specific edition of the album was released. Note: for files using ID3 tags, releaseDate should generally be read from the TDRL tag. Servers that use a different source for this field should document the behavior. | [optional] 
**IsCompilation** | **bool** | True if the album is a compilation. | [optional] 
**ExplicitStatus** | **ExplicitStatus** |  | [optional] 
**DiscTitles** | [**List&lt;DiscTitle&gt;**](DiscTitle.md) | The list of all disc titles of the album. | [optional] 
**Song** | [**List&lt;Child&gt;**](Child.md) | The list of songs | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

