using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Base;

public abstract record SampleResource
{
    [Column("id")]
    public int Id { get; set; }
    [Column("sample_id")]
    public int SampleId { get; set; }

    [Column("name")]
    public string Name { get; set; }
    [Column("type")]
    public string Type { get; set; }
    [Column("format")]
    public string Format { get; set; }
    [Column("archive")]
    public string Archive { get; set; }
    [Column("url")]
    public string Url { get; set; }
}
