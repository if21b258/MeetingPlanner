using Moq;
using System.Collections.ObjectModel;
using TourPlannerBL.Service;
using TourPlannerModel;
using TourPlannerBL.Util;
using System.Windows;

namespace TourPlannerTest.BL
{
    public class TourCalculationsTest

    {
        private TourCalculations tourCalculations = new TourCalculations();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GIVEN_null_WHEN_GetPopularity_THEN_return_null()
        {
            int? result = tourCalculations.GetPopularity(null);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_tourLogs_is_null_WHEN_GetPopularity_THEN_return_null()
        {
            TourModel tour = new TourModel();

            int? result = tourCalculations.GetPopularity(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logs_WHEN_GetPopularity_THEN_return_count_of_logs()
        {
            TourModel tour = new TourModel();
            tour.Logs = new ObservableCollection<TourLogModel>();

            int? result;
            for (int i = 0; i < 5; i++)
            {
                result = tourCalculations.GetPopularity(tour);

                Assert.AreEqual(i, result);

                tour.Logs.Add(new TourLogModel());
            }
        }

        [Test]
        public void GIVEN_null_WHEN_GetChildFriendliness_THEN_return_null()
        {
            float? result = tourCalculations.GetChildFriendliness(null);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_tourLogs_is_null_WHEN_GetChildFriendliness_THEN_return_null()
        {
            TourModel tour = new TourModel();

            float? result = tourCalculations.GetChildFriendliness(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logCount_is_zero_WHEN_GetChildFriendliness_THEN_return_null()
        {
            TourModel tour = new TourModel();
            tour.Logs = new ObservableCollection<TourLogModel>();

            float? result = tourCalculations.GetChildFriendliness(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logs_WHEN_GetChildFriendliness_THEN_return_value()
        {
            TourModel tour = new TourModel { Distance=1 };
            TourLogModel tourLog1 = new TourLogModel { Difficulty = 1, Duration = TimeSpan.Parse("01:00:00") };
            TourLogModel tourLog2 = new TourLogModel { Difficulty = 1, Duration = TimeSpan.Parse("01:00:00") };
            tour.Logs = new ObservableCollection<TourLogModel> { tourLog1, tourLog2 };

            float? result = tourCalculations.GetChildFriendliness(tour);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GIVEN_null_WHEN_GetAverageDuration_THEN_return_null()
        {
            TimeSpan? result = tourCalculations.GetAverageDuration(null);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_tourLogs_is_null_WHEN_GetAverageDuration_THEN_return_null()
        {
            TourModel tour = new TourModel();

            TimeSpan? result = tourCalculations.GetAverageDuration(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logCount_is_zero_WHEN_GetAverageDuration_THEN_return_null()
        {
            TourModel tour = new TourModel();
            tour.Logs = new ObservableCollection<TourLogModel>();

            TimeSpan? result = tourCalculations.GetAverageDuration(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logs_WHEN_GetAverageDuration_THEN_return_average()
        {
            TourModel tour = new TourModel();
            TourLogModel tourLog1 = new TourLogModel { Duration = TimeSpan.Parse("01:00:00") };
            TourLogModel tourLog2 = new TourLogModel { Duration = TimeSpan.Parse("01:00:00") };
            tour.Logs = new ObservableCollection<TourLogModel> { tourLog1, tourLog2 };

            TimeSpan? result = tourCalculations.GetAverageDuration(tour);

            Assert.AreEqual(TimeSpan.Parse("01:00:00"), result);
        }

        [Test]
        public void GIVEN_null_WHEN_GetAverageDifficulty_THEN_return_null()
        {
            float? result = tourCalculations.GetAverageDifficulty(null);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_tourLogs_is_null_WHEN_GetAverageDifficulty_THEN_return_null()
        {
            TourModel tour = new TourModel();

            float? result = tourCalculations.GetAverageDifficulty(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logCount_is_zero_WHEN_GetAverageDifficulty_THEN_return_null()
        {
            TourModel tour = new TourModel();
            tour.Logs = new ObservableCollection<TourLogModel>();

            float? result = tourCalculations.GetAverageDifficulty(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logs_WHEN_GetAverageDifficulty_THEN_return_average()
        {
            TourModel tour = new TourModel();
            TourLogModel tourLog1 = new TourLogModel { Difficulty = 1 };
            TourLogModel tourLog2 = new TourLogModel { Difficulty = 1 };
            tour.Logs = new ObservableCollection<TourLogModel> { tourLog1, tourLog2 };

            float? result = tourCalculations.GetAverageDifficulty(tour);

            Assert.AreEqual(1, result);
        }

        [Test]
        public void GIVEN_null_WHEN_GetAverageRating_THEN_return_null()
        {
            float? result = tourCalculations.GetAverageRating(null);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_tourLogs_is_null_WHEN_GetAverageRating_THEN_return_null()
        {
            TourModel tour = new TourModel();

            float? result = tourCalculations.GetAverageRating(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logCount_is_zero_WHEN_GetAverageRating_THEN_return_null()
        {
            TourModel tour = new TourModel();
            tour.Logs = new ObservableCollection<TourLogModel>();

            float? result = tourCalculations.GetAverageRating(tour);

            Assert.IsNull(result);
        }

        [Test]
        public void GIVEN_tour_with_logs_WHEN_GetAverageRating_THEN_return_average()
        {
            TourModel tour = new TourModel();
            TourLogModel tourLog1 = new TourLogModel { Rating = 1 };
            TourLogModel tourLog2 = new TourLogModel { Rating = 1 };
            tour.Logs = new ObservableCollection<TourLogModel> { tourLog1, tourLog2 };

            float? result = tourCalculations.GetAverageRating(tour);

            Assert.AreEqual(1, result);
        }
    }
}
