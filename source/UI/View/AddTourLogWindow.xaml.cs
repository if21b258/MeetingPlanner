using System.Windows;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.View
{
    /// <summary>
    /// Interaction logic for AddTourLog.xaml
    /// </summary>
    public partial class AddTourLogWindow : Window
    {
        public AddTourLogWindow()
        {
            InitializeComponent();

            var context = this.DataContext as AddTourLogViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
