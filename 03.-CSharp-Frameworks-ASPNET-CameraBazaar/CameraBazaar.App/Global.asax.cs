using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CameraBazaar.App
{
    using AutoMapper;
    using Models.EntityModels;
    using Models.ViewModels.Camera;
    using Models.ViewModels.User;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureAutomapping();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void ConfigureAutomapping()
        {
            Mapper.Initialize(
                action =>
                {
                    action.CreateMap<AddCameraVm, Camera>();
                    action.CreateMap<Camera, AllCameraVm>()
                        .ForMember(vm => vm.InStock,
                            configurationExpression => configurationExpression.MapFrom(entity => entity.Quantity != 0))
                        .ForMember(vm => vm.SellerUsername,
                            configurationExpression => configurationExpression.MapFrom(entity => entity.Owner.UserName));
                    action.CreateMap<ApplicationUser, ProfileVm>()
                        .ForMember(vm => vm.CamerasInStock,
                            configurationExpression =>
                                configurationExpression.MapFrom(
                                    appUser => appUser.Cameras.Count(c => c.Quantity != 0)))
                        .ForMember(vm => vm.CamerasOutOfStock,
                            configurationExpression =>
                                configurationExpression.MapFrom(
                                    appUser => appUser.Cameras.Count(c => c.Quantity == 0)));
                    action.CreateMap<Camera, DetailsCameraVm>()
                        .ForMember(vm => vm.InStock,
                            configurationExpression => configurationExpression.MapFrom(entity => entity.Quantity != 0))
                        .ForMember(vm => vm.SellerUsername,
                            configurationExpression => configurationExpression.MapFrom(entity => entity.Owner.UserName));
                    action.CreateMap<Camera, EditCameraVm>();
                    action.CreateMap<Camera, DeleteCameraVm>();
                    action.CreateMap<ApplicationUser, EditProfileVm>()
                        .ForMember(vm => vm.Password, configurationExpression => configurationExpression.Ignore());

                });
        }

    }
}
