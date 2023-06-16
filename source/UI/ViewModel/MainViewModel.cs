using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerDAL;
using TourPlannerUI.ViewModel;
using TourPlannerBL;

namespace TourPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand ResetDatabaseCommand { get; set; }
        private TourPlannerDbContext _dbContext;

        public MainViewModel(TourPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
            ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
        }

        private void ResetDatabase(object obj)
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
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
