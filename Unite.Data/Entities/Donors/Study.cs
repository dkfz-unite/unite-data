namespace Unite.Data.Entities.Donors;

public class Study
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<StudyDonor> StudyDonors { get; set; }
}
