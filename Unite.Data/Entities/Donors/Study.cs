using System.Collections.Generic;

namespace Unite.Data.Entities.Donors;

public class Study
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<StudyDonor> StudyDonors { get; set; }
}
