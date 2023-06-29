using System.Windows;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.View
{
    /// <summary>
    /// Interaction logic for EditTourLogWindow.xaml
    /// </summary>
    public partial class EditTourLogWindow : Window
    {
        public EditTourLogWindow()
        {
            InitializeComponent();

            var context = this.DataContext as EditTourLogViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
