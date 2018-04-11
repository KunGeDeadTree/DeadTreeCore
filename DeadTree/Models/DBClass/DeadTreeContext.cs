namespace DeadTree.Models.DBClass
{
    using Microsoft.EntityFrameworkCore;
    public class DeadTreeContext :DbContext
    {
        public DeadTreeContext(DbContextOptions<DeadTreeContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<ApparatusModel> GetApparatusModels { get; set; }
        public virtual DbSet<ComponentModel> GetComponentModels { get; set; }
        public virtual DbSet<FaultFeaturesModel> GetFaultFeaturesModels { get; set; }
        public virtual DbSet<FaultNameModel> GetFaultNameModels { get; set; }
        public virtual DbSet<ProfessorModel> GetProfessorModels { get; set; }
        public virtual DbSet<FaultResultsModel> GetFaultResultsModels { get; set; }
        public virtual DbSet<FeaturesMappingModel> GetFeaturesMappingModels { get; set; }
        public virtual DbSet<ResultsMappingModel> GetResultsMappingModels { get; set; }
        public virtual DbSet<QuestionsModel> GetQuestionsModels { get; set; }
    }
}
