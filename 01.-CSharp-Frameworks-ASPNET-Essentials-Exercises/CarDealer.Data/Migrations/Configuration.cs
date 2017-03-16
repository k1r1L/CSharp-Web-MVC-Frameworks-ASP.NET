namespace CarDealer.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealer.Data.CarDealerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CarDealer.Data.CarDealerContext";
        }

        protected override void Seed(CarDealer.Data.CarDealerContext context)
        {

        }
    }
}
