using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourPlannerUI;
using TourPlannerModel;
using TourPlannerUI.ViewModel;
using TourPlannerBL;
using System.Net;

namespace TourPlannerUI.ViewModel
{
    public class AddTourViewModel : BaseViewModel
    {
        private TourListViewModel _tourListViewModel;
        private TourService _tourServiceOfficer;
        private Validation _validation;
        private string _name = "";
        private string _origin = "";
        private string _destination = "";
        private Transport _transportType;
        private string _description = "";
        public ICommand AddTourCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public AddTourViewModel(TourListViewModel tourListViewModel, TourService TourServiceOff)
        {
            _tourListViewModel = tourListViewModel;
            _tourServiceOfficer = TourServiceOff;
            AddTourCommand = new RelayCommand<object>(AddTour);
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
            get { return _name; }
            set
            {
                _name = value;
            }
        }

        public string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
            }
        }

        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
            }
        }

        public Transport TransportType
        {
            get { return _transportType; }
            set
            {
                _transportType = value;
            }

        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }

        private async void AddTour(object commandParameter)
        {
            try
            {
                if (!String.IsNullOrEmpty(_name) && !String.IsNullOrEmpty(_origin) && !String.IsNullOrEmpty(_destination)
                && !String.IsNullOrEmpty(_description))
                {
                    CloseEvent?.Invoke(true);
                    TourModel tour = new TourModel(_name, _origin, _transportType, _destination, _description);
                    if (_validation.ValidateTourInput(tour))
                    {
                        await _tourServiceOfficer.AddTour(tour);
                        _tourListViewModel.LoadTours();
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
            catch (Exception e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }
        }

        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }
        
    }
}
