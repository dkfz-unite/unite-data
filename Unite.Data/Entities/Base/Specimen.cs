using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Entities.Base;

public abstract record Specimen
{
    [Column("id")]
    public int Id { get; set; }
    [Column("reference_id")]
    public string ReferenceId { get; set; }
    [Column("donor_id")]
    public int DonorId { get; set; }
    [Column("creation_date")]
    public DateOnly? CreationDate { get; set; }
    [Column("creation_day")]
    public int? CreationDay { get; set; }

    public virtual Donor Donor { get; set; }
}

public abstract record Specimen<TType> : Specimen
    where TType : struct, Enum
{
    [Column("type_id")]
    public TType TypeId { get; set; }
}
