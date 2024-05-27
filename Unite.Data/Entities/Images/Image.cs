using Unite.Data.Entities.Images.Analysis;
using Unite.Data.Entities.Images.Enums;

namespace Unite.Data.Entities.Images;

public record Image : Base.Specimen<ImageType>
{
    public virtual MriImage MriImage { get; set; }
    
    public virtual ICollection<Sample> Samples { get; set; }
}
