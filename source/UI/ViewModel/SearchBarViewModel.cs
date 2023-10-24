using System.Windows.Input;
using System;
using MeetingPlannerBL.Logging;
using MeetingPlannerBL.Service;
using MeetingPlannerBL.Util;
using System.Text.RegularExpressions;
using MeetingPlannerModel;

namespace MeetingPlannerUI.ViewModel
{
    public class SearchBarViewModel : BaseViewModel
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingListViewModel _meetingListViewModel;

        public ICommand SearchCommand { get; set; }

        public SearchBarViewModel(MeetingListViewModel meetingListViewModel)
        {
            _meetingListViewModel = meetingListViewModel;
        }

        private String _searchString = "";
        public String SearchString
        {
            get { return _searchString; }
            set
            {
                if (_searchString != value)
                {
                    _searchString = value;
                    Search();
                }
            }
        }

        private void Search()
        {
            var regex = new Regex(_searchString);

            foreach (MeetingModel meeting in _meetingListViewModel.MeetingList)
            {
                meeting.Visible = regex.IsMatch(GetSearchString(meeting));
            }

            _meetingListViewModel.OnVisibilityChanged();
        }

        public string GetSearchString(MeetingModel meeting)
        {
            string searchString = string.Concat(
                meeting.Title,
                meeting.From,
                meeting.To,
                meeting.Agenda
                );

            foreach (MeetingNoteModel meetingNote in meeting.MeetingNotes)
            {
                searchString += string.Concat(
                                        meetingNote.Id,
                                        meetingNote.Note
                                        );
            }

            return searchString;
        }

    }
}
