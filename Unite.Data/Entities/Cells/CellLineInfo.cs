using System;

namespace Unite.Data.Entities.Cells
{
    public class CellLineInfo
    {
        public long CellLineId { get; set; }

        public DateTime? EstablishmentDate { get; set; }
        public string DespositorName { get; set; }
        public string DespositorInstitute { get; set; }
        public string PMID { get; set; }

        public string ATCCLink { get; set; }
        public string ExPasyLink { get; set; }
    }
}
