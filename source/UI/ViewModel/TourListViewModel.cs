using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.source.BL;
using TourPlanner.source.UI.View;
using TourPlanner.source.UI.Windows;

namespace source.UI.ViewModel
{
    public class TourListViewModel
    {
        public ICommand AddTourCommand { get; set; }
        public ICommand DeleteTourCommand { get; set; }

        public TourListViewModel()
        {
            AddTourCommand = new RelayCommand(AddTour);
            DeleteTourCommand = new RelayCommand(DeleteTour);
        }

        private void AddTour(object obj)
        {
            AddTour addtour = new AddTour();
            addtour.ShowDialog();
        }

        private void DeleteTour(object obj)
        {
            DeleteTour deleteTour = new DeleteTour();
            deleteTour.ShowDialog();
        }
    }
}