using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class TourInfoViewModel : BaseViewModel
    {
        private TourListViewModel _tourListViewModel;
        private TourModel? _selectedTour;

        public TourInfoViewModel(TourListViewModel tourListViewModel)
        {
            _tourListViewModel = tourListViewModel;
            _tourListViewModel.SelectedTourChanged += HandleSelectedTourChanged;
        }

        private void HandleSelectedTourChanged(TourModel selectedTour)
        {
            if (_selectedTour != selectedTour)
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
            }
        }

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

        public float? EstimatedTime
        {
            get { return _selectedTour?.EstimatedTime; }
        }

        public int? Id
        {
            get { return _selectedTour?.Id; }
        }
    }
}
