using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerUI;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.ViewModel
{
    public class AddTourLogViewModel : BaseViewModel
    {
        //private TourItem _currentTour;

        private ICommand _addTourLogCommand;

        private string _date;

        private string _time;

        private string _comment;

        private int _difficulty;

        private string _totalTime;

        private int _rating;

        public ICommand AddTourLogCommand => _addTourLogCommand ??= new RelayCommand<object>(AddTourLog);
        private AddTourLogViewModel(TourLogViewModel tourLogViewModel)
        {
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

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;

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

        public string TotalTime
        {
            get { return _totalTime; }
            set
            {
                _totalTime = value;

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
            /*if (_tourLogDistance != 0 && _tourLogDuration != 0 && !String.IsNullOrEmpty(_tourLogReport)
                && !String.IsNullOrEmpty(_tourLogWeather) && _tourLogTemperature != 0)
            {
                AddedTourLog?.Invoke(this, new TourLogItem(_currentTour.Name, DateTime.Now, _tourLogDistance, _tourLogDuration, _tourLogReport, _tourLogRating, _tourLogFuelUsed, _tourLogWeather, _tourLogTemperature, _tourLogEffort));
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }*/
        }
    }
}
