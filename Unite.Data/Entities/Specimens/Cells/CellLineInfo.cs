using System;

namespace Unite.Data.Entities.Specimens.Cells
{
    public class CellLineInfo
    {
        public int SpecimenId { get; set; }

        public string Name { get; set; }
        public string DepositorName { get; set; }
        public string DepositorEstablishment { get; set; }
        public DateTime? EstablishmentDate { get; set; }
        public string PublicationId { get; set; }
        public string AtccId { get; set; }
        public string ExPasyId { get; set; }
    }
}
