using Unite.Data.Entities.Genome.Abstractions;
using Unite.Data.Entities.Genome.Enums;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Helpers.Genome;

public static class RangeHelper
{
    /// <summary>
    /// Checks whether variant is in range.
    /// </summary>
    /// <param name="variant">Variant.</param>
    /// <param name="chr">Chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if variant is in range, false otherwise.</returns> 
    public static bool IsInRange(this SSM.Variant variant, Chromosome  chr, int start, int end)
    {
        return ChromosomesMatch(variant.ChromosomeId, chr) &&
               PositionsMatch(variant.Start, variant.End, start, end);
    }

    /// <summary>
    /// Checks whether variant is in range.
    /// </summary>
    /// <param name="variant">Variant.</param>
    /// <param name="startChr">Start chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="endChr">End chromosome.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if variant is in range, false otherwise.</returns>
    public static bool IsInRange(this SSM.Variant variant, Chromosome startChr, int start, Chromosome endChr, int end)
    {
        return ChromosomesMatch(variant.ChromosomeId, startChr, endChr) &&
               PositionsMatch(variant.Start, variant.End, start, end);
    }

    /// <summary>
    /// Checks whether variant is in range.
    /// </summary>
    /// <param name="variant">Variant.</param>
    /// <param name="chr">Chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if variant is in range, false otherwise.</returns> 
    public static bool IsInRange(this CNV.Variant variant, Chromosome chr, int start, int end)
    {
        return ChromosomesMatch(variant.ChromosomeId, chr) &&
               PositionsMatch(variant.Start, variant.End, start, end);
    }

    /// <summary>
    /// Checks whether variant is in range.
    /// </summary>
    /// <param name="variant">Variant.</param>
    /// <param name="startChr">Start chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="endChr">End chromosome.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if variant is in range, false otherwise.</returns> 
    public static bool IsInRange(this CNV.Variant variant, Chromosome startChr, int start, Chromosome endChr, int end)
    {
        return ChromosomesMatch(variant.ChromosomeId, startChr, endChr) &&
               PositionsMatch(variant.Start, variant.End, start, end);
    }

    /// <summary>
    /// Checks whether variant is in range. Ignores cross chromosomal variants.
    /// </summary>
    /// <param name="variant">Variant.</param>
    /// <param name="chr">Chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if variant is in range, false otherwise.</returns> 
    public static bool IsInRange(SV.Variant variant, Chromosome chr, int start, int end)
    {
        // SV start and end positions are different from SSM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2

        return ChromosomesMatch(variant.ChromosomeId, chr) &&
               ChromosomesMatch(variant.OtherChromosomeId, chr) &&
               PositionsMatch(variant.End, variant.OtherStart, start, end);
    }

    /// <summary>
    /// Checks whether variant is in range. Ignores cross chromosomal variants.
    /// </summary>
    /// <param name="variant">Variant.</param>
    /// <param name="startChr">Start chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="endChr">End chromosome.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if variant is in range, false otherwise.</returns>
    public static bool IsInRange(this SV.Variant variant, Chromosome startChr, int start, Chromosome endChr, int end)
    {
        // SV start and end positions are different from SSM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2

        return ChromosomesMatch(variant.ChromosomeId, startChr, endChr) &&
               ChromosomesMatch(variant.OtherChromosomeId, startChr, endChr) &&
               PositionsMatch(variant.End, variant.OtherStart, start, end);
    }

    /// <summary>
    /// Checks whether dna entity is in range.
    /// </summary>
    /// <param name="entity">DNA entity.</param>
    /// <param name="chr">Chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if dna entity is in range, false otherwise.</returns> 
    public static bool IsInRange(this IDnaEntity entity, Chromosome chr, int start, int end)
    {
        return ChromosomesMatch(entity.ChromosomeId, chr) &&
               PositionsMatch(entity.Start, entity.End, start, end);
    }

    /// <summary>
    /// Checks whether dna entity is in range.
    /// </summary>
    /// <param name="entity">DNA entity.</param>
    /// <param name="startChr">Start chromosome.</param>
    /// <param name="start">Start position.</param>
    /// <param name="endChr">End chromosome.</param>
    /// <param name="end">End position.</param>
    /// <returns>True if dna entity is in range, false otherwise.</returns>
    public static bool IsInRange(this IDnaEntity entity, Chromosome startChr, int start, Chromosome endChr, int end)
    {
        return ChromosomesMatch(entity.ChromosomeId, startChr, endChr) &&
               PositionsMatch(entity.Start, entity.End, start, end);
    }


    private static bool ChromosomesMatch(Chromosome? chr, Chromosome rangeChr)
    {
        return chr == rangeChr;
    }

    private static bool ChromosomesMatch(Chromosome? chr, Chromosome rangeStartChr, Chromosome rangeEndChr)
    {
        return (int)chr >= (int)rangeStartChr && (int)chr <= (int)rangeEndChr;
    }

    private static bool PositionsMatch(int? start, int? end, int rangeStart, int rangeEnd)
    {
        return (start >= rangeStart && start <= rangeEnd)
            || (end >= rangeStart && end <= rangeEnd)
            || (start <= rangeStart && end >= rangeEnd);
    }
}
