namespace CarDealer.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;

    public abstract class Service
    {
        protected Service()
             : this(new CarDealerContext())
        {

        }

        protected Service(CarDealerContext dbContext)
        {
            this.DbContext = dbContext;
        }

        protected CarDealerContext DbContext { get; set; }
    }
}
