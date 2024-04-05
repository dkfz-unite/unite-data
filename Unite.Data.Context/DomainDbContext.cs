using Microsoft.EntityFrameworkCore;
using Unite.Data.Context.Configuration.Options;

namespace Unite.Data.Context;

public class DomainDbContext : DbContext
{
    private readonly string _connectionString;

    public const string DatabaseName = "unite_data";

    public DbSet<Entities.Tasks.Task> Tasks { get; set; }
    public DbSet<Entities.Tasks.Worker> Workers { get; set; }

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
    public DbSet<Entities.Images.Features.RadiomicsFeature> RadiomicsFeatures { get; set; }
    public DbSet<Entities.Images.Features.RadiomicsFeatureEntry> RadiomicsFeatureEntries { get; set; }

    public DbSet<Entities.Specimens.Specimen> Specimens { get; set; }
    public DbSet<Entities.Specimens.MolecularData> MolecularData { get; set; }
    public DbSet<Entities.Specimens.InterventionType> InterventionTypes { get; set; }
    public DbSet<Entities.Specimens.Intervention> Interventions { get; set; }
    public DbSet<Entities.Specimens.Drug> Drugs { get; set; }
    public DbSet<Entities.Specimens.DrugScreening> DrugScreenings { get; set; }
    public DbSet<Entities.Specimens.Materials.Material> Materials { get; set; }
    public DbSet<Entities.Specimens.Materials.MaterialSource> MaterialSources { get; set; }
    public DbSet<Entities.Specimens.Lines.Line> Lines { get; set; }
    public DbSet<Entities.Specimens.Lines.LineInfo> LineInfos { get; set; }
    public DbSet<Entities.Specimens.Organoids.Organoid> Organoids { get; set; }
    public DbSet<Entities.Specimens.Xenografts.Xenograft> Xenografts { get; set; }

    public DbSet<Entities.Genome.Gene> Genes { get; set; }
    public DbSet<Entities.Genome.Transcript> Transcripts { get; set; }
    public DbSet<Entities.Genome.Protein> Proteins { get; set; }
    public DbSet<Entities.Genome.Analysis.Analysis> Analyses { get; set; }
    public DbSet<Entities.Genome.Analysis.AnalysedSample> AnalysedSamples { get; set; }
    public DbSet<Entities.Genome.Variants.SSM.Variant> Ssms { get; set; }
    public DbSet<Entities.Genome.Variants.SSM.VariantEntry> SsmEntries { get; set; }
    public DbSet<Entities.Genome.Variants.SSM.AffectedTranscript> SsmAffectedTranscripts { get; set; }
    public DbSet<Entities.Genome.Variants.CNV.Variant> Cnvs { get; set; }
    public DbSet<Entities.Genome.Variants.CNV.VariantEntry> CnvEntries { get; set; }
    public DbSet<Entities.Genome.Variants.CNV.AffectedTranscript> CnvAffectedTranscripts { get; set; }
    public DbSet<Entities.Genome.Variants.SV.Variant> Svs { get; set; }
    public DbSet<Entities.Genome.Variants.SV.VariantEntry> SvEntries { get; set; }
    public DbSet<Entities.Genome.Variants.SV.AffectedTranscript> SvAffectedTranscripts { get; set; }
    public DbSet<Entities.Genome.Transcriptomics.BulkExpression> BulkGeneExpressions { get; set; }


    public DomainDbContext(ISqlOptions options)
    {
        _connectionString = CreateConnectionString(options);
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


    public static string CreateConnectionString(ISqlOptions options)
    {
        return $"Host={options.Host};Port={options.Port};Database={DatabaseName};Username={options.User};Password={options.Password}";
    }

    private static void Configure(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.SubmissionTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.AnnotationTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.IndexingTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.AnalysisTaskTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.TaskStatusTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.WorkerTypeMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.TaskMapper());
        modelBuilder.ApplyConfiguration(new Mappers.Tasks.WorkerMapper());
    }

    private static void ConfigureDonors(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Donors.DonorMapper());
        builder.ApplyConfiguration(new Mappers.Donors.StudyMapper());
        builder.ApplyConfiguration(new Mappers.Donors.StudyDonorMapper());
        builder.ApplyConfiguration(new Mappers.Donors.ProjectMapper());
        builder.ApplyConfiguration(new Mappers.Donors.ProjectDonorMapper());

        builder.ApplyConfiguration(new Mappers.Donors.Clinical.Enums.GenderMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.ClinicalDataMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TumorPrimarySiteMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TumorLocalizationMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TherapyMapper());
        builder.ApplyConfiguration(new Mappers.Donors.Clinical.TreatmentMapper());
    }

    private static void ConfigureImages(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Images.Enums.ImageTypeMapper());
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
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.SpecimenTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.GeneExpressionSubtypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.IdhStatusMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.IdhMutationMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.MgmtStatusMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.MethylationSubtypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.SpecimenMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.MolecularDataMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.InterventionTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.InterventionMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.DrugMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.DrugScreeningMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Materials.Enums.MaterialTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Materials.Enums.TumorTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Materials.MaterialSourceMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Materials.MaterialMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Lines.Enums.CellsTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Lines.Enums.CellsCultureTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Lines.Enums.CellsSpeciesMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Lines.LineMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Lines.LineInfoMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Organoids.OrganoidMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.Enums.ImplantTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.Enums.ImplantLocationMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.Enums.TumorGrowthFormMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Xenografts.XenograftMapper());
    }

    private static void ConfigureGenome(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Genome.Enums.ChromosomeMapper());
        builder.ApplyConfiguration(new Mappers.Genome.GeneMapper());
        builder.ApplyConfiguration(new Mappers.Genome.TranscriptMapper());
        builder.ApplyConfiguration(new Mappers.Genome.ProteinMapper());

        builder.ApplyConfiguration(new Mappers.Genome.Analysis.Enums.AnalysisTypeMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Analysis.AnalysisMapper());
        builder.ApplyConfiguration(new Mappers.Genome.Analysis.AnalysedSampleMapper());

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

        builder.ApplyConfiguration(new Mappers.Genome.Transcriptomics.BulkExpressionMapper());
    }
}
