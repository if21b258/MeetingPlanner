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
        private TourModel _selectedTour;
        public ICommand EditTourCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public Dictionary<Transport, string> TransportEnumForCombo { get; } =
            new Dictionary<Transport, string>()
            {
                {Transport.Fastest, "Car"},
                {Transport.Pedestrian, "By Foot"},
                {Transport.Bicycle, "Bicycle" },
            };

        public EditTourViewModel(TourListViewModel tourListViewModel, TourService tourService, TourRouteViewModel tourRouteViewModel)
        {
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourRouteViewModel = tourRouteViewModel;
            _selectedTour = _tourListViewModel.SelectedTour;
            EditTourCommand = new RelayCommand<object>(EditTour);
            CancelCommand = new RelayCommand<object>(Cancel);
            InitializeFields();
        }


        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

                //Errorhandling fehlt noch 
            }
        }

        private string _origin = "";
        public string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;

                //Errorhandling fehlt noch 
            }
        }

        private string _destination = "";
        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;

                //Errorhandling fehlt noch 
            }
        }

        private Transport _transportType = Transport.Fastest;
        public Transport TransportType
        {
            get { return _transportType; }
            set
            {
                _transportType = value;

            }

        }

        private string _description = "";
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;

                //Errorhandling fehlt noch 
            }
        }

        private async void EditTour(object commandParameter)
        {
            if (!String.IsNullOrEmpty(_selectedTour.Name) && !String.IsNullOrEmpty(_selectedTour.Origin) && !String.IsNullOrEmpty(_selectedTour.Destination)
            && !String.IsNullOrEmpty(_selectedTour.Description))
            {
                CloseEvent?.Invoke(true);
                ApplyChanges();
                await _tourService.EditTour(_selectedTour);
                _tourListViewModel.LoadTours();
                _tourListViewModel.OnSelectedTourChanged();
                _tourRouteViewModel.GetImage(_selectedTour);
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }
        }

        private void InitializeFields()
        {
            _name = _selectedTour.Name;
            _origin = _selectedTour.Origin;
            _destination = _selectedTour.Destination;
            _description = _selectedTour.Description;
            _transportType = _selectedTour.TransportType;
        }

        private void ApplyChanges()
        {
            _selectedTour.Name = _name;
            _selectedTour.Origin = _origin;
            _selectedTour.Destination = _destination;
            _selectedTour.Description = _description;
            _selectedTour.TransportType = _transportType;
        }

        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(true);
        }
    }
}
