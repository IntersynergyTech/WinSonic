# WinSonic.Subsonic.Client.Model.ReplayGain
The replay gain data of a song. Note: If the data is not present the field must be ommited in the answer. (But the replayGain field on Child must always be present)

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**TrackGain** | **decimal** | The track replay gain value. (In Db) | [optional] 
**AlbumGain** | **decimal** | The album replay gain value. (In Db) | [optional] 
**TrackPeak** | **decimal** | The track peak value. (Must be positive) | [optional] 
**AlbumPeak** | **decimal** | The album peak value. (Must be positive) | [optional] 
**BaseGain** | **decimal** | The base gain value. (In Db) (Ogg Opus Output Gain for example) | [optional] 
**FallbackGain** | **decimal** | An optional fallback gain that clients should apply when the corresponding gain value is missing. (Can be computed from the tracks or exposed as an user setting.) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

