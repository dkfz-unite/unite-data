namespace Unite.Data.Entities.Specimens.Xenografts
{
    public class XenograftIntervention
    {
        public int Id { get; set; }

        public int SpecimenId { get; set; }
        public int TypeId { get; set; }

        public string Details { get; set; }
        public int? StartDay { get; set; }
        public int? DurationDays { get; set; }
        public string Results { get; set; }

        public virtual XenograftInterventionType Type { get; set; }
    }
}
