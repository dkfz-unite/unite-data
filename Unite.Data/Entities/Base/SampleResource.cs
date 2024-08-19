namespace Unite.Data.Entities.Base;

public abstract record SampleResource
{
    public int Id { get; set; }
    public int SampleId { get; set; }

    public string Type { get; set; }
    public string Format { get; set; }
    public string Archive { get; set; }
    public string Url { get; set; }
}
