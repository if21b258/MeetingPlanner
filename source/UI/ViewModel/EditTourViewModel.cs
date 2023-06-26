using Microsoft.Extensions.Primitives;
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
        private TourRouteViewModel _tourRouteViewModel;
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

        public Transport TransportType
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
            && !String.IsNullOrEmpty(_selectedTour.Description))
            {
                CloseEvent?.Invoke(true);
                _tourService.EditTour(_selectedTour);
                _tourListViewModel.LoadTours();
                _tourRouteViewModel.GetImage(_selectedTour);
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }
        }

        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(true);
        }
    }
}
