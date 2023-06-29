using System.Windows;
using TourPlannerUI.ViewModel;

namespace TourPlannerUI.View
{
    /// <summary>
    /// Interaction logic for EditTourWindow.xaml
    /// </summary>
    public partial class EditTourWindow : Window
    {
        public EditTourWindow()
        {
            InitializeComponent();

            var context = this.DataContext as EditTourViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
