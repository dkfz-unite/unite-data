using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities;
using Unite.Data.Entities.Clinical;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Identity;
using Unite.Data.Entities.Molecular;
using Unite.Data.Entities.Mutations;
using Unite.Data.Entities.Samples;
using Unite.Data.Entities.Samples.Cells;
using Unite.Data.Entities.Samples.Tissues;
using Unite.Data.Entities.Tasks;
using Unite.Data.Services.Configuration.Options;
using Unite.Data.Services.Extensions.Model;
using Unite.Data.Services.Extensions.Model.Clinical;
using Unite.Data.Services.Extensions.Model.Clinical.Enums;
using Unite.Data.Services.Extensions.Model.Donors;
using Unite.Data.Services.Extensions.Model.Identity;
using Unite.Data.Services.Extensions.Model.Molecular;
using Unite.Data.Services.Extensions.Model.Molecular.Enums;
using Unite.Data.Services.Extensions.Model.Mutations;
using Unite.Data.Services.Extensions.Model.Mutations.Enums;
using Unite.Data.Services.Extensions.Model.Samples;
using Unite.Data.Services.Extensions.Model.Samples.Cells;
using Unite.Data.Services.Extensions.Model.Samples.Cells.Enums;
using Unite.Data.Services.Extensions.Model.Samples.Tissues;
using Unite.Data.Services.Extensions.Model.Samples.Tissues.Enums;
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
        public DbSet<Pseudonym> Pseudonyms { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Study> Studies { get; set; }
        public DbSet<StudyDonor> StudyDonors { get; set; }
        public DbSet<WorkPackage> WorkPackages { get; set; }
        public DbSet<WorkPackageDonor> WorkPackageDonors { get; set; }

        public DbSet<ClinicalData> ClinicalData { get; set; }
        public DbSet<MolecularData> MolecularData { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<PrimarySite> PrimarySites { get; set; }

        public DbSet<Sample> Samples { get; set; }
        public DbSet<Tissue> Tissues { get; set; }
        public DbSet<CellLine> CellLines { get; set; }
        public DbSet<CellLineInfo> CellLineInfo { get; set; }

        public DbSet<Analysis> Analyses { get; set; }
        public DbSet<AnalysedSample> AnalysedSamples { get; set; }
        public DbSet<MatchedSample> MatchedSamples { get; set; }
        public DbSet<Mutation> Mutations { get; set; }
        public DbSet<MutationOccurrence> MutationOccurrences { get; set; }
        public DbSet<Gene> Genes { get; set; }
        public DbSet<GeneInfo> GeneInfo { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<TranscriptInfo> TranscriptInfo { get; set; }
        public DbSet<Biotype> Biotypes { get; set; }
        public DbSet<AffectedTranscript> AffectedTranscripts { get; set; }
        public DbSet<AffectedTranscriptConsequence> AffectedTranscriptConsequences { get; set; }
        public DbSet<Consequence> Consequences { get; set; }

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
            BuildClinicalDataModels(modelBuilder);
            BuildMolecularDataModels(modelBuilder);
            BuildSampleModels(modelBuilder);
            BuildMutationModels(modelBuilder);
            BuildTaskModels(modelBuilder);
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
            modelBuilder.BuildDonorModel();
            modelBuilder.BuildPseudonymModel();
            modelBuilder.BuildStudyModel();
            modelBuilder.BuildStudyDonorModel();
            modelBuilder.BuildWorkPackageModel();
            modelBuilder.BuildWorkPackageDonorModel();
        }

        private void BuildClinicalDataModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildGenderModel();

            modelBuilder.BuildClinicalDataModel();
            modelBuilder.BuildPrimarySiteModel();
            modelBuilder.BuildLocalizationModel();
            modelBuilder.BuildTherapyModel();
            modelBuilder.BuildTreatmentModel();
        }

        private void BuildMolecularDataModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildGeneExpressionSubtypeModel();
            modelBuilder.BuildIDHStatusModel();
            modelBuilder.BuildIDHMutationModel();
            modelBuilder.BuildMethylationStatusModel();
            modelBuilder.BuildMethylationSubtypeModel();

            modelBuilder.BuildMolecularDataModel();
        }

        private void BuildSampleModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildSampleModel();

            modelBuilder.BuildTissueTypeModel();
            modelBuilder.BuildTissueModel();

            modelBuilder.BuildCellLineTypeModel();
            modelBuilder.BuildSpeciesModel();
            modelBuilder.BuildCellLineModel();
            modelBuilder.BuildCellLineInfoModel();
        }

        private void BuildMutationModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildChromosomeModel();
            modelBuilder.BuildSequenceTypeModel();
            modelBuilder.BuildMutationTypeModel();
            modelBuilder.BuildAnalysisTypeModel();
            modelBuilder.BuildConsequenceTypeModel();
            modelBuilder.BuildConsequenceImpactModel();

            modelBuilder.BuildAnalysisModel();
            modelBuilder.BuildAnalysedSampleModel();
            modelBuilder.BuildMatchedSampleModel();
            modelBuilder.BuildMutationModel();
            modelBuilder.BuildMutationOccurrenceModel();
            modelBuilder.BuildConsequenceModel();
            modelBuilder.BuildBiotypeModel();
            modelBuilder.BuildGeneModel();
            modelBuilder.BuildGeneInfoModel();
            modelBuilder.BuildTranscriptModel();
            modelBuilder.BuildTranscriptInfoModel();
            modelBuilder.BuildAffectedTranscriptModel();
            modelBuilder.BuildAffectedTranscriptConsequenceModel();
        }

        private void BuildTaskModels(ModelBuilder modelBuilder)
        {
            modelBuilder.BuildTaskTypeModel();
            modelBuilder.BuildTaskTargetTypeModel();

            modelBuilder.BuildTaskModel();
        }
    }
}
