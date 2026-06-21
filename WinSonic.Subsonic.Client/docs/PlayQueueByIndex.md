# WinSonic.Subsonic.Client.Model.PlayQueueByIndex
NowPlayingEntry with queue index.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**CurrentIndex** | **int** | Index of currently playing track.  This must be provided if one or more entries exists | [optional] 
**Position** | **int** | Position in milliseconds of currently playing track. If not provided, treat this value as 0 | [optional] 
**Username** | **string** | The user this queue belongs to | 
**Changed** | **DateTime** | Date modified [ISO 8601] | 
**ChangedBy** | **string** | Name of client app | 
**Entry** | [**List&lt;Child&gt;**](Child.md) | The list of songs in the queue | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

