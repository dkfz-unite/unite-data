namespace Unite.Data.Utilities.Mutations;

public static class CodonChangeCodeGenerator
{
    public static string Generate(int? start, int? end, string change)
    {
        if (start != null && end != null && !string.IsNullOrWhiteSpace(change))
        {
            var basePair = BasePairChangeParser.Parse(change);

            var position = start;
            var referenceBase = GetChangedAlleles(basePair.ReferenceBase) ?? "-";
            var alternateBase = GetChangedAlleles(basePair.AlternateBase) ?? "-";

            return $"{position}{referenceBase}>{alternateBase}";
        }
        else
        {
            return null;
        }
    }

    private static string GetChangedAlleles(string sequence)
    {
        if (sequence != null)
        {
            var alleles = sequence.Where(allele => char.IsUpper(allele)).ToArray();

            return alleles.Any() ? new string(alleles) : null;
        }
        else
        {
            return null;
        }
    }
}
