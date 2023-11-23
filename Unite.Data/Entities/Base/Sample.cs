using Unite.Data.Entities.Donors;

namespace Unite.Data.Entities.Base;

public abstract record Sample
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }
    public int DonorId { get; set; }
    public DateOnly? CreationDate { get; set; }
    public int? CreationDay { get; set; }

    public Donor Donor { get; set; }
}

public abstract record Sample<TType> : Sample
    where TType : struct, Enum
{
    public TType TypeId { get; set; }
}
