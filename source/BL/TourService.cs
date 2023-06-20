using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;
using System.Drawing;
using System.Net.NetworkInformation;
using TourPlannerDAL;
using TourPlannerDAL.DAO;
using System.Configuration;
using System.Collections.ObjectModel;

namespace TourPlannerBL
{
    public class TourService
    {
        //private MapQuest mapQuest = new();
        private TourDAO _tourDAO;
        private TourLogDAO _tourLogDAO;

        public TourService(TourPlannerDbContext dbContext)
        { 
            _tourDAO = new TourDAO(dbContext);
            _tourLogDAO = new TourLogDAO(dbContext);
        }

        public void AddTour(TourModel tour)
        {
            //TODO Calculate Tour Data
            tour.Distance = "0";
            tour.EstimatedTime = "0";
            tour.RouteInformation = "0";

            _tourDAO.AddTour(tour);
        }

        public void DeleteTour(TourModel tour)
        {
            _tourDAO.DeleteTour(tour);
        }

        public void EditTour(TourModel tour)
        {
            //TODO Calculate  Tour Data
            tour.Distance = "0";
            tour.EstimatedTime = "0";
            tour.RouteInformation = "0";

            _tourDAO.UpdateTour(tour);
        }

        public ObservableCollection<TourModel> GetTours()
        {
            return _tourDAO.GetTours();
        }

        public void AddTourLog(TourLogModel tourLog)
        {
            //TODO Calculate TourLog Data

            _tourLogDAO.AddTourLog(tourLog);
        }

        public void DeleteTourLog(TourLogModel tourLog)
        {
            _tourLogDAO.DeleteTourLog(tourLog);
        }

        public void EditTourLog(TourLogModel tourLog)
        {
            //TODO Calculate  TourLog Data


            _tourLogDAO.UpdateTourLog(tourLog);
        }

        public ObservableCollection<TourLogModel> GetTourLogs(TourModel tour)
        {
            return _tourLogDAO.GetTourLogs(tour);
        }

        public async Task GetMap(TourModel Tour)
        {
            MapQuest mapQuest = new(Tour);
            TourModel touri; 
            touri = await mapQuest.GetWay(Tour);
            SaveImageToFile(touri);
            


        }
        public void SaveImageToFile(TourModel Tour)
        {
            string filePath;
            filePath= "C:\\Users\\rif1wi\\Desktop\\FHTW\\TourPlanner\\source\\Ressources\\";
            try
            {
                using (MemoryStream fileStream = new MemoryStream(Tour.Map))
                {
                    
                    var image = Image.FromStream(fileStream);
                    image.Save(filePath + Tour.Name + Tour.Id + ".png");

                }
                Console.WriteLine("Bild erfolgreich gespeichert: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern des Bildes: " + ex.Message);
            }
        }
    }
}
