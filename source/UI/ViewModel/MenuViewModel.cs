using Microsoft.Win32;
using System.Windows;
using System.Windows.Input;
using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;

namespace MeetingPlannerUI.ViewModel
{
    public class MenuViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingService _meetingService;
        private ReportService _reportService = new ReportService();
        private MeetingListViewModel _meetingListViewModel;
        private MeetingNoteViewModel _meetingNoteViewModel;

        public ICommand ImportMeetingCommand { get; set; }
        public ICommand ExportMeetingCommand { get; set; }
        public ICommand GenerateMeetingReportCommand { get; set; }
        public ICommand ResetDatabaseCommand { get; set; }
        public ICommand SortAlphabeticallyCommand { get; set; }
        public ICommand SortIdCommand { get; set; }
        public ICommand AboutCommand { get; set; }

        public MenuViewModel(MeetingService meetingService, MeetingListViewModel meetingListViewModel, MeetingNoteViewModel meetingNoteViewModel)
        {
            _meetingService = meetingService;
            _meetingListViewModel = meetingListViewModel;
            _meetingNoteViewModel = meetingNoteViewModel;
            ImportMeetingCommand = new RelayCommand<object>(ImportMeeting);
            ExportMeetingCommand = new RelayCommand<object>(ExportMeeting);
            GenerateMeetingReportCommand = new RelayCommand<object>(GenerateMeetingReport);
            ResetDatabaseCommand = new RelayCommand<object>(ResetDatabase);
            SortAlphabeticallyCommand = new RelayCommand<object>(SortAlphabetical);
            SortIdCommand = new RelayCommand<object>(SortId);
            AboutCommand = new RelayCommand<object>(About);
        }

        private void ImportMeeting(object obj)
        {
            string? filePath = ShowSelectFileDialog("json");
            if (filePath != null)
            {
                log.Info("Import meeting from " + filePath);

                _meetingService.ImportMeeting(filePath);
                _meetingListViewModel.LoadMeetings();
            }
        }

        private void ExportMeeting(object obj)
        {
            if (_meetingListViewModel.SelectedMeeting != null)
            {
                string? filePath = ShowSaveFileDialog("Meeting", "json");
                if (filePath != null)
                {
                    log.Info("Export meeting to " + filePath);

                    _meetingService.ExportMeeting(_meetingListViewModel.SelectedMeeting, filePath);
                }
            }
            else
            {
                MessageBox.Show("Please select a Meeting to export");
            }
        }

        private void GenerateMeetingReport(object obj)
        {
            if (_meetingListViewModel.SelectedMeeting != null)
            {
                string? filePath = ShowSaveFileDialog("Meeting Report", "pdf");
                if (filePath != null)
                {
                    log.Info("Create meeting report at " + filePath);

                    _reportService.GenerateMeetingReport(_meetingListViewModel.SelectedMeeting, filePath);
                }
            }
            else
            {
                MessageBox.Show("Please select a Meeting to create a report");
            }

        }

        private void ResetDatabase(object obj)
        {
            log.Info("Database reset");

            _meetingService.EnsureDatabaseDeleted();
            _meetingService.EnsureDatabaseCreated();
            _meetingListViewModel.LoadMeetings();
            _meetingNoteViewModel.LoadMeetingNotes();
        }

        private void About(object obj)
        {
            MessageBox.Show("Meeting Planner made by Josua Hämmerle");
        }

        public string? ShowSaveFileDialog(string defaultName, string ext)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = defaultName;
            dialog.DefaultExt = $".{ext}";
            dialog.Filter = $"{ext} documents |*.{ext}";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public string? ShowSelectFileDialog(string ext)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.DefaultExt = $".{ext}";
            dialog.Filter = $"{ext} documents |*.{ext}";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }
            else
            {
                return null;
            }
        }

        public void SortAlphabetical(object obj)
        {
            _meetingListViewModel.SortMeetingsAlphabetical();
        }

        public void SortId(object obj)
        {
            _meetingListViewModel.SortMeetingsId();
        }
    }
}
