using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerDAL.Repository
{
    public class TourRepository
    {
        private TourPlannerDbContext _dbContext;

        public TourRepository(TourPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTour(TourModel tour)
        {
            _dbContext.Tours.Add(tour);
            _dbContext.SaveChanges();
        }

        public void DeleteTour(TourModel tour)
        {
            _dbContext.Tours.Remove(tour);
            _dbContext.SaveChanges();
        }

        public void UpdateTour(TourModel tour)
        {
            _dbContext.Tours.Update(tour);
            _dbContext.SaveChanges();
        }

        public ObservableCollection<TourModel> GetTours()
        {
            return new ObservableCollection<TourModel>(_dbContext.Tours.ToList());
        }





    }
}
