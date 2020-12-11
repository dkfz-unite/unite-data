using System;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Entities.Tasks
{
    public class DonorIndexingTask
    {
        public int Id { get; set; }
        public string DonorId { get; set; }
        public DateTime Date { get; set; }

        public virtual Donor Donor { get; set; }
    }
}
