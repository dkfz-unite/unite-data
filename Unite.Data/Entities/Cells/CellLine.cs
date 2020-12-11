using System.Collections.Generic;
using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Samples;

namespace Unite.Data.Entities.Cells
{
    public class CellLine
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string DonorId { get; set; }
        public string Name { get; set; }
        public CellLineType? TypeId { get; set; }
        public Species? SpeciesId { get; set; }
        public GeneExpressionSubtype? GeneExpressionSubtypeId { get; set; }
        public IDHStatus? IdhStatusId { get; set; }
        public IDHMutation? IdhMutationId { get; set; }
        public MethylationStatus? MethylationStatusId { get; set; }
        public MethylationSubtype? MethylationSubtypeId { get; set; }
        public bool? GcimpMethylation { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual CellLine Parent { get; set; }
        public virtual ICollection<CellLine> Childern { get; set; }
        public virtual CellLineInfo CellLineInfo { get; set; }

        public virtual ICollection<Sample> Samples { get; set; }
    }
}
