﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerUI.View;
using TourPlannerModel;
using System.ComponentModel;
using TourPlannerBL;
using TourPlannerBL.Logging;
using System.Windows;

namespace TourPlannerUI.ViewModel
{
    public class TourListViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private TourService _tourService;

        public ICommand AddTourCommand { get; set; }
        public ICommand DeleteTourCommand { get; set; }
        public ICommand EditTourCommand { get; set; }
        public event Action<TourModel?>? SelectedTourChanged;

        public TourListViewModel(TourService tourService)
        {
            AddTourCommand = new RelayCommand<object>(AddTour);
            DeleteTourCommand = new RelayCommand<object>(DeleteTour);
            EditTourCommand = new RelayCommand<object>(EditTour);
            _tourList = new ObservableCollection<TourModel>();
            _tourService = tourService;
        }

        // The Obervable Collection
        private ObservableCollection<TourModel> _tourList;
        public ObservableCollection<TourModel> TourList
        {
            get { return _tourList; }
            set
            {
                if (_tourList != value)
                {
                    _tourList = value;
                    RaisePropertyChangedEvent(nameof(TourList));
                }
            }
        }

        // The tour which will be selected by the user in the tourlistview
        private TourModel? _selectedTour;
        public TourModel? SelectedTour
        {
            get { return _selectedTour; }
            set
            {
                if(_selectedTour != value)
                {
                    _selectedTour = value;
                    OnSelectedTourChanged();
                }
            }
        }

        //AddWindow will be shown up
        private void AddTour(object obj)
        {
            AddTourWindow addtour = new AddTourWindow();
            addtour.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addtour.ShowDialog();
        }

        //Delete popup to make sure if the user would like to delete this tour
        private void DeleteTour(object obj)
        {
            if(_selectedTour != null)
            {
                if (MessageBox.Show("Do you want to delete this Tour?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    _tourService.DeleteTour(_selectedTour);
                    SelectedTour = null;
                    LoadTours();
                }
            }
            else
            {
                MessageBox.Show("Please select a Tour to delete");
            }
        }

        //EditWindow will be shown up
        private void EditTour(object obj)
        {
            if(_selectedTour != null)
            {
                EditTourWindow editTour = new EditTourWindow();
                editTour.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                editTour.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Tour to edit");
            }
        }

        //Loading Tours
        public void LoadTours()
        {
            TourList = _tourService.GetTours();

            foreach (TourModel tour in TourList)
            {
                tour.Logs = _tourService.GetTourLogs(tour);
            }
        }

        //If another Tour has been chosen
        public void OnSelectedTourChanged()
        {
            SelectedTourChanged?.Invoke(SelectedTour);
        }
    }
}