using System.Collections.Generic;

namespace HomeTask.DataAccess.Entities
{
    public class EmployeeExperienceEntity
    {
        public int EmployeeId { get; set; }

        public virtual EmployeeEntity Employee { get; set; }

        public int ProgramingLanguageId { get; set; }

        public ProgramingLanguageEntity ProgramingLanguage { get; set; }
    }
}