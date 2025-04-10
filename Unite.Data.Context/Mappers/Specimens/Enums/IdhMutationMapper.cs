using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
using Unite.Data.Entities.Specimens.Enums;

namespace Unite.Data.Context.Mappers.Specimens.Enums;

internal class IdhMutationMapper : IEntityTypeConfiguration<EnumEntity<IdhMutation>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<IdhMutation>> entity)
    {
        var data = new EnumEntity<IdhMutation>[]
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

        entity.BuildEnumEntity("idh_mutation", DomainDbSchemaNames.Specimens, data);
    }
}
