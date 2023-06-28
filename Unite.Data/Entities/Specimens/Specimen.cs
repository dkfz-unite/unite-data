﻿using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Genome.Analysis;
using Unite.Data.Entities.Specimens.Cells;
using Unite.Data.Entities.Specimens.Enums;
using Unite.Data.Entities.Specimens.Organoids;
using Unite.Data.Entities.Specimens.Tissues;
using Unite.Data.Entities.Specimens.Xenografts;

namespace Unite.Data.Entities.Specimens;

public record Specimen
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public int DonorId { get; set; }

    public DateOnly? CreationDate { get; set; }
    public int? CreationDay { get; set; }

    public string ReferenceId => GetSpecimenId();
    public SpecimenType? Type => GetSpecimenType();

    public virtual Specimen Parent { get; set; }
    public virtual ICollection<Specimen> Children { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual Tissue Tissue { get; set; }
    public virtual CellLine CellLine { get; set; }
    public virtual Organoid Organoid { get; set; }
    public virtual Xenograft Xenograft { get; set; }
    public virtual MolecularData MolecularData { get; set; }

    public virtual ICollection<DrugScreening> DrugScreenings { get; set; }
    public virtual ICollection<Sample> Samples { get; set; }


    private string GetSpecimenId()
    {
        return Tissue != null ? Tissue.ReferenceId
             : CellLine != null ? CellLine.ReferenceId
             : Organoid != null ? Organoid.ReferenceId
             : Xenograft != null ? Xenograft.ReferenceId
             : throw new Exception("Could not determine specimen 'ReferenceId'. Most likely not all specific specimen tables were joined.");
    }

    private SpecimenType? GetSpecimenType()
    {
        return Tissue != null ? SpecimenType.Tissue
             : CellLine != null ? SpecimenType.CellLine
             : Organoid != null ? SpecimenType.Organoid
             : Xenograft != null ? SpecimenType.Xenograft
             : throw new Exception("Could not determine specimen 'Type'. Most likely not all specific specimen tables were joined.");
    }
}
