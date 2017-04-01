namespace CameraBazaar.Services
{
    using AutoMapper;
    using Models.EntityModels;
    using Models.ViewModels.User;

    public class UserService : Service
    {
        public ProfileVm RetrieveProfileVm(string name)
        {
            ApplicationUser currentlyLogged = this.RetrieveCurrentUser(name);
            ProfileVm profileVm = Mapper.Map<ProfileVm>(currentlyLogged);

            return profileVm;
        }
    }
}
