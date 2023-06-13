using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlannerUI.Model
{
    public class TourModel
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string TransportType { get; set; }
        public string Description { get; set; }
        public string Distance { get; set; }
        public string EstimatedTime { get; set; }
        public string RouteInformation { get; set; }

        public TourModel(string name, string origin, string destination, string transportType, string description, string distance, string estimatedTime, string routeInformation)
        {
            TourId = 0;
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
            TourId = 0;
            Name = name;
            Origin = origin;
            Destination = destination;
            TransportType = transportType;
            Description = description;
            Distance = null;
            EstimatedTime = null;
            RouteInformation = null;
        }
    }
}
