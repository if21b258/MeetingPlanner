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
                TourModel tour = new TourModel(_name, _origin, _transportType, _destination, _description);
                if (_validation.ValidateTourInput(tour))
                {
                    await _tourServiceOfficer.AddTour(tour);
                    _tourListViewModel.LoadTours();
                    CloseEvent?.Invoke(true);
                }
                else
                {
                    MessageBox.Show("Your input was invalid, please make sure that your description is not longer than 100 characters and all fields are filled");
                    throw new ArgumentException("Invalid Input");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Processing failed: {e.Message}");
            }
        }

        // Window will be closed
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }
        
    }
}
