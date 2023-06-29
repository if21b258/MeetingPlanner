using Moq;
using System.Collections.ObjectModel;
using TourPlannerBL.Service;
using TourPlannerModel;
using TourPlannerBL.Util;

namespace TourPlannerTest.BL
{
    public class TourCalculationsTest

    {
        private TourCalculations tourCalculations = new TourCalculations();
        private TourModel tour = new TourModel("name", "origin", "destination", Transport.Fastest, "description");
        private ObservableCollection<TourLogModel> tourLogs = new ObservableCollection<TourLogModel>();

        [SetUp]
        public void Setup()
        {
            tour.Logs = tourLogs;
        }

        [Test]
        public void GIVEN_empty_list_WHEN_GetPopularity_THEN_return_null()
        {
            int? popularity = tourCalculations.GetPopularity(tour);

            Assert.AreEqual(0,popularity);
        }
    }
}
