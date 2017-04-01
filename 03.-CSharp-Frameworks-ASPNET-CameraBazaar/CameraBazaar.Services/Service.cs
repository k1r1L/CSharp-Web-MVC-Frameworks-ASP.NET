namespace CameraBazaar.Services
{
    using System.Linq;
    using AutoMapper;
    using Data;
    using Models.EntityModels;
    using Models.ViewModels.Camera;
    using Models.ViewModels.User;

    public abstract class Service
    {
        protected Service()
        {
            this.DbContext = CameraBazzarContext.Create();
            ConfigureAutomapping();
        }

        protected CameraBazzarContext DbContext { get; set; }

        protected void ConfigureAutomapping()
        {
            Mapper.Initialize(
                action =>
                {
                    action.CreateMap<AddCameraVm, Camera>();
                    action.CreateMap<Camera, AllCameraVm>()
                        .ForMember(vm => vm.InStock,
                            configurationExpression => configurationExpression.MapFrom(entity => entity.Quantity != 0));
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

                });
        }

        protected ApplicationUser RetrieveCurrentUser(string username)
        {
            return this.DbContext.Users.First(user => user.UserName == username);
        }
    }
}
