# WinSonic.Subsonic.Client.Api.MediaRetrievalApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**Download**](MediaRetrievalApi.md#download) | **GET** /rest/download | Downloads a given media file. |
| [**GetAvatar**](MediaRetrievalApi.md#getavatar) | **GET** /rest/getAvatar | Returns the avatar (personal image) for a user. |
| [**GetCaptions**](MediaRetrievalApi.md#getcaptions) | **GET** /rest/getCaptions | Returns captions (subtitles) for a video. |
| [**GetCoverArt**](MediaRetrievalApi.md#getcoverart) | **GET** /rest/getCoverArt | Returns a cover art image. |
| [**GetLyrics**](MediaRetrievalApi.md#getlyrics) | **GET** /rest/getLyrics | Searches for and returns lyrics for a given song. |
| [**GetLyricsBySongId**](MediaRetrievalApi.md#getlyricsbysongid) | **GET** /rest/getLyricsBySongId | Add support for synchronized lyrics, multiple languages, and retrieval by song ID.  |
| [**HlsM3u8**](MediaRetrievalApi.md#hlsm3u8) | **GET** /rest/hls.m3u8 | Downloads a given media file (HLS). |
| [**PostDownload**](MediaRetrievalApi.md#postdownload) | **POST** /rest/download | Downloads a given media file. |
| [**PostGetAvatar**](MediaRetrievalApi.md#postgetavatar) | **POST** /rest/getAvatar | Returns the avatar (personal image) for a user. |
| [**PostGetCaptions**](MediaRetrievalApi.md#postgetcaptions) | **POST** /rest/getCaptions | Returns captions (subtitles) for a video. |
| [**PostGetCoverArt**](MediaRetrievalApi.md#postgetcoverart) | **POST** /rest/getCoverArt | Returns a cover art image. |
| [**PostGetLyrics**](MediaRetrievalApi.md#postgetlyrics) | **POST** /rest/getLyrics | Searches for and returns lyrics for a given song. |
| [**PostGetLyricsBySongId**](MediaRetrievalApi.md#postgetlyricsbysongid) | **POST** /rest/getLyricsBySongId | Add support for synchronized lyrics, multiple languages, and retrieval by song ID. |
| [**PostHlsM3u8**](MediaRetrievalApi.md#posthlsm3u8) | **POST** /rest/hls.m3u8 | Downloads a given media file (HLS). |
| [**PostStream**](MediaRetrievalApi.md#poststream) | **POST** /rest/stream | Streams a given media file. |
| [**Stream**](MediaRetrievalApi.md#stream) | **GET** /rest/stream | Streams a given media file. |

<a id="download"></a>
# **Download**
> System.IO.Stream Download (string id)

Downloads a given media file.

Downloads a given media file. Similar to stream, but this method returns the original media data without transcoding or downsampling.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class DownloadExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory.

            try
            {
                // Downloads a given media file.
                System.IO.Stream result = apiInstance.Download(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.Download: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DownloadWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Downloads a given media file.
    ApiResponse<System.IO.Stream> response = apiInstance.DownloadWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.DownloadWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory. |  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getavatar"></a>
# **GetAvatar**
> System.IO.Stream GetAvatar (string username)

Returns the avatar (personal image) for a user.

Returns the avatar (personal image) for a user.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetAvatarExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var username = "username_example";  // string | 

            try
            {
                // Returns the avatar (personal image) for a user.
                System.IO.Stream result = apiInstance.GetAvatar(username);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.GetAvatar: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAvatarWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the avatar (personal image) for a user.
    ApiResponse<System.IO.Stream> response = apiInstance.GetAvatarWithHttpInfo(username);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.GetAvatarWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** |  |  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getcaptions"></a>
# **GetCaptions**
> System.IO.Stream GetCaptions (string id, string? format = null)

Returns captions (subtitles) for a video.

Returns captions (subtitles) for a video. Use `getVideoInfo` to get a list of available captions.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetCaptionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | The ID of the video.
            var format = "srt";  // string? | Preferred captions format (“srt” or “vtt”). (optional) 

            try
            {
                // Returns captions (subtitles) for a video.
                System.IO.Stream result = apiInstance.GetCaptions(id, format);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.GetCaptions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCaptionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns captions (subtitles) for a video.
    ApiResponse<System.IO.Stream> response = apiInstance.GetCaptionsWithHttpInfo(id, format);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.GetCaptionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the video. |  |
| **format** | **string?** | Preferred captions format (“srt” or “vtt”). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/binary, text/plain


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns the raw video captions. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getcoverart"></a>
# **GetCoverArt**
> System.IO.Stream GetCoverArt (string id, int? size = null)

Returns a cover art image.

Returns a cover art image.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetCoverArtExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | The coverArt ID. Returned by most entities likes `Child` or `AlbumID3`
            var size = 56;  // int? | If specified, scale image to this size. (optional) 

            try
            {
                // Returns a cover art image.
                System.IO.Stream result = apiInstance.GetCoverArt(id, size);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.GetCoverArt: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCoverArtWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a cover art image.
    ApiResponse<System.IO.Stream> response = apiInstance.GetCoverArtWithHttpInfo(id, size);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.GetCoverArtWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The coverArt ID. Returned by most entities likes &#x60;Child&#x60; or &#x60;AlbumID3&#x60; |  |
| **size** | **int?** | If specified, scale image to this size. | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getlyrics"></a>
# **GetLyrics**
> GetLyricsResponse GetLyrics (string? artist = null, string? title = null)

Searches for and returns lyrics for a given song.

Searches for and returns lyrics for a given song.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetLyricsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var artist = "artist_example";  // string? | The artist name. (optional) 
            var title = "title_example";  // string? | The song title. (optional) 

            try
            {
                // Searches for and returns lyrics for a given song.
                GetLyricsResponse result = apiInstance.GetLyrics(artist, title);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.GetLyrics: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLyricsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Searches for and returns lyrics for a given song.
    ApiResponse<GetLyricsResponse> response = apiInstance.GetLyricsWithHttpInfo(artist, title);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.GetLyricsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **artist** | **string?** | The artist name. | [optional]  |
| **title** | **string?** | The song title. | [optional]  |

### Return type

[**GetLyricsResponse**](GetLyricsResponse.md)

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful or failed response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getlyricsbysongid"></a>
# **GetLyricsBySongId**
> GetLyricsBySongIdResponse GetLyricsBySongId (string id, bool? enhanced = null)

Add support for synchronized lyrics, multiple languages, and retrieval by song ID. 

OpenSubsonic extension name `songLyrics` (As returned by `getOpenSubsonicExtensions`). Retrieves all structured lyrics from the server for a given song. The lyrics can come from embedded tags (SYLT/USLT), LRC file/text file, or any other external source.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetLyricsBySongIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | The track ID.
            var enhanced = false;  // bool? | When true, the response includes cueLine arrays with word/syllable-level timing data, required cue byteStart and byteEnd offsets into cueLine.value, and non-main kind tracks (translations, pronunciations). When false or omitted, only kind=main entries are returned with no cueLine data. (optional)  (default to false)

            try
            {
                // Add support for synchronized lyrics, multiple languages, and retrieval by song ID. 
                GetLyricsBySongIdResponse result = apiInstance.GetLyricsBySongId(id, enhanced);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.GetLyricsBySongId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetLyricsBySongIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add support for synchronized lyrics, multiple languages, and retrieval by song ID. 
    ApiResponse<GetLyricsBySongIdResponse> response = apiInstance.GetLyricsBySongIdWithHttpInfo(id, enhanced);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.GetLyricsBySongIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The track ID. |  |
| **enhanced** | **bool?** | When true, the response includes cueLine arrays with word/syllable-level timing data, required cue byteStart and byteEnd offsets into cueLine.value, and non-main kind tracks (translations, pronunciations). When false or omitted, only kind&#x3D;main entries are returned with no cueLine data. | [optional] [default to false] |

### Return type

[**GetLyricsBySongIdResponse**](GetLyricsBySongIdResponse.md)

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful or failed response |  -  |
| **404** | Extension not supported. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="hlsm3u8"></a>
# **HlsM3u8**
> string HlsM3u8 (string id, int? bitRate = null, string? audioTrack = null)

Downloads a given media file (HLS).

Creates an HLS (HTTP Live Streaming) playlist used for streaming video or audio. HLS is a streaming protocol implemented by Apple and works by breaking the overall stream into a sequence of small HTTP-based file downloads. It’s supported by iOS and newer versions of Android. This method also supports adaptive bitrate streaming, see the bitRate parameter.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class HlsM3u8Example
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the media file to stream.
            var bitRate = 56;  // int? | If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If this parameter is specified more than once, the server will create a variant playlist, suitable for adaptive bitrate streaming. The playlist will support streaming at all the specified bitrates. The server will automatically choose video dimensions that are suitable for the given bitrates. Since 1.9.0 you may explicitly request a certain width (480) and height (360) like so: bitRate=1000@480x360 (optional) 
            var audioTrack = "audioTrack_example";  // string? | The ID of the audio track to use. See `getVideoInfo` for how to get the list of available audio tracks for a video. (optional) 

            try
            {
                // Downloads a given media file (HLS).
                string result = apiInstance.HlsM3u8(id, bitRate, audioTrack);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.HlsM3u8: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the HlsM3u8WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Downloads a given media file (HLS).
    ApiResponse<string> response = apiInstance.HlsM3u8WithHttpInfo(id, bitRate, audioTrack);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.HlsM3u8WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the media file to stream. |  |
| **bitRate** | **int?** | If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If this parameter is specified more than once, the server will create a variant playlist, suitable for adaptive bitrate streaming. The playlist will support streaming at all the specified bitrates. The server will automatically choose video dimensions that are suitable for the given bitrates. Since 1.9.0 you may explicitly request a certain width (480) and height (360) like so: bitRate&#x3D;1000@480x360 | [optional]  |
| **audioTrack** | **string?** | The ID of the audio track to use. See &#x60;getVideoInfo&#x60; for how to get the list of available audio tracks for a video. | [optional]  |

### Return type

**string**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/vnd.apple.mpegurl, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful or failed response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="postdownload"></a>
# **PostDownload**
> System.IO.Stream PostDownload (string id)

Downloads a given media file.

Downloads a given media file. Similar to stream, but this method returns the original media data without transcoding or downsampling.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostDownloadExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file to download. Obtained by calls to getMusicDirectory.

            try
            {
                // Downloads a given media file.
                System.IO.Stream result = apiInstance.PostDownload(id);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostDownload: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostDownloadWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Downloads a given media file.
    ApiResponse<System.IO.Stream> response = apiInstance.PostDownloadWithHttpInfo(id);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostDownloadWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file to download. Obtained by calls to getMusicDirectory. |  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="postgetavatar"></a>
# **PostGetAvatar**
> System.IO.Stream PostGetAvatar (string username)

Returns the avatar (personal image) for a user.

Returns the avatar (personal image) for a user.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetAvatarExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var username = "username_example";  // string | The username for which to retrieve the avatar.

            try
            {
                // Returns the avatar (personal image) for a user.
                System.IO.Stream result = apiInstance.PostGetAvatar(username);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostGetAvatar: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetAvatarWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the avatar (personal image) for a user.
    ApiResponse<System.IO.Stream> response = apiInstance.PostGetAvatarWithHttpInfo(username);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostGetAvatarWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The username for which to retrieve the avatar. |  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="postgetcaptions"></a>
# **PostGetCaptions**
> System.IO.Stream PostGetCaptions (string id, string? format = null)

Returns captions (subtitles) for a video.

Returns captions (subtitles) for a video. Use `getVideoInfo` to get a list of available captions.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetCaptionsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | The ID of the video.
            var format = "srt";  // string? | Preferred captions format (“srt” or “vtt”). (optional) 

            try
            {
                // Returns captions (subtitles) for a video.
                System.IO.Stream result = apiInstance.PostGetCaptions(id, format);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostGetCaptions: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetCaptionsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns captions (subtitles) for a video.
    ApiResponse<System.IO.Stream> response = apiInstance.PostGetCaptionsWithHttpInfo(id, format);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostGetCaptionsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The ID of the video. |  |
| **format** | **string?** | Preferred captions format (“srt” or “vtt”). | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/binary, text/plain


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Returns the raw video captions. |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="postgetcoverart"></a>
# **PostGetCoverArt**
> System.IO.Stream PostGetCoverArt (string id, int? size = null)

Returns a cover art image.

Returns a cover art image.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetCoverArtExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | The coverArt ID. Returned by most entities likes `Child` or `AlbumID3`
            var size = 56;  // int? | If specified, scale image to this size. (optional) 

            try
            {
                // Returns a cover art image.
                System.IO.Stream result = apiInstance.PostGetCoverArt(id, size);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostGetCoverArt: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetCoverArtWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a cover art image.
    ApiResponse<System.IO.Stream> response = apiInstance.PostGetCoverArtWithHttpInfo(id, size);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostGetCoverArtWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The coverArt ID. Returned by most entities likes &#x60;Child&#x60; or &#x60;AlbumID3&#x60; |  |
| **size** | **int?** | If specified, scale image to this size. | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="postgetlyrics"></a>
# **PostGetLyrics**
> GetLyricsResponse PostGetLyrics (string? artist = null, string? title = null)

Searches for and returns lyrics for a given song.

Searches for and returns lyrics for a given song.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetLyricsExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var artist = "artist_example";  // string? | The artist name. (optional) 
            var title = "title_example";  // string? | The song title. (optional) 

            try
            {
                // Searches for and returns lyrics for a given song.
                GetLyricsResponse result = apiInstance.PostGetLyrics(artist, title);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostGetLyrics: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetLyricsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Searches for and returns lyrics for a given song.
    ApiResponse<GetLyricsResponse> response = apiInstance.PostGetLyricsWithHttpInfo(artist, title);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostGetLyricsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **artist** | **string?** | The artist name. | [optional]  |
| **title** | **string?** | The song title. | [optional]  |

### Return type

[**GetLyricsResponse**](GetLyricsResponse.md)

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful or failed response |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="postgetlyricsbysongid"></a>
# **PostGetLyricsBySongId**
> GetLyricsBySongIdResponse PostGetLyricsBySongId (string id, bool? enhanced = null)

Add support for synchronized lyrics, multiple languages, and retrieval by song ID.

OpenSubsonic extension name `songLyrics` (As returned by `getOpenSubsonicExtensions`). Retrieves all structured lyrics from the server for a given song. The lyrics can come from embedded tags (SYLT/USLT), LRC file/text file, or any other external source.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetLyricsBySongIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | The track ID.
            var enhanced = false;  // bool? | When true, the response includes cueLine arrays with word/syllable-level timing data, required cue byteStart and byteEnd offsets into cueLine.value, and non-main kind tracks (translations, pronunciations). When false or omitted, only kind=main entries are returned with no cueLine data. (optional)  (default to false)

            try
            {
                // Add support for synchronized lyrics, multiple languages, and retrieval by song ID.
                GetLyricsBySongIdResponse result = apiInstance.PostGetLyricsBySongId(id, enhanced);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostGetLyricsBySongId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetLyricsBySongIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Add support for synchronized lyrics, multiple languages, and retrieval by song ID.
    ApiResponse<GetLyricsBySongIdResponse> response = apiInstance.PostGetLyricsBySongIdWithHttpInfo(id, enhanced);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostGetLyricsBySongIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The track ID. |  |
| **enhanced** | **bool?** | When true, the response includes cueLine arrays with word/syllable-level timing data, required cue byteStart and byteEnd offsets into cueLine.value, and non-main kind tracks (translations, pronunciations). When false or omitted, only kind&#x3D;main entries are returned with no cueLine data. | [optional] [default to false] |

### Return type

[**GetLyricsBySongIdResponse**](GetLyricsBySongIdResponse.md)

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful or failed response |  -  |
| **404** | Extension not supported. |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="posthlsm3u8"></a>
# **PostHlsM3u8**
> string PostHlsM3u8 (string id, int? bitRate = null, string? audioTrack = null)

Downloads a given media file (HLS).

Creates an HLS (HTTP Live Streaming) playlist used for streaming video or audio. HLS is a streaming protocol implemented by Apple and works by breaking the overall stream into a sequence of small HTTP-based file downloads. It’s supported by iOS and newer versions of Android. This method also supports adaptive bitrate streaming, see the bitRate parameter.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostHlsM3u8Example
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the media file to stream.
            var bitRate = 56;  // int? | If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed. (optional) 
            var audioTrack = "audioTrack_example";  // string? | The ID of the audio track to use. See `getVideoInfo` for how to get the list of available audio tracks for a video. (optional) 

            try
            {
                // Downloads a given media file (HLS).
                string result = apiInstance.PostHlsM3u8(id, bitRate, audioTrack);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostHlsM3u8: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostHlsM3u8WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Downloads a given media file (HLS).
    ApiResponse<string> response = apiInstance.PostHlsM3u8WithHttpInfo(id, bitRate, audioTrack);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostHlsM3u8WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the media file to stream. |  |
| **bitRate** | **int?** | If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed. | [optional]  |
| **audioTrack** | **string?** | The ID of the audio track to use. See &#x60;getVideoInfo&#x60; for how to get the list of available audio tracks for a video. | [optional]  |

### Return type

**string**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/vnd.apple.mpegurl, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Successful or failed response |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="poststream"></a>
# **PostStream**
> System.IO.Stream PostStream (string id, int? maxBitRate = null, string? format = null, int? timeOffset = null, string? size = null, bool? estimateContentLength = null, bool? converted = null)

Streams a given media file.

Streams a given media file.  OpenSubsonic servers must not count access to this endpoint as a play and increase playcount. Clients can use the Scrobble endpoint to indicate that a media is played ensuring proper data in all cases.  If the server supports the Transcode Offset extension, then it must accept the timeOffset parameter for music too.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostStreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory.
            var maxBitRate = 56;  // int? | (Since 1.2.0) If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed. (optional) 
            var format = "format_example";  // string? | (Since 1.6.0) Specifies the preferred target format (e.g., “mp3” or “flv”) in case there are multiple applicable transcodings. Starting with 1.9.0 you can use the special value “raw” to disable transcoding. (optional) 
            var timeOffset = 56;  // int? | By default only applicable to video streaming. If specified, start streaming at the given offset (in seconds) into the media. The `Transcode Offset` extension enables the parameter to music too. (optional) 
            var size = "size_example";  // string? | (Since 1.6.0) Only applicable to video streaming. Requested video size specified as WxH, for instance “640x480”. (optional) 
            var estimateContentLength = false;  // bool? | (Since 1.8.0). If set to “true”, the Content-Length HTTP header will be set to an estimated value for transcoded or downsampled media. (optional)  (default to false)
            var converted = false;  // bool? | (Since 1.14.0) Only applicable to video streaming. Servers can optimize videos for streaming by converting them to MP4. If a conversion exists for the video in question, then setting this parameter to “true” will cause the converted video to be returned instead of the original. (optional)  (default to false)

            try
            {
                // Streams a given media file.
                System.IO.Stream result = apiInstance.PostStream(id, maxBitRate, format, timeOffset, size, estimateContentLength, converted);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.PostStream: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostStreamWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Streams a given media file.
    ApiResponse<System.IO.Stream> response = apiInstance.PostStreamWithHttpInfo(id, maxBitRate, format, timeOffset, size, estimateContentLength, converted);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.PostStreamWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory. |  |
| **maxBitRate** | **int?** | (Since 1.2.0) If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed. | [optional]  |
| **format** | **string?** | (Since 1.6.0) Specifies the preferred target format (e.g., “mp3” or “flv”) in case there are multiple applicable transcodings. Starting with 1.9.0 you can use the special value “raw” to disable transcoding. | [optional]  |
| **timeOffset** | **int?** | By default only applicable to video streaming. If specified, start streaming at the given offset (in seconds) into the media. The &#x60;Transcode Offset&#x60; extension enables the parameter to music too. | [optional]  |
| **size** | **string?** | (Since 1.6.0) Only applicable to video streaming. Requested video size specified as WxH, for instance “640x480”. | [optional]  |
| **estimateContentLength** | **bool?** | (Since 1.8.0). If set to “true”, the Content-Length HTTP header will be set to an estimated value for transcoded or downsampled media. | [optional] [default to false] |
| **converted** | **bool?** | (Since 1.14.0) Only applicable to video streaming. Servers can optimize videos for streaming by converting them to MP4. If a conversion exists for the video in question, then setting this parameter to “true” will cause the converted video to be returned instead of the original. | [optional] [default to false] |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |
| **405** | HTTP form POST (&#x60;formPost&#x60;) Extension not supported |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="stream"></a>
# **Stream**
> System.IO.Stream Stream (string id, int? maxBitRate = null, string? format = null, int? timeOffset = null, string? size = null, bool? estimateContentLength = null, bool? converted = null)

Streams a given media file.

Streams a given media file.  OpenSubsonic servers must not count access to this endpoint as a play and increase playcount. Clients can use the Scrobble endpoint to indicate that a media is played ensuring proper data in all cases.  If the server support the Transcode Offet extension, then it must accept the timeOffset parameter for music too.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class StreamExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "https://example-opensubsonic-compatible-server.com";
            // Configure API key authorization: legacyPassword
            config.AddApiKey("p", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("p", "Bearer");
            // Configure API key authorization: salt
            config.AddApiKey("s", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("s", "Bearer");
            // Configure API key authorization: clientName
            config.AddApiKey("c", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("c", "Bearer");
            // Configure API key authorization: apiKeyAuth
            config.AddApiKey("apiKey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("apiKey", "Bearer");
            // Configure API key authorization: format
            config.AddApiKey("f", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("f", "Bearer");
            // Configure API key authorization: protocolVersion
            config.AddApiKey("v", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("v", "Bearer");
            // Configure API key authorization: username
            config.AddApiKey("u", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("u", "Bearer");
            // Configure API key authorization: token
            config.AddApiKey("t", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // config.AddApiKeyPrefix("t", "Bearer");

            var apiInstance = new MediaRetrievalApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory.
            var maxBitRate = 56;  // int? | (Since 1.2.0) If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed. (optional) 
            var format = "format_example";  // string? | (Since 1.6.0) Specifies the preferred target format (e.g., “mp3” or “flv”) in case there are multiple applicable transcodings. Starting with 1.9.0 you can use the special value “raw” to disable transcoding. (optional) 
            var timeOffset = 56;  // int? | By default only applicable to video streaming. If specified, start streaming at the given offset (in seconds) into the media. The `Transcode Offset` extension enables the parameter to music too. (optional) 
            var size = "size_example";  // string? | (Since 1.6.0) Only applicable to video streaming. Requested video size specified as WxH, for instance “640x480”. (optional) 
            var estimateContentLength = false;  // bool? | (Since 1.8.0). If set to “true”, the Content-Length HTTP header will be set to an estimated value for transcoded or downsampled media. (optional)  (default to false)
            var converted = false;  // bool? | (Since 1.14.0) Only applicable to video streaming. Servers can optimize videos for streaming by converting them to MP4. If a conversion exists for the video in question, then setting this parameter to “true” will cause the converted video to be returned instead of the original. (optional)  (default to false)

            try
            {
                // Streams a given media file.
                System.IO.Stream result = apiInstance.Stream(id, maxBitRate, format, timeOffset, size, estimateContentLength, converted);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaRetrievalApi.Stream: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StreamWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Streams a given media file.
    ApiResponse<System.IO.Stream> response = apiInstance.StreamWithHttpInfo(id, maxBitRate, format, timeOffset, size, estimateContentLength, converted);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaRetrievalApi.StreamWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file to stream. Obtained by calls to getMusicDirectory. |  |
| **maxBitRate** | **int?** | (Since 1.2.0) If specified, the server will attempt to limit the bitrate to this value, in kilobits per second. If set to zero, no limit is imposed. | [optional]  |
| **format** | **string?** | (Since 1.6.0) Specifies the preferred target format (e.g., “mp3” or “flv”) in case there are multiple applicable transcodings. Starting with 1.9.0 you can use the special value “raw” to disable transcoding. | [optional]  |
| **timeOffset** | **int?** | By default only applicable to video streaming. If specified, start streaming at the given offset (in seconds) into the media. The &#x60;Transcode Offset&#x60; extension enables the parameter to music too. | [optional]  |
| **size** | **string?** | (Since 1.6.0) Only applicable to video streaming. Requested video size specified as WxH, for instance “640x480”. | [optional]  |
| **estimateContentLength** | **bool?** | (Since 1.8.0). If set to “true”, the Content-Length HTTP header will be set to an estimated value for transcoded or downsampled media. | [optional] [default to false] |
| **converted** | **bool?** | (Since 1.14.0) Only applicable to video streaming. Servers can optimize videos for streaming by converting them to MP4. If a conversion exists for the video in question, then setting this parameter to “true” will cause the converted video to be returned instead of the original. | [optional] [default to false] |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/binary, text/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Success (binary) or error (xml) response |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

