using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Tasks.Enums;

namespace Unite.Data.Entities.Tasks;

public record Task
{
    [Column("id")]
    public long Id { get; set; }
    [Column("submission_type_id")]
    public SubmissionTaskType? SubmissionTypeId { get; set; }
    [Column("annotation_type_id")]
    public AnnotationTaskType? AnnotationTypeId { get; set; }
    [Column("indexing_type_id")]
    public IndexingTaskType? IndexingTypeId { get; set; }
    [Column("analysis_type_id")]
    public AnalysisTaskType? AnalysisTypeId { get; set; }
    [Column("task_status_type_id")]
    public TaskStatusType? StatusTypeId { get; set; }
    [Column("target")]
    public string Target { get; set; }
    [Column("data")]
    public string Data { get; set; }
    [Column("comment")]
    public string Comment { get; set; }
    [Column("date")]
    public DateTime Date { get; set; }
}
