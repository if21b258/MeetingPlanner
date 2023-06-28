using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public TourModel() { }

        public TourModel(int? id, ICollection<TourLogModel> logs, string name, string origin, string destination, Transport transportType, string description, float distance, TimeSpan? estimatedTime)
        {
            Id = id;
            Logs = logs;
            Name = name;
            Origin = origin;
            Destination = destination;
            TransportType = transportType;
            Description = description;
            Distance = distance;
            EstimatedTime = estimatedTime;
        }

        public TourModel(string name, string origin, string destination, string description, float distance, TimeSpan estimatedTime)
        {
            Name = name;
            Origin = origin;
            Destination = destination;
            Description = description;
            Distance = distance;
            EstimatedTime = estimatedTime;
        }

        public TourModel(string name, string origin, Transport transporType, string destination, string description)
        {
            Name = name;
            Origin = origin;
            TransportType = transporType;
            Destination = destination;
            Description = description;
            Distance = 0;
        }
    }
}
