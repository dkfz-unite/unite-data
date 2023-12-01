using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Genome.Enums;
using Unite.Data.Entities.Genome.Variants;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Context.Extensions.Queryable;

public static class VariantExtensions
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
        if (query is IQueryable<SSM.VariantEntry> ssmQuery)
            return FilterBySpecimenIds(ssmQuery, specimenIds) as IQueryable<TVE>;
        else if (query is IQueryable<CNV.VariantEntry> cnvQuery)
            return FilterBySpecimenIds(cnvQuery, specimenIds) as IQueryable<TVE>;
        else if (query is IQueryable<SV.VariantEntry> svQuery)
            return FilterBySpecimenIds(svQuery, specimenIds) as IQueryable<TVE>;

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
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSampleId));
    }

    /// <summary>
    /// Filters CNVs by specimen ids.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="specimenIds">Specimen ids.</param>
    /// <returns>Query with CNVs filtered by specimen ids.</returns>
    public static IQueryable<CNV.VariantEntry> FilterBySpecimenIds(this IQueryable<CNV.VariantEntry> query, IEnumerable<int> specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSampleId));
    }

    /// <summary>
    /// Filters SVs by specimen ids.
    /// </summary>
    /// <param name="query">Source query.</param>
    /// <param name="specimenIds">Specimen ids.</param>
    /// <returns>Query with SVs filtered by specimen ids.</returns>
    public static IQueryable<SV.VariantEntry> FilterBySpecimenIds(this IQueryable<SV.VariantEntry> query, IEnumerable<int> specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSampleId));
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
        if (query is IQueryable<SSM.VariantEntry> ssmQuery)
            return FilterByRange(ssmQuery, chromosomeId, start, end) as IQueryable<TVE>;
        else if (query is IQueryable<CNV.VariantEntry> cnvQuery)
            return FilterByRange(cnvQuery, chromosomeId, start, end) as IQueryable<TVE>;
        else if (query is IQueryable<SV.VariantEntry> svQuery)
            return FilterByRange(svQuery, chromosomeId, start, end) as IQueryable<TVE>;

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
    public static IQueryable<SSM.VariantEntry> FilterByRange(this IQueryable<SSM.VariantEntry> query, Chromosome chromosomeId, int start, int end)
    {
        return query.Where(entry => IsInRange(entry.Entity, chromosomeId, start, end));
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
        return query.Where(entry => IsInRange(entry.Entity, chromosomeId, start, end));
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

        return query
            .Where(entry => !ignoreTypes.Contains(entry.Entity.TypeId))
            .Where(entry => IsInRange(entry.Entity, chromosomeId, start, end));
    }


    private static bool IsInRange(SSM.Variant variant, Chromosome chromosomeId, int start, int end)
    {
        return variant.ChromosomeId == chromosomeId &&
               ((variant.End >= start && variant.End <= end) ||
               (variant.Start >= start && variant.Start <= end) ||
               (variant.Start >= start && variant.End <= end) ||
               (variant.Start <= start && variant.End >= end));
    }

    private static bool IsInRange(CNV.Variant variant, Chromosome chromosomeId, int start, int end)
    {
        return variant.ChromosomeId == chromosomeId &&
               ((variant.End >= start && variant.End <= end) ||
               (variant.Start >= start && variant.Start <= end) ||
               (variant.Start >= start && variant.End <= end) ||
               (variant.Start <= start && variant.End >= end));
    }

    private static bool IsInRange(SV.Variant variant, Chromosome chromosomeId, int start, int end)
    {
        // SV start and end positions are different from SSM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2

        return  variant.ChromosomeId == chromosomeId &&
                variant.OtherChromosomeId == chromosomeId &&
               ((variant.OtherStart >= start && variant.OtherStart <= end) ||
               (variant.End >= start && variant.End <= end) ||
               (variant.End >= start && variant.OtherStart <= end) ||
               (variant.End <= start && variant.OtherStart >= end));
    }
}
