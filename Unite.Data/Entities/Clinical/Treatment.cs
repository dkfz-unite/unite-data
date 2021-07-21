namespace Unite.Data.Entities.Clinical
{
    public class Treatment
    {
        public int Id { get; set; }

        public int DonorId { get; set; }
        public int TherapyId { get; set; }

        public string Details { get; set; }
        public int? StartDay { get; set; }
        public int? DurationDays { get; set; }
        public bool? ProgressionStatus { get; set; }
        public int? ProgressionStatusChangeDay { get; set; }
        public string Results { get; set; }

        public virtual Therapy Therapy { get; set; }
    }
}
