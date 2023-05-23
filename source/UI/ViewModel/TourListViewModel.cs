using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerUI.View;

namespace TourPlannerUI.ViewModel
{
    public class TourListViewModel
    {
        public ICommand AddTourCommand { get; set; }
        public ICommand DeleteTourCommand { get; set; }

        public TourListViewModel()
        {
            AddTourCommand = new RelayCommand<object>(AddTour);
            DeleteTourCommand = new RelayCommand<object>(DeleteTour);
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
    }
}