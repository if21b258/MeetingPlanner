using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TourPlannerUI.View;
using TourPlannerModel;
using TourPlannerBL;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;

namespace TourPlannerUI.ViewModel
{
    public class TourLogViewModel : BaseViewModel
    {
        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        private TourModel? _selectedTour;
        private ObservableCollection<TourLogModel> _tourLogList;
        private TourLogModel? _selectedTourLog;
        public ICommand AddTourLogCommand { get; set; }
        public ICommand DeleteTourLogCommand { get; set; }
        public ICommand EditTourLogCommand { get; set; }
        public event Action<TourLogModel>? SelectedTourLogChanged;

        public TourLogViewModel(TourListViewModel tourListViewModel, TourService tourService)
        {
            AddTourLogCommand = new RelayCommand<object>(AddTourLog);
            DeleteTourLogCommand = new RelayCommand<object>(DeleteTourLog);
            EditTourLogCommand = new RelayCommand<object>(EditTourLog);
            _tourListViewModel = tourListViewModel;
            _tourListViewModel.SelectedTourChanged += HandleSelectedTourChanged;
            _tourService = tourService;
            _tourLogList = new ObservableCollection<TourLogModel>();
        }

        public TourModel? SelectedTour
        {
            get { return _selectedTour; }
        }

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

        private void AddTourLog(object obj)
        {
            if(_selectedTour != null)
            {
                AddTourLogWindow addTourLog = new AddTourLogWindow();
                addTourLog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Tour to add a Log");
            }
        }

        private void DeleteTourLog(object obj)
        {
            if(_selectedTourLog != null)
            {
                if (MessageBox.Show("Do you want to delete this Log?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _tourService.DeleteTourLog(_selectedTourLog);
                    _selectedTourLog = null;
                    LoadTourLogs();
                }
            }
            else
            {
                MessageBox.Show("Please select a Log to delete");
            }


        }

        private void EditTourLog(object obj)
        {
            if(_selectedTourLog != null)
            {
                EditTourLogWindow editTourLog = new EditTourLogWindow();
                editTourLog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Log to edit");
            }
        }

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

        private void OnSelectedTourLogChanged()
        {
            SelectedTourLogChanged?.Invoke(SelectedTourLog);
        }

        private void HandleSelectedTourChanged(TourModel selectedTour)
        {
            _selectedTour = selectedTour;
            LoadTourLogs();
        }
    }
}
