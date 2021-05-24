using Unite.Data.Entities.Specimens.Cells.Enums;

namespace Unite.Data.Entities.Specimens.Cells
{
    public class CellLine
    {
        public int SpecimenId { get; set; }

        public string ReferenceId { get; set; }
        public string Name { get; set; }
        public CellLineType? TypeId { get; set; }
        public Species? SpeciesId { get; set; }

        public virtual CellLineInfo Info { get; set; }
    }
}
