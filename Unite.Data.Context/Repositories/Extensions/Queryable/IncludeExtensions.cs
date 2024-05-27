using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens;

using Dna = Unite.Data.Entities.Genome.Analysis.Dna;

namespace Unite.Data.Context.Extensions.Queryable;

public static class IncludeExtensions
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

    public static IQueryable<Donor> IncludeProjects(this IQueryable<Donor> query)
    {
        return query
            .Include(donor => donor.DonorProjects)
                .ThenInclude(donorProject => donorProject.Project);
    }

    public static IQueryable<Donor> IncludeStudies(this IQueryable<Donor> query)
    {
        return query
            .Include(donor => donor.DonorStudies)
                .ThenInclude(donorStudy => donorStudy.Study);
    }


    public static IQueryable<Image> IncludeMriImage(this IQueryable<Image> query)
    {
        return query
            .Include(image => image.MriImage);
    }


    public static IQueryable<Specimen> IncludeMaterial(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.Material)
                .ThenInclude(material => material.Source);
    }

    public static IQueryable<Specimen> IncludeLine(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.Line)
                .ThenInclude(line => line.Info);
    }

    public static IQueryable<Specimen> IncludeOrganoid(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.Organoid);
    }

    public static IQueryable<Specimen> IncludeXenograft(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.Xenograft);
    }

    public static IQueryable<Specimen> IncludeMolecularData(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.MolecularData);
    }

    public static IQueryable<Specimen> IncludeInterventions(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.Interventions)
                .ThenInclude(intervention => intervention.Type);
    }


    public static IQueryable<TVariant> IncludeAffectedTranscripts<TVariant>(this IQueryable<TVariant> query) where TVariant : Dna.Variant
    {
        switch (query)
        {
            case IQueryable<Dna.Ssm.Variant> ssms:
                return (IQueryable<TVariant>)ssms.IncludeAffectedTranscripts();
            case IQueryable<Dna.Cnv.Variant> cnvs:
                return (IQueryable<TVariant>)cnvs.IncludeAffectedTranscripts();
            case IQueryable<Dna.Sv.Variant> svs:
                return (IQueryable<TVariant>)svs.IncludeAffectedTranscripts();
            default:
                return query;
        }
    }

    public static IQueryable<Dna.Ssm.Variant> IncludeAffectedTranscripts(this IQueryable<Dna.Ssm.Variant> query)
    {
        return query
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
                    .ThenInclude(transcript => transcript.Gene)
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
                    .ThenInclude(transcript => transcript.Protein);
    }

    public static IQueryable<Dna.Cnv.Variant> IncludeAffectedTranscripts(this IQueryable<Dna.Cnv.Variant> query)
    {
        return query
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
                    .ThenInclude(transcript => transcript.Gene)
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
                    .ThenInclude(transcript => transcript.Protein);
    }

    public static IQueryable<Dna.Sv.Variant> IncludeAffectedTranscripts(this IQueryable<Dna.Sv.Variant> query)
    {
        return query
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
                    .ThenInclude(transcript => transcript.Gene)
            .Include(variant => variant.AffectedTranscripts)
                .ThenInclude(affectedTranscript => affectedTranscript.Feature)
                    .ThenInclude(transcript => transcript.Protein);
    }
}
