using System;
using System.Windows;
using System.Windows.Input;
using TourPlannerBL.Logging;
using TourPlannerBL.Service;
using TourPlannerBL.Util;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class AddTourLogViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private TourService _tourService;
        private TourLogViewModel _tourLogViewModel;
        private TourModel _selectedTour;
        private TourPlannerValidation _validation = new TourPlannerValidation();
        public ICommand AddTourLogCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public AddTourLogViewModel(TourLogViewModel tourLogViewModel, TourService tourService)
        {
            _tourService = tourService;
            _tourLogViewModel = tourLogViewModel;
            _selectedTour = _tourLogViewModel.SelectedTour;
            AddTourLogCommand = new RelayCommand<object>(AddTourLog);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        private DateTime _date = DateTime.Now;
        public DateTime Date
        {
            get { return _date; }

            set
            {
                _date = value;
            }

        }

        private string _comment = "";
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
            }
        }

        private int _difficulty = 0;
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
            }
        }

        private TimeSpan _duration = new TimeSpan();
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
            }
        }

        private int _rating = 0;
        public int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
            }
        }
        // TourLog will be validated and added to the tourLoglist
        private void AddTourLog(object commandParameter)
        {
            try
            {
                TourLogModel tourLog = new TourLogModel(_selectedTour, _date, _comment, _difficulty, _duration, _rating);

                if (_validation.ValidateTourLogInput(tourLog))
                {
                    log.Info("Adding Tour log for tour with id: " + tourLog.Tour.Id);

                    _tourService.AddTourLog(tourLog);
                    _tourLogViewModel.LoadTourLogs();
                    CloseEvent?.Invoke(true);
                }
                else
                {
                    MessageBox.Show("Your input was invalid, please make sure that your comment is not longer than 100 characters and all fields are filled in");
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                log.Warn($"Add tour log failed: {e.Message}");
            }

        }

        // Window will be closed
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }
    }
}
