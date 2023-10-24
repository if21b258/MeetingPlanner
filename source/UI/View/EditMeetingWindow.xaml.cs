using System.Windows;
using MeetingPlannerUI.ViewModel;

namespace MeetingPlannerUI.View
{
    /// <summary>
    /// Interaction logic for EditMeetingWindow.xaml
    /// </summary>
    public partial class EditMeetingWindow : Window
    {
        public EditMeetingWindow()
        {
            InitializeComponent();

            var context = this.DataContext as EditMeetingViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
