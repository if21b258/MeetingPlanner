using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlannerUI.Model
{
    public class DurationModel
    {
        int Hours { get; set; }
        int Minutes { get; set; }


        public DurationModel(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }
    }
}
