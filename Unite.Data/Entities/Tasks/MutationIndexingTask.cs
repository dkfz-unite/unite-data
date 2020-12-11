using System;
using Unite.Data.Entities.Mutations;

namespace Unite.Data.Entities.Tasks
{
    public class MutationIndexingTask
    {
        public int Id { get; set; }
        public int MutationId { get; set; }
        public DateTime Date { get; set; }

        public virtual Mutation Mutation { get; set; }
    }
}
