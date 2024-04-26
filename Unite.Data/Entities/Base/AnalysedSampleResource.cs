namespace Unite.Data.Entities.Base;

public abstract record AnalysedSampleResource
{
    public int Id { get; set; }
    public int AnalysedSampleId { get; set; }

    public string Type { get; set; }
    public string Path { get; set; }
    public string Url { get; set; }
}
