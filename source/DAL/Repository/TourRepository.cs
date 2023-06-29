using System.Collections.ObjectModel;
using TourPlannerModel;

namespace TourPlannerDAL.Repository
{
    public class TourRepository : ITourRepository, IDisposable
    {
        private TourPlannerDbContext _dbContext;
        private bool _disposed = false;

        public TourRepository(TourPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTour(TourModel tour)
        {
            _dbContext.Tours.Add(tour);
        }

        public void DeleteTour(TourModel tour)
        {
            _dbContext.Tours.Remove(tour);
        }

        public void UpdateTour(TourModel tour)
        {
            _dbContext.Tours.Update(tour);
        }

        public ObservableCollection<TourModel> GetTours()
        {
            return new ObservableCollection<TourModel>(_dbContext.Tours.ToList());
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
