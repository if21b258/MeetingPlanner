using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TourPlannerUI.ViewModel
{
    public class MenuViewModel
    {
        public ICommand ResetDatabaseCommand { get; set; }
        public ICommand GenerateTourReportCommand { get; set; }

        public MenuViewModel()
        {
            //ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
            //GenerateTourReportCommand = new RelayCommand<object>(GenerateTourReport);
        }

    }
}
