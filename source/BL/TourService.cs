using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;
using System.Drawing;
using System.Net.NetworkInformation;
using TourPlannerDAL;
using TourPlannerDAL.Repository;
using System.Configuration;
using System.Collections.ObjectModel;

namespace TourPlannerBL
{
    public class TourService
    {
        private TourRepository _tourRepo;
        private TourLogRepository _tourLogRepo;
        private FileService _fileService;

        public TourService(TourPlannerDbContext dbContext)
        { 
            _tourRepo = new TourRepository(dbContext);
            _tourLogRepo = new TourLogRepository(dbContext);
            _fileService = new FileService();
        }

        public async Task AddTour(TourModel tour)
        {
            MapQuest mapQuest = new(tour);
            //TourModel tour; 
            byte[] image = await mapQuest.GetWay(tour);
            _tourRepo.AddTour(tour);
            _fileService.SaveImageToFile(image, tour);
        }

        public void DeleteTour(TourModel tour)
        {
            _tourRepo.DeleteTour(tour);
        }

        public void EditTour(TourModel tour)
        {
            //TODO Calculate  Tour Data
            tour.Distance = 0;
            tour.EstimatedTime = 0;

            _tourRepo.UpdateTour(tour);
        }

        public ObservableCollection<TourModel> GetTours()
        {
            return _tourRepo.GetTours();
        }

        public void AddTourLog(TourLogModel tourLog)
        {
            //TODO Calculate TourLog Data

            _tourLogRepo.AddTourLog(tourLog);
        }

        public void DeleteTourLog(TourLogModel tourLog)
        {
            _tourLogRepo.DeleteTourLog(tourLog);
        }

        public void EditTourLog(TourLogModel tourLog)
        {
            //TODO Calculate  TourLog Data


            _tourLogRepo.UpdateTourLog(tourLog);
        }

        public ObservableCollection<TourLogModel> GetTourLogs(TourModel tour)
        {
            return _tourLogRepo.GetTourLogs(tour);
        }
    }
}
