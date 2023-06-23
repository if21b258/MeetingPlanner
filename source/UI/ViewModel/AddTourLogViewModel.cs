﻿using System;
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
        }

        public DateTime Date
        {
            get { return _date; }

            set
            {
                _date = value;

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

        public TimeSpan Duration
        {
            get { return _duration; }
            set
            {
                _duration = value;
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
                if (!String.IsNullOrEmpty(_comment))
                {
                    CloseEvent?.Invoke(true);
                    TourLogModel tourLog = new TourLogModel(_selectedTour, _date, _comment, _difficulty, _duration, _rating);
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

        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }
    }
}
