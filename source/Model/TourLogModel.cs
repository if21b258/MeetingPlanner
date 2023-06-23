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
        public int Id { get; set; }
        public TourModel Tour { get; set; }
        public string Date { get; set; }
        public DateTime Time { get; set; }
        public string Comment { get; set; }
        public int Difficulty { get; set; }
        public float Duration { get; set; }
        public int Rating { get; set; }

        public TourLogModel() { }

        public TourLogModel(TourModel selectedTour, string date, int hours, int minutes, string comment, int difficulty, int durationHours, int durationMinutes, int rating)
        {
            Id = 0;
            Tour = selectedTour;
            Date = date;
            Time = hours + ":" + minutes;
            THours = hours;
            TMinutes = minutes;
            Comment = comment;
            Difficulty = difficulty;
            Duration = durationHours + ":" + durationMinutes;
            DHours = durationHours;
            DMinutes = durationMinutes;
            Rating = rating;
        }
    }
}
