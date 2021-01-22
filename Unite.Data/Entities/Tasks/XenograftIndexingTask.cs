using System;
using Unite.Data.Entities.Xenografts;

namespace Unite.Data.Entities.Tasks
{
    public class XenograftIndexingTask
    {
        public int Id { get; set; }
        public int XenograftId { get; set; }
        public DateTime Date { get; set; }

        public virtual Xenograft Xenograft { get; set; }
    }
}
