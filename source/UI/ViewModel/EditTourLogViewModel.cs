using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TourPlannerUI.ViewModel
{
    public class EditTourLogViewModel : BaseViewModel
    {
        //private TourAttribute _currentTour"Log?";
        private ICommand _editTourLogCommand;

        private string _date;

        private string _time;

        private string _comment;

        private int _difficulty;

        private string _totalTime;

        private int _rating;


        //public event EventHandler<TourLogItem> EditedTourLog;


        public ICommand EditTourLogCommand => _editTourLogCommand ??= new RelayCommand<object>(EditTourLog);

        /*public EditTourLogViewModel(TourItem currentTour, TourLogItem currentTourLog)
        {
            _currentTour = currentTour;
            _date = currentTourLog.date;
            _time = currentTourLog.Time;
            _comment = currentTourLog.Comment;
            _difficulty = currentTourLog.difficulty;
            _totalTime = currentTourLog.TotalTime;
            _rating = currentTourLog.Rating;
        }*/

        public string Date
        {
            get { return _date; }

            set
            {
                _date = value;
                //RaisePropertyChangedEvent(nameof(Date));

                //Errorhandling fehlt noch 
            }

        }

        public string Time
        {
            get { return _time; }
            set
            {
                _time = value;
                //RaisePropertyChangedEvent(nameof(Time));

                //Errorhandling fehlt noch 
            }
        }

        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                //RaisePropertyChangedEvent(nameof(Comment));

                //Errorhandling fehlt noch 
            }
        }

        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
                //RaisePropertyChangedEvent(nameof(Difficulty));

                //Errorhandling fehlt noch 
            }
        }

        public string TotalTime
        {
            get { return _totalTime; }
            set
            {
                _totalTime = value;
                //RaisePropertyChangedEvent(nameof(TotalTime));

                //Errorhandling fehlt noch 
            }
        }

        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                //RaisePropertyChangedEvent(nameof(Rating));

                //Errorhandling fehlt noch 
            }
        }

        private void EditTourLog(object commandParameter)
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
