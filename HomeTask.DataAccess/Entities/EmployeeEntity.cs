using System.Collections.Generic;

namespace HomeTask.DataAccess.Entities
{
    public class EmployeeEntity
    {
        public int EmployeeId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int GenderId { get; set; }
        
        public virtual GenderEntity Gender { get; set; }

        public int DepartmentId { get; set; }

        public bool IsDeleted { get; set; }
        
        public virtual DepartmentEntity Department { get; set; }
        
        public ICollection<EmployeeExperienceEntity> Experiences { get; set; }
    }
}