using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Molecular.Enums
{
    public static class GeneExpressionSubtypeModelBuilder
    {
        public static void BuildGeneExpressionSubtypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<GeneExpressionSubtype>[]
            {
                GeneExpressionSubtype.Classical.ToEnumValue(),
                GeneExpressionSubtype.Mesenchymal.ToEnumValue(),
                GeneExpressionSubtype.Proneural.ToEnumValue()
            };

            modelBuilder.BuildEnumValueModel("GeneExpressionSubtypes", data);
        }
    }
}