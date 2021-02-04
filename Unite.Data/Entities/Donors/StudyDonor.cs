﻿namespace Unite.Data.Entities.Donors
{
    public class StudyDonor
    {
        public int StudyId { get; set; }
        public string DonorId { get; set; }

        public virtual Study Study { get; set; }
        public virtual Donor Donor { get; set; }
    }
}