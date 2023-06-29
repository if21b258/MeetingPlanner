using System.Windows;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.View
{
    /// <summary>
    /// Interaction logic for AddTour.xaml
    /// </summary>
    public partial class AddTourWindow : Window
    {
        public AddTourWindow()
        {
            InitializeComponent();

            var context = this.DataContext as AddTourViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
