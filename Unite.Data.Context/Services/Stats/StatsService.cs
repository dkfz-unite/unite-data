using Unite.Data.Context.Services.Stats.Extensions;

namespace Unite.Data.Context.Services.Stats;

public record Stat<T>(T Key, int Count);

public static class StatsService
{
    public static Stat<TProp>[] GetPropertyBreakdown<T, TProp>(
        IEnumerable<T> entries,
        Func<T, TProp> selector)
        where T : class
    {
        if (!entries.Any())
            return [];

        return entries
            .GroupBy(selector)
            .OrderBy(group => group.Key)
            .Select(group => new Stat<TProp>(group.Key, group.Count()))
            .ToArray();
    }

    public static Stat<int?>[] GetRangeBreakdown<T>(
        IEnumerable<T> entries,
        Func<T, int?> selector,
        byte rangesNumber = 5,
        int? desiredMin = null,
        int? desiredMax = null)
        where T : class
    {
        if (!entries.Any())
            return [];

        return entries
            .GroupIntoRangesBy(selector, rangesNumber, desiredMin, desiredMax)
            .OrderBy(group => group.Key)
            .Select(group => new Stat<int?>(group.Key, group.Count()))
            .ToArray();
    }

    public static Stat<double?>[] GetRangeBreakdown<T>(
        IEnumerable<T> entries,
        Func<T, double?> selector,
        byte rangesNumber = 5,
        double? desiredMin = null,
        double? desiredMax = null)
        where T : class
    {
        if (!entries.Any())
            return [];

        return entries
            .GroupIntoRangesBy(selector, rangesNumber, desiredMin, desiredMax)
            .OrderBy(group => group.Key)
            .Select(group => new Stat<double?>(group.Key, group.Count()))
            .ToArray();
    }
}
