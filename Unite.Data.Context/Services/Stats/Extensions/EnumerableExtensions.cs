namespace Unite.Data.Context.Services.Stats.Extensions;

internal static class EnumerableExtensions
{
    /// <summary>
    /// Groups the source collection into ranges based on the specified number property.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <param name="source">Source elements collection.</param>
    /// <param name="selector">Grouping property selector.</param>
    /// <param name="rangesNumber">Number of ranges (defaults to 5).</param>
    /// <param name="desiredMin">Desired minimum.</param>
    /// <param name="desiredMax">Desired maximum.</param>
    /// <returns>Elements grouped into ranges by the specified number property.</returns>
    public static IEnumerable<IGrouping<int?, T>> GroupIntoRangesBy<T>(
        this IEnumerable<T> source,
        Func<T, int?> selector,
        byte rangesNumber = 5,
        int? desiredMin = null,
        int? desiredMax = null)
    {
        var groups = DefineGroups(source.Select(selector), rangesNumber, desiredMin, desiredMax);

        return source.GroupBy(entry => GetGroup(selector(entry), groups));
    }

    /// <summary>
    /// Groups the source collection into ranges based on the specified number property.
    /// </summary>
    /// <typeparam name="T">Element type.</typeparam>
    /// <param name="source">Source elements collection.</param>
    /// <param name="selector">Grouping property selector.</param>
    /// <param name="rangesNumber">Number of ranges (defaults to 5).</param>
    /// <param name="desiredMin">Desired minimum.</param>
    /// <param name="desiredMax">Desired maximum.</param>
    /// <returns>Elements grouped into ranges by the specified number property.</returns>
    public static IEnumerable<IGrouping<double?, T>> GroupIntoRangesBy<T>(
        this IEnumerable<T> source, Func<T,
        double?> selector,
        byte rangesNumber = 5,
        double? desiredMin = null,
        double? desiredMax = null)
    {
        var groups = DefineGroups(source.Select(selector), rangesNumber, desiredMin, desiredMax);

        return source.GroupBy(entry => GetGroup(selector(entry), groups));
    }


    private static IEnumerable<int> DefineGroups(
        IEnumerable<int?> source,
        byte rangesNumber = 5,
        int? desiredMin = default,
        int? desiredMax = default)
    {
        if (!source.Any())
            yield break;

        var values = source.Where(value => value != null).Select(value => value.Value);
        var min = desiredMin ?? values.Min();
        var max = desiredMax ?? values.Max();

        if (min == max)
            yield return min;

        var step = (max - min) / rangesNumber;
        
        for (int i = 1; i <= rangesNumber; i++)
            yield return min + step * i;
    }

    private static IEnumerable<double> DefineGroups(
        IEnumerable<double?> source,
        byte rangesNumber = 5,
        double? desiredMin = default,
        double? desiredMax = default)
    {
        if (!source.Any())
            yield break;

        var values = source.Where(value => value != null).Select(value => value.Value);
        var min = desiredMin ?? Math.Floor(values.Min());
        var max = desiredMax ?? Math.Ceiling(values.Max());

        if (min == max)
            yield return min;

        var step = Math.Round((max - min) / rangesNumber);

        for (int i = 1; i <= rangesNumber; i++)
            yield return min + step * i;
    }

    private static int? GetGroup(
        int? value,
        IEnumerable<int> groups)
    {
        if (value == null)
            return null;

        for (int i = 0; i < groups.Count(); i++)
            if (value <= groups.ElementAt(i))
                return groups.ElementAt(i);
                
        return groups.Last();
    }

    private static double? GetGroup(
        double? value,
        IEnumerable<double> groups)
    {
        if (value == null)
            return null;

        for (int i = 0; i < groups.Count(); i++)
            if (value <= groups.ElementAt(i))
                return groups.ElementAt(i);

        return groups.Last();
    }
}
