using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;

namespace MeetingPlannerUI.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingService _meetingService;
        private MeetingListViewModel _meetingListViewModel;
        private MeetingNoteViewModel _meetingNoteViewModel;
        private MeetingInfoViewModel _meetingInfoViewModel;
        private MenuViewModel _menuViewModel;


        public MainViewModel(MeetingService meetingService, MeetingListViewModel meetingListViewModel, MeetingNoteViewModel meetingNoteViewModel, MeetingInfoViewModel meetingInfoViewModel, MenuViewModel menuViewModel)
        {
            _meetingService = meetingService;
            _meetingListViewModel = meetingListViewModel;
            _meetingNoteViewModel = meetingNoteViewModel;
            _meetingInfoViewModel = meetingInfoViewModel;
            _menuViewModel = menuViewModel;
            Startup();
        }

        //Start MeetingPlanner
        private void Startup()
        {
            log.Info("Meeting Planner started.");

            _meetingService.EnsureDatabaseCreated();
            _meetingListViewModel.LoadMeetings();
            _meetingNoteViewModel.LoadMeetingNotes();
        }
    }
}
