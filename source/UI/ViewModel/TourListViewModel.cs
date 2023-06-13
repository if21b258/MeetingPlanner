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

namespace TourPlannerUI.ViewModel
{
    public class TourListViewModel : BaseViewModel
    {
        public ICommand AddTourCommand { get; set; }
        public ICommand DeleteTourCommand { get; set; }
        public ICommand EditTourCommand { get; set; }

        public ObservableCollection<TourModel> TourList { get; set; }

        public TourListViewModel()
        {
            AddTourCommand = new RelayCommand<object>(AddTour);
            DeleteTourCommand = new RelayCommand<object>(DeleteTour);
            EditTourCommand = new RelayCommand<object>(EditTour);
            TourList = new ObservableCollection<TourModel>();
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
    }
}