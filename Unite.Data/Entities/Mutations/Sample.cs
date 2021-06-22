using System;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Entities.Mutations
{
    public class Sample
    {
        public int Id { get; set; }

        public int SpecimenId { get; set; }

        public DateTime? Date { get; set; }

        public virtual Specimen Specimen { get; set; }
    }
}
