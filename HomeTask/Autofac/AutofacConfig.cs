using System.Reflection;
using System.Web.Configuration;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using HomeTask.BusinessLogic.MapperConfig;
using HomeTask.BusinessLogic.Services;
using HomeTask.BusinessLogic.Services.Interfaces;
using HomeTask.Controllers;
using HomeTask.DataAccess;
using HomeTask.DataAccess.DatabaseContexts;
using HomeTask.DataAccess.Repositories;
using HomeTask.DataAccess.Repositories.Interfaces;
using HomeTask.Filters;

namespace HomeTask.Autofac
{
    public static class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            builder
                .RegisterType<DatabaseContext>()
                .InstancePerRequest();

            builder.RegisterType<EmployeeRepository>()
                .As<IEmployeeRepository>()
                .InstancePerRequest();
            
            builder.RegisterType<DepartmentRepository>()
                .As<IDepartmentRepository>()
                .InstancePerRequest();
            
            builder.RegisterType<ProgramingLanguageRepository>()
                .As<IProgramingLanguageRepository>()
                .InstancePerRequest();
            
            builder.RegisterType<GenderRepository>()
                .As<IGenderRepository>()
                .InstancePerRequest();
            
            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerRequest();
            
            builder.RegisterType<PopularNamesRepository>()
                .As<IPopularNamesRepository>()
                .InstancePerRequest();

            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfiles(new Profile[]
                {
                    new BusinessLogicMapperConfig(),
                });
            });

            var mapper = mapperConfig.CreateMapper();
            
            builder.RegisterInstance(mapper).SingleInstance();

            builder
                .RegisterType<EmployeeService>()
                .As<IEmployeeService>()
                .InstancePerRequest();
            
            builder
                .RegisterType<ProgramingLanguageService>()
                .As<IProgramingLanguageService>()
                .InstancePerRequest();
            
            builder
                .RegisterType<DepartmentService>()
                .As<IDepartmentService>()
                .InstancePerRequest();
            
            builder
                .RegisterType<GenderService>()
                .As<IGenderService>()
                .InstancePerRequest();
            
            builder.RegisterType<UserService>()
                .As<IUserService>()
                .InstancePerRequest();

            builder.RegisterType<PopularNamesService>()
                .As<IPopularNamesService>()
                .InstancePerRequest();
            
            builder.RegisterFilterProvider();

            var container = builder.Build();
                
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}