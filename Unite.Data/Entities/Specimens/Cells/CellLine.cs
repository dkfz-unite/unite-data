using Unite.Data.Entities.Specimens.Cells.Enums;

namespace Unite.Data.Entities.Specimens.Cells
{
    public class CellLine
    {
        public int SpecimenId { get; set; }
        public string ReferenceId { get; set; }

        public Species? SpeciesId { get; set; }
        public CellLineType? TypeId { get; set; }
        public CellLineCultureType? CultureTypeId { get; set; }
        public string PassageNumber { get; set; }

        public virtual CellLineInfo Info { get; set; }
    }
}
