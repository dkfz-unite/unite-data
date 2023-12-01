namespace Unite.Data.Helpers.Genome.Variants.SSM;

public static class PositionParser
{
    /// <summary>
    /// Retreives start and end positions from position string.
    /// </summary>
    /// <param name="position">Position string ('1234567890' or '1234567890-1234567890')</param>
    /// <returns>Start and End positions.</returns>
    public static (int Start, int End) Parse(string position)
    {
        if (position.Contains('-'))
        {
            var parts = position.Split('-');

            var start = int.Parse(parts[0]);
            var end = int.Parse(parts[1]);

            return (start, end);
        }
        else
        {
            var start = int.Parse(position);
            var end = int.Parse(position);

            return (start, end);
        }
    }
}
