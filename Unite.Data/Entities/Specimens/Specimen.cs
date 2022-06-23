using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Genome.Mutations;
using Unite.Data.Entities.Specimens.Cells;
using Unite.Data.Entities.Specimens.Organoids;
using Unite.Data.Entities.Specimens.Tissues;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Entities.Specimens;

public class Specimen
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public int DonorId { get; set; }

    public DateTime? CreationDate { get; set; }
    public int? CreationDay { get; set; }

    public virtual Specimen Parent { get; set; }
    public virtual ICollection<Specimen> Children { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual Tissue Tissue { get; set; }
    public virtual CellLine CellLine { get; set; }
    public virtual Organoid Organoid { get; set; }
    public virtual Xenograft Xenograft { get; set; }
    public virtual MolecularData MolecularData { get; set; }

    public virtual ICollection<Sample> Samples { get; set; }
}
