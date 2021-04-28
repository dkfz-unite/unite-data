﻿using System.Collections.Generic;

namespace Unite.Data.Entities.Donors
{
    public class WorkPackage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<WorkPackageDonor> WorkPackageDonors { get; set; }
    }
}
