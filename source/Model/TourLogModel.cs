using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TourPlannerModel
{
    public class TourLogModel
    {
        public int? Id { get; set; }
        public TourModel Tour { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Difficulty { get; set; }
        public TimeSpan Duration { get; set; }
        public int Rating { get; set; }

        public TourLogModel() { }

        public TourLogModel(TourModel selectedTour, DateTime date, string comment, int difficulty, TimeSpan duration, int rating)
        {
            Tour = selectedTour;
            Date = date;
            Comment = comment;
            Difficulty = difficulty;
            Duration = duration;
            Rating = rating;
        }
    }
}
