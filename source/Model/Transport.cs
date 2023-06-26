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
    
    public static class TransportExtension
    {

        public static Transport GetTransportType(string comboBoxValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(comboBoxValue) && comboBoxValue.Contains(":"))
                {
                    int startIndex = comboBoxValue.IndexOf(":") + 1;
                    string transportType = comboBoxValue.Substring(startIndex).Trim();
                    switch (transportType)
                    {
                        case "Car":
                            return Transport.Fastest;
                        case "By Foot":
                            return Transport.Pedestrian;
                        case "Bicycle":
                            return Transport.Bicycle;
                        default:
                            return Transport.Fastest;
                    }
                }
                else
                {
                    throw new NullReferenceException();

                }

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Transporttype value was null");
                return Transport.Fastest;
            }

        }



    }
    
   
}
