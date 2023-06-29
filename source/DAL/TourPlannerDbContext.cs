using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TourPlannerModel;

namespace TourPlannerDAL
{
    public class TourPlannerDbContext : DbContext
    {
        public DbSet<TourModel> Tours { get; set; }
        public DbSet<TourLogModel> TourLogs { get; set; }

        public TourPlannerDbContext() { }

        public TourPlannerDbContext(DbContextOptions<TourPlannerDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var isConfigured = optionsBuilder.IsConfigured;

            if (!isConfigured)
            {
                optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["TourPlannerDb"].ConnectionString);
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            }

        }
    }
}
