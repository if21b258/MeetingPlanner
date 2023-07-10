using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

//Model for the Tour
namespace TourPlannerModel
{
    public class TourModel
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public ICollection<TourLogModel> Logs { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public Transport TransportType { get; set; }
        public string Description { get; set; }
        public float Distance { get; set; }
        public TimeSpan? EstimatedTime { get; set; }
        [NotMapped]
        public bool Visible { get; set; } = true;

        public TourModel() { }

        public TourModel(string name, string origin, string destination, Transport transportType, string description)
        {
            Name = name;
            Origin = origin;
            Destination = destination;
            TransportType = transportType;
            Description = description;
        }
    }
}
