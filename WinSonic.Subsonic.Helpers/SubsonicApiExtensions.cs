namespace WinSonic.Subsonic.Helpers;

public static class SubsonicApiExtensions
{
    public static List<TResult> ConvertList<TInner, TResult>(this List<TInner> collection, Func<TInner, TResult> action){
        return collection.Select(action).ToList();
    }
    
    public static TResult[] ConvertArray<TInner, TResult>(this List<TInner> collection, Func<TInner, TResult> action){
        return collection.Select(action).ToArray();
    }
}
