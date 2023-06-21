using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerUI;
using TourPlannerModel;
using TourPlannerUI.ViewModel;
using TourPlannerBL;

namespace TourPlannerUI.ViewModel
{
    public class AddTourLogViewModel : BaseViewModel
    {

        private TourService _tourService;
        private TourLogViewModel _tourLogViewModel;
        private TourModel _selectedTour;
        private string _date;
        private int _hours;
        private int _minutes;
        private string _comment;
        private int _difficulty;
        private int _durationHours;
        private int _durationMinutes;
        private int _rating;
        public ICommand AddTourLogCommand { get; set; }

        public AddTourLogViewModel(TourLogViewModel tourLogViewModel, TourService tourService)
        {
            _tourService = tourService;
            _tourLogViewModel = tourLogViewModel;
            _selectedTour = _tourLogViewModel.SelectedTour;
            AddTourLogCommand = new RelayCommand<object>(AddTourLog);
        }

        public string Date
        {
            get { return _date; }

            set
            {
                _date = value;

                //Errorhandling fehlt noch 
            }

        }

        public int Hours
        {
            get { return _hours; }
            set
            {
                _hours = value;

                //Errorhandling fehlt noch 
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                _minutes = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;

                //Errorhandling fehlt noch 
            }
        }

        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;

                //Errorhandling fehlt noch 
            }
        }

        public int DurationHours
        {
            get { return _durationHours; }
            set
            {
                _durationHours = value;

                //Errorhandling fehlt noch 
            }
        }

        public int DurationMinutes
        {
            get { return _durationMinutes; }
            set
            {
                _durationMinutes = value;

                //Errorhandling fehlt noch 
            }
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;

                //Errorhandling fehlt noch 
            }
        }

        private void AddTourLog(object commandParameter)
        {
            try
            {
                if (!String.IsNullOrEmpty(_date) && !String.IsNullOrEmpty(_comment))
                {
                    TourLogModel tourLog = new TourLogModel(_selectedTour, _date, _hours, _minutes, _comment, _difficulty, _durationHours, _durationMinutes, _rating);
                    _tourService.AddTourLog(tourLog);
                    _tourLogViewModel.LoadTourLogs();
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
