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
using System.Runtime.CompilerServices;
using Microsoft.Win32;

namespace TourPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private TourPlannerDbContext _dbContext;
        private TourService _tourService;
        private FileService _fileService = new FileService();
        private ReportService _reportService = new ReportService();
        private TourListViewModel _tourListViewModel;
        private TourLogViewModel _tourLogViewModel;
        private TourInfoViewModel _tourInfoViewModel;
        private TourRouteViewModel _tourRouteViewModel;
        public ICommand ResetDatabaseCommand { get; set; }
        public ICommand GenerateTourReportCommand { get; set; }

        public MainViewModel(TourPlannerDbContext dbContext, TourService tourService, TourListViewModel tourListViewModel, TourLogViewModel tourLogViewModel, TourInfoViewModel tourInfoViewModel, TourRouteViewModel tourRouteViewModel)
        {
            _dbContext = dbContext;
            _tourService = tourService;
            _tourListViewModel = tourListViewModel;
            _tourLogViewModel = tourLogViewModel;
            _tourRouteViewModel = tourRouteViewModel;
            _tourInfoViewModel = tourInfoViewModel;
            ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
            GenerateTourReportCommand = new RelayCommand<object>(GenerateTourReport);
            Startup();
        }

        private void Startup()
        {
            _dbContext.Database.EnsureCreated();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }

        private void ResetDatabase(object obj)
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
            _fileService.DeleteImageFolder();
            _tourListViewModel.LoadTours();
            _tourLogViewModel.LoadTourLogs();
        }

        private void GenerateTourReport(object obj)
        {
            string filePath = ShowSaveFileDialog("Tour", "pdf");
            if(filePath != null)
            {
                _reportService.GenerateTourReport(_tourListViewModel.SelectedTour,filePath);
            }
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
    }
}
