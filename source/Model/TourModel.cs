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
        public int Id { get; set; }
        public ICollection<TourLogModel> Logs { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string TransportType { get; set; }
        public string Description { get; set; }
        public float Distance { get; set; }
        public float EstimatedTime { get; set; }
        public string RouteInformation { get; set; }

        [NotMapped]
        public byte[] Map { get; set; }

        public TourModel() { }

        public TourModel(string name, string origin, string destination, string transportType, string description, float distance, float estimatedTime, string routeInformation)
        {
            Id = 0;
            Name = name;
            Origin = origin;
            Destination = destination;
            TransportType = transportType;
            Description = description;
            Distance = distance;
            EstimatedTime = estimatedTime;
            RouteInformation = routeInformation;
        }

        public TourModel(string name, string origin, string destination, string transportType, string description)
        {
            Id = 0;
            Name = name;
            Origin = origin;
            Destination = destination;
            TransportType = transportType;
            Description = description;
            Distance = 0;
            EstimatedTime = 0;
            RouteInformation = null;
        }
    }
}
