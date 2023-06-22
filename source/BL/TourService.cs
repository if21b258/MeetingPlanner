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
using static System.Net.Mime.MediaTypeNames;

namespace TourPlannerBL
{
    public class TourService
    {
        private ITourRepository _tourRepo;
        private ITourLogRepository _tourLogRepo;
        private FileService _fileService;

        public TourService(TourPlannerDbContext dbContext)
        {
            _tourRepo = new TourRepository(dbContext);
            _tourLogRepo = new TourLogRepository(dbContext);
            _fileService = new FileService();
        }

        public async Task AddTour(TourModel tour)
        {
            byte[] image = await GetMap(tour);
            _tourRepo.AddTour(tour);
            _tourRepo.Save();
            _fileService.SaveImageToFile(image, tour);

        }

        public void DeleteTour(TourModel tour)
        {
            _tourRepo.DeleteTour(tour);
            _tourRepo.Save();
        }

        public async Task EditTour(TourModel tour)
        {
            byte[] image = await GetMap(tour);
            _tourRepo.UpdateTour(tour);
            _tourRepo.Save();
            _fileService.SaveImageToFile(image, tour);
        }

        public ObservableCollection<TourModel> GetTours()
        {
            return _tourRepo.GetTours();
        }

        public void AddTourLog(TourLogModel tourLog)
        {
            //TODO Calculate TourLog Data

            _tourLogRepo.AddTourLog(tourLog);
            _tourLogRepo.Save();
        }

        public void DeleteTourLog(TourLogModel tourLog)
        {
            _tourLogRepo.DeleteTourLog(tourLog);
            _tourLogRepo.Save();
        }

        public void EditTourLog(TourLogModel tourLog)
        {
            //TODO Calculate  TourLog Data


            _tourLogRepo.UpdateTourLog(tourLog);
            _tourLogRepo.Save();
        }

        public ObservableCollection<TourLogModel> GetTourLogs(TourModel tour)
        {
            return _tourLogRepo.GetTourLogs(tour);
        }

        public async Task<byte[]> GetMap(TourModel tour)
        {
            MapQuest mapQuest = new(tour);
            return await mapQuest.GetWay(tour);
        }
    }
}
