# WinSonic.Subsonic.Client.Api.ListsApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAlbumList**](ListsApi.md#getalbumlist) | **GET** /rest/getAlbumList | Returns a list of random, newest, highest rated etc. albums. |
| [**GetAlbumList2**](ListsApi.md#getalbumlist2) | **GET** /rest/getAlbumList2 | Returns a list of random, newest, highest rated etc. albums (v2). |
| [**GetNowPlaying**](ListsApi.md#getnowplaying) | **GET** /rest/getNowPlaying | Returns what is currently being played by all users. |
| [**GetRandomSongs**](ListsApi.md#getrandomsongs) | **GET** /rest/getRandomSongs | Returns random songs matching the given criteria. |
| [**GetSongsByGenre**](ListsApi.md#getsongsbygenre) | **GET** /rest/getSongsByGenre | Returns songs in a given genre. |
| [**GetStarred**](ListsApi.md#getstarred) | **GET** /rest/getStarred | Returns starred songs, albums and artists. |
| [**GetStarred2**](ListsApi.md#getstarred2) | **GET** /rest/getStarred2 | Returns starred songs, albums and artists. |
| [**PostGetAlbumList**](ListsApi.md#postgetalbumlist) | **POST** /rest/getAlbumList | Returns a list of random, newest, highest rated etc. albums. |
| [**PostGetAlbumList2**](ListsApi.md#postgetalbumlist2) | **POST** /rest/getAlbumList2 | Returns a list of random, newest, highest rated etc. albums (v2). |
| [**PostGetNowPlaying**](ListsApi.md#postgetnowplaying) | **POST** /rest/getNowPlaying | Returns what is currently being played by all users. |
| [**PostGetRandomSongs**](ListsApi.md#postgetrandomsongs) | **POST** /rest/getRandomSongs | Returns random songs matching the given criteria. |
| [**PostGetSongsByGenre**](ListsApi.md#postgetsongsbygenre) | **POST** /rest/getSongsByGenre | Returns songs in a given genre. |
| [**PostGetStarred**](ListsApi.md#postgetstarred) | **POST** /rest/getStarred | Returns starred songs, albums and artists. |
| [**PostGetStarred2**](ListsApi.md#postgetstarred2) | **POST** /rest/getStarred2 | Returns starred songs, albums and artists. |

<a id="getalbumlist"></a>
# **GetAlbumList**
> GetAlbumListResponse GetAlbumList (AlbumListType type, int? size = null, int? offset = null, int? fromYear = null, int? toYear = null, string? genre = null, string? musicFolderId = null)

Returns a list of random, newest, highest rated etc. albums.

Returns a list of random, newest, highest rated etc. albums. Similar to the album lists on the home page of the Subsonic web interface.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetAlbumListExample
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

            var apiInstance = new ListsApi(config);
            var type = (AlbumListType) "random";  // AlbumListType | 
            var size = 10;  // int? | The number of albums to return. Max 500. (optional)  (default to 10)
            var offset = 0;  // int? | The list offset. Useful if you for example want to page through the list of newest albums. (optional)  (default to 0)
            var fromYear = 56;  // int? | Required if `type=='byYear'`. The first year in the range. If `fromYear` > `toYear` a reverse chronological list is returned. (optional) 
            var toYear = 56;  // int? | Required if `type=='byYear'`. The last year in the range. (optional) 
            var genre = "genre_example";  // string? | Required if `type=='byGenre'`. The name of the genre, e.g., “Rock”. (optional) 
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.11.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns a list of random, newest, highest rated etc. albums.
                GetAlbumListResponse result = apiInstance.GetAlbumList(type, size, offset, fromYear, toYear, genre, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.GetAlbumList: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAlbumListWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a list of random, newest, highest rated etc. albums.
    ApiResponse<GetAlbumListResponse> response = apiInstance.GetAlbumListWithHttpInfo(type, size, offset, fromYear, toYear, genre, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.GetAlbumListWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **type** | **AlbumListType** |  |  |
| **size** | **int?** | The number of albums to return. Max 500. | [optional] [default to 10] |
| **offset** | **int?** | The list offset. Useful if you for example want to page through the list of newest albums. | [optional] [default to 0] |
| **fromYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The first year in the range. If &#x60;fromYear&#x60; &gt; &#x60;toYear&#x60; a reverse chronological list is returned. | [optional]  |
| **toYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The last year in the range. | [optional]  |
| **genre** | **string?** | Required if &#x60;type&#x3D;&#x3D;&#39;byGenre&#39;&#x60;. The name of the genre, e.g., “Rock”. | [optional]  |
| **musicFolderId** | **string?** | (Since 1.11.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetAlbumListResponse**](GetAlbumListResponse.md)

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

<a id="getalbumlist2"></a>
# **GetAlbumList2**
> GetAlbumList2Response GetAlbumList2 (AlbumListType type, int? size = null, int? offset = null, int? fromYear = null, int? toYear = null, string? genre = null, string? musicFolderId = null)

Returns a list of random, newest, highest rated etc. albums (v2).

Similar to `getAlbumList`, but organizes music according to ID3 tags.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetAlbumList2Example
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

            var apiInstance = new ListsApi(config);
            var type = (AlbumListType) "random";  // AlbumListType | 
            var size = 10;  // int? | The number of albums to return. Max 500. (optional)  (default to 10)
            var offset = 0;  // int? | The list offset. Useful if you for example want to page through the list of newest albums. (optional)  (default to 0)
            var fromYear = 56;  // int? | Required if `type=='byYear'`. The first year in the range. If `fromYear` > `toYear` a reverse chronological list is returned. (optional) 
            var toYear = 56;  // int? | Required if `type=='byYear'`. The last year in the range. (optional) 
            var genre = "genre_example";  // string? | Required if `type=='byGenre'`. The name of the genre, e.g., “Rock”. (optional) 
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.11.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns a list of random, newest, highest rated etc. albums (v2).
                GetAlbumList2Response result = apiInstance.GetAlbumList2(type, size, offset, fromYear, toYear, genre, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.GetAlbumList2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAlbumList2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a list of random, newest, highest rated etc. albums (v2).
    ApiResponse<GetAlbumList2Response> response = apiInstance.GetAlbumList2WithHttpInfo(type, size, offset, fromYear, toYear, genre, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.GetAlbumList2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **type** | **AlbumListType** |  |  |
| **size** | **int?** | The number of albums to return. Max 500. | [optional] [default to 10] |
| **offset** | **int?** | The list offset. Useful if you for example want to page through the list of newest albums. | [optional] [default to 0] |
| **fromYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The first year in the range. If &#x60;fromYear&#x60; &gt; &#x60;toYear&#x60; a reverse chronological list is returned. | [optional]  |
| **toYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The last year in the range. | [optional]  |
| **genre** | **string?** | Required if &#x60;type&#x3D;&#x3D;&#39;byGenre&#39;&#x60;. The name of the genre, e.g., “Rock”. | [optional]  |
| **musicFolderId** | **string?** | (Since 1.11.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetAlbumList2Response**](GetAlbumList2Response.md)

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

<a id="getnowplaying"></a>
# **GetNowPlaying**
> GetNowPlayingResponse GetNowPlaying ()

Returns what is currently being played by all users.

Returns what is currently being played by all users. Takes no extra parameters.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetNowPlayingExample
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

            var apiInstance = new ListsApi(config);

            try
            {
                // Returns what is currently being played by all users.
                GetNowPlayingResponse result = apiInstance.GetNowPlaying();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.GetNowPlaying: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetNowPlayingWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns what is currently being played by all users.
    ApiResponse<GetNowPlayingResponse> response = apiInstance.GetNowPlayingWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.GetNowPlayingWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetNowPlayingResponse**](GetNowPlayingResponse.md)

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

<a id="getrandomsongs"></a>
# **GetRandomSongs**
> GetRandomSongsResponse GetRandomSongs (int? size = null, string? genre = null, int? fromYear = null, int? toYear = null, string? musicFolderId = null)

Returns random songs matching the given criteria.

Returns random songs matching the given criteria.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetRandomSongsExample
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

            var apiInstance = new ListsApi(config);
            var size = 10;  // int? | The maximum number of songs to return. Max 500. (optional)  (default to 10)
            var genre = "genre_example";  // string? | Only returns songs belonging to this genre. (optional) 
            var fromYear = 56;  // int? | (Since 1.9.0) Only return songs from this year or later. (optional) 
            var toYear = 56;  // int? | Only return songs published before or in this year. (optional) 
            var musicFolderId = "musicFolderId_example";  // string? | Only return songs in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns random songs matching the given criteria.
                GetRandomSongsResponse result = apiInstance.GetRandomSongs(size, genre, fromYear, toYear, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.GetRandomSongs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRandomSongsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns random songs matching the given criteria.
    ApiResponse<GetRandomSongsResponse> response = apiInstance.GetRandomSongsWithHttpInfo(size, genre, fromYear, toYear, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.GetRandomSongsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **size** | **int?** | The maximum number of songs to return. Max 500. | [optional] [default to 10] |
| **genre** | **string?** | Only returns songs belonging to this genre. | [optional]  |
| **fromYear** | **int?** | (Since 1.9.0) Only return songs from this year or later. | [optional]  |
| **toYear** | **int?** | Only return songs published before or in this year. | [optional]  |
| **musicFolderId** | **string?** | Only return songs in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetRandomSongsResponse**](GetRandomSongsResponse.md)

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

<a id="getsongsbygenre"></a>
# **GetSongsByGenre**
> GetSongsByGenreResponse GetSongsByGenre (string genre, int? count = null, int? offset = null, string? musicFolderId = null)

Returns songs in a given genre.

Returns songs in a given genre.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetSongsByGenreExample
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

            var apiInstance = new ListsApi(config);
            var genre = "genre_example";  // string | The genre, as returned by `getGenres`.
            var count = 10;  // int? | The maximum number of songs to return. Max 500. (optional)  (default to 10)
            var offset = 0;  // int? | The offset. Useful if you want to page through the songs in a genre. (optional)  (default to 0)
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns songs in a given genre.
                GetSongsByGenreResponse result = apiInstance.GetSongsByGenre(genre, count, offset, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.GetSongsByGenre: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetSongsByGenreWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns songs in a given genre.
    ApiResponse<GetSongsByGenreResponse> response = apiInstance.GetSongsByGenreWithHttpInfo(genre, count, offset, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.GetSongsByGenreWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **genre** | **string** | The genre, as returned by &#x60;getGenres&#x60;. |  |
| **count** | **int?** | The maximum number of songs to return. Max 500. | [optional] [default to 10] |
| **offset** | **int?** | The offset. Useful if you want to page through the songs in a genre. | [optional] [default to 0] |
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetSongsByGenreResponse**](GetSongsByGenreResponse.md)

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

<a id="getstarred"></a>
# **GetStarred**
> GetStarredResponse GetStarred (string? musicFolderId = null)

Returns starred songs, albums and artists.

Returns starred songs, albums and artists.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetStarredExample
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

            var apiInstance = new ListsApi(config);
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns starred songs, albums and artists.
                GetStarredResponse result = apiInstance.GetStarred(musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.GetStarred: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetStarredWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns starred songs, albums and artists.
    ApiResponse<GetStarredResponse> response = apiInstance.GetStarredWithHttpInfo(musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.GetStarredWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetStarredResponse**](GetStarredResponse.md)

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

<a id="getstarred2"></a>
# **GetStarred2**
> GetStarred2Response GetStarred2 (string? musicFolderId = null)

Returns starred songs, albums and artists.

Similar to `getStarred`, but organizes music according to ID3 tags.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetStarred2Example
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

            var apiInstance = new ListsApi(config);
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns starred songs, albums and artists.
                GetStarred2Response result = apiInstance.GetStarred2(musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.GetStarred2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetStarred2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns starred songs, albums and artists.
    ApiResponse<GetStarred2Response> response = apiInstance.GetStarred2WithHttpInfo(musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.GetStarred2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetStarred2Response**](GetStarred2Response.md)

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

<a id="postgetalbumlist"></a>
# **PostGetAlbumList**
> GetAlbumListResponse PostGetAlbumList (AlbumListType type, int? size = null, int? offset = null, int? fromYear = null, int? toYear = null, string? genre = null, string? musicFolderId = null)

Returns a list of random, newest, highest rated etc. albums.

Returns a list of random, newest, highest rated etc. albums. Similar to the album lists on the home page of the Subsonic web interface.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetAlbumListExample
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

            var apiInstance = new ListsApi(config);
            var type = (AlbumListType) "random";  // AlbumListType | 
            var size = 10;  // int? | The number of albums to return. Max 500. (optional)  (default to 10)
            var offset = 0;  // int? | The list offset. Useful if you for example want to page through the list of newest albums. (optional)  (default to 0)
            var fromYear = 56;  // int? | Required if `type=='byYear'`. The first year in the range. If `fromYear` > `toYear` a reverse chronological list is returned. (optional) 
            var toYear = 56;  // int? | Required if `type=='byYear'`. The last year in the range. (optional) 
            var genre = "genre_example";  // string? | Required if `type=='byGenre'`. The name of the genre, e.g., “Rock”. (optional) 
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.11.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns a list of random, newest, highest rated etc. albums.
                GetAlbumListResponse result = apiInstance.PostGetAlbumList(type, size, offset, fromYear, toYear, genre, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.PostGetAlbumList: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetAlbumListWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a list of random, newest, highest rated etc. albums.
    ApiResponse<GetAlbumListResponse> response = apiInstance.PostGetAlbumListWithHttpInfo(type, size, offset, fromYear, toYear, genre, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.PostGetAlbumListWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **type** | **AlbumListType** |  |  |
| **size** | **int?** | The number of albums to return. Max 500. | [optional] [default to 10] |
| **offset** | **int?** | The list offset. Useful if you for example want to page through the list of newest albums. | [optional] [default to 0] |
| **fromYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The first year in the range. If &#x60;fromYear&#x60; &gt; &#x60;toYear&#x60; a reverse chronological list is returned. | [optional]  |
| **toYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The last year in the range. | [optional]  |
| **genre** | **string?** | Required if &#x60;type&#x3D;&#x3D;&#39;byGenre&#39;&#x60;. The name of the genre, e.g., “Rock”. | [optional]  |
| **musicFolderId** | **string?** | (Since 1.11.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetAlbumListResponse**](GetAlbumListResponse.md)

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

<a id="postgetalbumlist2"></a>
# **PostGetAlbumList2**
> GetAlbumList2Response PostGetAlbumList2 (AlbumListType type, int? size = null, int? offset = null, int? fromYear = null, int? toYear = null, string? genre = null, string? musicFolderId = null)

Returns a list of random, newest, highest rated etc. albums (v2).

Similar to `getAlbumList`, but organizes music according to ID3 tags.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetAlbumList2Example
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

            var apiInstance = new ListsApi(config);
            var type = (AlbumListType) "random";  // AlbumListType | 
            var size = 10;  // int? | The number of albums to return. Max 500. (optional)  (default to 10)
            var offset = 0;  // int? | The list offset. Useful if you for example want to page through the list of newest albums. (optional)  (default to 0)
            var fromYear = 56;  // int? | Required if `type=='byYear'`. The first year in the range. If `fromYear` > `toYear` a reverse chronological list is returned. (optional) 
            var toYear = 56;  // int? | Required if `type=='byYear'`. The last year in the range. (optional) 
            var genre = "genre_example";  // string? | Required if `type=='byGenre'`. The name of the genre, e.g., “Rock”. (optional) 
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.11.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns a list of random, newest, highest rated etc. albums (v2).
                GetAlbumList2Response result = apiInstance.PostGetAlbumList2(type, size, offset, fromYear, toYear, genre, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.PostGetAlbumList2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetAlbumList2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a list of random, newest, highest rated etc. albums (v2).
    ApiResponse<GetAlbumList2Response> response = apiInstance.PostGetAlbumList2WithHttpInfo(type, size, offset, fromYear, toYear, genre, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.PostGetAlbumList2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **type** | **AlbumListType** |  |  |
| **size** | **int?** | The number of albums to return. Max 500. | [optional] [default to 10] |
| **offset** | **int?** | The list offset. Useful if you for example want to page through the list of newest albums. | [optional] [default to 0] |
| **fromYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The first year in the range. If &#x60;fromYear&#x60; &gt; &#x60;toYear&#x60; a reverse chronological list is returned. | [optional]  |
| **toYear** | **int?** | Required if &#x60;type&#x3D;&#x3D;&#39;byYear&#39;&#x60;. The last year in the range. | [optional]  |
| **genre** | **string?** | Required if &#x60;type&#x3D;&#x3D;&#39;byGenre&#39;&#x60;. The name of the genre, e.g., “Rock”. | [optional]  |
| **musicFolderId** | **string?** | (Since 1.11.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetAlbumList2Response**](GetAlbumList2Response.md)

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

<a id="postgetnowplaying"></a>
# **PostGetNowPlaying**
> GetNowPlayingResponse PostGetNowPlaying ()

Returns what is currently being played by all users.

Returns what is currently being played by all users. Takes no extra parameters.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetNowPlayingExample
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

            var apiInstance = new ListsApi(config);

            try
            {
                // Returns what is currently being played by all users.
                GetNowPlayingResponse result = apiInstance.PostGetNowPlaying();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.PostGetNowPlaying: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetNowPlayingWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns what is currently being played by all users.
    ApiResponse<GetNowPlayingResponse> response = apiInstance.PostGetNowPlayingWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.PostGetNowPlayingWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetNowPlayingResponse**](GetNowPlayingResponse.md)

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

<a id="postgetrandomsongs"></a>
# **PostGetRandomSongs**
> GetRandomSongsResponse PostGetRandomSongs (int? size = null, string? genre = null, int? fromYear = null, int? toYear = null, string? musicFolderId = null)

Returns random songs matching the given criteria.

Returns random songs matching the given criteria.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetRandomSongsExample
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

            var apiInstance = new ListsApi(config);
            var size = 10;  // int? | The maximum number of songs to return. Max 500. (optional)  (default to 10)
            var genre = "genre_example";  // string? | Only returns songs belonging to this genre. (optional) 
            var fromYear = 56;  // int? | (Since 1.9.0) Only return songs from this year or later. (optional) 
            var toYear = 56;  // int? | Only return songs published before or in this year. (optional) 
            var musicFolderId = "musicFolderId_example";  // string? | Only return songs in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns random songs matching the given criteria.
                GetRandomSongsResponse result = apiInstance.PostGetRandomSongs(size, genre, fromYear, toYear, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.PostGetRandomSongs: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetRandomSongsWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns random songs matching the given criteria.
    ApiResponse<GetRandomSongsResponse> response = apiInstance.PostGetRandomSongsWithHttpInfo(size, genre, fromYear, toYear, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.PostGetRandomSongsWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **size** | **int?** | The maximum number of songs to return. Max 500. | [optional] [default to 10] |
| **genre** | **string?** | Only returns songs belonging to this genre. | [optional]  |
| **fromYear** | **int?** | (Since 1.9.0) Only return songs from this year or later. | [optional]  |
| **toYear** | **int?** | Only return songs published before or in this year. | [optional]  |
| **musicFolderId** | **string?** | Only return songs in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetRandomSongsResponse**](GetRandomSongsResponse.md)

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

<a id="postgetsongsbygenre"></a>
# **PostGetSongsByGenre**
> GetSongsByGenreResponse PostGetSongsByGenre (string genre, int? count = null, int? offset = null, string? musicFolderId = null)

Returns songs in a given genre.

Returns songs in a given genre.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetSongsByGenreExample
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

            var apiInstance = new ListsApi(config);
            var genre = "genre_example";  // string | The genre, as returned by `getGenres`.
            var count = 10;  // int? | The maximum number of songs to return. Max 500. (optional)  (default to 10)
            var offset = 0;  // int? | The offset. Useful if you want to page through the songs in a genre. (optional)  (default to 0)
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns songs in a given genre.
                GetSongsByGenreResponse result = apiInstance.PostGetSongsByGenre(genre, count, offset, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.PostGetSongsByGenre: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetSongsByGenreWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns songs in a given genre.
    ApiResponse<GetSongsByGenreResponse> response = apiInstance.PostGetSongsByGenreWithHttpInfo(genre, count, offset, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.PostGetSongsByGenreWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **genre** | **string** | The genre, as returned by &#x60;getGenres&#x60;. |  |
| **count** | **int?** | The maximum number of songs to return. Max 500. | [optional] [default to 10] |
| **offset** | **int?** | The offset. Useful if you want to page through the songs in a genre. | [optional] [default to 0] |
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**GetSongsByGenreResponse**](GetSongsByGenreResponse.md)

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

<a id="postgetstarred"></a>
# **PostGetStarred**
> GetStarredResponse PostGetStarred ()

Returns starred songs, albums and artists.

Returns starred songs, albums and artists.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetStarredExample
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

            var apiInstance = new ListsApi(config);

            try
            {
                // Returns starred songs, albums and artists.
                GetStarredResponse result = apiInstance.PostGetStarred();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.PostGetStarred: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetStarredWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns starred songs, albums and artists.
    ApiResponse<GetStarredResponse> response = apiInstance.PostGetStarredWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.PostGetStarredWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetStarredResponse**](GetStarredResponse.md)

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

<a id="postgetstarred2"></a>
# **PostGetStarred2**
> GetStarred2Response PostGetStarred2 ()

Returns starred songs, albums and artists.

Similar to `getStarred`, but organizes music according to ID3 tags.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetStarred2Example
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

            var apiInstance = new ListsApi(config);

            try
            {
                // Returns starred songs, albums and artists.
                GetStarred2Response result = apiInstance.PostGetStarred2();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ListsApi.PostGetStarred2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetStarred2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns starred songs, albums and artists.
    ApiResponse<GetStarred2Response> response = apiInstance.PostGetStarred2WithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ListsApi.PostGetStarred2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetStarred2Response**](GetStarred2Response.md)

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

