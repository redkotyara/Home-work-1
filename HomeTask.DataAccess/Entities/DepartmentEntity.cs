using System.Collections.Generic;

namespace HomeTask.DataAccess.Entities
{
    public class DepartmentEntity
    {
        public int DepartmentId { get; set; }

        public int FloorNumber { get; set; }

        public string DepartmentName { get; set; }

        public ICollection<EmployeeEntity> Employees { get; set; }
    }
}