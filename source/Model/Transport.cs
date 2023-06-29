using System.ComponentModel.DataAnnotations;

//Transport Enum
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
