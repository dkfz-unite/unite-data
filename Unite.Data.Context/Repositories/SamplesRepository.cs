using Microsoft.EntityFrameworkCore;
using Unite.Data.Constants;
using Unite.Data.Entities.Omics.Analysis;
using Unite.Data.Entities.Omics.Analysis.Dna;
using Unite.Data.Entities.Omics.Analysis.Prot;
using Unite.Data.Entities.Omics.Analysis.Rna;

using Sm = Unite.Data.Entities.Omics.Analysis.Dna.Sm;
using Cnv = Unite.Data.Entities.Omics.Analysis.Dna.Cnv;
using Sv = Unite.Data.Entities.Omics.Analysis.Dna.Sv;

namespace Unite.Data.Context.Repositories;

public class SamplesRepository : Repository
{
    public record OmicsResources(bool Sm, bool Cnv, bool Sv, bool Meth, bool GeneExp, bool GeneExpSc, bool ProtExp);

    public SamplesRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
    }


    public async Task<OmicsResources> HasRelatedOmicsResources(int id)
    {
        var sm = await HasRelatedVariants<Sm.VariantEntry, Sm.Variant>(id);
        var cnv = await HasRelatedVariants<Cnv.VariantEntry, Cnv.Variant>(id);
        var sv = await HasRelatedVariants<Sv.VariantEntry, Sv.Variant>(id);
        var meth = await HasRelatedMethylations(id);
        var geneExp = await HasRelatedGeneExpressions(id);
        var geneExpSc = await HasRelatedGeneExpressionsPerCells(id);
        var protExp = await HasRelatedProteinExpressions(id);

        if (sm || cnv || sv || meth || geneExp || geneExpSc || protExp)
            return new OmicsResources(sm, cnv, sv, meth, geneExp, geneExpSc, protExp);
        
        return null;
    }

    public async Task<bool> HasRelatedVariants<TVE, TV>(int id)
        where TVE : VariantEntry<TV>
        where TV : Variant
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<TVE>()
            .AsNoTracking()
            .AnyAsync(entry => entry.SampleId == id);
    }

    public async Task<bool> HasRelatedProfiles(int id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<Cnv.Profile>()
            .AsNoTracking()
            .AnyAsync(profile => profile.SampleId == id);
    }

    public async Task<bool> HasRelatedMethylations(int id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<SampleResource>()
            .AsNoTracking()
            .AnyAsync(resource => resource.SampleId == id
                               && resource.Type == DataTypes.Omics.Methylation.Sample
                               && resource.Format == FileTypes.Sequence.Idat);
    }

    public async Task<bool> HasRelatedGeneExpressions(int id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<GeneExpression>()
            .AsNoTracking()
            .AnyAsync(expression => expression.SampleId == id);
    }

    public async Task<bool> HasRelatedGeneExpressionsPerCells(int id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<SampleResource>()
            .AsNoTracking()
            .AnyAsync(resource => resource.SampleId == id
                               && resource.Type == DataTypes.Omics.Rnasc.Expression);
    }

    public async Task<bool> HasRelatedProteinExpressions(int id)
    {
        using var dbContext = _dbContextFactory.CreateDbContext();

        return await dbContext.Set<ProteinExpression>()
            .AsNoTracking()
            .AnyAsync(expression => expression.SampleId == id);
    }
}
