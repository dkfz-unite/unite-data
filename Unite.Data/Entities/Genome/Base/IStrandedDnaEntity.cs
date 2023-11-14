namespace Unite.Data.Entities.Genome.Base;

public interface IStrandedDnaEntity : IDnaEntity
{
    bool? Strand { get; set; }
}
