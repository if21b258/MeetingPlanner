using System.Collections.ObjectModel;
using TourPlannerModel;

namespace TourPlannerDAL.Repository
{
    public interface ITourLogRepository : IDisposable
    {
        void AddTourLog(TourLogModel tourLog);
        void DeleteTourLog(TourLogModel tourLog);
        void UpdateTourLog(TourLogModel tourLog);
        ObservableCollection<TourLogModel> GetTourLogs(TourModel tour);
        void Save();
    }
}
