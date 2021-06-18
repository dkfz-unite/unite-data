using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Molecular.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Molecular.Enums
{
    public static class IdhMutationModelBuilder
    {
        public static void BuildIdhMutationModel(this ModelBuilder modelBuilder)
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
