using System;
using Unite.Data.Entities.Donors.Enums;

namespace Unite.Data.Entities.Donors
{
    public class ClinicalData
    {
        public string DonorId { get; set; }
        public Gender? GenderId { get; set; }
        public int? Age { get; set; }
        public AgeCategory? AgeCategoryId { get; set; }
        public int? LocalizationId { get; set; }
        public VitalStatus? VitalStatusId { get; set; }
        public DateTime? VitalStatusChangeDate { get; set; }
        public int? SurvivalDays { get; set; }
        public DateTime? ProgressionDate { get; set; }
        public int? ProgressionFreeDays { get; set; }
        public DateTime? RelapseDate { get; set; }
        public int? RelapseFreeDays { get; set; }
        public int? KpsBaseline { get; set; }
        public bool? SteroidsBaseline { get; set; }

        public virtual Localization Localization { get; set; }
    }
}
