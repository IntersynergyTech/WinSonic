# WinSonic.Subsonic.Client.Api.TranscodingApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetTranscodeDecision**](TranscodingApi.md#gettranscodedecision) | **POST** /rest/getTranscodeDecision | Get Transcode Decision |
| [**GetTranscodeStream**](TranscodingApi.md#gettranscodestream) | **GET** /rest/getTranscodeStream | Get Transcoded Stream |

<a id="gettranscodedecision"></a>
# **GetTranscodeDecision**
> GetTranscodeDecision200Response GetTranscodeDecision (string mediaId, string mediaType, ClientInfo clientInfo)

Get Transcode Decision

Returns a transcode decision for a given media file.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetTranscodeDecisionExample
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

            var apiInstance = new TranscodingApi(config);
            var mediaId = "mediaId_example";  // string | The ID of the media.
            var mediaType = "song";  // string | The type of the media.
            var clientInfo = new ClientInfo(); // ClientInfo | 

            try
            {
                // Get Transcode Decision
                GetTranscodeDecision200Response result = apiInstance.GetTranscodeDecision(mediaId, mediaType, clientInfo);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TranscodingApi.GetTranscodeDecision: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetTranscodeDecisionWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Transcode Decision
    ApiResponse<GetTranscodeDecision200Response> response = apiInstance.GetTranscodeDecisionWithHttpInfo(mediaId, mediaType, clientInfo);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TranscodingApi.GetTranscodeDecisionWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **mediaId** | **string** | The ID of the media. |  |
| **mediaType** | **string** | The type of the media. |  |
| **clientInfo** | [**ClientInfo**](ClientInfo.md) |  |  |

### Return type

[**GetTranscodeDecision200Response**](GetTranscodeDecision200Response.md)

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/xml


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | A transcode decision. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="gettranscodestream"></a>
# **GetTranscodeStream**
> System.IO.Stream GetTranscodeStream (string mediaId, string mediaType, string transcodeParams, int? offset = null)

Get Transcoded Stream

Returns a transcoded media stream. Clients should not try to reconstruct the `transcodeParams`. Instead, they must use the `transcodeParams` provided in the response of the `getTranscodeDecision` endpoint.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetTranscodeStreamExample
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

            var apiInstance = new TranscodingApi(config);
            var mediaId = "mediaId_example";  // string | The ID of the media.
            var mediaType = "song";  // string | The type of the media.
            var transcodeParams = "transcodeParams_example";  // string | Server-specific transcoding parameters. This should be obtained from the `getTranscodeDecision` endpoint.
            var offset = 0;  // int? | The time offset in seconds from which to start transcoding. (optional)  (default to 0)

            try
            {
                // Get Transcoded Stream
                System.IO.Stream result = apiInstance.GetTranscodeStream(mediaId, mediaType, transcodeParams, offset);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling TranscodingApi.GetTranscodeStream: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetTranscodeStreamWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get Transcoded Stream
    ApiResponse<System.IO.Stream> response = apiInstance.GetTranscodeStreamWithHttpInfo(mediaId, mediaType, transcodeParams, offset);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling TranscodingApi.GetTranscodeStreamWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **mediaId** | **string** | The ID of the media. |  |
| **mediaType** | **string** | The type of the media. |  |
| **transcodeParams** | **string** | Server-specific transcoding parameters. This should be obtained from the &#x60;getTranscodeDecision&#x60; endpoint. |  |
| **offset** | **int?** | The time offset in seconds from which to start transcoding. | [optional] [default to 0] |

### Return type

**System.IO.Stream**

### Authorization

[legacyPassword](../README.md#legacyPassword), [salt](../README.md#salt), [clientName](../README.md#clientName), [apiKeyAuth](../README.md#apiKeyAuth), [format](../README.md#format), [protocolVersion](../README.md#protocolVersion), [username](../README.md#username), [token](../README.md#token)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | The transcoded media stream. |  -  |
| **400** | Bad Request - The request was malformed or invalid. |  -  |
| **401** | Unauthorized - Authentication failed. |  -  |
| **404** | Not Found - The requested track does not exist. |  -  |
| **500** | Internal Server Error - The server encountered an error during transcoding. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

