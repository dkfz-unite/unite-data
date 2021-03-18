using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Epigenetics;
using Unite.Data.Entities.Identity;
using Unite.Data.Entities.Mutations;
using Unite.Data.Entities.Tasks;
using Unite.Data.Services.Configuration.Options;
using Unite.Data.Services.Extensions.Model;
using Unite.Data.Services.Extensions.Model.Donors;
using Unite.Data.Services.Extensions.Model.Donors.Enums;
using Unite.Data.Services.Extensions.Model.Epigenetics;
using Unite.Data.Services.Extensions.Model.Epigenetics.Enums;
using Unite.Data.Services.Extensions.Model.Identity;
using Unite.Data.Services.Extensions.Model.Mutations;
using Unite.Data.Services.Extensions.Model.Mutations.Enums;
using Unite.Data.Services.Extensions.Model.Tasks;
using Unite.Data.Services.Extensions.Model.Tasks.Enums;

namespace Unite.Data.Services
{
    public class UniteDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<User> Users { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }

        public DbSet<File> Files { get; set; }

        public DbSet<Donor> Donors { get; set; }
        public DbSet<PrimarySite> PrimarySites { get; set; }
        public DbSet<ClinicalData> ClinicalData { get; set; }
        public DbSet<EpigeneticsData> EpigeneticsData { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<StudyDonor> StudyDonors { get; set; }
        public DbSet<WorkPackage> WorkPackages { get; set; }
        public DbSet<WorkPackageDonor> WorkPackageDonors { get; set; }

        
        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<AnalysedSample> AnalysedSamples { get; set; }
        public DbSet<MatchedSample> MatchedSamples { get; set; }
        public DbSet<Mutation> Mutations { get; set; }
        public DbSet<MutationOccurrence> MutationOccurrences { get; set; }
        public DbSet<Gene> Genes { get; set; }
        public DbSet<GeneInfo> GeneInfo { get; set; }
        public DbSet<Consequence> Consequences { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<TranscriptInfo> TranscriptInfo { get; set; }
        public DbSet<AffectedTranscript> TranscriptConsequences { get; set; }
        public DbSet<AffectedTranscriptConsequence> AffectedTranscriptConsequences { get; set; }


        public DbSet<Task> Tasks { get; set; }


        public UniteDbContext(ISqlOptions options)
        {
            _connectionString = $"Host={options.Host};Database={options.Database};Username={options.User};Password={options.Password}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseNpgsql(_connectionString, b => b.MigrationsAssembly("Unite.Data.Migrations"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BuildIdentityModels(modelBuilder);

            BuildGeneralModels(modelBuilder);

            BuildDonorModels(modelBuilder);

            BuildEpigeneticsModels(modelBuilder);

            BuildMutationModels(modelBuilder);

            BuildIndexingTaskModels(modelBuilder);
        }

        private void BuildIdentityModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildUserModel();
            modelBuilder.BuildUserSessionModel();
        }

        private void BuildGeneralModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildFileModel();
        }

        private void BuildDonorModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildGenderModel();
            modelBuilder.BuildAgeCategoryModel();
            modelBuilder.BuildVitalStatusModel();

            modelBuilder.BuildDonorModel();
            modelBuilder.BuildPrimarySiteModel();

            modelBuilder.BuildClinicalDataModel();
            modelBuilder.BuildLocalizationModel();

            modelBuilder.BuildTherapyModel();
            modelBuilder.BuildTreatmentModel();

            modelBuilder.BuildStudyModel();
            modelBuilder.BuildStudyDonorModel();

            modelBuilder.BuildWorkPackageModel();
            modelBuilder.BuildWorkPackageDonorModel();
        }

        private void BuildEpigeneticsModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildGeneExpressionSubtypeModel();
            modelBuilder.BuildIDHStatusModel();
            modelBuilder.BuildIDHMutationModel();
            modelBuilder.BuildMethylationStatusModel();
            modelBuilder.BuildMethylationSubtypeModel();

            modelBuilder.BuildEpigeneticsDataModel();
        }

        private void BuildMutationModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildChromosomeModel();
            modelBuilder.BuildSequenceTypeModel();
            modelBuilder.BuildMutationTypeModel();
            modelBuilder.BuildAnalysisTypeModel();
            modelBuilder.BuildSampleTypeModel();
            modelBuilder.BuildSampleSubtypeModel();
            modelBuilder.BuildConsequenceTypeModel();
            modelBuilder.BuildConsequenceImpactModel();

            modelBuilder.BuildAnalysisModel();

            modelBuilder.BuildSampleModel();
            modelBuilder.BuildAnalysedSampleModel();
            modelBuilder.BuildMatchedSampleModel();

            modelBuilder.BuildMutationModel();
            modelBuilder.BuildMutationOccurrenceModel();

            modelBuilder.BuildConsequenceModel();

            modelBuilder.BuildGeneModel();
            modelBuilder.BuildGeneInfoModel();

            modelBuilder.BuildTranscriptModel();
            modelBuilder.BuildTranscriptInfoModel();
            modelBuilder.BuildAffectedTranscriptModel();
            modelBuilder.BuildAffectedTranscriptConsequenceModel();
        }

        private void BuildIndexingTaskModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildTaskTypeModel();
            modelBuilder.BuildTaskTargetTypeModel();

            modelBuilder.BuildTaskModel();
        }
    }
}
