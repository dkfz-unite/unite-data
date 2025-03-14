namespace Unite.Data.Entities.Donors;

public record Project
{
    public const string DefaultName = "Other";

    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<ProjectDonor> ProjectDonors { get; set; }
}
