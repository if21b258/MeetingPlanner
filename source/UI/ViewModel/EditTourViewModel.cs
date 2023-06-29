using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TourPlannerModel;
using TourPlannerBL;
using TourPlannerBL.Logging;

namespace TourPlannerUI.ViewModel
{
    public class EditTourViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        private TourRouteViewModel _tourRouteViewModel;
        private Validation _validation = new Validation();
        private TourModel _selectedTour;
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
            InitializeFields();
        }

        public Dictionary<Transport, string> TransportEnumForCombo { get; } =
            new Dictionary<Transport, string>()
            {
                {Transport.Fastest, "Car"},
                {Transport.Pedestrian, "By Foot"},
                {Transport.Bicycle, "Bicycle" },
            };

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        //Origin
        private string _origin = "";
        public string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
            }
        }

        //Destination
        private string _destination = "";
        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
            }
        }

        //TransportType
        private Transport _transportType = Transport.Fastest;
        public Transport TransportType
        {
            get { return _transportType; }
            set
            {
                _transportType = value;
            }

        }

        //Description
        private string _description = "";
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        // Tour will be validated and the tourlist will be updated if it has the right userinput
        private async void EditTour(object commandParameter)
        {
            try
            {
                TourModel temp = new TourModel();
                ApplyChanges(temp);
                if (_validation.ValidateTourInput(temp))
                {
                    log.Info("Editing Tour: " + _selectedTour.Name);

                    ApplyChanges(_selectedTour);
                    await _tourService.EditTour(_selectedTour);
                    _tourListViewModel.LoadTours();
                    _tourListViewModel.OnSelectedTourChanged();
                    _tourRouteViewModel.GetImage(_selectedTour);
                    CloseEvent?.Invoke(true);
                }
                else
                {
                    MessageBox.Show("Your input was invalid, please make sure that your description is not longer than 100 characters and all fields are filled in");
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                log.Warn($"Edit tour failed: {e.Message}");
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

        private void ApplyChanges(TourModel tour)
        {
            tour.Name = _name;
            tour.Origin = _origin;
            tour.Destination = _destination;
            tour.Description = _description;
            tour.TransportType = _transportType;
        }

        // Window will be closed
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(true);
        }
    }
}
