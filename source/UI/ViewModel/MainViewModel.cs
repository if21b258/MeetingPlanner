using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly TourListViewModel _tourListViewModel;
        private readonly TourLogViewModel _tourLogViewModel;

        public MainViewModel(TourListViewModel tourListViewModel, TourLogViewModel tourLogViewModel)
        {
            _tourListViewModel = tourListViewModel;
            _tourLogViewModel = tourLogViewModel;
        }
    }
}
