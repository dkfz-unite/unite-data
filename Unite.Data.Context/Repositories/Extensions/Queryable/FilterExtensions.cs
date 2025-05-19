using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Omics.Analysis.Rna;

using Sm = Unite.Data.Entities.Omics.Analysis.Dna.Sm;
using Cnv = Unite.Data.Entities.Omics.Analysis.Dna.Cnv;
using Sv = Unite.Data.Entities.Omics.Analysis.Dna.Sv;

namespace Unite.Data.Context.Extensions.Queryable;

public static class FilterExtensions
{   
    public static IQueryable<Sm.VariantEntry> FilterBySpecimenId(this IQueryable<Sm.VariantEntry> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.Sample.SpecimenId));
    }

    public static IQueryable<Cnv.VariantEntry> FilterBySpecimenId(this IQueryable<Cnv.VariantEntry> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.Sample.SpecimenId));
    }

    public static IQueryable<Sv.VariantEntry> FilterBySpecimenId(this IQueryable<Sv.VariantEntry> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.Sample.SpecimenId));
    }

    public static IQueryable<GeneExpression> FilterBySpecimenId(this IQueryable<GeneExpression> query, params int[] specimenIds)
    {
        return query.Where(entry => specimenIds.Contains(entry.Sample.SpecimenId));
    }


    public static IQueryable<Sm.VariantEntry> FilterByRange(this IQueryable<Sm.VariantEntry> query, int chr, int? start, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId == chr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }

    public static IQueryable<Cnv.VariantEntry> FilterByRange(this IQueryable<Cnv.VariantEntry> query, int chr, int? start, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId == chr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }

    public static IQueryable<Sv.VariantEntry> FilterByRange(this IQueryable<Sv.VariantEntry> query, int chr, int? start, int? end)
    {
        // SV start and end positions are different from SM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2
        
        var ignoreTypes = new[] { Sv.Enums.SvType.ITX, Sv.Enums.SvType.CTX };

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

    public static IQueryable<GeneExpression> FilterByRange(this IQueryable<GeneExpression> query, int chr, int? start, int? end)
    {
        return query
            .Where(entry => 
                (int)entry.Entity.ChromosomeId == chr &&
                ((entry.Entity.Start >= start && entry.Entity.Start <= end) ||
                (entry.Entity.End >= start && entry.Entity.End <= end) ||
                (entry.Entity.Start <= start && entry.Entity.End >= end))
            );
    }


    public static IQueryable<Sm.VariantEntry> FilterByRange(this IQueryable<Sm.VariantEntry> query, int startChr, int? start, int endChr, int? end)
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

    public static IQueryable<Cnv.VariantEntry> FilterByRange(this IQueryable<Cnv.VariantEntry> query, int startChr, int? start, int endChr, int? end)
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

    public static IQueryable<Sv.VariantEntry> FilterByRange(this IQueryable<Sv.VariantEntry> query, int startChr, int? start, int endChr, int? end)
    {
        // SV start and end positions are different from SM and CNV
        // Modified genome is located between two breakpoints, which are represented as bands with start and end positions
        // Breakpoint 1 (Chromosome1, S1, E1) - start and end positions of the first breakpoint (Variant.ChromosomeId, Variant.Start, Variant.End)
        // Breakpoint 2 (Chromosome2, S2, E2) - start and end positions of the second breakpoint (Variant.OtherChromosomeId, Variant.OtherStart, Variant.OtherEnd)
        // Excluding translocations, modified genome is located between E1 and S2 (Variant.End and Variant.OtherStart)
        // ------------| |------------| |------------
        //            S1 E1          S2 E2
        
        var ignoreTypes = new[] { Sv.Enums.SvType.ITX, Sv.Enums.SvType.CTX };

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

    public static IQueryable<GeneExpression> FilterByRange(this IQueryable<GeneExpression> query, int startChr, int? start, int endChr, int? end)
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
