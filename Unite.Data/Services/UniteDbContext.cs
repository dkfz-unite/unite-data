using Microsoft.EntityFrameworkCore;
using Unite.Data.Entities;
using Unite.Data.Entities.Cells;
using Unite.Data.Entities.Donors;
using Unite.Data.Entities.Mutations;
using Unite.Data.Entities.Samples;
using Unite.Data.Entities.Tasks;
using Unite.Data.Services.Configuration.Options;
using Unite.Data.Services.Extensions.Model;
using Unite.Data.Services.Extensions.Model.Cells;
using Unite.Data.Services.Extensions.Model.Cells.Enums;
using Unite.Data.Services.Extensions.Model.Donors;
using Unite.Data.Services.Extensions.Model.Donors.Enums;
using Unite.Data.Services.Extensions.Model.Mutations;
using Unite.Data.Services.Extensions.Model.Mutations.Enums;
using Unite.Data.Services.Extensions.Model.Samples;
using Unite.Data.Services.Extensions.Model.Samples.Enums;
using Unite.Data.Services.Extensions.Model.Tasks;

namespace Unite.Data.Services
{
    public class UniteDbContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<Donor> Donors { get; set; }
        public DbSet<PrimarySite> PrimarySites { get; set; }
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<ClinicalData> ClinicalData { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<Mutation> Mutations { get; set; }
        public DbSet<Gene> Genes { get; set; }
        public DbSet<Contig> Contigs { get; set; }

        public DbSet<CellLine> CellLines { get; set; }
        public DbSet<CellLineInfo> CellLineInfos { get; set; }

        public DbSet<Sample> Samples { get; set; }
        public DbSet<SampleMutation> SampleMutations { get; set; }

        public DbSet<Study> Studies { get; set; }
        public DbSet<StudyDonor> StudyDonors { get; set; }
        public DbSet<WorkPackage> WorkPackages { get; set; }
        public DbSet<WorkPackageDonor> WorkPackageDonors { get; set; }

        public DbSet<DonorIndexingTask> DonorIndexingTasks { get; set; }
        public DbSet<MutationIndexingTask> MutationIndexingTasks { get; set; }
        public DbSet<CellLineIndexingTask> CellLineIndexingTasks { get; set; }


        public UniteDbContext(IMySqlOptions options)
        {
            _connectionString = $"server={options.Host};database={options.Database};user={options.User};password={options.Password}";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseMySQL(_connectionString, b => b.MigrationsAssembly("Unite.Data.Migrations"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Donors
            modelBuilder.BuildGenderModel();
            modelBuilder.BuildAgeCategoryModel();
            modelBuilder.BuildVitalStatusModel();

            modelBuilder.BuildPrimarySiteModel();
            modelBuilder.BuildLocalizationModel();
            modelBuilder.BuildTherapyModel();
            modelBuilder.BuildDonorModel();
            modelBuilder.BuildClinicalDataModel();
            modelBuilder.BuildTreatmentModel();

            // Mutations
            modelBuilder.BuildChromosomeModel();
            modelBuilder.BuildSequenceTypeModel();
            modelBuilder.BuildMutationTypeModel();

            modelBuilder.BuildGeneModel();
            modelBuilder.BuildContigModel();
            modelBuilder.BuildMutationModel();

            // Cells
            modelBuilder.BuildCellLineTypeModel();
            modelBuilder.BuildSpeciesModel();
            modelBuilder.BuildGeneExpressionSubtypeModel();
            modelBuilder.BuildIDHStatusModel();
            modelBuilder.BuildIDHMutationModel();
            modelBuilder.BuildMethylationStatusModel();
            modelBuilder.BuildMethylationSubtypeModel();

            modelBuilder.BuildCellLineModel();
            modelBuilder.BuildCellLineInfoModel();

            // Samples
            modelBuilder.BuildSampleTypeModel();
            modelBuilder.BuildSampleSubtypeModel();

            modelBuilder.BuildSampleModel();
            modelBuilder.BuildSampleMutationModel();
            modelBuilder.BuildVcfDataModel();

            // Studies
            modelBuilder.BuildStudyModel();
            modelBuilder.BuildStudyDonorModel();

            // Work Packages
            modelBuilder.BuildWorkPackageModel();
            modelBuilder.BuildWorkPackageDonorModel();
            
            // Tasks
            modelBuilder.BuildDonorIndexingTaskModel();
            modelBuilder.BuildMutationIndexingTaskModel();
            modelBuilder.BuildCellLineIndexingTaskModel();
        }
    }
}
