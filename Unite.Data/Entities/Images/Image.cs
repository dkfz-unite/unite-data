using System;
using System.Collections.Generic;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Entities.Images
{
    public class Image
    {
        public int Id { get; set; }
        public int DonorId { get; set; }

        public DateTime? ScanningDate { get; set; }
        public int? ScanningDay { get; set; }


        public virtual Donor Donor { get; set; }
        public virtual MriImage MriImage { get; set; }
        public virtual ICollection<AnalysedImage> ImageAnalyses { get; set; }
    }
}
