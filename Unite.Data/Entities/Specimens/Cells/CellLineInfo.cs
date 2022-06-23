using System;

namespace Unite.Data.Entities.Specimens.Cells;

public class CellLineInfo
{
    public int SpecimenId { get; set; }

    public string Name { get; set; }
    public string DepositorName { get; set; }
    public string DepositorEstablishment { get; set; }
    public DateTime? EstablishmentDate { get; set; }

    public string PubMedLink { get; set; }
    public string AtccLink { get; set; }
    public string ExPasyLink { get; set; }
}
