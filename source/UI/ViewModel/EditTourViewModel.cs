using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using TourPlannerBL;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class EditTourViewModel : BaseViewModel
    {
        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        private TourModel _selectedTour;

        public ICommand EditTourCommand { get; set; }

        public EditTourViewModel(TourListViewModel tourListViewModel, TourService tourService)
        {
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _selectedTour = _tourListViewModel.SelectedTour;
            EditTourCommand = new RelayCommand<object>(EditTour);
        }

        public string Name
        {
            get { return _selectedTour.Name; }
            set
            {
                _selectedTour.Name = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Origin
        {
            get { return _selectedTour.Origin; }
            set
            {
                _selectedTour.Origin = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Destination
        {
            get { return _selectedTour.Destination; }
            set
            {
                _selectedTour.Destination = value;

                //Errorhandling fehlt noch 
            }
        }

        public string TransportType
        {
            get { return _selectedTour.TransportType; }
            set
            {
                _selectedTour.TransportType = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Description
        {
            get { return _selectedTour.Description; }
            set
            {
                _selectedTour.Description = value;

                //Errorhandling fehlt noch 
            }
        }

        private void EditTour(object commandParameter)
        {
            if (!String.IsNullOrEmpty(_selectedTour.Name) && !String.IsNullOrEmpty(_selectedTour.Origin) && !String.IsNullOrEmpty(_selectedTour.Destination)
                && !String.IsNullOrEmpty(_selectedTour.TransportType) && !String.IsNullOrEmpty(_selectedTour.Description))
            {
                _tourService.EditTour(_selectedTour);
                _tourListViewModel.LoadTours();
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }
        }
    }
}
