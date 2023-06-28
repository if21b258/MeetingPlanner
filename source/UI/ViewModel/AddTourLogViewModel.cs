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
using System.Windows;

namespace TourPlannerUI.ViewModel
{
    public class AddTourLogViewModel : BaseViewModel
    {

        private TourService _tourService;
        private TourLogViewModel _tourLogViewModel;
        private TourModel _selectedTour;
        private Validation _validation;
        private DateTime _date = DateTime.Now;
        private string _comment;
        private int _difficulty;
        private TimeSpan _duration;
        private int _rating;
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
            _validation = new Validation();
        }
        //Date
        public DateTime Date
        {
            get { return _date; }

            set
            {
                _date = value;
            }

        }
        //Comment
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
            }
        }
        //Difficulty
        public int Difficulty
        {
            get { return _difficulty; }
            set
            {
                _difficulty = value;
            }
        }
        //Duration
        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
            }
        }
        //Rating
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
                if (!String.IsNullOrEmpty(_comment))
                {
                    CloseEvent?.Invoke(true);
                    TourLogModel tourLog = new TourLogModel(_selectedTour, _date, _comment, _difficulty, _duration, _rating);
                    if (_validation.ValidateTourLogInput(tourLog))
                    {
                        _tourService.AddTourLog(tourLog);
                        _tourLogViewModel.LoadTourLogs();
                    }
                    else
                    {
                        MessageBox.Show("Your input was invalid, please make sure that your comment is not longer than 100 characters");
                    }
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

        // Window will be closed
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }
    }
}
