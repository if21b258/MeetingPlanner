using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerDAL;
using TourPlannerUI.ViewModel;
using TourPlannerBL;
using System.IO;
using System.Configuration;
using System.Runtime.CompilerServices;
using Microsoft.Win32;

namespace TourPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        private TourLogViewModel _tourLogViewModel;
        private TourInfoViewModel _tourInfoViewModel;
        private TourRouteViewModel _tourRouteViewModel;
        private MenuViewModel _menuViewModel;


        public MainViewModel(TourService tourService, TourListViewModel tourListViewModel, TourLogViewModel tourLogViewModel, TourInfoViewModel tourInfoViewModel, TourRouteViewModel tourRouteViewModel, MenuViewModel menuViewModel)
        {
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourLogViewModel = tourLogViewModel;
            _tourRouteViewModel = tourRouteViewModel;
            _tourInfoViewModel = tourInfoViewModel;
            _menuViewModel = menuViewModel;
            Startup();
        }

        private void Startup()
        {
            //_dbContext.Database.EnsureCreated();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }

        private void ResetDatabase(object obj)
        {
            //_dbContext.Database.EnsureDeleted();
            //_dbContext.Database.EnsureCreated();
            //_fileService.DeleteImageFolder();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }

        private void GenerateTourReport(object obj)
        {
            string filePath = ShowSaveFileDialog("Tour", "pdf");
            if(filePath != null)
            {
                //_reportService.GenerateTourReport(_tourListViewModel.SelectedTour,filePath);
            }
        }

        public string? ShowSaveFileDialog(string defaultName, string ext)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = defaultName;
            dialog.DefaultExt = $".{ext}";
            dialog.Filter = $"{ext} documents |*.{ext}";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}
