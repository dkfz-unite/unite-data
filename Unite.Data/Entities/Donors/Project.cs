using System.Collections.Generic;

namespace Unite.Data.Entities.Donors;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<ProjectDonor> ProjectDonors { get; set; }
}
