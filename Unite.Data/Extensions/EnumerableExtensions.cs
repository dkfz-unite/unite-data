namespace Unite.Data.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Executes given action for each element of collection.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <param name="items">Source collection of elements.</param>
    /// <param name="action">Action to execute.</param>
    public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
    {
        foreach (var item in items)
        {
            action.Invoke(item);
        }
    }

    /// <summary>
    /// Checks if collection null or empty.
    /// </summary>
    /// <typeparam name="T">Collection element type.</typeparam>
    /// <param name="items">Source collection of elements.</param>
    /// <returns>'true' if collection is either null or empty, 'false' otherwise.</returns>
    public static bool IsEmpty<T>(this IEnumerable<T> items)
    {
        return items == null || !items.Any();
    }

    /// <summary>
    /// Checks if collection is not null and have elements.
    /// </summary>
    /// <typeparam name="T">Collection element type.</typeparam>
    /// <param name="items">Source collection of epements.</param>
    /// <returns>'true' if colletion is not null and has elements, 'false' otherwise.</returns>
    public static bool IsNotEmpty<T>(this IEnumerable<T> items)
    {
        return items != null && items.Any();
    }

    /// <summary>
    /// Iterates collection with given bucket size.
    /// </summary>
    /// <typeparam name="T">Collection element type.</typeparam>
    /// <param name="items">Source collection of elements.</param>
    /// <param name="buketSize">Bucket size.</param>
    /// <param name="handler">Bucket processing handler.</param>
    public static void Iterate<T>(this IEnumerable<T> items, int buketSize, Action<T[]> handler)
    {
        var queue = new Queue<T>(items);

        while (queue.Any())
        {
            var chunk = queue.Dequeue(buketSize).ToArray();

            handler(chunk);
        }
    }
}
