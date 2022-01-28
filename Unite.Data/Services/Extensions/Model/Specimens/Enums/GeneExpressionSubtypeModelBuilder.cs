using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Enums
{
    internal static class GeneExpressionSubtypeModelBuilder
    {
        internal static void BuildGeneExpressionSubtypeModel(this ModelBuilder modelBuilder)
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