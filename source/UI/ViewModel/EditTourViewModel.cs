using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using TourPlannerUI.Model;

namespace TourPlannerUI.ViewModel
{
    public class EditTourViewModel : BaseViewModel
    {
        private TourListViewModel _tourListViewModel;

        public ICommand EditTourCommand { get; set; }

        private string? _name;
        private string? _origin;
        private string? _destination;
        private string? _transportType;
        private string? _description;

        private TourModel _selectedTour;

        public EditTourViewModel(TourListViewModel tourListViewModel)
        {
            _tourListViewModel = tourListViewModel;
            _selectedTour = _tourListViewModel.SelectedTour;
            EditTourCommand = new RelayCommand<object>(EditTour);
        }

        public string Name
        {
            get { return _selectedTour.Name; }
            set
            {
                _name = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Origin
        {
            get { return _selectedTour.Origin; }
            set
            {
                _origin = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Destination
        {
            get { return _selectedTour.Destination; }
            set
            {
                _destination = value;

                //Errorhandling fehlt noch 
            }
        }

        public string TransportType
        {
            get { return _selectedTour.TransportType; }
            set
            {
                _transportType = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Description
        {
            get { return _selectedTour.Description; }
            set
            {
                _description = value;

                //Errorhandling fehlt noch 
            }
        }

        private void EditTour(object commandParameter)
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
    }
}
