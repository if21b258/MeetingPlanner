using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerUI.Model;

namespace TourPlannerUI.ViewModel
{
    public class EditTourViewModel : BaseViewModel
    {
        private ICommand _editTourCommand;

        private string _name;

        private string _description;

        private string _origin;

        private int _destination;

        private string _transportType;


        //public event EventHandler<TourAttribute> AddedTour;

        //public ObservableCollection<TourAttribute> Tours { get; set; }


        public ICommand EditTourCommand => _editTourCommand ??= new RelayCommand<object>(EditTour);



        /*public ObservableCollection<TourAttribute> Tours { get; set; }*/

        /*public EditTourViewModel(TourAttribute currentTour, ObservableCollection<TourAttribute> tours)
        {
            Tours = tours;
            _name = currentTour.Name;
            _description = currentTour.Description;
            _origin = currentTour.Origin;
            _destination = currentTour.Destination;
            _transportType = currentTour.TransportType;
        }*/


        public string Name
        {
            get { return _name; }

            set
            {
                _name = value;
                RaisePropertyChangedEvent(nameof(Name));

                //Errorhandling fehlt noch 
            }

        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                //RaisePropertyChangedEvent(nameof(Description));

                //Errorhandling fehlt noch 
            }
        }

        public string Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
                //RaisePropertyChangedEvent(nameof(Origin));
                //oder
                //RaisePropertyChangedEvent<object>(nameof(Origin));

                //Errorhandling fehlt noch 
            }
        }

        public int Destination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                //RaisePropertyChangedEvent(nameof(Destination));

                //Errorhandling fehlt noch 
            }
        }

        public string TransportType
        {
            get { return _transportType; }
            set
            {
                _transportType = value;
                //RaisePropertyChangedEvent(nameof(TransportType));

                //Errorhandling fehlt noch 
            }
        }


        private void EditTour(object commandParameter)
        {
            /*if (!String.IsNullOrEmpty(_tourName) && !String.IsNullOrEmpty(_tourDescription) && !String.IsNullOrEmpty(_tourFrom)
                && !String.IsNullOrEmpty(_tourTo) && !String.IsNullOrEmpty(_tourTransportMode))
            {
                EditededTour?.Invoke(this, new TourItem(_tourName, _tourDescription, _tourFrom, _tourTo, _tourTransportMode));
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }*/
        }
    }
}
