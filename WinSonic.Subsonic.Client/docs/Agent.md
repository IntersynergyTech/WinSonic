# WinSonic.Subsonic.Client.Model.Agent
Reusable metadata for a vocal agent within a structuredLyrics entry

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Id** | **string** | Opaque identifier for this agent. The value is only meaningful within the parent structuredLyrics entry and must be unique within that entry | 
**Role** | **string** | Semantic vocal-layer classification for cueLines that reference this agent. One of: main (lead/default vocal layer), voice (additional explicit individual voice part), bg (background vocals), group (group/chorus vocals). When a structuredLyrics entry uses agents for cue-attributed lyrics, it must define exactly one main agent | 
**Name** | **string** | Optional human-readable label for this agent, such as a singer or character name from the source metadata | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

