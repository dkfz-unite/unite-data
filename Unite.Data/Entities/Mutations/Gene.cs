using System.Collections.Generic;

namespace Unite.Data.Entities.Mutations
{
    public class Gene
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Mutation> Mutations { get; set; }
    }
}
