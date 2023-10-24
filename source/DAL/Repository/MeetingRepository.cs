using System.Collections.ObjectModel;
using MeetingPlannerModel;

namespace MeetingPlannerDAL.Repository
{
    public class MeetingRepository : IMeetingRepository, IDisposable
    {
        private MeetingPlannerDbContext _dbContext;
        private bool _disposed = false;

        public MeetingRepository(MeetingPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMeeting(MeetingModel meeting)
        {
            _dbContext.Meetings.Add(meeting);
        }

        public void DeleteMeeting(MeetingModel meeting)
        {
            _dbContext.Meetings.Remove(meeting);
        }

        public void UpdateMeeting(MeetingModel meeting)
        {
            _dbContext.Meetings.Update(meeting);
        }

        public ObservableCollection<MeetingModel> GetMeetings()
        {
            return new ObservableCollection<MeetingModel>(_dbContext.Meetings.ToList());
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
