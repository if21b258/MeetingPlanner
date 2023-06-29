using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerBL.Service
{
    internal interface IReportService
    {
        public void GenerateTourReport(TourModel tour, string path);
        public void GenerateSummaryReport(ObservableCollection<TourModel> tours, string path);
    }
}
