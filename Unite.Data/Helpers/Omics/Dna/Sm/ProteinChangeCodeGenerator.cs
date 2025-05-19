using Unite.Data.Helpers.Omics.Dna.Sm;

namespace Unite.Data.Helpers.Omics.Dna.Sm;

public static class ProteinChangeCodeGenerator
{
    /// <summary>
    /// Generates amino acid change code from position and change string.
    /// </summary>
    /// <param name="start">Change start psition (e.g. 248)</param>
    /// <param name="end">Change end position (e.g. 248)</param>
    /// <param name="change">Change string (e.g. 'R/Q')</param>
    /// <returns>Universal amino acid change code (e.g. 'R248Q')</returns>
    public static string Generate(int? start, int? end, string change)
    {
        if (start != null && end != null && !string.IsNullOrWhiteSpace(change))
        {
            var basePair = BasePairChangeParser.Parse(change);

            var position = start;
            var referenceBase = basePair.ReferenceBase;
            var alternateBase = basePair.AlternateBase;

            return $"{referenceBase}{position}{alternateBase}";
        }
        else
        {
            return null;
        }
    }
}
