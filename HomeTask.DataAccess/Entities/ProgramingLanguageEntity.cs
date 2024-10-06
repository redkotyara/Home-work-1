using System.Collections.Generic;

namespace HomeTask.DataAccess.Entities
{
    public class ProgramingLanguageEntity
    {
        public int ProgramingLanguageId { get; set; }

        public string ProgramingLanguageName { get; set; }

        public ICollection<EmployeeExperienceEntity> Employees { get; set; }
    }
}