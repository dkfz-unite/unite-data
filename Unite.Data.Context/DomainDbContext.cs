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
    public DbSet<Entities.Images.MrImage> MrImages { get; set; }
    public DbSet<Entities.Images.Analysis.Analysis> ImageAnalyses { get; set; }
    public DbSet<Entities.Images.Analysis.Sample> ImageSamples { get; set; }
    public DbSet<Entities.Images.Analysis.Radiomics.Feature> RadiomicsFeatures { get; set; }
    public DbSet<Entities.Images.Analysis.Radiomics.FeatureEntry> RadiomicsFeatureEntries { get; set; }

    public DbSet<Entities.Specimens.Specimen> Specimens { get; set; }
    public DbSet<Entities.Specimens.TumorClassification> TumorClassifications { get; set; }
    public DbSet<Entities.Specimens.MolecularData> MolecularData { get; set; }
    public DbSet<Entities.Specimens.InterventionType> InterventionTypes { get; set; }
    public DbSet<Entities.Specimens.Intervention> Interventions { get; set; }
    public DbSet<Entities.Specimens.Materials.Material> Materials { get; set; }
    public DbSet<Entities.Specimens.Materials.MaterialSource> MaterialSources { get; set; }
    public DbSet<Entities.Specimens.Lines.Line> Lines { get; set; }
    public DbSet<Entities.Specimens.Lines.LineInfo> LineInfos { get; set; }
    public DbSet<Entities.Specimens.Organoids.Organoid> Organoids { get; set; }
    public DbSet<Entities.Specimens.Xenografts.Xenograft> Xenografts { get; set; }
    public DbSet<Entities.Specimens.Analysis.Analysis> SpecimenAnalyses { get; set; }
    public DbSet<Entities.Specimens.Analysis.Sample> SpecimenSamples { get; set; }
    public DbSet<Entities.Specimens.Analysis.Drugs.Drug> Drugs { get; set; }
    public DbSet<Entities.Specimens.Analysis.Drugs.DrugScreening> DrugScreenings { get; set; }

    public DbSet<Entities.Omics.Gene> Genes { get; set; }
    public DbSet<Entities.Omics.Transcript> Transcripts { get; set; }
    public DbSet<Entities.Omics.Protein> Proteins { get; set; }
    public DbSet<Entities.Omics.Analysis.Analysis> OmicsAnalyses { get; set; }
    public DbSet<Entities.Omics.Analysis.Sample> OmicsSamples { get; set; }
    public DbSet<Entities.Omics.Analysis.SampleResource> OmicsSampleResources { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Sm.Variant> Sms { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Sm.VariantEntry> SmEntries { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Sm.AffectedTranscript> SmAffectedTranscripts { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Cnv.Variant> Cnvs { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Cnv.VariantEntry> CnvEntries { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Cnv.AffectedTranscript> CnvAffectedTranscripts { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Sv.Variant> Svs { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Sv.VariantEntry> SvEntries { get; set; }
    public DbSet<Entities.Omics.Analysis.Dna.Sv.AffectedTranscript> SvAffectedTranscripts { get; set; }
    public DbSet<Entities.Omics.Analysis.Rna.GeneExpression> GeneExpressions { get; set; }
    public DbSet<Entities.Omics.Analysis.CnvProfile> CnvProfiles { get; set; }


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
        ConfigureOmics(builder);
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

        builder.ApplyConfiguration(new Mappers.Donors.Clinical.Enums.SexMapper());
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

        builder.ApplyConfiguration(new Mappers.Images.MrImageMapper());

        builder.ApplyConfiguration(new Mappers.Images.Analysis.Enums.AnalysisTypeMapper());
        builder.ApplyConfiguration(new Mappers.Images.Analysis.AnalysisMapper());
        builder.ApplyConfiguration(new Mappers.Images.Analysis.SampleMapper());
        builder.ApplyConfiguration(new Mappers.Images.Analysis.Radiomics.FeatureMapper());
        builder.ApplyConfiguration(new Mappers.Images.Analysis.Radiomics.FeatureEntryMapper());
    }

    private static void ConfigureSpecimens(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.SpecimenTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.CategoryMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.TumorTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.IdhMutationMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.TertMutationMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.ExpressionSubtypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Enums.MethylationSubtypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.SpecimenMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.TumorSuperfamilyMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.TumorFamilyMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.TumorClassMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.TumorSubclassMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.TumorClassificationMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.MolecularDataMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.InterventionTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.InterventionMapper());

        builder.ApplyConfiguration(new Mappers.Specimens.Materials.Enums.FixationTypeMapper());
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

        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.Enums.AnalysisTypeMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.AnalysisMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.SampleMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.Drugs.DrugMapper());
        builder.ApplyConfiguration(new Mappers.Specimens.Analysis.Drugs.DrugScreeningMapper());
    }

    private static void ConfigureOmics(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new Mappers.Omics.Enums.ChromosomeMapper());
        builder.ApplyConfiguration(new Mappers.Omics.GeneMapper());
        builder.ApplyConfiguration(new Mappers.Omics.TranscriptMapper());
        builder.ApplyConfiguration(new Mappers.Omics.ProteinMapper());

        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Enums.AnalysisTypeMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.AnalysisMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.SampleMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.SampleResourceMapper());

        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sm.Enums.SmTypeMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sm.VariantMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sm.VariantEntryMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sm.AffectedTranscriptMapper());

        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Cnv.Enums.CnvTypeMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Cnv.VariantMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Cnv.VariantEntryMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Cnv.AffectedTranscriptMapper());

        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sv.Enums.SvTypeMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sv.VariantMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sv.VariantEntryMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Dna.Sv.AffectedTranscriptMapper());

        builder.ApplyConfiguration(new Mappers.Omics.Analysis.Rna.GeneExpressionMapper());
        builder.ApplyConfiguration(new Mappers.Omics.Analysis.CnvProfileMapper());
    }
}
