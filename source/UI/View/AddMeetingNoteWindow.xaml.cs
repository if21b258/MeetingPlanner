using System.Windows;
using MeetingPlannerUI.ViewModel;

namespace MeetingPlannerUI.View
{
    /// <summary>
    /// Interaction logic for AddMeetingNote.xaml
    /// </summary>
    public partial class AddMeetingNoteWindow : Window
    {
        public AddMeetingNoteWindow()
        {
            InitializeComponent();

            var context = this.DataContext as AddMeetingNoteViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
