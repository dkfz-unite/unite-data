using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Donors.Clinical;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Donors;

public record Donor
{
    [Column("id")]
    public int Id { get; set; }
    [Column("reference_id")]
    public string ReferenceId { get; set; }

    [Column("mta_protected")]
    public bool? MtaProtected { get; set; }

    public virtual ClinicalData ClinicalData { get; set; }
    public virtual ICollection<Treatment> Treatments { get; set; }
    public virtual ICollection<Image> Images { get; set; }
    public virtual ICollection<Specimen> Specimens { get; set; }
    public virtual ICollection<ProjectDonor> DonorProjects { get; set; }
    public virtual ICollection<StudyDonor> DonorStudies { get; set; }
}
