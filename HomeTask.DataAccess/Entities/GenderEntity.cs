using System.Collections.Generic;

namespace HomeTask.DataAccess.Entities
{
    public class GenderEntity
    {
        public int GenderId { get; set; }

        public string GenderName { get; set; }
        
        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}