namespace Unite.Data.Entities.Donors;

public class Project
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<ProjectDonor> ProjectDonors { get; set; }
}
