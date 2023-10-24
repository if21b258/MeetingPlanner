using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;
using MeetingPlannerModel;
using MeetingPlannerUI.View;

namespace MeetingPlannerUI.ViewModel
{
    public class MeetingListViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingService _meetingService;
        public ICommand AddMeetingCommand { get; set; }
        public ICommand DeleteMeetingCommand { get; set; }
        public ICommand EditMeetingCommand { get; set; }

        public event Action<MeetingModel?>? SelectedMeetingChanged;

        
        public MeetingListViewModel(MeetingService meetingService)
        {
            _meetingService = meetingService;
            AddMeetingCommand = new RelayCommand<object>(AddMeeting);
            DeleteMeetingCommand = new RelayCommand<object>(DeleteMeeting);
            EditMeetingCommand = new RelayCommand<object>(EditMeeting);
        }


        private ObservableCollection<MeetingModel> _meetingList = new ObservableCollection<MeetingModel>();
        public ObservableCollection<MeetingModel> MeetingList
        {
            get { return _meetingList; }
            set
            {
                if (_meetingList != value)
                {
                    _meetingList = value;
                    RaisePropertyChangedEvent(nameof(MeetingList));
                    RaisePropertyChangedEvent(nameof(MeetingListVisible));
                }
            }
        }

        //get all meetings which are visible
        public IEnumerable<MeetingModel> MeetingListVisible => MeetingList.Where(t => t.Visible);

        // The meeting which will be selected by the user in the meetinglistview
        private MeetingModel? _selectedMeeting;
        public MeetingModel? SelectedMeeting
        {
            get { return _selectedMeeting; }
            set
            {
                if (_selectedMeeting != value)
                {
                    _selectedMeeting = value;
                    OnSelectedMeetingChanged();
                }
            }
        }

        //AddMeetingWindow will pop up
        private void AddMeeting(object obj)
        {
            AddMeetingWindow addmeeting = new AddMeetingWindow();
            addmeeting.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addmeeting.ShowDialog();
        }

        //Delete popup to make sure if the user would like to delete this meeting
        private void DeleteMeeting(object obj)
        {
            if (_selectedMeeting != null)
            {
                if (MessageBox.Show("Do you want to delete this Meeting?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    log.Info("Deleting meeting with Id: " + _selectedMeeting.Id);

                    _meetingService.DeleteMeeting(_selectedMeeting);
                    SelectedMeeting = null;
                    LoadMeetings();
                }
            }
            else
            {
                MessageBox.Show("Please select a Meeting to delete");
            }
        }

        //EditWindow will be shown up
        private void EditMeeting(object obj)
        {
            if (_selectedMeeting != null)
            {
                EditMeetingWindow editMeeting = new EditMeetingWindow();
                editMeeting.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                editMeeting.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Meeting to edit");
            }
        }

        //Loading Meetings
        public void LoadMeetings()
        {
            MeetingList = _meetingService.GetMeetings();

            foreach (MeetingModel meeting in MeetingList)
            {
                meeting.MeetingNotes = _meetingService.GetMeetingNotes(meeting);
            }
        }

        //If another Meeting has been chosen
        public void OnSelectedMeetingChanged()
        {
            SelectedMeetingChanged?.Invoke(SelectedMeeting);
        }

        public void OnVisibilityChanged()
        {
            RaisePropertyChangedEvent(nameof(MeetingListVisible));
        }

        public void SortMeetingsAlphabetical()
        {
            MeetingList = new ObservableCollection<MeetingModel>(MeetingList.OrderBy(t => t.Title));
        }
        public void SortMeetingsId()
        {
            MeetingList = new ObservableCollection<MeetingModel>(MeetingList.OrderBy(t => t.Id));
        }
    }
}