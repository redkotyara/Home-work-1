using System.ComponentModel.DataAnnotations;

namespace HomeTask.BusinessLogic.Models
{
    public class DepartmentModel
    {
        [Display(Name = "Floor number")]
        public int FloorNumber { get; set; }

        [Display(Name = "Department name")]
        public string DepartmentName { get; set; }

        public int DepartmentId { get; set; }
    }
}