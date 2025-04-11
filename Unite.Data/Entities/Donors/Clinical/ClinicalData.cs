using System.ComponentModel.DataAnnotations.Schema;
using Unite.Data.Entities.Donors.Clinical.Enums;

namespace Unite.Data.Entities.Donors.Clinical;

public record ClinicalData
{
    [Column("donor_id")]
    public int DonorId { get; set; }

    [Column("sex_id")]
    public Sex? SexId { get; set; }
    [Column("enrollment_date")]
    public DateOnly? EnrollmentDate { get; set; }
    [Column("enrollment_age")]
    public int? EnrollmentAge { get; set; }
    [Column("diagnosis")]
    public string Diagnosis { get; set; }
    [Column("primary_site_id")]
    public int? PrimarySiteId { get; set; }
    [Column("localization_id")]
    public int? LocalizationId { get; set; }
    [Column("vital_status")]
    public bool? VitalStatus { get; set; }
    [Column("vital_status_change_date")]
    public DateOnly? VitalStatusChangeDate { get; set; }
    [Column("vital_status_change_day")]
    public int? VitalStatusChangeDay { get; set; }
    [Column("progression_status")]
    public bool? ProgressionStatus { get; set; }
    [Column("progression_status_change_date")]
    public DateOnly? ProgressionStatusChangeDate { get; set; }
    [Column("progression_status_change_day")]
    public int? ProgressionStatusChangeDay { get; set; }
    [Column("steroids_reactive")]
    public bool? SteroidsReactive { get; set; }
    [Column("kps")]
    public int? Kps { get; set; }
    

    public virtual Donor Donor { get; set; }
    public virtual TumorPrimarySite PrimarySite { get; set; }
    public virtual TumorLocalization Localization { get; set; }
}
