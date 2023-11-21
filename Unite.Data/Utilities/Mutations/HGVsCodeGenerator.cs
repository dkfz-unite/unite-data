using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Extensions;

namespace Unite.Data.Utilities.Mutations;

public static class HGVsCodeGenerator
{
    /// <summary>
    /// Generates HGVs mutation code.
    /// </summary>
    /// <param name="chr">Chromosome</param>
    /// <param name="pos">Position</param>
    /// <param name="refBase">Reference base</param>
    /// <param name="altBase">Alternate base</param>
    /// <returns>HGVs mutation code.</returns>
    public static string Generate(Chromosome chr, string pos, string refBase, string altBase)
    {
        var position = PositionParser.Parse(pos);

        return Generate(chr, position.Start, refBase, altBase);
    }

    /// <summary>
    /// Generates HGVs mutation code.
    /// </summary>
    /// <param name="chr">Chromosome</param>
    /// <param name="start">Mutation start</param>
    /// <param name="refBase">Reference base</param>
    /// <param name="altBase">Alternate base</param>
    /// <returns>HGVs mutation code.</returns>
    public static string Generate(Chromosome chr, int start, string refBase, string altBase)
    {
        var chromosome = $"chr{chr.ToDefinitionString()}";
        var sequenceType = "g";
        var position = $"{start}";
        var referenceBase = refBase ?? "-";
        var alternateBase = altBase ?? "-";

        return $"{chromosome}:{sequenceType}.{position}{referenceBase}>{alternateBase}";
    }
}
