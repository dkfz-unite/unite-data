using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Specimens;

using Variants = Unite.Data.Entities.Genome.Variants;

namespace Unite.Data.Services.Extensions;

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

    public static IQueryable<Specimen> IncludeDrugScreeningData(this IQueryable<Specimen> query)
    {
        return query
            .Include(specimen => specimen.DrugScreenings)
                .ThenInclude(screening => screening.Feature);
    }


    public static IQueryable<TVariant> IncludeAffectedTranscripts<TVariant>(this IQueryable<TVariant> query) where TVariant : Entities.Genome.Variants.Variant
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
