using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//Model for a Meeting
namespace MeetingPlannerModel
{
    public class MeetingModel
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public ICollection<MeetingNoteModel> MeetingNotes { get; set; }
        public string Title { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Agenda { get; set; }
        [NotMapped]
        public bool Visible { get; set; } = true;

        public MeetingModel() { }

        public MeetingModel(string title, DateTime from, DateTime to, string agenda)
        {
            Title = title;
            From = from;
            To = to;
            Agenda = agenda;
        }
    }
}
