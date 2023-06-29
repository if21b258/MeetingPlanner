using System.Collections.ObjectModel;
using TourPlannerModel;

namespace TourPlannerBL.Service
{
    internal interface ITourService
    {
        public Task AddTour(TourModel tour);
        public void DeleteTour(TourModel tour);
        public Task EditTour(TourModel tour);
        public ObservableCollection<TourModel> GetTours();
        public void AddTourLog(TourLogModel tourLog);
        public void DeleteTourLog(TourLogModel tourLog);
        public void EditTourLog(TourLogModel tourLog);
        public ObservableCollection<TourLogModel> GetTourLogs(TourModel tour);
        public Task<byte[]> GetMap(TourModel tour);
        public void EnsureDatabaseCreated();
        public void EnsureDatabaseDeleted();
        public void ExportTour(TourModel tour, string filePath);
        public Task ImportTour(string filePath);

    }
}
