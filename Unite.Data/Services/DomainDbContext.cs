using Microsoft.EntityFrameworkCore;
using Unite.Data.Services.Configuration.Options;

namespace Unite.Data.Services
{
    public class DomainDbContext : DbContext
    {
        private const string _database = "unite_data";
        private readonly string _connectionString;

        public DbSet<Entities.Tasks.Task> Tasks { get; set; }

        public DbSet<Entities.Donors.Donor> Donors { get; set; }
        public DbSet<Entities.Donors.Study> Studies { get; set; }
        public DbSet<Entities.Donors.StudyDonor> StudyDonors { get; set; }
        public DbSet<Entities.Donors.WorkPackage> WorkPackages { get; set; }
        public DbSet<Entities.Donors.WorkPackageDonor> WorkPackageDonors { get; set; }
        public DbSet<Entities.Donors.Clinical.ClinicalData> ClinicalData { get; set; }
        public DbSet<Entities.Donors.Clinical.TumorPrimarySite> TumorPrimarySites { get; set; }
        public DbSet<Entities.Donors.Clinical.TumorLocalization> TumorLocalizations { get; set; }
        public DbSet<Entities.Donors.Clinical.Therapy> Therapies { get; set; }
        public DbSet<Entities.Donors.Clinical.Treatment> Treatments { get; set; }

        public DbSet<Entities.Specimens.Specimen> Specimens { get; set; }
        public DbSet<Entities.Specimens.MolecularData> MolecularData { get; set; }
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

        public DbSet<Entities.Genome.Gene> Genes { get; set; }
        public DbSet<Entities.Genome.GeneBiotype> GeneBiotypes { get; set; }
        public DbSet<Entities.Genome.GeneInfo> GeneInfo { get; set; }
        public DbSet<Entities.Genome.Transcript> Transcripts { get; set; }
        public DbSet<Entities.Genome.TranscriptBiotype> TranscriptBiotypes { get; set; }
        public DbSet<Entities.Genome.TranscriptInfo> TranscriptInfo { get; set; }
        public DbSet<Entities.Genome.Protein> Proteins { get; set; }
        public DbSet<Entities.Genome.ProteinInfo> ProteinInfo { get; set; }
        public DbSet<Entities.Genome.Mutations.Sample> Samples { get; set; }
        public DbSet<Entities.Genome.Mutations.AnalysedSample> AnalysedSamples { get; set; }
        public DbSet<Entities.Genome.Mutations.Analysis> SampleAnalyses { get; set; }
        public DbSet<Entities.Genome.Mutations.AnalysisParameter> SampleAnalysisParameters { get; set; }
        public DbSet<Entities.Genome.Mutations.AnalysisParameterOccurrence> SampleAnalysisParameterOccurrences { get; set; }
        public DbSet<Entities.Genome.Mutations.Mutation> Mutations { get; set; }
        public DbSet<Entities.Genome.Mutations.MutationOccurrence> MutationOccurrences { get; set; }
        public DbSet<Entities.Genome.Mutations.AffectedTranscript> AffectedTranscripts { get; set; }
        public DbSet<Entities.Genome.Mutations.AffectedTranscriptConsequence> AffectedTranscriptConsequences { get; set; }
        public DbSet<Entities.Genome.Mutations.Consequence> Consequences { get; set; }

        public DbSet<Entities.Images.Image> Images { get; set; }
        public DbSet<Entities.Images.MriImage> MriImages { get; set; }
        public DbSet<Entities.Images.Features.AnalysedImage> AnalysedImages { get; set; }
        public DbSet<Entities.Images.Features.Analysis> ImageAnalyses { get; set; }
        public DbSet<Entities.Images.Features.AnalysisParameter> ImageAnalysisParameters { get; set; }
        public DbSet<Entities.Images.Features.AnalysisParameterOccurrence> ImageAnalysisParameterOccurrences { get; set; }
        public DbSet<Entities.Images.Features.Feature> ImageFeatures { get; set; }
        public DbSet<Entities.Images.Features.FeatureOccurrence> ImageFeatureOccurrences { get; set; }
        


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
            ConfigureSpecimens(builder);
            ConfigureGenome(builder);
            ConfigureImages(builder);
        }


        private void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.TaskTypeMapper());
            modelBuilder.ApplyConfiguration(new Mappers.Tasks.Enums.TaskTargetTypeMapper());
            modelBuilder.ApplyConfiguration(new Mappers.Tasks.TaskMapper());
        }

        private void ConfigureDonors(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Mappers.Donors.DonorMapper());
            builder.ApplyConfiguration(new Mappers.Donors.StudyMapper());
            builder.ApplyConfiguration(new Mappers.Donors.StudyDonorMapper());
            builder.ApplyConfiguration(new Mappers.Donors.WorkPackageMapper());
            builder.ApplyConfiguration(new Mappers.Donors.WorkPackageDonorMapper());

            builder.ApplyConfiguration(new Mappers.Donors.Clinical.Enums.GenderMapper());
            builder.ApplyConfiguration(new Mappers.Donors.Clinical.ClinicalDataMapper());
            builder.ApplyConfiguration(new Mappers.Donors.Clinical.TumorPrimarySiteMapper());
            builder.ApplyConfiguration(new Mappers.Donors.Clinical.TumorLocalizationMapper());
            builder.ApplyConfiguration(new Mappers.Donors.Clinical.TherrapyMapper());
            builder.ApplyConfiguration(new Mappers.Donors.Clinical.TreatmentMapper());
        }

        private void ConfigureSpecimens(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Mappers.Specimens.Enums.GeneExpressionSubtypeMapper());
            builder.ApplyConfiguration(new Mappers.Specimens.Enums.IdhStatusMapper());
            builder.ApplyConfiguration(new Mappers.Specimens.Enums.IdhMutationMapper());
            builder.ApplyConfiguration(new Mappers.Specimens.Enums.MgmtStatusMapper());
            builder.ApplyConfiguration(new Mappers.Specimens.Enums.MethylationSubtypeMapper());
            builder.ApplyConfiguration(new Mappers.Specimens.SpecimenMapper());
            builder.ApplyConfiguration(new Mappers.Specimens.MolecularDataMapper());

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

        private void ConfigureGenome(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Mappers.Genome.Enums.ChromosomeMapper());
            builder.ApplyConfiguration(new Mappers.Genome.GeneMapper());
            builder.ApplyConfiguration(new Mappers.Genome.GeneBiotypeMapper());
            builder.ApplyConfiguration(new Mappers.Genome.GeneInfoMapper());
            builder.ApplyConfiguration(new Mappers.Genome.TranscriptMapper());
            builder.ApplyConfiguration(new Mappers.Genome.TranscriptBiotypeMapper());
            builder.ApplyConfiguration(new Mappers.Genome.TranscriptInfoMapper());
            builder.ApplyConfiguration(new Mappers.Genome.ProteinMapper());
            builder.ApplyConfiguration(new Mappers.Genome.ProteinInfoMapper());

            builder.ApplyConfiguration(new Mappers.Genome.Mutations.Enums.AnalysisTypeMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.Enums.ConsequenceTypeMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.Enums.ConsequenceImpactMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.Enums.MutationTypeMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.SampleMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.AnalysedSampleMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.AnalysisMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.AnalysisParameterMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.AnalysisParameterOccurrenceMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.MutationMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.MutationOccurrenceMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.AffectedTranscriptMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.AffectedTranscriptConsequenceMapper());
            builder.ApplyConfiguration(new Mappers.Genome.Mutations.ConsequenceMapper());
        }

        private void ConfigureImages(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Mappers.Images.ImageMapper());
            builder.ApplyConfiguration(new Mappers.Images.MriImageMapper());

            builder.ApplyConfiguration(new Mappers.Images.Features.Enums.AnalysisTypeMapper());
            builder.ApplyConfiguration(new Mappers.Images.Features.AnalysedImageMapper());
            builder.ApplyConfiguration(new Mappers.Images.Features.AnalysisMapper());
            builder.ApplyConfiguration(new Mappers.Images.Features.AnalysisParameterMapper());
            builder.ApplyConfiguration(new Mappers.Images.Features.AnalysisParameterOccurrenceMapper());
            builder.ApplyConfiguration(new Mappers.Images.Features.FeatureMapper());
            builder.ApplyConfiguration(new Mappers.Images.Features.FeatureOccurrenceMapper());
        }
    }
}
