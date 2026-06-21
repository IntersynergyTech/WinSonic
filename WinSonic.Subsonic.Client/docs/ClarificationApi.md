# WinSonic.Subsonic.Client.Api.ClarificationApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetCoverArt**](ClarificationApi.md#getcoverart) | **GET** /rest/getCoverArt | Returns a cover art image. |
| [**GetSimilarSongs**](ClarificationApi.md#getsimilarsongs) | **GET** /rest/getSimilarSongs | Returns a random collection of songs from the given artist and similar artists. |
| [**PostSearch3**](ClarificationApi.md#postsearch3) | **POST** /rest/search3 | Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3) |
| [**PostStream**](ClarificationApi.md#poststream) | **POST** /rest/stream | Streams a given media file. |
| [**Search3**](ClarificationApi.md#search3) | **GET** /rest/search3 | Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3) |
| [**Stream**](ClarificationApi.md#stream) | **GET** /rest/stream | Streams a given media file. |

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

            var apiInstance = new ClarificationApi(config);
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
                Debug.Print("Exception when calling ClarificationApi.GetCoverArt: " + e.Message);
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
    Debug.Print("Exception when calling ClarificationApi.GetCoverArtWithHttpInfo: " + e.Message);
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

<a id="getsimilarsongs"></a>
# **GetSimilarSongs**
> GetSimilarSongsResponse GetSimilarSongs (string id, int? count = null)

Returns a random collection of songs from the given artist and similar artists.

Returns a random collection of songs from the given artist and similar artists, using data from last.fm. Typically used for artist radio features.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetSimilarSongsExample
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

            var apiInstance = new ClarificationApi(config);
            var id = "id_example";  // string | The artist, album or song ID.
            var count = 50;  // int? | Max number of songs to return. (optional)  (default to 50)

            try
            {
                // Returns a random collection of songs from the given artist and similar artists.
                GetSimilarSongsResponse result = apiInstance.GetSimilarSongs(id, count);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ClarificationApi.GetSimilarSongs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSimilarSongsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a random collection of songs from the given artist and similar artists.
    ApiResponse<GetSimilarSongsResponse> response = apiInstance.GetSimilarSongsWithHttpInfo(id, count);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ClarificationApi.GetSimilarSongsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | The artist, album or song ID. |  |
| **count** | **int?** | Max number of songs to return. | [optional] [default to 50] |

### Return type

[**GetSimilarSongsResponse**](GetSimilarSongsResponse.md)

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

<a id="postsearch3"></a>
# **PostSearch3**
> Search3Response PostSearch3 (string query, int? artistCount = null, int? artistOffset = null, int? albumCount = null, int? albumOffset = null, int? songCount = null, int? songOffset = null, string? musicFolderId = null)

Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3)

Returns albums, artists and songs matching the given search criteria. Supports paging through the result.  Music is organized according to ID3 tags.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostSearch3Example
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

            var apiInstance = new ClarificationApi(config);
            var query = "query_example";  // string | Search query. Servers must support an empty query and return all the data to allow clients to properly access all the media information for offline sync.
            var artistCount = 20;  // int? | Maximum number of artists to return. (optional)  (default to 20)
            var artistOffset = 0;  // int? | Search result offset for artists. Used for paging. (optional)  (default to 0)
            var albumCount = 20;  // int? | Maximum number of albums to return. (optional)  (default to 20)
            var albumOffset = 0;  // int? | Search result offset for albums. Used for paging. (optional)  (default to 0)
            var songCount = 20;  // int? | Maximum number of songs to return. (optional)  (default to 20)
            var songOffset = 0;  // int? | Search result offset for songs. Used for paging. (optional)  (default to 0)
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3)
                Search3Response result = apiInstance.PostSearch3(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ClarificationApi.PostSearch3: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostSearch3WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3)
    ApiResponse<Search3Response> response = apiInstance.PostSearch3WithHttpInfo(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ClarificationApi.PostSearch3WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | Search query. Servers must support an empty query and return all the data to allow clients to properly access all the media information for offline sync. |  |
| **artistCount** | **int?** | Maximum number of artists to return. | [optional] [default to 20] |
| **artistOffset** | **int?** | Search result offset for artists. Used for paging. | [optional] [default to 0] |
| **albumCount** | **int?** | Maximum number of albums to return. | [optional] [default to 20] |
| **albumOffset** | **int?** | Search result offset for albums. Used for paging. | [optional] [default to 0] |
| **songCount** | **int?** | Maximum number of songs to return. | [optional] [default to 20] |
| **songOffset** | **int?** | Search result offset for songs. Used for paging. | [optional] [default to 0] |
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**Search3Response**](Search3Response.md)

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

            var apiInstance = new ClarificationApi(config);
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
                Debug.Print("Exception when calling ClarificationApi.PostStream: " + e.Message);
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
    Debug.Print("Exception when calling ClarificationApi.PostStreamWithHttpInfo: " + e.Message);
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

<a id="search3"></a>
# **Search3**
> Search3Response Search3 (string query, int? artistCount = null, int? artistOffset = null, int? albumCount = null, int? albumOffset = null, int? songCount = null, int? songOffset = null, string? musicFolderId = null)

Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3)

Returns albums, artists and songs matching the given search criteria. Supports paging through the result.  Music is organized according to ID3 tags.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class Search3Example
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

            var apiInstance = new ClarificationApi(config);
            var query = "query_example";  // string | Search query. Servers must support an empty query and return all the data to allow clients to properly access all the media information for offline sync.
            var artistCount = 20;  // int? | Maximum number of artists to return. (optional)  (default to 20)
            var artistOffset = 0;  // int? | Search result offset for artists. Used for paging. (optional)  (default to 0)
            var albumCount = 20;  // int? | Maximum number of albums to return. (optional)  (default to 20)
            var albumOffset = 0;  // int? | Search result offset for albums. Used for paging. (optional)  (default to 0)
            var songCount = 20;  // int? | Maximum number of songs to return. (optional)  (default to 20)
            var songOffset = 0;  // int? | Search result offset for songs. Used for paging. (optional)  (default to 0)
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3)
                Search3Response result = apiInstance.Search3(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ClarificationApi.Search3: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the Search3WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3)
    ApiResponse<Search3Response> response = apiInstance.Search3WithHttpInfo(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ClarificationApi.Search3WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | Search query. Servers must support an empty query and return all the data to allow clients to properly access all the media information for offline sync. |  |
| **artistCount** | **int?** | Maximum number of artists to return. | [optional] [default to 20] |
| **artistOffset** | **int?** | Search result offset for artists. Used for paging. | [optional] [default to 0] |
| **albumCount** | **int?** | Maximum number of albums to return. | [optional] [default to 20] |
| **albumOffset** | **int?** | Search result offset for albums. Used for paging. | [optional] [default to 0] |
| **songCount** | **int?** | Maximum number of songs to return. | [optional] [default to 20] |
| **songOffset** | **int?** | Search result offset for songs. Used for paging. | [optional] [default to 0] |
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**Search3Response**](Search3Response.md)

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

            var apiInstance = new ClarificationApi(config);
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
                Debug.Print("Exception when calling ClarificationApi.Stream: " + e.Message);
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
    Debug.Print("Exception when calling ClarificationApi.StreamWithHttpInfo: " + e.Message);
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

