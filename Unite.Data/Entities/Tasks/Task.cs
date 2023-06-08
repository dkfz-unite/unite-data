using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Entities.Tasks;

public record Task
{
    public long Id { get; set; }
    public SubmissionTaskType? SubmissionTypeId { get; set; }
    public AnnotationTaskType? AnnotationTypeId { get; set; }
    public IndexingTaskType? IndexingTypeId { get; set; }
    public string Target { get; set; }
    public string Data { get; set; }
    public DateTime Date { get; set; }
}
