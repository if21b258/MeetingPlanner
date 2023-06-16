using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;
using TourPlannerDAL;
using TourPlannerDAL.DAO;
using System.Configuration;

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
            //Calculate Tour Data
            tour.Distance = "0";
            tour.EstimatedTime = "0";
            tour.RouteInformation = "0";

            _tourDAO.AddTour(tour);
        }

        public async Task GetMap(TourModel Tour)
        {
            MapQuest mapQuest = new(Tour);
            var tour = await mapQuest.GetMap(Tour);


        }
    }
}
