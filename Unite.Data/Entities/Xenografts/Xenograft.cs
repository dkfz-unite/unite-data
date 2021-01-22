using Unite.Data.Entities.Xenografts.Enums;

namespace Unite.Data.Entities.Xenografts
{
    public class Xenograft
    {
        public int Id { get; set; }
        public int CellLineId { get; set; }

        public int MouseStrainId { get; set; }
        public int GroupSize { get; set; }
        public int SurvivalDays { get; set; }

        public ImplantType ImplantTypeId { get; set; }
        public TissueLocation TissueLocationId { get; set; }
        public int ImplantedCellsNumber { get; set; }

        public string InterventionType { get; set; }
        public string InterventionStartPoint { get; set; }
        public string InterventionManipulation { get; set; }

        public bool Tumorigenicity { get; set; }
        public GrowthForm GrowthFormId { get; set; }
        public TumorSize TumorSizeId { get; set; }
    }
}
