using Microsoft.EntityFrameworkCore;
using TourPlannerModel;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlannerDAL
{
    public class TourPlannerDbContext : DbContext
    {
        public DbSet<TourModel> Tours { get;  set; }
        public DbSet<TourLogModel> TourLogs { get;  set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["TourPlannerDb"].ConnectionString);
        }
    }
}
