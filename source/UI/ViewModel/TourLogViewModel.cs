using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.source.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TourPlanner.source.BL;
using TourPlanner.source.UI.View;
using TourPlanner.source.UI.Windows;

namespace TourPlanner.source.UI.ViewModel
{
    class TourLogViewModel
    {
        public ICommand AddTourLogCommand { get; set; }
        public ICommand DeleteTourLogCommand { get; set; }

        public TourLogViewModel()
        {
            AddTourLogCommand = new RelayCommand(AddTourLog);
            DeleteTourLogCommand = new RelayCommand(DeleteTourLog);
        }

        private void AddTourLog(object obj)
        {
            AddTourLog addTourLog = new AddTourLog();
            addTourLog.ShowDialog();
        }

        private void DeleteTourLog(object obj)
        {
            DeleteTour deleteTour = new DeleteTour();
            deleteTour.ShowDialog();
        }
    }
}
