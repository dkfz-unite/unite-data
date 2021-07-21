using Unite.Data.Entities.Clinical.Enums;

namespace Unite.Data.Entities.Clinical
{
    public class ClinicalData
    {
        public int? DonorId { get; set; }

        public Gender? GenderId { get; set; }
        public int? Age { get; set; }
        public string Diagnosis { get; set; }
        public int? PrimarySiteId { get; set; }
        public int? LocalizationId { get; set; }
        public bool? VitalStatus { get; set; }
        public int? VitalStatusChangeDay { get; set; }
        public int? KpsBaseline { get; set; }
        public bool? SteroidsBaseline { get; set; }

        public virtual TumorPrimarySite PrimarySite { get; set; }
        public virtual TumorLocalization Localization { get; set; }
    }
}
