# WinSonic.Subsonic.Client.Api.UserManagementApi

All URIs are relative to *https://example-opensubsonic-compatible-server.com*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ChangePassword**](UserManagementApi.md#changepassword) | **GET** /rest/changePassword | Changes the password of an existing user on the server. |
| [**CreateUser**](UserManagementApi.md#createuser) | **GET** /rest/createUser | Creates a new user on the server. |
| [**DeleteUser**](UserManagementApi.md#deleteuser) | **GET** /rest/deleteUser | Deletes an existing user on the server. |
| [**GetUser**](UserManagementApi.md#getuser) | **GET** /rest/getUser | Get details about a given user, including which authorization roles and folder access it has. |
| [**GetUsers**](UserManagementApi.md#getusers) | **GET** /rest/getUsers | Get details about all users, including which authorization roles and folder access they have |
| [**PostChangePassword**](UserManagementApi.md#postchangepassword) | **POST** /rest/changePassword | Changes the password of an existing user on the server. |
| [**PostCreateUser**](UserManagementApi.md#postcreateuser) | **POST** /rest/createUser | Creates a new user on the server. |
| [**PostDeleteUser**](UserManagementApi.md#postdeleteuser) | **POST** /rest/deleteUser | Deletes an existing user on the server. |
| [**PostGetUser**](UserManagementApi.md#postgetuser) | **POST** /rest/getUser | Get details about a given user, including which authorization roles and folder access it has. |
| [**PostGetUsers**](UserManagementApi.md#postgetusers) | **POST** /rest/getUsers | Get details about all users, including which authorization roles and folder access they have |
| [**PostUpdateUser**](UserManagementApi.md#postupdateuser) | **POST** /rest/updateUser | Modifies an existing user on the server. |
| [**UpdateUser**](UserManagementApi.md#updateuser) | **GET** /rest/updateUser | Modifies an existing user on the server. |

<a id="changepassword"></a>
# **ChangePassword**
> SubsonicResponse ChangePassword (string username, string password)

Changes the password of an existing user on the server.

Changes the password of an existing user on the server, using the following parameters. You can only change your own password unless you have admin privileges.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class ChangePasswordExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user which should change its password.
            var password = "password_example";  // string | The new password of the new user, either in clear text of hex-encoded (see above).

            try
            {
                // Changes the password of an existing user on the server.
                SubsonicResponse result = apiInstance.ChangePassword(username, password);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.ChangePassword: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the ChangePasswordWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Changes the password of an existing user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.ChangePasswordWithHttpInfo(username, password);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.ChangePasswordWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user which should change its password. |  |
| **password** | **string** | The new password of the new user, either in clear text of hex-encoded (see above). |  |

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

<a id="createuser"></a>
# **CreateUser**
> SubsonicResponse CreateUser (string username, string password, string email, bool? ldapAuthenticated = null, bool? adminRole = null, bool? settingsRole = null, bool? streamRole = null, bool? jukeboxRole = null, bool? downloadRole = null, bool? uploadRole = null, bool? playlistRole = null, bool? coverArtRole = null, bool? commentRole = null, bool? podcastRole = null, bool? shareRole = null, bool? videoConversionRole = null, List<string>? musicFolderId = null)

Creates a new user on the server.

Creates a new user on the server.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class CreateUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the new user.
            var password = "password_example";  // string | The password of the new user, either in clear text of hex-encoded (see above).
            var email = "email_example";  // string | The email address of the new user.
            var ldapAuthenticated = false;  // bool? | Whether the user is authenticated in LDAP. (optional)  (default to false)
            var adminRole = false;  // bool? | Whether the user is administrator. (optional)  (default to false)
            var settingsRole = true;  // bool? | Whether the user is allowed to change personal settings and password. (optional)  (default to true)
            var streamRole = true;  // bool? | Whether the user is allowed to play files. (optional)  (default to true)
            var jukeboxRole = false;  // bool? | Whether the user is allowed to play files in jukebox mode. (optional)  (default to false)
            var downloadRole = false;  // bool? | Whether the user is allowed to download files. (optional)  (default to false)
            var uploadRole = false;  // bool? | Whether the user is allowed to upload files. (optional)  (default to false)
            var playlistRole = false;  // bool? | Whether the user is allowed to create and delete playlists. Since 1.8.0, changing this role has no effect. (optional)  (default to false)
            var coverArtRole = false;  // bool? | Whether the user is allowed to change cover art and tags. (optional)  (default to false)
            var commentRole = false;  // bool? | Whether the user is allowed to create and edit comments and ratings. (optional)  (default to false)
            var podcastRole = false;  // bool? | Whether the user is allowed to administrate Podcasts. (optional)  (default to false)
            var shareRole = false;  // bool? | (Since 1.8.0) Whether the user is allowed to share files with anyone. (optional)  (default to false)
            var videoConversionRole = false;  // bool? | (Since 1.15.0) Whether the user is allowed to start video conversions. (optional)  (default to false)
            var musicFolderId = new List<string>?(); // List<string>? | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. Default all folders. (optional) 

            try
            {
                // Creates a new user on the server.
                SubsonicResponse result = apiInstance.CreateUser(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, playlistRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.CreateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the CreateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Creates a new user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.CreateUserWithHttpInfo(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, playlistRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.CreateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the new user. |  |
| **password** | **string** | The password of the new user, either in clear text of hex-encoded (see above). |  |
| **email** | **string** | The email address of the new user. |  |
| **ldapAuthenticated** | **bool?** | Whether the user is authenticated in LDAP. | [optional] [default to false] |
| **adminRole** | **bool?** | Whether the user is administrator. | [optional] [default to false] |
| **settingsRole** | **bool?** | Whether the user is allowed to change personal settings and password. | [optional] [default to true] |
| **streamRole** | **bool?** | Whether the user is allowed to play files. | [optional] [default to true] |
| **jukeboxRole** | **bool?** | Whether the user is allowed to play files in jukebox mode. | [optional] [default to false] |
| **downloadRole** | **bool?** | Whether the user is allowed to download files. | [optional] [default to false] |
| **uploadRole** | **bool?** | Whether the user is allowed to upload files. | [optional] [default to false] |
| **playlistRole** | **bool?** | Whether the user is allowed to create and delete playlists. Since 1.8.0, changing this role has no effect. | [optional] [default to false] |
| **coverArtRole** | **bool?** | Whether the user is allowed to change cover art and tags. | [optional] [default to false] |
| **commentRole** | **bool?** | Whether the user is allowed to create and edit comments and ratings. | [optional] [default to false] |
| **podcastRole** | **bool?** | Whether the user is allowed to administrate Podcasts. | [optional] [default to false] |
| **shareRole** | **bool?** | (Since 1.8.0) Whether the user is allowed to share files with anyone. | [optional] [default to false] |
| **videoConversionRole** | **bool?** | (Since 1.15.0) Whether the user is allowed to start video conversions. | [optional] [default to false] |
| **musicFolderId** | [**List&lt;string&gt;?**](string.md) | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. Default all folders. | [optional]  |

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

<a id="deleteuser"></a>
# **DeleteUser**
> SubsonicResponse DeleteUser (string username)

Deletes an existing user on the server.

Deletes an existing user on the server.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class DeleteUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user to delete.

            try
            {
                // Deletes an existing user on the server.
                SubsonicResponse result = apiInstance.DeleteUser(username);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.DeleteUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Deletes an existing user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.DeleteUserWithHttpInfo(username);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.DeleteUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user to delete. |  |

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

<a id="getuser"></a>
# **GetUser**
> GetUserResponse GetUser (string username)

Get details about a given user, including which authorization roles and folder access it has.

Get details about a given user, including which authorization roles and folder access it has. Can be used to enable/disable certain features in the client, such as jukebox control.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user to retrieve. You can only retrieve your own user unless you have admin privileges.

            try
            {
                // Get details about a given user, including which authorization roles and folder access it has.
                GetUserResponse result = apiInstance.GetUser(username);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.GetUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get details about a given user, including which authorization roles and folder access it has.
    ApiResponse<GetUserResponse> response = apiInstance.GetUserWithHttpInfo(username);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.GetUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user to retrieve. You can only retrieve your own user unless you have admin privileges. |  |

### Return type

[**GetUserResponse**](GetUserResponse.md)

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

<a id="getusers"></a>
# **GetUsers**
> GetUsersResponse GetUsers ()

Get details about all users, including which authorization roles and folder access they have

Get details about all users, including which authorization roles and folder access they have. Only users with admin privileges are allowed to call this method.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class GetUsersExample
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

            var apiInstance = new UserManagementApi(config);

            try
            {
                // Get details about all users, including which authorization roles and folder access they have
                GetUsersResponse result = apiInstance.GetUsers();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.GetUsers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetUsersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get details about all users, including which authorization roles and folder access they have
    ApiResponse<GetUsersResponse> response = apiInstance.GetUsersWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.GetUsersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetUsersResponse**](GetUsersResponse.md)

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

<a id="postchangepassword"></a>
# **PostChangePassword**
> SubsonicResponse PostChangePassword (string username, string password)

Changes the password of an existing user on the server.

Changes the password of an existing user on the server, using the following parameters. You can only change your own password unless you have admin privileges.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostChangePasswordExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user which should change its password.
            var password = "password_example";  // string | The new password of the new user, either in clear text of hex-encoded (see above).

            try
            {
                // Changes the password of an existing user on the server.
                SubsonicResponse result = apiInstance.PostChangePassword(username, password);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.PostChangePassword: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostChangePasswordWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Changes the password of an existing user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.PostChangePasswordWithHttpInfo(username, password);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.PostChangePasswordWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user which should change its password. |  |
| **password** | **string** | The new password of the new user, either in clear text of hex-encoded (see above). |  |

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

<a id="postcreateuser"></a>
# **PostCreateUser**
> SubsonicResponse PostCreateUser (string username, string password, string email, bool? ldapAuthenticated = null, bool? adminRole = null, bool? settingsRole = null, bool? streamRole = null, bool? jukeboxRole = null, bool? downloadRole = null, bool? uploadRole = null, bool? playlistRole = null, bool? coverArtRole = null, bool? commentRole = null, bool? podcastRole = null, bool? shareRole = null, bool? videoConversionRole = null, List<string>? musicFolderId = null)

Creates a new user on the server.

Creates a new user on the server.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostCreateUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the new user.
            var password = "password_example";  // string | The password of the new user, either in clear text or hex-encoded.
            var email = "email_example";  // string | The email address of the new user.
            var ldapAuthenticated = false;  // bool? | Whether the user is authenticated in LDAP. (optional)  (default to false)
            var adminRole = false;  // bool? | Whether the user is administrator. (optional)  (default to false)
            var settingsRole = true;  // bool? | Whether the user is allowed to change personal settings and password. (optional)  (default to true)
            var streamRole = true;  // bool? | Whether the user is allowed to play files. (optional)  (default to true)
            var jukeboxRole = false;  // bool? | Whether the user is allowed to play files in jukebox mode. (optional)  (default to false)
            var downloadRole = false;  // bool? | Whether the user is allowed to download files. (optional)  (default to false)
            var uploadRole = false;  // bool? | Whether the user is allowed to upload files. (optional)  (default to false)
            var playlistRole = false;  // bool? | Whether the user is allowed to create and delete playlists. Since 1.8.0, changing this role has no effect. (optional)  (default to false)
            var coverArtRole = false;  // bool? | Whether the user is allowed to change cover art and tags. (optional)  (default to false)
            var commentRole = false;  // bool? | Whether the user is allowed to create and edit comments and ratings. (optional)  (default to false)
            var podcastRole = false;  // bool? | Whether the user is allowed to administrate Podcasts. (optional)  (default to false)
            var shareRole = false;  // bool? | (Since 1.8.0) Whether the user is allowed to share files with anyone. (optional)  (default to false)
            var videoConversionRole = false;  // bool? | (Since 1.15.0) Whether the user is allowed to start video conversions. (optional)  (default to false)
            var musicFolderId = new List<string>?(); // List<string>? | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. Default all folders. (optional) 

            try
            {
                // Creates a new user on the server.
                SubsonicResponse result = apiInstance.PostCreateUser(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, playlistRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.PostCreateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostCreateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Creates a new user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.PostCreateUserWithHttpInfo(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, playlistRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.PostCreateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the new user. |  |
| **password** | **string** | The password of the new user, either in clear text or hex-encoded. |  |
| **email** | **string** | The email address of the new user. |  |
| **ldapAuthenticated** | **bool?** | Whether the user is authenticated in LDAP. | [optional] [default to false] |
| **adminRole** | **bool?** | Whether the user is administrator. | [optional] [default to false] |
| **settingsRole** | **bool?** | Whether the user is allowed to change personal settings and password. | [optional] [default to true] |
| **streamRole** | **bool?** | Whether the user is allowed to play files. | [optional] [default to true] |
| **jukeboxRole** | **bool?** | Whether the user is allowed to play files in jukebox mode. | [optional] [default to false] |
| **downloadRole** | **bool?** | Whether the user is allowed to download files. | [optional] [default to false] |
| **uploadRole** | **bool?** | Whether the user is allowed to upload files. | [optional] [default to false] |
| **playlistRole** | **bool?** | Whether the user is allowed to create and delete playlists. Since 1.8.0, changing this role has no effect. | [optional] [default to false] |
| **coverArtRole** | **bool?** | Whether the user is allowed to change cover art and tags. | [optional] [default to false] |
| **commentRole** | **bool?** | Whether the user is allowed to create and edit comments and ratings. | [optional] [default to false] |
| **podcastRole** | **bool?** | Whether the user is allowed to administrate Podcasts. | [optional] [default to false] |
| **shareRole** | **bool?** | (Since 1.8.0) Whether the user is allowed to share files with anyone. | [optional] [default to false] |
| **videoConversionRole** | **bool?** | (Since 1.15.0) Whether the user is allowed to start video conversions. | [optional] [default to false] |
| **musicFolderId** | [**List&lt;string&gt;?**](string.md) | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. Default all folders. | [optional]  |

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

<a id="postdeleteuser"></a>
# **PostDeleteUser**
> SubsonicResponse PostDeleteUser (string username)

Deletes an existing user on the server.

Deletes an existing user on the server.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostDeleteUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user to delete.

            try
            {
                // Deletes an existing user on the server.
                SubsonicResponse result = apiInstance.PostDeleteUser(username);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.PostDeleteUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostDeleteUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Deletes an existing user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.PostDeleteUserWithHttpInfo(username);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.PostDeleteUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user to delete. |  |

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

<a id="postgetuser"></a>
# **PostGetUser**
> GetUserResponse PostGetUser (string username)

Get details about a given user, including which authorization roles and folder access it has.

Get details about a given user, including which authorization roles and folder access it has. Can be used to enable/disable certain features in the client, such as jukebox control.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user to retrieve. You can only retrieve your own user unless you have admin privileges.

            try
            {
                // Get details about a given user, including which authorization roles and folder access it has.
                GetUserResponse result = apiInstance.PostGetUser(username);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.PostGetUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get details about a given user, including which authorization roles and folder access it has.
    ApiResponse<GetUserResponse> response = apiInstance.PostGetUserWithHttpInfo(username);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.PostGetUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user to retrieve. You can only retrieve your own user unless you have admin privileges. |  |

### Return type

[**GetUserResponse**](GetUserResponse.md)

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

<a id="postgetusers"></a>
# **PostGetUsers**
> GetUsersResponse PostGetUsers ()

Get details about all users, including which authorization roles and folder access they have

Get details about all users, including which authorization roles and folder access they have. Only users with admin privileges are allowed to call this method.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostGetUsersExample
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

            var apiInstance = new UserManagementApi(config);

            try
            {
                // Get details about all users, including which authorization roles and folder access they have
                GetUsersResponse result = apiInstance.PostGetUsers();
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.PostGetUsers: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostGetUsersWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get details about all users, including which authorization roles and folder access they have
    ApiResponse<GetUsersResponse> response = apiInstance.PostGetUsersWithHttpInfo();
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.PostGetUsersWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters
This endpoint does not need any parameter.
### Return type

[**GetUsersResponse**](GetUsersResponse.md)

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

<a id="postupdateuser"></a>
# **PostUpdateUser**
> SubsonicResponse PostUpdateUser (string username, string password, string? email = null, bool? ldapAuthenticated = null, bool? adminRole = null, bool? settingsRole = null, bool? streamRole = null, bool? jukeboxRole = null, bool? downloadRole = null, bool? uploadRole = null, bool? coverArtRole = null, bool? commentRole = null, bool? podcastRole = null, bool? shareRole = null, bool? videoConversionRole = null, List<string>? musicFolderId = null, int? maxBitRate = null)

Modifies an existing user on the server.

Modifies an existing user on the server.  Requires OpenSubsonic extension name `formPost` (As returned by `getOpenSubsonicExtensions`)

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class PostUpdateUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user.
            var password = "password_example";  // string | The password of the user, either in clear text or hex-encoded.
            var email = "email_example";  // string? | The email address of the user. (optional) 
            var ldapAuthenticated = false;  // bool? | Whether the user is authenticated in LDAP. (optional)  (default to false)
            var adminRole = false;  // bool? | Whether the user is an administrator. (optional)  (default to false)
            var settingsRole = true;  // bool? | Whether the user is allowed to change personal settings and password. (optional)  (default to true)
            var streamRole = true;  // bool? | Whether the user is allowed to play files. (optional)  (default to true)
            var jukeboxRole = false;  // bool? | Whether the user is allowed to play files in jukebox mode. (optional)  (default to false)
            var downloadRole = false;  // bool? | Whether the user is allowed to download files. (optional)  (default to false)
            var uploadRole = false;  // bool? | Whether the user is allowed to upload files. (optional)  (default to false)
            var coverArtRole = false;  // bool? | Whether the user is allowed to change cover art and tags. (optional)  (default to false)
            var commentRole = false;  // bool? | Whether the user is allowed to create and edit comments and ratings. (optional)  (default to false)
            var podcastRole = false;  // bool? | Whether the user is allowed to administrate Podcasts. (optional)  (default to false)
            var shareRole = false;  // bool? | Whether the user is allowed to share files with anyone. (optional)  (default to false)
            var videoConversionRole = false;  // bool? | (Since 1.15.0) Whether the user is allowed to start video conversions. (optional)  (default to false)
            var musicFolderId = new List<string>?(); // List<string>? | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. (optional) 
            var maxBitRate = 0;  // int? | (Since 1.13.0) The maximum bit rate (in Kbps) for the user. Audio streams of higher bit rates are automatically downsampled to this bit rate. Legal values: 0 (no limit), 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320. (optional) 

            try
            {
                // Modifies an existing user on the server.
                SubsonicResponse result = apiInstance.PostUpdateUser(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId, maxBitRate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.PostUpdateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostUpdateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Modifies an existing user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.PostUpdateUserWithHttpInfo(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId, maxBitRate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.PostUpdateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user. |  |
| **password** | **string** | The password of the user, either in clear text or hex-encoded. |  |
| **email** | **string?** | The email address of the user. | [optional]  |
| **ldapAuthenticated** | **bool?** | Whether the user is authenticated in LDAP. | [optional] [default to false] |
| **adminRole** | **bool?** | Whether the user is an administrator. | [optional] [default to false] |
| **settingsRole** | **bool?** | Whether the user is allowed to change personal settings and password. | [optional] [default to true] |
| **streamRole** | **bool?** | Whether the user is allowed to play files. | [optional] [default to true] |
| **jukeboxRole** | **bool?** | Whether the user is allowed to play files in jukebox mode. | [optional] [default to false] |
| **downloadRole** | **bool?** | Whether the user is allowed to download files. | [optional] [default to false] |
| **uploadRole** | **bool?** | Whether the user is allowed to upload files. | [optional] [default to false] |
| **coverArtRole** | **bool?** | Whether the user is allowed to change cover art and tags. | [optional] [default to false] |
| **commentRole** | **bool?** | Whether the user is allowed to create and edit comments and ratings. | [optional] [default to false] |
| **podcastRole** | **bool?** | Whether the user is allowed to administrate Podcasts. | [optional] [default to false] |
| **shareRole** | **bool?** | Whether the user is allowed to share files with anyone. | [optional] [default to false] |
| **videoConversionRole** | **bool?** | (Since 1.15.0) Whether the user is allowed to start video conversions. | [optional] [default to false] |
| **musicFolderId** | [**List&lt;string&gt;?**](string.md) | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. | [optional]  |
| **maxBitRate** | **int?** | (Since 1.13.0) The maximum bit rate (in Kbps) for the user. Audio streams of higher bit rates are automatically downsampled to this bit rate. Legal values: 0 (no limit), 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320. | [optional]  |

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

<a id="updateuser"></a>
# **UpdateUser**
> SubsonicResponse UpdateUser (string username, string password, string? email = null, bool? ldapAuthenticated = null, bool? adminRole = null, bool? settingsRole = null, bool? streamRole = null, bool? jukeboxRole = null, bool? downloadRole = null, bool? uploadRole = null, bool? coverArtRole = null, bool? commentRole = null, bool? podcastRole = null, bool? shareRole = null, bool? videoConversionRole = null, List<string>? musicFolderId = null, int? maxBitRate = null)

Modifies an existing user on the server.

Modifies an existing user on the server.

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using WinSonic.Subsonic.Client.Api;
using WinSonic.Subsonic.Client.Client;
using WinSonic.Subsonic.Client.Model;

namespace Example
{
    public class UpdateUserExample
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

            var apiInstance = new UserManagementApi(config);
            var username = "username_example";  // string | The name of the user.
            var password = "password_example";  // string | The password of the user, either in clear text of hex-encoded (see above).
            var email = "email_example";  // string? | The email address of the user. (optional) 
            var ldapAuthenticated = false;  // bool? | Whether the user is authenicated in LDAP. (optional)  (default to false)
            var adminRole = false;  // bool? | Whether the user is administrator. (optional)  (default to false)
            var settingsRole = true;  // bool? | Whether the user is allowed to change personal settings and password. (optional)  (default to true)
            var streamRole = true;  // bool? | Whether the user is allowed to play files. (optional)  (default to true)
            var jukeboxRole = false;  // bool? | Whether the user is allowed to play files in jukebox mode. (optional)  (default to false)
            var downloadRole = false;  // bool? | Whether the user is allowed to download files. (optional)  (default to false)
            var uploadRole = false;  // bool? | Whether the user is allowed to upload files. (optional)  (default to false)
            var coverArtRole = false;  // bool? | Whether the user is allowed to change cover art and tags. (optional)  (default to false)
            var commentRole = false;  // bool? | Whether the user is allowed to create and edit comments and ratings. (optional)  (default to false)
            var podcastRole = false;  // bool? | Whether the user is allowed to administrate Podcasts. (optional)  (default to false)
            var shareRole = false;  // bool? | Whether the user is allowed to share files with anyone. (optional)  (default to false)
            var videoConversionRole = false;  // bool? | (Since 1.15.0) Whether the user is allowed to start video conversions. (optional)  (default to false)
            var musicFolderId = new List<string>?(); // List<string>? | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. (optional) 
            var maxBitRate = 0;  // int? | (Since 1.13.0) The maximum bit rate (in Kbps) for the user. Audio streams of higher bit rates are automatically downsampled to this bit rate. Legal values: 0 (no limit), 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320. (optional) 

            try
            {
                // Modifies an existing user on the server.
                SubsonicResponse result = apiInstance.UpdateUser(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId, maxBitRate);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling UserManagementApi.UpdateUser: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the UpdateUserWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Modifies an existing user on the server.
    ApiResponse<SubsonicResponse> response = apiInstance.UpdateUserWithHttpInfo(username, password, email, ldapAuthenticated, adminRole, settingsRole, streamRole, jukeboxRole, downloadRole, uploadRole, coverArtRole, commentRole, podcastRole, shareRole, videoConversionRole, musicFolderId, maxBitRate);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling UserManagementApi.UpdateUserWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **username** | **string** | The name of the user. |  |
| **password** | **string** | The password of the user, either in clear text of hex-encoded (see above). |  |
| **email** | **string?** | The email address of the user. | [optional]  |
| **ldapAuthenticated** | **bool?** | Whether the user is authenicated in LDAP. | [optional] [default to false] |
| **adminRole** | **bool?** | Whether the user is administrator. | [optional] [default to false] |
| **settingsRole** | **bool?** | Whether the user is allowed to change personal settings and password. | [optional] [default to true] |
| **streamRole** | **bool?** | Whether the user is allowed to play files. | [optional] [default to true] |
| **jukeboxRole** | **bool?** | Whether the user is allowed to play files in jukebox mode. | [optional] [default to false] |
| **downloadRole** | **bool?** | Whether the user is allowed to download files. | [optional] [default to false] |
| **uploadRole** | **bool?** | Whether the user is allowed to upload files. | [optional] [default to false] |
| **coverArtRole** | **bool?** | Whether the user is allowed to change cover art and tags. | [optional] [default to false] |
| **commentRole** | **bool?** | Whether the user is allowed to create and edit comments and ratings. | [optional] [default to false] |
| **podcastRole** | **bool?** | Whether the user is allowed to administrate Podcasts. | [optional] [default to false] |
| **shareRole** | **bool?** | Whether the user is allowed to share files with anyone. | [optional] [default to false] |
| **videoConversionRole** | **bool?** | (Since 1.15.0) Whether the user is allowed to start video conversions. | [optional] [default to false] |
| **musicFolderId** | [**List&lt;string&gt;?**](string.md) | (Since 1.12.0) IDs of the music folders the user is allowed access to. Include the parameter once for each folder. | [optional]  |
| **maxBitRate** | **int?** | (Since 1.13.0) The maximum bit rate (in Kbps) for the user. Audio streams of higher bit rates are automatically downsampled to this bit rate. Legal values: 0 (no limit), 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320. | [optional]  |

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

