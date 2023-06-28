using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Input;
using TourPlannerBL;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class EditTourViewModel : BaseViewModel
    {
        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        private TourRouteViewModel _tourRouteViewModel;
        private Validation _validation;
        private TourModel _selectedTour;
        private Transport transport;
        public ICommand EditTourCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public EditTourViewModel(TourListViewModel tourListViewModel, TourService tourService, TourRouteViewModel tourRouteViewModel)
        {
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourRouteViewModel = tourRouteViewModel;
            _selectedTour = _tourListViewModel.SelectedTour;
            EditTourCommand = new RelayCommand<object>(EditTour);
            CancelCommand = new RelayCommand<object>(Cancel);
            _validation = new Validation();
        }
        public Dictionary<Transport, string> TransportEnumForCombo { get; } =
        new Dictionary<Transport, string>()
        {
            {Transport.Fastest, "Car"},
            {Transport.Pedestrian, "By Foot"},
            {Transport.Bicycle, "Bicycle" },
        };
        public string Name
        {
            get { return _selectedTour.Name; }
            set
            {
                _selectedTour.Name = value;
            }
        }

        public string Origin
        {
            get { return _selectedTour.Origin; }
            set
            {
                _selectedTour.Origin = value;
            }
        }

        public string Destination
        {
            get { return _selectedTour.Destination; }
            set
            {
                _selectedTour.Destination = value;
            }
        }

        public Transport TransportType
        {
            get { return _selectedTour.TransportType; }
            set
            {
                _selectedTour.TransportType = value;
            }
        }

        public string Description
        {
            get { return _selectedTour.Description; }
            set
            {
                _selectedTour.Description = value;
            }
        }

        private void EditTour(object commandParameter)
        {
            if (!String.IsNullOrEmpty(_selectedTour.Name) && !String.IsNullOrEmpty(_selectedTour.Origin) && !String.IsNullOrEmpty(_selectedTour.Destination)
            && !String.IsNullOrEmpty(_selectedTour.Description))
            {
                CloseEvent?.Invoke(true);
                if (_validation.ValidateTourInput(_selectedTour))
                {
                    _tourService.EditTour(_selectedTour);
                    _tourListViewModel.LoadTours();
                    _tourRouteViewModel.GetImage(_selectedTour);
                }
                else
                {
                    MessageBox.Show("Your input was invalid, please make sure that your description is not longer than 100 characters");
                }
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }
        }

        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(true);
        }
    }
}
