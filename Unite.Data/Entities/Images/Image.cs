using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Images.Analysis;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Entities.Images;

/// <summary>
/// Image. Image is a sample and can be analysed.
/// Image is an entity of specific image type: MRI or CT.
/// </summary>
public record Image : Base.Sample<ImageType>
{
    public int DonorId { get; set; }

    public virtual Donor Donor { get; set; }
    public virtual MriImage MriImage { get; set; }
    // public virtual CtImage CtImage { get; set; }
    public virtual ICollection<AnalysedSample> SampleAnalyses { get; set; }
}
