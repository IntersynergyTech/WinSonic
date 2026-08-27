namespace WinSonic.Resources.Localisation;

public static class SupportedLanguages
{
    public const string DefaultLanguageIetf = "en-GB";

    public static IReadOnlyList<SupportedLanguage> All { get; } = new[]
    {
        new SupportedLanguage("en-GB", Strings._LanguageEnglishGb),
        new SupportedLanguage("en", Strings._LanguageEnglish)
    };
}

public class SupportedLanguage
{
    public SupportedLanguage(string ietfTag, string displayName)
    {
        IetfTag = ietfTag;
        DisplayName = displayName;
    }

    public string IetfTag { get; }
    public string DisplayName { get; }
}
