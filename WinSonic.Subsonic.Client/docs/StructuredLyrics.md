# WinSonic.Subsonic.Client.Model.StructuredLyrics
Structured lyrics

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Lang** | **string** | The lyrics language (ideally ISO 639). If the language is unknown (e.g. lrc file), the server must return &#x60;und&#x60; (ISO standard) or &#x60;xxx&#x60; (common value for taggers). Ideally, the server will return lang as an ISO 639 (2/3) code. However, tagged files and external lyrics can come with any value as a potential language code, so clients should take care when displaying lang.  Furthermore, there is special behavior for the value xxx. While not an ISO code, it is commonly used by taggers and other parsing software. Clients should treat xxx as not having a specified language (equivalent to the und code). | 
**Synced** | **bool** | True if the lyrics are synced, false otherwise | 
**Line** | [**List&lt;Line&gt;**](Line.md) | The actual lyrics. Ordered by start time (synced) or appearance order (unsynced) | 
**DisplayArtist** | **string** | The artist name to display. This could be the localized name, or any other value | [optional] 
**DisplayTitle** | **string** | The title to display. This could be the song title (localized), or any other value | [optional] 
**Offset** | **decimal** | The offset to apply to all lyrics, in milliseconds. Positive means lyrics appear sooner, negative means later. If not included, the offset must be assumed to be 0 | [optional] 
**Kind** | **string** | The primary lyric-layer classification for this structuredLyrics entry. One of: main (primary vocals for this entry, default if omitted), translation (a translation of another lyric layer into another language), pronunciation (a phonetic/romanized rendering, e.g. romaji for Japanese, pinyin for Chinese). Tracks are independent across kind values; clients should not assume 1:1 line or cue alignment between entries. Only returned when enhanced&#x3D;true | [optional] 
**Agents** | [**List&lt;Agent&gt;**](Agent.md) | Reusable per-track attribution metadata for cueLine entries. When present, agents must contain at least one entry, and each agents[].id must be unique within this structuredLyrics entry. Agents are optional for simple unattributed single-layer lyrics. When a structuredLyrics entry represents multiple vocal agents or layers, it must include agents; a single-agent attributed or default entry may also include agents, and if it does, exactly one agent must use role main. Agents should not be emitted without cueLine data | [optional] 
**CueLine** | [**List&lt;CueLine&gt;**](CueLine.md) | Word/syllable-level timing data. Each cueLine corresponds to a line in this structuredLyrics entry by its index field. Every cueLine includes value, and every cue includes byteStart and byteEnd offsets into that exact string. If agents is present, every cueLine in the entry must include agentId, and each agentId must match exactly one agents[].id in that entry. If agents is absent, cueLines must not include agentId. Only returned when enhanced&#x3D;true and synced is true | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

