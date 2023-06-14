using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TourPlannerUI.View;
using TourPlannerUI.Model;

namespace TourPlannerUI.ViewModel
{
    public class TourLogViewModel : BaseViewModel
    {
        public ICommand AddTourLogCommand { get; set; }    
        public ICommand DeleteTourLogCommand { get; set; }       
        public ICommand EditTourLogCommand { get; set; }

        public event Action<TourLogModel> SelectedTourLogChanged;

        public ObservableCollection<TourLogModel> TourLogList { get; set; }

        private TourLogModel _selectedTourLog;

        public TourLogViewModel()
        {
            AddTourLogCommand = new RelayCommand<object>(AddTourLog);
            DeleteTourLogCommand = new RelayCommand<object>(DeleteTourLog);
            EditTourLogCommand = new RelayCommand<object>(EditTourLog);
            TourLogList = new ObservableCollection<TourLogModel>();
        }

        public TourLogModel SelectedTourLog
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
            AddTourLogWindow addTourLog = new AddTourLogWindow();
            addTourLog.ShowDialog();
        }

        private void DeleteTourLog(object obj)
        {
            DeleteTourWindow deleteTour = new DeleteTourWindow();
            deleteTour.ShowDialog();
        }

        private void EditTourLog(object obj)
        {
            EditTourLogWindow editTourLog = new EditTourLogWindow();
            editTourLog.ShowDialog();
        }

        private void OnSelectedTourLogChanged()
        {
            SelectedTourLogChanged?.Invoke(SelectedTourLog);
        }
    }
}
