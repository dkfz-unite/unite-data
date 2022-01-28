using System.Collections.Generic;
using Unite.Data.Entities.Donors;

namespace Unite.Data.Entities.Radiology
{
    public class Image
    {
        public int Id { get; set; }
        public int DonorId { get; set; }

        public int? ScanningDay { get; set; }


        public virtual Donor Donor { get; set; }
        public virtual MriImage MriImage { get; set; }

        public virtual ICollection<AnalysedImage> ImageAnalyses { get; set; }
    }
}
