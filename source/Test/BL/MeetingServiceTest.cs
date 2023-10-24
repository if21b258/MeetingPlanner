using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.IO.Packaging;
using MeetingPlannerBL.Service;
using MeetingPlannerDAL;
using MeetingPlannerModel;

namespace MeetingPlannerTest.BL
{
    internal class MeetingServiceTest
    {

        private MeetingService meetingService;
        MeetingModel meeting1 = new MeetingModel { Id = 1, Title = "Meeting 1", From = DateTime.Parse("2020-01-01"), To = DateTime.Parse("2020-01-01"), Agenda = "" };
        MeetingModel meeting2 = new MeetingModel { Id = 2, Title = "Meeting 2", From = DateTime.Parse("2020-01-01"), To = DateTime.Parse("2020-01-01"), Agenda = "" };
        MeetingModel meeting3 = new MeetingModel { Id = 3, Title = "Meeting 3", From = DateTime.Parse("2020-01-01"), To = DateTime.Parse("2020-01-01"), Agenda = "" };
        MeetingNoteModel note1 = new MeetingNoteModel { Id = 1, Note = "Note 1" };
        MeetingNoteModel note2 = new MeetingNoteModel { Id = 2, Note = "Note 2" };
        MeetingNoteModel note3 = new MeetingNoteModel { Id = 3, Note = "Note 3" };

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                context.Meetings.Add(meeting1);
                context.Meetings.Add(meeting2);

                note1.Meeting = meeting1;
                note2.Meeting = meeting2;
                note3.Meeting = meeting3;

                context.MeetingNotes.Add(note1);
                context.MeetingNotes.Add(note2);
                context.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                context.Meetings.RemoveRange(context.Meetings);
                context.MeetingNotes.RemoveRange(context.MeetingNotes);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetMeetings_WhenCalled_ReturnsListOfMeetings()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                meetingService = new MeetingService(context);
                var meetings = meetingService.GetMeetings();
                Assert.AreEqual(2, meetings.Count);
            }
        }

        [Test]
        public void GetMeetingNotes_WhenCalled_ReturnsListOfMeetingNotes()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                meetingService = new MeetingService(context);
                var meetings = meetingService.GetMeetingNotes(meeting1);
                Assert.AreEqual(1, meetings.Count);
            }
        }

        [Test]
        public void AddMeeting_WhenCalled_AddsMeeting()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                meetingService = new MeetingService(context);
                meetingService.AddMeeting(meeting3);
                var meetings = meetingService.GetMeetings();
                Assert.AreEqual(3, meetings.Count);
            }
        }

        [Test]
        public void AddMeetingNote_WhenCalled_AddsMeetingNote()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                meetingService = new MeetingService(context);
                meetingService.AddMeetingNote(note3);
                var notes = meetingService.GetMeetingNotes(meeting3);
                Assert.AreEqual(1, notes.Count);
            }
        }

        [Test]
        public void EditMeeting_WhenCalled_EditsMeeting()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                meetingService = new MeetingService(context);
                meeting1.Title = "New Title";
                meetingService.EditMeeting(meeting1);
                var meetings = meetingService.GetMeetings();
                Assert.AreEqual("New Title", meetings[1].Title);
            }
        }

        [Test]
        public void EditMeetingNote_WhenCalled_EditsMeetingNote()
        {
            var options = new DbContextOptionsBuilder<MeetingPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new MeetingPlannerDbContext(options))
            {
                meetingService = new MeetingService(context);
                note1.Note = "New Note";
                meetingService.EditMeetingNote(note1);
                var notes = meetingService.GetMeetingNotes(meeting1);
                Assert.AreEqual("New Note", notes[0].Note);
            }
        }
    }
}
