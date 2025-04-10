using System.ComponentModel.DataAnnotations.Schema;

namespace Unite.Data.Entities.Images;

public record MrImage
{
    [Column("image_id")]
    public int ImageId { get; set; }

    [Column("whole_tumor")]
    public double? WholeTumor { get; set; }
    [Column("contrast_enhancing")]
    public double? ContrastEnhancing { get; set; }
    [Column("non_contrast_enhancing")]
    public double? NonContrastEnhancing { get; set; }

    [Column("median_adc_tumor")]
    public double? MedianAdcTumor { get; set; }
    [Column("median_adc_ce")]
    public double? MedianAdcCe { get; set; }
    [Column("median_adc_edema")]
    public double? MedianAdcEdema { get; set; }

    [Column("median_cbf_tumor")]
    public double? MedianCbfTumor { get; set; }
    [Column("median_cbf_ce")]
    public double? MedianCbfCe { get; set; }
    [Column("median_cbf_edema")]
    public double? MedianCbfEdema { get; set; }

    [Column("median_cbv_tumor")]
    public double? MedianCbvTumor { get; set; }
    [Column("median_cbv_ce")]
    public double? MedianCbvCe { get; set; }
    [Column("median_cbv_edema")]
    public double? MedianCbvEdema { get; set; }

    [Column("median_mtt_tumor")]
    public double? MedianMttTumor { get; set; }
    [Column("median_mtt_ce")]
    public double? MedianMttCe { get; set; }
    [Column("median_mtt_edema")]
    public double? MedianMttEdema { get; set; }


    public virtual Image Image { get; set; }
}
