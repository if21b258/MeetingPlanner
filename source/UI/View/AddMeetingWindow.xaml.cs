using System.Windows;
using MeetingPlannerUI.ViewModel;

namespace MeetingPlannerUI.View
{
    /// <summary>
    /// Interaction logic for AddMeeting.xaml
    /// </summary>
    public partial class AddMeetingWindow : Window
    {
        public AddMeetingWindow()
        {
            InitializeComponent();

            var context = this.DataContext as AddMeetingViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
