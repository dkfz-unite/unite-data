﻿using System.Collections.Generic;

namespace Unite.Data.Entities.Specimens.Organoids
{
    public class Organoid
    {
        public int SpecimenId { get; set; }
        public string ReferenceId { get; set; }

        public int? ImplantedCellsNumber { get; set; }
        public bool? Tumorigenicity { get; set; }
        public string Medium { get; set; }

        public virtual ICollection<OrganoidIntervention> Interventions { get; set; }
    }
}
