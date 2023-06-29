using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TourPlannerModel;
using TourPlannerUI.ViewModel;
using TourPlannerBL.Util;

namespace TourPlannerTest.UI
{
    public class AddTourViewModelTest
    {

        [Test]
        public void CheckSetterGetterOrigin()
        {
            AddTourViewModel addTourViewModel = new AddTourViewModel();
            addTourViewModel.Origin = "Origin";
            Assert.AreEqual("Origin", addTourViewModel.Origin);
        }
        [Test]
        public void CheckSetterGetterDestination()
        {
            AddTourViewModel addTourViewModel = new AddTourViewModel();
            addTourViewModel.Destination = "Destination";
            Assert.AreEqual("Destination", addTourViewModel.Destination);
        }

        [Test]
        public void CheckSetterGetterTransportType()
        { 
            AddTourViewModel addTourViewModel = new AddTourViewModel();
            addTourViewModel.TransportType = Transport.Fastest;
            Assert.AreEqual(Transport.Fastest, addTourViewModel.TransportType);
        }

        [Test]
        public void CheckSetterGetterDescription()
        {
            AddTourViewModel addTourViewModel = new AddTourViewModel();
            addTourViewModel.Description = "Description";
            Assert.AreEqual("Description", addTourViewModel.Description);
        }
        [Test]
        public void CheckEnum()
        {
           
            AddTourViewModel addTourViewModel = new AddTourViewModel();

           
            var transportEnumForCombo = addTourViewModel.TransportEnumForCombo;

           
            Assert.AreEqual(3, transportEnumForCombo.Count);
            Assert.IsTrue(transportEnumForCombo.ContainsKey(Transport.Fastest));
            Assert.IsTrue(transportEnumForCombo.ContainsKey(Transport.Pedestrian));
            Assert.IsTrue(transportEnumForCombo.ContainsKey(Transport.Bicycle));
            Assert.AreEqual("Car", transportEnumForCombo[Transport.Fastest]);
            Assert.AreEqual("By Foot", transportEnumForCombo[Transport.Pedestrian]);
            Assert.AreEqual("Bicycle", transportEnumForCombo[Transport.Bicycle]);
        }



    }

}
