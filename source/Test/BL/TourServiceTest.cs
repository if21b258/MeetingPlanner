using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.IO.Packaging;
using TourPlannerBL.Service;
using TourPlannerDAL;
using TourPlannerModel;

namespace TourPlannerTest.BL
{
    internal class TourServiceTest
    {

        private TourService tourService;
        TourModel tour1 = new TourModel { Id = 1, Name = "Tour 1", Description = "", Origin = "", Destination = "" };
        TourModel tour2 = new TourModel { Id = 2, Name = "Tour 2", Description = "", Origin = "", Destination = "" };
        TourModel tour3 = new TourModel { Id = 3, Name = "Tour 3", Description = "", Origin = "", Destination = "" };
        TourLogModel log1 = new TourLogModel { Id = 1, Comment = "Log 1" };
        TourLogModel log2 = new TourLogModel { Id = 2, Comment = "Log 2" };
        TourLogModel log3 = new TourLogModel { Id = 3, Comment = "Log 3" };

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TourPlannerDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

            using (var context = new TourPlannerDbContext(options))
            {
                context.Tours.Add(tour1);
                context.Tours.Add(tour2);

                log1.Tour = tour1;
                log2.Tour = tour2;
                log3.Tour = tour3;

                context.TourLogs.Add(log1);
                context.TourLogs.Add(log2);

                context.SaveChanges();
            }
        }

        [TearDown]
        public void TearDown()
        {
            var options = new DbContextOptionsBuilder<TourPlannerDbContext>()
            .UseInMemoryDatabase(databaseName: "InMemoryDb")
            .Options;

            using (var context = new TourPlannerDbContext(options))
            {
                context.Tours.RemoveRange(context.Tours);
                context.TourLogs.RemoveRange(context.TourLogs);
                context.SaveChanges();
            }
        }

        [Test]
        public void GetTours_WhenCalled_ReturnsListOfTours()
        {
            var options = new DbContextOptionsBuilder<TourPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new TourPlannerDbContext(options))
            {
                tourService = new TourService(context);
                var tours = tourService.GetTours();
                Assert.AreEqual(2, tours.Count);
            }
        }

        [Test]
        public void GetTourLogs_WhenCalled_ReturnsListOfTourLogs()
        {
            var options = new DbContextOptionsBuilder<TourPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new TourPlannerDbContext(options))
            {
                tourService = new TourService(context);
                var tours = tourService.GetTourLogs(tour1);
                Assert.AreEqual(1, tours.Count);
            }
        }

        [Test]
        public void AddTourLog_WhenCalled_AddsTourLog()
        {
            var options = new DbContextOptionsBuilder<TourPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new TourPlannerDbContext(options))
            {
                tourService = new TourService(context);
                tourService.AddTourLog(log3);
                var logs = tourService.GetTourLogs(tour3);
                Assert.AreEqual(1, logs.Count);
            }
        }

        [Test]
        public void EditTourLog_WhenCalled_EditsTourLog()
        {
            var options = new DbContextOptionsBuilder<TourPlannerDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;

            using (var context = new TourPlannerDbContext(options))
            {
                tourService = new TourService(context);
                log1.Comment = "New Comment";
                tourService.EditTourLog(log1);
                var logs = tourService.GetTourLogs(tour1);
                Assert.AreEqual("New Comment", logs[0].Comment);
            }
        }
    }
}
