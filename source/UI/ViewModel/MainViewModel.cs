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
        public ICommand ResetDatabaseCommand { get; set; }
        private TourPlannerDbContext _dbContext;
        private TourService _tourService;
        private TourListViewModel _tourListViewModel;
        private TourLogViewModel _tourLogViewModel;

        private TourRouteViewModel _tourRouteViewModel;

        public MainViewModel(TourPlannerDbContext dbContext, TourService tourService, TourListViewModel tourListViewModel, TourLogViewModel tourLogViewModel, TourRouteViewModel tourRouteViewModel)
        {
            _dbContext = dbContext;
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourLogViewModel = tourLogViewModel;
            _tourRouteViewModel = tourRouteViewModel;
            ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
            Startup();
        }

        private void ResetDatabase(object obj)
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        private void Startup()
        {
            _dbContext.Database.EnsureCreated();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }

        /*private TourService _tourServiceOfficer { get; set; }

private AddTourViewModel _addTourViewModel { get; set; }

public MainViewModel(TourService TourServiceOff, AddTourViewModel AddTourVM) { //Hier gibts auch noch einen Mapquest mit

    this._tourServiceOfficer = TourServiceOff; 

    this._addTourViewModel = AddTourVM;


    _addTourViewModel.GetMapByRequest += (_, tourModel) =>
    {
        _tourServiceOfficer.GetMap(tourModel);
    };

} */
    }
}
