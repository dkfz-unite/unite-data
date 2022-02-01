using System.Linq;
using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Genome.Mutations;
using Unite.Data.Entities.Specimens;

namespace Unite.Data.Services.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<Donor> IncludeClinicalData(this IQueryable<Donor> query)
        {
            return query
                .Include(donor => donor.ClinicalData)
                    .ThenInclude(clinicalData => clinicalData.PrimarySite)
                .Include(donor => donor.ClinicalData)
                    .ThenInclude(clinicalData => clinicalData.Localization);
        }

        public static IQueryable<Donor> IncludeTreatments(this IQueryable<Donor> query)
        {
            return query
                .Include(donor => donor.Treatments)
                    .ThenInclude(treatment => treatment.Therapy);
        }

        public static IQueryable<Donor> IncludeWorkPackages(this IQueryable<Donor> query)
        {
            return query
                .Include(donor => donor.DonorWorkPackages)
                    .ThenInclude(donorWorkPackage => donorWorkPackage.WorkPackage);
        }

        public static IQueryable<Donor> IncludeStudies(this IQueryable<Donor> query)
        {
            return query
                .Include(donor => donor.DonorStudies)
                    .ThenInclude(donorStudy => donorStudy.Study);
        }


        public static IQueryable<Specimen> IncludeTissue(this IQueryable<Specimen> query)
        {
            return query
                .Include(specimen => specimen.Tissue)
                    .ThenInclude(tissue => tissue.Source);
        }

        public static IQueryable<Specimen> IncludeCellLine(this IQueryable<Specimen> query)
        {
            return query
                .Include(specimen => specimen.CellLine)
                    .ThenInclude(cellLine => cellLine.Info);
        }

        public static IQueryable<Specimen> IncludeOrganoid(this IQueryable<Specimen> query)
        {
            return query
                .Include(specimen => specimen.Organoid)
                    .ThenInclude(organoid => organoid.Interventions)
                        .ThenInclude(intervention => intervention.Type);
        }

        public static IQueryable<Specimen> IncludeXenograft(this IQueryable<Specimen> query)
        {
            return query
                .Include(specimen => specimen.Xenograft)
                     .ThenInclude(xenograft => xenograft.Interventions)
                        .ThenInclude(intervention => intervention.Type);
        }

        public static IQueryable<Specimen> IncludeMolecularData(this IQueryable<Specimen> query)
        {
            return query
                .Include(specimen => specimen.MolecularData);
        }


        public static IQueryable<Mutation> IncludeAffectedTranscripts(this IQueryable<Mutation> query)
        {
            return query
                .Include(mutation => mutation.AffectedTranscripts)
                    .ThenInclude(affectedTranscript => affectedTranscript.Transcript)
                        .ThenInclude(transcript => transcript.Biotype)
                .Include(mutation => mutation.AffectedTranscripts)
                    .ThenInclude(affectedTranscript => affectedTranscript.Transcript)
                        .ThenInclude(transcript => transcript.Info)
                .Include(mutation => mutation.AffectedTranscripts)
                    .ThenInclude(affectedTranscript => affectedTranscript.Transcript)
                        .ThenInclude(transcript => transcript.Gene)
                            .ThenInclude(gene => gene.Biotype)
                .Include(mutation => mutation.AffectedTranscripts)
                    .ThenInclude(affectedTranscript => affectedTranscript.Transcript)
                        .ThenInclude(transcript => transcript.Gene)
                            .ThenInclude(gene => gene.Info)
                .Include(mutation => mutation.AffectedTranscripts)
                    .ThenInclude(affectedTranscript => affectedTranscript.Transcript)
                        .ThenInclude(transcript => transcript.Protein)
                            .ThenInclude(protein => protein.Info)
                .Include(mutation => mutation.AffectedTranscripts)
                    .ThenInclude(affectedTranscript => affectedTranscript.Consequences)
                        .ThenInclude(affectedTranscriptConsequence => affectedTranscriptConsequence.Consequence);
        }
    }
}
