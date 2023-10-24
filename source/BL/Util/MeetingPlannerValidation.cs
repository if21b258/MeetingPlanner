using MeetingPlannerModel;

namespace MeetingPlannerBL.Util
{
    public class MeetingPlannerValidation
    {
        public bool ValidateMeetingInput(MeetingModel meeting)
        {
            if (string.IsNullOrEmpty(meeting.Title))
            {
                return false;
            }

            if (string.IsNullOrEmpty(meeting.From.ToString()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(meeting.To.ToString()))
            {
                return false;
            }

            if (string.IsNullOrEmpty(meeting.Agenda))
            {
                return false;
            }

            return true;

        }

        public bool ValidateMeetingNoteInput(MeetingNoteModel meetingNote)
        {
            if (string.IsNullOrEmpty(meetingNote.Note))
            {
                return false;
            }

            return true;

        }
    }
}
