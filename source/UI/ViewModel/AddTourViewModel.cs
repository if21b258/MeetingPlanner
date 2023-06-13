using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourPlannerUI;
using TourPlannerUI.Model;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.ViewModel
{
    public class AddTourViewModel : BaseViewModel
    {

        private TourListViewModel _tourListViewModel;

        private ICommand _addTourCommand;

        private ICommand _cancelAddTourCommand;

        private string _name;

        private string _origin;

        private string _destination;

        private string _transportType;

        private string _description;

        //public event EventHandler<TourAttribute> TourAdded;

        //public ObservableCollection<TourAttribute> Tours { get; set; }

        public AddTourViewModel(TourListViewModel tourListViewModel)
        {
            _tourListViewModel = tourListViewModel;
        }

        public ICommand AddTourCommand => _addTourCommand ??= new RelayCommand<object>(AddTour);

        public ICommand CancelAddTourCommand => _addTourCommand ??= new RelayCommand<object>(CancelAddTour);

        /*public AddTourLogViewModel(TourAttribute currentTour)
        {
            _currentTour = currentTour;
        }*/

        /*public AddTourViewModel(ObservableCollection<TourAttribute> tours)
        {
            this.Tours = tours;
        }*/

        public string Name
        {
            get { return _name; }

            set
            {
                _name = value;

                //Errorhandling fehlt noch 
            }

        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;

                //Errorhandling fehlt noch 
            }
        }

        public string TransportType
        {
            get { return _transportType; }
            set
            {
                _transportType = value;

                //Errorhandling fehlt noch 
            }
        }


        private void AddTour(object commandParameter)
        {
            if (!String.IsNullOrEmpty(_name) && !String.IsNullOrEmpty(_origin) && !String.IsNullOrEmpty(_destination) 
                && !String.IsNullOrEmpty(_transportType) && !String.IsNullOrEmpty(_description))
                {
                    _tourListViewModel.TourList.Add(new TourModel(_name, _origin, _destination, _transportType, _description));
                }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }
        }

        private void CancelAddTour(object commandParameter)
        {

        }
    }
}
