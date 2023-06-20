using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;
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
            var tour = await mapQuest.GetMap(Tour);


        }
    }
}
