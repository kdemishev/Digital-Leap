using System.Web.Mvc;
using AutoMapper;
using Unity;
using Unity.Mvc5;
using DigitalLeap.Services;
using DigitalLeap.Repositories;
using DigitalLeap.Web.MappingProfiles;
using Unity.Lifetime;


namespace DigitalLeap.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IEnquiryService, EnquiryService>();

            container.RegisterType<IEnquiryRepository, EnquiryRepository>();

            container.RegisterType<DataContext, DataContext>(new PerThreadLifetimeManager());

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DataProfile>();
            });

            var mapper = config.CreateMapper();

            container.RegisterInstance(mapper);

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}