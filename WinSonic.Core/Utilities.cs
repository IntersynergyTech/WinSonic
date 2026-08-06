namespace WinSonic.Core;

public static class Utilities
{
    public static List<TResult> ConvertList<TInner, TResult>(this ICollection<TInner> collection, Func<TInner, TResult> action){
        return collection.Select(action).ToList();
    }
    
    public static TResult[] ConvertArray<TInner, TResult>(this ICollection<TInner> collection, Func<TInner, TResult> action){
        return collection.Select(action).ToArray();
    }
}
