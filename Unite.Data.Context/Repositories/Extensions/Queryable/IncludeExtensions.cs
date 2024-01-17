using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Images;
using Unite.Data.Entities.Specimens;

using Variants = Unite.Data.Entities.Genome.Variants;

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

    public static IQueryable<Specimen> IncludeDrugScreenings(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.DrugScreenings)
                .ThenInclude(screening => screening.Drug);
    }

    public static IQueryable<Specimen> IncludeInterventions(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.Interventions)
                .ThenInclude(intervention => intervention.Type);
    }


    public static IQueryable<TVariant> IncludeAffectedTranscripts<TVariant>(this IQueryable<TVariant> query) where TVariant : Variants.Variant
    {
        switch (query)
        {
            case IQueryable<Variants.SSM.Variant> mutations:
                return (IQueryable<TVariant>)mutations.IncludeAffectedTranscripts();
            case IQueryable<Variants.CNV.Variant> copyNumberVariants:
                return (IQueryable<TVariant>)copyNumberVariants.IncludeAffectedTranscripts();
            case IQueryable<Variants.SV.Variant> structuralVariants:
                return (IQueryable<TVariant>)structuralVariants.IncludeAffectedTranscripts();
            default:
                return query;
        }
    }

    public static IQueryable<Variants.SSM.Variant> IncludeAffectedTranscripts(this IQueryable<Variants.SSM.Variant> query)
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

    public static IQueryable<Variants.CNV.Variant> IncludeAffectedTranscripts(this IQueryable<Variants.CNV.Variant> query)
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

    public static IQueryable<Variants.SV.Variant> IncludeAffectedTranscripts(this IQueryable<Variants.SV.Variant> query)
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
