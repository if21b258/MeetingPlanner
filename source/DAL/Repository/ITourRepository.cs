using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerDAL.Repository
{
    public interface ITourRepository : IDisposable
    {
        void AddTour(TourModel tour);
        void DeleteTour(TourModel tour);
        void UpdateTour(TourModel tour);
        ObservableCollection<TourModel> GetTours();
        void Save();
    }
}
