using TourPlannerBL;
using TourPlannerBL.Logging;

namespace TourPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

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
            log.Info("Tour Planner started.");

            _tourService.EnsureDatabaseCreated();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }
    }
}
