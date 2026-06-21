# WinSonic.Subsonic.Client.Api.ChatApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAddChatMessage**](ChatApi.md#getaddchatmessage) | **GET** /rest/addChatMessage | Adds a message to the chat log. |
| [**GetChatMessages**](ChatApi.md#getchatmessages) | **GET** /rest/getChatMessages | Returns the current visible (non-expired) chat messages. |
| [**PostAddChatMessage**](ChatApi.md#postaddchatmessage) | **POST** /rest/addChatMessage | Adds a message to the chat log. |
| [**PostGetChatMessages**](ChatApi.md#postgetchatmessages) | **POST** /rest/getChatMessages | Returns the current visible (non-expired) chat messages. |

<a id="getaddchatmessage"></a>
# **GetAddChatMessage**
> SubsonicResponse GetAddChatMessage (string message)

Adds a message to the chat log.

Adds a message to the chat log.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetAddChatMessageExample
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

            var apiInstance = new ChatApi(config);
            var message = "message_example";  // string | The chat message.

            try
            {
                // Adds a message to the chat log.
                SubsonicResponse result = apiInstance.GetAddChatMessage(message);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChatApi.GetAddChatMessage: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetAddChatMessageWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Adds a message to the chat log.
    ApiResponse<SubsonicResponse> response = apiInstance.GetAddChatMessageWithHttpInfo(message);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChatApi.GetAddChatMessageWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **message** | **string** | The chat message. |  |

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

<a id="getchatmessages"></a>
# **GetChatMessages**
> GetChatMessagesResponse GetChatMessages ()

Returns the current visible (non-expired) chat messages.

Returns the current visible (non-expired) chat messages.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetChatMessagesExample
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

            var apiInstance = new ChatApi(config);

            try
            {
                // Returns the current visible (non-expired) chat messages.
                GetChatMessagesResponse result = apiInstance.GetChatMessages();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChatApi.GetChatMessages: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetChatMessagesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the current visible (non-expired) chat messages.
    ApiResponse<GetChatMessagesResponse> response = apiInstance.GetChatMessagesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChatApi.GetChatMessagesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetChatMessagesResponse**](GetChatMessagesResponse.md)

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

<a id="postaddchatmessage"></a>
# **PostAddChatMessage**
> SubsonicResponse PostAddChatMessage (string message)

Adds a message to the chat log.

Adds a message to the chat log.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostAddChatMessageExample
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

            var apiInstance = new ChatApi(config);
            var message = "message_example";  // string | The chat message.

            try
            {
                // Adds a message to the chat log.
                SubsonicResponse result = apiInstance.PostAddChatMessage(message);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChatApi.PostAddChatMessage: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostAddChatMessageWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Adds a message to the chat log.
    ApiResponse<SubsonicResponse> response = apiInstance.PostAddChatMessageWithHttpInfo(message);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChatApi.PostAddChatMessageWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **message** | **string** | The chat message. |  |

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

<a id="postgetchatmessages"></a>
# **PostGetChatMessages**
> GetChatMessagesResponse PostGetChatMessages ()

Returns the current visible (non-expired) chat messages.

Returns the current visible (non-expired) chat messages.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetChatMessagesExample
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

            var apiInstance = new ChatApi(config);

            try
            {
                // Returns the current visible (non-expired) chat messages.
                GetChatMessagesResponse result = apiInstance.PostGetChatMessages();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ChatApi.PostGetChatMessages: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetChatMessagesWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Returns the current visible (non-expired) chat messages.
    ApiResponse<GetChatMessagesResponse> response = apiInstance.PostGetChatMessagesWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ChatApi.PostGetChatMessagesWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetChatMessagesResponse**](GetChatMessagesResponse.md)

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

