using System.Linq;
using AutoMapper;
using HomeTask.BusinessLogic.Models;
using HomeTask.DataAccess.Entities;
using HomeTask.DataAccess.Models;

namespace HomeTask.BusinessLogic.MapperConfig
{
    public class BusinessLogicMapperConfig : Profile
    {
        public BusinessLogicMapperConfig()
        {
            CreateMap<EmployeeFilter, GetEmployeesFilter>()
                .ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.GenderId, o => o.MapFrom(s => s.GenderId))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.Age))
                .ForMember(d => d.ProgramLanguageId, o => o.MapFrom(s => s.ProgramLanguageId))
                .ForMember(d => d.LastMame, o => o.MapFrom(s => s.LastMame))
                .ReverseMap();
            
            CreateMap<GenderEntity, GenderModel>()
                .ForMember(d => d.GenderName, opt => opt.MapFrom(s => s.GenderName))
                .ForMember(d => d.GenderId, opt => opt.MapFrom(s => s.GenderId));
            
            CreateMap<DepartmentEntity, DepartmentModel>()
                .ForMember(d => d.DepartmentName, o => o.MapFrom(s => s.DepartmentName))
                .ForMember(d => d.FloorNumber, o => o.MapFrom(s => s.FloorNumber))
                .ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId));

            CreateMap<ProgramingLanguageEntity, ProgramingLanguageModel>()
                .ForMember(d => d.ProgramingLanguageName, o => o.MapFrom(s => s.ProgramingLanguageName))
                .ForMember(d => d.ProgramingLanguageId, o => o.MapFrom(s => s.ProgramingLanguageId));
            
            CreateMap<EmployeeEntity, EmployeeModel>()
                .ForMember(d => d.EmployeeId, o => o.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.Age))
                .ForMember(d => d.ProgramingLanguages, o => o.MapFrom(s => s.Experiences.Select(x => x.ProgramingLanguage)))
                .ForMember(d => d.Department, o => o.MapFrom(s => s.Department))
                .ForMember(d => d.Gender, o => o.MapFrom(s => s.Gender));

            CreateMap<CreateOrUpdateEmployeeModel, EmployeeEntity>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.Age, o => o.MapFrom(s => s.Age))
                .ForMember(d => d.GenderId, o => o.MapFrom(s => s.GenderId))
                .ForMember(d => d.Gender, o => o.Ignore())
                .ForMember(d => d.LastName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.DepartmentId, o => o.MapFrom(s => s.DepartmentId))
                .ForMember(d => d.EmployeeId, o => o.MapFrom(s => s.EmployeeId))
                .ForMember(d => d.Experiences, o => 
                    o.MapFrom(s => s.ProgramingLanguageIds.Select(programingLanguageId => new EmployeeExperienceEntity
                {
                    ProgramingLanguageId = programingLanguageId,
                    EmployeeId = s.EmployeeId
                })));
        }
    }
}