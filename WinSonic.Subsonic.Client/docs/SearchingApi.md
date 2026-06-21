# WinSonic.Subsonic.Client.Api.SearchingApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**PostSearch**](SearchingApi.md#postsearch) | **POST** /rest/search | Returns a listing of files matching the given search criteria. Supports paging through the result. |
| [**PostSearch2**](SearchingApi.md#postsearch2) | **POST** /rest/search2 | Returns a listing of files matching the given search criteria. Supports paging through the result. (v2) |
| [**PostSearch3**](SearchingApi.md#postsearch3) | **POST** /rest/search3 | Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3) |
| [**Search**](SearchingApi.md#search) | **GET** /rest/search | Returns a listing of files matching the given search criteria. Supports paging through the result. |
| [**Search2**](SearchingApi.md#search2) | **GET** /rest/search2 | Returns a listing of files matching the given search criteria. Supports paging through the result. (v2) |
| [**Search3**](SearchingApi.md#search3) | **GET** /rest/search3 | Returns albums, artists and songs matching the given search criteria. Supports paging through the result. (v3) |

<a id="postsearch"></a>
# **PostSearch**
> SearchResponse PostSearch (string? artist = null, string? album = null, string? title = null, bool? any = null, int? count = null, int? offset = null, int? newerThan = null)

Returns a listing of files matching the given search criteria. Supports paging through the result.

Deprecated since 1.4.0, use search2 instead.  Returns a listing of files matching the given search criteria. Supports paging through the result.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostSearchExample
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

            var apiInstance = new SearchingApi(config);
            var artist = "artist_example";  // string? | Artist to search for. (optional) 
            var album = "album_example";  // string? | Album to search for. (optional) 
            var title = "title_example";  // string? | Song title to search for. (optional) 
            var any = false;  // bool? | Searches all fields. (optional)  (default to false)
            var count = 20;  // int? | Maximum number of results to return. (optional)  (default to 20)
            var offset = 0;  // int? | Search result offset. Used for paging. (optional)  (default to 0)
            var newerThan = 56;  // int? | Only return matches that are newer than this. Given as milliseconds since 1970. (optional) 

            try
            {
                // Returns a listing of files matching the given search criteria. Supports paging through the result.
                SearchResponse result = apiInstance.PostSearch(artist, album, title, any, count, offset, newerThan);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchingApi.PostSearch: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostSearchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a listing of files matching the given search criteria. Supports paging through the result.
    ApiResponse<SearchResponse> response = apiInstance.PostSearchWithHttpInfo(artist, album, title, any, count, offset, newerThan);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchingApi.PostSearchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **artist** | **string?** | Artist to search for. | [optional]  |
| **album** | **string?** | Album to search for. | [optional]  |
| **title** | **string?** | Song title to search for. | [optional]  |
| **any** | **bool?** | Searches all fields. | [optional] [default to false] |
| **count** | **int?** | Maximum number of results to return. | [optional] [default to 20] |
| **offset** | **int?** | Search result offset. Used for paging. | [optional] [default to 0] |
| **newerThan** | **int?** | Only return matches that are newer than this. Given as milliseconds since 1970. | [optional]  |

### Return type

[**SearchResponse**](SearchResponse.md)

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

<a id="postsearch2"></a>
# **PostSearch2**
> Search2Response PostSearch2 (string query, int? artistCount = null, int? artistOffset = null, int? albumCount = null, int? albumOffset = null, int? songCount = null, int? songOffset = null, string? musicFolderId = null)

Returns a listing of files matching the given search criteria. Supports paging through the result. (v2)

Returns albums, artists and songs matching the given search criteria. Supports paging through the result.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostSearch2Example
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

            var apiInstance = new SearchingApi(config);
            var query = "query_example";  // string | Search query.
            var artistCount = 20;  // int? | Maximum number of artists to return. (optional)  (default to 20)
            var artistOffset = 0;  // int? | Search result offset for artists. Used for paging. (optional)  (default to 0)
            var albumCount = 20;  // int? | Maximum number of albums to return. (optional)  (default to 20)
            var albumOffset = 0;  // int? | Search result offset for albums. Used for paging. (optional)  (default to 0)
            var songCount = 20;  // int? | Maximum number of songs to return. (optional)  (default to 20)
            var songOffset = 0;  // int? | Search result offset for songs. Used for paging. (optional)  (default to 0)
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns a listing of files matching the given search criteria. Supports paging through the result. (v2)
                Search2Response result = apiInstance.PostSearch2(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchingApi.PostSearch2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostSearch2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a listing of files matching the given search criteria. Supports paging through the result. (v2)
    ApiResponse<Search2Response> response = apiInstance.PostSearch2WithHttpInfo(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchingApi.PostSearch2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | Search query. |  |
| **artistCount** | **int?** | Maximum number of artists to return. | [optional] [default to 20] |
| **artistOffset** | **int?** | Search result offset for artists. Used for paging. | [optional] [default to 0] |
| **albumCount** | **int?** | Maximum number of albums to return. | [optional] [default to 20] |
| **albumOffset** | **int?** | Search result offset for albums. Used for paging. | [optional] [default to 0] |
| **songCount** | **int?** | Maximum number of songs to return. | [optional] [default to 20] |
| **songOffset** | **int?** | Search result offset for songs. Used for paging. | [optional] [default to 0] |
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**Search2Response**](Search2Response.md)

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

            var apiInstance = new SearchingApi(config);
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
                Debug.Print("Exception when calling SearchingApi.PostSearch3: " + e.Message);
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
    Debug.Print("Exception when calling SearchingApi.PostSearch3WithHttpInfo: " + e.Message);
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

<a id="search"></a>
# **Search**
> SearchResponse Search (string? artist = null, string? album = null, string? title = null, bool? any = null, int? count = null, int? offset = null, int? newerThan = null)

Returns a listing of files matching the given search criteria. Supports paging through the result.

Deprecated since 1.4.0, use search2 instead.  Returns a listing of files matching the given search criteria. Supports paging through the result.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class SearchExample
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

            var apiInstance = new SearchingApi(config);
            var artist = "artist_example";  // string? | Artist to search for. (optional) 
            var album = "album_example";  // string? | Album to search for. (optional) 
            var title = "title_example";  // string? | Song title to search for. (optional) 
            var any = true;  // bool? | Searches all fields. (optional) 
            var count = 20;  // int? | Maximum number of results to return. (optional)  (default to 20)
            var offset = 0;  // int? | Search result offset. Used for paging. (optional)  (default to 0)
            var newerThan = 56;  // int? | Only return matches that are newer than this. Given as milliseconds since 1970. (optional) 

            try
            {
                // Returns a listing of files matching the given search criteria. Supports paging through the result.
                SearchResponse result = apiInstance.Search(artist, album, title, any, count, offset, newerThan);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchingApi.Search: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the SearchWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a listing of files matching the given search criteria. Supports paging through the result.
    ApiResponse<SearchResponse> response = apiInstance.SearchWithHttpInfo(artist, album, title, any, count, offset, newerThan);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchingApi.SearchWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **artist** | **string?** | Artist to search for. | [optional]  |
| **album** | **string?** | Album to search for. | [optional]  |
| **title** | **string?** | Song title to search for. | [optional]  |
| **any** | **bool?** | Searches all fields. | [optional]  |
| **count** | **int?** | Maximum number of results to return. | [optional] [default to 20] |
| **offset** | **int?** | Search result offset. Used for paging. | [optional] [default to 0] |
| **newerThan** | **int?** | Only return matches that are newer than this. Given as milliseconds since 1970. | [optional]  |

### Return type

[**SearchResponse**](SearchResponse.md)

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

<a id="search2"></a>
# **Search2**
> Search2Response Search2 (string query, int? artistCount = null, int? artistOffset = null, int? albumCount = null, int? albumOffset = null, int? songCount = null, int? songOffset = null, string? musicFolderId = null)

Returns a listing of files matching the given search criteria. Supports paging through the result. (v2)

Returns albums, artists and songs matching the given search criteria. Supports paging through the result.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class Search2Example
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

            var apiInstance = new SearchingApi(config);
            var query = "query_example";  // string | Search query.
            var artistCount = 20;  // int? | Maximum number of artists to return. (optional)  (default to 20)
            var artistOffset = 0;  // int? | Search result offset for artists. Used for paging. (optional)  (default to 0)
            var albumCount = 20;  // int? | Maximum number of albums to return. (optional)  (default to 20)
            var albumOffset = 0;  // int? | Search result offset for albums. Used for paging. (optional)  (default to 0)
            var songCount = 20;  // int? | Maximum number of songs to return. (optional)  (default to 20)
            var songOffset = 0;  // int? | Search result offset for songs. Used for paging. (optional)  (default to 0)
            var musicFolderId = "musicFolderId_example";  // string? | (Since 1.12.0) Only return albums in the music folder with the given ID. See `getMusicFolders`. (optional) 

            try
            {
                // Returns a listing of files matching the given search criteria. Supports paging through the result. (v2)
                Search2Response result = apiInstance.Search2(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling SearchingApi.Search2: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the Search2WithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns a listing of files matching the given search criteria. Supports paging through the result. (v2)
    ApiResponse<Search2Response> response = apiInstance.Search2WithHttpInfo(query, artistCount, artistOffset, albumCount, albumOffset, songCount, songOffset, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling SearchingApi.Search2WithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **query** | **string** | Search query. |  |
| **artistCount** | **int?** | Maximum number of artists to return. | [optional] [default to 20] |
| **artistOffset** | **int?** | Search result offset for artists. Used for paging. | [optional] [default to 0] |
| **albumCount** | **int?** | Maximum number of albums to return. | [optional] [default to 20] |
| **albumOffset** | **int?** | Search result offset for albums. Used for paging. | [optional] [default to 0] |
| **songCount** | **int?** | Maximum number of songs to return. | [optional] [default to 20] |
| **songOffset** | **int?** | Search result offset for songs. Used for paging. | [optional] [default to 0] |
| **musicFolderId** | **string?** | (Since 1.12.0) Only return albums in the music folder with the given ID. See &#x60;getMusicFolders&#x60;. | [optional]  |

### Return type

[**Search2Response**](Search2Response.md)

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

            var apiInstance = new SearchingApi(config);
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
                Debug.Print("Exception when calling SearchingApi.Search3: " + e.Message);
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
    Debug.Print("Exception when calling SearchingApi.Search3WithHttpInfo: " + e.Message);
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

