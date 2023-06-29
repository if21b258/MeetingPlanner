using TourPlannerModel;

namespace TourPlannerBL.Util
{
    //This class validates the Userinput of the tours and tourlogs
    public class TourPlannerValidation
    {

        //Tours
        public bool ValidateTourInput(TourModel tour)
        {
            if (string.IsNullOrEmpty(tour.Name))
            {
                return false;
            }

            if (string.IsNullOrEmpty(tour.Description))
            {
                return false;
            }

            if (string.IsNullOrEmpty(tour.Origin))
            {
                return false;
            }

            if (string.IsNullOrEmpty(tour.Destination))
            {
                return false;
            }

            if (tour.TransportType != Transport.Fastest && tour.TransportType != Transport.Pedestrian && tour.TransportType != Transport.Bicycle)
            {
                return false;
            }

            if (tour.Description.Length > 100)
            {
                return false;
            }

            return true;

        }

        //TourLogs
        public bool ValidateTourLogInput(TourLogModel tourLog)
        {

            if (tourLog.Date == null)
            {
                return false;
            }

            if (tourLog.Duration == null)
            {
                return false;
            }

            if (tourLog.Difficulty < 0 | tourLog.Difficulty > 10)
            {
                return false;
            }

            if (tourLog.Rating < 0 | tourLog.Rating > 5)
            {
                return false;
            }

            if (string.IsNullOrEmpty(tourLog.Comment))
            {
                return false;
            }

            if (tourLog.Comment.Length > 100)
            {
                return false;
            }

            return true;

        }
    }
}
