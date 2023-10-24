using System.Collections.ObjectModel;
using MeetingPlannerModel;

namespace MeetingPlannerDAL.Repository
{
    public class MeetingNoteRepository : IMeetingNoteRepository, IDisposable
    {
        private MeetingPlannerDbContext _dbContext;
        private bool _disposed = false;

        public MeetingNoteRepository(MeetingPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddMeetingNote(MeetingNoteModel meetingNote)
        {
            _dbContext.MeetingNotes.Add(meetingNote);
        }

        public void DeleteMeetingNote(MeetingNoteModel meetingNote)
        {
            _dbContext.MeetingNotes.Remove(meetingNote);
        }

        public void UpdateMeetingNote(MeetingNoteModel meetingNote)
        {
            _dbContext.MeetingNotes.Update(meetingNote);
        }

        public ObservableCollection<MeetingNoteModel> GetMeetingNotes(MeetingModel meeting)
        {
            return new ObservableCollection<MeetingNoteModel>(_dbContext.MeetingNotes.Where(t => t.Meeting.Id == meeting.Id).ToList());
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
