# WinSonic.Subsonic.Client.Model.Cue
A word or syllable cue within a cueLine

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Start** | **int** | Start time in milliseconds | 
**End** | **int** | End time in milliseconds. Within a cueLine, end must be either present on all cues or none. When the source provides partial end times, servers must fill missing values (e.g., using the next cue&#39;s start, or the cueLine&#39;s end for the final cue). When no cues have end times (e.g., Enhanced LRC with start-only timing), end is omitted from all cues. This is a documented contract rule; this schema does not enforce the all-or-none shape structurally | [optional] 
**ByteStart** | **int** | Required zero-based inclusive UTF-8 byte offset into the parent cueLine.value where this cue begins. The parent cueLine must include value, and the offsets must be calculated against the final cueLine.value with no normalization step | 
**ByteEnd** | **int** | Required zero-based inclusive UTF-8 byte offset into the parent cueLine.value where this cue ends. byteStart must be less than or equal to byteEnd, the parent cueLine must include value, and the offsets must be calculated against the final cueLine.value with no normalization step. This schema does not enforce the cross-field ordering constraint structurally | 
**Value** | **string** | The text of this word or syllable | 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

