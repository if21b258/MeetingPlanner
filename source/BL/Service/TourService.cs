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
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

//This class is managing the data which has been received by the frontend
namespace TourPlannerBL.Service
{
    public class TourService : ITourService
    {
        private TourPlannerDbContext _dbContext;
        private ITourRepository _tourRepo;
        private ITourLogRepository _tourLogRepo;
        private FileService _fileService;

        public TourService(TourPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
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
            _fileService.DeleteImage(tour);
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
            MapQuestService mapQuest = new(tour);
            return await mapQuest.GetWay(tour);
        }

        public void EnsureDatabaseCreated()
        {
            _dbContext.Database.EnsureCreated();
        }

        public void EnsureDatabaseDeleted()
        {
            _dbContext.Database.EnsureDeleted();
        }

        public void ExportTour(TourModel tour, string filePath)
        {

            string jsonString = JsonSerializer.Serialize(tour, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public async Task ImportTour(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            TourModel tour = JsonSerializer.Deserialize<TourModel>(jsonString);
            await AddTour(tour);
        }
    }
}