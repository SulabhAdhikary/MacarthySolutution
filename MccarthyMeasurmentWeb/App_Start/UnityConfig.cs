using MccarthyMeasurementService;
using MccathyDataAccessLayer;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MccarthyMeasurmentWeb
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //MeasurementService : IMeasurementService
            container.RegisterType<IMeasurementService, MeasurementService>();
            container.RegisterType<IDataAccessDalRepo, DataAccessDalRepo>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}