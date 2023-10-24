using System;
using System.Windows;
using System.Windows.Input;
using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;
using MeetingPlannerBL.Util;
using MeetingPlannerModel;

namespace MeetingPlannerUI.ViewModel
{
    public class AddMeetingNoteViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingService _meetingService;
        private MeetingNoteViewModel _meetingNoteViewModel;
        private MeetingModel _selectedMeeting;
        private MeetingPlannerValidation _validation = new MeetingPlannerValidation();
        public ICommand AddMeetingNoteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public AddMeetingNoteViewModel(MeetingNoteViewModel meetingNoteViewModel, MeetingService meetingService)
        {
            _meetingService = meetingService;
            _meetingNoteViewModel = meetingNoteViewModel;
            _selectedMeeting = _meetingNoteViewModel.SelectedMeeting;
            AddMeetingNoteCommand = new RelayCommand<object>(AddMeetingNote);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        //Note
        private string _note = "";
        public string Note
        {
            get { return _note; }
            set
            {
                _note = value;
            }
        }

        //validated note and added it to the list of notes
        private void AddMeetingNote(object commandParameter)
        {
            try
            {
                MeetingNoteModel meetingNote = new MeetingNoteModel(_selectedMeeting, _note);

                if (_validation.ValidateMeetingNoteInput(meetingNote))
                {
                    log.Info("Adding MeetingNote for meeting with id: " + meetingNote.Meeting.Id);

                    _meetingService.AddMeetingNote(meetingNote);
                    _meetingNoteViewModel.LoadMeetingNotes();
                    CloseEvent?.Invoke(true);
                }
                else
                {
                    MessageBox.Show("Your input was invalid");
                    throw new ArgumentException("Invalid input");
                }
            }
            catch (Exception e)
            {
                log.Warn($"Add meeting log failed: {e.Message}");
            }

        }

        //close window
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }
    }
}
