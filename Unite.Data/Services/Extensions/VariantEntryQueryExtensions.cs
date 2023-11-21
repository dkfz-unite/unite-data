using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Services.Extensions;

public static class VariantEntryQueryExtensions
{
    /// <summary>
    /// Filters variants by specimen ids.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="specimenIds">Specimen ids.</param>
    /// <typeparam name="TVE">Variant occurrence type.</typeparam>
    /// <typeparam name="TV">Variant type.</typeparam>
    /// <returns>Query with variants filtered by specimen ids.</returns>
    public static IQueryable<TVE> FilterBySpecimenIds<TVE, TV>(this IQueryable<TVE> query, IEnumerable<int> specimenIds)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        if (typeof(TVE) == typeof(SSM.VariantEntry))
        {
            return FilterBySpecimenIds((IQueryable<SSM.VariantEntry>)query, specimenIds).Cast<TVE>();
        }
        else if (typeof(TVE) == typeof(CNV.VariantEntry))
        {
            return FilterBySpecimenIds((IQueryable<CNV.VariantEntry>)query, specimenIds).Cast<TVE>();
        }
        else if (typeof(TVE) == typeof(SV.VariantEntry))
        {
            return FilterBySpecimenIds((IQueryable<SV.VariantEntry>)query, specimenIds).Cast<TVE>();
        }

        throw new ArgumentException($"Unsupported variant type: {typeof(TV).Name}");
    }

    /// <summary>
    /// Filters SSMs by specimen ids.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="specimenIds">Specimen ids.</param>
    /// <returns>Query with SSMs filtered by specimen ids.</returns>
    public static IQueryable<SSM.VariantEntry> FilterBySpecimenIds(this IQueryable<SSM.VariantEntry> query, IEnumerable<int> specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSample.SpecimenId));
    }

    /// <summary>
    /// Filters CNVs by specimen ids.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="specimenIds">Specimen ids.</param>
    /// <returns>Query with CNVs filtered by specimen ids.</returns>
    public static IQueryable<CNV.VariantEntry> FilterBySpecimenIds(this IQueryable<CNV.VariantEntry> query, IEnumerable<int> specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSample.SpecimenId));
    }

    /// <summary>
    /// Filters SVs by specimen ids.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="specimenIds">Specimen ids.</param>
    /// <returns>Query with SVs filtered by specimen ids.</returns>
    public static IQueryable<SV.VariantEntry> FilterBySpecimenIds(this IQueryable<SV.VariantEntry> query, IEnumerable<int> specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSample.SpecimenId));
    }


    /// <summary>
    /// Filters variants by range.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="chromosomeId">Range chromosome.</param>
    /// <param name="start">Range start.</param>
    /// <param name="end">Range end.</param>
    /// <typeparam name="TVE">Variant occurrence type.</typeparam>
    /// <typeparam name="TV">Variant type.</typeparam>
    /// <returns>Query with variants filtered by range.</returns>
    public static IQueryable<TVE> FilterByRange<TVE, TV>(this IQueryable<TVE> query, Chromosome chromosomeId, int start, int end)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        if (typeof(TVE) == typeof(SSM.VariantEntry))
        {
            return FilterByRange((IQueryable<SSM.VariantEntry>)query, chromosomeId, start, end).Cast<TVE>();
        }
        else if (typeof(TVE) == typeof(CNV.VariantEntry))
        {
            return FilterByRange((IQueryable<CNV.VariantEntry>)query, chromosomeId, start, end).Cast<TVE>();
        }
        else if (typeof(TVE) == typeof(SV.VariantEntry))
        {
            return FilterByRange((IQueryable<SV.VariantEntry>)query, chromosomeId, start, end).Cast<TVE>();
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
    public static IQueryable<SSM.VariantEntry> FilterByRange(this  IQueryable<SSM.VariantEntry> query, Chromosome chromosomeId, int start, int end)
    {
        return query
            .Where(entry => entry.Variant.ChromosomeId == chromosomeId)
            .Where(entry => (entry.Variant.End >= start && entry.Variant.End <= end) ||
                                 (entry.Variant.Start >= start && entry.Variant.Start <= end) ||
                                 (entry.Variant.Start >= start && entry.Variant.End <= end) ||
                                 (entry.Variant.Start <= start && entry.Variant.End >= end));
    }

    /// <summary>
    /// Filters CNVs by range.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="chromosomeId">Range chromosome.</param>
    /// <param name="start">Range start.</param>
    /// <param name="end">Range end.</param>
    /// <returns>Query with CNVs filtered by range.</returns>
    public static IQueryable<CNV.VariantEntry> FilterByRange(this IQueryable<CNV.VariantEntry> query, Chromosome chromosomeId, int start, int end)
    {
        return query
            .Where(entry => entry.Variant.ChromosomeId == chromosomeId)
            .Where(entry => (entry.Variant.End >= start && entry.Variant.End <= end) ||
                                 (entry.Variant.Start >= start && entry.Variant.Start <= end) ||
                                 (entry.Variant.Start >= start && entry.Variant.End <= end) ||
                                 (entry.Variant.Start <= start && entry.Variant.End >= end));
    }

    /// <summary>
    /// Filters SVs by range.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="chromosomeId">Range chromosome.</param>
    /// <param name="start">Range start.</param>
    /// <param name="end">Range end.</param>
    /// <returns>Query with SVs filtered by range.</returns>
    public static IQueryable<SV.VariantEntry> FilterByRange(this IQueryable<SV.VariantEntry> query, Chromosome chromosomeId, int start, int end)
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
            .Where(entry => !ignoreTypes.Contains(entry.Variant.TypeId))
            .Where(entry => entry.Variant.ChromosomeId == chromosomeId && entry.Variant.OtherChromosomeId == chromosomeId)
            .Where(entry => (entry.Variant.OtherStart >= start && entry.Variant.OtherStart <= end) ||
                                 (entry.Variant.End >= start && entry.Variant.End <= end) ||
                                 (entry.Variant.End >= start && entry.Variant.OtherStart <= end) ||
                                 (entry.Variant.End <= start && entry.Variant.OtherStart >= end)
            );
    }
}
