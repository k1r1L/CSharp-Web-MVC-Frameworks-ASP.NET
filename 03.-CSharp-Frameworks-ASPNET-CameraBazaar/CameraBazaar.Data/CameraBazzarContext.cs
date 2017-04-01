namespace CameraBazaar.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    public class CameraBazzarContext : IdentityDbContext<ApplicationUser>
    {
        public CameraBazzarContext()
            : base("name=CameraBazzarContext")
        {
        }

        public static CameraBazzarContext Create()
        {
            return new CameraBazzarContext();
        }
    }
}