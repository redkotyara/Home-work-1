using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeTask.BusinessLogic.Models
{
    public class CreateOrUpdateEmployeeModel
    {
        public int EmployeeId { get; set; }
        
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        [Required, Range(18, 100, ErrorMessage = "Please enter from 18 to 100")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "Please select gender")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select gender")]
        public int GenderId { get; set; }

        [Required(ErrorMessage = "Please select department")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select program languages")]
        [MinLength(1, ErrorMessage = "Please select program languages")]
        public int[] ProgramingLanguageIds { get; set; }
    }
}