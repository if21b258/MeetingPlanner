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

namespace TourPlannerUI.ViewModel
{
    public class AddTourViewModel : BaseViewModel
    {
        private TourListViewModel _tourListViewModel;

        public ICommand AddTourCommand { get; set; }

        private string _name;

        private string _origin;

        private string _destination;

        private string _transportType;

        private string _description;

        //public event EventHandler<TourModel> GetMapByRequest;

        //private MapQuest _mapQuest;

        private TourService _tourServiceOfficer;


        public AddTourViewModel(TourListViewModel tourListViewModel, TourService TourServiceOff)
        {
            _tourListViewModel = tourListViewModel;
            AddTourCommand = new RelayCommand<object>(AddTour);
            _tourServiceOfficer = TourServiceOff;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;

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

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;

                //Errorhandling fehlt noch 
            }
        }

        private void AddTour(object commandParameter)
        {
            try
            {
                if (!String.IsNullOrEmpty(_name) && !String.IsNullOrEmpty(_origin) && !String.IsNullOrEmpty(_destination)
                && !String.IsNullOrEmpty(_transportType) && !String.IsNullOrEmpty(_description))
                {
                    _tourListViewModel.TourList.Add(new TourModel(_name, _origin, _destination, _transportType, _description));
                    TourModel touri = _tourListViewModel.TourList.Last();
                    _tourServiceOfficer.AddTour(touri);
                    var tour = _tourServiceOfficer.GetMap(touri);

                    //GetMapByRequest?.Invoke(this, touri); //Mapcall  

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
    }
}
