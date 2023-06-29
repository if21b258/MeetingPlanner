using TourPlannerModel;

namespace TourPlannerBL.Service
{
    public interface IMapQuestService
    {
        public Task<byte[]> GetWay(TourModel tourModel);
        public Task<byte[]> GetMap(TourModel tourModel);
    }
}
