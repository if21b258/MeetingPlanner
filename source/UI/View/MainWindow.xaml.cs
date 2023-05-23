using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TourListViewModel _tourListViewModel = new TourListViewModel();
        private readonly TourLogViewModel _tourLogViewModel = new TourLogViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(_tourListViewModel, _tourLogViewModel);
            TourList.DataContext = _tourListViewModel;
            TourLog.DataContext = _tourLogViewModel;
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
