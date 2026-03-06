using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Omics.Analysis.Dna.Cnv;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Repositories;

public class CnvProfilesRepository : Repository
{
    private readonly SpecimensRepository _specimensRepository;


    public CnvProfilesRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : base(dbContextFactory)
    {
        _specimensRepository = new SpecimensRepository(dbContextFactory);
    }


    public async Task<int[]> GetRelatedProjects(IEnumerable<int> ids)
    {
        var donors = await GetRelatedDonors(ids);

        return await GetDonorRelatedProjects(donors);
    }

    public async Task<int[]> GetRelatedDonors(IEnumerable<int> ids)
    {
        var specimens = await GetRelatedSpecimens(ids);

        return await _specimensRepository.GetRelatedDonors(specimens);
    }
    
    public async Task<int[]> GetRelatedImages(IEnumerable<int> ids, ImageType? typeId = null)
    {
        var specimens = await GetRelatedSpecimens(ids, SpecimenType.Material);

        return await _specimensRepository.GetRelatedImages(specimens, typeId);
    }
    
    public async Task<int[]> GetRelatedSpecimens(IEnumerable<int> ids, SpecimenType? typeId = null)
    {
        await using var dbContext = await _dbContextFactory.CreateDbContextAsync();

        return await dbContext.Set<Profile>()
            .AsNoTracking()
            .Where(profile => typeId == null || profile.Sample.Specimen.TypeId == typeId)
            .Where(profile => ids.Contains(profile.Id))
            .Select(profile => profile.Sample.Specimen.Id)
            .Distinct()
            .ToArrayAsync();
    }
}
