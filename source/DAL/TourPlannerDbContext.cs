using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TourPlannerModel;

namespace TourPlannerDAL
{
    public class TourPlannerDbContext : DbContext
    {
        public DbSet<TourModel> Tours { get; set; }
        public DbSet<TourLogModel> TourLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["TourPlannerDb"].ConnectionString);
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
    }
}
