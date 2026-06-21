# WinSonic.Subsonic.Client.Model.SonicMatch
A sonic match entry, containing a Child entry object and a normalized similarity score.

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Entry** | [**Child**](Child.md) |  | 
**Similarity** | **decimal** | The normalized similarity score (1.0 &#x3D; same exact song, 0.0 &#x3D; most different). For getSonicSimilarTracks, relative to the query song. For findSonicPath, relative to the starting song. Returns -1 when similarity is not supported by the server. | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

