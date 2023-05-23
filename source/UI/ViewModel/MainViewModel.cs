using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.source.UI.ViewModel;

namespace TourPlannerUI.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private TourListViewModel _tourListViewModel;
        private AddTourViewModel _addTourViewModel;
        private EditTourViewModel _editTourViewModel;
        private TourLogViewModel _tourLogViewModel;
        private AddTourLogViewModel _addTourLogViewModel;
        private EditTourLogViewModel _editTourLogViewModel;
        private SearchBarViewModel _searchBarViewModel;
        MainViewModel()
        {
            _tourListViewModel = new TourListViewModel();
            _addTourViewModel = new AddTourViewModel();
            _editTourViewModel = new EditTourViewModel();
            _tourLogViewModel = new TourLogViewModel();
            _addTourLogViewModel = new AddTourLogViewModel();
            _editTourLogViewModel = new EditTourLogViewModel();
            _searchBarViewModel = new SearchBarViewModel();
        }
    }
}
