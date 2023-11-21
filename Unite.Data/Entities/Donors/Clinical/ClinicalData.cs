using Unite.Data.Entities.Donors.Clinical.Enums;

namespace Unite.Data.Entities.Donors.Clinical;

public record ClinicalData
{
    public int DonorId { get; set; }

    public Gender? GenderId { get; set; }
    public int? Age { get; set; }
    public string Diagnosis { get; set; }
    public DateOnly? DiagnosisDate { get; set; }
    public int? PrimarySiteId { get; set; }
    public int? LocalizationId { get; set; }
    public bool? VitalStatus { get; set; }
    public DateOnly? VitalStatusChangeDate { get; set; }
    public int? VitalStatusChangeDay { get; set; }
    public bool? ProgressionStatus { get; set; }
    public DateOnly? ProgressionStatusChangeDate { get; set; }
    public int? ProgressionStatusChangeDay { get; set; }
    public int? KpsBaseline { get; set; }
    public bool? SteroidsBaseline { get; set; }


    public virtual Donor Donor { get; set; }
    public virtual TumorPrimarySite PrimarySite { get; set; }
    public virtual TumorLocalization Localization { get; set; }
}
