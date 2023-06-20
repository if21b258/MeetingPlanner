using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using TourPlannerBL;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class EditTourLogViewModel : BaseViewModel
    {
        private TourService _tourService;
        private TourLogViewModel _tourLogViewModel;
        private TourLogModel _selectedTourLog;
        public ICommand EditTourLogCommand { get; set; }

        public EditTourLogViewModel(TourLogViewModel tourLogViewModel, TourService tourService)
        {
            _tourService = tourService;
            _tourLogViewModel = tourLogViewModel;
            _selectedTourLog = _tourLogViewModel.SelectedTourLog;
            EditTourLogCommand = new RelayCommand<object>(EditTourLog);
        }

        public string Date
        {
            get { return _selectedTourLog.Date; }

            set
            {
                _selectedTourLog.Date = value;

                //Errorhandling fehlt noch 
            }

        }

        public string Time
        {
            get { return _selectedTourLog.Time; }
            set
            {
                _selectedTourLog.Time = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Comment
        {
            get { return _selectedTourLog.Comment; }
            set
            {
                _selectedTourLog.Comment = value;

                //Errorhandling fehlt noch 
            }
        }

        public int DMinutes
        {
            get { return _selectedTourLog.DMinutes; }
            set
            {
                _selectedTourLog.DMinutes = value;

            }

        }
        public int DHours
        {
            get { return _selectedTourLog.DHours; }
            set
            {
                _selectedTourLog.DHours = value;

            }

        }
        public int THours
        {
            get { return _selectedTourLog.THours; }
            set
            {
                _selectedTourLog.THours = value;

            }

        }
        public int TMinutes
        {
            get { return _selectedTourLog.TMinutes; }
            set
            {
                _selectedTourLog.TMinutes = value;

            }

        }

        public int Difficulty
        {
            get { return _selectedTourLog.Difficulty; }
            set
            {
                _selectedTourLog.Difficulty = value;

                //Errorhandling fehlt noch 
            }
        }

        public string Duration
        {
            get { return _selectedTourLog.Duration; }
            set
            {
                _selectedTourLog.Duration = value;

                //Errorhandling fehlt noch 
            }
        }

        public int Rating
        {
            get { return _selectedTourLog.Rating; }
            set
            {
                _selectedTourLog.Rating = value;

                //Errorhandling fehlt noch 
            }
        }

        private void EditTourLog(object commandParameter)
        {
            try
            {
                if (!String.IsNullOrEmpty(_selectedTourLog.Date) && !String.IsNullOrEmpty(_selectedTourLog.Comment))
                {
                    _tourService.EditTourLog(_selectedTourLog);
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
