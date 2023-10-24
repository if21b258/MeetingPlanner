using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;
using MeetingPlannerModel;
using MeetingPlannerUI.View;


namespace MeetingPlannerUI.ViewModel
{
    public class MeetingNoteViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingService _meetingService;
        private MeetingListViewModel _meetingListViewModel;
        public ICommand AddMeetingNoteCommand { get; set; }
        public ICommand DeleteMeetingNoteCommand { get; set; }
        public ICommand EditMeetingNoteCommand { get; set; }
        public event Action<MeetingNoteModel?>? SelectedMeetingNoteChanged;

        public MeetingNoteViewModel(MeetingListViewModel meetingListViewModel, MeetingService meetingService)
        {
            _meetingService = meetingService;
            _meetingListViewModel = meetingListViewModel;
            _meetingListViewModel.SelectedMeetingChanged += HandleSelectedMeetingChanged;
            AddMeetingNoteCommand = new RelayCommand<object>(AddMeetingNote);
            DeleteMeetingNoteCommand = new RelayCommand<object>(DeleteMeetingNote);
            EditMeetingNoteCommand = new RelayCommand<object>(EditMeetingNote);
        }

        private MeetingModel? _selectedMeeting;
        public MeetingModel? SelectedMeeting
        {
            get { return _selectedMeeting; }
        }

        private ObservableCollection<MeetingNoteModel> _meetingNoteList = new ObservableCollection<MeetingNoteModel>();
        public ObservableCollection<MeetingNoteModel> MeetingNoteList
        {
            get { return _meetingNoteList; }
            set
            {
                if (_meetingNoteList != value)
                {
                    _meetingNoteList = value;
                    RaisePropertyChangedEvent(nameof(MeetingNoteList));
                }
            }
        }

        private MeetingNoteModel? _selectedMeetingNote;
        public MeetingNoteModel? SelectedMeetingNote
        {
            get { return _selectedMeetingNote; }
            set
            {
                if (_selectedMeetingNote != value)
                {
                    _selectedMeetingNote = value;
                    OnSelectedMeetingNoteChanged();
                }
            }
        }

        //AddMeetingNoteWindow will pop up
        private void AddMeetingNote(object obj)
        {
            if (_selectedMeeting != null)
            {
                AddMeetingNoteWindow addMeetingNote = new AddMeetingNoteWindow();
                addMeetingNote.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                addMeetingNote.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Meeting to add a Note");
            }
        }

        //Delete popup to make sure if the user would like to delete this meetingNote
        private void DeleteMeetingNote(object obj)
        {
            if (_selectedMeetingNote != null)
            {
                if (MessageBox.Show("Do you want to delete this Note?",
                    "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    log.Info("Deleting meeting with Id: " + _selectedMeeting.Id);

                    _meetingService.DeleteMeetingNote(_selectedMeetingNote);
                    SelectedMeetingNote = null;
                    LoadMeetingNotes();
                }
            }
            else
            {
                MessageBox.Show("Please select a Note to delete");
            }


        }

        //EditMeetingNoteWindow will pop up
        private void EditMeetingNote(object obj)
        {
            if (_selectedMeetingNote != null)
            {
                EditMeetingNoteWindow editMeetingNote = new EditMeetingNoteWindow();
                editMeetingNote.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                editMeetingNote.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a Note to edit");
            }
        }

        //Loading MeetingNotes
        public void LoadMeetingNotes()
        {
            if (_selectedMeeting != null)
            {
                MeetingNoteList = _meetingService.GetMeetingNotes(_selectedMeeting);
            }
            else
            {
                MeetingNoteList.Clear();
            }
        }

        //If a new meetingnote has been selected
        private void OnSelectedMeetingNoteChanged()
        {
            SelectedMeetingNoteChanged?.Invoke(SelectedMeetingNote);
        }

        private void HandleSelectedMeetingChanged(MeetingModel? selectedMeeting)
        {
            _selectedMeeting = selectedMeeting;
            LoadMeetingNotes();
        }
    }
}
