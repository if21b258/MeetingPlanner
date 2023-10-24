using System.Collections.ObjectModel;
using MeetingPlannerModel;

namespace MeetingPlannerBL.Service
{
    public interface IMeetingService
    {
        public void AddMeeting(MeetingModel meeting);
        public void EditMeeting(MeetingModel meeting);
        public void DeleteMeeting(MeetingModel meeting);
        public ObservableCollection<MeetingModel> GetMeetings();
        public void AddMeetingNote(MeetingNoteModel meetingNote);
        public void EditMeetingNote(MeetingNoteModel meetingNote);
        public void DeleteMeetingNote(MeetingNoteModel meetingNote);
        public ObservableCollection<MeetingNoteModel> GetMeetingNotes(MeetingModel meeting);
        public void EnsureDatabaseCreated();
        public void EnsureDatabaseDeleted();
        public void ExportMeeting(MeetingModel meeting, string filePath);
        public void ImportMeeting(string filePath);
    }
}
