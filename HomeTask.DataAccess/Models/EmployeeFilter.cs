namespace HomeTask.DataAccess.Models
{
    public class EmployeeFilter
    {
        public int? DepartmentId { get; set; }

        public string? LastMame { get; set; }

        public string? FirstName { get; set; }

        public int? Age { get; set; }

        public int? ProgramLanguageId { get; set; }

        public int? GenderId { get; set; }
    }
}