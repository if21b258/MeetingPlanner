using System.Collections.ObjectModel;
using TourPlannerModel;

namespace TourPlannerBL.Service
{
    internal interface IReportService
    {
        public void GenerateTourReport(TourModel tour, string path);
        public void GenerateSummaryReport(ObservableCollection<TourModel> tours, string path);
    }
}
