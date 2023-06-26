using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TourPlannerModel
{
    public enum Transport
    {
        [Display(Name = "Car")]
        Fastest,

        [Display(Name = "By Foot")]
        Pedestrian,

        [Display(Name = "Bicycle")]
        Bicycle
    }
}
