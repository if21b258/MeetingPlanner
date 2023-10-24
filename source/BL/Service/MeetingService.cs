using System.Collections.ObjectModel;
using System.Text.Json;
using MeetingPlannerBL.Logging;
using MeetingPlannerDAL;
using MeetingPlannerDAL.Repository;
using MeetingPlannerModel;

namespace MeetingPlannerBL.Service
{
    public class MeetingService : IMeetingService
    {
        private readonly ILoggerWrapper log = LoggerFactory.GetLogger();

        private MeetingPlannerDbContext _dbContext;
        private IMeetingRepository _meetingRepository;
        private IMeetingNoteRepository _meetingNoteRepository;

        public MeetingService(MeetingPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
            _meetingRepository = new MeetingRepository(dbContext);
            _meetingNoteRepository = new MeetingNoteRepository(dbContext);
        }

        public void AddMeeting(MeetingModel meeting)
        {
            _meetingRepository.AddMeeting(meeting);
            _meetingRepository.Save();

            log.Info($"Meeting with id: {meeting.Id} added to database");
        }

        public void EditMeeting(MeetingModel meeting)
        {
            _meetingRepository.UpdateMeeting(meeting);
            _meetingRepository.Save();

            log.Info($"Meeting with id: {meeting.Id} updated in database");
        }

        public void DeleteMeeting(MeetingModel meeting)
        {
            _meetingRepository.DeleteMeeting(meeting);
            _meetingRepository.Save();

            log.Info($"Meeting with id: {meeting.Id} removed from database");
        }

        public ObservableCollection<MeetingModel> GetMeetings()
        {
            return _meetingRepository.GetMeetings();
        }

        public void AddMeetingNote(MeetingNoteModel meetingNote)
        {
            _meetingNoteRepository.AddMeetingNote(meetingNote);
            _meetingNoteRepository.Save();

            log.Info($"MeetingNote with id: {meetingNote.Id} added to database");
        }

        public void EditMeetingNote(MeetingNoteModel meetingNote)
        {
            _meetingNoteRepository.UpdateMeetingNote(meetingNote);
            _meetingNoteRepository.Save();

            log.Info($"MeetingNote with id: {meetingNote.Id} updated in database");
        }

        public void DeleteMeetingNote(MeetingNoteModel meetingNote)
        {
            _meetingNoteRepository.DeleteMeetingNote(meetingNote);
            _meetingNoteRepository.Save();

            log.Info($"MeetingNote with id: {meetingNote.Id} removed from database");
        }

        public ObservableCollection<MeetingNoteModel> GetMeetingNotes(MeetingModel meeting)
        {
            return _meetingNoteRepository.GetMeetingNotes(meeting);
        }

        public void EnsureDatabaseCreated()
        {
            _dbContext.Database.EnsureCreated();
        }

        public void EnsureDatabaseDeleted()
        {
            _dbContext.Database.EnsureDeleted();
        }

        public void ExportMeeting(MeetingModel meeting, string filePath)
        {
            string jsonString = JsonSerializer.Serialize(meeting, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public void ImportMeeting(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            MeetingModel? meeting = JsonSerializer.Deserialize<MeetingModel>(jsonString);
            AddMeeting(meeting);
        }
    }
}