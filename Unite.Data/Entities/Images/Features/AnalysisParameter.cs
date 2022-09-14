namespace Unite.Data.Entities.Images.Features;

public class AnalysisParameter
{
    public int Id { get; set; }

    public string Name { get; set; }


    public virtual ICollection<AnalysisParameterOccurrence> ParameterOccurrences { get; set; }
}
