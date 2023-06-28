using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        private Validation _validation;
        public ICommand EditTourLogCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public EditTourLogViewModel(TourLogViewModel tourLogViewModel, TourService tourService)
        {
            _tourService = tourService;
            _tourLogViewModel = tourLogViewModel;
            _selectedTourLog = _tourLogViewModel.SelectedTourLog;
            EditTourLogCommand = new RelayCommand<object>(EditTourLog);
            CancelCommand = new RelayCommand<object>(Cancel);
            _validation = new Validation();
        }

        //Date
        public DateTime Date
        {
            get { return _selectedTourLog.Date; }

            set
            {
                _selectedTourLog.Date = value;
            }

        }

        //Comment
        public string Comment
        {
            get { return _selectedTourLog.Comment; }
            set
            {
                _selectedTourLog.Comment = value;

            }
        }

        //Difficulty
        public int Difficulty
        {
            get { return _selectedTourLog.Difficulty; }
            set
            {
                _selectedTourLog.Difficulty = value;

            }
        }

        //Duration
        public TimeSpan Duration
        {
            get { return _selectedTourLog.Duration; }
            set
            {
                _selectedTourLog.Duration = value;
            }
        }

        //Rating
        public int Rating
        {
            get { return _selectedTourLog.Rating; }
            set
            {
                _selectedTourLog.Rating = value; 
            }
        }

        // new TourLog will be validated and added to the tourLoglist if it has the right input
        private void EditTourLog(object commandParameter)
        {
            try
            {
                if (!String.IsNullOrEmpty(_selectedTourLog.Comment))
                {
                    CloseEvent?.Invoke(true);
                    if (_validation.ValidateTourLogInput(_selectedTourLog))
                    {
                        _tourService.EditTourLog(_selectedTourLog);
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
