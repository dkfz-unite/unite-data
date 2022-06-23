using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;
using Unite.Data.Services.Models.Extensions;

namespace Unite.Data.Services.Mappers.Specimens.Enums;

internal class IdhMutationMapper : IEntityTypeConfiguration<EnumValue<IdhMutation>>
{
    public void Configure(EntityTypeBuilder<EnumValue<IdhMutation>> entity)
    {
        var data = new EnumValue<IdhMutation>[]
        {
            IdhMutation.IDH1_R132H.ToEnumValue(),
            IdhMutation.IDH1_R132C.ToEnumValue(),
            IdhMutation.IDH1_R132G.ToEnumValue(),
            IdhMutation.IDH1_R132L.ToEnumValue(),
            IdhMutation.IDH1_R132S.ToEnumValue(),
            IdhMutation.IDH2_R172G.ToEnumValue(),
            IdhMutation.IDH2_R172W.ToEnumValue(),
            IdhMutation.IDH2_R172K.ToEnumValue(),
            IdhMutation.IDH2_R172T.ToEnumValue(),
            IdhMutation.IDH2_R172M.ToEnumValue(),
            IdhMutation.IDH2_R172S.ToEnumValue()
        };

        entity.BuildEnumEntity("IdhMutations", DomainDbSchemaNames.Specimens, data);
    }
}
