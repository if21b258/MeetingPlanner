using System.Collections.ObjectModel;
using MeetingPlannerModel;

namespace MeetingPlannerBL.Service
{
    public interface IReportService
    {
        public void GenerateMeetingReport(MeetingModel meeting, string path);
    }
}
