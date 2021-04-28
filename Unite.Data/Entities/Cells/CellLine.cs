using Unite.Data.Entities.Cells.Enums;
using Unite.Data.Entities.Common.Enums;

namespace Unite.Data.Entities.Cells
{
    public class CellLine
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string DonorId { get; set; }

        public string Name { get; set; }
        public CellLineType TypeId { get; set; }
        public TumorType TumorTypeId { get; set; }
        public Species SpeciesId { get; set; }
    }
}
