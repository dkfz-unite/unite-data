using Unite.Data.Entities.Samples.Cells.Enums;

namespace Unite.Data.Entities.Samples.Cells
{
    public class CellLine
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public CellLineType? TypeId { get; set; }
        public Species? SpeciesId { get; set; }

        public virtual Sample Sample { get; set; }
        public virtual CellLineInfo Info { get; set; }
    }
}
