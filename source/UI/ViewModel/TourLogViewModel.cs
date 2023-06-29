using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TourPlannerBL.Logging;
using TourPlannerBL.Service;
using TourPlannerModel;
using TourPlannerUI.View;


namespace TourPlannerUI.ViewModel
{
    public class TourLogViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        public ICommand AddTourLogCommand { get; set; }
        public ICommand DeleteTourLogCommand { get; set; }
        public ICommand EditTourLogCommand { get; set; }
        public event Action<TourLogModel?>? SelectedTourLogChanged;

        public TourLogViewModel(TourListViewModel tourListViewModel, TourService tourService)
        {
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourListViewModel.SelectedTourChanged += HandleSelectedTourChanged;
            AddTourLogCommand = new RelayCommand<object>(AddTourLog);
            DeleteTourLogCommand = new RelayCommand<object>(DeleteTourLog);
            EditTourLogCommand = new RelayCommand<object>(EditTourLog);
        }

        private TourModel? _selectedTour;
        public TourModel? SelectedTour
        {
            get { return _selectedTour; }
        }

        private ObservableCollection<TourLogModel> _tourLogList = new ObservableCollection<TourLogModel>();
        public ObservableCollection<TourLogModel> TourLogList
        {
            get { return _tourLogList; }
            set
            {
                if (_tourLogList != value)
                {
                    _tourLogList = value;
                    RaisePropertyChangedEvent(nameof(TourLogList));
                }
            }
        }

        private TourLogModel? _selectedTourLog;
        public TourLogModel? SelectedTourLog
        {
            get { return _selectedTourLog; }
            set
            {
                if (_selectedTourLog != value)
                {
                    _selectedTourLog = value;
                    OnSelectedTourLogChanged();
                }
            }
        }

        //AddWindow will show up
        private void AddTourLog(object obj)
        {
            if (_selectedTour != null)
            {
                AddTourLogWindow addTourLog = new AddTourLogWindow();
                addTourLog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                addTourLog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Tour to add a Log");
            }
        }

        //Delete popup to make sure if the user would like to delete this tourLog
        private void DeleteTourLog(object obj)
        {
            if (_selectedTourLog != null)
            {
                if (MessageBox.Show("Do you want to delete this Log?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    log.Info("Deleting tour with Id: " + _selectedTour.Id);

                    _tourService.DeleteTourLog(_selectedTourLog);
                    SelectedTourLog = null;
                    LoadTourLogs();
                }
            }
            else
            {
                MessageBox.Show("Please select a Log to delete");
            }


        }

        //EditWindow will be shown up
        private void EditTourLog(object obj)
        {
            if (_selectedTourLog != null)
            {
                EditTourLogWindow editTourLog = new EditTourLogWindow();
                editTourLog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                editTourLog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Log to edit");
            }
        }

        //´Loading TourLogs
        public void LoadTourLogs()
        {
            if (_selectedTour != null)
            {
                TourLogList = _tourService.GetTourLogs(_selectedTour);
            }
            else
            {
                TourLogList.Clear();
            }
        }

        //If a new tourlog has been selected
        private void OnSelectedTourLogChanged()
        {
            SelectedTourLogChanged?.Invoke(SelectedTourLog);
        }

        private void HandleSelectedTourChanged(TourModel? selectedTour)
        {
            _selectedTour = selectedTour;
            LoadTourLogs();
        }
    }
}
