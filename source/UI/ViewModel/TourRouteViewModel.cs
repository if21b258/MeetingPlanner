using System;
using System.IO;
using System.Windows.Media.Imaging;
using TourPlannerModel;
using TourPlannerBL;
using TourPlannerBL.Logging;

namespace TourPlannerUI.ViewModel
{
    public class TourRouteViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private FileService _fileService = new FileService();
        private TourListViewModel _tourListViewModel;
        private TourModel? _selectedTour;

        public TourRouteViewModel(TourListViewModel tourListViewModel) {
            _tourListViewModel = tourListViewModel;
            _tourListViewModel.SelectedTourChanged += HandleSelectedTourChanged;
        }

        //Get the new Image
        private BitmapImage _routeImage;
        public BitmapImage RouteImage
        {
            get { return _routeImage; }
            set
            {
                if (_routeImage != value)
                {
                    _routeImage = value;
                    RaisePropertyChangedEvent(nameof(RouteImage));
                }
            }
        }
        private void LoadImage(TourModel tour)
        {
            try
            {
                if(tour == null)
                {
                    log.Warn("tried to get image of null tour");
                    return;
                }

                string filePath = _fileService.GetFilePath(tour);
                byte[] image = File.ReadAllBytes(filePath);
                using (MemoryStream memoryStream = new MemoryStream(image))
                {
                    // Create a new BitmapImage
                    BitmapImage bitmapImage = new BitmapImage();

                    //Get the BitmapImage
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    // Set the BitmapImage to RouteImage, so that it will be shown in the UI
                    RouteImage = bitmapImage;
                }

            }
            catch (Exception FileNotFoundException)
            {
                log.Error($"File for tour id: {tour.Id} could not be found");
                RouteImage = null;
            }
            
        }

        //If the user has selected a new tour
        private void HandleSelectedTourChanged(TourModel selectedTour)
        {
            _selectedTour = selectedTour;
            LoadImage(_selectedTour);
        }
    }
}
