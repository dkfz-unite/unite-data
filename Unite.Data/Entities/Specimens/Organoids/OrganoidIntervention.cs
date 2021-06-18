namespace Unite.Data.Entities.Specimens.Organoids
{
    public class OrganoidIntervention
    {
        public int Id { get; set; }

        public int SpecimenId { get; set; }
        public int TypeId { get; set; }

        public string Details { get; set; }
        public int? StartDay { get; set; }
        public int? DurationDays { get; set; }
        public string Results { get; set; }

        public virtual OrganoidInterventionType Type { get; set; }
    }
}
