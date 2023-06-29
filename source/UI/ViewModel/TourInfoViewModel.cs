using System;
using TourPlannerBL;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class TourInfoViewModel : BaseViewModel
    {
        private TourListViewModel _tourListViewModel;
        private TourModel? _selectedTour;
        private TourCalculations _tourCalculations = new TourCalculations();

        public TourInfoViewModel(TourListViewModel tourListViewModel)
        {
            _tourListViewModel = tourListViewModel;
            _tourListViewModel.SelectedTourChanged += HandleSelectedTourChanged;
        }

        private void HandleSelectedTourChanged(TourModel selectedTour)
        {
            _selectedTour = selectedTour;
            RaisePropertyChangedEvent(nameof(Name));
            RaisePropertyChangedEvent(nameof(Origin));
            RaisePropertyChangedEvent(nameof(Destination));
            RaisePropertyChangedEvent(nameof(Description));
            RaisePropertyChangedEvent(nameof(TransportType));
            RaisePropertyChangedEvent(nameof(Distance));
            RaisePropertyChangedEvent(nameof(EstimatedTime));
            RaisePropertyChangedEvent(nameof(Id));
            RaisePropertyChangedEvent(nameof(Popularity));
            RaisePropertyChangedEvent(nameof(ChildFriendliness));
        }

        //Get the Attributes from the selected tour for showing it in the general column
        public string? Name
        {
            get { return _selectedTour?.Name; }
        }

        public string? Origin
        {
            get { return _selectedTour?.Origin; }
        }

        public string? Destination
        {
            get { return _selectedTour?.Destination; }
        }

        public string? Description
        {
            get { return _selectedTour?.Description; }
        }

        public Transport? TransportType
        {
            get { return _selectedTour?.TransportType; }
        }

        public float? Distance
        {
            get { return _selectedTour?.Distance; }
        }

        public TimeSpan? EstimatedTime
        {
            get { return _selectedTour?.EstimatedTime; }
        }

        public int? Id
        {
            get { return _selectedTour?.Id; }
        }

        public int? Popularity
        {
            get { return _tourCalculations.GetPopularity(_selectedTour); }
        }

        public float? ChildFriendliness
        {
            get { return _tourCalculations.GetChildFriendliness(_selectedTour); }
        }
    }
}
