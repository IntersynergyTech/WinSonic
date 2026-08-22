using GnomeStack.Standard;
using WinSonic.Service.SecureData;

namespace WinSonic.Gui.Xplat.Misc.Platform;

public class XplatSecureDataService : ISecureDataService
{
    private const string SecretServiceName = "WinSonic";

    public string? GetValueByKey(string key)
    {
        return OsSecretVault.GetSecret(SecretServiceName, key);
    }

    public void SetValueByKey(string key, string? value)
    {
        if (value is null)
        {
            // If the value is null, we can delete the secret by setting it to an empty string
            OsSecretVault.DeleteSecret(SecretServiceName, key);
        }
        else
        {
            // If the value is not null, we can set the secret
            OsSecretVault.SetSecret(SecretServiceName, key, value);
        }
    }
}
