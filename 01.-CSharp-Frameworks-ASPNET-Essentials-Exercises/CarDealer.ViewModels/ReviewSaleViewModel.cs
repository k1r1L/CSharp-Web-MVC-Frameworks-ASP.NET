namespace CarDealer.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ReviewSaleViewModel
    {
        public AddSaleCustomerViewModel Customer { get; set; }

        public AddSaleCarViewModel Car { get; set; }

        public string CarDisplay { get; set; }

        public double Discount { get; set; }

        public bool HasAdditionalDiscount { get; set; }

        public double? CarPrice { get; set; }

        public double? FinalCarPrice { get; set; }
    }
}
