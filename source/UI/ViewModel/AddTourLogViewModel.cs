using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.source.UI.ViewModel
{
    public class AddTourLogViewModel // vlt noch von etwas erben
    {
        //private TourItem _currentTour;

        private ICommand _addTourLogCommand;
        private ICommand _addTourLogCommand;

        public Action CancelAddTourLog { get; set; }

        private string _date;

        private string _time;

        private string _comment;

        private int _difficulty;

        private string _totalTime;

        private int _rating;

        public ICommand AddTourLogCommand => _addTourLogCommand ??= new RelayCommand(AddTour);
        public ICommand CancelTourLogCommand => _cancelAddTourLogCommand ??= new RelayCommand(CancelAddTourLog);

        /*public AddTourLogViewModel(TourItem currentTour)
        {
            _currentTour = currentTour;
        }*/

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

        /*private void AddTourLog(object commandParameter)
        {
            if (_tourLogDistance != 0 && _tourLogDuration != 0 && !String.IsNullOrEmpty(_tourLogReport)
                && !String.IsNullOrEmpty(_tourLogWeather) && _tourLogTemperature != 0)
            {
                AddedTourLog?.Invoke(this, new TourLogItem(_currentTour.Name, DateTime.Now, _tourLogDistance, _tourLogDuration, _tourLogReport, _tourLogRating, _tourLogFuelUsed, _tourLogWeather, _tourLogTemperature, _tourLogEffort));
            }
            else
            {
                throw new ArgumentException("Please fill in all fields");
            }
        }*/


        private void CancelWindow(object commandParameter)
        {
            if (commandParameter != null)
            {
                (commandParameter as Window).Close();
            }
        }


    }
}
