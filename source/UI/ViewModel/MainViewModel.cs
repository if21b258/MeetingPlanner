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

namespace TourPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private TourPlannerDbContext _dbContext;
        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        private TourLogViewModel _tourLogViewModel;
        private TourInfoViewModel _tourInfoViewModel;
        private TourRouteViewModel _tourRouteViewModel;
        public ICommand ResetDatabaseCommand { get; set; }

        public MainViewModel(TourPlannerDbContext dbContext, TourService tourService, TourListViewModel tourListViewModel, TourLogViewModel tourLogViewModel, TourInfoViewModel tourInfoViewModel, TourRouteViewModel tourRouteViewModel)
        {
            _dbContext = dbContext;
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourLogViewModel = tourLogViewModel;
            _tourRouteViewModel = tourRouteViewModel;
            _tourInfoViewModel = tourInfoViewModel;
            ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
            Startup();
        }

        private void ResetDatabase(object obj)
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }

        private void Startup()
        {
            _dbContext.Database.EnsureCreated();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }
    }
}
