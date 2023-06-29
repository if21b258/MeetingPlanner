using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using TourPlannerBL.Logging;
using TourPlannerBL.Service;

namespace TourPlannerUI.ViewModel
{
    public class MenuViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private TourService _tourService;
        private FileService _fileService = new FileService();
        private ReportService _reportService = new ReportService();
        private TourListViewModel _tourListViewModel;
        private TourLogViewModel _tourLogViewModel;

        public ICommand ImportTourCommand { get; set; }
        public ICommand ExportTourCommand { get; set; }
        public ICommand GenerateTourReportCommand { get; set; }
        public ICommand GenerateSummaryReportCommand { get; set; }
        public ICommand ResetDatabaseCommand { get; set; }
        public ICommand AboutCommand { get; set; }

        public MenuViewModel(TourService tourService, TourListViewModel tourListViewModel, TourLogViewModel tourLogViewModel)
        {
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourLogViewModel = tourLogViewModel;
            ImportTourCommand = new RelayCommand<object>(ImportTour);
            ExportTourCommand = new RelayCommand<object>(ExportTour);
            GenerateTourReportCommand = new RelayCommand<object>(GenerateTourReport);
            GenerateSummaryReportCommand = new RelayCommand<object>(GenerateSummaryReport);
            ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
            AboutCommand = new RelayCommand<object>(About);
        }

        //Import tour from chosen file path
        private async void ImportTour(object obj)
        {
            string? filePath = ShowSaveFileDialog("Tour", "json");
            if (filePath != null)
            {
                log.Info("Import tour from " + filePath);

                await _tourService.ImportTour(filePath);
                _tourListViewModel.LoadTours();
            }
        }

        //Export tour to chosen file path
        private void ExportTour(object obj)
        {
            if (_tourListViewModel.SelectedTour != null)
            {
                string? filePath = ShowSaveFileDialog("Tour", "json");
                if (filePath != null)
                {
                    log.Info("Export tour to " + filePath);

                    _tourService.ExportTour(_tourListViewModel.SelectedTour, filePath);
                }
            }
            else
            {
                MessageBox.Show("Please select a Tour to export");
            }
        }

        //Method for creating the tour report
        private void GenerateTourReport(object obj)
        {
            if (_tourListViewModel.SelectedTour != null)
            {
                string? filePath = ShowSaveFileDialog("Tour Report", "pdf");
                if (filePath != null)
                {
                    log.Info("Create tour report at " + filePath);

                    _reportService.GenerateTourReport(_tourListViewModel.SelectedTour, filePath);
                }
            }
            else
            {
                MessageBox.Show("Please select a Tour to create a report");
            }

        }
        //Method for creating the summary report
        private void GenerateSummaryReport(object obj)
        {
            string? filePath = ShowSaveFileDialog("Summary Report", "pdf");
            if (filePath != null)
            {
                log.Info("Create summary report at " + filePath);

                _reportService.GenerateSummaryReport(_tourListViewModel.TourList, filePath);
            }
        }

        //Database is able to reset by clicking the reset button in Top-Bar by pressing options
        private void ResetDatabase(object obj)
        {
            log.Info("Database reset");

            _tourService.EnsureDatabaseDeleted();
            _tourService.EnsureDatabaseCreated();
            _fileService.DeleteImageFolder();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }

        //About Dialog
        private void About(object obj)
        {
            MessageBox.Show("Tour Planner made by Josua and Felix");
        }

        public string? ShowSaveFileDialog(string defaultName, string ext)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = defaultName;
            dialog.DefaultExt = $".{ext}";
            dialog.Filter = $"{ext} documents |*.{ext}";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public string? ShowSelectFileDialog(string ext)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = $".{ext}";
            dialog.Filter = $"{ext} documents |*.{ext}";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }
    }
}
