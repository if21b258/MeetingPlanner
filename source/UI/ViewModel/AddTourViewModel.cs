using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TourPlanner.source.UI.ViewModel
{
    public class AddTourViewModel // vlt noch von etwas erben
    {

        private ICommand _addTourCommand;
        private ICommand _addTourCommand;

        public Action CancelAddTour { get; set; }

        private string _name;

        private string _description;

        private string _origin;

        private int _destination;

        private string _transportType;


        //public event EventHandler<TourAttribute> AddedTour;

        //public ObservableCollection<TourAttribute> Tours { get; set; }


        public ICommand AddTourCommand => _addTourCommand ??= new RelayCommand(AddTour);
        public ICommand CancelTourCommand => _cancelAddTourCommand ??= new RelayCommand(CancelAddTour);

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

        public int Destination
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


        /*private void AddTour(object commandParameter)
        {
            if (!String.IsNullOrEmpty(_tourName) && !String.IsNullOrEmpty(_tourDescription) && !String.IsNullOrEmpty(_tourFrom)
                && !String.IsNullOrEmpty(_tourTo) && !String.IsNullOrEmpty(_tourTransportMode))
            {
                AddedTour?.Invoke(this, new TourItem(_tourName, _tourDescription, _tourFrom, _tourTo, _tourTransportMode));
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }
        }+/


        private void CancelWindow(object commandParameter)
        {
            if (commandParameter != null)
            {
                (commandParameter as Window).Close();
            }
        }


    }
}
