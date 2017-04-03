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
        }

        protected CameraBazzarContext DbContext { get; set; }

        protected ApplicationUser RetrieveCurrentUser(string username)
        {
            return this.DbContext.Users.First(user => user.UserName == username);
        }
    }
}
