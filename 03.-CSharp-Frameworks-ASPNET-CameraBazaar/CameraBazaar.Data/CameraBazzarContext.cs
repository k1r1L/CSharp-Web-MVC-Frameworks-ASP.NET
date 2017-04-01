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

        public DbSet<Camera> Cameras { get; set; }

        public static CameraBazzarContext Create()
        {
            return new CameraBazzarContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Camera>()
                .Property(c => c.Price)
                .HasPrecision(16, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}