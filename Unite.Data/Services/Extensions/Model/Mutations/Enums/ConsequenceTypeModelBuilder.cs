using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Mutations.Enums;
using Unite.Data.Services.Entities;

namespace Unite.Data.Services.Extensions.Model.Mutations.Enums
{
    public static class ConsequenceTypeModelBuilder
    {
        public static void BuildConsequenceTypeModel(this ModelBuilder modelBuilder)
        {
            var data = new EnumValue<ConsequenceType>[]
            {
                ConsequenceType.TranscriptAblation.ToEnumValue(name: "Transcript ablation"),
                ConsequenceType.SpliceAcceptor.ToEnumValue(name: "Splice acceptor variant"),
                ConsequenceType.SpliceDonor.ToEnumValue(name: "Splice donor variant"),
                ConsequenceType.StopGained.ToEnumValue(name: "Stop gained"),
                ConsequenceType.Frameshift.ToEnumValue(name: "Frameshift variant"),
                ConsequenceType.StopLost.ToEnumValue(name: "Stop lost"),
                ConsequenceType.StartLost.ToEnumValue(name: "Start lost"),
                ConsequenceType.TranscriptAmplification.ToEnumValue(name: "Transcript amplification"),
                ConsequenceType.InframeInsertion.ToEnumValue(name: "Inframe insertion"),
                ConsequenceType.InframeDeletion.ToEnumValue(name: "Inframe deletion"),
                ConsequenceType.Missense.ToEnumValue(name: "Missense variant"),
                ConsequenceType.ProteinAltering.ToEnumValue(name: "Protein altering variant"),
                ConsequenceType.SpliceRegion.ToEnumValue(name: "Splice region variant"),
                ConsequenceType.IncompleteTerminalCodon.ToEnumValue(name: "Incomplete terminal codon variant"),
                ConsequenceType.StartRetained.ToEnumValue(name: "Start retained variant"),
                ConsequenceType.StopRetained.ToEnumValue(name: "Stop retained variant"),
                ConsequenceType.Synonymous.ToEnumValue(name: "Synonymous variant"),
                ConsequenceType.CodingSequence.ToEnumValue(name: "Coding sequence variant"),
                ConsequenceType.MatureMiRNA.ToEnumValue(name: "Mature miRNA variant"),
                ConsequenceType.UTR5.ToEnumValue(name: "5 prime UTR variant"),
                ConsequenceType.UTR3.ToEnumValue(name: "3 prime UTR variant"),
                ConsequenceType.NonCodingTranscriptExon.ToEnumValue(name: "Non coding transcript exon variant"),
                ConsequenceType.Intron.ToEnumValue(name: "Intron variant"),
                ConsequenceType.NmdTranscript.ToEnumValue(name: "NMD transcript variant"),
                ConsequenceType.NonCodingTranscript.ToEnumValue(name: "Non coding transcript variant"),
                ConsequenceType.Upstream.ToEnumValue(name: "Upstream gene variant"),
                ConsequenceType.Downstream.ToEnumValue(name: "Downstream gene variant"),
                ConsequenceType.TfbsAblation.ToEnumValue(name: "TFBS ablation"),
                ConsequenceType.TfbsAmplification.ToEnumValue(name: "TFBS amplification"),
                ConsequenceType.TfBindingSite.ToEnumValue(name: "TF binding site variant"),
                ConsequenceType.RegulatoryRegionAblation.ToEnumValue(name: "Regulatory region ablation"),
                ConsequenceType.RegulatoryRegionAmplification.ToEnumValue(name: "Regulatory region amplification"),
                ConsequenceType.FeatureElongation.ToEnumValue(name: "Feature elongation"),
                ConsequenceType.RegulatoryRegion.ToEnumValue(name: "Regulatory region variant"),
                ConsequenceType.FeatureTruncation.ToEnumValue(name: "Feature truncation"),
                ConsequenceType.Intergenic.ToEnumValue(name: "Intergenic variant")
            };

            modelBuilder.BuildEnumValueModel("ConsequenceTypes", data);
        }
    }
}
