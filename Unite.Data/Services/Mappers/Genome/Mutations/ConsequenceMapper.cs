using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unite.Data.Entities.Genome.Mutations;
using Unite.Data.Entities.Genome.Mutations.Enums;

namespace Unite.Data.Services.Mappers.Genome.Mutations
{
    internal class ConsequenceMapper : IEntityTypeConfiguration<Consequence>
    {
        public void Configure(EntityTypeBuilder<Consequence> entity)
        {
            entity.ToTable("Consequences", DomainDbSchemaNames.Genome);

            entity.HasKey(consequence => consequence.TypeId);

            entity.Property(consequence => consequence.TypeId)
                  .IsRequired()
                  .HasConversion<int>();

            entity.Property(consequence => consequence.ImpactId)
                  .IsRequired()
                  .HasConversion<int>();

            entity.Property(consequence => consequence.Severity)
                  .IsRequired();

            entity.HasData
            (
                new Consequence() { TypeId = ConsequenceType.TranscriptAblation, ImpactId = ConsequenceImpact.High, Severity = 1 },
                new Consequence() { TypeId = ConsequenceType.SpliceAcceptor, ImpactId = ConsequenceImpact.High, Severity = 2 },
                new Consequence() { TypeId = ConsequenceType.SpliceDonor, ImpactId = ConsequenceImpact.High, Severity = 3 },
                new Consequence() { TypeId = ConsequenceType.StopGained, ImpactId = ConsequenceImpact.High, Severity = 4 },
                new Consequence() { TypeId = ConsequenceType.Frameshift, ImpactId = ConsequenceImpact.High, Severity = 5 },
                new Consequence() { TypeId = ConsequenceType.StopLost, ImpactId = ConsequenceImpact.High, Severity = 6 },
                new Consequence() { TypeId = ConsequenceType.StartLost, ImpactId = ConsequenceImpact.High, Severity = 7 },
                new Consequence() { TypeId = ConsequenceType.TranscriptAmplification, ImpactId = ConsequenceImpact.High, Severity = 8 },
                new Consequence() { TypeId = ConsequenceType.InframeInsertion, ImpactId = ConsequenceImpact.Moderate, Severity = 9 },
                new Consequence() { TypeId = ConsequenceType.InframeDeletion, ImpactId = ConsequenceImpact.Moderate, Severity = 10 },
                new Consequence() { TypeId = ConsequenceType.Missense, ImpactId = ConsequenceImpact.Moderate, Severity = 11 },
                new Consequence() { TypeId = ConsequenceType.ProteinAltering, ImpactId = ConsequenceImpact.Moderate, Severity = 12 },
                new Consequence() { TypeId = ConsequenceType.SpliceRegion, ImpactId = ConsequenceImpact.Low, Severity = 13 },
                new Consequence() { TypeId = ConsequenceType.IncompleteTerminalCodon, ImpactId = ConsequenceImpact.Low, Severity = 14 },
                new Consequence() { TypeId = ConsequenceType.StartRetained, ImpactId = ConsequenceImpact.Low, Severity = 15 },
                new Consequence() { TypeId = ConsequenceType.StopRetained, ImpactId = ConsequenceImpact.Low, Severity = 16 },
                new Consequence() { TypeId = ConsequenceType.Synonymous, ImpactId = ConsequenceImpact.Low, Severity = 17 },
                new Consequence() { TypeId = ConsequenceType.CodingSequence, ImpactId = ConsequenceImpact.Unknown, Severity = 18 },
                new Consequence() { TypeId = ConsequenceType.MatureMiRNA, ImpactId = ConsequenceImpact.Unknown, Severity = 19 },
                new Consequence() { TypeId = ConsequenceType.UTR5, ImpactId = ConsequenceImpact.Unknown, Severity = 20 },
                new Consequence() { TypeId = ConsequenceType.UTR3, ImpactId = ConsequenceImpact.Unknown, Severity = 21 },
                new Consequence() { TypeId = ConsequenceType.NonCodingTranscriptExon, ImpactId = ConsequenceImpact.Unknown, Severity = 22 },
                new Consequence() { TypeId = ConsequenceType.Intron, ImpactId = ConsequenceImpact.Unknown, Severity = 23 },
                new Consequence() { TypeId = ConsequenceType.NmdTranscript, ImpactId = ConsequenceImpact.Unknown, Severity = 24 },
                new Consequence() { TypeId = ConsequenceType.NonCodingTranscript, ImpactId = ConsequenceImpact.Unknown, Severity = 25 },
                new Consequence() { TypeId = ConsequenceType.Upstream, ImpactId = ConsequenceImpact.Unknown, Severity = 26 },
                new Consequence() { TypeId = ConsequenceType.Downstream, ImpactId = ConsequenceImpact.Unknown, Severity = 27 },
                new Consequence() { TypeId = ConsequenceType.TfbsAblation, ImpactId = ConsequenceImpact.Unknown, Severity = 28 },
                new Consequence() { TypeId = ConsequenceType.TfbsAmplification, ImpactId = ConsequenceImpact.Unknown, Severity = 29 },
                new Consequence() { TypeId = ConsequenceType.TfBindingSite, ImpactId = ConsequenceImpact.Unknown, Severity = 30 },
                new Consequence() { TypeId = ConsequenceType.RegulatoryRegionAblation, ImpactId = ConsequenceImpact.Moderate, Severity = 31 },
                new Consequence() { TypeId = ConsequenceType.RegulatoryRegionAmplification, ImpactId = ConsequenceImpact.Unknown, Severity = 32 },
                new Consequence() { TypeId = ConsequenceType.FeatureElongation, ImpactId = ConsequenceImpact.Unknown, Severity = 33 },
                new Consequence() { TypeId = ConsequenceType.RegulatoryRegion, ImpactId = ConsequenceImpact.Unknown, Severity = 34 },
                new Consequence() { TypeId = ConsequenceType.FeatureTruncation, ImpactId = ConsequenceImpact.Unknown, Severity = 35 },
                new Consequence() { TypeId = ConsequenceType.Intergenic, ImpactId = ConsequenceImpact.Unknown, Severity = 36 }
            );
        }
    }
}
