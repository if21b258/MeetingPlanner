using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourPlannerModel
{
    public class TourModel
    {
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

        public TourModel(string name, string origin, string destination, string description, float distance, TimeSpan estimatedTime)
        {
            Name = name;
            Origin = origin;
            Destination = destination;
            Description = description;
            Distance = distance;
            EstimatedTime = estimatedTime;
        }

        public TourModel(string name, string origin, string destination, string description)
        {
            Name = name;
            Origin = origin;
            Destination = destination;
            Description = description;
            Distance = 0;
        }
    }
}
