﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlannerModel;

namespace TourPlannerDAL.Repository
{
    public class TourLogRepository
    {
        private TourPlannerDbContext _dbContext;

        public TourLogRepository(TourPlannerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddTourLog(TourLogModel tourLog)
        {
            _dbContext.TourLogs.Add(tourLog);
            _dbContext.SaveChanges();
        }

        public void DeleteTourLog(TourLogModel tourLog)
        {
            _dbContext.TourLogs.Remove(tourLog);
            _dbContext.SaveChanges();
        }

        public void UpdateTourLog(TourLogModel tourLog)
        {
            _dbContext.TourLogs.Update(tourLog);
            _dbContext.SaveChanges();
        }

        public ObservableCollection<TourLogModel> GetTourLogs(TourModel tour)
        {
            return new ObservableCollection<TourLogModel>(_dbContext.TourLogs.Where(t => t.Tour.Id == tour.Id).ToList());
        }
    }
}