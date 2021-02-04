﻿using System;
using System.Collections.Generic;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Mutations.Enums;

namespace Unite.Data.Entities.Mutations
{
    public class Analysis
    {
        public int Id { get; set; }
        public string DonorId { get; set; }
        public string Name { get; set; }
        public AnalysisType? TypeId { get; set; }
        public DateTime? Date { get; set; }
        public int? FileId { get; set; }

        public virtual Donor Donor { get; set; }
        public virtual File File { get; set; }
        public virtual ICollection<AnalysedSample> AnalysedSamples { get; set; }
    }
}