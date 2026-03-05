using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Repositories;

public class CnvProfilesRepository(IDbContextFactory<DomainDbContext> dbContextFactory) : Repository(dbContextFactory)
{
    private readonly SpecimensRepository _specimensRepository = new SpecimensRepository(dbContextFactory);
    
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

        return await (
                from p in dbContext.CnvProfiles
                where ids.Contains(p.Id)
                join s in dbContext.OmicsSamples on p.SampleId equals s.Id
                join sp in dbContext.Specimens   on s.SpecimenId equals sp.Id
                where typeId == null || sp.TypeId == typeId
                select sp.Id
            )
            .Distinct()
            .ToArrayAsync();
    }
}