using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.BindingModels
{
    public class AddSaleBindingModel
    {
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public double Discount { get; set; }
    }
}
