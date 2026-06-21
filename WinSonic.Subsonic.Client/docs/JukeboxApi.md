# WinSonic.Subsonic.Client.Api.JukeboxApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**JukeboxControl**](JukeboxApi.md#jukeboxcontrol) | **GET** /rest/jukeboxControl | Controls the jukebox, i.e., playback directly on the server’s audio hardware. |
| [**PostJukeboxControl**](JukeboxApi.md#postjukeboxcontrol) | **POST** /rest/jukeboxControl | Controls the jukebox, i.e., playback directly on the server’s audio hardware. |

<a id="jukeboxcontrol"></a>
# **JukeboxControl**
> JukeboxControlResponse JukeboxControl (JukeboxAction action, int? index = null, int? offset = null, List<string>? id = null, float? gain = null)

Controls the jukebox, i.e., playback directly on the server’s audio hardware.

Controls the jukebox, i.e., playback directly on the server’s audio hardware. Note: The user must be authorized to control the jukebox (see Settings > Users > User is allowed to play files in jukebox mode).

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class JukeboxControlExample
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

            var apiInstance = new JukeboxApi(config);
            var action = (JukeboxAction) "get";  // JukeboxAction | The operation to perform. Must be one of: get, status (since 1.7.0), set (since 1.7.0), start, stop, skip, add, clear, remove, shuffle, setGain
            var index = 56;  // int? | Used by `skip` and `remove`. Zero-based index of the song to skip to or remove. (optional) 
            var offset = 56;  // int? | (Since 1.7.0) Used by `skip`. Start playing this many seconds into the track. (optional) 
            var id = new List<string>?(); // List<string>? | Used by `add` and `set`. ID of song to add to the jukebox playlist. Use multiple id parameters to add many songs in the same request. (set is similar to a clear followed by a add, but will not change the currently playing track.) (optional) 
            var gain = 3.4F;  // float? | Used by `setGain` to control the playback volume. A float value between 0.0 and 1.0. (optional) 

            try
            {
                // Controls the jukebox, i.e., playback directly on the server’s audio hardware.
                JukeboxControlResponse result = apiInstance.JukeboxControl(action, index, offset, id, gain);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JukeboxApi.JukeboxControl: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the JukeboxControlWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Controls the jukebox, i.e., playback directly on the server’s audio hardware.
    ApiResponse<JukeboxControlResponse> response = apiInstance.JukeboxControlWithHttpInfo(action, index, offset, id, gain);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JukeboxApi.JukeboxControlWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **action** | **JukeboxAction** | The operation to perform. Must be one of: get, status (since 1.7.0), set (since 1.7.0), start, stop, skip, add, clear, remove, shuffle, setGain |  |
| **index** | **int?** | Used by &#x60;skip&#x60; and &#x60;remove&#x60;. Zero-based index of the song to skip to or remove. | [optional]  |
| **offset** | **int?** | (Since 1.7.0) Used by &#x60;skip&#x60;. Start playing this many seconds into the track. | [optional]  |
| **id** | [**List&lt;string&gt;?**](string.md) | Used by &#x60;add&#x60; and &#x60;set&#x60;. ID of song to add to the jukebox playlist. Use multiple id parameters to add many songs in the same request. (set is similar to a clear followed by a add, but will not change the currently playing track.) | [optional]  |
| **gain** | **float?** | Used by &#x60;setGain&#x60; to control the playback volume. A float value between 0.0 and 1.0. | [optional]  |

### Return type

[**JukeboxControlResponse**](JukeboxControlResponse.md)

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

<a id="postjukeboxcontrol"></a>
# **PostJukeboxControl**
> JukeboxControlResponse PostJukeboxControl (Object? action = null, int? index = null, int? offset = null, List<string>? id = null, float? gain = null)

Controls the jukebox, i.e., playback directly on the server’s audio hardware.

Controls the jukebox, i.e., playback directly on the server’s audio hardware. Note: The user must be authorized to control the jukebox (see Settings > Users > User is allowed to play files in jukebox mode).  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostJukeboxControlExample
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

            var apiInstance = new JukeboxApi(config);
            var action = new Object?(); // Object? | 'setGain' action. (optional) 
            var index = 56;  // int? | Zero-based index of the song to skip. (optional) 
            var offset = 56;  // int? | (Since 1.7.0) Used by `skip`. Start playing this many seconds into the track. (optional) 
            var id = new List<string>?(); // List<string>? | ID of song to add to the jukebox playlist. Use multiple id parameters to add many songs in the same request. (set is similar to a clear followed by an add, but will not change the currently playing track.) (optional) 
            var gain = 3.4F;  // float? | Used by `setGain` to control the playback volume. A float value between 0.0 and 1.0. (optional) 

            try
            {
                // Controls the jukebox, i.e., playback directly on the server’s audio hardware.
                JukeboxControlResponse result = apiInstance.PostJukeboxControl(action, index, offset, id, gain);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling JukeboxApi.PostJukeboxControl: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostJukeboxControlWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Controls the jukebox, i.e., playback directly on the server’s audio hardware.
    ApiResponse<JukeboxControlResponse> response = apiInstance.PostJukeboxControlWithHttpInfo(action, index, offset, id, gain);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling JukeboxApi.PostJukeboxControlWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **action** | [**Object?**](Object?.md) | &#39;setGain&#39; action. | [optional]  |
| **index** | **int?** | Zero-based index of the song to skip. | [optional]  |
| **offset** | **int?** | (Since 1.7.0) Used by &#x60;skip&#x60;. Start playing this many seconds into the track. | [optional]  |
| **id** | [**List&lt;string&gt;?**](string.md) | ID of song to add to the jukebox playlist. Use multiple id parameters to add many songs in the same request. (set is similar to a clear followed by an add, but will not change the currently playing track.) | [optional]  |
| **gain** | **float?** | Used by &#x60;setGain&#x60; to control the playback volume. A float value between 0.0 and 1.0. | [optional]  |

### Return type

[**JukeboxControlResponse**](JukeboxControlResponse.md)

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

