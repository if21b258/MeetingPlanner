using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using TourPlannerBL;
using TourPlannerModel;

namespace TourPlannerUI.ViewModel
{
    public class TourRouteViewModel : BaseViewModel
    {
        private TourService _tourService;
        private FileService _fileService;
        private TourListViewModel _tourListViewModel;
        private TourModel? _selectedTour;
        public BitmapImage _routeImage;

        public TourRouteViewModel(TourService tourService, TourListViewModel tourListViewModel) {
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourListViewModel.SelectedTourChanged += HandleSelectedTourChanged;
            _fileService = new FileService();
        }

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
        public void GetImage(TourModel tour)
        {
            try
            {
                //Placeholder wenn tour gelöscht wird (tour=null) crashed das programm. Sollte in dem fall kein bild anzeigen.
                if(tour == null)
                {
                    return;
                }

                string filePath = _fileService.GetFilePath(tour);
                byte[] image = File.ReadAllBytes(filePath);
                using (MemoryStream memoryStream = new MemoryStream(image))
                {
                    // Create a new BitmapImage
                    BitmapImage bitmapImage = new BitmapImage();

                    // Set the MemoryStream as the source of the BitmapImage
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();

                    // Set the BitmapImage as the ImageData property in your ViewModel
                    RouteImage = bitmapImage;
                }

            }
            catch (Exception FileNotFoundException)
            {
                Console.WriteLine("File konnte nicht gefunden werden");
                RouteImage = null;
            }
            
        }

        private void HandleSelectedTourChanged(TourModel selectedTour)
        {
            _selectedTour = selectedTour;
            GetImage(selectedTour);
        }
    }
}
