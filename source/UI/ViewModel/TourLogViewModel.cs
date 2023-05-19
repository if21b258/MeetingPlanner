using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.source.Model;
using System.Collections.ObjectModel;

namespace TourPlanner.source.UI.ViewModel
{
    class TourLogViewModel
    {
        public ObservableCollection<TourLogModel> TourLogs { get; set; }
        public TourLogViewModel()
        {
            TourLogs = new ObservableCollection<TourLogModel>();
        }
    }
}
