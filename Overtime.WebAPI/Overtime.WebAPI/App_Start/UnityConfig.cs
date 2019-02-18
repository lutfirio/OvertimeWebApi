using BussinessLogic.Service;
using BussinessLogic.Service.Master;
using Common.Interface;
using Common.Interface.Master;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Overtime.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();

            container.RegisterType<IRegencyService, RegencyService>();
            container.RegisterType<IRegencyRepository, RegencyRepository>();


            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<IDistrictRepository, DistrictRepository>();

            container.RegisterType<IVillageService, VillageService>();
            container.RegisterType<IVillageRepository, VillageRepository>();

            container.RegisterType<IPositionService, PositionService>();
            container.RegisterType<IPositionRepository, PositionRepository>();

            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}