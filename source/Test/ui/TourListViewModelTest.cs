using log4net;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlannerModel;
using TourPlannerUI.ViewModel;
using TourPlannerBL.Service;

namespace TourPlannerTest.UI
{
    public class TourListViewModelTest
    {
        private TourModel _tour = new TourModel("Name", "Origin", "Destination", Transport.Fastest, "Description");

       
        [Test]
        public void CheckTour()
        {
            Assert.AreEqual("Name", _tour.Name);
            Assert.AreEqual("Origin", _tour.Origin);
            Assert.AreEqual("Destination", _tour.Destination);
            Assert.AreEqual(Transport.Fastest, _tour.TransportType);
            Assert.AreEqual("Description", _tour.Description);
        }


        [Test]
        public void CheckTourLog()
        {

            TourModel selectedTour = new TourModel();
            DateTime date = DateTime.Now;
            string comment = "This is a Comment!!";
            int difficulty = 3;
            TimeSpan duration = TimeSpan.FromMinutes(45);
            int rating = 4;
            TourLogModel tourLog = new TourLogModel(selectedTour, date, comment, difficulty, duration, rating);

            Assert.AreEqual(selectedTour, tourLog.Tour);
            Assert.AreEqual(date, tourLog.Date);
            Assert.AreEqual(comment, tourLog.Comment);
            Assert.AreEqual(difficulty, tourLog.Difficulty);
            Assert.AreEqual(duration, tourLog.Duration);
            Assert.AreEqual(rating, tourLog.Rating);
        }

        [Test]
        public void CheckSetterAndGetterId()
        {
            TourLogModel tourLog = new TourLogModel();
            int expectedId = 42;
            tourLog.Id = expectedId;
            int? actualId = tourLog.Id;
            Assert.AreEqual(expectedId, actualId);
        }
       
    }
}
