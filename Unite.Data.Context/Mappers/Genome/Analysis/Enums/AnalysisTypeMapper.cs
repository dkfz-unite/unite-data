using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Context.Mappers.Entities;
using Unite.Data.Context.Mappers.Entities.Extensions;
using Unite.Data.Entities.Genome.Analysis.Enums;

namespace Unite.Data.Context.Mappers.Genome.Analysis.Enums;

internal class AnalysisTypeMapper : IEntityTypeConfiguration<EnumEntity<AnalysisType>>
{
    public void Configure(EntityTypeBuilder<EnumEntity<AnalysisType>> entity)
    {
        var data = new EnumEntity<AnalysisType>[]
        {
            AnalysisType.WGS.ToEnumValue(name: "Whole Genome Sequencing"),
            AnalysisType.WES.ToEnumValue(name: "Whole Exome Sequencing"),
            AnalysisType.RNASeq.ToEnumValue(name: "Bulk RNA Sequencing"),
            AnalysisType.RNASeqSc.ToEnumValue(name: "Single Cell RNA Sequencing"),
            AnalysisType.RNASeqSn.ToEnumValue(name: "Single Nucleus RNA Sequencing"),
            AnalysisType.ATACSeq.ToEnumValue(name: "Bulk ATAC Sequencing"),
            AnalysisType.ATACSeqSc.ToEnumValue(name: "Single Cell ATAC Sequencing"),
            AnalysisType.ATACSeqSn.ToEnumValue(name: "Single Nucleus ATAC Sequencing"),
            AnalysisType.MethArray.ToEnumValue(name: "Illumina Infinium Methylation Arrays Assay"),
            AnalysisType.WGBS.ToEnumValue(name: "Whole Genome Bisulfite Sequencing"),
            AnalysisType.RRBS.ToEnumValue(name: "Reduced Representation Bisulfite Sequencing")
        };

        entity.BuildEnumEntity("AnalysisTypes", DomainDbSchemaNames.Genome, data);
    }
}
