# WinSonic.Subsonic.Client.Model.JukeboxControlResponseSubsonicResponse

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**VarVersion** | **string** | The server supported Subsonic API version. | 
**Type** | **string** | The server actual name. [Ex: Navidrome or gonic] | 
**ServerVersion** | **string** | The server version. | 
**OpenSubsonic** | **bool** | Must return true if the server support OpenSubsonic API v1 | 
**Status** | **string** | The command result. &#x60;failed&#x60; | 
**JukeboxStatus** | [**JukeboxStatus**](JukeboxStatus.md) |  | [optional] 
**JukeboxPlaylist** | [**JukeboxPlaylist**](JukeboxPlaylist.md) |  | [optional] 
**Error** | [**Error**](Error.md) |  | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

