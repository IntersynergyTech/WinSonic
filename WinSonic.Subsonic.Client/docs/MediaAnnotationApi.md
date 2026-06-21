# WinSonic.Subsonic.Client.Api.MediaAnnotationApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**PostReportPlayback**](MediaAnnotationApi.md#postreportplayback) | **POST** /rest/reportPlayback | Reports playback timeline state for a song. |
| [**PostScrobble**](MediaAnnotationApi.md#postscrobble) | **POST** /rest/scrobble | Registers the local playback of one or more media files. |
| [**PostSetRating**](MediaAnnotationApi.md#postsetrating) | **POST** /rest/setRating | Sets the rating for a music file. |
| [**PostStar**](MediaAnnotationApi.md#poststar) | **POST** /rest/star | Attaches a star to a song, album or artist. |
| [**PostUnstar**](MediaAnnotationApi.md#postunstar) | **POST** /rest/unstar | Removes a star to a song, album or artist. |
| [**ReportPlayback**](MediaAnnotationApi.md#reportplayback) | **GET** /rest/reportPlayback | Reports playback timeline state for a song. |
| [**Scrobble**](MediaAnnotationApi.md#scrobble) | **GET** /rest/scrobble | Registers the local playback of one or more media files. |
| [**SetRating**](MediaAnnotationApi.md#setrating) | **GET** /rest/setRating | Sets the rating for a music file. |
| [**Star**](MediaAnnotationApi.md#star) | **GET** /rest/star | Attaches a star to a song, album or artist. |
| [**Unstar**](MediaAnnotationApi.md#unstar) | **GET** /rest/unstar | Removes a star to a song, album or artist. |

<a id="postreportplayback"></a>
# **PostReportPlayback**
> SubsonicResponse PostReportPlayback (string mediaId, string mediaType, int positionMs, string state, float? playbackRate = null, bool? ignoreScrobble = null)

Reports playback timeline state for a song.

OpenSubsonic extension name `playbackReport` (As returned by `getOpenSubsonicExtensions`). Reports playback timeline state for a song.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostReportPlaybackExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var mediaId = "mediaId_example";  // string | TThe ID of the media.
            var mediaType = "song";  // string | The type of the media.
            var positionMs = 56;  // int | The playback position in milliseconds.
            var state = "starting";  // string | Playback state.
            var playbackRate = 1.0F;  // float? | Playback speed multiplier. (optional)  (default to 1.0F)
            var ignoreScrobble = false;  // bool? | If true, server should only update now-playing display/state and should not trigger scrobble/playcount side effects. (optional)  (default to false)

            try
            {
                // Reports playback timeline state for a song.
                SubsonicResponse result = apiInstance.PostReportPlayback(mediaId, mediaType, positionMs, state, playbackRate, ignoreScrobble);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.PostReportPlayback: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostReportPlaybackWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Reports playback timeline state for a song.
    ApiResponse<SubsonicResponse> response = apiInstance.PostReportPlaybackWithHttpInfo(mediaId, mediaType, positionMs, state, playbackRate, ignoreScrobble);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.PostReportPlaybackWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **mediaId** | **string** | TThe ID of the media. |  |
| **mediaType** | **string** | The type of the media. |  |
| **positionMs** | **int** | The playback position in milliseconds. |  |
| **state** | **string** | Playback state. |  |
| **playbackRate** | **float?** | Playback speed multiplier. | [optional] [default to 1.0F] |
| **ignoreScrobble** | **bool?** | If true, server should only update now-playing display/state and should not trigger scrobble/playcount side effects. | [optional] [default to false] |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="postscrobble"></a>
# **PostScrobble**
> SubsonicResponse PostScrobble (string id, int? time = null, bool? submission = null)

Registers the local playback of one or more media files.

Registers the local playback of one or more media files. Typically used when playing media that is cached on the client. This operation includes the following:  * “Scrobbles” the media files on last.fm if the user has configured his/her last.fm credentials on the server. * Updates the play count and last played timestamp for the media files. (Since 1.11.0) * Makes the media files appear in the “Now playing” page in the web app, and appear in the list of songs returned by getNowPlaying (Since 1.11.0)  Since 1.8.0 you may specify multiple id (and optionally time) parameters to scrobble multiple files.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostScrobbleExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file to scrobble.
            var time = 56;  // int? | (Since 1.8.0) The time (in milliseconds since 1 Jan 1970) at which the song was listened to. (optional) 
            var submission = true;  // bool? | Whether this is a “submission” or a “now playing” notification. (optional)  (default to true)

            try
            {
                // Registers the local playback of one or more media files.
                SubsonicResponse result = apiInstance.PostScrobble(id, time, submission);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.PostScrobble: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostScrobbleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Registers the local playback of one or more media files.
    ApiResponse<SubsonicResponse> response = apiInstance.PostScrobbleWithHttpInfo(id, time, submission);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.PostScrobbleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file to scrobble. |  |
| **time** | **int?** | (Since 1.8.0) The time (in milliseconds since 1 Jan 1970) at which the song was listened to. | [optional]  |
| **submission** | **bool?** | Whether this is a “submission” or a “now playing” notification. | [optional] [default to true] |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="postsetrating"></a>
# **PostSetRating**
> SubsonicResponse PostSetRating (string id, int rating)

Sets the rating for a music file.

Sets the rating for a music file.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostSetRatingExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file (song) or folder (album/artist) to rate.
            var rating = 56;  // int | The rating between 1 and 5 (inclusive), or 0 to remove the rating.

            try
            {
                // Sets the rating for a music file.
                SubsonicResponse result = apiInstance.PostSetRating(id, rating);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.PostSetRating: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostSetRatingWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Sets the rating for a music file.
    ApiResponse<SubsonicResponse> response = apiInstance.PostSetRatingWithHttpInfo(id, rating);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.PostSetRatingWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file (song) or folder (album/artist) to rate. |  |
| **rating** | **int** | The rating between 1 and 5 (inclusive), or 0 to remove the rating. |  |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="poststar"></a>
# **PostStar**
> SubsonicResponse PostStar (List<string>? id = null, List<string>? albumId = null, List<string>? artistId = null)

Attaches a star to a song, album or artist.

Attaches a star to a song, album or artist.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostStarExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = new List<string>?(); // List<string>? | The ID of the file (song) or folder (album/artist) to star. Multiple parameters allowed. (optional) 
            var albumId = new List<string>?(); // List<string>? | The ID of an album to star. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 
            var artistId = new List<string>?(); // List<string>? | The ID of an artist to star. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 

            try
            {
                // Attaches a star to a song, album or artist.
                SubsonicResponse result = apiInstance.PostStar(id, albumId, artistId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.PostStar: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostStarWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Attaches a star to a song, album or artist.
    ApiResponse<SubsonicResponse> response = apiInstance.PostStarWithHttpInfo(id, albumId, artistId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.PostStarWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**List&lt;string&gt;?**](string.md) | The ID of the file (song) or folder (album/artist) to star. Multiple parameters allowed. | [optional]  |
| **albumId** | [**List&lt;string&gt;?**](string.md) | The ID of an album to star. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |
| **artistId** | [**List&lt;string&gt;?**](string.md) | The ID of an artist to star. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="postunstar"></a>
# **PostUnstar**
> SubsonicResponse PostUnstar (Object? id = null, Object? albumId = null, Object? artistId = null)

Removes a star to a song, album or artist.

Removes a star to a song, album or artist.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostUnstarExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = new Object?(); // Object? | The ID of the file (song) or folder (album/artist) to unstar. Multiple parameters allowed. (optional) 
            var albumId = new Object?(); // Object? | The ID of an album to unstar. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 
            var artistId = new Object?(); // Object? | The ID of an artist to unstar. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 

            try
            {
                // Removes a star to a song, album or artist.
                SubsonicResponse result = apiInstance.PostUnstar(id, albumId, artistId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.PostUnstar: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostUnstarWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Removes a star to a song, album or artist.
    ApiResponse<SubsonicResponse> response = apiInstance.PostUnstarWithHttpInfo(id, albumId, artistId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.PostUnstarWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**Object?**](Object?.md) | The ID of the file (song) or folder (album/artist) to unstar. Multiple parameters allowed. | [optional]  |
| **albumId** | [**Object?**](Object?.md) | The ID of an album to unstar. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |
| **artistId** | [**Object?**](Object?.md) | The ID of an artist to unstar. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="reportplayback"></a>
# **ReportPlayback**
> SubsonicResponse ReportPlayback (string mediaId, string mediaType, int positionMs, string state, float? playbackRate = null, bool? ignoreScrobble = null)

Reports playback timeline state for a song.

OpenSubsonic extension name `playbackReport` (As returned by `getOpenSubsonicExtensions`). Reports playback timeline state for a song.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class ReportPlaybackExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var mediaId = "mediaId_example";  // string | The ID of the media.
            var mediaType = "song";  // string | The type of the media.
            var positionMs = 56;  // int | The playback position in milliseconds.
            var state = "starting";  // string | Playback state.
            var playbackRate = 1.0F;  // float? | Playback speed multiplier. (optional)  (default to 1.0F)
            var ignoreScrobble = false;  // bool? | If true, server should only update now-playing display/state and should not trigger scrobble/playcount side effects. (optional)  (default to false)

            try
            {
                // Reports playback timeline state for a song.
                SubsonicResponse result = apiInstance.ReportPlayback(mediaId, mediaType, positionMs, state, playbackRate, ignoreScrobble);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.ReportPlayback: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ReportPlaybackWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Reports playback timeline state for a song.
    ApiResponse<SubsonicResponse> response = apiInstance.ReportPlaybackWithHttpInfo(mediaId, mediaType, positionMs, state, playbackRate, ignoreScrobble);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.ReportPlaybackWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **mediaId** | **string** | The ID of the media. |  |
| **mediaType** | **string** | The type of the media. |  |
| **positionMs** | **int** | The playback position in milliseconds. |  |
| **state** | **string** | Playback state. |  |
| **playbackRate** | **float?** | Playback speed multiplier. | [optional] [default to 1.0F] |
| **ignoreScrobble** | **bool?** | If true, server should only update now-playing display/state and should not trigger scrobble/playcount side effects. | [optional] [default to false] |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="scrobble"></a>
# **Scrobble**
> SubsonicResponse Scrobble (string id, int? time = null, bool? submission = null)

Registers the local playback of one or more media files.

Registers the local playback of one or more media files. Typically used when playing media that is cached on the client. This operation includes the following:  * “Scrobbles” the media files on last.fm if the user has configured his/her last.fm credentials on the server. * Updates the play count and last played timestamp for the media files. (Since 1.11.0) * Makes the media files appear in the “Now playing” page in the web app, and appear in the list of songs returned by getNowPlaying (Since 1.11.0)  Since 1.8.0 you may specify multiple id (and optionally time) parameters to scrobble multiple files.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class ScrobbleExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file to scrobble.
            var time = 56;  // int? | (Since 1.8.0) The time (in milliseconds since 1 Jan 1970) at which the song was listened to. (optional) 
            var submission = true;  // bool? | Whether this is a “submission” or a “now playing” notification. (optional)  (default to true)

            try
            {
                // Registers the local playback of one or more media files.
                SubsonicResponse result = apiInstance.Scrobble(id, time, submission);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.Scrobble: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ScrobbleWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Registers the local playback of one or more media files.
    ApiResponse<SubsonicResponse> response = apiInstance.ScrobbleWithHttpInfo(id, time, submission);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.ScrobbleWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file to scrobble. |  |
| **time** | **int?** | (Since 1.8.0) The time (in milliseconds since 1 Jan 1970) at which the song was listened to. | [optional]  |
| **submission** | **bool?** | Whether this is a “submission” or a “now playing” notification. | [optional] [default to true] |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="setrating"></a>
# **SetRating**
> SubsonicResponse SetRating (string id, int rating)

Sets the rating for a music file.

Sets the rating for a music file.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class SetRatingExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = "id_example";  // string | A string which uniquely identifies the file (song) or folder (album/artist) to rate.
            var rating = 56;  // int | The rating between 1 and 5 (inclusive), or 0 to remove the rating.

            try
            {
                // Sets the rating for a music file.
                SubsonicResponse result = apiInstance.SetRating(id, rating);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.SetRating: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SetRatingWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Sets the rating for a music file.
    ApiResponse<SubsonicResponse> response = apiInstance.SetRatingWithHttpInfo(id, rating);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.SetRatingWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **string** | A string which uniquely identifies the file (song) or folder (album/artist) to rate. |  |
| **rating** | **int** | The rating between 1 and 5 (inclusive), or 0 to remove the rating. |  |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="star"></a>
# **Star**
> SubsonicResponse Star (List<string>? id = null, List<string>? albumId = null, List<string>? artistId = null)

Attaches a star to a song, album or artist.

Attaches a star to a song, album or artist.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class StarExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = new List<string>?(); // List<string>? | The ID of the file (song) or folder (album/artist) to star. Multiple parameters allowed. (optional) 
            var albumId = new List<string>?(); // List<string>? | The ID of an album to star. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 
            var artistId = new List<string>?(); // List<string>? | The ID of an artist to star. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 

            try
            {
                // Attaches a star to a song, album or artist.
                SubsonicResponse result = apiInstance.Star(id, albumId, artistId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.Star: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the StarWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Attaches a star to a song, album or artist.
    ApiResponse<SubsonicResponse> response = apiInstance.StarWithHttpInfo(id, albumId, artistId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.StarWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**List&lt;string&gt;?**](string.md) | The ID of the file (song) or folder (album/artist) to star. Multiple parameters allowed. | [optional]  |
| **albumId** | [**List&lt;string&gt;?**](string.md) | The ID of an album to star. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |
| **artistId** | [**List&lt;string&gt;?**](string.md) | The ID of an artist to star. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

<a id="unstar"></a>
# **Unstar**
> SubsonicResponse Unstar (List<string>? id = null, List<string>? albumId = null, List<string>? artistId = null)

Removes a star to a song, album or artist.

Removes a star to a song, album or artist.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class UnstarExample
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

            var apiInstance = new MediaAnnotationApi(config);
            var id = new List<string>?(); // List<string>? | The ID of the file (song) or folder (album/artist) to star. Multiple parameters allowed. (optional) 
            var albumId = new List<string>?(); // List<string>? | The ID of an album to star. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 
            var artistId = new List<string>?(); // List<string>? | The ID of an artist to star. Use this rather than `id` if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. (optional) 

            try
            {
                // Removes a star to a song, album or artist.
                SubsonicResponse result = apiInstance.Unstar(id, albumId, artistId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling MediaAnnotationApi.Unstar: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UnstarWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Removes a star to a song, album or artist.
    ApiResponse<SubsonicResponse> response = apiInstance.UnstarWithHttpInfo(id, albumId, artistId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling MediaAnnotationApi.UnstarWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | [**List&lt;string&gt;?**](string.md) | The ID of the file (song) or folder (album/artist) to star. Multiple parameters allowed. | [optional]  |
| **albumId** | [**List&lt;string&gt;?**](string.md) | The ID of an album to star. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |
| **artistId** | [**List&lt;string&gt;?**](string.md) | The ID of an artist to star. Use this rather than &#x60;id&#x60; if the client accesses the media collection according to ID3 tags rather than file structure. Multiple parameters allowed. | [optional]  |

### Return type

[**SubsonicResponse**](SubsonicResponse.md)

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

