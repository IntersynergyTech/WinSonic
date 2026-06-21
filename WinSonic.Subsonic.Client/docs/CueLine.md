# WinSonic.Subsonic.Client.Model.CueLine
Word/syllable-level timing data for a lyrics line

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Index** | **int** | Zero-based index into the parent line array this cueLine corresponds to | 
**Start** | **int** | Start time in milliseconds (may differ from the parent line if cues are more precise) | [optional] 
**End** | **int** | End time in milliseconds | [optional] 
**Value** | **string** | Required full text of the line. Nested cue byteStart and byteEnd offsets are always calculated against this exact final UTF-8 string | 
**AgentId** | **string** | Opaque identifier referencing an agent in the same structuredLyrics entry. If the parent structuredLyrics entry includes agents, every cueLine in that entry must include agentId, and the value must match exactly one agents[].id in that entry. If the parent entry does not include agents, cueLines must not include agentId. When multiple cueLines share the same index, the cueLine whose referenced agent has role main must come first | [optional] 
**Cue** | [**List&lt;Cue&gt;**](Cue.md) | Ordered list of word/syllable cues. Every cue includes required byteStart and byteEnd offsets into value | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

