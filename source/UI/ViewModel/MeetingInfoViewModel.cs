using System;
using MeetingPlannerBL.Util;
using MeetingPlannerModel;

namespace MeetingPlannerUI.ViewModel
{
    public class MeetingInfoViewModel : BaseViewModel
    {
        private MeetingListViewModel _meetingListViewModel;
        private MeetingModel? _selectedMeeting;

        public MeetingInfoViewModel(MeetingListViewModel meetingListViewModel)
        {
            _meetingListViewModel = meetingListViewModel;
            _meetingListViewModel.SelectedMeetingChanged += HandleSelectedMeetingChanged;
        }

        private void HandleSelectedMeetingChanged(MeetingModel selectedMeeting)
        {
            _selectedMeeting = selectedMeeting;
            RaisePropertyChangedEvent(nameof(Id));
            RaisePropertyChangedEvent(nameof(Title));
            RaisePropertyChangedEvent(nameof(From));
            RaisePropertyChangedEvent(nameof(To));
            RaisePropertyChangedEvent(nameof(Agenda));
        }

        //Get the Attributes from the selected meeting for showing it in the general column
        public int? Id
        {
            get { return _selectedMeeting?.Id; }
        }

        public string? Title
        {
            get { return _selectedMeeting?.Title; }
        }

        public DateTime? From
        {
            get { return _selectedMeeting?.From; }
        }

        public DateTime? To
        {
            get { return _selectedMeeting?.To; }
        }

        public string? Agenda
        {
            get { return _selectedMeeting?.Agenda; }
        }
    }
}
