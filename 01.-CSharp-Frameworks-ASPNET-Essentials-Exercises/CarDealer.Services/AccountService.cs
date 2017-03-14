namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using BindingModels;
    using Models;

    public class AccountService : Service
    {
        public void RegisterUser(RegisterUserBindingModel rubm)
        {
            User userEntity = Mapper.Map<User>(rubm);
            this.DbContext.Users.Add(userEntity);
            this.DbContext.SaveChanges();
        }

        public void LoginUser(LoginUserBindingModel lubm, string sessionId)
        {
            Login log = new Login()
            {
                IsActive = true,
                SessionId = sessionId,
                User = this.DbContext.Users.First(user => user.Password == lubm.Password && user.Username == lubm.Username)
            };

            this.DbContext.Logins.Add(log);
            this.DbContext.SaveChanges();
        }

        public bool UserExists(LoginUserBindingModel lubm)
        {
            return this.DbContext.Users.Any(user => user.Password == lubm.Password && user.Username == lubm.Username);
        }

        public void LogoutUser()
        {
            this.DbContext.Logins.Remove(this.DbContext.Logins.First());
            this.DbContext.SaveChanges();
        }

        public User GetCurrentUser()
        {
            return this.DbContext.Logins.First().User;
        }
    }
}
