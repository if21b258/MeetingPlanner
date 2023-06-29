using TourPlannerBL.Util;
using TourPlannerModel;

namespace TourPlannerBL.Util
{
    public class TourCalculations
    {
        public int? GetPopularity(TourModel? tour)
        {
            if (tour == null) { return null; }

            if (tour.Logs == null) { return null; }

            return tour.Logs.Count();
        }

        public float? GetChildFriendliness(TourModel? tour)
        {
            if (tour == null) { return null; }

            if (tour.Logs == null) { return null; }

            if (tour.Logs.Count == 0) { return null; }

            int logCount = tour.Logs.Count();
            int difficultySum = tour.Logs.Sum(log => log.Difficulty);
            TimeSpan durationSum = tour.Logs.Sum(log => log.Duration);
            float difficulty = difficultySum / logCount;
            float duration = (float)durationSum.TotalHours / logCount;
            float distance = tour.Distance;

            //random child friendliness calculation (please improve if motivated)
            return difficulty * duration * distance;
        }

        public TimeSpan? GetAverageDuration(TourModel tour)
        {
            if (tour.Logs == null) { return null; }

            if (tour.Logs.Count == 0) { return null; }

            return tour.Logs.Average(log => log.Duration);
        }

        public float? GetAverageDifficulty(TourModel tour)
        {
            if (tour.Logs == null) { return null; }

            if (tour.Logs.Count == 0) { return null; }

            return tour.Logs.Average(log => (float)log.Difficulty);
        }

        public float? GetAverageRating(TourModel tour)
        {
            if (tour.Logs == null) { return null; }

            if (tour.Logs.Count == 0) { return null; }

            return tour.Logs.Average(log => (float)log.Rating);
        }
    }
}
