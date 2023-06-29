using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerBL.Service
{
    internal interface IMapQuestService
    {
        public Task<byte[]> GetWay(TourModel tourModel);
        public Task<byte[]> GetMap(TourModel tourModel);
    }
}
