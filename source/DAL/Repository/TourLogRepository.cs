using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerDAL.Repository
{
    public class TourLogRepository : ITourLogRepository, IDisposable
    {
        private TourPlannerDbContext _dbContext;
        private bool _disposed = false;

        public TourLogRepository(TourPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTourLog(TourLogModel tourLog)
        {
            _dbContext.TourLogs.Add(tourLog);
        }

        public void DeleteTourLog(TourLogModel tourLog)
        {
            _dbContext.TourLogs.Remove(tourLog);
        }

        public void UpdateTourLog(TourLogModel tourLog)
        {
            _dbContext.TourLogs.Update(tourLog);
        }

        public ObservableCollection<TourLogModel> GetTourLogs(TourModel tour)
        {
            return new ObservableCollection<TourLogModel>(_dbContext.TourLogs.Where(t => t.Tour.Id == tour.Id).ToList());
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
