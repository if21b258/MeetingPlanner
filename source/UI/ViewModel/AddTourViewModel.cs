using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerUI;
using TourPlannerUI.ViewModel;

namespace TourPlanner.source.UI.ViewModel
{
    public class AddTourViewModel : BaseViewModel
    {

        private ICommand _addTourCommand;

        private string _name;

        private string _description;

        private string _origin;

        private int _destination;

        private string _transportType;

        private TourListViewModel _tourListViewModel;


        //public event EventHandler<TourAttribute> AddedTour;

            //public ObservableCollection<TourAttribute> Tours { get; set; }


        public ICommand AddTourCommand => _addTourCommand ??= new RelayCommand<object>(AddTour);

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


        private void AddTour(object commandParameter)
        {
            /*if (!String.IsNullOrEmpty(_tourName) && !String.IsNullOrEmpty(_tourDescription) && !String.IsNullOrEmpty(_tourFrom)
                && !String.IsNullOrEmpty(_tourTo) && !String.IsNullOrEmpty(_tourTransportMode))
            {
                AddedTour?.Invoke(this, new TourItem(_tourName, _tourDescription, _tourFrom, _tourTo, _tourTransportMode));
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }*/
        }
    }
}
