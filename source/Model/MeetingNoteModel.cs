using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//Model for a MeetingNote
namespace MeetingPlannerModel
{
    public class MeetingNoteModel
    {
        [JsonIgnore]
        public int? Id { get; set; }
        [JsonIgnore]
        public MeetingModel Meeting { get; set; }
        public string Note { get; set; }

        public MeetingNoteModel() { }

        public MeetingNoteModel(MeetingModel selectedMeeting, string note)
        {
            Meeting = selectedMeeting;
            Note = note;
        }
    }
}
