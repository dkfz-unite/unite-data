using System;

namespace Unite.Data.Entities.Specimens.Organoids
{
    public class Intervention
    {
        public int Id { get; set; }

        public int SpecimenId { get; set; }

        public int TypeId { get; set; }

        public string Details { get; set; }

        public DateTime? StartDate { get; set; }
        public int? StartDay { get; set; }

        public DateTime? EndDate { get; set; }
        public int? DurationDays { get; set; }

        public string Results { get; set; }


        public virtual InterventionType Type { get; set; }
    }
}
