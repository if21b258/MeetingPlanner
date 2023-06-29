using TourPlannerModel;

namespace TourPlannerBL.Service
{
    internal interface IMapQuestService
    {
        public Task<byte[]> GetWay(TourModel tourModel);
        public Task<byte[]> GetMap(TourModel tourModel);
    }
}
