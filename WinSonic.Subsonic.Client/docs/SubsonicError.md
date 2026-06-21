# WinSonic.Subsonic.Client.Model.SubsonicError

## Properties

Name | Type | Description | Notes
------------ | ------------- | ------------- | -------------
**Code** | **int** | The error code. * 0: A generic error. * 10: Required parameter is missing. * 20: Incompatible Subsonic REST protocol version. Client must upgrade. * 30: Incompatible Subsonic REST protocol version. Server must upgrade. * 40: Wrong username or password. * 41: Token authentication not supported for LDAP users. * 42: Provided authentication mechanism not supported. * 43: Multiple conflicting authentication mechanisms provided. * 44: Invalid API key. * 50: User is not authorized for the given operation. * 60: The trial period for the Subsonic server is over. Please upgrade to Subsonic Premium. Visit subsonic.org for details. * 70: The requested data was not found. | 
**Message** | **string** | The optional error message | [optional] 
**HelpUrl** | **string** | A URL (documentation, configuration, etc) which may provide additional context for the error) | [optional] 

[[Back to Model list]](../README.md#documentation-for-models) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to README]](../README.md)

