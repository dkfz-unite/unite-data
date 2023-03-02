namespace Unite.Data.Entities.Genome.Abstractions;

public interface IStrandedDnaEntity : IDnaEntity
{
    bool? Strand { get; set; }
}
