using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeetingPlannerBL.Util;
using MeetingPlannerModel;

namespace MeetingPlannerTest.BL
{
    public class ValidationTests
    {
        [Test]
        public void ValidateMeetingInput_WhenCalled_ReturnsTrue()
        {
            MeetingModel meeting = new MeetingModel { Id = 1, Title = "Meeting 1", From = DateTime.Parse("2020-01-01"), To = DateTime.Parse("2020-01-01"), Agenda = "Agenda 1" };
            MeetingPlannerValidation meetingPlannerValidation = new MeetingPlannerValidation();
            bool result = meetingPlannerValidation.ValidateMeetingInput(meeting);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateMeetingInput_WhenCalled_ReturnsFalse()
        {
            MeetingModel meeting = new MeetingModel { Id = 1, Title = "", From = DateTime.Parse("2020-01-01"), To = DateTime.Parse("2020-01-01"), Agenda = "Agenda 1" };
            MeetingPlannerValidation meetingPlannerValidation = new MeetingPlannerValidation();
            bool result = meetingPlannerValidation.ValidateMeetingInput(meeting);
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateMeetingNoteInput_WhenCalled_ReturnsTrue()
        {
            MeetingNoteModel meetingNote = new MeetingNoteModel { Id = 1, Note = "Note 1" };
            MeetingPlannerValidation meetingPlannerValidation = new MeetingPlannerValidation();
            bool result = meetingPlannerValidation.ValidateMeetingNoteInput(meetingNote);
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateMeetingNoteInput_WhenCalled_ReturnsFalse()
        {
            MeetingNoteModel meetingNote = new MeetingNoteModel { Id = 1, Note = "" };
            MeetingPlannerValidation meetingPlannerValidation = new MeetingPlannerValidation();
            bool result = meetingPlannerValidation.ValidateMeetingNoteInput(meetingNote);
            Assert.IsFalse(result);
        }
    }
}
