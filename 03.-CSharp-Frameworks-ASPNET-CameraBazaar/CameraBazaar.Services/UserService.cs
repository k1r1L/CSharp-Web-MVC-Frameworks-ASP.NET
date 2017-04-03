namespace CameraBazaar.Services
{
    using System.Linq;
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

        public EditProfileVm RetrieveEditProfileVm(string username)
        {
            ApplicationUser appUser = this.DbContext.Users
                .First(user => user.UserName == username);

            EditProfileVm editProfileVm = Mapper.Map<EditProfileVm>(appUser);

            return editProfileVm;
        }
    }
}
