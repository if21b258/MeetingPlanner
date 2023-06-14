using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerUI.View;
using TourPlannerUI.Model;
using System.ComponentModel;

namespace TourPlannerUI.ViewModel
{
    public class TourListViewModel : BaseViewModel
    {
        public ICommand AddTourCommand { get; set; }
        public ICommand DeleteTourCommand { get; set; }
        public ICommand EditTourCommand { get; set; }

        public event Action<TourModel> SelectedTourChanged;

        public ObservableCollection<TourModel> TourList { get; set; }

        private TourModel _selectedTour;

        public TourListViewModel()
        {
            AddTourCommand = new RelayCommand<object>(AddTour);
            DeleteTourCommand = new RelayCommand<object>(DeleteTour);
            EditTourCommand = new RelayCommand<object>(EditTour);
            TourList = new ObservableCollection<TourModel>();
        }

        public TourModel SelectedTour
        {
            get { return _selectedTour; }
            set
            {
                if(_selectedTour != value)
                {
                    _selectedTour = value;
                    OnSelectedTourChanged();
                }
            }
        }

        private void AddTour(object obj)
        {
            AddTourWindow addtour = new AddTourWindow();
            addtour.ShowDialog();
        }

        private void DeleteTour(object obj)
        {
            DeleteTourWindow deleteTour = new DeleteTourWindow();
            deleteTour.ShowDialog();
        }

        private void EditTour(object obj)
        {
            EditTourWindow editTour = new EditTourWindow();
            editTour.ShowDialog();
        }

        private void OnSelectedTourChanged()
        {
            SelectedTourChanged?.Invoke(SelectedTour);
        }
    }
}