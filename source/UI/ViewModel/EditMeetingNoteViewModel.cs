using System;
using System.Windows;
using System.Windows.Input;
using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;
using MeetingPlannerBL.Util;
using MeetingPlannerModel;


namespace MeetingPlannerUI.ViewModel
{
    public class EditMeetingNoteViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingService _meetingService;
        private MeetingNoteViewModel _meetingNoteViewModel;
        private MeetingNoteModel _selectedMeetingNote;
        private MeetingPlannerValidation _validation = new MeetingPlannerValidation();
        public ICommand EditMeetingNoteCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Action<bool> CloseEvent;

        public EditMeetingNoteViewModel(MeetingNoteViewModel meetingNoteViewModel, MeetingService meetingService)
        {
            _meetingService = meetingService;
            _meetingNoteViewModel = meetingNoteViewModel;
            _selectedMeetingNote = _meetingNoteViewModel.SelectedMeetingNote;
            EditMeetingNoteCommand = new RelayCommand<object>(EditMeetingNote);
            CancelCommand = new RelayCommand<object>(Cancel);
        }

        //Note
        public string Note
        {
            get { return _selectedMeetingNote.Note; }
            set
            {
                _selectedMeetingNote.Note = value;

            }
        }

        //validate changes and edit meeting note
        private void EditMeetingNote(object commandParameter)
        {
            try
            {
                if (_validation.ValidateMeetingNoteInput(_selectedMeetingNote))
                {
                    _meetingService.EditMeetingNote(_selectedMeetingNote);
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
                log.Warn($"Edit meeting log failed: {e.Message}");
            }
        }

        //close window
        private void Cancel(object commandParameter)
        {
            CloseEvent?.Invoke(false);
        }
    }
}
