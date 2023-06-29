using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using TourPlannerBL.Logging;
using TourPlannerBL.Service;
using TourPlannerBL.Util;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class AddTourViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private TourListViewModel _tourListViewModel;
        private TourService _tourServiceOfficer;
        private Validation _validation = new Validation();

        public ICommand AddTourCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public AddTourViewModel(TourListViewModel tourListViewModel, TourService TourServiceOff)
        {
            _tourListViewModel = tourListViewModel;
            _tourServiceOfficer = TourServiceOff;
            AddTourCommand = new RelayCommand<object>(AddTour);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        // Enum for handling the values of the combobox
        public Dictionary<Transport, string> TransportEnumForCombo { get; } =
        new Dictionary<Transport, string>()
        {
            {Transport.Fastest, "Car"},
            {Transport.Pedestrian, "By Foot"},
            {Transport.Bicycle, "Bicycle" },
        };

        //Name
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

        // Tour will be validated and added to the tourlist
        private async void AddTour(object commandParameter)
        {
            try
            {
                TourModel tour = new TourModel(_name, _origin, _destination, _transportType, _description);


                if (_validation.ValidateTourInput(tour))
                {
                    log.Info("Adding Tour: " + tour.Name);

                    await _tourServiceOfficer.AddTour(tour);
                    _tourListViewModel.LoadTours();
                    CloseEvent?.Invoke(true);
                }

                else
                {
                    MessageBox.Show("Your input was invalid, please make sure that your description is not longer than 100 characters and all fields are filled");
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                log.Warn($"Add tour failed: {e.Message}");
            }
        }

        // Window will be closed
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }

    }
}
