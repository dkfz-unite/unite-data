using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Genome.Transcriptomics;

using SSM = Unite.Data.Entities.Genome.Variants.SSM;
using CNV = Unite.Data.Entities.Genome.Variants.CNV;
using SV = Unite.Data.Entities.Genome.Variants.SV;

namespace Unite.Data.Context.Extensions.Queryable;

public static class FilterExtensions
{   
    public static IQueryable<SSM.VariantEntry> FilterBySpecimenId(this IQueryable<SSM.VariantEntry> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSampleId));
    }

    public static IQueryable<CNV.VariantEntry> FilterBySpecimenId(this IQueryable<CNV.VariantEntry> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSampleId));
    }

    public static IQueryable<SV.VariantEntry> FilterBySpecimenId(this IQueryable<SV.VariantEntry> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSampleId));
    }

    public static IQueryable<BulkExpression> FilterBySpecimenId(this IQueryable<BulkExpression> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.AnalysedSample.TargetSampleId));
    }


    public static IQueryable<SSM.VariantEntry> FilterByRange(this IQueryable<SSM.VariantEntry> query, int chr, int? start, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId == chr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }

    public static IQueryable<CNV.VariantEntry> FilterByRange(this IQueryable<CNV.VariantEntry> query, int chr, int? start, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId == chr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }

    public static IQueryable<SV.VariantEntry> FilterByRange(this IQueryable<SV.VariantEntry> query, int chr, int? start, int? end)
    {
        // SV start and end positions are different from SSM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2
        
        var ignoreTypes = new[] { SV.Enums.SvType.ITX, SV.Enums.SvType.CTX };

        return query
            .Where(entry => !ignoreTypes.Contains(entry.Entity.TypeId))
            .Where(entry => 
                (int)entry.Entity.ChromosomeId == chr &&
                (int)entry.Entity.OtherChromosomeId == chr &&
                ((entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.OtherStart >= start && entry.Entity.OtherStart <= end) ||
                (entry.Entity.End <= start && entry.Entity.OtherStart >= end))
            );
    }

    public static IQueryable<BulkExpression> FilterByRange(this IQueryable<BulkExpression> query, int chr, int? start, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId == chr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }


    public static IQueryable<SSM.VariantEntry> FilterByRange(this IQueryable<SSM.VariantEntry> query, int startChr, int? start, int endChr, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId >= startChr &&
                (int)entry.Entity.ChromosomeId <= endChr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }

    public static IQueryable<CNV.VariantEntry> FilterByRange(this IQueryable<CNV.VariantEntry> query, int startChr, int? start, int endChr, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId >= startChr &&
                (int)entry.Entity.ChromosomeId <= endChr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }

    public static IQueryable<SV.VariantEntry> FilterByRange(this IQueryable<SV.VariantEntry> query, int startChr, int? start, int endChr, int? end)
    {
        // SV start and end positions are different from SSM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2
        
        var ignoreTypes = new[] { SV.Enums.SvType.ITX, SV.Enums.SvType.CTX };

        return query
            .Where(entry => !ignoreTypes.Contains(entry.Entity.TypeId))
            .Where(entry =>
                entry.Entity.ChromosomeId == entry.Entity.OtherChromosomeId &&
                (int)entry.Entity.ChromosomeId >= startChr &&
                (int)entry.Entity.ChromosomeId <= endChr &&
                ((entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.OtherStart >= start && entry.Entity.OtherStart <= end) ||
                (entry.Entity.End <= start && entry.Entity.OtherStart >= end))
            );
    }

    public static IQueryable<BulkExpression> FilterByRange(this IQueryable<BulkExpression> query, int startChr, int? start, int endChr, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId >= startChr &&
                (int)entry.Entity.ChromosomeId <= endChr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }
}
