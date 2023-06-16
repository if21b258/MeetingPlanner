using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerBL
{
    public class TourService
    {
        //private MapQuest mapQuest = new();
        public TourService() { 
        
        
        }

        public async Task<byte[]> GetMap(TourModel Tour)
        {
            MapQuest mapQuest = new(Tour);
            return await mapQuest.GetMap(Tour);
            


        }
    }
}
