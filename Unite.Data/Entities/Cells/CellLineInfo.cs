using System;

namespace Unite.Data.Entities.Cells
{
    public class CellLineInfo
    {
        public int CellLineId { get; set; }
        public string DepositorName { get; set; }
        public string DepositorEstablishment { get; set; }
        public DateTime? EstablishmentYear { get; set; }
        public string FirstPublication { get; set; }
        public string Comments { get; set; }
        public string AtccLink { get; set; }
        public string ExPasyLink { get; set; }
    }
}
