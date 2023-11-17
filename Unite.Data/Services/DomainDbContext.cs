using Microsoft.EntityFrameworkCore;
using Unite.Data.Services.Configuration.Options;

namespace Unite.Data.Services;

public class DomainDbContext : DbContext
{
    private const string _database = "unite_data";
    private readonly string _connectionString;

    public DbSet<Entities.Tasks.Task> Tasks { get; set; }

    public DbSet<Entities.Donors.Donor> Donors { get; set; }
    public DbSet<Entities.Donors.Study> Studies { get; set; }
    public DbSet<Entities.Donors.StudyDonor> StudyDonors { get; set; }
    public DbSet<Entities.Donors.Project> Projects { get; set; }
    public DbSet<Entities.Donors.ProjectDonor> ProjectDonors { get; set; }
    public DbSet<Entities.Donors.Clinical.ClinicalData> ClinicalData { get; set; }
    public DbSet<Entities.Donors.Clinical.TumorPrimarySite> TumorPrimarySites { get; set; }
    public DbSet<Entities.Donors.Clinical.TumorLocalization> TumorLocalizations { get; set; }
    public DbSet<Entities.Donors.Clinical.Therapy> Therapies { get; set; }
    public DbSet<Entities.Donors.Clinical.Treatment> Treatments { get; set; }

    public DbSet<Entities.Images.Image> Images { get; set; }
    public DbSet<Entities.Images.MriImage> MriImages { get; set; }
    public DbSet<Entities.Images.Analysis.AnalysedSample> AnalysedImages { get; set; }
    public DbSet<Entities.Images.Analysis.Analysis> ImageAnalyses { get; set; }
    public DbSet<Entities.Images.Features.RadiomicsFeature> ImageFeatures { get; set; }
    public DbSet<Entities.Images.Features.RadiomicsFeatureEntry> ImageFeatureEntries { get; set; }

    public DbSet<Entities.Specimens.Specimen> Specimens { get; set; }
    public DbSet<Entities.Specimens.MolecularData> MolecularData { get; set; }
    public DbSet<Entities.Specimens.Drug> Drugs { get; set; }
    public DbSet<Entities.Specimens.DrugScreening> DrugScreenings { get; set; }
    public DbSet<Entities.Specimens.Tissues.Tissue> Tissues { get; set; }
    public DbSet<Entities.Specimens.Tissues.TissueSource> TissueSources { get; set; }
    public DbSet<Entities.Specimens.Cells.CellLine> CellLines { get; set; }
    public DbSet<Entities.Specimens.Cells.CellLineInfo> CellLineInfo { get; set; }
    public DbSet<Entities.Specimens.Organoids.Organoid> Organoids { get; set; }
    public DbSet<Entities.Specimens.Organoids.Intervention> OrganoidInterventions { get; set; }
    public DbSet<Entities.Specimens.Organoids.InterventionType> OrganoidInterventionTypes { get; set; }
    public DbSet<Entities.Specimens.Xenografts.Xenograft> Xenografts { get; set; }
    public DbSet<Entities.Specimens.Xenografts.Intervention> XenograftInterventions { get; set; }
    public DbSet<Entities.Specimens.Xenografts.InterventionType> XenograftInterventionTypes { get; set; }
    public DbSet<Entities.Specimens.Analysis.AnalysedSample> AnalysedSpecimens { get; set; }
    public DbSet<Entities.Specimens.Analysis.Analysis> SpecimenAnalyses { get; set; }

    public DbSet<Entities.Genome.Gene> Genes { get; set; }
    public DbSet<Entities.Genome.Transcript> Transcripts { get; set; }
    public DbSet<Entities.Genome.Protein> Proteins { get; set; }
    public DbSet<Entities.Genome.Variants.SSM.Variant> Ssms { get; set; }
    public DbSet<Entities.Genome.Variants.SSM.VariantEntry> SsmEntries { get; set; }
    public DbSet<Entities.Genome.Variants.SSM.AffectedTranscript> SsmAffectedTranscripts { get; set; }
    public DbSet<Entities.Genome.Variants.CNV.Variant> Cnvs { get; set; }
    public DbSet<Entities.Genome.Variants.CNV.VariantEntry> CnvEntries { get; set; }
    public DbSet<Entities.Genome.Variants.CNV.AffectedTranscript> CnvAffectedTranscripts { get; set; }
    public DbSet<Entities.Genome.Variants.SV.Variant> Svs { get; set; }
    public DbSet<Entities.Genome.Variants.SV.VariantEntry> SvEntries { get; set; }
    public DbSet<Entities.Genome.Variants.SV.AffectedTranscript> SvAffectedTranscripts { get; set; }
    public DbSet<Entities.Genome.Expressions.BulkExpression> BulkExpressions { get; set; }


    public DomainDbContext(ISqlOptions options)
    {
        _connectionString = $"Host={options.Host};Port={options.Port};Database={_database};Username={options.User};Password={options.Password}";
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();

        optionsBuilder.UseNpgsql(_connectionString, b => b.MigrationsAssembly("Unite.Data.Migrations"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        Configure(builder);
        ConfigureDonors(builder);
        ConfigureImages(builder);
        ConfigureSpecimens(builder);
        ConfigureGenome(builder);
    }


    private static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.SubmissionTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.AnnotationTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.IndexingTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.AnalysisTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.TaskStatusTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.TaskMapper());
    }

    private static void ConfigureDonors(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Donors.DonorMapper());
        builder.ApplyConfiguration(new Mappers.Donors.StudyMapper());
        builder.ApplyConfiguration(new Mappers.Donors.StudyDonorMapper());
        builder.ApplyConfiguration(new Mappers.Donors.ProjectMapper());
        builder.ApplyConfiguration(new Mappers.Donors.ProjectDonorMapper());

        builder.ApplyConfiguration(new Mappers.Donors.Clinical.Enums.SexMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.ClinicalDataMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TumorPrimarySiteMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TumorLocalizationMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TherapyMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TreatmentMapper());
    }

    private static void ConfigureImages(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Images.ImageMapper());
        builder.ApplyConfiguration(new Mappers.Images.MriImageMapper());

        builder.ApplyConfiguration(new Mappers.Images.Analysis.Enums.AnalysisTypeMapper());
        builder.ApplyConfiguration(new Mappers.Images.Analysis.AnalysedSampleMapper());
        builder.ApplyConfiguration(new Mappers.Images.Analysis.AnalysisMapper());
        builder.ApplyConfiguration(new Mappers.Images.Features.RadiomicsFeatureMapper());
        builder.ApplyConfiguration(new Mappers.Images.Features.RadiomicsFeatureEntryMapper());
    }

    private static void ConfigureSpecimens(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.Enums.AnalysisTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.AnalysisMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.AnalysedSampleMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Enums.GeneExpressionSubtypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.IdhStatusMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.IdhMutationMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.MgmtStatusMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.MethylationSubtypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.SpecimenMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.MolecularDataMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.DrugMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.DrugScreeningMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Tissues.Enums.TissueTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Tissues.Enums.TumorTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Tissues.TissueSourceMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Tissues.TissueMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Cells.Enums.CellLineTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Cells.Enums.CellLineCultureTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Cells.Enums.SpeciesMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Cells.CellLineMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Cells.CellLineInfoMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Organoids.OrganoidMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Organoids.InterventionMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Organoids.InterventionTypeMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.Enums.ImplantTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.Enums.TissueLocationMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.Enums.TumorGrowthFormMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.XenograftMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.InterventionMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.InterventionTypeMapper());
    }

    private static void ConfigureGenome(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Genome.Enums.ChromosomeMapper());
        builder.ApplyConfiguration(new Mappers.Genome.GeneMapper());
        builder.ApplyConfiguration(new Mappers.Genome.TranscriptMapper());
        builder.ApplyConfiguration(new Mappers.Genome.ProteinMapper());

        builder.ApplyConfiguration(new Mappers.Genome.Variants.SSM.Enums.SsmTypeMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.SSM.VariantMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.SSM.VariantEntryMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.SSM.AffectedTranscriptMapper());

        builder.ApplyConfiguration(new Mappers.Genome.Variants.CNV.Enums.CnvTypeMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.CNV.VariantMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.CNV.VariantEntryMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.CNV.AffectedTranscriptMapper());

        builder.ApplyConfiguration(new Mappers.Genome.Variants.SV.Enums.SvTypeMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.SV.VariantMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.SV.VariantEntryMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Variants.SV.AffectedTranscriptMapper());

        builder.ApplyConfiguration(new Mappers.Genome.Expressions.BulkExpressionMapper());
    }
}
