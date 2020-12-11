using System;
using Unite.Data.Entities.Cells;

namespace Unite.Data.Entities.Tasks
{
    public class CellLineIndexingTask
    {
        public int Id { get; set; }
        public int CellLineId { get; set; }
        public DateTime Date { get; set; }

        public virtual CellLine CellLine { get; set; }
    }
}
