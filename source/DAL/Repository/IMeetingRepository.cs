using System.Collections.ObjectModel;
using MeetingPlannerModel;

namespace MeetingPlannerDAL.Repository
{
    public interface IMeetingRepository : IDisposable
    {
        void AddMeeting(MeetingModel meeting);
        void DeleteMeeting(MeetingModel meeting);
        void UpdateMeeting(MeetingModel meeting);
        ObservableCollection<MeetingModel> GetMeetings();
        void Save();
    }
}
