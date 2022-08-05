namespace Unite.Data.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Executes given action for each element of collection
    /// </summary>
    /// <typeparam name="T">Element type</typeparam>
    /// <param name="items">Source collection of elements</param>
    /// <param name="action">Action to execute</param>
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (var item in items)
        {
            action.Invoke(item);
        }
    }
}
