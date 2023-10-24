using Microsoft.EntityFrameworkCore;
using System.Configuration;
using MeetingPlannerModel;

namespace MeetingPlannerDAL
{
    public class MeetingPlannerDbContext : DbContext
    {
        public DbSet<MeetingModel> Meetings { get; set; }
        public DbSet<MeetingNoteModel> MeetingNotes { get; set; }

        public MeetingPlannerDbContext() { }

        public MeetingPlannerDbContext(DbContextOptions<MeetingPlannerDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var isConfigured = optionsBuilder.IsConfigured;

            if (!isConfigured)
            {
                optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["MeetingPlannerDb"].ConnectionString);
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            }

        }
    }
}
