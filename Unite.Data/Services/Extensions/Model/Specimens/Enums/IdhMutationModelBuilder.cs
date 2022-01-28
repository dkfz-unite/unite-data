using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Services.Models;

namespace Unite.Data.Services.Extensions.Model.Specimens.Enums
{
    internal static class IdhMutationModelBuilder
    {
        internal static void BuildIdhMutationModel(this ModelBuilder modelBuilder)
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

            modelBuilder.BuildEnumValueModel("IdhMutations", data);
        }
    }
}
