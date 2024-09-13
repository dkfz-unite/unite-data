using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Context.Mappers.Tasks.Enums;

internal class SubmissionTaskTypeMapper : IEntityTypeConfiguration<EnumEntity<SubmissionTaskType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<SubmissionTaskType>> entity)
    {
        var data = new EnumEntity<SubmissionTaskType>[]
        {
            SubmissionTaskType.DON.ToEnumValue(),
            SubmissionTaskType.DON_TRT.ToEnumValue(),
            SubmissionTaskType.MRI.ToEnumValue(),
            SubmissionTaskType.IMG_RAD.ToEnumValue(),
            SubmissionTaskType.MAT.ToEnumValue(),
            SubmissionTaskType.LNE.ToEnumValue(),
            SubmissionTaskType.ORG.ToEnumValue(),
            SubmissionTaskType.XEN.ToEnumValue(),
            SubmissionTaskType.SPE_INT.ToEnumValue(),
            SubmissionTaskType.SPE_DRG.ToEnumValue(),
            SubmissionTaskType.DNA_SSM.ToEnumValue(),
            SubmissionTaskType.DNA_CNV.ToEnumValue(),
            SubmissionTaskType.DNA_SV.ToEnumValue(),
            SubmissionTaskType.RNA_EXP.ToEnumValue(),
            SubmissionTaskType.RNASC_EXP.ToEnumValue()          
        };

        entity.BuildEnumEntity("SubmissionTaskTypes", DomainDbSchemaNames.Common, data);
    }
}
