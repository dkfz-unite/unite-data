using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Base.Entities;
using Unite.Data.Context.Mappers.Base.Entities.Extensions;
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
            SubmissionTaskType.MR.ToEnumValue(),
            SubmissionTaskType.IMG_RAD.ToEnumValue(),
            SubmissionTaskType.MAT.ToEnumValue(),
            SubmissionTaskType.LNE.ToEnumValue(),
            SubmissionTaskType.ORG.ToEnumValue(),
            SubmissionTaskType.XEN.ToEnumValue(),
            SubmissionTaskType.SPE_INT.ToEnumValue(),
            SubmissionTaskType.SPE_DRG.ToEnumValue(),
            SubmissionTaskType.DNA.ToEnumValue(),
            SubmissionTaskType.DNA_SM.ToEnumValue(),
            SubmissionTaskType.DNA_CNV.ToEnumValue(),
            SubmissionTaskType.DNA_SV.ToEnumValue(),
            SubmissionTaskType.METH.ToEnumValue(),
            SubmissionTaskType.METH_LVL.ToEnumValue(),
            SubmissionTaskType.RNA.ToEnumValue(),
            SubmissionTaskType.RNA_EXP.ToEnumValue(),
            SubmissionTaskType.RNASC.ToEnumValue(),
            SubmissionTaskType.RNASC_EXP.ToEnumValue(),        
            SubmissionTaskType.DNA_CNV_PROFILE.ToEnumValue()
        };

        entity.BuildEnumEntity("submission_task_types", DomainDbSchemaNames.Common, data);
    }
}
