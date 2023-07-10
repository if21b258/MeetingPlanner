using System.Windows.Input;
using System;
using TourPlannerBL.Logging;
using TourPlannerBL.Service;
using TourPlannerBL.Util;
using System.Text.RegularExpressions;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class SearchBarViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private TourListViewModel _tourListViewModel;
        private TourCalculations _tourCalculations = new TourCalculations();

        public ICommand SearchCommand { get; set; }

        public SearchBarViewModel(TourListViewModel tourListViewModel)
        {
            _tourListViewModel = tourListViewModel;
        }

        private String _searchString = "";
        public String SearchString
        {
            get { return _searchString; }
            set
            {
                if (_searchString != value)
                {
                    _searchString = value;
                    Search();
                }
            }
        }

        private void Search()
        {
            var regex = new Regex(_searchString);

            foreach (TourModel tour in _tourListViewModel.TourList)
            {
                tour.Visible = regex.IsMatch(GetSearchString(tour));
            }

            _tourListViewModel.OnVisibilityChanged();
        }

        public string GetSearchString(TourModel tour)
        {
            string searchString = string.Concat(
                tour.Name,
                tour.Description,
                tour.Origin,
                tour.Destination,
                tour.TransportType,
                tour.Distance,
                tour.EstimatedTime,
                tour.Id,
                _tourCalculations.GetPopularity(tour),
                _tourCalculations.GetChildFriendliness(tour)
                );

            foreach (TourLogModel tourLog in tour.Logs)
            {
                searchString += string.Concat(
                                        tourLog.Id,
                                        tourLog.Date,
                                        tourLog.Comment,
                                        tourLog.Duration,
                                        tourLog.Rating
                                        );
            }

            return searchString;
        }

    }
}
