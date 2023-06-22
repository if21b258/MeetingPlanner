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
            _tourService.EnsureDatabaseCreated();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }
    }
}
