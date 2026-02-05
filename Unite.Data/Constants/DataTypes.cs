namespace Unite.Data.Constants;

public static class DataTypes
{
    // don
    // dont-trt
    // mr
    // ct
    // img-rad
    // mat
    // lne
    // org
    // xen
    // spe-int
    // spe-drg
    // dna
    // dna-sm
    // dna-cnv
    // dna-cnvp
    // dna-sv
    // meth
    // meth-lvl
    // rna
    // rna-exp
    // rnasc
    // rnasc-exp
    // prot
    // prot-exp

    public static class Donor
    {
        public const string Entry = "don"; // Donors with clinical data
        public const string Treatment = "don-trt"; // Treatments
    }

    public static class Image
    {
        public static class Entry
        {
            public const string Mr = "mr"; // MR images
            public const string Ct = "ct"; // CT images
        }

        public const string Feature = "img-rad"; // Radiomics features (RFE analysis)
    }

    public static class Specimen
    {
        public static class Entry // Specimens with molecular data
        {
            public const string Material = "mat"; // Materials
            public const string Line = "lne"; // Cell lines
            public const string Organoid = "org"; // Organoids
            public const string Xenograft = "xen"; // Xenografts
        }

        public const string Intervention = "spe-int"; // Interventions
        public const string Drug = "spe-drg"; // Drugs screenings (DSA analysis)
    }

    public static class Omics
    {
        public static class Dna
        {
            public const string Sample = "dna"; // DNA samples (fasta, fastq, BAM)
            public const string Sm = "dna-sm"; // SMs
            public const string Cnv = "dna-cnv"; // CNVs
            public const string CnvProfile = "dna-cnvp"; //CNV profiles (aggregation of CNV per chromosome arm)
            public const string Sv = "dna-sv"; // SVs
        }

        public static class Methylation
        {
            public const string Sample = "meth"; // Methylation samples (fasta, fastq, BAM, idat)
            public const string Level = "meth-lvl"; // Methylation levels (beta and/or M values)
        }

        public static class Rna
        {
            public const string Sample = "rna"; // Bulk RNA samples (fasta, fastq, BAM)
            public const string Expression = "rna-exp"; // Bulk RNA expressions
        }

        public static class Rnasc
        {
            public const string Sample = "rnasc"; // Single cell RNA samples (fasta, fastq, BAM)
            public const string Expression = "rnasc-exp"; // Single cell RNA expressions (mtx)
        }

        public static class Proteomics
        {
            public const string Sample = "prot"; // Proteomics samples (mzML)
            public const string Expression = "prot-exp"; // Protein expressions
        }
    }
}
