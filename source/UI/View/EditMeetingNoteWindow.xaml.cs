using System.Windows;
using MeetingPlannerUI.ViewModel;

namespace MeetingPlannerUI.View
{
    /// <summary>
    /// Interaction logic for EditMeetingNoteWindow.xaml
    /// </summary>
    public partial class EditMeetingNoteWindow : Window
    {
        public EditMeetingNoteWindow()
        {
            InitializeComponent();

            var context = this.DataContext as EditMeetingNoteViewModel;
            context.CloseEvent += (value) => this.DialogResult = value;
        }
    }
}
