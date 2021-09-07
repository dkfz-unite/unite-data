using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations.Enums
{
    internal static class AnalysisTypeModelBuilder
    {
        internal static void BuildAnalysisTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<AnalysisType>[]
            {
                AnalysisType.WGS.ToEnumValue(),
                AnalysisType.WES.ToEnumValue(),
                AnalysisType.WGA.ToEnumValue(),
                AnalysisType.RNASeq.ToEnumValue(),
                AnalysisType.Validation.ToEnumValue(),
                AnalysisType.Amplicon.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("AnalysisTypes", data);
        }
    }
}
