using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Images.Analysis;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Entities.Images;

public record Image
{
    public int Id { get; set; }
    public string ReferenceId { get; set; }
    public int DonorId { get; set; }
    public ImageType TypeId { get; set; }
    public DateOnly? ScanningDate { get; set; }
    public int? ScanningDay { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual MriImage MriImage { get; set; }
    
    public virtual ICollection<AnalysedImage> ImageAnalyses { get; set; }
}
