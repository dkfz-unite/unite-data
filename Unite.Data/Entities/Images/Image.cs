﻿using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Images.Enums;
using Unite.Data.Entities.Images.Features;

namespace Unite.Data.Entities.Images;

public record Image
{
    public int Id { get; set; }
    public int DonorId { get; set; }

    public DateOnly? ScanningDate { get; set; }
    public int? ScanningDay { get; set; }

    public ImageType? Type => GetImageType();

    public virtual Donor Donor { get; set; }
    public virtual MriImage MriImage { get; set; }
    public virtual ICollection<AnalysedImage> ImageAnalyses { get; set; }


    private ImageType? GetImageType()
    {
        return MriImage != null ? ImageType.MRI
            //  : CtImage != null ? ImageType.CT
            : null;
    }
}
