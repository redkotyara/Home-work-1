using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeTask.BusinessLogic.Models
{
    public class EmployeeModel
    {
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        public int EmployeeId { get; set; }

        public int Age { get; set; }
        
        public GenderModel Gender { get; set; }

        public DepartmentModel Department { get; set; }

        public IEnumerable<ProgramingLanguageModel> ProgramingLanguages { get; set; }
    }
}