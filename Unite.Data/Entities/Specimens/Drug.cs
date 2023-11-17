using Unite.Data.Entities.Base;

namespace Unite.Data.Entities.Specimens;

public record Drug : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}
