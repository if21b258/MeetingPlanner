using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlannerUI.Model
{
    class Tour
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Trasportation { get; set; }
        public string Distance { get; set; }
        public string EstimatedTime { get; set; }
        public string RouteInformation { get; set; }
        
    }
}
