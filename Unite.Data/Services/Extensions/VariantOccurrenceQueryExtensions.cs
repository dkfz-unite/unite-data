using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Services.Genome;

public static class VariantOccurrenceQueryExtensions
{
    /// <summary>
    /// Filters variants by range.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="chromosomeId">Range chromosome.</param>
    /// <param name="start">Range start.</param>
    /// <param name="end">Range end.</param>
    /// <typeparam name="TVO">Variant occurrence type.</typeparam>
    /// <typeparam name="TV">Variant type.</typeparam>
    /// <returns>Query with variants filtered by range.</returns>
    public static IQueryable<TVO> FilterByRange<TVO, TV>(this IQueryable<TVO> query, Chromosome chromosomeId, int start, int end)
        where TVO : VariantOccurrence<TV>
        where TV : Variant
    {
        if (typeof(TV) == typeof(SSM.Variant))
        {
            return FilterByRange(query.Cast<SSM.VariantOccurrence>(), chromosomeId, start, end).Cast<TVO>();
        }
        else if (typeof(TV) == typeof(CNV.Variant))
        {
            return FilterByRange(query.Cast<CNV.VariantOccurrence>(), chromosomeId, start, end).Cast<TVO>();
        }
        else if (typeof(TV) == typeof(SV.Variant))
        {
            return FilterByRange(query.Cast<SV.VariantOccurrence>(), chromosomeId, start, end).Cast<TVO>();
        }

        throw new ArgumentException($"Unsupported variant type: {typeof(TV).Name}");
    }

    /// <summary>
    /// Filters SSMs by range.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="chromosomeId">Range chromosome.</param>
    /// <param name="start">Range start.</param>
    /// <param name="end">Range end.</param>
    /// <returns>Query with SSMs filtered by range.</returns>
    public static IQueryable<SSM.VariantOccurrence> FilterByRange(this  IQueryable<SSM.VariantOccurrence> query, Chromosome chromosomeId, int start, int end)
    {
        return query
            .Where(occurrence => occurrence.Variant.ChromosomeId == chromosomeId)
            .Where(occurrence => (occurrence.Variant.End >= start && occurrence.Variant.End <= end) ||
                                 (occurrence.Variant.Start >= start && occurrence.Variant.Start <= end) ||
                                 (occurrence.Variant.Start >= start && occurrence.Variant.End <= end) ||
                                 (occurrence.Variant.Start <= start && occurrence.Variant.End >= end));
    }

    /// <summary>
    /// Filters CNVs by range.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="chromosomeId">Range chromosome.</param>
    /// <param name="start">Range start.</param>
    /// <param name="end">Range end.</param>
    /// <returns>Query with CNVs filtered by range.</returns>
    public static IQueryable<CNV.VariantOccurrence> FilterByRange(this IQueryable<CNV.VariantOccurrence> query, Chromosome chromosomeId, int start, int end)
    {
        return query
            .Where(occurrence => occurrence.Variant.ChromosomeId == chromosomeId)
            .Where(occurrence => (occurrence.Variant.End >= start && occurrence.Variant.End <= end) ||
                                 (occurrence.Variant.Start >= start && occurrence.Variant.Start <= end) ||
                                 (occurrence.Variant.Start >= start && occurrence.Variant.End <= end) ||
                                 (occurrence.Variant.Start <= start && occurrence.Variant.End >= end));
    }

    /// <summary>
    /// Filters SVs by range.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="chromosomeId">Range chromosome.</param>
    /// <param name="start">Range start.</param>
    /// <param name="end">Range end.</param>
    /// <returns>Query with SVs filtered by range.</returns>
    public static IQueryable<SV.VariantOccurrence> FilterByRange(this IQueryable<SV.VariantOccurrence> query, Chromosome chromosomeId, int start, int end)
    {
        // Temporarily ignoring intra- and cross- chromosomal translocations
        var ignoreTypes = new[] { SV.Enums.SvType.ITX, SV.Enums.SvType.CTX };

        // SV start and end positions are different from SSM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2

        return query
            .Where(occurrence => !ignoreTypes.Contains(occurrence.Variant.TypeId))
            .Where(occurrence => occurrence.Variant.ChromosomeId == chromosomeId && occurrence.Variant.OtherChromosomeId == chromosomeId)
            .Where(occurrence => (occurrence.Variant.OtherStart >= start && occurrence.Variant.OtherStart <= end) ||
                                 (occurrence.Variant.End >= start && occurrence.Variant.End <= end) ||
                                 (occurrence.Variant.End >= start && occurrence.Variant.OtherStart <= end) ||
                                 (occurrence.Variant.End <= start && occurrence.Variant.OtherStart >= end)
            );
    }
}
