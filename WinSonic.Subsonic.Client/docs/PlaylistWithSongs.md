# WinSonic.Subsonic.Client.Model.PlaylistWithSongs

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Id of the playlist | 
**Name** | **string** | Name of the playlist | 
**Comment** | **string** | A comment | [optional] 
**Owner** | **string** | Owner of the playlist | [optional] 
**Public** | **bool** | Is the playlist public | [optional] 
**SongCount** | **int** | number of songs | 
**Duration** | **int** | Playlist duration in seconds | 
**Created** | **DateTime** | Creation date [ISO 8601] | 
**Changed** | **DateTime** | Last changed date [ISO 8601] | 
**CoverArt** | **string** | A cover Art Id | [optional] 
**AllowedUser** | **List&lt;string&gt;** | A list of allowed usernames | [optional] 
**Readonly** | **bool** | [OS] If true the playlist cannot be edited by the current user | [optional] 
**ValidUntil** | **DateTime** | [OS] Date the playlist contents are considered valid until [ISO 8601]. Empty or absent means no caching guarantee. | [optional] 
**Entry** | [**List&lt;Child&gt;**](Child.md) | The list of songs | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

