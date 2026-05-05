using System.ComponentModel;
using System.Runtime.Serialization;

namespace Unite.Data.Entities.Omics.Analysis.Enums;

public enum AnalysisType
{
    /// <summary>
    /// DNA - Whole Genome Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Variants can be called (SM, CNV, SV).
    /// </summary>
    [EnumMember(Value = "WGS")]
    [Description("Whole Genome Sequencing")]
    WGS = 1,

    /// <summary>
    /// DNA - Whole Exome Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Variants can be called (SM, CNV, SV).
    /// </summary>
    [EnumMember(Value = "WES")]
    [Description("Whole Exome Sequencing")]
    WES = 2,

    /// <summary>
    /// Bulk RNA Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Gene expression levels can be quantified.
    /// </summary>
    [EnumMember(Value = "RNASeq")]
    [Description("Bulk RNA Sequencing")]
    RNASeq = 3,

    /// <summary>
    /// Single Cell RNA Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Gene expression levels can be quantified for each cell.
    /// </summary>
    [EnumMember(Value = "scRNASeq")]
    [Description("Single Cell RNA Sequencing")]
    RNASeqSc = 4,

    /// <summary>
    /// Single Nucleus RNA Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Gene expression levels can be quantified for each cell nucleus.
    /// </summary>
    [EnumMember(Value = "snRNASeq")]
    [Description("Single Nucleus RNA Sequencing")]
    RNASeqSn = 5,

    /// <summary>
    /// Bulk ATAC Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Can be used to identify open chromatin regions.
    /// </summary>
    [EnumMember(Value = "ATACSeq")]
    [Description("Bulk ATAC Sequencing")]
    ATACSeq = 6,

    /// <summary>
    /// Single Cell ATAC Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Can be used to identify open chromatin regions for each cell.
    /// </summary>
    [EnumMember(Value = "scATACSeq")]
    [Description("Single Cell ATAC Sequencing")]
    ATACSeqSc = 7,

    /// <summary>
    /// Single Nucleus ATAC Sequencing.
    /// Produces a fastq file.
    /// Can be aligned to a reference genome.
    /// Can be used to identify open chromatin regions for each cell nucleus.
    /// </summary>
    [EnumMember(Value = "snATACSeq")]
    [Description("Single Nucleus ATAC Sequencing")]
    ATACSeqSn = 8,

    /// <summary>
    /// Illumina Infinium Methylation Arrays Assay.
    /// Produces IDAT files (Red and Green) from fluorescence intensity measurements.
    /// Can be used to quantify methylation levels (Beta and M-values) at predefined CpG sites.
    /// </summary>
    [EnumMember(Value = "MethArray")]
    [Description("Illumina Infinium Methylation Arrays Assay")]
    MethArray = 9,

    /// <summary>
    /// Whole Genome Bisulfite Sequencing.
    /// Produces a bisulfite-converted DNA sequence in fastq format.
    /// The fastq files reflect methylation status by showing converted/unconverted bases.
    /// Can be aligned to a reference genome.
    /// Can be used to quantify methylation levels (Beta and M-values).
    /// </summary>
    [EnumMember(Value = "WGBS")]
    [Description("Whole Genome Bisulfite Sequencing")]
    WGBS = 10,

    /// <summary>
    /// Reduced Representation Bisulfite Sequencing.
    /// Produces a bisulfite-converted DNA sequence in fastq format.
    /// The fastq files reflect methylation status by showing converted/unconverted bases.
    /// Can be aligned to a reference genome.
    /// Can be used to quantify methylation levels (Beta and M-values).
    /// </summary>
    [EnumMember(Value = "RRBS")]
    [Description("Reduced Representation Bisulfite Sequencing")]
    RRBS = 11,

    /// <summary>
    /// Mass Spectrometry.
    /// Produces raw mass spectrometry data files.
    /// Can be used to identify and quantify proteins and peptides in complex biological samples.
    /// </summary>
    [EnumMember(Value = "MS")]
    [Description("Mass Spectrometry")]
    MS = 12
}
