namespace WinSonic.Service.SecureData;

public interface ISecureDataService
{
    string GetValueByKey(string key);
    void SetValueByKey(string key, string value);
    
}
