using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerDAL;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand ResetDatabaseCommand { get; set; }

        public MainViewModel()
        {

            ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
        }

        private void ResetDatabase(object obj)
        {
            TourPlannerDbContext dbContext = new TourPlannerDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
    }
}
