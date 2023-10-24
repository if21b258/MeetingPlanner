using System.Collections.ObjectModel;
using MeetingPlannerModel;

namespace MeetingPlannerDAL.Repository
{
    public interface IMeetingNoteRepository : IDisposable
    {
        void AddMeetingNote(MeetingNoteModel meetingNote);
        void DeleteMeetingNote(MeetingNoteModel meetingNote);
        void UpdateMeetingNote(MeetingNoteModel meetingNote);
        ObservableCollection<MeetingNoteModel> GetMeetingNotes(MeetingModel meeting);
        void Save();
    }
}
