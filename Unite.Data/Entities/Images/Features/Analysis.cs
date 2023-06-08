using Unite.Data.Entities.Images.Features.Enums;

namespace Unite.Data.Entities.Images.Features;

public record Analysis
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }

    public AnalysisType? TypeId { get; set; }
    public DateOnly? Date { get; set; }
    public Dictionary<string, string> Parameters { get; set; }


    public virtual AnalysedImage AnalysedImage { get; set; }
}
